using System;

namespace Vulkan;

public struct VkAllocationCallbacks
{
	public unsafe void* pUserData;

	public IntPtr pfnAllocation;

	public IntPtr pfnReallocation;

	public IntPtr pfnFree;

	public IntPtr pfnInternalAllocation;

	public IntPtr pfnInternalFree;
}
