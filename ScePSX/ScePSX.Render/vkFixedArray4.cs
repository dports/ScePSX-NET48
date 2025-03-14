namespace ScePSX.Render;

public struct vkFixedArray4<T> where T : struct
{
	public T First;

	public T Second;

	public T Third;

	public T Fourth;

	public uint Count => 4u;

	public vkFixedArray4(T first, T second, T third, T fourth)
	{
		First = first;
		Second = second;
		Third = third;
		Fourth = fourth;
	}
}
