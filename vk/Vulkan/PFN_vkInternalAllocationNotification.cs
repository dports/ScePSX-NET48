using System;

namespace Vulkan;

public unsafe delegate void PFN_vkInternalAllocationNotification(void* pUserData, UIntPtr size, VkInternalAllocationType allocationType, VkSystemAllocationScope allocationScope);
