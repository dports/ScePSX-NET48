using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Security;
using Khronos;

namespace OpenGL;

public class Memory
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	[SuppressUnmanagedCodeSecurity]
	private unsafe delegate void CopyDelegate(void* dst, void* src, ulong bytes);

	private static readonly Action<nint, byte, uint> _MemsetDelegate;

	private static CopyDelegate _CopyPointer;

	private static bool _UseSystemCopy;

	private static readonly bool _HasSystemCopy;

	public unsafe static bool UseSystemCopy
	{
		get
		{
			if (_UseSystemCopy)
			{
				return _HasSystemCopy;
			}
			return false;
		}
		set
		{
			if (_UseSystemCopy != value && _HasSystemCopy)
			{
				_UseSystemCopy = value;
				_CopyPointer = (_UseSystemCopy ? GetPlatformMemcpy() : new CopyDelegate(CopyDelegate_Managed));
			}
		}
	}

	unsafe static Memory()
	{
		_MemsetDelegate = GenerateMemsetDelegate();
		_UseSystemCopy = true;
		_HasSystemCopy = true;
		_CopyPointer = GetPlatformMemcpy();
		if (_CopyPointer == null)
		{
			_CopyPointer = CopyDelegate_Managed;
			_UseSystemCopy = false;
			_HasSystemCopy = false;
		}
	}

	public static void Set(nint addr, byte value, uint count)
	{
		_MemsetDelegate(addr, value, count);
	}

	private static Action<nint, byte, uint> GenerateMemsetDelegate()
	{
		DynamicMethod dynamicMethod = new DynamicMethod("Memset", MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard, null, new Type[3]
		{
			typeof(nint),
			typeof(byte),
			typeof(uint)
		}, typeof(Memory), skipVisibility: true);
		ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
		iLGenerator.Emit(OpCodes.Ldarg_0);
		iLGenerator.Emit(OpCodes.Ldarg_1);
		iLGenerator.Emit(OpCodes.Ldarg_2);
		iLGenerator.Emit(OpCodes.Initblk);
		iLGenerator.Emit(OpCodes.Ret);
		return (Action<nint, byte, uint>)dynamicMethod.CreateDelegate(typeof(Action<nint, byte, uint>));
	}

	public unsafe static void Copy(void* dst, void* src, ulong bytes)
	{
		_CopyPointer(dst, src, bytes);
	}

	public unsafe static void Copy(nint dst, nint src, ulong bytes)
	{
		Copy(((IntPtr)dst).ToPointer(), ((IntPtr)src).ToPointer(), bytes);
	}

	public unsafe static void Copy(Array dst, nint src, ulong bytes)
	{
		using MemoryLock memoryLock = new MemoryLock(dst);
		_CopyPointer(((IntPtr)memoryLock.Address).ToPointer(), ((IntPtr)src).ToPointer(), bytes);
	}

	public unsafe static void Copy(nint dst, Array src, ulong bytes)
	{
		using MemoryLock memoryLock = new MemoryLock(src);
		_CopyPointer(((IntPtr)dst).ToPointer(), ((IntPtr)memoryLock.Address).ToPointer(), bytes);
	}

	private unsafe static void CopyDelegate_Managed(void* dst, void* src, ulong bytes)
	{
		if (IntPtr.Size == 8)
		{
			ulong* ptr = (ulong*)dst;
			ulong* ptr2 = (ulong*)src;
			while (bytes >= 8)
			{
				*(ptr++) = *(ptr2++);
				bytes -= 8;
			}
			byte* ptr3 = (byte*)ptr;
			byte* ptr4 = (byte*)ptr2;
			while (bytes >= 1)
			{
				*(ptr3++) = *(ptr4++);
				bytes--;
			}
		}
		else
		{
			uint* ptr5 = (uint*)dst;
			uint* ptr6 = (uint*)src;
			while (bytes >= 4)
			{
				*(ptr5++) = *(ptr6++);
				bytes -= 4;
			}
			byte* ptr7 = (byte*)ptr5;
			byte* ptr8 = (byte*)ptr6;
			while (bytes >= 1)
			{
				*(ptr7++) = *(ptr8++);
				bytes--;
			}
		}
	}

	private static CopyDelegate GetPlatformMemcpy()
	{
		switch (Platform.CurrentPlatformId)
		{
		case Platform.Id.WindowsNT:
		{
			nint procAddress = GetProcAddressOS.GetProcAddress("msvcrt.dll", "memcpy");
			if (procAddress != IntPtr.Zero)
			{
				return (CopyDelegate)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(CopyDelegate));
			}
			return null;
		}
		case Platform.Id.Linux:
		{
			nint procAddress = GetProcAddressOS.GetProcAddress("libc.so.6", "memcpy");
			if (procAddress != IntPtr.Zero)
			{
				return (CopyDelegate)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(CopyDelegate));
			}
			return null;
		}
		default:
			return null;
		}
	}
}
