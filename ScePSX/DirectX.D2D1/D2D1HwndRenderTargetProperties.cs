namespace DirectX.D2D1;

public struct D2D1HwndRenderTargetProperties
{
	private nint hwnd;

	private D2D1SizeU pixelSize;

	private D2D1PresentOptions presentOptions;

	public D2D1HwndRenderTargetProperties(nint hwnd)
	{
		this.hwnd = hwnd;
		pixelSize = new D2D1SizeU(0u, 0u);
		presentOptions = D2D1PresentOptions.None;
	}

	public D2D1HwndRenderTargetProperties(nint hwnd, D2D1SizeU pixelSize, D2D1PresentOptions presentOptions)
	{
		this.hwnd = hwnd;
		this.pixelSize = pixelSize;
		this.presentOptions = presentOptions;
	}
}
