namespace DirectX.D2D1;

public struct D2D1RenderTargetProperties
{
	public D2D1RenderTargetType renderTargetType;

	public D2D1PixelFormat pixelFormat;

	public float dpiX;

	public float dpiY;

	public D2D1RenderTargetUsages usage;

	public D2D1FeatureLevel minLevel;

	public D2D1RenderTargetProperties(D2D1RenderTargetType renderTargetType, D2D1PixelFormat pixelFormat, float dpiX, float dpiY, D2D1RenderTargetUsages usage, D2D1FeatureLevel minLevel)
	{
		this.renderTargetType = renderTargetType;
		this.pixelFormat = pixelFormat;
		this.dpiX = dpiX;
		this.dpiY = dpiY;
		this.usage = usage;
		this.minLevel = minLevel;
	}
}
