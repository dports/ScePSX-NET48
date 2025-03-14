namespace Vulkan;

public enum VkPresentModeKHR
{
	ImmediateKHR = 0,
	MailboxKHR = 1,
	FifoKHR = 2,
	FifoRelaxedKHR = 3,
	SharedDemandRefreshKHR = 1000111000,
	SharedContinuousRefreshKHR = 1000111001
}
