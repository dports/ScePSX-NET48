namespace ScePSX.Render;

public static class vkFixedArray
{
	public static vkFixedArray2<T> Create<T>(T first, T second) where T : struct
	{
		return new vkFixedArray2<T>(first, second);
	}

	public static vkFixedArray3<T> Create<T>(T first, T second, T third) where T : struct
	{
		return new vkFixedArray3<T>(first, second, third);
	}

	public static vkFixedArray4<T> Create<T>(T first, T second, T third, T fourth) where T : struct
	{
		return new vkFixedArray4<T>(first, second, third, fourth);
	}

	public static vkFixedArray5<T> Create<T>(T first, T second, T third, T fourth, T fifth) where T : struct
	{
		return new vkFixedArray5<T>(first, second, third, fourth, fifth);
	}

	public static vkFixedArray6<T> Create<T>(T first, T second, T third, T fourth, T fifth, T sixth) where T : struct
	{
		return new vkFixedArray6<T>(first, second, third, fourth, fifth, sixth);
	}
}
