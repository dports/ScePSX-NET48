using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScePSX.UI;

public class KeyMappingManager
{
	public Dictionary<Keys, Controller.InputAction> _keyMapping = new Dictionary<Keys, Controller.InputAction>();

	public void SetKeyMapping(Keys key, Controller.InputAction button)
	{
		_keyMapping.Remove(GetKeyCode(button));
		_keyMapping.Remove(key);
		_keyMapping[key] = button;
	}

	public Controller.InputAction GetKeyButton(Keys key)
	{
		if (_keyMapping.TryGetValue(key, out var value))
		{
			return value;
		}
		return (Controller.InputAction)255;
	}

	public string GetKeyName(Keys key)
	{
		if (_keyMapping.TryGetValue(key, out var value))
		{
			return value.ToString();
		}
		return "";
	}

	public Keys GetKeyCode(Controller.InputAction button)
	{
		foreach (KeyValuePair<Keys, Controller.InputAction> item in _keyMapping)
		{
			if (item.Value == button)
			{
				return item.Key;
			}
		}
		return Keys.None;
	}

	public void ClearKeyMapping(Keys key)
	{
		_keyMapping.Remove(key);
	}

	public void ClearAllMappings()
	{
		_keyMapping.Clear();
	}

	public void PrintMappings()
	{
		Console.WriteLine("Current Key Mappings:");
		foreach (KeyValuePair<Keys, Controller.InputAction> item in _keyMapping)
		{
			Console.WriteLine($"{item.Key} -> {item.Value}");
		}
	}
}
