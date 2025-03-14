namespace ScePSX.Render;

public struct vkFixedArray2<T> where T : struct
{
	public T First;

	public T Second;

	public uint Count => 2u;

	public vkFixedArray2(T first, T second)
	{
		First = first;
		Second = second;
	}
}
