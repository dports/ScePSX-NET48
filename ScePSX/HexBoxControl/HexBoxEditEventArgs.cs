using System;

namespace HexBoxControl;

public class HexBoxEditEventArgs : EventArgs
{
	private int _Offset;

	private int _OldValue;

	private int _NewValue;

	public int Offset => _Offset;

	public int OldValue => _OldValue;

	public int NewValue => _NewValue;

	public HexBoxEditEventArgs(int offset, int prev, int current)
	{
		_Offset = offset;
		_OldValue = prev;
		_NewValue = current;
	}
}
