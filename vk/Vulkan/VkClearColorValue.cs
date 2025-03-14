using System.Runtime.InteropServices;

namespace Vulkan;

[StructLayout(LayoutKind.Explicit)]
public struct VkClearColorValue
{
	[FieldOffset(0)]
	public float float32_0;

	[FieldOffset(4)]
	public float float32_1;

	[FieldOffset(8)]
	public float float32_2;

	[FieldOffset(12)]
	public float float32_3;

	[FieldOffset(0)]
	public int int32_0;

	[FieldOffset(4)]
	public int int32_1;

	[FieldOffset(8)]
	public int int32_2;

	[FieldOffset(12)]
	public int int32_3;

	[FieldOffset(0)]
	public uint uint32_0;

	[FieldOffset(4)]
	public uint uint32_1;

	[FieldOffset(8)]
	public uint uint32_2;

	[FieldOffset(12)]
	public uint uint32_3;

	public VkClearColorValue(float r, float g, float b, float a = 1f)
	{
		this = default(VkClearColorValue);
		float32_0 = r;
		float32_1 = g;
		float32_2 = b;
		float32_3 = a;
	}

	public VkClearColorValue(int r, int g, int b, int a = 255)
	{
		this = default(VkClearColorValue);
		int32_0 = r;
		int32_1 = g;
		int32_2 = b;
		int32_3 = a;
	}

	public VkClearColorValue(uint r, uint g, uint b, uint a = 255u)
	{
		this = default(VkClearColorValue);
		uint32_0 = r;
		uint32_1 = g;
		uint32_2 = b;
		uint32_3 = a;
	}
}
