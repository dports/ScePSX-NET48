using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace Khronos;

public class KhronosApi
{
	public delegate nint GetAddressDelegate(string path, string function);

	private class FunctionContext
	{
		private readonly Type _DelegateType;

		public readonly List<FieldInfo> Delegates;

		public FunctionContext(Type type)
		{
			Type nestedType = type.GetNestedType("Delegates", BindingFlags.Static | BindingFlags.NonPublic);
			_DelegateType = nestedType;
			Delegates = GetDelegateList(type);
		}

		public FieldInfo GetFunction(string functionName)
		{
			if (functionName == null)
			{
				throw new ArgumentNullException("functionName");
			}
			return _DelegateType.GetField("p" + functionName, BindingFlags.Static | BindingFlags.NonPublic);
		}
	}

	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
	public sealed class ExtensionAttribute : Attribute
	{
		public readonly string ExtensionName;

		public string Api;

		public ExtensionAttribute(string extensionName)
		{
			ExtensionName = extensionName;
		}
	}

	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
	public sealed class CoreExtensionAttribute : Attribute
	{
		public readonly KhronosVersion Version;

		public CoreExtensionAttribute(int major, int minor, string api)
		{
			Version = new KhronosVersion(major, minor, 0, api);
		}

		public CoreExtensionAttribute(int major, int minor)
			: this(major, minor, "gl")
		{
		}
	}

	public abstract class ExtensionsCollection
	{
		private readonly Dictionary<string, bool> _ExtensionsRegistry = new Dictionary<string, bool>();

		public bool HasExtensions(string extensionName)
		{
			if (extensionName == null)
			{
				throw new ArgumentNullException("extensionName");
			}
			return _ExtensionsRegistry.ContainsKey(extensionName);
		}

		internal void EnableExtension(string extensionName)
		{
			if (extensionName == null)
			{
				throw new ArgumentNullException("extensionName");
			}
			_ExtensionsRegistry[extensionName] = true;
		}

		protected void Query(KhronosVersion version, string extensionsString)
		{
			if (extensionsString == null)
			{
				throw new ArgumentNullException("extensionsString");
			}
			Query(version, extensionsString.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
		}

		protected void Query(KhronosVersion version, string[] extensions)
		{
			if (extensions == null)
			{
				throw new ArgumentNullException("extensions");
			}
			_ExtensionsRegistry.Clear();
			foreach (string key in extensions)
			{
				if (!_ExtensionsRegistry.ContainsKey(key))
				{
					_ExtensionsRegistry.Add(key, value: true);
				}
			}
			SyncMembers(version);
		}

		protected internal void SyncMembers(KhronosVersion version)
		{
			foreach (FieldInfo declaredField in GetType().GetTypeInfo().DeclaredFields)
			{
				if (declaredField.FieldType != typeof(bool))
				{
					continue;
				}
				bool flag = false;
				foreach (ExtensionAttribute customAttribute in declaredField.GetCustomAttributes(typeof(ExtensionAttribute)))
				{
					if (_ExtensionsRegistry.ContainsKey(customAttribute.ExtensionName) && (!(version != null) || version.Api == null || customAttribute.Api == null || Regex.IsMatch(version.Api, "^" + customAttribute.Api + "$")))
					{
						flag = true;
						break;
					}
				}
				if (version != null && !flag)
				{
					foreach (CoreExtensionAttribute customAttribute2 in declaredField.GetCustomAttributes(typeof(CoreExtensionAttribute)))
					{
						if (!(version.Api != customAttribute2.Version.Api) && !(version < customAttribute2.Version))
						{
							flag = true;
							break;
						}
					}
				}
				declaredField.SetValue(this, flag);
			}
		}
	}

	private static readonly Dictionary<Type, FunctionContext> _FunctionContext = new Dictionary<Type, FunctionContext>();

	public static bool HasdDebugLogging => false;

	public static bool LogEnabled { get; set; }

	public static event EventHandler<KhronosLogEventArgs> Log;

	protected static string PtrToString(nint ptr)
	{
		return PtrToStringUTF8(ptr);
	}

	protected static string PtrToStringUTF8(nint ptr)
	{
		if (ptr == IntPtr.Zero)
		{
			return null;
		}
		List<byte> list = new List<byte>();
		int num = 0;
		while (true)
		{
			byte b = Marshal.ReadByte(ptr, num);
			if (b == 0)
			{
				break;
			}
			list.Add(b);
			num++;
		}
		return Encoding.UTF8.GetString(list.ToArray());
	}

	protected static string GetAssemblyLocation()
	{
		return Directory.GetCurrentDirectory();
	}

	protected static nint GetProcAddressOS(string path, string function)
	{
		return Khronos.GetProcAddressOS.GetProcAddress(path, function);
	}

	internal static void BindAPIFunction<T>(string path, string functionName, GetAddressDelegate getProcAddress, KhronosVersion version, ExtensionsCollection extensions)
	{
		FunctionContext functionContext = GetFunctionContext(typeof(T));
		BindAPIFunction(path, getProcAddress, functionContext.GetFunction(functionName), version, extensions);
	}

	internal static void BindAPI<T>(string path, GetAddressDelegate getAddress, KhronosVersion version)
	{
		BindAPI<T>(path, getAddress, version, null);
	}

	internal static void BindAPI<T>(string path, GetAddressDelegate getAddress, KhronosVersion version, ExtensionsCollection extensions)
	{
		if (path == null)
		{
			throw new ArgumentNullException("path");
		}
		if (getAddress == null)
		{
			throw new ArgumentNullException("getAddress");
		}
		foreach (FieldInfo @delegate in GetFunctionContext(typeof(T)).Delegates)
		{
			BindAPIFunction(path, getAddress, @delegate, version, extensions);
		}
	}

	private static void BindAPIFunction(string path, GetAddressDelegate getAddress, FieldInfo function, KhronosVersion version, ExtensionsCollection extensions)
	{
		RequiredByFeatureAttribute requiredByFeatureAttribute = null;
		List<RequiredByFeatureAttribute> list = new List<RequiredByFeatureAttribute>();
		string text = function.Name.Substring(1);
		if (version != null || extensions != null)
		{
			bool flag = false;
			foreach (RequiredByFeatureAttribute item in (IEnumerable<Attribute>)new List<Attribute>(function.GetCustomAttributes(typeof(RequiredByFeatureAttribute))))
			{
				if (!item.IsSupported(version, extensions))
				{
					continue;
				}
				if (item.FeatureVersion != null)
				{
					if (requiredByFeatureAttribute == null || requiredByFeatureAttribute.FeatureVersion < item.FeatureVersion)
					{
						requiredByFeatureAttribute = item;
					}
				}
				else
				{
					list.Add(item);
				}
			}
			if (requiredByFeatureAttribute != null)
			{
				Attribute[] array = new List<Attribute>(function.GetCustomAttributes(typeof(RemovedByFeatureAttribute))).ToArray();
				KhronosVersion khronosVersion = null;
				Attribute[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					RemovedByFeatureAttribute removedByFeatureAttribute = (RemovedByFeatureAttribute)array2[i];
					if (removedByFeatureAttribute.IsRemoved(version, extensions))
					{
						flag = true;
						if (khronosVersion == null || khronosVersion < removedByFeatureAttribute.FeatureVersion)
						{
							khronosVersion = removedByFeatureAttribute.FeatureVersion;
						}
					}
				}
				if (flag && requiredByFeatureAttribute.FeatureVersion > khronosVersion)
				{
					flag = false;
				}
			}
			if (flag)
			{
				requiredByFeatureAttribute = null;
			}
		}
		if (requiredByFeatureAttribute != null || version == null)
		{
			string function2 = text;
			if (requiredByFeatureAttribute != null && requiredByFeatureAttribute.EntryPoint != null)
			{
				function2 = requiredByFeatureAttribute.EntryPoint;
			}
			nint importAddress;
			if ((importAddress = getAddress(path, function2)) != IntPtr.Zero)
			{
				BindAPIFunction(function, importAddress);
				return;
			}
		}
		foreach (RequiredByFeatureAttribute item2 in list)
		{
			string function3 = item2.EntryPoint ?? text;
			nint importAddress;
			if ((importAddress = getAddress(path, function3)) != IntPtr.Zero)
			{
				BindAPIFunction(function, importAddress);
				return;
			}
		}
		function.SetValue(null, null);
	}

	private static void BindAPIFunction(FieldInfo function, nint importAddress)
	{
		Delegate delegateForFunctionPointer = Marshal.GetDelegateForFunctionPointer(importAddress, function.FieldType);
		function.SetValue(null, delegateForFunctionPointer);
	}

	internal static bool IsCompatibleField(FieldInfo function, KhronosVersion version, ExtensionsCollection extensions)
	{
		List<Attribute> list = new List<Attribute>(function.GetCustomAttributes(typeof(RequiredByFeatureAttribute)));
		KhronosVersion khronosVersion = null;
		bool flag = false;
		bool flag2 = false;
		foreach (RequiredByFeatureAttribute item in (IEnumerable<Attribute>)list)
		{
			if (item.IsSupported(version, extensions))
			{
				flag = true;
				if (khronosVersion == null || khronosVersion < item.FeatureVersion)
				{
					khronosVersion = item.FeatureVersion;
				}
			}
		}
		if (flag)
		{
			List<Attribute> list2 = new List<Attribute>(function.GetCustomAttributes(typeof(RemovedByFeatureAttribute)));
			KhronosVersion khronosVersion2 = null;
			foreach (RemovedByFeatureAttribute item2 in (IEnumerable<Attribute>)list2)
			{
				if (item2.IsRemoved(version, extensions))
				{
					flag2 = true;
					if (khronosVersion2 == null || khronosVersion2 < item2.FeatureVersion)
					{
						khronosVersion2 = item2.FeatureVersion;
					}
				}
			}
			if (flag2 && khronosVersion > khronosVersion2)
			{
				flag2 = false;
			}
			return !flag2;
		}
		return false;
	}

	private static List<FieldInfo> GetDelegateList(Type type)
	{
		return new List<FieldInfo>(type.GetNestedType("Delegates", BindingFlags.Static | BindingFlags.NonPublic).GetFields(BindingFlags.Static | BindingFlags.NonPublic));
	}

	private static FunctionContext GetFunctionContext(Type type)
	{
		if (_FunctionContext.TryGetValue(type, out var value))
		{
			return value;
		}
		value = new FunctionContext(type);
		_FunctionContext.Add(type, value);
		return value;
	}

	protected static void CheckExtensionCommands<T>(KhronosVersion version, ExtensionsCollection extensions, bool enableExtensions) where T : KhronosApi
	{
		if (version == null)
		{
			throw new ArgumentNullException("version");
		}
		if (extensions == null)
		{
			throw new ArgumentNullException("extensions");
		}
		throw new NotImplementedException();
	}

	protected internal static void RaiseLog(KhronosLogEventArgs args)
	{
		if (args == null)
		{
			throw new ArgumentNullException("args");
		}
		if (!LogEnabled || KhronosApi.Log == null)
		{
			return;
		}
		Delegate[] invocationList = KhronosApi.Log.GetInvocationList();
		for (int i = 0; i < invocationList.Length; i++)
		{
			EventHandler<KhronosLogEventArgs> eventHandler = (EventHandler<KhronosLogEventArgs>)invocationList[i];
			try
			{
				eventHandler(null, args);
			}
			catch
			{
			}
		}
	}

	public static void LogComment(string comment)
	{
		if (comment == null)
		{
			throw new ArgumentNullException("comment");
		}
		if (LogEnabled)
		{
			RaiseLog(new KhronosLogEventArgs(comment));
		}
	}

	[Conditional("GL_DEBUG")]
	public static void LogCommand(string name, object returnValue, params object[] args)
	{
		if (LogEnabled)
		{
			RaiseLog(new KhronosLogEventArgs(null, name, args, returnValue));
		}
	}
}
