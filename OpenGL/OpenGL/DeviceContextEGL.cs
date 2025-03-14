using System;
using System.Collections.Generic;
using Khronos;

namespace OpenGL;

internal sealed class DeviceContextEGL : DeviceContext
{
	internal abstract class NativeSurface : IDisposable
	{
		public static readonly nint DefaultDisplay = new IntPtr(0);

		protected internal nint _Display;

		protected internal KhronosVersion _EglVersion;

		public abstract nint Handle { get; }

		protected NativeSurface(nint display)
		{
			if ((_Display = Egl.GetDisplay(display)) == IntPtr.Zero)
			{
				throw new InvalidOperationException("unable to get display handle");
			}
			int[] array = new int[1];
			int[] array2 = new int[1];
			if (!Egl.Initialize(_Display, array, array2))
			{
				throw new InvalidOperationException("unable to initialize the display");
			}
			_EglVersion = new KhronosVersion(array[0], array2[0], "egl");
		}

		public abstract void CreateHandle(nint configId, int[] attribs);

		public virtual void Dispose()
		{
			if (_Display != IntPtr.Zero)
			{
				Egl.Terminate(_Display);
				_Display = IntPtr.Zero;
			}
		}
	}

	internal sealed class NativeWindow : NativeSurface, INativeWindow, IDisposable
	{
		private nint _Handle;

		private readonly nint _WindowHandle;

		public override nint Handle => _Handle;

		nint INativeWindow.Display => _Display;

		nint INativeWindow.Handle => _Handle;

		public NativeWindow(nint display)
			: this(display, Gl.NativeWindow.Handle)
		{
		}

		public NativeWindow(nint display, nint windowHandle)
			: this(display, windowHandle, null)
		{
		}

		public NativeWindow(nint display, nint windowHandle, DevicePixelFormat pixelFormat)
			: base(display)
		{
			try
			{
				_WindowHandle = windowHandle;
				if (pixelFormat != null)
				{
					pixelFormat.RenderWindow = true;
					nint configId = ChoosePixelFormat(_Display, _EglVersion, pixelFormat);
					List<int> list = new List<int>();
					if (pixelFormat.DoubleBuffer)
					{
						list.AddRange(new int[2] { 12422, 12420 });
					}
					list.Add(12344);
					CreateHandle(configId, list.ToArray());
				}
			}
			catch
			{
				Dispose();
				throw;
			}
		}

		public override void CreateHandle(nint configId, int[] attribs)
		{
			if (_Handle != IntPtr.Zero)
			{
				throw new InvalidOperationException("handle already created");
			}
			if (_WindowHandle == IntPtr.Zero && !Egl.CurrentExtensions.SurfacelessContext_KHR)
			{
				throw new InvalidOperationException("null window handle");
			}
			if (_WindowHandle != IntPtr.Zero && (_Handle = Egl.CreateWindowSurface(_Display, configId, _WindowHandle, attribs)) == IntPtr.Zero)
			{
				throw new InvalidOperationException("unable to create window surface");
			}
		}

		public override void Dispose()
		{
			if (_Handle != IntPtr.Zero)
			{
				Egl.DestroySurface(_Display, _Handle);
				_Handle = IntPtr.Zero;
			}
			base.Dispose();
		}
	}

	internal sealed class NativePBuffer : NativeSurface, INativePBuffer, IDisposable, INativeWindow
	{
		private nint _Handle;

		public override nint Handle => _Handle;

		nint INativeWindow.Display => _Display;

		nint INativeWindow.Handle => _Handle;

		public NativePBuffer(DevicePixelFormat pixelFormat, uint width, uint height)
			: this(NativeSurface.DefaultDisplay, pixelFormat, width, height)
		{
		}

		public NativePBuffer(nint display, DevicePixelFormat pixelFormat, uint width, uint height)
			: base(display)
		{
			if (pixelFormat == null)
			{
				throw new ArgumentNullException("pixelFormat");
			}
			try
			{
				pixelFormat.RenderWindow = false;
				pixelFormat.RenderPBuffer = true;
				nint configId = ChoosePixelFormat(_Display, _EglVersion, pixelFormat);
				List<int> list = new List<int>();
				list.AddRange(new int[2]
				{
					12375,
					(int)width
				});
				list.AddRange(new int[2]
				{
					12374,
					(int)height
				});
				list.Add(12344);
				CreateHandle(configId, list.ToArray());
			}
			catch
			{
				Dispose();
				throw;
			}
		}

		public override void CreateHandle(nint configId, int[] attribs)
		{
			if (_Handle != IntPtr.Zero)
			{
				throw new InvalidOperationException("handle already created");
			}
			if ((_Handle = Egl.CreatePbufferSurface(_Display, configId, attribs)) == IntPtr.Zero)
			{
				throw new InvalidOperationException("unable to create window surface");
			}
		}

		public override void Dispose()
		{
			if (_Handle != IntPtr.Zero)
			{
				Egl.DestroySurface(_Display, _Handle);
				_Handle = IntPtr.Zero;
			}
			base.Dispose();
		}
	}

	private NativeSurface _NativeSurface;

	private nint _Config;

	private DevicePixelFormatCollection _PixelFormatCache;

	internal nint Display => _NativeSurface?._Display ?? IntPtr.Zero;

	private nint EglSurface => _NativeSurface?.Handle ?? new IntPtr(0);

	private int[] DefaultConfigAttribs
	{
		get
		{
			List<int> list = new List<int>();
			if (Version >= Egl.Version_120)
			{
				list.AddRange(new int[2] { 12352, 4 });
			}
			list.AddRange(new int[2] { 12339, 5 });
			list.AddRange(new int[6] { 12324, 8, 12323, 8, 12322, 8 });
			list.Add(12344);
			return list.ToArray();
		}
	}

	private int[] DefaultContextAttribs
	{
		get
		{
			List<int> list = new List<int>();
			if (Version >= Egl.Version_130)
			{
				list.AddRange(new int[2] { 12440, 2 });
			}
			list.Add(12344);
			return list.ToArray();
		}
	}

	public new static bool IsPBufferSupported => true;

	public override KhronosVersion Version => new KhronosVersion(_NativeSurface._EglVersion);

	public override IEnumerable<string> AvailableAPIs => Egl.AvailableApis;

	public override DevicePixelFormatCollection PixelsFormats
	{
		get
		{
			if (_PixelFormatCache != null)
			{
				return _PixelFormatCache;
			}
			_PixelFormatCache = new DevicePixelFormatCollection();
			if (!Egl.GetConfigs(Display, null, 0, out var num_config))
			{
				throw new InvalidOperationException("unable to get configurations count");
			}
			nint[] array = new nint[num_config];
			if (!Egl.GetConfigs(Display, array, array.Length, out num_config))
			{
				throw new InvalidOperationException("unable to get configurations");
			}
			nint[] array2 = array;
			foreach (nint config in array2)
			{
				DevicePixelFormat devicePixelFormat = new DevicePixelFormat();
				bool flag = Version >= Egl.Version_120;
				bool flag2 = Version >= Egl.Version_130;
				bool flag3 = Version >= Egl.Version_140;
				if (!Egl.GetConfigAttrib(Display, config, 12328, out devicePixelFormat.FormatIndex))
				{
					throw new InvalidOperationException("unable to get configuration parameter CONFIG_ID");
				}
				devicePixelFormat.RgbaUnsigned = true;
				devicePixelFormat.RenderWindow = true;
				devicePixelFormat.RenderBuffer = false;
				if (!Egl.GetConfigAttrib(Display, config, 12320, out var value))
				{
					throw new InvalidOperationException("unable to get configuration parameter BUFFER_SIZE");
				}
				devicePixelFormat.ColorBits = value;
				if (!Egl.GetConfigAttrib(Display, config, 12324, out devicePixelFormat.RedBits))
				{
					throw new InvalidOperationException("unable to get configuration parameter RED_SIZE");
				}
				if (!Egl.GetConfigAttrib(Display, config, 12323, out devicePixelFormat.GreenBits))
				{
					throw new InvalidOperationException("unable to get configuration parameter GREEN_SIZE");
				}
				if (!Egl.GetConfigAttrib(Display, config, 12322, out devicePixelFormat.BlueBits))
				{
					throw new InvalidOperationException("unable to get configuration parameter BLUE_SIZE");
				}
				if (!Egl.GetConfigAttrib(Display, config, 12321, out devicePixelFormat.AlphaBits))
				{
					throw new InvalidOperationException("unable to get configuration parameter ALPHA_SIZE");
				}
				if (!Egl.GetConfigAttrib(Display, config, 12350, out value))
				{
					throw new InvalidOperationException("unable to get configuration parameter ALPHA_MASK_SIZE");
				}
				if (!Egl.GetConfigAttrib(Display, config, 12325, out value))
				{
					throw new InvalidOperationException("unable to get configuration parameter DEPTH_SIZE");
				}
				devicePixelFormat.DepthBits = value;
				if (!Egl.GetConfigAttrib(Display, config, 12326, out value))
				{
					throw new InvalidOperationException("unable to get configuration parameter STENCIL_SIZE");
				}
				devicePixelFormat.StencilBits = value;
				if (!Egl.GetConfigAttrib(Display, config, 12337, out value))
				{
					throw new InvalidOperationException("unable to get configuration parameter SAMPLES");
				}
				devicePixelFormat.MultisampleBits = value;
				if (!Egl.GetConfigAttrib(Display, config, 12327, out value))
				{
					throw new InvalidOperationException("unable to get configuration parameter CONFIG_CAVEAT");
				}
				if (value != 12344)
				{
					if (value == 12368)
					{
						continue;
					}
					_ = 12369;
				}
				if (flag)
				{
					if (!Egl.GetConfigAttrib(Display, config, 12351, out value))
					{
						throw new InvalidOperationException("unable to get configuration parameter COLOR_BUFFER_TYPE");
					}
					if (value != 12430 && value == 12431)
					{
						if (!Egl.GetConfigAttrib(Display, config, 12349, out value))
						{
							throw new InvalidOperationException("unable to get configuration parameter LUMINANCE_SIZE");
						}
						devicePixelFormat.ColorBits = value;
						continue;
					}
				}
				if (!Egl.GetConfigAttrib(Display, config, 12348, out value))
				{
					throw new InvalidOperationException("unable to get configuration parameter MAX_SWAP_INTERVAL");
				}
				if (!Egl.GetConfigAttrib(Display, config, 12347, out value))
				{
					throw new InvalidOperationException("unable to get configuration parameter MIN_SWAP_INTERVAL");
				}
				if (flag2)
				{
					if (!Egl.GetConfigAttrib(Display, config, 12354, out value))
					{
						throw new InvalidOperationException("unable to get configuration parameter CONFORMANT");
					}
					if ((value & 4) == 0)
					{
						continue;
					}
					_ = value & 1;
					_ = value & 2;
					if (flag3)
					{
						_ = value & 8;
					}
				}
				if (flag3)
				{
					if (!Egl.GetConfigAttrib(Display, config, 12339, out value))
					{
						throw new InvalidOperationException("unable to get configuration parameter SURFACE_TYPE");
					}
					_ = value & 0x200;
					_ = value & 1;
					_ = value & 2;
					_ = value & 0x400;
					_ = value & 0x40;
					_ = value & 0x20;
					if ((value & 4) == 0)
					{
						devicePixelFormat.RenderWindow = false;
					}
				}
				devicePixelFormat.DoubleBuffer = true;
				devicePixelFormat.SwapMethod = 0;
				_PixelFormatCache.Add(devicePixelFormat);
			}
			return _PixelFormatCache;
		}
	}

	private DeviceContextEGL()
	{
		string[] availableApis = Egl.AvailableApis;
		if (availableApis.Length == 0)
		{
			throw new InvalidOperationException("no API available");
		}
		if (!Array.Exists(availableApis, (string api) => api == DeviceContext.DefaultAPI))
		{
			base.CurrentAPI = availableApis[0];
		}
	}

	public DeviceContextEGL(nint windowHandle)
		: this(NativeSurface.DefaultDisplay, windowHandle)
	{
	}

	public DeviceContextEGL(nint display, nint windowHandle)
		: this()
	{
		_NativeSurface = new NativeWindow(display, windowHandle);
	}

	public DeviceContextEGL(INativePBuffer nativeBuffer)
		: this()
	{
		if (nativeBuffer == null)
		{
			throw new ArgumentNullException("nativeBuffer");
		}
		if (!(nativeBuffer is NativePBuffer nativeSurface))
		{
			throw new ArgumentException("INativePBuffer not created with DeviceContext.CreatePBuffer");
		}
		_NativeSurface = nativeSurface;
		base.IsPixelFormatSet = true;
	}

	internal override nint CreateSimpleContext()
	{
		int[] defaultConfigAttribs = DefaultConfigAttribs;
		int[] array = new int[1];
		nint[] array2 = new nint[8];
		if (!Egl.ChooseConfig(Display, defaultConfigAttribs, array2, array2.Length, array))
		{
			throw new InvalidOperationException("unable to choose configuration");
		}
		if (array[0] == 0)
		{
			throw new InvalidOperationException("no available configuration");
		}
		int[] defaultContextAttribs = DefaultContextAttribs;
		int[] collection = new int[1] { 12344 };
		if (Version >= Egl.Version_120 && !Egl.BindAPI(12448u))
		{
			throw new InvalidOperationException("no ES API");
		}
		nint result;
		if ((result = Egl.CreateContext(Display, array2[0], IntPtr.Zero, defaultContextAttribs)) == IntPtr.Zero)
		{
			throw new InvalidOperationException("unable to create context");
		}
		if (_NativeSurface.Handle == IntPtr.Zero)
		{
			List<int> list = new List<int>(collection);
			list.RemoveAt(list.Count - 1);
			list.AddRange(new int[4] { 12375, 1, 12374, 1 });
			list.Add(12344);
			_NativeSurface.CreateHandle(array2[0], list.ToArray());
		}
		return result;
	}

	public override nint CreateContext(nint sharedContext)
	{
		return CreateContextAttrib(sharedContext, DefaultContextAttribs);
	}

	public override nint CreateContextAttrib(nint sharedContext, int[] attribsList)
	{
		return CreateContextAttrib(sharedContext, attribsList, new KhronosVersion(1, 0, base.CurrentAPI));
	}

	public override nint CreateContextAttrib(nint sharedContext, int[] attribsList, KhronosVersion api)
	{
		if (attribsList == null)
		{
			throw new ArgumentNullException("attribsList");
		}
		if (attribsList.Length == 0)
		{
			throw new ArgumentException("zero length array", "attribsList");
		}
        if (attribsList[attribsList.Length - 1] != 12344)
        {
            throw new ArgumentException("not EGL_NONE-terminated array", "attribsList");
        }
        if (_NativeSurface != null && _NativeSurface.Handle != IntPtr.Zero)
		{
			int[] array = new int[1];
			if (!Egl.QuerySurface(Display, EglSurface, 12328, array))
			{
				throw new InvalidOperationException("unable to query EGL surface config ID");
			}
			_Config = ChoosePixelFormat(Display, array[0]);
		}
		if (Version >= Egl.Version_120)
		{
			uint api2;
			switch (api.Api)
			{
			case "gles2":
			case "gles1":
			case null:
				api2 = 12448u;
				break;
			case "gl":
				api2 = 12450u;
				break;
			case "vg":
				api2 = 12449u;
				break;
			default:
				throw new InvalidOperationException($"'{api}' API not available");
			}
			if (!Egl.BindAPI(api2))
			{
				throw new InvalidOperationException("no ES API");
			}
		}
		else if (api != null && api.Api != "gles2" && api.Api != "gles1")
		{
			throw new InvalidOperationException($"'{api}' API not available");
		}
		nint result;
		if ((result = Egl.CreateContext(Display, _Config, sharedContext, attribsList)) == IntPtr.Zero)
		{
			throw new EglException(Egl.GetError());
		}
		if (_NativeSurface != null && _NativeSurface.Handle == IntPtr.Zero)
		{
			_NativeSurface.CreateHandle(_Config, new int[1] { 12344 });
		}
		return result;
	}

	protected override bool MakeCurrentCore(nint ctx)
	{
		if (ctx != IntPtr.Zero)
		{
			if (Version >= Egl.Version_120)
			{
				int[] array = new int[1];
				if (Egl.QueryContext(Display, ctx, 12439, array) && !Egl.BindAPI((uint)array[0]))
				{
					throw new InvalidOperationException("no ES API");
				}
			}
			return Egl.MakeCurrent(Display, EglSurface, EglSurface, ctx);
		}
		return Egl.MakeCurrent(Display, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
	}

	public override bool DeleteContext(nint ctx)
	{
		if (ctx == IntPtr.Zero)
		{
			throw new ArgumentException("ctx");
		}
		return Egl.DestroyContext(Display, ctx);
	}

	public override void SwapBuffers()
	{
		Egl.SwapBuffers(Display, EglSurface);
	}

	public override bool SwapInterval(int interval)
	{
		return Egl.SwapInterval(Display, interval);
	}

	internal override void QueryPlatformExtensions()
	{
		Egl.CurrentExtensions = new Egl.Extensions();
		Egl.CurrentExtensions.Query(Display, Version);
	}

	public override Exception GetPlatformException()
	{
		return null;
	}

	public override void ChoosePixelFormat(DevicePixelFormat pixelFormat)
	{
		if (_NativeSurface != null)
		{
			if (_NativeSurface.Handle != IntPtr.Zero)
			{
				throw new InvalidOperationException("pixel format already set");
			}
			_Config = ChoosePixelFormat(Display, Version, pixelFormat);
			base.IsPixelFormatSet = true;
		}
	}

	private static nint ChoosePixelFormat(nint display, KhronosVersion version, DevicePixelFormat pixelFormat)
	{
		if (version == null)
		{
			throw new ArgumentNullException("version");
		}
		if (pixelFormat == null)
		{
			throw new ArgumentNullException("pixelFormat");
		}
		List<int> list = new List<int>();
		int[] array = new int[1];
		nint[] array2 = new nint[8];
		int num = 0;
		if (version >= Egl.Version_120)
		{
			list.AddRange(new int[2] { 12352, 4 });
		}
		if (pixelFormat.RenderWindow)
		{
			num |= 4;
		}
		if (pixelFormat.RenderPBuffer)
		{
			num |= 1;
		}
		if (num != 0)
		{
			list.AddRange(new int[2] { 12339, num });
		}
		switch (pixelFormat.ColorBits)
		{
		case 24:
			list.AddRange(new int[6] { 12324, 8, 12323, 8, 12322, 8 });
			break;
		case 32:
			list.AddRange(new int[8] { 12324, 8, 12323, 8, 12322, 8, 12321, 8 });
			break;
		default:
			list.AddRange(new int[2] { 12320, pixelFormat.ColorBits });
			break;
		}
		if (pixelFormat.DepthBits > 0)
		{
			list.AddRange(new int[2] { 12325, pixelFormat.DepthBits });
		}
		if (pixelFormat.StencilBits > 0)
		{
			list.AddRange(new int[2] { 12326, pixelFormat.StencilBits });
		}
		list.Add(12344);
		if (!Egl.ChooseConfig(display, list.ToArray(), array2, array2.Length, array))
		{
			throw new InvalidOperationException("unable to choose configuration");
		}
		if (array[0] == 0)
		{
			throw new InvalidOperationException("no available configuration");
		}
		return array2[0];
	}

	private static nint ChoosePixelFormat(nint display, int configId)
	{
		List<int> list = new List<int>();
		int[] array = new int[1];
		nint[] array2 = new nint[8];
		list.AddRange(new int[2] { 12328, configId });
		list.Add(12344);
		if (!Egl.ChooseConfig(display, list.ToArray(), array2, array2.Length, array))
		{
			throw new InvalidOperationException("unable to choose configuration");
		}
		if (array[0] == 0)
		{
			throw new InvalidOperationException("no available configuration");
		}
		return array2[0];
	}

	public override void SetPixelFormat(DevicePixelFormat pixelFormat)
	{
		if (pixelFormat == null)
		{
			throw new ArgumentNullException("pixelFormat");
		}
		if (_NativeSurface != null)
		{
			if (_NativeSurface.Handle != IntPtr.Zero)
			{
				throw new InvalidOperationException("pixel format already set");
			}
			List<int> list = new List<int>();
			if (Version >= Egl.Version_120)
			{
				list.AddRange(new int[2] { 12352, 4 });
			}
			list.AddRange(new int[2] { 12328, pixelFormat.FormatIndex });
			list.Add(12344);
			int[] array = new int[1];
			nint[] array2 = new nint[1];
			if (!Egl.ChooseConfig(Display, list.ToArray(), array2, 1, array))
			{
				throw new InvalidOperationException("unable to choose configuration");
			}
			if (array[0] == 0)
			{
				throw new InvalidOperationException("no available configuration");
			}
			_Config = array2[0];
			base.IsPixelFormatSet = true;
		}
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
		if (disposing && _NativeSurface != null)
		{
			_NativeSurface.Dispose();
			_NativeSurface = null;
		}
	}
}
