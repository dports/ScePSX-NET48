using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DirectX.D2D1;

public abstract class D2D1Resource : IDisposable, ID2D1Releasable
{
	public abstract object Handle
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal D2D1Resource()
	{
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator bool(D2D1Resource value)
	{
		if (value != null)
		{
			return value.Handle != null;
		}
		return false;
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
	public D2D1Factory GetFactory()
	{
		GetHandle<ID2D1Resource>().GetFactory(out var factory);
		if (factory == null)
		{
			return null;
		}
		return new D2D1Factory(factory);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal T GetHandle<T>()
	{
		return (T)Handle;
	}
}
