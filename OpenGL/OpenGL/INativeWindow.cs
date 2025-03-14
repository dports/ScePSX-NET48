using System;

namespace OpenGL;

internal interface INativeWindow : IDisposable
{
	nint Display { get; }

	nint Handle { get; }
}
