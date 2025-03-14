namespace DirectX.D2D1;

public struct D2D1RectF
{
	public float left;

	public float top;

	public float right;

	public float bottom;

	public static D2D1RectF Infinite => new D2D1RectF(float.MinValue, float.MinValue, float.MaxValue, float.MaxValue);

	public D2D1RectF(float left, float top, float right, float bottom)
	{
		this.left = left;
		this.top = top;
		this.right = right;
		this.bottom = bottom;
	}
}
