using System;
using System.ComponentModel;
using System.Text;
using Khronos;

namespace OpenGL;

public sealed class GlxException : KhronosException
{
	internal GlxException(nint displayHandle, ref Glx.XErrorEvent errorEvent)
		: base(errorEvent.error_code, GetErrorMessage(displayHandle, ref errorEvent), new Win32Exception(errorEvent.error_code, GetErrorMessage(displayHandle, ref errorEvent)))
	{
	}

	private static string GetErrorMessage(nint displayHandle, ref Glx.XErrorEvent errorEvent)
	{
		StringBuilder stringBuilder = new StringBuilder(1024);
		Glx.UnsafeNativeMethods.XGetErrorText(displayHandle, errorEvent.error_code, stringBuilder, 1024);
		string text = Enum.GetName(typeof(Glx.XEventName), errorEvent.type);
		string text2 = Enum.GetName(typeof(Glx.XRequest), errorEvent.request_code);
		if (string.IsNullOrEmpty(text))
		{
			text = "Unknown";
		}
		if (string.IsNullOrEmpty(text2))
		{
			text2 = "Unknown";
		}
		stringBuilder.AppendLine("\nX error details:");
		stringBuilder.AppendFormat("\tX event name: '{0}' ({1})\n", text, errorEvent.type);
		stringBuilder.AppendFormat("\tDisplay: 0x{0:x}\n", ((IntPtr)errorEvent.display).ToInt64());
		stringBuilder.AppendFormat("\tResource ID: {0:x}\n", ((IntPtr)errorEvent.resourceid).ToInt64());
		stringBuilder.AppendFormat("\tError code: {0}\n", errorEvent.error_code);
		stringBuilder.AppendFormat("\tMajor code: '{0}' ({1})\n", text2, errorEvent.request_code);
		stringBuilder.AppendFormat("\tMinor code: {0}", errorEvent.minor_code);
		return stringBuilder.ToString();
	}
}
