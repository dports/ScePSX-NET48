using System;
using Khronos;

namespace OpenGL;

public class KhronosApi : Khronos.KhronosApi
{
	protected static readonly bool EnvDebug;

	protected static readonly bool EnvExperimental;

	public static event EventHandler<EglEventArgs> EglInitializing;

	static KhronosApi()
	{
		EnvDebug = Environment.GetEnvironmentVariable("OPENGL_NET_DEBUG") != null;
		EnvExperimental = Environment.GetEnvironmentVariable("OPENGL_NET_EXPERIMENTAL") != null;
	}

	protected static void RaiseEglInitializing(EglEventArgs e)
	{
		KhronosApi.EglInitializing?.Invoke(null, e);
	}

	protected static nint GetProcAddressGL(string path, string function)
	{
		return OpenGL.GetProcAddressGL.GetProcAddress(function);
	}

	protected static nint GetProcAddressGLOS(string path, string function)
	{
		nint procAddress = OpenGL.GetProcAddressGL.GetProcAddress(function);
		if (procAddress == IntPtr.Zero)
		{
			procAddress = Khronos.GetProcAddressOS.GetProcAddress(path, function);
		}
		return procAddress;
	}
}
