using System;

namespace OpenGL;

public class GlControlEventArgs : EventArgs
{
	public readonly DeviceContext DeviceContext;

	public readonly nint RenderContext;

	public GlControlEventArgs(DeviceContext deviceContext, nint renderContext)
	{
		if (deviceContext == null)
		{
			throw new ArgumentNullException("deviceContext");
		}
		if (renderContext == IntPtr.Zero)
		{
			throw new ArgumentException("renderContext");
		}
		DeviceContext = deviceContext;
		RenderContext = renderContext;
	}
}
