using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DirectX.D2D1;

public sealed class D2D1Bitmap : D2D1Resource
{
	private readonly ID2D1Bitmap bitmap;

	public override object Handle
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return bitmap;
		}
	}

	public D2D1SizeF Size
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			bitmap.GetSize(out var size);
			return size;
		}
	}

	public D2D1SizeU PixelSize
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			bitmap.GetPixelSize(out var size);
			return size;
		}
	}

	public D2D1PixelFormat PixelFormat
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			bitmap.GetPixelFormat(out var pixelFormat);
			return pixelFormat;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal D2D1Bitmap(ID2D1Bitmap bitmap)
	{
		this.bitmap = bitmap;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void GetDpi(out float dpiX, out float dpiY)
	{
		bitmap.GetDpi(out dpiX, out dpiY);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void CopyFromBitmap(D2D1Bitmap srcBitmap)
	{
		if (srcBitmap == null)
		{
			throw new ArgumentNullException("srcBitmap");
		}
		bitmap.CopyFromBitmap(IntPtr.Zero, srcBitmap.bitmap, IntPtr.Zero);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void CopyFromBitmap(D2D1Point2U destPoint, D2D1Bitmap srcBitmap, D2D1RectU srcRect)
	{
		if (srcBitmap == null)
		{
			throw new ArgumentNullException("srcBitmap");
		}
		GCHandle gCHandle = GCHandle.Alloc(destPoint, GCHandleType.Pinned);
		GCHandle gCHandle2 = GCHandle.Alloc(srcRect, GCHandleType.Pinned);
		try
		{
			bitmap.CopyFromBitmap(gCHandle.AddrOfPinnedObject(), srcBitmap.bitmap, gCHandle2.AddrOfPinnedObject());
		}
		finally
		{
			gCHandle.Free();
			gCHandle2.Free();
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void CopyFromMemory(nint srcData, uint pitch)
	{
		bitmap.CopyFromMemory(IntPtr.Zero, srcData, pitch);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void CopyFromMemory(byte[] srcData, uint pitch)
	{
		if (srcData == null)
		{
			throw new ArgumentNullException("srcData");
		}
		bitmap.CopyFromMemory(IntPtr.Zero, Marshal.UnsafeAddrOfPinnedArrayElement(srcData, 0), pitch);
	}
}
