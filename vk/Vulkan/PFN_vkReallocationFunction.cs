using System;

namespace Vulkan;

public unsafe delegate void* PFN_vkReallocationFunction(void* pUserData, void* pOriginal, UIntPtr size, UIntPtr alignment, VkSystemAllocationScope allocationScope);
