using System.Runtime.InteropServices;
using System.Security;

namespace DirectX.D2D1;

[ComImport]
[SecurityCritical]
[SuppressUnmanagedCodeSecurity]
[Guid("2cd90691-12e2-11dc-9fed-001143a055f9")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface ID2D1Resource
{
	[PreserveSig]
	void GetFactory(out ID2D1Factory factory);
}
