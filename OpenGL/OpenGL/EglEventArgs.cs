using System;

namespace OpenGL;

public class EglEventArgs : EventArgs
{
	public nint Display = new IntPtr(0);
}
