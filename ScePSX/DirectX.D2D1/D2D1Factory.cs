using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DirectX.D2D1;

public sealed class D2D1Factory : IDisposable, ID2D1Releasable
{
	private readonly ID2D1Factory factory;

	public object Handle
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return factory;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal D2D1Factory(ID2D1Factory factory)
	{
		this.factory = factory;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator bool(D2D1Factory value)
	{
		if (value != null)
		{
			return value.Handle != null;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static D2D1Factory Create(D2D1FactoryType factoryType)
	{
		NativeMethods.D2D1CreateFactory(factoryType, typeof(ID2D1Factory).GUID, IntPtr.Zero, out var iD2D1Factory);
		if (iD2D1Factory == null)
		{
			return null;
		}
		return new D2D1Factory(iD2D1Factory);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static D2D1Factory Create(D2D1FactoryType factoryType, D2D1FactoryOptions factoryOptions)
	{
		GCHandle gCHandle = GCHandle.Alloc(factoryOptions, GCHandleType.Pinned);
		ID2D1Factory iD2D1Factory;
		try
		{
			NativeMethods.D2D1CreateFactory(factoryType, typeof(ID2D1Factory).GUID, gCHandle.AddrOfPinnedObject(), out iD2D1Factory);
		}
		finally
		{
			gCHandle.Free();
		}
		if (iD2D1Factory == null)
		{
			return null;
		}
		return new D2D1Factory(iD2D1Factory);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static D2D1Factory Create(D2D1FactoryType factoryType, D2D1DebugLevel debugLevel)
	{
		D2D1FactoryOptions factoryOptions = new D2D1FactoryOptions(debugLevel);
		return Create(factoryType, factoryOptions);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool ToBoolean()
	{
		return Handle != null;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Dispose()
	{
		Marshal.ReleaseComObject(Handle);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Release()
	{
		Marshal.FinalReleaseComObject(Handle);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ReloadSystemMetrics()
	{
		factory.ReloadSystemMetrics();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void GetDesktopDpi(out float dpiX, out float dpiY)
	{
		factory.GetDesktopDpi(out dpiX, out dpiY);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public D2D1HwndRenderTarget CreateHwndRenderTarget(D2D1RenderTargetProperties renderTargetProperties, D2D1HwndRenderTargetProperties hwndRenderTargetProperties)
	{
		factory.CreateHwndRenderTarget(ref renderTargetProperties, ref hwndRenderTargetProperties, out var hwndRenderTarget);
		if (hwndRenderTarget == null)
		{
			return null;
		}
		return new D2D1HwndRenderTarget(hwndRenderTarget);
	}
}
