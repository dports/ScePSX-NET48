using System;

namespace ScePSX;

[Serializable]
public class Expansion
{
	public uint read(uint addr)
	{
		Console.WriteLine($"[BUS] Read Unsupported to EXP2 address: {addr:x8}");
		return 255u;
	}

	public void write(uint addr, uint value)
	{
		if (addr != 528490531 && addr != 528490561 && addr != 528490624)
		{
			Console.WriteLine($"[BUS] Write Unsupported to EXP2: {addr:x8} Value: {value:x8}");
		}
	}
}
