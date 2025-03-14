using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ScePSX.CdRom2;

[Serializable]
public class CDSector
{
	public const int RAW_BUFFER = 2352;

	public const int XA_BUFFER = 18816;

	private byte[] sectorBuffer;

	private int pointer;

	private int size;

	public CDSector(int size)
	{
		sectorBuffer = new byte[size];
	}

	public void fillWith(Span<byte> data)
	{
		pointer = 0;
		size = data.Length;
		Span<byte> destination = sectorBuffer.AsSpan();
		data.CopyTo(destination);
	}

    public unsafe ref byte ReadByte()
    {
        fixed (byte* ptr = sectorBuffer)
        {
            return ref *(ptr + pointer++);
        }
    }

    public unsafe ref short readShort()
    {
        fixed (byte* ptr = sectorBuffer)
        {
            ref short result = ref *(short*)(ptr + pointer);
            pointer += 2;
            return ref result;
        }
    }

    public Span<uint> Read(int size)
	{
		Span<byte> span = sectorBuffer.AsSpan().Slice(pointer, size * 4);
		pointer += size * 4;
		return MemoryMarshal.Cast<byte, uint>(span);
	}

	public Span<byte> Read()
	{
		return sectorBuffer.AsSpan().Slice(0, size);
	}

	public bool HasData()
	{
		return pointer < size;
	}

	public bool hasSamples()
	{
		return size - pointer > 3;
	}

	public void Clear()
	{
		pointer = 0;
		size = 0;
	}
}
