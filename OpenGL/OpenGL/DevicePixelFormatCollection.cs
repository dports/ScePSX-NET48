using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace OpenGL;

[DebuggerDisplay("DevicePixelFormatCollection: Count={Count}")]
public class DevicePixelFormatCollection : List<DevicePixelFormat>
{
	public List<DevicePixelFormat> Choose(DevicePixelFormat pixelFormat)
	{
		if (pixelFormat == null)
		{
			throw new ArgumentNullException("pixelFormat");
		}
		List<DevicePixelFormat> list = new List<DevicePixelFormat>(this);
		list.RemoveAll(delegate(DevicePixelFormat item)
		{
			if (pixelFormat.RgbaUnsigned != item.RgbaUnsigned)
			{
				return true;
			}
			if (pixelFormat.RgbaFloat != item.RgbaFloat)
			{
				return true;
			}
			if (pixelFormat.RenderWindow && !item.RenderWindow)
			{
				return true;
			}
			if (pixelFormat.RenderPBuffer && !item.RenderPBuffer)
			{
				return true;
			}
			if (pixelFormat.RenderBuffer && !item.RenderBuffer)
			{
				return true;
			}
			if (item.ColorBits < pixelFormat.ColorBits)
			{
				return true;
			}
			if (item.RedBits < pixelFormat.RedBits)
			{
				return true;
			}
			if (item.GreenBits < pixelFormat.GreenBits)
			{
				return true;
			}
			if (item.BlueBits < pixelFormat.BlueBits)
			{
				return true;
			}
			if (item.AlphaBits < pixelFormat.AlphaBits)
			{
				return true;
			}
			if (item.DepthBits < pixelFormat.DepthBits)
			{
				return true;
			}
			if (item.StencilBits < pixelFormat.StencilBits)
			{
				return true;
			}
			if (item.MultisampleBits < pixelFormat.MultisampleBits)
			{
				return true;
			}
			if (pixelFormat.DoubleBuffer && !item.DoubleBuffer)
			{
				return true;
			}
			return (pixelFormat.SRGBCapable && !item.SRGBCapable) ? true : false;
		});
		List<DevicePixelFormat> list2 = list.Select((DevicePixelFormat devicePixelFormat) => devicePixelFormat.Copy()).ToList();
		list2.Sort(delegate(DevicePixelFormat x, DevicePixelFormat y)
		{
			int result;
			if ((result = x.ColorBits.CompareTo(y.ColorBits)) != 0)
			{
				return result;
			}
			if ((result = x.DepthBits.CompareTo(y.DepthBits)) != 0)
			{
				return result;
			}
			if ((result = x.StencilBits.CompareTo(y.StencilBits)) != 0)
			{
				return result;
			}
			if ((result = x.MultisampleBits.CompareTo(y.MultisampleBits)) != 0)
			{
				return result;
			}
			return ((result = y.DoubleBuffer.CompareTo(x.DoubleBuffer)) != 0) ? result : 0;
		});
		return list2;
	}

	public string GuessChooseError(DevicePixelFormat pixelFormat)
	{
		if (pixelFormat == null)
		{
			throw new ArgumentNullException("pixelFormat");
		}
		List<DevicePixelFormat> list = new List<DevicePixelFormat>(this);
		list.RemoveAll(delegate(DevicePixelFormat item)
		{
			if (pixelFormat.RgbaUnsigned != item.RgbaUnsigned)
			{
				return true;
			}
			return (pixelFormat.RgbaFloat != item.RgbaFloat) ? true : false;
		});
		if (list.Count == 0)
		{
			return $"no RGBA pixel type matching (RGBAui={pixelFormat.RgbaUnsigned}, RGBAf={pixelFormat.RgbaFloat})";
		}
		list.RemoveAll(delegate(DevicePixelFormat item)
		{
			if (pixelFormat.RenderWindow && !item.RenderWindow)
			{
				return true;
			}
			if (pixelFormat.RenderPBuffer && !item.RenderPBuffer)
			{
				return true;
			}
			return (pixelFormat.RenderBuffer && !item.RenderBuffer) ? true : false;
		});
		if (list.Count == 0)
		{
			return $"no surface matching (Window={pixelFormat.RenderWindow}, PBuffer={pixelFormat.RenderPBuffer}, RenderBuffer={pixelFormat.RenderBuffer})";
		}
		list.RemoveAll(delegate(DevicePixelFormat item)
		{
			if (item.ColorBits < pixelFormat.ColorBits)
			{
				return true;
			}
			if (item.RedBits < pixelFormat.RedBits)
			{
				return true;
			}
			if (item.GreenBits < pixelFormat.GreenBits)
			{
				return true;
			}
			if (item.BlueBits < pixelFormat.BlueBits)
			{
				return true;
			}
			return (item.AlphaBits < pixelFormat.AlphaBits) ? true : false;
		});
		if (list.Count == 0)
		{
			return $"no color bits combination matching ({pixelFormat.ColorBits} bits, {{{pixelFormat.RedBits}|{pixelFormat.BlueBits}|{pixelFormat.GreenBits}|{pixelFormat.AlphaBits}}})";
		}
		list.RemoveAll((DevicePixelFormat item) => item.DepthBits < pixelFormat.DepthBits);
		if (list.Count == 0)
		{
			return $"no depth bits matching (Depth >= {pixelFormat.DepthBits})";
		}
		list.RemoveAll((DevicePixelFormat item) => item.StencilBits < pixelFormat.StencilBits);
		if (list.Count == 0)
		{
			return $"no stencil bits matching (Bits >= {pixelFormat.StencilBits})";
		}
		list.RemoveAll((DevicePixelFormat item) => item.MultisampleBits < pixelFormat.MultisampleBits);
		if (list.Count == 0)
		{
			return $"no multisample bits matching (Samples >= {pixelFormat.MultisampleBits})";
		}
		list.RemoveAll((DevicePixelFormat item) => pixelFormat.DoubleBuffer && !item.DoubleBuffer);
		if (list.Count == 0)
		{
			return $"no double-buffer matching (DB={pixelFormat.DoubleBuffer})";
		}
		list.RemoveAll((DevicePixelFormat item) => pixelFormat.SRGBCapable && !item.SRGBCapable);
		if (list.Count == 0)
		{
			return $"no sRGB matching (sRGB={pixelFormat.SRGBCapable})";
		}
		return "no error";
	}

	public DevicePixelFormatCollection Copy()
	{
		DevicePixelFormatCollection devicePixelFormatCollection = new DevicePixelFormatCollection();
		devicePixelFormatCollection.AddRange(this.Select((DevicePixelFormat devicePixelFormat) => devicePixelFormat.Copy()));
		return devicePixelFormatCollection;
	}
}
