namespace ScePSX.Render;

public struct vkFixedArray5<T> where T : struct
{
	public T First;

	public T Second;

	public T Third;

	public T Fourth;

	public T Fifth;

	public uint Count => 5u;

	public vkFixedArray5(T first, T second, T third, T fourth, T fifth)
	{
		First = first;
		Second = second;
		Third = third;
		Fourth = fourth;
		Fifth = fifth;
	}
}
