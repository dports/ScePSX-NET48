using System;
using System.Collections.Generic;

namespace ScePSX.CdRom2;

[Serializable]
public static class QueueExtensions
{
	public static void EnqueueRange<T>(this Queue<T> queue, Span<T> parameters)
	{
		if (queue == null)
		{
			throw new ArgumentNullException("queue");
		}
		Span<T> span = parameters;
		for (int i = 0; i < span.Length; i++)
		{
			T item = span[i];
			queue.Enqueue(item);
		}
	}
}
