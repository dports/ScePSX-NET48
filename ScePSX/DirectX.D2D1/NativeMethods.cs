using System;
using System.Runtime.InteropServices;
using System.Security;

namespace DirectX.D2D1;

[SecurityCritical]
[SuppressUnmanagedCodeSecurity]
internal static class NativeMethods
{
	[DllImport("D2d1.dll", PreserveSig = false)]
	public static extern void D2D1CreateFactory([In] D2D1FactoryType factoryType, [In][MarshalAs(UnmanagedType.LPStruct)] Guid riid, [In] nint factoryOptions, out ID2D1Factory factory);
}
