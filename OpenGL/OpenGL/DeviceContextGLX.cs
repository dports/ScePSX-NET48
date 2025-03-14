using System;
using System.Collections.Generic;
using Khronos;

namespace OpenGL;

internal sealed class DeviceContextGLX : DeviceContext
{
	internal class NativeWindow : INativeWindow, IDisposable
	{
		internal static nint _InternalConfig;

		internal static Glx.XVisualInfo _InternalVisual;

		private nint _Display;

		private nint _Handle;

		private nint _GlxHandle;

		nint INativeWindow.Display => _Display;

		nint INativeWindow.Handle => _GlxHandle;

		public NativeWindow()
			: this(0, 0, 16u, 16u)
		{
		}

		public unsafe NativeWindow(int x, int y, uint width, uint height)
		{
			try
			{
				if ((_Display = Glx.XOpenDisplay(IntPtr.Zero)) == IntPtr.Zero)
				{
					throw new InvalidOperationException("unable to connect to X server");
				}
				int[] attrib_list = new int[13]
				{
					32784, 1, 32785, 1, 5, -1, 8, 1, 9, 1,
					10, 1, 0
				};
				int num = Glx.XDefaultScreen(_Display);
				int[] array = new int[1];
				nint* num2 = Glx.ChooseFBConfig(_Display, num, attrib_list, array);
				if (array[0] == 0)
				{
					throw new InvalidOperationException("unable to find basic visual");
				}
				nint num3 = *num2;
				Glx.XVisualInfo visualFromFBConfig = Glx.GetVisualFromFBConfig(_Display, num3);
				Glx.XFree((nint)num2);
				_InternalConfig = num3;
				_InternalVisual = visualFromFBConfig;
				Glx.XSetWindowAttributes attributes = default(Glx.XSetWindowAttributes);
				nint num4 = Glx.XRootWindow(_Display, num);
				ulong value = 10248uL;
				attributes.border_pixel = IntPtr.Zero;
				attributes.event_mask = new IntPtr(131072L);
				attributes.colormap = Glx.XCreateColormap(_Display, num4, visualFromFBConfig.visual, 0);
				if ((_Handle = Glx.XCreateWindow(_Display, num4, x, y, (int)width, (int)height, 0, visualFromFBConfig.depth, 0, visualFromFBConfig.visual, new UIntPtr(value), ref attributes)) == IntPtr.Zero)
				{
					throw new InvalidOperationException("unable to create window");
				}
				_GlxHandle = Glx.CreateWindow(_Display, num3, _Handle, null);
			}
			catch
			{
				Dispose();
				throw;
			}
		}

		public void Dispose()
		{
			if (_Handle != IntPtr.Zero)
			{
				Glx.UnsafeNativeMethods.XDestroyWindow(_Display, _Handle);
				_Handle = IntPtr.Zero;
			}
			if (_Display != IntPtr.Zero)
			{
				Glx.UnsafeNativeMethods.XCloseDisplay(_Display);
				_Display = IntPtr.Zero;
			}
		}
	}

	private readonly nint _Display;

	private readonly nint _WindowHandle;

	private nint _FBConfig;

	private Glx.XVisualInfo _XVisualInfo;

	private static bool _MultithreadingInitialized;

	private KhronosVersion _GlxVersion;

	internal static readonly object _DisplayErrorsLock;

	internal static readonly Dictionary<nint, Exception> _DisplayErrors;

	public nint Display
	{
		get
		{
			if (base.IsDisposed)
			{
				throw new ObjectDisposedException("XServerDeviceContext");
			}
			return _Display;
		}
	}

	internal static bool IsMultithreadingInitialized => _MultithreadingInitialized;

	public override KhronosVersion Version => new KhronosVersion(_GlxVersion);

	public override IEnumerable<string> AvailableAPIs => GetAvailableApis();

	public unsafe override DevicePixelFormatCollection PixelsFormats
	{
		get
		{
			Glx.Extensions extensions = new Glx.Extensions();
			extensions.Query(this);
			DevicePixelFormatCollection devicePixelFormatCollection = new DevicePixelFormatCollection();
			using (new Glx.XLock(Display))
			{
				int nelements = 0;
				int screen = Glx.UnsafeNativeMethods.XDefaultScreen(_Display);
				nint* fBConfigs = Glx.GetFBConfigs(Display, screen, out nelements);
				for (int i = 0; i < nelements; i++)
				{
					nint num = fBConfigs[i];
					if (Glx.GetFBConfigAttrib(Display, num, 32785, out var value) != 0)
					{
						throw new InvalidOperationException();
					}
					if (((ulong)value & 1uL) == 0L)
					{
						continue;
					}
					Glx.GetFBConfigAttrib(Display, num, 32, out var value2);
					if (value2 == 32769)
					{
						continue;
					}
					DevicePixelFormat devicePixelFormat = new DevicePixelFormat();
					devicePixelFormat.XFbConfig = num;
					devicePixelFormat.XVisualInfo = Glx.GetVisualFromFBConfig(Display, num);
					devicePixelFormat.RgbaUnsigned = ((ulong)value & 4uL) == 0;
					devicePixelFormat.RgbaFloat = ((ulong)value & 4uL) != 0;
					if (Glx.GetFBConfigAttrib(Display, num, 32784, out value2) != 0)
					{
						throw new InvalidOperationException("unable to get DRAWABLE_TYPE from framebuffer configuration");
					}
					devicePixelFormat.RenderWindow = ((ulong)value2 & 1uL) != 0;
					devicePixelFormat.RenderBuffer = false;
					devicePixelFormat.RenderPBuffer = ((ulong)value2 & 4uL) != 0;
					if (Glx.GetFBConfigAttrib(Display, num, 32787, out devicePixelFormat.FormatIndex) != 0)
					{
						throw new InvalidOperationException("unable to get FBCONFIG_ID from framebuffer configuration");
					}
					if (Glx.GetFBConfigAttrib(Display, num, 2, out devicePixelFormat.ColorBits) != 0)
					{
						throw new InvalidOperationException("unable to get BUFFER_SIZE from framebuffer configuration");
					}
					if (Glx.GetFBConfigAttrib(Display, num, 12, out devicePixelFormat.DepthBits) != 0)
					{
						throw new InvalidOperationException("unable to get DEPTH_SIZE from framebuffer configuration");
					}
					if (Glx.GetFBConfigAttrib(Display, num, 13, out devicePixelFormat.StencilBits) != 0)
					{
						throw new InvalidOperationException("unable to get STENCIL_SIZE from framebuffer configuration");
					}
					if (extensions.Multisample_ARB)
					{
						int value3 = 0;
						if (Glx.GetFBConfigAttrib(Display, num, 100000, out value3) != 0)
						{
							throw new InvalidOperationException("unable to get SAMPLE_BUFFERS from framebuffer configuration");
						}
						if (value3 != 0)
						{
							devicePixelFormat.MultisampleBits = 0;
							if (Glx.GetFBConfigAttrib(Display, num, 100001, out devicePixelFormat.MultisampleBits) != 0)
							{
								throw new InvalidOperationException("unable to get SAMPLES from framebuffer configuration");
							}
						}
						else
						{
							devicePixelFormat.MultisampleBits = 0;
						}
					}
					if (Glx.GetFBConfigAttrib(Display, num, 5, out value2) != 0)
					{
						throw new InvalidOperationException("unable to get DOUBLEBUFFER from framebuffer configuration");
					}
					devicePixelFormat.DoubleBuffer = value2 != 0;
					if (Glx.GetFBConfigAttrib(Display, num, 6, out value2) != 0)
					{
						throw new InvalidOperationException("unable to get STEREO from framebuffer configuration");
					}
					devicePixelFormat.StereoBuffer = value2 != 0;
					if (extensions.FramebufferSRGB_ARB)
					{
						if (Glx.GetFBConfigAttrib(Display, num, 8370, out value2) != 0)
						{
							throw new InvalidOperationException("unable to get FRAMEBUFFER_SRGB_CAPABLE_ARB from framebuffer configuration");
						}
						devicePixelFormat.SRGBCapable = value2 != 0;
					}
					else
					{
						devicePixelFormat.SRGBCapable = false;
					}
					devicePixelFormatCollection.Add(devicePixelFormat);
				}
				return devicePixelFormatCollection;
			}
		}
	}

	static DeviceContextGLX()
	{
		_DisplayErrorsLock = new object();
		_DisplayErrors = new Dictionary<nint, Exception>();
		Glx.UnsafeNativeMethods.XSetErrorHandler(XServerErrorHandler);
	}

	public DeviceContextGLX()
	{
		if (Gl.NativeWindow == null)
		{
			throw new InvalidOperationException("no underlying native window", Gl.InitializationException);
		}
		_Display = Gl.NativeWindow.Display;
		_WindowHandle = Gl.NativeWindow.Handle;
		QueryVersion();
		if (Version < Glx.Version_130)
		{
			throw new NotSupportedException("missing GLX 1.3 or greater");
		}
	}

	public DeviceContextGLX(nint display, nint windowHandle)
	{
		if (display == IntPtr.Zero)
		{
			throw new ArgumentException("invalid X display", "display");
		}
		if (windowHandle == IntPtr.Zero)
		{
			throw new ArgumentException("invalid X window", "windowHandle");
		}
		_Display = display;
		_WindowHandle = windowHandle;
		QueryVersion();
		if (Version < Glx.Version_130)
		{
			throw new NotSupportedException("missing GLX 1.3 or greater");
		}
	}

	public static void InitializeMultithreading()
	{
		if (Glx.UnsafeNativeMethods.XInitThreads() == 0)
		{
			throw new InvalidOperationException("platform does not support multithreading");
		}
		_MultithreadingInitialized = true;
	}

	private void QueryVersion()
	{
		using (new Glx.XLock(Display))
		{
			int[] array = new int[1];
			int[] array2 = new int[1];
			Glx.QueryVersion(Display, array, array2);
			_GlxVersion = new KhronosVersion(array[0], array2[0], "glx");
		}
	}

	internal override nint CreateSimpleContext()
	{
		using (new Glx.XLock(Display))
		{
			nint num = CreateContext(IntPtr.Zero);
			if (num == IntPtr.Zero)
			{
				throw new InvalidOperationException("unable to create context");
			}
			return num;
		}
	}

	internal static string[] GetAvailableApis()
	{
		List<string> list = new List<string> { "gl" };
		if (Glx.CurrentExtensions != null && Glx.CurrentExtensions.CreateContextEsProfile_EXT)
		{
			list.Add("gles1");
			list.Add("gles2");
		}
		return list.ToArray();
	}

	public override nint CreateContext(nint sharedContext)
	{
		if (Glx.CurrentExtensions == null || !Glx.CurrentExtensions.CreateContext_ARB)
		{
			using (new Glx.XLock(Display))
			{
				Glx.XVisualInfo vis = ((_XVisualInfo != null) ? _XVisualInfo : GetVisualInfoFromXWindow(_WindowHandle));
				return Glx.CreateContext(Display, vis, sharedContext, direct: true);
			}
		}
		return CreateContextAttrib(sharedContext, new int[1]);
	}

	private unsafe Glx.XVisualInfo GetVisualInfoFromXWindow(nint xWindow)
	{
		uint[] array = new uint[1];
		int screen = Glx.XDefaultScreen(_Display);
		Glx.QueryDrawable(_Display, _WindowHandle, 32787, array);
		if (array[0] == 0)
		{
			Khronos.KhronosApi.LogComment("Glx.QueryDrawable cannot query Glx.FBCONFIG_ID. Query manually.");
			return NativeWindow._InternalVisual;
		}
		int[] attrib_list = new int[3]
		{
			32787,
			(int)array[0],
			0
		};
		int[] array2 = new int[1];
		nint* ptr = Glx.ChooseFBConfig(_Display, screen, attrib_list, array2);
		if (array2[0] == 0)
		{
			throw new InvalidOperationException("unable to find X Window visual configuration");
		}
		nint config = *ptr;
		Glx.XVisualInfo visualFromFBConfig = Glx.GetVisualFromFBConfig(_Display, config);
		Glx.XFree((nint)ptr);
		return visualFromFBConfig;
	}

	public override nint CreateContextAttrib(nint sharedContext, int[] attribsList)
	{
		return CreateContextAttrib(sharedContext, attribsList, new KhronosVersion(1, 0, base.CurrentAPI));
	}

	public override nint CreateContextAttrib(nint sharedContext, int[] attribsList, KhronosVersion api)
	{
		if (api != null && api.Api != "gl")
		{
			List<int> list = new List<int>(attribsList);
			string api2 = api.Api;
			if (api2 == "gles1" || api2 == "gles2")
			{
				if (!Glx.CurrentExtensions.CreateContextEsProfile_EXT)
				{
					throw new NotSupportedException("OpenGL ES API not supported");
				}
				if (list.Count > 0 && list[list.Count - 1] == 0)
				{
					list.RemoveAt(list.Count - 1);
				}
				int num = list.FindIndex((int item) => item == 33307);
				int num2 = list.FindIndex((int item) => item == 33308);
				int num3 = list.FindIndex((int item) => item == 37158);
				if (num < 0)
				{
					list.AddRange(new int[2] { 33307, api.Major });
					num = list.Count - 2;
				}
				if (num2 < 0)
				{
					list.AddRange(new int[2] { 33308, api.Minor });
					num2 = list.Count - 2;
				}
				if (num3 < 0)
				{
					list.AddRange(new int[2] { 37158, 0 });
					num3 = list.Count - 2;
				}
				api2 = api.Api;
				if (!(api2 == "gles1"))
				{
					if (!(api2 == "gles2"))
					{
						throw new NotSupportedException($"'{api.Api}' API not supported");
					}
					list[num + 1] = api.Major;
					list[num2 + 1] = api.Minor;
					list[num3 + 1] |= 4;
				}
				else
				{
					list[num + 1] = 1;
					list[num2 + 1] = 1;
					list[num3 + 1] |= 4;
				}
				list.Add(0);
				using (new Glx.XLock(Display))
				{
					return Glx.CreateContextAttribsARB(Display, _FBConfig, sharedContext, direct: true, list.ToArray());
				}
			}
			throw new NotSupportedException($"'{api.Api}' API not supported");
		}
		using (new Glx.XLock(Display))
		{
			return Glx.CreateContextAttribsARB(Display, _FBConfig, sharedContext, direct: true, attribsList);
		}
	}

	protected override bool MakeCurrentCore(nint ctx)
	{
		using (new Glx.XLock(Display))
		{
			return Glx.MakeCurrent(Display, (ctx != IntPtr.Zero) ? _WindowHandle : IntPtr.Zero, ctx);
		}
	}

	public override bool DeleteContext(nint ctx)
	{
		if (ctx == IntPtr.Zero)
		{
			throw new ArgumentException("ctx");
		}
		using (new Glx.XLock(Display))
		{
			Glx.DestroyContext(Display, ctx);
		}
		return true;
	}

	public override void SwapBuffers()
	{
		using (new Glx.XLock(Display))
		{
			Glx.SwapBuffers(Display, _WindowHandle);
		}
	}

	public override bool SwapInterval(int interval)
	{
		return false;
	}

	internal override void QueryPlatformExtensions()
	{
		Glx._CurrentExtensions = new Glx.Extensions();
		Glx._CurrentExtensions.Query(this);
	}

	public override Exception GetPlatformException()
	{
		Exception result = null;
		lock (_DisplayErrorsLock)
		{
			if ((result = _DisplayErrors[Display]) != null)
			{
				_DisplayErrors[Display] = null;
			}
		}
		return result;
	}

	private static int XServerErrorHandler(nint displayHandle, ref Glx.XErrorEvent error_event)
	{
		lock (_DisplayErrorsLock)
		{
			_DisplayErrors[displayHandle] = new GlxException(displayHandle, ref error_event);
		}
		return 0;
	}

	public unsafe override void ChoosePixelFormat(DevicePixelFormat pixelFormat)
	{
		if (pixelFormat == null)
		{
			throw new ArgumentNullException("pixelFormat");
		}
		int screen = Glx.XDefaultScreen(_Display);
		List<int> list = new List<int>();
		if (pixelFormat.RenderWindow)
		{
			list.AddRange(new int[2] { 32784, 1 });
		}
		if (pixelFormat.RgbaUnsigned)
		{
			list.AddRange(new int[2] { 32785, 1 });
		}
		if (pixelFormat.RgbaFloat)
		{
			list.AddRange(new int[2] { 32785, 4 });
		}
		if (pixelFormat.DoubleBuffer)
		{
			list.AddRange(new int[2] { 5, 1 });
		}
		if (pixelFormat.ColorBits > 0)
		{
			switch (pixelFormat.ColorBits)
			{
			case 16:
				list.AddRange(new int[8] { 8, 5, 9, 6, 10, 8, 11, 5 });
				break;
			case 24:
				list.AddRange(new int[6] { 8, 8, 9, 8, 10, 8 });
				break;
			case 32:
				list.AddRange(new int[8] { 8, 8, 9, 8, 10, 8, 11, 8 });
				break;
			default:
				if (pixelFormat.ColorBits < 16)
				{
					list.AddRange(new int[6] { 8, 1, 9, 1, 10, 1 });
				}
				else
				{
					int num = pixelFormat.ColorBits / 4;
					int[] obj = new int[6] { 8, 0, 9, 0, 10, 0 };
					obj[1] = num;
					obj[3] = num;
					obj[5] = num;
					list.AddRange(obj);
				}
				break;
			}
		}
		if (pixelFormat.DepthBits > 0)
		{
			list.AddRange(new int[2] { 12, pixelFormat.DepthBits });
		}
		if (pixelFormat.StencilBits > 0)
		{
			list.AddRange(new int[2] { 13, pixelFormat.StencilBits });
		}
		list.Add(0);
		int[] array = new int[1];
		nint* num2 = Glx.ChooseFBConfig(_Display, screen, list.ToArray(), array);
		if (array[0] == 0)
		{
			throw new InvalidOperationException("unable to choose visual");
		}
		nint num3 = *num2;
		Glx.XVisualInfo visualFromFBConfig = Glx.GetVisualFromFBConfig(_Display, num3);
		Glx.XFree((nint)num2);
		_FBConfig = num3;
		_XVisualInfo = visualFromFBConfig;
		base.IsPixelFormatSet = true;
	}

	public override void SetPixelFormat(DevicePixelFormat pixelFormat)
	{
		if (pixelFormat == null)
		{
			throw new ArgumentNullException("pixelFormat");
		}
		_FBConfig = pixelFormat.XFbConfig;
		_XVisualInfo = pixelFormat.XVisualInfo;
		base.IsPixelFormatSet = true;
	}
}
