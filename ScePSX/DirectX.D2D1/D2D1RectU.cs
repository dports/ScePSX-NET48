namespace DirectX.D2D1;

public struct D2D1RectU
{
	private uint left;

	private uint top;

	private uint right;

	private uint bottom;

	public D2D1RectU(uint left, uint top, uint right, uint bottom)
	{
		this.left = left;
		this.top = top;
		this.right = right;
		this.bottom = bottom;
	}
}
