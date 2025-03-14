using System;
using System.Collections.Generic;
using System.Linq;

namespace Khronos;

public sealed class KhronosLogMap
{
	public sealed class Command
	{
		public string Name;

		public CommandParam[] Params;
	}

	public sealed class CommandParam
	{
		public string Name;

		public KhronosLogCommandParameterFlags Flags;
	}

	private readonly Dictionary<string, Command> _Commands = new Dictionary<string, Command>();

	public Command[] Commands
	{
		get
		{
			return _Commands.Values.ToArray();
		}
		set
		{
			_Commands.Clear();
			if (value != null)
			{
				foreach (Command command in value)
				{
					_Commands[command.Name] = command;
				}
			}
		}
	}

	internal static KhronosLogMap Load(string resourcePath)
	{
		if (resourcePath == null)
		{
			throw new ArgumentNullException("resourcePath");
		}
		throw new NotImplementedException();
	}

	internal static void Save(string resourcePath, KhronosLogMap logMap)
	{
		if (resourcePath == null)
		{
			throw new ArgumentNullException("resourcePath");
		}
		if (logMap == null)
		{
			throw new ArgumentNullException("logMap");
		}
		throw new NotImplementedException();
	}

	public KhronosLogCommandParameterFlags GetCommandParameterFlag(string commandName, int paramIndex)
	{
		return GetCommandParam(commandName, paramIndex)?.Flags ?? KhronosLogCommandParameterFlags.None;
	}

	private Command GetCommand(string commandName)
	{
		if (commandName == null)
		{
			throw new ArgumentNullException("commandName");
		}
		if (_Commands.TryGetValue(commandName, out var value))
		{
			return value;
		}
		return null;
	}

	private CommandParam GetCommandParam(string commandName, int paramIndex)
	{
		if (paramIndex < 0)
		{
			throw new ArgumentOutOfRangeException("paramIndex", paramIndex, "it cannot be negative");
		}
		Command command = GetCommand(commandName);
		if (command == null)
		{
			return null;
		}
		if (paramIndex >= command.Params.Length)
		{
			throw new ArgumentOutOfRangeException("paramIndex", paramIndex, "greater than the number of parameters");
		}
		return command.Params[paramIndex];
	}
}
