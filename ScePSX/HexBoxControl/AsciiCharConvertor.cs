using System.Text;

namespace HexBoxControl;

public class AsciiCharConvertor : ICharConverter
{
	private Encoding _Encoding = Encoding.ASCII;

	public virtual char ToChar(byte[] dump, int offset)
	{
		char c = _Encoding.GetChars(dump, offset, 1)[0];
		if (c >= '!' && c != '\u007f')
		{
			return c;
		}
		return '\0';
	}

	public virtual byte ToByte(char c)
	{
		byte[] bytes = _Encoding.GetBytes(new char[1] { c });
		if (bytes.Length == 0)
		{
			return 0;
		}
		return bytes[0];
	}

	public override string ToString()
	{
		return "ASCII";
	}
}
