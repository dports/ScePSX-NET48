using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using Khronos;

namespace OpenGL;

internal sealed class DeviceContextWGL : DeviceContext
{
	internal class NativeWindow : INativeWindow, IDisposable
	{
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		private struct WNDCLASSEX
		{
			public int cbSize;

			public int style;

			public nint lpfnWndProc;

			public int cbClsExtra;

			public int cbWndExtra;

			public nint hInstance;

			public nint hIcon;

			public nint hCursor;

			public nint hbrBackground;

			[MarshalAs(UnmanagedType.LPTStr)]
			public string lpszMenuName;

			[MarshalAs(UnmanagedType.LPTStr)]
			public string lpszClassName;

			public nint hIconSm;
		}

		private static class UnsafeNativeMethods
		{
			internal delegate nint WndProc(nint hWnd, uint msg, nint wParam, nint lParam);

			public const uint CS_VREDRAW = 1u;

			public const uint CS_HREDRAW = 2u;

			public const uint CS_OWNDC = 32u;

			public const uint WS_CLIPCHILDREN = 33554432u;

			public const uint WS_CLIPSIBLINGS = 67108864u;

			public const uint WS_OVERLAPPED = 0u;

			public const uint WS_EX_APPWINDOW = 262144u;

			public const uint WS_EX_WINDOWEDGE = 256u;

			[DllImport("user32.dll", SetLastError = true)]
			internal static extern nint DefWindowProc(nint hWnd, uint msg, nint wParam, nint lParam);

			[DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
			internal static extern ushort RegisterClassEx([In] ref WNDCLASSEX lpWndClass);

			[DllImport("user32.dll", SetLastError = true)]
			public static extern bool UnregisterClass(ushort lpClassAtom, nint hInstance);

			[DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
			internal static extern nint CreateWindowEx(uint dwExStyle, string lpClassName, string lpWindowName, uint dwStyle, int x, int y, int nWidth, int nHeight, nint hWndParent, nint hMenu, nint hInstance, nint lpParam);

			[DllImport("user32.dll", SetLastError = true)]
			internal static extern bool DestroyWindow(nint hWnd);

			[DllImport("Kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
			internal static extern nint GetModuleHandle(string lpModuleName);
		}

		private static readonly UnsafeNativeMethods.WndProc _WindowsWndProc = WindowsWndProc;

		private nint _Handle;

		private ushort _ClassAtom;

		nint INativeWindow.Display => IntPtr.Zero;

		nint INativeWindow.Handle => _Handle;

		public NativeWindow()
			: this(1, 1, 16u, 16u)
		{
		}

		public NativeWindow(int x, int y, uint width, uint height)
		{
			try
			{
				WNDCLASSEX lpWndClass = new WNDCLASSEX
				{
					cbSize = Marshal.SizeOf(typeof(WNDCLASSEX)),
					style = 35,
					lpfnWndProc = Marshal.GetFunctionPointerForDelegate(_WindowsWndProc),
					hInstance = UnsafeNativeMethods.GetModuleHandle(typeof(Gl).GetTypeInfo().Assembly.Location),
					lpszClassName = "OpenGL.Net2"
				};
				if ((_ClassAtom = UnsafeNativeMethods.RegisterClassEx(ref lpWndClass)) == 0)
				{
					throw new Win32Exception(Marshal.GetLastWin32Error());
				}
				_Handle = UnsafeNativeMethods.CreateWindowEx(262400u, lpWndClass.lpszClassName, string.Empty, 100663296u, x, y, (int)width, (int)height, IntPtr.Zero, IntPtr.Zero, lpWndClass.hInstance, IntPtr.Zero);
				if (_Handle == IntPtr.Zero)
				{
					throw new Win32Exception(Marshal.GetLastWin32Error());
				}
			}
			catch
			{
				Dispose();
				throw;
			}
		}

		private static nint WindowsWndProc(nint hWnd, uint msg, nint wParam, nint lParam)
		{
			return UnsafeNativeMethods.DefWindowProc(hWnd, msg, wParam, lParam);
		}

		public void Dispose()
		{
			if (_Handle != IntPtr.Zero)
			{
				UnsafeNativeMethods.DestroyWindow(_Handle);
				_Handle = IntPtr.Zero;
			}
			if (_ClassAtom != 0)
			{
				_ClassAtom = 0;
			}
		}
	}

	internal class NativePBuffer : INativePBuffer, IDisposable
	{
		private nint _DeviceContext;

		[RequiredByFeature("WGL_ARB__pbuffer")]
		public nint Handle { get; private set; }

		[RequiredByFeature("WGL_ARB__pbuffer")]
		public NativePBuffer(DevicePixelFormat pixelFormat, uint width, uint height)
		{
			if (pixelFormat == null)
			{
				throw new ArgumentNullException("pixelFormat");
			}
			if (!Wgl.CurrentExtensions.Pbuffer_ARB && !Wgl.CurrentExtensions.Pbuffer_EXT)
			{
				throw new NotSupportedException("WGL_(ARB|EXT)_pbuffer not implemented");
			}
			if (Gl.NativeWindow == null)
			{
				throw new InvalidOperationException("no underlying native window", Gl.InitializationException);
			}
			try
			{
				_DeviceContext = Wgl.GetDC(Gl.NativeWindow.Handle);
				pixelFormat.RenderWindow = false;
				pixelFormat.RenderPBuffer = true;
				pixelFormat.DoubleBuffer = true;
				int iPixelFormat = ChoosePixelFormat(_DeviceContext, pixelFormat);
				Handle = (Wgl.CurrentExtensions.Pbuffer_ARB ? Wgl.CreatePbufferARB(_DeviceContext, iPixelFormat, (int)width, (int)height, new int[1]) : Wgl.CreatePbufferEXT(_DeviceContext, iPixelFormat, (int)width, (int)height, new int[1]));
				if (Handle == IntPtr.Zero)
				{
					throw new InvalidOperationException("unable to create P-Buffer", GetPlatformExceptionCore());
				}
			}
			catch
			{
				Dispose();
				throw;
			}
		}

		[RequiredByFeature("WGL_ARB__pbuffer")]
		public void Dispose()
		{
			if (Handle != IntPtr.Zero)
			{
				if (Wgl.CurrentExtensions.Pbuffer_ARB)
				{
					Wgl.DestroyPbufferARB(Handle);
				}
				else
				{
					Wgl.DestroyPbufferEXT(Handle);
				}
				Handle = IntPtr.Zero;
			}
			if (_DeviceContext != IntPtr.Zero)
			{
				Wgl.ReleaseDC(IntPtr.Zero, _DeviceContext);
				_DeviceContext = IntPtr.Zero;
			}
		}
	}

	private nint _WindowHandle;

	private readonly bool _DeviceContextPBuffer;

	private DevicePixelFormatCollection _PixelFormatCache;

	internal nint DeviceContext { get; private set; }

	public new static bool IsPBufferSupported
	{
		get
		{
			if (Wgl.CurrentExtensions != null)
			{
				if (!Wgl.CurrentExtensions.Pbuffer_ARB)
				{
					return Wgl.CurrentExtensions.Pbuffer_EXT;
				}
				return true;
			}
			return false;
		}
	}

	public override KhronosVersion Version => new KhronosVersion(1, 0, "wgl");

	public override IEnumerable<string> AvailableAPIs => GetAvailableApis();

	public override DevicePixelFormatCollection PixelsFormats
	{
		get
		{
			if (_PixelFormatCache != null)
			{
				return _PixelFormatCache;
			}
			_PixelFormatCache = ((Wgl.CurrentExtensions != null && Wgl.CurrentExtensions.PixelFormat_ARB) ? GetPixelFormats_ARB_pixel_format(Wgl.CurrentExtensions) : GetPixelFormats_Win32());
			return _PixelFormatCache;
		}
	}

	public DeviceContextWGL()
	{
		if (Gl.NativeWindow == null)
		{
			throw new InvalidOperationException("no underlying native window", Gl.InitializationException);
		}
		_WindowHandle = Gl.NativeWindow.Handle;
		base.IsPixelFormatSet = true;
		DeviceContext = Wgl.GetDC(_WindowHandle);
		if (DeviceContext == IntPtr.Zero)
		{
			throw new InvalidOperationException("unable to get device context");
		}
	}

	public DeviceContextWGL(nint windowHandle)
	{
		if (windowHandle == IntPtr.Zero)
		{
			throw new ArgumentException("null handle", "windowHandle");
		}
		_WindowHandle = windowHandle;
		DeviceContext = Wgl.GetDC(_WindowHandle);
		if (DeviceContext == IntPtr.Zero)
		{
			throw new InvalidOperationException("unable to get device context");
		}
	}

	public DeviceContextWGL(INativePBuffer nativeBuffer)
	{
		if (nativeBuffer == null)
		{
			throw new ArgumentNullException("nativeBuffer");
		}
		if (!(nativeBuffer is NativePBuffer nativePBuffer))
		{
			throw new ArgumentException("INativePBuffer not created with DeviceContext.CreatePBuffer");
		}
		if (!Wgl.CurrentExtensions.Pbuffer_ARB && !Wgl.CurrentExtensions.Pbuffer_EXT)
		{
			throw new InvalidOperationException("WGL_(ARB|EXT)_pbuffer not supported");
		}
		_WindowHandle = nativePBuffer.Handle;
		DeviceContext = (Wgl.CurrentExtensions.Pbuffer_ARB ? Wgl.GetPbufferDCARB(nativePBuffer.Handle) : Wgl.GetPbufferDCEXT(nativePBuffer.Handle));
		if (DeviceContext == IntPtr.Zero)
		{
			throw new InvalidOperationException("unable to get device context");
		}
		_DeviceContextPBuffer = true;
		base.IsPixelFormatSet = true;
	}

	internal override nint CreateSimpleContext()
	{
		Wgl.PIXELFORMATDESCRIPTOR pixelFormatDescriptor = new Wgl.PIXELFORMATDESCRIPTOR(24);
		pixelFormatDescriptor.dwFlags |= Wgl.PixelFormatDescriptorFlags.StereoDontCare | Wgl.PixelFormatDescriptorFlags.DepthDontCare | Wgl.PixelFormatDescriptorFlags.DoublebufferDontCare;
		int num = Wgl.ChoosePixelFormat(DeviceContext, ref pixelFormatDescriptor);
		Wgl.DescribePixelFormat(DeviceContext, num, (uint)pixelFormatDescriptor.nSize, ref pixelFormatDescriptor);
		Wgl.SetPixelFormat(DeviceContext, num, ref pixelFormatDescriptor);
		return CreateContext(IntPtr.Zero);
	}

	internal static string[] GetAvailableApis()
	{
		List<string> list = new List<string> { "gl" };
		if (Wgl.CurrentExtensions != null && Wgl.CurrentExtensions.CreateContextEsProfile_EXT)
		{
			list.Add("gles1");
			list.Add("gles2");
			list.Add("glsc2");
		}
		return list.ToArray();
	}

	public override nint CreateContext(nint sharedContext)
	{
		if (Wgl.CurrentExtensions == null || !Wgl.CurrentExtensions.CreateContext_ARB)
		{
			nint num = Wgl.CreateContext(DeviceContext);
			if (num == IntPtr.Zero)
			{
				throw new WglException(Marshal.GetLastWin32Error());
			}
			if (sharedContext != IntPtr.Zero && !Wgl.ShareLists(num, sharedContext))
			{
				throw new WglException(Marshal.GetLastWin32Error());
			}
			return num;
		}
		return CreateContextAttrib(sharedContext, new int[1]);
	}

	[RequiredByFeature("WGL_ARB_create_context")]
	public override nint CreateContextAttrib(nint sharedContext, int[] attribsList)
	{
		return CreateContextAttrib(sharedContext, attribsList, new KhronosVersion(1, 0, base.CurrentAPI));
	}

	[RequiredByFeature("WGL_ARB_create_context")]
	public override nint CreateContextAttrib(nint sharedContext, int[] attribsList, KhronosVersion api)
	{
		if (Wgl.CurrentExtensions != null && !Wgl.CurrentExtensions.CreateContext_ARB)
		{
			throw new InvalidOperationException("WGL_ARB_create_context not supported");
		}
		if (attribsList != null && attribsList.Length == 0)
		{
			throw new ArgumentException("zero length array", "attribsList");
		}
        if (attribsList != null && attribsList.Length > 0 && attribsList[attribsList.Length - 1] != 0)
        {
            throw new ArgumentException("not zero-terminated array", "attribsList");
        }
        if (attribsList == null)
		{
			attribsList = new int[1];
		}
		nint num6;
		if (api != null)
		{
			List<int> list = new List<int>(attribsList);
			switch (api.Api)
			{
			case "gles1":
			case "gles2":
			case "glsc2":
				if (Wgl.CurrentExtensions != null && !Wgl.CurrentExtensions.CreateContextEsProfile_EXT)
				{
					throw new NotSupportedException("OpenGL ES API not supported");
				}
				break;
			default:
				throw new NotSupportedException("'" + api.Api + "' API not supported");
			case "gl":
				break;
			}
			if (list.Count > 0 && list[list.Count - 1] == 0)
			{
				list.RemoveAt(list.Count - 1);
			}
			int num = api.Major;
			int value = api.Minor;
			int num2 = 0;
			switch (api.Api)
			{
			case "gl":
				switch (api.Profile)
				{
				case "compatibility":
					num2 |= 2;
					break;
				case "core":
					num2 |= 1;
					break;
				default:
					throw new NotSupportedException("'" + api.Profile + "' Profile not supported");
				case null:
					break;
				}
				break;
			case "gles1":
				num = 1;
				value = 0;
				num2 |= 4;
				break;
			case "gles2":
			case "glsc2":
				num = 2;
				value = 0;
				num2 |= 4;
				break;
			default:
				throw new NotSupportedException("'" + api.Api + "' API not supported");
			}
			int num3;
			if ((num3 = list.FindIndex((int item) => item == 8337)) >= 0)
			{
				list[num3 + 1] = num;
			}
			else
			{
				list.AddRange(new int[2] { 8337, num });
			}
			int num4;
			if ((num4 = list.FindIndex((int item) => item == 8338)) >= 0)
			{
				list[num4 + 1] = value;
			}
			else
			{
				list.AddRange(new int[2] { 8338, api.Minor });
			}
			if (num2 != 0)
			{
				int num5;
				if ((num5 = list.FindIndex((int item) => item == 37158)) >= 0)
				{
					list[num5 + 1] = num2;
				}
				else
				{
					list.AddRange(new int[2] { 37158, num2 });
				}
			}
			list.Add(0);
			num6 = Wgl.CreateContextAttribsARB(DeviceContext, sharedContext, list.ToArray());
		}
		else
		{
			num6 = Wgl.CreateContextAttribsARB(DeviceContext, sharedContext, attribsList);
		}
		if (num6 == IntPtr.Zero)
		{
			throw new WglException(Marshal.GetLastWin32Error());
		}
		return num6;
	}

	public override bool MakeCurrent(nint ctx)
	{
		nint currentContext = Wgl.GetCurrentContext();
		nint currentDC = Wgl.GetCurrentDC();
		if (ctx == currentContext && DeviceContext == currentDC)
		{
			return true;
		}
		return base.MakeCurrent(ctx);
	}

	protected override bool MakeCurrentCore(nint ctx)
	{
		return Wgl.MakeCurrent(DeviceContext, ctx);
	}

	public override bool DeleteContext(nint ctx)
	{
		if (ctx == IntPtr.Zero)
		{
			throw new ArgumentException("ctx");
		}
		return Wgl.DeleteContext(ctx);
	}

	public override void SwapBuffers()
	{
		Wgl.UnsafeNativeMethods.GdiSwapBuffersFast(DeviceContext);
	}

	[RequiredByFeature("WGL_EXT_swap_control")]
	public override bool SwapInterval(int interval)
	{
		if (!Wgl.CurrentExtensions.SwapControl_EXT)
		{
			throw new InvalidOperationException("WGL_EXT_swap_control not supported");
		}
		if (interval == -1 && !Wgl.CurrentExtensions.SwapControlTear_EXT)
		{
			throw new InvalidOperationException("WGL_EXT_swap_control_tear not supported");
		}
		return Wgl.SwapIntervalEXT(interval);
	}

	internal override void QueryPlatformExtensions()
	{
		Wgl.CurrentExtensions = new Wgl.Extensions();
		Wgl.CurrentExtensions.Query(this);
	}

	public override Exception GetPlatformException()
	{
		return GetPlatformExceptionCore();
	}

	internal static Exception GetPlatformExceptionCore()
	{
		Exception result = null;
		int lastWin32Error = Marshal.GetLastWin32Error();
		if (lastWin32Error != 0)
		{
			result = new Win32Exception(lastWin32Error);
		}
		return result;
	}

	[RequiredByFeature("WGL_ARB_pixel_format")]
	private DevicePixelFormatCollection GetPixelFormats_ARB_pixel_format(Wgl.Extensions wglExtensions)
	{
		int[] array = new int[1] { 8192 };
		int[] array2 = new int[array.Length];
		Wgl.GetPixelFormatAttribARB(DeviceContext, 1, 0, (uint)array.Length, array, array2);
		List<int> list = new List<int>(12)
		{
			8208, 8195, 8211, 8193, 8194, 8209, 8199, 8210, 8212, 8226,
			8227
		};
		if (wglExtensions.Multisample_ARB || wglExtensions.Multisample_EXT)
		{
			list.Add(8257);
			list.Add(8258);
		}
		int num = list.Count - 1;
		if (wglExtensions.Pbuffer_ARB || wglExtensions.Pbuffer_EXT)
		{
			list.Add(8237);
		}
		int num2 = list.Count - 1;
		if (wglExtensions.FramebufferSRGB_ARB || wglExtensions.FramebufferSRGB_EXT)
		{
			list.Add(8361);
		}
		int num3 = list.Count - 1;
		DevicePixelFormatCollection devicePixelFormatCollection = new DevicePixelFormatCollection();
		int[] array3 = new int[list.Count];
		for (int i = 1; i < array2[0]; i++)
		{
			DevicePixelFormat devicePixelFormat = new DevicePixelFormat();
			Wgl.GetPixelFormatAttribARB(DeviceContext, i, 0, (uint)list.Count, list.ToArray(), array3);
			if (array3[0] != 1 || array3[1] != 8231)
			{
				continue;
			}
			int num4 = array3[2];
			if (num4 == 8235 || num4 == 8360 || num4 == 8608)
			{
				devicePixelFormat.FormatIndex = i;
				switch (array3[2])
				{
				case 8235:
					devicePixelFormat.RgbaUnsigned = true;
					break;
				case 8608:
					devicePixelFormat.RgbaFloat = true;
					break;
				case 8360:
					devicePixelFormat.RgbaFloat = (devicePixelFormat.RgbaUnsigned = true);
					break;
				}
				devicePixelFormat.RenderWindow = array3[3] == 1;
				devicePixelFormat.RenderBuffer = array3[4] == 1;
				devicePixelFormat.DoubleBuffer = array3[5] == 1;
				devicePixelFormat.SwapMethod = array3[6];
				devicePixelFormat.StereoBuffer = array3[7] == 1;
				devicePixelFormat.ColorBits = array3[8];
				devicePixelFormat.DepthBits = array3[9];
				devicePixelFormat.StencilBits = array3[10];
				if (wglExtensions.Multisample_ARB || wglExtensions.Multisample_EXT)
				{
					devicePixelFormat.MultisampleBits = array3[num];
				}
				if (wglExtensions.Pbuffer_ARB || wglExtensions.Pbuffer_EXT)
				{
					devicePixelFormat.RenderPBuffer = array3[num2] == 1;
				}
				if (wglExtensions.FramebufferSRGB_ARB || wglExtensions.FramebufferSRGB_EXT)
				{
					devicePixelFormat.SRGBCapable = array3[num3] != 0;
				}
				devicePixelFormatCollection.Add(devicePixelFormat);
			}
		}
		return devicePixelFormatCollection;
	}

	private DevicePixelFormatCollection GetPixelFormats_Win32()
	{
		DevicePixelFormatCollection devicePixelFormatCollection = new DevicePixelFormatCollection();
		Wgl.PIXELFORMATDESCRIPTOR pixelFormatDescriptor = default(Wgl.PIXELFORMATDESCRIPTOR);
		int num = Wgl.DescribePixelFormat(DeviceContext, 0, 0u, ref pixelFormatDescriptor);
		for (int i = 1; i <= num; i++)
		{
			Wgl.DescribePixelFormat(DeviceContext, i, (uint)Marshal.SizeOf(typeof(Wgl.PIXELFORMATDESCRIPTOR)), ref pixelFormatDescriptor);
			if ((pixelFormatDescriptor.dwFlags & Wgl.PixelFormatDescriptorFlags.SupportOpenGL) != 0)
			{
				DevicePixelFormat item = new DevicePixelFormat
				{
					FormatIndex = i,
					RgbaUnsigned = true,
					RgbaFloat = false,
					RenderWindow = true,
					RenderBuffer = false,
					DoubleBuffer = ((pixelFormatDescriptor.dwFlags & Wgl.PixelFormatDescriptorFlags.Doublebuffer) != 0),
					SwapMethod = 0,
					StereoBuffer = ((pixelFormatDescriptor.dwFlags & Wgl.PixelFormatDescriptorFlags.Stereo) != 0),
					ColorBits = pixelFormatDescriptor.cColorBits,
					DepthBits = pixelFormatDescriptor.cDepthBits,
					StencilBits = pixelFormatDescriptor.cStencilBits,
					MultisampleBits = 0,
					RenderPBuffer = false,
					SRGBCapable = false
				};
				devicePixelFormatCollection.Add(item);
			}
		}
		return devicePixelFormatCollection;
	}

	public override void ChoosePixelFormat(DevicePixelFormat pixelFormat)
	{
		if (pixelFormat == null)
		{
			throw new ArgumentNullException("pixelFormat");
		}
		if (base.IsPixelFormatSet)
		{
			throw new InvalidOperationException("pixel format already set");
		}
		int pixelFormat2 = ChoosePixelFormat(DeviceContext, pixelFormat);
		Wgl.PIXELFORMATDESCRIPTOR pixelFormatDescriptor = default(Wgl.PIXELFORMATDESCRIPTOR);
		if (!Wgl.SetPixelFormat(DeviceContext, pixelFormat2, ref pixelFormatDescriptor))
		{
			throw new InvalidOperationException("unable to set pixel format", GetPlatformException());
		}
		base.IsPixelFormatSet = true;
	}

	private static int ChoosePixelFormat(nint deviceContext, DevicePixelFormat pixelFormat)
	{
		if (pixelFormat == null)
		{
			throw new ArgumentNullException("pixelFormat");
		}
		List<int> list = new List<int>();
		uint[] nNumFormats = new uint[1];
		int[] array = new int[4];
		list.AddRange(new int[2] { 8208, 1 });
		if (pixelFormat.RenderWindow)
		{
			list.AddRange(new int[2] { 8193, 1 });
		}
		if (pixelFormat.RenderPBuffer)
		{
			list.AddRange(new int[2] { 8237, 1 });
		}
		if (pixelFormat.RgbaUnsigned)
		{
			list.AddRange(new int[2] { 8211, 8235 });
		}
		if (pixelFormat.RgbaFloat)
		{
			list.AddRange(new int[2] { 8211, 8608 });
		}
		if (pixelFormat.ColorBits > 0)
		{
			list.AddRange(new int[2] { 8212, pixelFormat.ColorBits });
		}
		if (pixelFormat.DepthBits > 0)
		{
			list.AddRange(new int[2] { 8226, pixelFormat.DepthBits });
		}
		if (pixelFormat.StencilBits > 0)
		{
			list.AddRange(new int[2] { 8227, pixelFormat.StencilBits });
		}
		if (pixelFormat.DoubleBuffer)
		{
			list.AddRange(new int[2] { 8209, 1 });
		}
		list.Add(0);
		if (!Wgl.ChoosePixelFormatARB(deviceContext, list.ToArray(), new List<float>().ToArray(), (uint)array.Length, array, nNumFormats))
		{
			throw new InvalidOperationException("unable to choose pixel format", GetPlatformExceptionCore());
		}
		return array[0];
	}

	public override void SetPixelFormat(DevicePixelFormat pixelFormat)
	{
		if (pixelFormat == null)
		{
			throw new ArgumentNullException("pixelFormat");
		}
		if (base.IsPixelFormatSet)
		{
			throw new InvalidOperationException("pixel format already set");
		}
		Wgl.PIXELFORMATDESCRIPTOR pixelFormatDescriptor = default(Wgl.PIXELFORMATDESCRIPTOR);
		if (Wgl.DescribePixelFormat(DeviceContext, pixelFormat.FormatIndex, (uint)pixelFormatDescriptor.nSize, ref pixelFormatDescriptor) == 0)
		{
			throw new InvalidOperationException($"unable to describe pixel format {pixelFormat.FormatIndex}", GetPlatformException());
		}
		if (!Wgl.SetPixelFormat(DeviceContext, pixelFormat.FormatIndex, ref pixelFormatDescriptor))
		{
			throw new InvalidOperationException($"unable to set pixel format {pixelFormat.FormatIndex}", GetPlatformException());
		}
		base.IsPixelFormatSet = true;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && DeviceContext != IntPtr.Zero)
		{
			if (!_DeviceContextPBuffer)
			{
				Wgl.ReleaseDC(_WindowHandle, DeviceContext);
			}
			else
			{
				Wgl.ReleasePbufferDCARB(_WindowHandle, DeviceContext);
			}
			DeviceContext = IntPtr.Zero;
			_WindowHandle = IntPtr.Zero;
		}
		base.Dispose(disposing);
	}
}
