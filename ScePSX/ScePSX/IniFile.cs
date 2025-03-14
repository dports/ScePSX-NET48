using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ScePSX;

public class IniFile
{
	private readonly string path;

	private readonly Dictionary<string, Dictionary<string, string>> data;

	public IniFile(string inipath)
	{
		path = inipath;
		data = new Dictionary<string, Dictionary<string, string>>(StringComparer.OrdinalIgnoreCase);
		Load();
	}

	private void Load()
	{
		if (!File.Exists(path))
		{
			return;
		}
		string text = null;
		string[] array = File.ReadAllLines(path);
		for (int i = 0; i < array.Length; i++)
		{
			string text2 = array[i].Trim();
			if (string.IsNullOrEmpty(text2) || text2.StartsWith(";"))
			{
				continue;
			}
			if (text2.StartsWith("[") && text2.EndsWith("]"))
			{
				text = text2.Substring(1, text2.Length - 2).Trim();
				if (!data.ContainsKey(text))
				{
					data[text] = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
				}
			}
			else if (text != null)
			{
				string[] array2 = text2.Split(new char[1] { '=' }, 2);
				if (array2.Length == 2)
				{
					string key = array2[0].Trim();
					string value = array2[1].Trim();
					data[text][key] = value;
				}
			}
		}
	}

	private void Save()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, Dictionary<string, string>> datum in data)
		{
			list.Add("[" + datum.Key + "]");
			foreach (KeyValuePair<string, string> item in datum.Value)
			{
				list.Add(item.Key + "=" + item.Value);
			}
			list.Add("");
		}
		File.WriteAllLines(path, list);
	}

	public void Write(string section, string key, string value)
	{
		if (!data.ContainsKey(section))
		{
			data[section] = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		}
		data[section][key] = value;
		Save();
	}

	public string Read(string section, string key)
	{
		if (data.ContainsKey(section) && data[section].ContainsKey(key))
		{
			return data[section][key];
		}
		return "";
	}

	public void WriteInt(string section, string key, int value)
	{
		Write(section, key, value.ToString());
	}

	public int ReadInt(string section, string key)
	{
		string value = Read(section, key);
		if (!string.IsNullOrEmpty(value))
		{
			return Convert.ToInt32(value);
		}
		return 0;
	}

	public double ReadFloat(string section, string key)
	{
		string value = Read(section, key);
		if (!string.IsNullOrEmpty(value))
		{
			return Convert.ToDouble(value);
		}
		return 0.0;
	}

	public void WriteFloat(string section, string key, double value)
	{
		Write(section, key, value.ToString());
	}

	public void WriteDictionary<TKey, TValue>(string section, Dictionary<TKey, TValue> dictionary) where TKey : Enum where TValue : Enum
	{
		if (dictionary != null && dictionary.Count != 0)
		{
			string value = string.Join(";", dictionary.Select((KeyValuePair<TKey, TValue> kvp) => $"{kvp.Key}|{kvp.Value}"));
			Write(section, "Dictionary", value);
		}
	}

	public Dictionary<TKey, TValue> ReadDictionary<TKey, TValue>(string section) where TKey : struct, Enum where TValue : struct, Enum
	{
		string text = Read(section, "Dictionary");
		if (string.IsNullOrEmpty(text))
		{
			return new Dictionary<TKey, TValue>();
		}
		return (from x in text.Split(new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries).Select(delegate(string pair)
			{
				string[] array = pair.Split('|');
				TKey result;
				TValue result2;
				return (array.Length == 2 && Enum.TryParse<TKey>(array[0], out result) && Enum.TryParse<TValue>(array[1], out result2)) ? new
				{
					Key = result,
					Value = result2
				} : null;
			})
			where x != null
			select x).ToDictionary(x => x.Key, x => x.Value);
	}

	public string[] GetSection(string sectionName)
	{
		if (data.ContainsKey(sectionName))
		{
			return data[sectionName].Select((KeyValuePair<string, string> kvp) => kvp.Key + "=" + kvp.Value).ToArray();
		}
		return Array.Empty<string>();
	}

	public string[] GetSectionKeys(string sectionName)
	{
		if (data.ContainsKey(sectionName))
		{
			return data[sectionName].Keys.ToArray();
		}
		return Array.Empty<string>();
	}

	public string[] GetSectionValues(string sectionName)
	{
		if (data.ContainsKey(sectionName))
		{
			return data[sectionName].Values.ToArray();
		}
		return Array.Empty<string>();
	}

	public void DeleteKey(string section, string key)
	{
		if (data.ContainsKey(section) && data[section].ContainsKey(key))
		{
			data[section].Remove(key);
			Save();
		}
	}
}
