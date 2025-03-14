using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ScePSX.Render;

public class FixedUtf8String : IDisposable
{
	private GCHandle _handle;

	private uint _numBytes;

	public unsafe byte* StringPtr => (byte*)((IntPtr)_handle.AddrOfPinnedObject()).ToPointer();

	public FixedUtf8String(string s)
	{
		if (s == null)
		{
			throw new ArgumentNullException("s");
		}
		byte[] bytes = Encoding.UTF8.GetBytes(s);
		_handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
		_numBytes = (uint)bytes.Length;
	}

	public void SetText(string s)
	{
		if (s == null)
		{
			throw new ArgumentNullException("s");
		}
		_handle.Free();
		byte[] bytes = Encoding.UTF8.GetBytes(s);
		_handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
		_numBytes = (uint)bytes.Length;
	}

	private unsafe string GetString()
	{
		return Encoding.UTF8.GetString(StringPtr, (int)_numBytes);
	}

	public void Dispose()
	{
		_handle.Free();
	}

	public unsafe static implicit operator byte*(FixedUtf8String utf8String)
	{
		return utf8String.StringPtr;
	}

	public unsafe static implicit operator nint(FixedUtf8String utf8String)
	{
		return new IntPtr(utf8String.StringPtr);
	}

	public static implicit operator FixedUtf8String(string s)
	{
		return new FixedUtf8String(s);
	}

	public static implicit operator string(FixedUtf8String utf8String)
	{
		return utf8String.GetString();
	}
}
