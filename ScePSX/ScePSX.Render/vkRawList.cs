using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ScePSX.Render;

public class vkRawList<T> : IEnumerable<T>, IEnumerable
{
	public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
	{
		private vkRawList<T> _list;

		private uint _currentIndex;

		public T Current => _list._items[_currentIndex];

		object IEnumerator.Current => Current;

		public Enumerator(vkRawList<T> list)
		{
			_list = list;
			_currentIndex = uint.MaxValue;
		}

		public bool MoveNext()
		{
			_currentIndex++;
			return _currentIndex < _list._count;
		}

		public void Reset()
		{
			_currentIndex = 0u;
		}

		public void Dispose()
		{
		}
	}

	private T[] _items;

	private uint _count;

	public const uint DefaultCapacity = 4u;

	private const float GrowthFactor = 2f;

	public uint Count
	{
		get
		{
			return _count;
		}
		set
		{
			Resize(value);
		}
	}

	public T[] Items => _items;

	public ArraySegment<T> ArraySegment => new ArraySegment<T>(_items, 0, (int)_count);

	public ref T this[uint index]
	{
		get
		{
			ValidateIndex(index);
			return ref _items[index];
		}
	}

	public ref T this[int index]
	{
		get
		{
			ValidateIndex(index);
			return ref _items[index];
		}
	}

	public vkRawList()
		: this(4u)
	{
	}

	public vkRawList(uint capacity)
	{
		_items = ((capacity == 0) ? Array.Empty<T>() : new T[capacity]);
	}

	public void Add(ref T item)
	{
		if (_count == _items.Length)
		{
			Array.Resize(ref _items, (int)((float)_items.Length * 2f));
		}
		_items[_count] = item;
		_count++;
	}

	public void Add(T item)
	{
		if (_count == _items.Length)
		{
			Array.Resize(ref _items, (int)((float)_items.Length * 2f));
		}
		_items[_count] = item;
		_count++;
	}

	public void AddRange(T[] items)
	{
		int num = (int)(_count + items.Length);
		if (num > _items.Length)
		{
			Array.Resize(ref _items, (int)((float)num * 2f));
		}
		Array.Copy(items, 0, _items, (int)_count, items.Length);
		_count += (uint)items.Length;
	}

	public void AddRange(IEnumerable<T> items)
	{
		foreach (T item in items)
		{
			Add(item);
		}
	}

	public void Replace(uint index, ref T item)
	{
		ValidateIndex(index);
		_items[index] = item;
	}

	public void Resize(uint count)
	{
		Array.Resize(ref _items, (int)count);
		_count = count;
	}

	public void Replace(uint index, T item)
	{
		Replace(index, ref item);
	}

	public bool Remove(ref T item)
	{
		uint index;
		bool index2 = GetIndex(item, out index);
		if (index2)
		{
			CoreRemoveAt(index);
		}
		return index2;
	}

	public bool Remove(T item)
	{
		uint index;
		bool index2 = GetIndex(item, out index);
		if (index2)
		{
			CoreRemoveAt(index);
		}
		return index2;
	}

	public void RemoveAt(uint index)
	{
		ValidateIndex(index);
		CoreRemoveAt(index);
	}

	public void Clear()
	{
		Array.Clear(_items, 0, _items.Length);
	}

	public bool GetIndex(T item, out uint index)
	{
		return (index = (uint)Array.IndexOf(_items, item)) != uint.MaxValue;
	}

	public void Sort()
	{
		Sort(null);
	}

	public void Sort(IComparer<T> comparer)
	{
		Array.Sort(_items, comparer);
	}

	public void TransformAll(Func<T, T> transformation)
	{
		for (int i = 0; i < _count; i++)
		{
			_items[i] = transformation(_items[i]);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void CoreRemoveAt(uint index)
	{
		_count--;
		Array.Copy(_items, (int)(index + 1), _items, (int)index, (int)(_count - index));
		_items[_count] = default(T);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void ValidateIndex(uint index)
	{
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void ValidateIndex(int index)
	{
	}

	public Enumerator GetEnumerator()
	{
		return new Enumerator(this);
	}

	IEnumerator<T> IEnumerable<T>.GetEnumerator()
	{
		return GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
