using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScePSX;

public class MemorySearch
{
	private byte[] data;

	public List<int> results;

	public MemorySearch(byte[] memory)
	{
		data = memory;
		ResetResults();
	}

	public void UpdateData(byte[] newMemory)
	{
		data = newMemory;
	}

	public void ResetResults()
	{
		results = Enumerable.Range(0, data.Length).ToList();
	}

	public void SearchByte(byte value)
	{
		results = Search((int index) => data[index] == value);
	}

	public void SearchWord(ushort value)
	{
		results = Search((int index) => index + 1 < data.Length && BitConverter.ToUInt16(data, index) == value);
	}

	public void SearchDword(uint value)
	{
		results = Search((int index) => index + 3 < data.Length && BitConverter.ToUInt32(data, index) == value);
	}

	public void SearchFloat(float value)
	{
		results = Search((int index) => index + 3 < data.Length && BitConverter.ToSingle(data, index) == value);
	}

	public List<(int Address, object Value)> GetResults()
	{
		List<(int, object)> list = new List<(int, object)>();
		foreach (int result in results)
		{
			if (result < data.Length)
			{
				list.Add((result, data[result]));
			}
		}
		return list;
	}

	private List<int> Search(Func<int, bool> condition)
	{
		List<int> newResults = new List<int>();
		Parallel.ForEach(Partitioner.Create(0, results.Count), delegate(Tuple<int, int> range)
		{
			List<int> list = new List<int>();
			for (int i = range.Item1; i < range.Item2; i++)
			{
				int num = results[i];
				if (condition(num))
				{
					list.Add(num);
				}
			}
			lock (newResults)
			{
				newResults.AddRange(list);
			}
		});
		return newResults;
	}
}
