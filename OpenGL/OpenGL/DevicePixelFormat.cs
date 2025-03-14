using System.Diagnostics;
using System.Text;

namespace OpenGL;

[DebuggerDisplay("DevicePixelFormat: Idx={FormatIndex} Color={ColorBits} Depth={DepthBits} Stencil={StencilBits} DB={DoubleBuffer} Ms={MultisampleBits} sRGB={SRGBCapable}")]
public sealed class DevicePixelFormat
{
	public int FormatIndex;

	public bool RgbaUnsigned;

	public bool RgbaFloat;

	public bool RenderWindow;

	public bool RenderBuffer;

	public bool RenderPBuffer;

	public bool DoubleBuffer;

	public int SwapMethod;

	public bool StereoBuffer;

	public int ColorBits;

	public int RedBits;

	public int GreenBits;

	public int BlueBits;

	public int AlphaBits;

	public int DepthBits;

	public int StencilBits;

	public int MultisampleBits;

	public bool SRGBCapable;

	internal nint XFbConfig;

	internal Glx.XVisualInfo XVisualInfo;

	public DevicePixelFormat()
	{
	}

	public DevicePixelFormat(int colorBits)
	{
		RgbaUnsigned = true;
		RenderWindow = true;
		ColorBits = colorBits;
	}

	public DevicePixelFormat Copy()
	{
		return (DevicePixelFormat)MemberwiseClone();
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (RgbaUnsigned)
		{
			stringBuilder.Append("U");
		}
		if (RgbaFloat)
		{
			stringBuilder.Append("F");
		}
		if (SRGBCapable)
		{
			stringBuilder.Append("s");
		}
		StringBuilder stringBuilder2 = new StringBuilder();
		if (RenderWindow)
		{
			stringBuilder2.Append("W");
		}
		if (RenderBuffer)
		{
			stringBuilder2.Append("B");
		}
		if (RenderPBuffer)
		{
			stringBuilder2.Append("P");
		}
		return $"Idx={FormatIndex} Pixel={stringBuilder} Color={ColorBits} Depth={DepthBits} Stencil={StencilBits} Ms={MultisampleBits} DB={DoubleBuffer}, Surface={stringBuilder2}";
	}
}
