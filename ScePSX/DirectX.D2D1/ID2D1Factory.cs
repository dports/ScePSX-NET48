using System.Runtime.InteropServices;
using System.Security;

namespace DirectX.D2D1;

[ComImport]
[SecurityCritical]
[SuppressUnmanagedCodeSecurity]
[Guid("06152247-6f50-465a-9245-118bfd3b6007")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface ID2D1Factory
{
	void ReloadSystemMetrics();

	[PreserveSig]
	void GetDesktopDpi(out float dpiX, out float dpiY);

	void CreateRectangleGeometry([In] ref D2D1RectF rectangle, out nint rectangleGeometry);

	void CreateRoundedRectangleGeometry([In] ref nint roundedRectangle, out nint roundedRectangleGeometry);

	void CreateEllipseGeometry([In] ref nint ellipse, out nint ellipseGeometry);

	void CreateGeometryGroup([In] nint fillMode, [In][MarshalAs(UnmanagedType.LPArray)] nint[] geometries, [In] uint geometriesCount, out nint geometryGroup);

	void CreateTransformedGeometry([In] nint sourceGeometry, [In] ref nint transform, out nint transformedGeometry);

	void CreatePathGeometry(out nint pathGeometry);

	void CreateStrokeStyle([In] ref nint strokeStyleProperties, [In][MarshalAs(UnmanagedType.LPArray)] float[] dashes, [In] uint dashesCount, out nint strokeStyle);

	void CreateDrawingStateBlock([In] nint drawingStateDescription, [In] nint textRenderingParams, out nint drawingStateBlock);

	void CreateWicBitmapRenderTarget([In] nint target, [In] ref D2D1RenderTargetProperties renderTargetProperties, out nint renderTarget);

	void CreateHwndRenderTarget([In] ref D2D1RenderTargetProperties renderTargetProperties, [In] ref D2D1HwndRenderTargetProperties hwndRenderTargetProperties, out ID2D1HwndRenderTarget hwndRenderTarget);

	void CreateDxgiSurfaceRenderTarget([In] nint dxgiSurface, [In] ref D2D1RenderTargetProperties renderTargetProperties, out nint renderTarget);

	void CreateDCRenderTarget([In] ref D2D1RenderTargetProperties renderTargetProperties, out nint renderTarget);
}
