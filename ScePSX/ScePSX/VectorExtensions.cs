using System.Numerics;

namespace ScePSX;

public static class VectorExtensions
{
	public static int Sum(this Vector<int> vector)
	{
		int num = 0;
		for (int i = 0; i < Vector<int>.Count; i++)
		{
			num += vector[i];
		}
		return num;
	}
}
