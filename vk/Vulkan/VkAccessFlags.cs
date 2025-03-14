using System;

namespace Vulkan;

[Flags]
public enum VkAccessFlags
{
	None = 0,
	IndirectCommandRead = 1,
	IndexRead = 2,
	VertexAttributeRead = 4,
	UniformRead = 8,
	InputAttachmentRead = 0x10,
	ShaderRead = 0x20,
	ShaderWrite = 0x40,
	ColorAttachmentRead = 0x80,
	ColorAttachmentWrite = 0x100,
	DepthStencilAttachmentRead = 0x200,
	DepthStencilAttachmentWrite = 0x400,
	TransferRead = 0x800,
	TransferWrite = 0x1000,
	HostRead = 0x2000,
	HostWrite = 0x4000,
	MemoryRead = 0x8000,
	MemoryWrite = 0x10000,
	CommandProcessReadNVX = 0x20000,
	CommandProcessWriteNVX = 0x40000,
	ColorAttachmentReadNoncoherentEXT = 0x80000
}
