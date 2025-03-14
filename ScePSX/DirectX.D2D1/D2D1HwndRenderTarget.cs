using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DirectX.D2D1;

public sealed class D2D1HwndRenderTarget : D2D1Resource
{
	private readonly ID2D1HwndRenderTarget renderTarget;

	public override object Handle
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return renderTarget;
		}
	}

	public ID2D1HwndRenderTarget RenderTarget
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return renderTarget;
		}
	}

	public nint Hwnd
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return renderTarget.GetHwnd();
		}
	}

	public D2D1AntialiasMode AntialiasMode
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return renderTarget.GetAntialiasMode();
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		set
		{
			renderTarget.SetAntialiasMode(value);
		}
	}

	public D2D1TextAntialiasMode TextAntialiasMode
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return renderTarget.GetTextAntialiasMode();
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		set
		{
			renderTarget.SetTextAntialiasMode(value);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal D2D1HwndRenderTarget(ID2D1HwndRenderTarget renderTarget)
	{
		this.renderTarget = renderTarget;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public D2D1WindowStates CheckWindowState()
	{
		return renderTarget.CheckWindowState();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Resize(D2D1SizeU pixelSize)
	{
		renderTarget.Resize(ref pixelSize);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public D2D1Bitmap CreateBitmap(D2D1SizeU size, nint srcData, uint pitch, D2D1BitmapProperties bitmapProperties)
	{
		renderTarget.CreateBitmap(size, srcData, pitch, ref bitmapProperties, out var bitmap);
		if (bitmap == null)
		{
			return null;
		}
		return new D2D1Bitmap(bitmap);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public D2D1Bitmap CreateBitmap(D2D1SizeU size, byte[] srcData, uint pitch, D2D1BitmapProperties bitmapProperties)
	{
		renderTarget.CreateBitmap(size, (srcData == null) ? IntPtr.Zero : Marshal.UnsafeAddrOfPinnedArrayElement(srcData, 0), pitch, ref bitmapProperties, out var bitmap);
		if (bitmap == null)
		{
			return null;
		}
		return new D2D1Bitmap(bitmap);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public D2D1Bitmap CreateBitmap(D2D1SizeU size, D2D1BitmapProperties bitmapProperties)
	{
		renderTarget.CreateBitmap(size, IntPtr.Zero, 0u, ref bitmapProperties, out var bitmap);
		if (bitmap == null)
		{
			return null;
		}
		return new D2D1Bitmap(bitmap);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void DrawBitmap(D2D1Bitmap bitmap)
	{
		if (bitmap == null)
		{
			throw new ArgumentNullException("bitmap");
		}
		renderTarget.DrawBitmap(bitmap.GetHandle<ID2D1Bitmap>(), IntPtr.Zero, 1f, D2D1BitmapInterpolationMode.Linear, IntPtr.Zero);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void DrawBitmap(D2D1Bitmap bitmap, D2D1RectF destinationRectangle, float opacity, D2D1BitmapInterpolationMode interpolationMode)
	{
		if (bitmap == null)
		{
			throw new ArgumentNullException("bitmap");
		}
		GCHandle gCHandle = GCHandle.Alloc(destinationRectangle, GCHandleType.Pinned);
		try
		{
			renderTarget.DrawBitmap(bitmap.GetHandle<ID2D1Bitmap>(), gCHandle.AddrOfPinnedObject(), opacity, interpolationMode, IntPtr.Zero);
		}
		finally
		{
			gCHandle.Free();
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void DrawBitmap(D2D1Bitmap bitmap, D2D1RectF destinationRectangle, float opacity, D2D1BitmapInterpolationMode interpolationMode, D2D1RectF sourceRectangle)
	{
		if (bitmap == null)
		{
			throw new ArgumentNullException("bitmap");
		}
		GCHandle gCHandle = GCHandle.Alloc(destinationRectangle, GCHandleType.Pinned);
		GCHandle gCHandle2 = GCHandle.Alloc(sourceRectangle, GCHandleType.Pinned);
		try
		{
			renderTarget.DrawBitmap(bitmap.GetHandle<ID2D1Bitmap>(), gCHandle.AddrOfPinnedObject(), opacity, interpolationMode, gCHandle2.AddrOfPinnedObject());
		}
		finally
		{
			gCHandle.Free();
			gCHandle2.Free();
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void BeginDraw()
	{
		renderTarget.BeginDraw();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void EndDraw()
	{
		renderTarget.EndDraw(out var _, out var _);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Clear()
	{
		renderTarget.Clear(IntPtr.Zero);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Clear(D2D1ColorF clearColor)
	{
		GCHandle gCHandle = GCHandle.Alloc(clearColor, GCHandleType.Pinned);
		try
		{
			renderTarget.Clear(gCHandle.AddrOfPinnedObject());
		}
		finally
		{
			gCHandle.Free();
		}
	}
}
