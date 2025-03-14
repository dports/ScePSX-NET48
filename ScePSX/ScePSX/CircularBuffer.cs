using System;

namespace ScePSX;

public class CircularBuffer<T>
{
	private readonly T[] _buffer;

	private int _readPos;

	private int _writePos;

	private int _count;

	private readonly object _syncRoot = new object();

	public int Capacity { get; }

	public int Count => _count;

	public CircularBuffer(int capacity)
	{
		Capacity = capacity;
		_buffer = new T[capacity];
	}

	public void Write(T[] data, int offset = 0, int? length = null)
	{
		int num = length ?? (data.Length - offset);
		if (num <= 0)
		{
			return;
		}
		lock (_syncRoot)
		{
			int num2 = Math.Max(0, _count + num - Capacity);
			if (num2 > 0)
			{
				_readPos = (_readPos + num2) % Capacity;
				_count -= num2;
			}
			int num3 = Math.Min(num, Capacity - _writePos);
			Array.Copy(data, offset, _buffer, _writePos, num3);
			int num4 = num - num3;
			if (num4 > 0)
			{
				Array.Copy(data, offset + num3, _buffer, 0, num4);
			}
			_writePos = (_writePos + num) % Capacity;
			_count += num;
		}
	}

	public int Read(T[] output, int offset = 0, int? length = null)
	{
		int num = length ?? (output.Length - offset);
		if (num <= 0)
		{
			return 0;
		}
		lock (_syncRoot)
		{
			int num2 = Math.Min(num, _count);
			if (num2 == 0)
			{
				return 0;
			}
			int num3 = Math.Min(num2, Capacity - _readPos);
			Array.Copy(_buffer, _readPos, output, offset, num3);
			int num4 = num2 - num3;
			if (num4 > 0)
			{
				Array.Copy(_buffer, 0, output, offset + num3, num4);
			}
			_readPos = (_readPos + num2) % Capacity;
			_count -= num2;
			return num2;
		}
	}

	public void Clear()
	{
		lock (_syncRoot)
		{
			_readPos = 0;
			_writePos = 0;
			_count = 0;
			Array.Clear(_buffer, 0, Capacity);
		}
	}
}
