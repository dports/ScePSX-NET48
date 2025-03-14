namespace ScePSX.Render;

public struct vkFixedArray6<T> where T : struct
{
	public T First;

	public T Second;

	public T Third;

	public T Fourth;

	public T Fifth;

	public T Sixth;

	public uint Count => 6u;

	public vkFixedArray6(T first, T second, T third, T fourth, T fifth, T sixth)
	{
		First = first;
		Second = second;
		Third = third;
		Fourth = fourth;
		Fifth = fifth;
		Sixth = sixth;
	}
}
