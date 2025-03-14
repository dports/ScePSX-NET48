using System;
using System.Collections.Generic;
using System.Text;

namespace Khronos;

internal sealed class KhronosLogContext
{
	private Dictionary<long, string> _EnumNames;

	private readonly KhronosLogMap _LogMap;

	public KhronosLogContext(Type khronoApiType)
		: this(khronoApiType, null)
	{
	}

	public KhronosLogContext(Type khronoApiType, KhronosLogMap logMap)
	{
		QueryLogContext(khronoApiType);
		if (logMap != null)
		{
			_LogMap = logMap;
		}
	}

	public string GetEnumName(long enumValue)
	{
		if (_EnumNames.TryGetValue(enumValue, out var value))
		{
			return value;
		}
		return null;
	}

	private void QueryLogContext(Type khronoApiType)
	{
		if (khronoApiType == null)
		{
			throw new ArgumentNullException("khronoApiType");
		}
		Dictionary<long, string> enumNames = new Dictionary<long, string>();
		new Dictionary<string, Dictionary<long, string>>();
		_EnumNames = enumNames;
	}

	public string ToString(string name, object returnValue, object[] args)
	{
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		StringBuilder stringBuilder = new StringBuilder();
		int num = 1;
		stringBuilder.Append("{0}(");
		if (args != null && args.Length != 0)
		{
			for (int i = 0; i < args.Length; i++)
			{
				stringBuilder.AppendFormat("{{{0}}}, ", num++);
			}
			stringBuilder.Remove(stringBuilder.Length - 2, 2);
		}
		stringBuilder.Append(")");
		if (returnValue != null)
		{
			stringBuilder.AppendFormat(" = {{{0}}}", num);
		}
		List<object> list = new List<object> { name };
		if (args != null)
		{
			for (int j = 0; j < args.Length; j++)
			{
				KhronosLogCommandParameterFlags flags = KhronosLogCommandParameterFlags.None;
				list.Add(FormatArg(args[j], flags));
			}
		}
		if (returnValue != null)
		{
			list.Add(FormatArg(returnValue, KhronosLogCommandParameterFlags.None));
		}
		return string.Format(stringBuilder.ToString(), list.ToArray());
	}

	private object FormatArg(object arg, KhronosLogCommandParameterFlags flags)
	{
		if (arg == null)
		{
			return "null";
		}
		Type type = arg.GetType();
		if (type == typeof(string[]))
		{
			return FormatArg((string[])arg);
		}
		if (type.IsArray)
		{
			return FormatArg((Array)arg, flags);
		}
		if (type == typeof(string))
		{
			return FormatArg((string)arg);
		}
		if (type == typeof(nint))
		{
			return FormatArg((nint)arg);
		}
		if (type == typeof(int))
		{
			return FormatArg((int)arg, flags);
		}
		return arg;
	}

	private static object FormatArg(string[] arg)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("{");
		foreach (string text in arg)
		{
			stringBuilder.AppendFormat("{0},", text.Replace("\n", "\\n"));
		}
		if (arg.Length != 0)
		{
			stringBuilder.Remove(stringBuilder.Length - 1, 1);
		}
		stringBuilder.Append("}");
		return stringBuilder.ToString();
	}

	private object FormatArg(Array arg, KhronosLogCommandParameterFlags flags)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("{");
		foreach (object item in arg)
		{
			stringBuilder.AppendFormat("{0},", FormatArg(item, flags).ToString());
		}
		if (arg.Length > 0)
		{
			stringBuilder.Remove(stringBuilder.Length - 1, 1);
		}
		stringBuilder.Append("}");
		return stringBuilder.ToString();
	}

	private static object FormatArg(nint arg)
	{
		return "0x" + ((IntPtr)arg).ToString("X8");
	}

	private static object FormatArg(string arg)
	{
		return "\"" + arg + "\"";
	}

	private object FormatArg(int arg, KhronosLogCommandParameterFlags flags)
	{
		if ((flags & KhronosLogCommandParameterFlags.Enum) != 0)
		{
			string enumName = GetEnumName(arg);
			if (enumName != null)
			{
				return enumName;
			}
		}
		return arg;
	}
}
