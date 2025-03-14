using System;
using System.Runtime.InteropServices;

namespace OpenGL;

public sealed class MemoryLock : IDisposable
{
	private GCHandle _Handle;

	public nint Address
	{
		get
		{
			if (!_Handle.IsAllocated)
			{
				return IntPtr.Zero;
			}
			return _Handle.AddrOfPinnedObject();
		}
	}

	public MemoryLock(object memoryObject)
	{
		_Handle = GCHandle.Alloc(memoryObject, GCHandleType.Pinned);
	}

	public void Dispose()
	{
		if (_Handle.IsAllocated)
		{
			_Handle.Free();
		}
	}
}
