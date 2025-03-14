using System;

namespace Vulkan;

[Flags]
public enum VkBufferUsageFlags
{
	None = 0,
	TransferSrc = 1,
	TransferDst = 2,
	UniformTexelBuffer = 4,
	StorageTexelBuffer = 8,
	UniformBuffer = 0x10,
	StorageBuffer = 0x20,
	IndexBuffer = 0x40,
	VertexBuffer = 0x80,
	IndirectBuffer = 0x100
}
