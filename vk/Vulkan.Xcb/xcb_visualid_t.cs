namespace Vulkan.Xcb;

public struct xcb_visualid_t
{
	public uint ID;

	public static implicit operator xcb_visualid_t(uint value)
	{
		xcb_visualid_t result = default(xcb_visualid_t);
		result.ID = value;
		return result;
	}

	public static implicit operator uint(xcb_visualid_t id)
	{
		return id.ID;
	}
}
