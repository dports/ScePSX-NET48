using System;
using System.Runtime.InteropServices;
using System.Security;

namespace DirectX.D2D1;

[ComImport]
[SecurityCritical]
[SuppressUnmanagedCodeSecurity]
[Guid("2cd90698-12e2-11dc-9fed-001143a055f9")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface ID2D1HwndRenderTarget
{
	[PreserveSig]
	void GetFactory(out ID2D1Factory factory);

	void CreateBitmap([In] D2D1SizeU size, [In] nint srcData, [In] uint pitch, [In] ref D2D1BitmapProperties bitmapProperties, out ID2D1Bitmap bitmap);

	void CreateBitmapFromWicBitmap([In] nint wicBitmapSource, [In] nint bitmapProperties, out ID2D1Bitmap bitmap);

	void CreateSharedBitmap([In] ref Guid riid, [In][Out] nint data, [In] nint bitmapProperties, out ID2D1Bitmap bitmap);

	void CreateBitmapBrush([In] ID2D1Bitmap bitmap, [In] nint bitmapBrushProperties, [In] nint brushProperties, out nint bitmapBrush);

	void CreateSolidColorBrush([In] ref D2D1ColorF color, [In] nint brushProperties, out nint solidColorBrush);

	void CreateGradientStopCollection([In][MarshalAs(UnmanagedType.LPArray)] nint[] gradientStops, [In] uint gradientStopsCount, [In] nint colorInterpolationGamma, [In] nint extendMode, out nint gradientStopCollection);

	void CreateLinearGradientBrush([In] ref nint linearGradientBrushProperties, [In] nint brushProperties, [In] nint gradientStopCollection, out nint linearGradientBrush);

	void CreateRadialGradientBrush([In] ref nint radialGradientBrushProperties, [In] nint brushProperties, [In] nint gradientStopCollection, out nint radialGradientBrush);

	void CreateCompatibleRenderTarget([In] nint desiredSize, [In] nint desiredPixelSize, [In] nint desiredFormat, [In] nint options, out nint bitmapRenderTarget);

	void CreateLayer([In] nint size, out nint layer);

	void CreateMesh(out nint mesh);

	[PreserveSig]
	void DrawLine([In] nint point0, [In] nint point1, [In] nint brush, [In] float strokeWidth, [In] nint strokeStyle);

	[PreserveSig]
	void DrawRectangle([In] ref D2D1RectF rect, [In] nint brush, [In] float strokeWidth, [In] nint strokeStyle);

	[PreserveSig]
	void FillRectangle([In] ref D2D1RectF rect, [In] nint brush);

	[PreserveSig]
	void DrawRoundedRectangle([In] ref nint roundedRect, [In] nint brush, [In] float strokeWidth, [In] nint strokeStyle);

	[PreserveSig]
	void FillRoundedRectangle([In] ref nint roundedRect, [In] nint brush);

	[PreserveSig]
	void DrawEllipse([In] ref nint ellipse, [In] nint brush, [In] float strokeWidth, [In] nint strokeStyle);

	[PreserveSig]
	void FillEllipse([In] ref nint ellipse, [In] nint brush);

	[PreserveSig]
	void DrawGeometry([In] nint geometry, [In] nint brush, [In] float strokeWidth, [In] nint strokeStyle);

	[PreserveSig]
	void FillGeometry([In] nint geometry, [In] nint brush, [In] nint opacityBrush);

	[PreserveSig]
	void FillMesh([In] nint mesh, [In] nint brush);

	[PreserveSig]
	void FillOpacityMask([In] ID2D1Bitmap opacityMask, [In] nint brush, [In] nint content, [In] nint destinationRectangle, [In] nint sourceRectangle);

	[PreserveSig]
	void DrawBitmap([In] ID2D1Bitmap bitmap, [In] nint destinationRectangle, [In] float opacity, [In] D2D1BitmapInterpolationMode interpolationMode, [In] nint sourceRectangle);

	[PreserveSig]
	void DrawText([In][MarshalAs(UnmanagedType.LPWStr)] string text, [In] uint textLength, [In] nint textFormat, [In] ref D2D1RectF layoutRect, [In] nint defaultForegroundBrush, [In] nint options, [In] nint measuringMode);

	[PreserveSig]
	void DrawTextLayout([In] nint origin, [In] nint textLayout, [In] nint defaultForegroundBrush, [In] nint options);

	[PreserveSig]
	void DrawGlyphRun([In] nint baselineOrigin, [In] nint glyphRun, [In] nint foregroundBrush, [In] nint measuringMode);

	[PreserveSig]
	void SetTransform([In] ref nint transform);

	[PreserveSig]
	void GetTransform(out nint transform);

	[PreserveSig]
	void SetAntialiasMode([In] D2D1AntialiasMode antialiasMode);

	[PreserveSig]
	D2D1AntialiasMode GetAntialiasMode();

	[PreserveSig]
	void SetTextAntialiasMode([In] D2D1TextAntialiasMode textAntialiasMode);

	[PreserveSig]
	D2D1TextAntialiasMode GetTextAntialiasMode();

	[PreserveSig]
	void SetTextRenderingParams([In] nint textRenderingParams);

	[PreserveSig]
	void GetTextRenderingParams(out nint textRenderingParams);

	[PreserveSig]
	void SetTags([In] ulong tag1, [In] ulong tag2);

	[PreserveSig]
	void GetTags(out ulong tag1, out ulong tag2);

	[PreserveSig]
	void PushLayer([In] ref nint layerParameters, [In] nint layer);

	[PreserveSig]
	void PopLayer();

	void Flush(out ulong tag1, out ulong tag2);

	[PreserveSig]
	void SaveDrawingState([In][Out] nint drawingStateBlock);

	[PreserveSig]
	void RestoreDrawingState([In] nint drawingStateBlock);

	[PreserveSig]
	void PushAxisAlignedClip([In] ref D2D1RectF clipRect, [In] D2D1AntialiasMode antialiasMode);

	[PreserveSig]
	void PopAxisAlignedClip();

	[PreserveSig]
	void Clear([In] nint clearColor);

	[PreserveSig]
	void BeginDraw();

	void EndDraw(out ulong tag1, out ulong tag2);

	[PreserveSig]
	void GetPixelFormat(out D2D1PixelFormat pixelFormat);

	[PreserveSig]
	void SetDpi([In] float dpiX, [In] float dpiY);

	[PreserveSig]
	void GetDpi(out float dpiX, out float dpiY);

	[PreserveSig]
	void GetSize(out D2D1SizeF size);

	[PreserveSig]
	void GetPixelSize(out D2D1SizeU size);

	[PreserveSig]
	uint GetMaximumBitmapSize();

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.Bool)]
	bool IsSupported([In] ref D2D1RenderTargetProperties renderTargetProperties);

	[PreserveSig]
	D2D1WindowStates CheckWindowState();

	void Resize([In] ref D2D1SizeU pixelSize);

	[PreserveSig]
	nint GetHwnd();
}
