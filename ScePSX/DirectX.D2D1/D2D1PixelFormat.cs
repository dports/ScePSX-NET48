namespace DirectX.D2D1;

public struct D2D1PixelFormat
{
	private DxgiFormat format;

	private D2D1AlphaMode alphaMode;

	public static D2D1PixelFormat Default => new D2D1PixelFormat(DxgiFormat.Unknown, D2D1AlphaMode.Unknown);

	public D2D1PixelFormat(DxgiFormat format, D2D1AlphaMode alphaMode)
	{
		this.format = format;
		this.alphaMode = alphaMode;
	}
}
