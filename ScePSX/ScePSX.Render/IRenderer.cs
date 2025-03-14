using System;
using System.Windows.Forms;

namespace ScePSX.Render;

public interface IRenderer : IDisposable
{
	RenderMode Mode { get; }

	void RenderBuffer(int[] pixels, int width, int height, ScaleParam scale);

	void Initialize(Control parentControl);

	void SetParam(int Param);
}
