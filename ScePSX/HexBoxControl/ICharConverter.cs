namespace HexBoxControl;

public interface ICharConverter
{
	char ToChar(byte[] dump, int offset);

	byte ToByte(char c);
}
