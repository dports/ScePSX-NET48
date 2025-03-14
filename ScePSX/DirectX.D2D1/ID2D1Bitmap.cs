using System.Runtime.InteropServices;
using System.Security;

namespace DirectX.D2D1;

[ComImport]
[SecurityCritical]
[SuppressUnmanagedCodeSecurity]
[Guid("a2296057-ea42-4099-983b-539fb6505426")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface ID2D1Bitmap
{
	[PreserveSig]
	void GetFactory(out ID2D1Factory factory);

	[PreserveSig]
	void GetSize(out D2D1SizeF size);

	[PreserveSig]
	void GetPixelSize(out D2D1SizeU size);

	[PreserveSig]
	void GetPixelFormat(out D2D1PixelFormat pixelFormat);

	[PreserveSig]
	void GetDpi(out float dpiX, out float dpiY);

	void CopyFromBitmap([In] nint destPoint, [In] ID2D1Bitmap bitmap, [In] nint srcRect);

	void CopyFromRenderTarget([In] nint destPoint, [In] nint renderTarget, [In] nint srcRect);

	void CopyFromMemory([In] nint destRect, [In] nint srcData, [In] uint pitch);
}
