using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Khronos;

public static class Platform
{
	public enum Id
	{
		WindowsNT,
		Linux,
		MacOS,
		Android,
		Unknown
	}

	private static readonly string _MonoVersion;

	public static Id CurrentPlatformId { get; internal set; }

	public static bool RunningMono => _MonoVersion != null;

	static Platform()
	{
		CurrentPlatformId = GetCurrentPlatform();
		_MonoVersion = DetectMonoEnvironment();
	}

	private static Id GetCurrentPlatform()
	{
		if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
		{
			return Id.WindowsNT;
		}
		if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
		{
			return Id.Linux;
		}
		if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
		{
			return Id.MacOS;
		}
		return Id.Unknown;
	}

	private static string DetectUnixKernel()
	{
		ProcessStartInfo processStartInfo = new ProcessStartInfo
		{
			Arguments = "-s",
			RedirectStandardOutput = true,
			RedirectStandardError = true,
			UseShellExecute = false
		};
		string[] array = new string[3] { "/usr/bin/uname", "/bin/uname", "uname" };
		foreach (string text in array)
		{
			if (!File.Exists(text))
			{
				continue;
			}
			try
			{
				processStartInfo.FileName = text;
				using Process process = Process.Start(processStartInfo);
				if (process != null)
				{
					return process.StandardOutput.ReadLine()?.Trim();
				}
			}
			catch (FileNotFoundException)
			{
			}
			catch (Win32Exception)
			{
			}
		}
		return null;
	}

	private static string DetectMonoEnvironment()
	{
		Type type = Type.GetType("Mono.Runtime", throwOnError: false);
		if (type != null)
		{
			string result = "generic";
			try
			{
				MethodInfo method = type.GetMethod("GetDisplayName", BindingFlags.Static | BindingFlags.NonPublic);
				if (method != null)
				{
					result = method.Invoke(null, new object[0]) as string;
				}
			}
			catch
			{
			}
			return result;
		}
		return null;
	}
}
