namespace ScePSX.Render;

public struct vkFixedArray3<T> where T : struct
{
	public T First;

	public T Second;

	public T Third;

	public uint Count => 3u;

	public vkFixedArray3(T first, T second, T third)
	{
		First = first;
		Second = second;
		Third = third;
	}
}
