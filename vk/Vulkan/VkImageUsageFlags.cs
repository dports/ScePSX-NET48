using System;

namespace Vulkan;

[Flags]
public enum VkImageUsageFlags
{
	None = 0,
	TransferSrc = 1,
	TransferDst = 2,
	Sampled = 4,
	Storage = 8,
	ColorAttachment = 0x10,
	DepthStencilAttachment = 0x20,
	TransientAttachment = 0x40,
	InputAttachment = 0x80
}
