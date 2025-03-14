using System;

namespace ScePSX;

[Serializable]
public abstract class Channel
{
	public abstract void write(uint register, uint value);

	public abstract uint read(uint regiter);
}
