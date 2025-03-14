using System;

namespace Vulkan;

public unsafe delegate void* PFN_vkAllocationFunction(void* pUserData, UIntPtr size, UIntPtr alignment, VkSystemAllocationScope allocationScope);
