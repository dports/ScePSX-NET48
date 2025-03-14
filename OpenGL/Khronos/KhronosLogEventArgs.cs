using System;

namespace Khronos;

public sealed class KhronosLogEventArgs : EventArgs
{
	private readonly KhronosLogContext _LogContext;

	public readonly string Name;

	public readonly object[] Args;

	public readonly object ReturnValue;

	private readonly string _Comment;

	internal KhronosLogEventArgs(string comment)
	{
		_Comment = comment;
	}

	internal KhronosLogEventArgs(KhronosLogContext logContext, string name, object[] args, object retvalue)
	{
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		_LogContext = logContext;
		Name = name;
		Args = args;
		ReturnValue = retvalue;
	}

	public override string ToString()
	{
		if (Name != null && _LogContext != null)
		{
			return _LogContext.ToString(Name, ReturnValue, Args);
		}
		return _Comment ?? string.Empty;
	}
}
