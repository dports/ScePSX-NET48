namespace Vulkan;

public enum VkImageLayout
{
	Undefined = 0,
	General = 1,
	ColorAttachmentOptimal = 2,
	DepthStencilAttachmentOptimal = 3,
	DepthStencilReadOnlyOptimal = 4,
	ShaderReadOnlyOptimal = 5,
	TransferSrcOptimal = 6,
	TransferDstOptimal = 7,
	Preinitialized = 8,
	PresentSrcKHR = 1000001002,
	SharedPresentKHR = 1000111000,
	DepthReadOnlyStencilAttachmentOptimalKHR = 1000117000,
	DepthAttachmentStencilReadOnlyOptimalKHR = 1000117001
}
