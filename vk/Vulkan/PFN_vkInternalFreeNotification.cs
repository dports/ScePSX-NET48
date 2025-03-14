using System;

namespace Vulkan;

public unsafe delegate void PFN_vkInternalFreeNotification(void* pUserData, UIntPtr size, VkInternalAllocationType allocationType, VkSystemAllocationScope allocationScope);
