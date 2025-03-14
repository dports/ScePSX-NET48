using System;
using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ScePSX;

public class MDEC : IDisposable
{
	private const int NUM_BLOCKS = 6;

	private const int MACRO_BLOCK_DECODED_BYTES = 768;

	private bool isDataInFifoFull;

	private bool isCommandBusy;

	private bool isDataInRequested;

	private bool isDataOutRequested;

	private uint dataOutputDepth;

	private bool isSigned;

	private uint bit15;

	private uint currentBlock;

	private uint remainingDataWords;

	private bool isColored;

	private byte[] luminanceQuantTable = new byte[64];

	private byte[] colorQuantTable = new byte[64];

	private short[] scaleTable = new short[64];

	private Action command;

	private short[][] block = new short[6][]
	{
		new short[64],
		new short[64],
		new short[64],
		new short[64],
		new short[64],
		new short[64]
	};

	private short[] dst = new short[64];

	private Queue<ushort> inBuffer = new Queue<ushort>(1024);

	private IMemoryOwner<byte> outBuffer = MemoryPool<byte>.Shared.Rent(196608);

	private int outBufferPos;

	private int yuvToRgbBlockPos;

	private int blockPointer = 64;

	private int q_scale;

	private int val;

	private ushort n;

	private static ReadOnlySpan<byte> zagzig => new byte[64]
	{
		0, 1, 8, 16, 9, 2, 3, 10, 17, 24,
		32, 25, 18, 11, 4, 5, 12, 19, 26, 33,
		40, 48, 41, 34, 27, 20, 13, 6, 7, 14,
		21, 28, 35, 42, 49, 56, 57, 50, 43, 36,
		29, 22, 15, 23, 30, 37, 44, 51, 58, 59,
		52, 45, 38, 31, 39, 46, 53, 60, 61, 54,
		47, 55, 62, 63
	};

	public void Dispose()
	{
		outBuffer?.Dispose();
	}

	public void write(uint addr, uint value)
	{
		uint num = addr & 0xF;
		switch (num)
		{
		case 0u:
			writeMDEC0_Command(value);
			return;
		case 4u:
			writeMDEC1_Control(value);
			return;
		}
		Console.WriteLine($"[GPU] Unhandled GPU write access to register {num} : {value}");
	}

	public void writeMDEC0_Command(uint value)
	{
		if (remainingDataWords == 0)
		{
			decodeCommand(value);
		}
		else
		{
			inBuffer.Enqueue((ushort)value);
			inBuffer.Enqueue((ushort)(value >> 16));
			remainingDataWords--;
			if (command == new Action(decodeMacroBlocks))
			{
				command();
			}
		}
		if (remainingDataWords == 0)
		{
			isCommandBusy = true;
			yuvToRgbBlockPos = 0;
			outBufferPos = 0;
			if (command != new Action(decodeMacroBlocks))
			{
				command();
			}
		}
	}

	private void decodeCommand(uint value)
	{
		uint num = value >> 29;
		dataOutputDepth = (value >> 27) & 3;
		isSigned = ((value >> 26) & 1) == 1;
		bit15 = (value >> 25) & 1;
		remainingDataWords = value & 0xFFFF;
		isColored = (value & 1) == 1;
		switch (num)
		{
		case 1u:
			command = decodeMacroBlocks;
			break;
		case 2u:
			command = setQuantTable;
			remainingDataWords = (uint)(16 + (isColored ? 16 : 0));
			break;
		case 3u:
			command = setScaleTable;
			remainingDataWords = 32u;
			break;
		default:
			Console.WriteLine("[MDEC] Unhandled Command " + num);
			break;
		}
	}

	private void decodeMacroBlocks()
	{
		while (inBuffer.Count != 0)
		{
			while (currentBlock < 6)
			{
				byte[] qt = ((currentBlock >= 2) ? luminanceQuantTable : colorQuantTable);
				if (!rl_decode_block(block[currentBlock], qt))
				{
					return;
				}
				idct_core(block[currentBlock]);
				currentBlock++;
			}
			currentBlock = 0u;
			yuv_to_rgb(block[2], 0, 0);
			yuv_to_rgb(block[3], 8, 0);
			yuv_to_rgb(block[4], 0, 8);
			yuv_to_rgb(block[5], 8, 8);
			yuvToRgbBlockPos += 768;
			blockPointer = 64;
			q_scale = 0;
			val = 0;
			n = 0;
		}
	}

	private void yuv_to_rgb(short[] Yblk, int xx, int yy)
	{
		Span<byte> span = stackalloc byte[3];
		for (int i = 0; i < 8; i++)
		{
			for (int j = 0; j < 8; j++)
			{
				int num = block[0][(j + xx) / 2 + (i + yy) / 2 * 8];
				int num2 = block[1][(j + xx) / 2 + (i + yy) / 2 * 8];
				int num3 = (int)(-0.3437 * (double)num2 + -0.7143 * (double)num);
				num = (int)(1.402 * (double)num);
				num2 = (int)(1.772 * (double)num2);
				short num4 = Yblk[j + i * 8];
				num = Math.Min(Math.Max(num4 + num, -128), 127);
				num3 = Math.Min(Math.Max(num4 + num3, -128), 127);
				num2 = Math.Min(Math.Max(num4 + num2, -128), 127);
				num ^= 0x80;
				num3 ^= 0x80;
				num2 ^= 0x80;
				span[0] = (byte)num;
				span[1] = (byte)num3;
				span[2] = (byte)num2;
				int start = (j + xx + (i + yy) * 16) * 3 + yuvToRgbBlockPos;
				Span<byte> destination = outBuffer.Memory.Span.Slice(start, 3);
				span.CopyTo(destination);
			}
		}
	}

	public bool rl_decode_block(short[] blk, byte[] qt)
	{
		if (blockPointer >= 64)
		{
			for (int i = 0; i < blk.Length; i++)
			{
				blk[i] = 0;
			}
			if (inBuffer.Count == 0)
			{
				return false;
			}
			for (n = inBuffer.Dequeue(); n == 65024; n = inBuffer.Dequeue())
			{
				if (inBuffer.Count == 0)
				{
					return false;
				}
			}
			q_scale = (n >> 10) & 0x3F;
			val = signed10bit(n & 0x3FF) * qt[0];
			blockPointer = 0;
		}
		while (blockPointer < blk.Length)
		{
			if (q_scale == 0)
			{
				val = signed10bit(n & 0x3FF) * 2;
			}
			val = Math.Min(Math.Max(val, -1024), 1023);
			if (q_scale > 0)
			{
				blk[zagzig[blockPointer]] = (short)val;
			}
			if (q_scale == 0)
			{
				blk[blockPointer] = (short)val;
			}
			if (inBuffer.Count == 0)
			{
				return false;
			}
			n = inBuffer.Dequeue();
			blockPointer += ((n >> 10) & 0x3F) + 1;
			val = (signed10bit(n & 0x3FF) * qt[blockPointer & 0x3F] * q_scale + 4) / 8;
		}
		return true;
	}

	private void idct_core(short[] src)
	{
		for (int i = 0; i < 2; i++)
		{
			for (int j = 0; j < 8; j++)
			{
				for (int k = 0; k < 8; k++)
				{
					int num = 0;
					for (int l = 0; l < 8; l++)
					{
						num += src[k + l * 8] * (scaleTable[j + l * 8] / 8);
					}
					dst[j + k * 8] = (short)((num + 4095) / 8192);
				}
			}
			short[] array = src;
			short[] array2 = dst;
			dst = array;
			src = array2;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private int signed10bit(int n)
	{
		return n << 22 >> 22;
	}

	private void setQuantTable()
	{
		for (int i = 0; i < 32; i++)
		{
			ushort num = inBuffer.Dequeue();
			luminanceQuantTable[i * 2] = (byte)num;
			luminanceQuantTable[i * 2 + 1] = (byte)(num >> 8);
		}
		if (isColored)
		{
			for (int j = 0; j < 32; j++)
			{
				ushort num2 = inBuffer.Dequeue();
				colorQuantTable[j * 2] = (byte)num2;
				colorQuantTable[j * 2 + 1] = (byte)(num2 >> 8);
			}
		}
	}

	private void setScaleTable()
	{
		for (int i = 0; i < 64; i++)
		{
			scaleTable[i] = (short)inBuffer.Dequeue();
		}
	}

	public void writeMDEC1_Control(uint value)
	{
		if (((value >> 31) & 1) == 1)
		{
			outBufferPos = 0;
			currentBlock = 0u;
			remainingDataWords = 0u;
			blockPointer = 64;
			q_scale = 0;
			val = 0;
			n = 0;
			command = null;
		}
		isDataInRequested = ((value >> 30) & 1) == 1;
		isDataOutRequested = ((value >> 29) & 1) == 1;
	}

	public uint readMDEC0_Data()
	{
		Memory<byte> memory;
		Span<byte> span;
		if (dataOutputDepth == 2)
		{
			memory = outBuffer.Memory;
			span = memory.Span;
            return Unsafe.ReadUnaligned<uint>(ref MemoryMarshal.GetReference(span.Slice(outBufferPos++ * 4, 4)));
        }
		if (dataOutputDepth == 3)
		{
			memory = outBuffer.Memory;
			span = memory.Span;
			Span<byte> span2 = span.Slice(outBufferPos++ * 6, 6);
			ushort num = (ushort)((bit15 << 15) | convert24to15bpp(span2[0], span2[1], span2[2]));
			return (uint)(((ushort)((bit15 << 15) | convert24to15bpp(span2[3], span2[4], span2[5])) << 16) | num);
		}
		return 16711935u;
	}

	public Span<uint> processDmaLoad(int size)
	{
		Memory<byte> memory;
		Span<byte> span;
		if (dataOutputDepth == 2)
		{
			memory = outBuffer.Memory;
			span = memory.Span;
			return MemoryMarshal.Cast<byte, uint>(span.Slice(outBufferPos++ * 4 * size, 4 * size));
		}
		if (dataOutputDepth == 3)
		{
			memory = outBuffer.Memory;
			span = memory.Span;
			Span<byte> span2 = span.Slice(outBufferPos++ * 6 * size, 6 * size);
			int num = 0;
			int num2 = 0;
			while (num < span2.Length)
			{
				int num3 = span2[num] >> 3;
				int num4 = span2[num + 1] >> 3;
				ushort num5 = (ushort)((span2[num + 2] >> 3 << 10) | (num4 << 5) | num3);
				byte b = (byte)num5;
				byte b2 = (byte)(num5 >> 8);
				span2[num2] = b;
				span2[num2 + 1] = b2;
				num += 3;
				num2 += 2;
			}
			return MemoryMarshal.Cast<byte, uint>(span2.Slice(0, 4 * size));
		}
		uint[] array = new uint[size];
		Span<uint> result = new Span<uint>(array);
		result.Fill(4278255360u);
		return result;
	}

	public ushort convert24to15bpp(byte sr, byte sg, byte sb)
	{
		byte b = (byte)(sr >> 3);
		byte b2 = (byte)(sg >> 3);
		return (ushort)(((byte)(sb >> 3) << 10) | (b2 << 5) | b);
	}

	public uint readMDEC1_Status()
	{
		uint result = 0 | ((isDataOutFifoEmpty() ? 1u : 0u) << 31) | ((isDataInFifoFull ? 1u : 0u) << 30) | ((isCommandBusy ? 1u : 0u) << 29) | ((isDataInRequested ? 1u : 0u) << 28) | ((isDataOutRequested ? 1u : 0u) << 27) | (dataOutputDepth << 25) | ((isSigned ? 1u : 0u) << 24) | (bit15 << 23) | ((currentBlock + 4) % 6 << 16) | (ushort)(remainingDataWords - 1);
		isCommandBusy = false;
		return result;
	}

	private bool isDataOutFifoEmpty()
	{
		return outBufferPos == 0;
	}
}
