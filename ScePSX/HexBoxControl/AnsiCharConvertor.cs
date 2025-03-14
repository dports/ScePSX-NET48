namespace HexBoxControl;

public class AnsiCharConvertor : ICharConverter
{
	public virtual char ToChar(byte[] dump, int offset)
	{
		char c = (char)dump[offset];
		if (c >= '!' && ('~' >= c || c >= '¡') && c != '\u00ad')
		{
			return c;
		}
		return '\0';
	}

	public virtual byte ToByte(char c)
	{
		return (byte)c;
	}

	public override string ToString()
	{
		return "ANSI";
	}
}
