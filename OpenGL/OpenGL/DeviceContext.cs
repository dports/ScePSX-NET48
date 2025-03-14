using System;
using System.Collections.Generic;
using Khronos;

namespace OpenGL;

public abstract class DeviceContext : IDisposable
{
	private static string _DefaultAPI;

	public static bool IsPBufferSupported
	{
		get
		{
			if (!Egl.IsRequired)
			{
				if (Platform.CurrentPlatformId == Platform.Id.WindowsNT)
				{
					return DeviceContextWGL.IsPBufferSupported;
				}
				return false;
			}
			return DeviceContextEGL.IsPBufferSupported;
		}
	}

	private static bool IsEglRequired
	{
		get
		{
			bool flag = Egl.IsRequired;
			if (flag)
			{
				return true;
			}
			switch (_DefaultAPI)
			{
			case "gles1":
			case "gles2":
			{
				string[] availableApis;
				switch (Platform.CurrentPlatformId)
				{
				case Platform.Id.WindowsNT:
					availableApis = DeviceContextWGL.GetAvailableApis();
					break;
				case Platform.Id.Linux:
					availableApis = DeviceContextGLX.GetAvailableApis();
					break;
				case Platform.Id.MacOS:
					if (Glx.IsRequired)
					{
						availableApis = DeviceContextGLX.GetAvailableApis();
						break;
					}
					throw new NotSupportedException("platform MacOS not supported without Glx.IsRequired=true");
				default:
					throw new NotSupportedException($"platform {Platform.CurrentPlatformId} not supported");
				}
				if (Array.FindIndex(availableApis, (string item) => item == _DefaultAPI) < 0)
				{
					flag = true;
				}
				break;
			}
			case "vg":
				flag = true;
				break;
			}
			return flag;
		}
	}

	public uint RefCount { get; private set; }

	public static string DefaultAPI
	{
		get
		{
			return _DefaultAPI;
		}
		set
		{
			switch (value)
			{
			default:
				throw new InvalidOperationException("unsupported API");
			case "gl":
			case "gles1":
			case "gles2":
			case "glsc2":
			case "vg":
				_DefaultAPI = value;
				break;
			}
		}
	}

	public string CurrentAPI { get; protected set; } = _DefaultAPI;

	public abstract KhronosVersion Version { get; }

	public virtual IEnumerable<string> AvailableAPIs
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public abstract DevicePixelFormatCollection PixelsFormats { get; }

	public bool IsPixelFormatSet { get; protected set; }

	public bool IsDisposed { get; private set; }

	static DeviceContext()
	{
		_DefaultAPI = "gl";
		if (Egl.IsRequired)
		{
			_DefaultAPI = "gles2";
		}
		Gl.Initialize();
	}

	internal static INativeWindow CreateHiddenWindow()
	{
		if (!Egl.IsRequired)
		{
			switch (Platform.CurrentPlatformId)
			{
			case Platform.Id.WindowsNT:
				return new DeviceContextWGL.NativeWindow();
			case Platform.Id.Linux:
				return new DeviceContextGLX.NativeWindow();
			case Platform.Id.MacOS:
				if (Glx.IsRequired)
				{
					return new DeviceContextGLX.NativeWindow();
				}
				throw new NotSupportedException("platform MacOS not supported without Glx.IsRequired=true");
			default:
				throw new NotSupportedException($"platform {Platform.CurrentPlatformId} not supported");
			}
		}
		return new DeviceContextEGL.NativePBuffer(new DevicePixelFormat(24), 1u, 1u);
	}

	public static INativePBuffer CreatePBuffer(DevicePixelFormat pixelFormat, uint width, uint height)
	{
		if (!Egl.IsRequired)
		{
			if (Platform.CurrentPlatformId == Platform.Id.WindowsNT)
			{
				return new DeviceContextWGL.NativePBuffer(pixelFormat, width, height);
			}
			throw new NotSupportedException($"platform {Platform.CurrentPlatformId} not supported");
		}
		return new DeviceContextEGL.NativePBuffer(pixelFormat, width, height);
	}

	public static DeviceContext Create()
	{
		if (!IsEglRequired)
		{
			if (Gl.NativeWindow == null)
			{
				throw new InvalidOperationException("OpenGL.Net not initialized", Gl.InitializationException);
			}
			switch (Platform.CurrentPlatformId)
			{
			case Platform.Id.WindowsNT:
				return new DeviceContextWGL();
			case Platform.Id.Linux:
				return new DeviceContextGLX();
			case Platform.Id.MacOS:
				if (Glx.IsRequired)
				{
					return new DeviceContextGLX();
				}
				throw new NotSupportedException("platform MacOS not supported without Glx.IsRequired=true");
			default:
				throw new NotSupportedException($"platform {Platform.CurrentPlatformId} not supported");
			}
		}
		if (Egl.CurrentExtensions == null || !Egl.CurrentExtensions.SurfacelessContext_KHR)
		{
			if (Gl.NativeWindow == null)
			{
				throw new InvalidOperationException("OpenGL.Net not initialized", Gl.InitializationException);
			}
			if (Gl.NativeWindow is INativePBuffer nativeBuffer)
			{
				return new DeviceContextEGL(nativeBuffer);
			}
			INativeWindow nativeWindow = Gl.NativeWindow;
			if (nativeWindow != null)
			{
				return new DeviceContextEGL(nativeWindow.Handle);
			}
			throw new NotSupportedException("EGL surface not supported");
		}
		return new DeviceContextEGL(IntPtr.Zero);
	}

	public static DeviceContext Create(nint display, nint windowHandle)
	{
		if (!IsEglRequired)
		{
			switch (Platform.CurrentPlatformId)
			{
			case Platform.Id.WindowsNT:
				return new DeviceContextWGL(windowHandle);
			case Platform.Id.Linux:
				return new DeviceContextGLX(display, windowHandle);
			case Platform.Id.MacOS:
				if (Glx.IsRequired)
				{
					return new DeviceContextGLX(display, windowHandle);
				}
				throw new NotSupportedException("platform MacOS not supported without Glx.IsRequired=true");
			default:
				throw new NotSupportedException($"platform {Platform.CurrentPlatformId} not supported");
			}
		}
		return new DeviceContextEGL(display, windowHandle);
	}

	public static DeviceContext Create(INativePBuffer nativeBuffer)
	{
		if (!IsEglRequired)
		{
			if (Platform.CurrentPlatformId == Platform.Id.WindowsNT)
			{
				return new DeviceContextWGL(nativeBuffer);
			}
			throw new NotSupportedException($"platform {Platform.CurrentPlatformId} not supported");
		}
		return new DeviceContextEGL(nativeBuffer);
	}

	public void IncRef()
	{
		RefCount++;
	}

	public void DecRef()
	{
		if (RefCount != 0)
		{
			RefCount--;
		}
		if (RefCount == 0)
		{
			Dispose();
		}
	}

	protected void ResetRefCount()
	{
		RefCount = 0u;
	}

	internal abstract nint CreateSimpleContext();

	public static IEnumerable<string> GetAvailableAPIs()
	{
		List<string> list = new List<string>();
		using DeviceContext deviceContext = Create();
		list.AddRange(deviceContext.AvailableAPIs);
		return list;
	}

	public abstract nint CreateContext(nint sharedContext);

	public abstract nint CreateContextAttrib(nint sharedContext, int[] attribsList);

	public abstract nint CreateContextAttrib(nint sharedContext, int[] attribsList, KhronosVersion api);

	public virtual bool MakeCurrent(nint ctx)
	{
		bool flag = MakeCurrentCore(ctx);
		if (ctx == IntPtr.Zero || !flag)
		{
			return flag;
		}
		if (DefaultAPI == "glsc2")
		{
			Gl.BindAPI(Gl.Version_200_SC, null);
		}
		else
		{
			Gl.BindAPI();
		}
		return true;
	}

	protected abstract bool MakeCurrentCore(nint ctx);

	public abstract bool DeleteContext(nint ctx);

	public abstract void SwapBuffers();

	public abstract bool SwapInterval(int interval);

	internal abstract void QueryPlatformExtensions();

	public abstract Exception GetPlatformException();

	public abstract void ChoosePixelFormat(DevicePixelFormat pixelFormat);

	public abstract void SetPixelFormat(DevicePixelFormat pixelFormat);

	public static nint GetCurrentContext()
	{
		if (!Egl.IsRequired)
		{
			switch (Platform.CurrentPlatformId)
			{
			case Platform.Id.WindowsNT:
				return Wgl.GetCurrentContext();
			case Platform.Id.Linux:
				return Glx.GetCurrentContext();
			case Platform.Id.MacOS:
				if (Glx.IsRequired)
				{
					return Glx.GetCurrentContext();
				}
				throw new NotSupportedException("platform MacOS not supported without Glx.IsRequired=true");
			default:
				throw new NotSupportedException($"platform {Platform.CurrentPlatformId} not supported");
			}
		}
		return Egl.GetCurrentContext();
	}

	~DeviceContext()
	{
		Dispose(disposing: false);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			IsDisposed = true;
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}
}
