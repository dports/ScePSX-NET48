namespace Vulkan.Xlib;

public struct VisualID
{
	public ulong ID;

	public static implicit operator VisualID(ulong value)
	{
		VisualID result = default(VisualID);
		result.ID = value;
		return result;
	}

	public static implicit operator ulong(VisualID id)
	{
		return id.ID;
	}
}
