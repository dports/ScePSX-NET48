namespace DirectX.D2D1;

public struct D2D1BitmapProperties
{
	public D2D1PixelFormat pixelFormat;

	public float dpiX;

	public float dpiY;

	public static D2D1BitmapProperties Default => new D2D1BitmapProperties(D2D1PixelFormat.Default, 96f, 96f);

	public D2D1BitmapProperties(D2D1PixelFormat pixelFormat, float dpiX, float dpiY)
	{
		this.pixelFormat = pixelFormat;
		this.dpiX = dpiX;
		this.dpiY = dpiY;
	}
}
