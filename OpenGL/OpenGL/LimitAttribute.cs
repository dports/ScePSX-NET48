using System;

namespace OpenGL;

[AttributeUsage(AttributeTargets.Field)]
internal class LimitAttribute : Attribute
{
	public readonly int EnumValue;

	public uint ArrayLength { get; set; }

	public LimitAttribute(int @enum)
	{
		EnumValue = @enum;
	}
}
