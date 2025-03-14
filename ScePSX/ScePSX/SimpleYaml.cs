using System;
using System.Collections.Generic;
using System.IO;

namespace ScePSX;

internal static class SimpleYaml
{
	private static Dictionary<string, object> yamlData = new Dictionary<string, object>();

	public static void ParseYamlFile(string filePath)
	{
		Stack<(int, Dictionary<string, object>)> stack = new Stack<(int, Dictionary<string, object>)>();
		stack.Push((0, yamlData));
		using StreamReader streamReader = new StreamReader(filePath);
		string text;
		while ((text = streamReader.ReadLine()) != null)
		{
			string text2 = text.Trim();
			if (string.IsNullOrWhiteSpace(text2) || text2.StartsWith("#"))
			{
				continue;
			}
			int num = text.Length - text2.Length;
			while (stack.Count > 1 && stack.Peek().Item1 >= num)
			{
				stack.Pop();
			}
			if (text2.Contains(":") && !text2.Contains(": "))
			{
				string key = text2.Replace(":", "").Trim();
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				stack.Peek().Item2[key] = dictionary;
				stack.Push((num, dictionary));
			}
			else if (text2.Contains(": "))
			{
				int num2 = text2.IndexOf(": ");
				string key2 = text2.Substring(0, num2).Trim();
				string text3 = text2.Substring(num2 + 2).Trim();
				int result;
				if (text3 == "true" || text3 == "false")
				{
					stack.Peek().Item2[key2] = bool.Parse(text3);
				}
				else if (int.TryParse(text3, out result))
				{
					stack.Peek().Item2[key2] = result;
				}
				else
				{
					stack.Peek().Item2[key2] = text3;
				}
			}
			else
			{
				if (!text2.StartsWith("- "))
				{
					continue;
				}
				string item = text2.Substring(2).Trim();
				if (stack.Peek().Item2.Count <= 0)
				{
					continue;
				}
				string text4 = null;
				foreach (KeyValuePair<string, object> item2 in stack.Peek().Item2)
				{
					text4 = item2.Key;
				}
				if (text4 != null && stack.Peek().Item2[text4] is List<object> list)
				{
					list.Add(item);
					continue;
				}
				stack.Peek().Item2[text4] = new List<object> { item };
			}
		}
	}

	public static string TryGetValue(string keyPath)
	{
		string[] array = keyPath.Split('.');
		object obj = yamlData;
		string[] array2 = array;
		foreach (string key in array2)
		{
			if (obj is Dictionary<string, object> dictionary && dictionary.ContainsKey(key))
			{
				obj = dictionary[key];
				continue;
			}
			return "";
		}
		return obj.ToString();
	}

	public static void Clear()
	{
		yamlData.Clear();
		yamlData = new Dictionary<string, object>();
		GC.Collect();
		GC.WaitForPendingFinalizers();
		GC.Collect();
	}
}
