using System;
using System.Runtime.InteropServices;
using Vulkan.Mir;
using Vulkan.Wayland;
using Vulkan.Win32;
using Vulkan.Xcb;
using Vulkan.Xlib;

namespace Vulkan;

public static class VulkanNative
{
	private static NativeLibrary s_nativeLib;

	public static readonly IntPtr NullHandle;

	private static IntPtr vkAcquireImageANDROID_ptr;

	private static IntPtr vkAcquireNextImage2KHX_ptr;

	private static IntPtr vkAcquireNextImageKHR_ptr;

	private static IntPtr vkAcquireXlibDisplayEXT_ptr;

	private static IntPtr vkAllocateCommandBuffers_ptr;

	private static IntPtr vkAllocateDescriptorSets_ptr;

	private static IntPtr vkAllocateMemory_ptr;

	private static IntPtr vkBeginCommandBuffer_ptr;

	private static IntPtr vkBindBufferMemory_ptr;

	private static IntPtr vkBindBufferMemory2KHR_ptr;

	private static IntPtr vkBindImageMemory_ptr;

	private static IntPtr vkBindImageMemory2KHR_ptr;

	private static IntPtr vkCmdBeginQuery_ptr;

	private static IntPtr vkCmdBeginRenderPass_ptr;

	private static IntPtr vkCmdBindDescriptorSets_ptr;

	private static IntPtr vkCmdBindIndexBuffer_ptr;

	private static IntPtr vkCmdBindPipeline_ptr;

	private static IntPtr vkCmdBindVertexBuffers_ptr;

	private static IntPtr vkCmdBlitImage_ptr;

	private static IntPtr vkCmdClearAttachments_ptr;

	private static IntPtr vkCmdClearColorImage_ptr;

	private static IntPtr vkCmdClearDepthStencilImage_ptr;

	private static IntPtr vkCmdCopyBuffer_ptr;

	private static IntPtr vkCmdCopyBufferToImage_ptr;

	private static IntPtr vkCmdCopyImage_ptr;

	private static IntPtr vkCmdCopyImageToBuffer_ptr;

	private static IntPtr vkCmdCopyQueryPoolResults_ptr;

	private static IntPtr vkCmdDebugMarkerBeginEXT_ptr;

	private static IntPtr vkCmdDebugMarkerEndEXT_ptr;

	private static IntPtr vkCmdDebugMarkerInsertEXT_ptr;

	private static IntPtr vkCmdDispatch_ptr;

	private static IntPtr vkCmdDispatchBaseKHX_ptr;

	private static IntPtr vkCmdDispatchIndirect_ptr;

	private static IntPtr vkCmdDraw_ptr;

	private static IntPtr vkCmdDrawIndexed_ptr;

	private static IntPtr vkCmdDrawIndexedIndirect_ptr;

	private static IntPtr vkCmdDrawIndexedIndirectCountAMD_ptr;

	private static IntPtr vkCmdDrawIndirect_ptr;

	private static IntPtr vkCmdDrawIndirectCountAMD_ptr;

	private static IntPtr vkCmdEndQuery_ptr;

	private static IntPtr vkCmdEndRenderPass_ptr;

	private static IntPtr vkCmdExecuteCommands_ptr;

	private static IntPtr vkCmdFillBuffer_ptr;

	private static IntPtr vkCmdNextSubpass_ptr;

	private static IntPtr vkCmdPipelineBarrier_ptr;

	private static IntPtr vkCmdProcessCommandsNVX_ptr;

	private static IntPtr vkCmdPushConstants_ptr;

	private static IntPtr vkCmdPushDescriptorSetKHR_ptr;

	private static IntPtr vkCmdPushDescriptorSetWithTemplateKHR_ptr;

	private static IntPtr vkCmdReserveSpaceForCommandsNVX_ptr;

	private static IntPtr vkCmdResetEvent_ptr;

	private static IntPtr vkCmdResetQueryPool_ptr;

	private static IntPtr vkCmdResolveImage_ptr;

	private static IntPtr vkCmdSetBlendConstants_ptr;

	private static IntPtr vkCmdSetDepthBias_ptr;

	private static IntPtr vkCmdSetDepthBounds_ptr;

	private static IntPtr vkCmdSetDeviceMaskKHX_ptr;

	private static IntPtr vkCmdSetDiscardRectangleEXT_ptr;

	private static IntPtr vkCmdSetEvent_ptr;

	private static IntPtr vkCmdSetLineWidth_ptr;

	private static IntPtr vkCmdSetSampleLocationsEXT_ptr;

	private static IntPtr vkCmdSetScissor_ptr;

	private static IntPtr vkCmdSetStencilCompareMask_ptr;

	private static IntPtr vkCmdSetStencilReference_ptr;

	private static IntPtr vkCmdSetStencilWriteMask_ptr;

	private static IntPtr vkCmdSetViewport_ptr;

	private static IntPtr vkCmdSetViewportWScalingNV_ptr;

	private static IntPtr vkCmdUpdateBuffer_ptr;

	private static IntPtr vkCmdWaitEvents_ptr;

	private static IntPtr vkCmdWriteTimestamp_ptr;

	private static IntPtr vkCreateAndroidSurfaceKHR_ptr;

	private static IntPtr vkCreateBuffer_ptr;

	private static IntPtr vkCreateBufferView_ptr;

	private static IntPtr vkCreateCommandPool_ptr;

	private static IntPtr vkCreateComputePipelines_ptr;

	private static IntPtr vkCreateDebugReportCallbackEXT_ptr;

	private static IntPtr vkCreateDescriptorPool_ptr;

	private static IntPtr vkCreateDescriptorSetLayout_ptr;

	private static IntPtr vkCreateDescriptorUpdateTemplateKHR_ptr;

	private static IntPtr vkCreateDevice_ptr;

	private static IntPtr vkCreateDisplayModeKHR_ptr;

	private static IntPtr vkCreateDisplayPlaneSurfaceKHR_ptr;

	private static IntPtr vkCreateEvent_ptr;

	private static IntPtr vkCreateFence_ptr;

	private static IntPtr vkCreateFramebuffer_ptr;

	private static IntPtr vkCreateGraphicsPipelines_ptr;

	private static IntPtr vkCreateImage_ptr;

	private static IntPtr vkCreateImageView_ptr;

	private static IntPtr vkCreateIndirectCommandsLayoutNVX_ptr;

	private static IntPtr vkCreateInstance_ptr;

	private static IntPtr vkCreateIOSSurfaceMVK_ptr;

	private static IntPtr vkCreateMacOSSurfaceMVK_ptr;

	private static IntPtr vkCreateMirSurfaceKHR_ptr;

	private static IntPtr vkCreateObjectTableNVX_ptr;

	private static IntPtr vkCreatePipelineCache_ptr;

	private static IntPtr vkCreatePipelineLayout_ptr;

	private static IntPtr vkCreateQueryPool_ptr;

	private static IntPtr vkCreateRenderPass_ptr;

	private static IntPtr vkCreateSampler_ptr;

	private static IntPtr vkCreateSamplerYcbcrConversionKHR_ptr;

	private static IntPtr vkCreateSemaphore_ptr;

	private static IntPtr vkCreateShaderModule_ptr;

	private static IntPtr vkCreateSharedSwapchainsKHR_ptr;

	private static IntPtr vkCreateSwapchainKHR_ptr;

	private static IntPtr vkCreateValidationCacheEXT_ptr;

	private static IntPtr vkCreateViSurfaceNN_ptr;

	private static IntPtr vkCreateWaylandSurfaceKHR_ptr;

	private static IntPtr vkCreateWin32SurfaceKHR_ptr;

	private static IntPtr vkCreateXcbSurfaceKHR_ptr;

	private static IntPtr vkCreateXlibSurfaceKHR_ptr;

	private static IntPtr vkDebugMarkerSetObjectNameEXT_ptr;

	private static IntPtr vkDebugMarkerSetObjectTagEXT_ptr;

	private static IntPtr vkDebugReportMessageEXT_ptr;

	private static IntPtr vkDestroyBuffer_ptr;

	private static IntPtr vkDestroyBufferView_ptr;

	private static IntPtr vkDestroyCommandPool_ptr;

	private static IntPtr vkDestroyDebugReportCallbackEXT_ptr;

	private static IntPtr vkDestroyDescriptorPool_ptr;

	private static IntPtr vkDestroyDescriptorSetLayout_ptr;

	private static IntPtr vkDestroyDescriptorUpdateTemplateKHR_ptr;

	private static IntPtr vkDestroyDevice_ptr;

	private static IntPtr vkDestroyEvent_ptr;

	private static IntPtr vkDestroyFence_ptr;

	private static IntPtr vkDestroyFramebuffer_ptr;

	private static IntPtr vkDestroyImage_ptr;

	private static IntPtr vkDestroyImageView_ptr;

	private static IntPtr vkDestroyIndirectCommandsLayoutNVX_ptr;

	private static IntPtr vkDestroyInstance_ptr;

	private static IntPtr vkDestroyObjectTableNVX_ptr;

	private static IntPtr vkDestroyPipeline_ptr;

	private static IntPtr vkDestroyPipelineCache_ptr;

	private static IntPtr vkDestroyPipelineLayout_ptr;

	private static IntPtr vkDestroyQueryPool_ptr;

	private static IntPtr vkDestroyRenderPass_ptr;

	private static IntPtr vkDestroySampler_ptr;

	private static IntPtr vkDestroySamplerYcbcrConversionKHR_ptr;

	private static IntPtr vkDestroySemaphore_ptr;

	private static IntPtr vkDestroyShaderModule_ptr;

	private static IntPtr vkDestroySurfaceKHR_ptr;

	private static IntPtr vkDestroySwapchainKHR_ptr;

	private static IntPtr vkDestroyValidationCacheEXT_ptr;

	private static IntPtr vkDeviceWaitIdle_ptr;

	private static IntPtr vkDisplayPowerControlEXT_ptr;

	private static IntPtr vkEndCommandBuffer_ptr;

	private static IntPtr vkEnumerateDeviceExtensionProperties_ptr;

	private static IntPtr vkEnumerateDeviceLayerProperties_ptr;

	private static IntPtr vkEnumerateInstanceExtensionProperties_ptr;

	private static IntPtr vkEnumerateInstanceLayerProperties_ptr;

	private static IntPtr vkEnumeratePhysicalDeviceGroupsKHX_ptr;

	private static IntPtr vkEnumeratePhysicalDevices_ptr;

	private static IntPtr vkFlushMappedMemoryRanges_ptr;

	private static IntPtr vkFreeCommandBuffers_ptr;

	private static IntPtr vkFreeDescriptorSets_ptr;

	private static IntPtr vkFreeMemory_ptr;

	private static IntPtr vkGetBufferMemoryRequirements_ptr;

	private static IntPtr vkGetBufferMemoryRequirements2KHR_ptr;

	private static IntPtr vkGetDeviceGroupPeerMemoryFeaturesKHX_ptr;

	private static IntPtr vkGetDeviceGroupPresentCapabilitiesKHX_ptr;

	private static IntPtr vkGetDeviceGroupSurfacePresentModesKHX_ptr;

	private static IntPtr vkGetDeviceMemoryCommitment_ptr;

	private static IntPtr vkGetDeviceProcAddr_ptr;

	private static IntPtr vkGetDeviceQueue_ptr;

	private static IntPtr vkGetDisplayModePropertiesKHR_ptr;

	private static IntPtr vkGetDisplayPlaneCapabilitiesKHR_ptr;

	private static IntPtr vkGetDisplayPlaneSupportedDisplaysKHR_ptr;

	private static IntPtr vkGetEventStatus_ptr;

	private static IntPtr vkGetFenceFdKHR_ptr;

	private static IntPtr vkGetFenceStatus_ptr;

	private static IntPtr vkGetFenceWin32HandleKHR_ptr;

	private static IntPtr vkGetImageMemoryRequirements_ptr;

	private static IntPtr vkGetImageMemoryRequirements2KHR_ptr;

	private static IntPtr vkGetImageSparseMemoryRequirements_ptr;

	private static IntPtr vkGetImageSparseMemoryRequirements2KHR_ptr;

	private static IntPtr vkGetImageSubresourceLayout_ptr;

	private static IntPtr vkGetInstanceProcAddr_ptr;

	private static IntPtr vkGetMemoryFdKHR_ptr;

	private static IntPtr vkGetMemoryFdPropertiesKHR_ptr;

	private static IntPtr vkGetMemoryHostPointerPropertiesEXT_ptr;

	private static IntPtr vkGetMemoryWin32HandleKHR_ptr;

	private static IntPtr vkGetMemoryWin32HandleNV_ptr;

	private static IntPtr vkGetMemoryWin32HandlePropertiesKHR_ptr;

	private static IntPtr vkGetPastPresentationTimingGOOGLE_ptr;

	private static IntPtr vkGetPhysicalDeviceDisplayPlanePropertiesKHR_ptr;

	private static IntPtr vkGetPhysicalDeviceDisplayPropertiesKHR_ptr;

	private static IntPtr vkGetPhysicalDeviceExternalBufferPropertiesKHR_ptr;

	private static IntPtr vkGetPhysicalDeviceExternalFencePropertiesKHR_ptr;

	private static IntPtr vkGetPhysicalDeviceExternalImageFormatPropertiesNV_ptr;

	private static IntPtr vkGetPhysicalDeviceExternalSemaphorePropertiesKHR_ptr;

	private static IntPtr vkGetPhysicalDeviceFeatures_ptr;

	private static IntPtr vkGetPhysicalDeviceFeatures2KHR_ptr;

	private static IntPtr vkGetPhysicalDeviceFormatProperties_ptr;

	private static IntPtr vkGetPhysicalDeviceFormatProperties2KHR_ptr;

	private static IntPtr vkGetPhysicalDeviceGeneratedCommandsPropertiesNVX_ptr;

	private static IntPtr vkGetPhysicalDeviceImageFormatProperties_ptr;

	private static IntPtr vkGetPhysicalDeviceImageFormatProperties2KHR_ptr;

	private static IntPtr vkGetPhysicalDeviceMemoryProperties_ptr;

	private static IntPtr vkGetPhysicalDeviceMemoryProperties2KHR_ptr;

	private static IntPtr vkGetPhysicalDeviceMirPresentationSupportKHR_ptr;

	private static IntPtr vkGetPhysicalDeviceMultisamplePropertiesEXT_ptr;

	private static IntPtr vkGetPhysicalDevicePresentRectanglesKHX_ptr;

	private static IntPtr vkGetPhysicalDeviceProperties_ptr;

	private static IntPtr vkGetPhysicalDeviceProperties2KHR_ptr;

	private static IntPtr vkGetPhysicalDeviceQueueFamilyProperties_ptr;

	private static IntPtr vkGetPhysicalDeviceQueueFamilyProperties2KHR_ptr;

	private static IntPtr vkGetPhysicalDeviceSparseImageFormatProperties_ptr;

	private static IntPtr vkGetPhysicalDeviceSparseImageFormatProperties2KHR_ptr;

	private static IntPtr vkGetPhysicalDeviceSurfaceCapabilities2EXT_ptr;

	private static IntPtr vkGetPhysicalDeviceSurfaceCapabilities2KHR_ptr;

	private static IntPtr vkGetPhysicalDeviceSurfaceCapabilitiesKHR_ptr;

	private static IntPtr vkGetPhysicalDeviceSurfaceFormats2KHR_ptr;

	private static IntPtr vkGetPhysicalDeviceSurfaceFormatsKHR_ptr;

	private static IntPtr vkGetPhysicalDeviceSurfacePresentModesKHR_ptr;

	private static IntPtr vkGetPhysicalDeviceSurfaceSupportKHR_ptr;

	private static IntPtr vkGetPhysicalDeviceWaylandPresentationSupportKHR_ptr;

	private static IntPtr vkGetPhysicalDeviceWin32PresentationSupportKHR_ptr;

	private static IntPtr vkGetPhysicalDeviceXcbPresentationSupportKHR_ptr;

	private static IntPtr vkGetPhysicalDeviceXlibPresentationSupportKHR_ptr;

	private static IntPtr vkGetPipelineCacheData_ptr;

	private static IntPtr vkGetQueryPoolResults_ptr;

	private static IntPtr vkGetRandROutputDisplayEXT_ptr;

	private static IntPtr vkGetRefreshCycleDurationGOOGLE_ptr;

	private static IntPtr vkGetRenderAreaGranularity_ptr;

	private static IntPtr vkGetSemaphoreFdKHR_ptr;

	private static IntPtr vkGetSemaphoreWin32HandleKHR_ptr;

	private static IntPtr vkGetShaderInfoAMD_ptr;

	private static IntPtr vkGetSwapchainCounterEXT_ptr;

	private static IntPtr vkGetSwapchainGrallocUsageANDROID_ptr;

	private static IntPtr vkGetSwapchainImagesKHR_ptr;

	private static IntPtr vkGetSwapchainStatusKHR_ptr;

	private static IntPtr vkGetValidationCacheDataEXT_ptr;

	private static IntPtr vkImportFenceFdKHR_ptr;

	private static IntPtr vkImportFenceWin32HandleKHR_ptr;

	private static IntPtr vkImportSemaphoreFdKHR_ptr;

	private static IntPtr vkImportSemaphoreWin32HandleKHR_ptr;

	private static IntPtr vkInvalidateMappedMemoryRanges_ptr;

	private static IntPtr vkMapMemory_ptr;

	private static IntPtr vkMergePipelineCaches_ptr;

	private static IntPtr vkMergeValidationCachesEXT_ptr;

	private static IntPtr vkQueueBindSparse_ptr;

	private static IntPtr vkQueuePresentKHR_ptr;

	private static IntPtr vkQueueSignalReleaseImageANDROID_ptr;

	private static IntPtr vkQueueSubmit_ptr;

	private static IntPtr vkQueueWaitIdle_ptr;

	private static IntPtr vkRegisterDeviceEventEXT_ptr;

	private static IntPtr vkRegisterDisplayEventEXT_ptr;

	private static IntPtr vkRegisterObjectsNVX_ptr;

	private static IntPtr vkReleaseDisplayEXT_ptr;

	private static IntPtr vkResetCommandBuffer_ptr;

	private static IntPtr vkResetCommandPool_ptr;

	private static IntPtr vkResetDescriptorPool_ptr;

	private static IntPtr vkResetEvent_ptr;

	private static IntPtr vkResetFences_ptr;

	private static IntPtr vkSetEvent_ptr;

	private static IntPtr vkSetHdrMetadataEXT_ptr;

	private static IntPtr vkTrimCommandPoolKHR_ptr;

	private static IntPtr vkUnmapMemory_ptr;

	private static IntPtr vkUnregisterObjectsNVX_ptr;

	private static IntPtr vkUpdateDescriptorSets_ptr;

	private static IntPtr vkUpdateDescriptorSetWithTemplateKHR_ptr;

	private static IntPtr vkWaitForFences_ptr;

	public const uint MaxPhysicalDeviceNameSize = 256u;

	public const uint UuidSize = 16u;

	public const uint LuidSizeKHR = 8u;

	public const uint MaxExtensionNameSize = 256u;

	public const uint MaxDescriptionSize = 256u;

	public const uint MaxMemoryTypes = 32u;

	public const uint MaxMemoryHeaps = 16u;

	public const float LodClampNone = 1000f;

	public const uint RemainingMipLevels = uint.MaxValue;

	public const uint RemainingArrayLayers = uint.MaxValue;

	public const ulong WholeSize = ulong.MaxValue;

	public const uint AttachmentUnused = uint.MaxValue;

	public const uint True = 1u;

	public const uint False = 0u;

	public const uint QueueFamilyIgnored = uint.MaxValue;

	public const uint QueueFamilyExternalKHR = 4294967294u;

	public const uint QueueFamilyForeignEXT = 4294967293u;

	public const uint SubpassExternal = uint.MaxValue;

	public const uint MaxDeviceGroupSizeKHX = 32u;

	static VulkanNative()
	{
		NullHandle = IntPtr.Zero;
		s_nativeLib = LoadNativeLibrary();
		LoadFunctionPointers();
	}

	private static NativeLibrary LoadNativeLibrary()
	{
		return NativeLibrary.Load(GetVulkanName());
	}

	private static string GetVulkanName()
	{
		if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
		{
			return "vulkan-1.dll";
		}
		if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
		{
			if (RuntimeInformation.OSDescription.Contains("Unix"))
			{
				return "libvulkan.so";
			}
			return "libvulkan.so.1";
		}
		/*if (OperatingSystem.IsAndroid())
		{
			return "libvulkan.so";
		}*/
		if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
		{
			return "libvulkan.dylib";
		}
		throw new PlatformNotSupportedException();
	}

	private static Exception CreateMissingFunctionException()
	{
		return new InvalidOperationException("The function does not exist or could not be loaded.");
	}

	public unsafe static VkResult vkAcquireImageANDROID(VkDevice device, VkImage image, int nativeFenceFd, VkSemaphore semaphore, VkFence fence)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkImage, int, VkSemaphore, VkFence, VkResult>)vkAcquireImageANDROID_ptr)(device, image, nativeFenceFd, semaphore, fence);
	}

	public unsafe static VkResult vkAcquireNextImage2KHX(VkDevice device, VkAcquireNextImageInfoKHX* pAcquireInfo, uint* pImageIndex)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkAcquireNextImageInfoKHX*, uint*, VkResult>)vkAcquireNextImage2KHX_ptr)(device, pAcquireInfo, pImageIndex);
	}

	public unsafe static VkResult vkAcquireNextImage2KHX(VkDevice device, VkAcquireNextImageInfoKHX* pAcquireInfo, ref uint pImageIndex)
	{
		fixed (uint* ptr = &pImageIndex)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkAcquireNextImageInfoKHX*, uint*, VkResult>)vkAcquireNextImage2KHX_ptr)(device, pAcquireInfo, ptr);
		}
	}

	public unsafe static VkResult vkAcquireNextImage2KHX(VkDevice device, VkAcquireNextImageInfoKHX* pAcquireInfo, IntPtr pImageIndex)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkAcquireNextImageInfoKHX*, IntPtr, VkResult>)vkAcquireNextImage2KHX_ptr)(device, pAcquireInfo, pImageIndex);
	}

	public unsafe static VkResult vkAcquireNextImage2KHX(VkDevice device, ref VkAcquireNextImageInfoKHX pAcquireInfo, uint* pImageIndex)
	{
		fixed (VkAcquireNextImageInfoKHX* ptr = &pAcquireInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkAcquireNextImageInfoKHX*, uint*, VkResult>)vkAcquireNextImage2KHX_ptr)(device, ptr, pImageIndex);
		}
	}

	public unsafe static VkResult vkAcquireNextImage2KHX(VkDevice device, ref VkAcquireNextImageInfoKHX pAcquireInfo, ref uint pImageIndex)
	{
		fixed (VkAcquireNextImageInfoKHX* ptr = &pAcquireInfo)
		{
			fixed (uint* ptr2 = &pImageIndex)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkAcquireNextImageInfoKHX*, uint*, VkResult>)vkAcquireNextImage2KHX_ptr)(device, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkAcquireNextImage2KHX(VkDevice device, ref VkAcquireNextImageInfoKHX pAcquireInfo, IntPtr pImageIndex)
	{
		fixed (VkAcquireNextImageInfoKHX* ptr = &pAcquireInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkAcquireNextImageInfoKHX*, IntPtr, VkResult>)vkAcquireNextImage2KHX_ptr)(device, ptr, pImageIndex);
		}
	}

	public unsafe static VkResult vkAcquireNextImage2KHX(VkDevice device, IntPtr pAcquireInfo, uint* pImageIndex)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, uint*, VkResult>)vkAcquireNextImage2KHX_ptr)(device, pAcquireInfo, pImageIndex);
	}

	public unsafe static VkResult vkAcquireNextImage2KHX(VkDevice device, IntPtr pAcquireInfo, ref uint pImageIndex)
	{
		fixed (uint* ptr = &pImageIndex)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, uint*, VkResult>)vkAcquireNextImage2KHX_ptr)(device, pAcquireInfo, ptr);
		}
	}

	public unsafe static VkResult vkAcquireNextImage2KHX(VkDevice device, IntPtr pAcquireInfo, IntPtr pImageIndex)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkResult>)vkAcquireNextImage2KHX_ptr)(device, pAcquireInfo, pImageIndex);
	}

	public unsafe static VkResult vkAcquireNextImageKHR(VkDevice device, VkSwapchainKHR swapchain, ulong timeout, VkSemaphore semaphore, VkFence fence, uint* pImageIndex)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkSwapchainKHR, ulong, VkSemaphore, VkFence, uint*, VkResult>)vkAcquireNextImageKHR_ptr)(device, swapchain, timeout, semaphore, fence, pImageIndex);
	}

	public unsafe static VkResult vkAcquireNextImageKHR(VkDevice device, VkSwapchainKHR swapchain, ulong timeout, VkSemaphore semaphore, VkFence fence, ref uint pImageIndex)
	{
		fixed (uint* ptr = &pImageIndex)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkSwapchainKHR, ulong, VkSemaphore, VkFence, uint*, VkResult>)vkAcquireNextImageKHR_ptr)(device, swapchain, timeout, semaphore, fence, ptr);
		}
	}

	public unsafe static VkResult vkAcquireNextImageKHR(VkDevice device, VkSwapchainKHR swapchain, ulong timeout, VkSemaphore semaphore, VkFence fence, IntPtr pImageIndex)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkSwapchainKHR, ulong, VkSemaphore, VkFence, IntPtr, VkResult>)vkAcquireNextImageKHR_ptr)(device, swapchain, timeout, semaphore, fence, pImageIndex);
	}

	public unsafe static VkResult vkAcquireXlibDisplayEXT(VkPhysicalDevice physicalDevice, Display* dpy, VkDisplayKHR display)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, Display*, VkDisplayKHR, VkResult>)vkAcquireXlibDisplayEXT_ptr)(physicalDevice, dpy, display);
	}

	public unsafe static VkResult vkAcquireXlibDisplayEXT(VkPhysicalDevice physicalDevice, ref Display dpy, VkDisplayKHR display)
	{
		fixed (Display* ptr = &dpy)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, Display*, VkDisplayKHR, VkResult>)vkAcquireXlibDisplayEXT_ptr)(physicalDevice, ptr, display);
		}
	}

	public unsafe static VkResult vkAcquireXlibDisplayEXT(VkPhysicalDevice physicalDevice, IntPtr dpy, VkDisplayKHR display)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, VkDisplayKHR, VkResult>)vkAcquireXlibDisplayEXT_ptr)(physicalDevice, dpy, display);
	}

	public unsafe static VkResult vkAllocateCommandBuffers(VkDevice device, VkCommandBufferAllocateInfo* pAllocateInfo, VkCommandBuffer* pCommandBuffers)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkCommandBufferAllocateInfo*, VkCommandBuffer*, VkResult>)vkAllocateCommandBuffers_ptr)(device, pAllocateInfo, pCommandBuffers);
	}

	public unsafe static VkResult vkAllocateCommandBuffers(VkDevice device, VkCommandBufferAllocateInfo* pAllocateInfo, out VkCommandBuffer pCommandBuffers)
	{
		fixed (VkCommandBuffer* ptr = &pCommandBuffers)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkCommandBufferAllocateInfo*, VkCommandBuffer*, VkResult>)vkAllocateCommandBuffers_ptr)(device, pAllocateInfo, ptr);
		}
	}

	public unsafe static VkResult vkAllocateCommandBuffers(VkDevice device, ref VkCommandBufferAllocateInfo pAllocateInfo, VkCommandBuffer* pCommandBuffers)
	{
		fixed (VkCommandBufferAllocateInfo* ptr = &pAllocateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkCommandBufferAllocateInfo*, VkCommandBuffer*, VkResult>)vkAllocateCommandBuffers_ptr)(device, ptr, pCommandBuffers);
		}
	}

	public unsafe static VkResult vkAllocateCommandBuffers(VkDevice device, ref VkCommandBufferAllocateInfo pAllocateInfo, out VkCommandBuffer pCommandBuffers)
	{
		fixed (VkCommandBufferAllocateInfo* ptr = &pAllocateInfo)
		{
			fixed (VkCommandBuffer* ptr2 = &pCommandBuffers)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkCommandBufferAllocateInfo*, VkCommandBuffer*, VkResult>)vkAllocateCommandBuffers_ptr)(device, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkAllocateCommandBuffers(VkDevice device, IntPtr pAllocateInfo, VkCommandBuffer* pCommandBuffers)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkCommandBuffer*, VkResult>)vkAllocateCommandBuffers_ptr)(device, pAllocateInfo, pCommandBuffers);
	}

	public unsafe static VkResult vkAllocateCommandBuffers(VkDevice device, IntPtr pAllocateInfo, out VkCommandBuffer pCommandBuffers)
	{
		fixed (VkCommandBuffer* ptr = &pCommandBuffers)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkCommandBuffer*, VkResult>)vkAllocateCommandBuffers_ptr)(device, pAllocateInfo, ptr);
		}
	}

	public unsafe static VkResult vkAllocateDescriptorSets(VkDevice device, VkDescriptorSetAllocateInfo* pAllocateInfo, VkDescriptorSet* pDescriptorSets)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorSetAllocateInfo*, VkDescriptorSet*, VkResult>)vkAllocateDescriptorSets_ptr)(device, pAllocateInfo, pDescriptorSets);
	}

	public unsafe static VkResult vkAllocateDescriptorSets(VkDevice device, VkDescriptorSetAllocateInfo* pAllocateInfo, out VkDescriptorSet pDescriptorSets)
	{
		fixed (VkDescriptorSet* ptr = &pDescriptorSets)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorSetAllocateInfo*, VkDescriptorSet*, VkResult>)vkAllocateDescriptorSets_ptr)(device, pAllocateInfo, ptr);
		}
	}

	public unsafe static VkResult vkAllocateDescriptorSets(VkDevice device, ref VkDescriptorSetAllocateInfo pAllocateInfo, VkDescriptorSet* pDescriptorSets)
	{
		fixed (VkDescriptorSetAllocateInfo* ptr = &pAllocateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorSetAllocateInfo*, VkDescriptorSet*, VkResult>)vkAllocateDescriptorSets_ptr)(device, ptr, pDescriptorSets);
		}
	}

	public unsafe static VkResult vkAllocateDescriptorSets(VkDevice device, ref VkDescriptorSetAllocateInfo pAllocateInfo, out VkDescriptorSet pDescriptorSets)
	{
		fixed (VkDescriptorSetAllocateInfo* ptr = &pAllocateInfo)
		{
			fixed (VkDescriptorSet* ptr2 = &pDescriptorSets)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorSetAllocateInfo*, VkDescriptorSet*, VkResult>)vkAllocateDescriptorSets_ptr)(device, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkAllocateDescriptorSets(VkDevice device, IntPtr pAllocateInfo, VkDescriptorSet* pDescriptorSets)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkDescriptorSet*, VkResult>)vkAllocateDescriptorSets_ptr)(device, pAllocateInfo, pDescriptorSets);
	}

	public unsafe static VkResult vkAllocateDescriptorSets(VkDevice device, IntPtr pAllocateInfo, out VkDescriptorSet pDescriptorSets)
	{
		fixed (VkDescriptorSet* ptr = &pDescriptorSets)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkDescriptorSet*, VkResult>)vkAllocateDescriptorSets_ptr)(device, pAllocateInfo, ptr);
		}
	}

	public unsafe static VkResult vkAllocateMemory(VkDevice device, VkMemoryAllocateInfo* pAllocateInfo, VkAllocationCallbacks* pAllocator, VkDeviceMemory* pMemory)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkMemoryAllocateInfo*, VkAllocationCallbacks*, VkDeviceMemory*, VkResult>)vkAllocateMemory_ptr)(device, pAllocateInfo, pAllocator, pMemory);
	}

	public unsafe static VkResult vkAllocateMemory(VkDevice device, VkMemoryAllocateInfo* pAllocateInfo, VkAllocationCallbacks* pAllocator, out VkDeviceMemory pMemory)
	{
		fixed (VkDeviceMemory* ptr = &pMemory)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkMemoryAllocateInfo*, VkAllocationCallbacks*, VkDeviceMemory*, VkResult>)vkAllocateMemory_ptr)(device, pAllocateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkAllocateMemory(VkDevice device, VkMemoryAllocateInfo* pAllocateInfo, ref VkAllocationCallbacks pAllocator, VkDeviceMemory* pMemory)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkMemoryAllocateInfo*, VkAllocationCallbacks*, VkDeviceMemory*, VkResult>)vkAllocateMemory_ptr)(device, pAllocateInfo, ptr, pMemory);
		}
	}

	public unsafe static VkResult vkAllocateMemory(VkDevice device, VkMemoryAllocateInfo* pAllocateInfo, ref VkAllocationCallbacks pAllocator, out VkDeviceMemory pMemory)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkDeviceMemory* ptr2 = &pMemory)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkMemoryAllocateInfo*, VkAllocationCallbacks*, VkDeviceMemory*, VkResult>)vkAllocateMemory_ptr)(device, pAllocateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkAllocateMemory(VkDevice device, VkMemoryAllocateInfo* pAllocateInfo, IntPtr pAllocator, VkDeviceMemory* pMemory)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkMemoryAllocateInfo*, IntPtr, VkDeviceMemory*, VkResult>)vkAllocateMemory_ptr)(device, pAllocateInfo, pAllocator, pMemory);
	}

	public unsafe static VkResult vkAllocateMemory(VkDevice device, VkMemoryAllocateInfo* pAllocateInfo, IntPtr pAllocator, out VkDeviceMemory pMemory)
	{
		fixed (VkDeviceMemory* ptr = &pMemory)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkMemoryAllocateInfo*, IntPtr, VkDeviceMemory*, VkResult>)vkAllocateMemory_ptr)(device, pAllocateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkAllocateMemory(VkDevice device, ref VkMemoryAllocateInfo pAllocateInfo, VkAllocationCallbacks* pAllocator, VkDeviceMemory* pMemory)
	{
		fixed (VkMemoryAllocateInfo* ptr = &pAllocateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkMemoryAllocateInfo*, VkAllocationCallbacks*, VkDeviceMemory*, VkResult>)vkAllocateMemory_ptr)(device, ptr, pAllocator, pMemory);
		}
	}

	public unsafe static VkResult vkAllocateMemory(VkDevice device, ref VkMemoryAllocateInfo pAllocateInfo, VkAllocationCallbacks* pAllocator, out VkDeviceMemory pMemory)
	{
		fixed (VkMemoryAllocateInfo* ptr = &pAllocateInfo)
		{
			fixed (VkDeviceMemory* ptr2 = &pMemory)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkMemoryAllocateInfo*, VkAllocationCallbacks*, VkDeviceMemory*, VkResult>)vkAllocateMemory_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkAllocateMemory(VkDevice device, ref VkMemoryAllocateInfo pAllocateInfo, ref VkAllocationCallbacks pAllocator, VkDeviceMemory* pMemory)
	{
		fixed (VkMemoryAllocateInfo* ptr = &pAllocateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkMemoryAllocateInfo*, VkAllocationCallbacks*, VkDeviceMemory*, VkResult>)vkAllocateMemory_ptr)(device, ptr, ptr2, pMemory);
			}
		}
	}

	public unsafe static VkResult vkAllocateMemory(VkDevice device, ref VkMemoryAllocateInfo pAllocateInfo, ref VkAllocationCallbacks pAllocator, out VkDeviceMemory pMemory)
	{
		fixed (VkMemoryAllocateInfo* ptr = &pAllocateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkDeviceMemory* ptr3 = &pMemory)
				{
					return ((delegate* unmanaged[Stdcall]<VkDevice, VkMemoryAllocateInfo*, VkAllocationCallbacks*, VkDeviceMemory*, VkResult>)vkAllocateMemory_ptr)(device, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkAllocateMemory(VkDevice device, ref VkMemoryAllocateInfo pAllocateInfo, IntPtr pAllocator, VkDeviceMemory* pMemory)
	{
		fixed (VkMemoryAllocateInfo* ptr = &pAllocateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkMemoryAllocateInfo*, IntPtr, VkDeviceMemory*, VkResult>)vkAllocateMemory_ptr)(device, ptr, pAllocator, pMemory);
		}
	}

	public unsafe static VkResult vkAllocateMemory(VkDevice device, ref VkMemoryAllocateInfo pAllocateInfo, IntPtr pAllocator, out VkDeviceMemory pMemory)
	{
		fixed (VkMemoryAllocateInfo* ptr = &pAllocateInfo)
		{
			fixed (VkDeviceMemory* ptr2 = &pMemory)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkMemoryAllocateInfo*, IntPtr, VkDeviceMemory*, VkResult>)vkAllocateMemory_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkAllocateMemory(VkDevice device, IntPtr pAllocateInfo, VkAllocationCallbacks* pAllocator, VkDeviceMemory* pMemory)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkDeviceMemory*, VkResult>)vkAllocateMemory_ptr)(device, pAllocateInfo, pAllocator, pMemory);
	}

	public unsafe static VkResult vkAllocateMemory(VkDevice device, IntPtr pAllocateInfo, VkAllocationCallbacks* pAllocator, out VkDeviceMemory pMemory)
	{
		fixed (VkDeviceMemory* ptr = &pMemory)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkDeviceMemory*, VkResult>)vkAllocateMemory_ptr)(device, pAllocateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkAllocateMemory(VkDevice device, IntPtr pAllocateInfo, ref VkAllocationCallbacks pAllocator, VkDeviceMemory* pMemory)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkDeviceMemory*, VkResult>)vkAllocateMemory_ptr)(device, pAllocateInfo, ptr, pMemory);
		}
	}

	public unsafe static VkResult vkAllocateMemory(VkDevice device, IntPtr pAllocateInfo, ref VkAllocationCallbacks pAllocator, out VkDeviceMemory pMemory)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkDeviceMemory* ptr2 = &pMemory)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkDeviceMemory*, VkResult>)vkAllocateMemory_ptr)(device, pAllocateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkAllocateMemory(VkDevice device, IntPtr pAllocateInfo, IntPtr pAllocator, VkDeviceMemory* pMemory)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkDeviceMemory*, VkResult>)vkAllocateMemory_ptr)(device, pAllocateInfo, pAllocator, pMemory);
	}

	public unsafe static VkResult vkAllocateMemory(VkDevice device, IntPtr pAllocateInfo, IntPtr pAllocator, out VkDeviceMemory pMemory)
	{
		fixed (VkDeviceMemory* ptr = &pMemory)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkDeviceMemory*, VkResult>)vkAllocateMemory_ptr)(device, pAllocateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkBeginCommandBuffer(VkCommandBuffer commandBuffer, VkCommandBufferBeginInfo* pBeginInfo)
	{
		return ((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkCommandBufferBeginInfo*, VkResult>)vkBeginCommandBuffer_ptr)(commandBuffer, pBeginInfo);
	}

	public unsafe static VkResult vkBeginCommandBuffer(VkCommandBuffer commandBuffer, ref VkCommandBufferBeginInfo pBeginInfo)
	{
		fixed (VkCommandBufferBeginInfo* ptr = &pBeginInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkCommandBufferBeginInfo*, VkResult>)vkBeginCommandBuffer_ptr)(commandBuffer, ptr);
		}
	}

	public unsafe static VkResult vkBeginCommandBuffer(VkCommandBuffer commandBuffer, IntPtr pBeginInfo)
	{
		return ((delegate* unmanaged[Stdcall]<VkCommandBuffer, IntPtr, VkResult>)vkBeginCommandBuffer_ptr)(commandBuffer, pBeginInfo);
	}

	public unsafe static VkResult vkBindBufferMemory(VkDevice device, VkBuffer buffer, VkDeviceMemory memory, ulong memoryOffset)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkBuffer, VkDeviceMemory, ulong, VkResult>)vkBindBufferMemory_ptr)(device, buffer, memory, memoryOffset);
	}

	public unsafe static VkResult vkBindBufferMemory2KHR(VkDevice device, uint bindInfoCount, VkBindBufferMemoryInfoKHR* pBindInfos)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, uint, VkBindBufferMemoryInfoKHR*, VkResult>)vkBindBufferMemory2KHR_ptr)(device, bindInfoCount, pBindInfos);
	}

	public unsafe static VkResult vkBindBufferMemory2KHR(VkDevice device, uint bindInfoCount, ref VkBindBufferMemoryInfoKHR pBindInfos)
	{
		fixed (VkBindBufferMemoryInfoKHR* ptr = &pBindInfos)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, uint, VkBindBufferMemoryInfoKHR*, VkResult>)vkBindBufferMemory2KHR_ptr)(device, bindInfoCount, ptr);
		}
	}

	public unsafe static VkResult vkBindBufferMemory2KHR(VkDevice device, uint bindInfoCount, IntPtr pBindInfos)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, uint, IntPtr, VkResult>)vkBindBufferMemory2KHR_ptr)(device, bindInfoCount, pBindInfos);
	}

	public unsafe static VkResult vkBindBufferMemory2KHR(VkDevice device, uint bindInfoCount, VkBindBufferMemoryInfoKHR[] pBindInfos)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, uint, VkBindBufferMemoryInfoKHR[], VkResult>)vkBindBufferMemory2KHR_ptr)(device, bindInfoCount, pBindInfos);
	}

	public unsafe static VkResult vkBindImageMemory(VkDevice device, VkImage image, VkDeviceMemory memory, ulong memoryOffset)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkImage, VkDeviceMemory, ulong, VkResult>)vkBindImageMemory_ptr)(device, image, memory, memoryOffset);
	}

	public unsafe static VkResult vkBindImageMemory2KHR(VkDevice device, uint bindInfoCount, VkBindImageMemoryInfoKHR* pBindInfos)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, uint, VkBindImageMemoryInfoKHR*, VkResult>)vkBindImageMemory2KHR_ptr)(device, bindInfoCount, pBindInfos);
	}

	public unsafe static VkResult vkBindImageMemory2KHR(VkDevice device, uint bindInfoCount, ref VkBindImageMemoryInfoKHR pBindInfos)
	{
		fixed (VkBindImageMemoryInfoKHR* ptr = &pBindInfos)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, uint, VkBindImageMemoryInfoKHR*, VkResult>)vkBindImageMemory2KHR_ptr)(device, bindInfoCount, ptr);
		}
	}

	public unsafe static VkResult vkBindImageMemory2KHR(VkDevice device, uint bindInfoCount, IntPtr pBindInfos)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, uint, IntPtr, VkResult>)vkBindImageMemory2KHR_ptr)(device, bindInfoCount, pBindInfos);
	}

	public unsafe static VkResult vkBindImageMemory2KHR(VkDevice device, uint bindInfoCount, VkBindImageMemoryInfoKHR[] pBindInfos)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, uint, VkBindImageMemoryInfoKHR[], VkResult>)vkBindImageMemory2KHR_ptr)(device, bindInfoCount, pBindInfos);
	}

	public unsafe static void vkCmdBeginQuery(VkCommandBuffer commandBuffer, VkQueryPool queryPool, uint query, VkQueryControlFlags flags)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkQueryPool, uint, VkQueryControlFlags, void>)vkCmdBeginQuery_ptr)(commandBuffer, queryPool, query, flags);
	}

	public unsafe static void vkCmdBeginRenderPass(VkCommandBuffer commandBuffer, VkRenderPassBeginInfo* pRenderPassBegin, VkSubpassContents contents)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkRenderPassBeginInfo*, VkSubpassContents, void>)vkCmdBeginRenderPass_ptr)(commandBuffer, pRenderPassBegin, contents);
	}

	public unsafe static void vkCmdBeginRenderPass(VkCommandBuffer commandBuffer, ref VkRenderPassBeginInfo pRenderPassBegin, VkSubpassContents contents)
	{
		fixed (VkRenderPassBeginInfo* ptr = &pRenderPassBegin)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkRenderPassBeginInfo*, VkSubpassContents, void>)vkCmdBeginRenderPass_ptr)(commandBuffer, ptr, contents);
		}
	}

	public unsafe static void vkCmdBeginRenderPass(VkCommandBuffer commandBuffer, IntPtr pRenderPassBegin, VkSubpassContents contents)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, IntPtr, VkSubpassContents, void>)vkCmdBeginRenderPass_ptr)(commandBuffer, pRenderPassBegin, contents);
	}

	public unsafe static void vkCmdBindDescriptorSets(VkCommandBuffer commandBuffer, VkPipelineBindPoint pipelineBindPoint, VkPipelineLayout layout, uint firstSet, uint descriptorSetCount, VkDescriptorSet* pDescriptorSets, uint dynamicOffsetCount, uint* pDynamicOffsets)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineBindPoint, VkPipelineLayout, uint, uint, VkDescriptorSet*, uint, uint*, void>)vkCmdBindDescriptorSets_ptr)(commandBuffer, pipelineBindPoint, layout, firstSet, descriptorSetCount, pDescriptorSets, dynamicOffsetCount, pDynamicOffsets);
	}

	public unsafe static void vkCmdBindDescriptorSets(VkCommandBuffer commandBuffer, VkPipelineBindPoint pipelineBindPoint, VkPipelineLayout layout, uint firstSet, uint descriptorSetCount, VkDescriptorSet* pDescriptorSets, uint dynamicOffsetCount, ref uint pDynamicOffsets)
	{
		fixed (uint* ptr = &pDynamicOffsets)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineBindPoint, VkPipelineLayout, uint, uint, VkDescriptorSet*, uint, uint*, void>)vkCmdBindDescriptorSets_ptr)(commandBuffer, pipelineBindPoint, layout, firstSet, descriptorSetCount, pDescriptorSets, dynamicOffsetCount, ptr);
		}
	}

	public unsafe static void vkCmdBindDescriptorSets(VkCommandBuffer commandBuffer, VkPipelineBindPoint pipelineBindPoint, VkPipelineLayout layout, uint firstSet, uint descriptorSetCount, VkDescriptorSet* pDescriptorSets, uint dynamicOffsetCount, IntPtr pDynamicOffsets)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineBindPoint, VkPipelineLayout, uint, uint, VkDescriptorSet*, uint, IntPtr, void>)vkCmdBindDescriptorSets_ptr)(commandBuffer, pipelineBindPoint, layout, firstSet, descriptorSetCount, pDescriptorSets, dynamicOffsetCount, pDynamicOffsets);
	}

	public unsafe static void vkCmdBindDescriptorSets(VkCommandBuffer commandBuffer, VkPipelineBindPoint pipelineBindPoint, VkPipelineLayout layout, uint firstSet, uint descriptorSetCount, ref VkDescriptorSet pDescriptorSets, uint dynamicOffsetCount, uint* pDynamicOffsets)
	{
		fixed (VkDescriptorSet* ptr = &pDescriptorSets)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineBindPoint, VkPipelineLayout, uint, uint, VkDescriptorSet*, uint, uint*, void>)vkCmdBindDescriptorSets_ptr)(commandBuffer, pipelineBindPoint, layout, firstSet, descriptorSetCount, ptr, dynamicOffsetCount, pDynamicOffsets);
		}
	}

	public unsafe static void vkCmdBindDescriptorSets(VkCommandBuffer commandBuffer, VkPipelineBindPoint pipelineBindPoint, VkPipelineLayout layout, uint firstSet, uint descriptorSetCount, ref VkDescriptorSet pDescriptorSets, uint dynamicOffsetCount, ref uint pDynamicOffsets)
	{
		fixed (VkDescriptorSet* ptr = &pDescriptorSets)
		{
			fixed (uint* ptr2 = &pDynamicOffsets)
			{
				((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineBindPoint, VkPipelineLayout, uint, uint, VkDescriptorSet*, uint, uint*, void>)vkCmdBindDescriptorSets_ptr)(commandBuffer, pipelineBindPoint, layout, firstSet, descriptorSetCount, ptr, dynamicOffsetCount, ptr2);
			}
		}
	}

	public unsafe static void vkCmdBindDescriptorSets(VkCommandBuffer commandBuffer, VkPipelineBindPoint pipelineBindPoint, VkPipelineLayout layout, uint firstSet, uint descriptorSetCount, ref VkDescriptorSet pDescriptorSets, uint dynamicOffsetCount, IntPtr pDynamicOffsets)
	{
		fixed (VkDescriptorSet* ptr = &pDescriptorSets)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineBindPoint, VkPipelineLayout, uint, uint, VkDescriptorSet*, uint, IntPtr, void>)vkCmdBindDescriptorSets_ptr)(commandBuffer, pipelineBindPoint, layout, firstSet, descriptorSetCount, ptr, dynamicOffsetCount, pDynamicOffsets);
		}
	}

	public unsafe static void vkCmdBindDescriptorSets(VkCommandBuffer commandBuffer, VkPipelineBindPoint pipelineBindPoint, VkPipelineLayout layout, uint firstSet, uint descriptorSetCount, IntPtr pDescriptorSets, uint dynamicOffsetCount, uint* pDynamicOffsets)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineBindPoint, VkPipelineLayout, uint, uint, IntPtr, uint, uint*, void>)vkCmdBindDescriptorSets_ptr)(commandBuffer, pipelineBindPoint, layout, firstSet, descriptorSetCount, pDescriptorSets, dynamicOffsetCount, pDynamicOffsets);
	}

	public unsafe static void vkCmdBindDescriptorSets(VkCommandBuffer commandBuffer, VkPipelineBindPoint pipelineBindPoint, VkPipelineLayout layout, uint firstSet, uint descriptorSetCount, IntPtr pDescriptorSets, uint dynamicOffsetCount, ref uint pDynamicOffsets)
	{
		fixed (uint* ptr = &pDynamicOffsets)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineBindPoint, VkPipelineLayout, uint, uint, IntPtr, uint, uint*, void>)vkCmdBindDescriptorSets_ptr)(commandBuffer, pipelineBindPoint, layout, firstSet, descriptorSetCount, pDescriptorSets, dynamicOffsetCount, ptr);
		}
	}

	public unsafe static void vkCmdBindDescriptorSets(VkCommandBuffer commandBuffer, VkPipelineBindPoint pipelineBindPoint, VkPipelineLayout layout, uint firstSet, uint descriptorSetCount, IntPtr pDescriptorSets, uint dynamicOffsetCount, IntPtr pDynamicOffsets)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineBindPoint, VkPipelineLayout, uint, uint, IntPtr, uint, IntPtr, void>)vkCmdBindDescriptorSets_ptr)(commandBuffer, pipelineBindPoint, layout, firstSet, descriptorSetCount, pDescriptorSets, dynamicOffsetCount, pDynamicOffsets);
	}

	public unsafe static void vkCmdBindIndexBuffer(VkCommandBuffer commandBuffer, VkBuffer buffer, ulong offset, VkIndexType indexType)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkBuffer, ulong, VkIndexType, void>)vkCmdBindIndexBuffer_ptr)(commandBuffer, buffer, offset, indexType);
	}

	public unsafe static void vkCmdBindPipeline(VkCommandBuffer commandBuffer, VkPipelineBindPoint pipelineBindPoint, VkPipeline pipeline)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineBindPoint, VkPipeline, void>)vkCmdBindPipeline_ptr)(commandBuffer, pipelineBindPoint, pipeline);
	}

	public unsafe static void vkCmdBindVertexBuffers(VkCommandBuffer commandBuffer, uint firstBinding, uint bindingCount, VkBuffer* pBuffers, ulong* pOffsets)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, uint, VkBuffer*, ulong*, void>)vkCmdBindVertexBuffers_ptr)(commandBuffer, firstBinding, bindingCount, pBuffers, pOffsets);
	}

	public unsafe static void vkCmdBindVertexBuffers(VkCommandBuffer commandBuffer, uint firstBinding, uint bindingCount, VkBuffer* pBuffers, ref ulong pOffsets)
	{
		fixed (ulong* ptr = &pOffsets)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, uint, VkBuffer*, ulong*, void>)vkCmdBindVertexBuffers_ptr)(commandBuffer, firstBinding, bindingCount, pBuffers, ptr);
		}
	}

	public unsafe static void vkCmdBindVertexBuffers(VkCommandBuffer commandBuffer, uint firstBinding, uint bindingCount, VkBuffer* pBuffers, IntPtr pOffsets)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, uint, VkBuffer*, IntPtr, void>)vkCmdBindVertexBuffers_ptr)(commandBuffer, firstBinding, bindingCount, pBuffers, pOffsets);
	}

	public unsafe static void vkCmdBindVertexBuffers(VkCommandBuffer commandBuffer, uint firstBinding, uint bindingCount, ref VkBuffer pBuffers, ulong* pOffsets)
	{
		fixed (VkBuffer* ptr = &pBuffers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, uint, VkBuffer*, ulong*, void>)vkCmdBindVertexBuffers_ptr)(commandBuffer, firstBinding, bindingCount, ptr, pOffsets);
		}
	}

	public unsafe static void vkCmdBindVertexBuffers(VkCommandBuffer commandBuffer, uint firstBinding, uint bindingCount, ref VkBuffer pBuffers, ref ulong pOffsets)
	{
		fixed (VkBuffer* ptr = &pBuffers)
		{
			fixed (ulong* ptr2 = &pOffsets)
			{
				((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, uint, VkBuffer*, ulong*, void>)vkCmdBindVertexBuffers_ptr)(commandBuffer, firstBinding, bindingCount, ptr, ptr2);
			}
		}
	}

	public unsafe static void vkCmdBindVertexBuffers(VkCommandBuffer commandBuffer, uint firstBinding, uint bindingCount, ref VkBuffer pBuffers, IntPtr pOffsets)
	{
		fixed (VkBuffer* ptr = &pBuffers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, uint, VkBuffer*, IntPtr, void>)vkCmdBindVertexBuffers_ptr)(commandBuffer, firstBinding, bindingCount, ptr, pOffsets);
		}
	}

	public unsafe static void vkCmdBindVertexBuffers(VkCommandBuffer commandBuffer, uint firstBinding, uint bindingCount, IntPtr pBuffers, ulong* pOffsets)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, uint, IntPtr, ulong*, void>)vkCmdBindVertexBuffers_ptr)(commandBuffer, firstBinding, bindingCount, pBuffers, pOffsets);
	}

	public unsafe static void vkCmdBindVertexBuffers(VkCommandBuffer commandBuffer, uint firstBinding, uint bindingCount, IntPtr pBuffers, ref ulong pOffsets)
	{
		fixed (ulong* ptr = &pOffsets)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, uint, IntPtr, ulong*, void>)vkCmdBindVertexBuffers_ptr)(commandBuffer, firstBinding, bindingCount, pBuffers, ptr);
		}
	}

	public unsafe static void vkCmdBindVertexBuffers(VkCommandBuffer commandBuffer, uint firstBinding, uint bindingCount, IntPtr pBuffers, IntPtr pOffsets)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, uint, IntPtr, IntPtr, void>)vkCmdBindVertexBuffers_ptr)(commandBuffer, firstBinding, bindingCount, pBuffers, pOffsets);
	}

	public unsafe static void vkCmdBlitImage(VkCommandBuffer commandBuffer, VkImage srcImage, VkImageLayout srcImageLayout, VkImage dstImage, VkImageLayout dstImageLayout, uint regionCount, VkImageBlit* pRegions, VkFilter filter)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkImage, VkImageLayout, VkImage, VkImageLayout, uint, VkImageBlit*, VkFilter, void>)vkCmdBlitImage_ptr)(commandBuffer, srcImage, srcImageLayout, dstImage, dstImageLayout, regionCount, pRegions, filter);
	}

	public unsafe static void vkCmdBlitImage(VkCommandBuffer commandBuffer, VkImage srcImage, VkImageLayout srcImageLayout, VkImage dstImage, VkImageLayout dstImageLayout, uint regionCount, ref VkImageBlit pRegions, VkFilter filter)
	{
		fixed (VkImageBlit* ptr = &pRegions)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkImage, VkImageLayout, VkImage, VkImageLayout, uint, VkImageBlit*, VkFilter, void>)vkCmdBlitImage_ptr)(commandBuffer, srcImage, srcImageLayout, dstImage, dstImageLayout, regionCount, ptr, filter);
		}
	}

	public unsafe static void vkCmdBlitImage(VkCommandBuffer commandBuffer, VkImage srcImage, VkImageLayout srcImageLayout, VkImage dstImage, VkImageLayout dstImageLayout, uint regionCount, IntPtr pRegions, VkFilter filter)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkImage, VkImageLayout, VkImage, VkImageLayout, uint, IntPtr, VkFilter, void>)vkCmdBlitImage_ptr)(commandBuffer, srcImage, srcImageLayout, dstImage, dstImageLayout, regionCount, pRegions, filter);
	}

	public unsafe static void vkCmdClearAttachments(VkCommandBuffer commandBuffer, uint attachmentCount, VkClearAttachment* pAttachments, uint rectCount, VkClearRect* pRects)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkClearAttachment*, uint, VkClearRect*, void>)vkCmdClearAttachments_ptr)(commandBuffer, attachmentCount, pAttachments, rectCount, pRects);
	}

	public unsafe static void vkCmdClearAttachments(VkCommandBuffer commandBuffer, uint attachmentCount, VkClearAttachment* pAttachments, uint rectCount, ref VkClearRect pRects)
	{
		fixed (VkClearRect* ptr = &pRects)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkClearAttachment*, uint, VkClearRect*, void>)vkCmdClearAttachments_ptr)(commandBuffer, attachmentCount, pAttachments, rectCount, ptr);
		}
	}

	public unsafe static void vkCmdClearAttachments(VkCommandBuffer commandBuffer, uint attachmentCount, VkClearAttachment* pAttachments, uint rectCount, IntPtr pRects)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkClearAttachment*, uint, IntPtr, void>)vkCmdClearAttachments_ptr)(commandBuffer, attachmentCount, pAttachments, rectCount, pRects);
	}

	public unsafe static void vkCmdClearAttachments(VkCommandBuffer commandBuffer, uint attachmentCount, ref VkClearAttachment pAttachments, uint rectCount, VkClearRect* pRects)
	{
		fixed (VkClearAttachment* ptr = &pAttachments)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkClearAttachment*, uint, VkClearRect*, void>)vkCmdClearAttachments_ptr)(commandBuffer, attachmentCount, ptr, rectCount, pRects);
		}
	}

	public unsafe static void vkCmdClearAttachments(VkCommandBuffer commandBuffer, uint attachmentCount, ref VkClearAttachment pAttachments, uint rectCount, ref VkClearRect pRects)
	{
		fixed (VkClearAttachment* ptr = &pAttachments)
		{
			fixed (VkClearRect* ptr2 = &pRects)
			{
				((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkClearAttachment*, uint, VkClearRect*, void>)vkCmdClearAttachments_ptr)(commandBuffer, attachmentCount, ptr, rectCount, ptr2);
			}
		}
	}

	public unsafe static void vkCmdClearAttachments(VkCommandBuffer commandBuffer, uint attachmentCount, ref VkClearAttachment pAttachments, uint rectCount, IntPtr pRects)
	{
		fixed (VkClearAttachment* ptr = &pAttachments)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkClearAttachment*, uint, IntPtr, void>)vkCmdClearAttachments_ptr)(commandBuffer, attachmentCount, ptr, rectCount, pRects);
		}
	}

	public unsafe static void vkCmdClearAttachments(VkCommandBuffer commandBuffer, uint attachmentCount, IntPtr pAttachments, uint rectCount, VkClearRect* pRects)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, IntPtr, uint, VkClearRect*, void>)vkCmdClearAttachments_ptr)(commandBuffer, attachmentCount, pAttachments, rectCount, pRects);
	}

	public unsafe static void vkCmdClearAttachments(VkCommandBuffer commandBuffer, uint attachmentCount, IntPtr pAttachments, uint rectCount, ref VkClearRect pRects)
	{
		fixed (VkClearRect* ptr = &pRects)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, IntPtr, uint, VkClearRect*, void>)vkCmdClearAttachments_ptr)(commandBuffer, attachmentCount, pAttachments, rectCount, ptr);
		}
	}

	public unsafe static void vkCmdClearAttachments(VkCommandBuffer commandBuffer, uint attachmentCount, IntPtr pAttachments, uint rectCount, IntPtr pRects)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, IntPtr, uint, IntPtr, void>)vkCmdClearAttachments_ptr)(commandBuffer, attachmentCount, pAttachments, rectCount, pRects);
	}

	public unsafe static void vkCmdClearColorImage(VkCommandBuffer commandBuffer, VkImage image, VkImageLayout imageLayout, VkClearColorValue* pColor, uint rangeCount, VkImageSubresourceRange* pRanges)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkImage, VkImageLayout, VkClearColorValue*, uint, VkImageSubresourceRange*, void>)vkCmdClearColorImage_ptr)(commandBuffer, image, imageLayout, pColor, rangeCount, pRanges);
	}

	public unsafe static void vkCmdClearColorImage(VkCommandBuffer commandBuffer, VkImage image, VkImageLayout imageLayout, VkClearColorValue* pColor, uint rangeCount, ref VkImageSubresourceRange pRanges)
	{
		fixed (VkImageSubresourceRange* ptr = &pRanges)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkImage, VkImageLayout, VkClearColorValue*, uint, VkImageSubresourceRange*, void>)vkCmdClearColorImage_ptr)(commandBuffer, image, imageLayout, pColor, rangeCount, ptr);
		}
	}

	public unsafe static void vkCmdClearColorImage(VkCommandBuffer commandBuffer, VkImage image, VkImageLayout imageLayout, VkClearColorValue* pColor, uint rangeCount, IntPtr pRanges)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkImage, VkImageLayout, VkClearColorValue*, uint, IntPtr, void>)vkCmdClearColorImage_ptr)(commandBuffer, image, imageLayout, pColor, rangeCount, pRanges);
	}

	public unsafe static void vkCmdClearColorImage(VkCommandBuffer commandBuffer, VkImage image, VkImageLayout imageLayout, ref VkClearColorValue pColor, uint rangeCount, VkImageSubresourceRange* pRanges)
	{
		fixed (VkClearColorValue* ptr = &pColor)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkImage, VkImageLayout, VkClearColorValue*, uint, VkImageSubresourceRange*, void>)vkCmdClearColorImage_ptr)(commandBuffer, image, imageLayout, ptr, rangeCount, pRanges);
		}
	}

	public unsafe static void vkCmdClearColorImage(VkCommandBuffer commandBuffer, VkImage image, VkImageLayout imageLayout, ref VkClearColorValue pColor, uint rangeCount, ref VkImageSubresourceRange pRanges)
	{
		fixed (VkClearColorValue* ptr = &pColor)
		{
			fixed (VkImageSubresourceRange* ptr2 = &pRanges)
			{
				((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkImage, VkImageLayout, VkClearColorValue*, uint, VkImageSubresourceRange*, void>)vkCmdClearColorImage_ptr)(commandBuffer, image, imageLayout, ptr, rangeCount, ptr2);
			}
		}
	}

	public unsafe static void vkCmdClearColorImage(VkCommandBuffer commandBuffer, VkImage image, VkImageLayout imageLayout, ref VkClearColorValue pColor, uint rangeCount, IntPtr pRanges)
	{
		fixed (VkClearColorValue* ptr = &pColor)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkImage, VkImageLayout, VkClearColorValue*, uint, IntPtr, void>)vkCmdClearColorImage_ptr)(commandBuffer, image, imageLayout, ptr, rangeCount, pRanges);
		}
	}

	public unsafe static void vkCmdClearColorImage(VkCommandBuffer commandBuffer, VkImage image, VkImageLayout imageLayout, IntPtr pColor, uint rangeCount, VkImageSubresourceRange* pRanges)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkImage, VkImageLayout, IntPtr, uint, VkImageSubresourceRange*, void>)vkCmdClearColorImage_ptr)(commandBuffer, image, imageLayout, pColor, rangeCount, pRanges);
	}

	public unsafe static void vkCmdClearColorImage(VkCommandBuffer commandBuffer, VkImage image, VkImageLayout imageLayout, IntPtr pColor, uint rangeCount, ref VkImageSubresourceRange pRanges)
	{
		fixed (VkImageSubresourceRange* ptr = &pRanges)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkImage, VkImageLayout, IntPtr, uint, VkImageSubresourceRange*, void>)vkCmdClearColorImage_ptr)(commandBuffer, image, imageLayout, pColor, rangeCount, ptr);
		}
	}

	public unsafe static void vkCmdClearColorImage(VkCommandBuffer commandBuffer, VkImage image, VkImageLayout imageLayout, IntPtr pColor, uint rangeCount, IntPtr pRanges)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkImage, VkImageLayout, IntPtr, uint, IntPtr, void>)vkCmdClearColorImage_ptr)(commandBuffer, image, imageLayout, pColor, rangeCount, pRanges);
	}

	public unsafe static void vkCmdClearDepthStencilImage(VkCommandBuffer commandBuffer, VkImage image, VkImageLayout imageLayout, VkClearDepthStencilValue* pDepthStencil, uint rangeCount, VkImageSubresourceRange* pRanges)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkImage, VkImageLayout, VkClearDepthStencilValue*, uint, VkImageSubresourceRange*, void>)vkCmdClearDepthStencilImage_ptr)(commandBuffer, image, imageLayout, pDepthStencil, rangeCount, pRanges);
	}

	public unsafe static void vkCmdClearDepthStencilImage(VkCommandBuffer commandBuffer, VkImage image, VkImageLayout imageLayout, VkClearDepthStencilValue* pDepthStencil, uint rangeCount, ref VkImageSubresourceRange pRanges)
	{
		fixed (VkImageSubresourceRange* ptr = &pRanges)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkImage, VkImageLayout, VkClearDepthStencilValue*, uint, VkImageSubresourceRange*, void>)vkCmdClearDepthStencilImage_ptr)(commandBuffer, image, imageLayout, pDepthStencil, rangeCount, ptr);
		}
	}

	public unsafe static void vkCmdClearDepthStencilImage(VkCommandBuffer commandBuffer, VkImage image, VkImageLayout imageLayout, VkClearDepthStencilValue* pDepthStencil, uint rangeCount, IntPtr pRanges)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkImage, VkImageLayout, VkClearDepthStencilValue*, uint, IntPtr, void>)vkCmdClearDepthStencilImage_ptr)(commandBuffer, image, imageLayout, pDepthStencil, rangeCount, pRanges);
	}

	public unsafe static void vkCmdClearDepthStencilImage(VkCommandBuffer commandBuffer, VkImage image, VkImageLayout imageLayout, ref VkClearDepthStencilValue pDepthStencil, uint rangeCount, VkImageSubresourceRange* pRanges)
	{
		fixed (VkClearDepthStencilValue* ptr = &pDepthStencil)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkImage, VkImageLayout, VkClearDepthStencilValue*, uint, VkImageSubresourceRange*, void>)vkCmdClearDepthStencilImage_ptr)(commandBuffer, image, imageLayout, ptr, rangeCount, pRanges);
		}
	}

	public unsafe static void vkCmdClearDepthStencilImage(VkCommandBuffer commandBuffer, VkImage image, VkImageLayout imageLayout, ref VkClearDepthStencilValue pDepthStencil, uint rangeCount, ref VkImageSubresourceRange pRanges)
	{
		fixed (VkClearDepthStencilValue* ptr = &pDepthStencil)
		{
			fixed (VkImageSubresourceRange* ptr2 = &pRanges)
			{
				((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkImage, VkImageLayout, VkClearDepthStencilValue*, uint, VkImageSubresourceRange*, void>)vkCmdClearDepthStencilImage_ptr)(commandBuffer, image, imageLayout, ptr, rangeCount, ptr2);
			}
		}
	}

	public unsafe static void vkCmdClearDepthStencilImage(VkCommandBuffer commandBuffer, VkImage image, VkImageLayout imageLayout, ref VkClearDepthStencilValue pDepthStencil, uint rangeCount, IntPtr pRanges)
	{
		fixed (VkClearDepthStencilValue* ptr = &pDepthStencil)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkImage, VkImageLayout, VkClearDepthStencilValue*, uint, IntPtr, void>)vkCmdClearDepthStencilImage_ptr)(commandBuffer, image, imageLayout, ptr, rangeCount, pRanges);
		}
	}

	public unsafe static void vkCmdClearDepthStencilImage(VkCommandBuffer commandBuffer, VkImage image, VkImageLayout imageLayout, IntPtr pDepthStencil, uint rangeCount, VkImageSubresourceRange* pRanges)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkImage, VkImageLayout, IntPtr, uint, VkImageSubresourceRange*, void>)vkCmdClearDepthStencilImage_ptr)(commandBuffer, image, imageLayout, pDepthStencil, rangeCount, pRanges);
	}

	public unsafe static void vkCmdClearDepthStencilImage(VkCommandBuffer commandBuffer, VkImage image, VkImageLayout imageLayout, IntPtr pDepthStencil, uint rangeCount, ref VkImageSubresourceRange pRanges)
	{
		fixed (VkImageSubresourceRange* ptr = &pRanges)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkImage, VkImageLayout, IntPtr, uint, VkImageSubresourceRange*, void>)vkCmdClearDepthStencilImage_ptr)(commandBuffer, image, imageLayout, pDepthStencil, rangeCount, ptr);
		}
	}

	public unsafe static void vkCmdClearDepthStencilImage(VkCommandBuffer commandBuffer, VkImage image, VkImageLayout imageLayout, IntPtr pDepthStencil, uint rangeCount, IntPtr pRanges)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkImage, VkImageLayout, IntPtr, uint, IntPtr, void>)vkCmdClearDepthStencilImage_ptr)(commandBuffer, image, imageLayout, pDepthStencil, rangeCount, pRanges);
	}

	public unsafe static void vkCmdCopyBuffer(VkCommandBuffer commandBuffer, VkBuffer srcBuffer, VkBuffer dstBuffer, uint regionCount, VkBufferCopy* pRegions)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkBuffer, VkBuffer, uint, VkBufferCopy*, void>)vkCmdCopyBuffer_ptr)(commandBuffer, srcBuffer, dstBuffer, regionCount, pRegions);
	}

	public unsafe static void vkCmdCopyBuffer(VkCommandBuffer commandBuffer, VkBuffer srcBuffer, VkBuffer dstBuffer, uint regionCount, ref VkBufferCopy pRegions)
	{
		fixed (VkBufferCopy* ptr = &pRegions)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkBuffer, VkBuffer, uint, VkBufferCopy*, void>)vkCmdCopyBuffer_ptr)(commandBuffer, srcBuffer, dstBuffer, regionCount, ptr);
		}
	}

	public unsafe static void vkCmdCopyBuffer(VkCommandBuffer commandBuffer, VkBuffer srcBuffer, VkBuffer dstBuffer, uint regionCount, IntPtr pRegions)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkBuffer, VkBuffer, uint, IntPtr, void>)vkCmdCopyBuffer_ptr)(commandBuffer, srcBuffer, dstBuffer, regionCount, pRegions);
	}

	public unsafe static void vkCmdCopyBufferToImage(VkCommandBuffer commandBuffer, VkBuffer srcBuffer, VkImage dstImage, VkImageLayout dstImageLayout, uint regionCount, VkBufferImageCopy* pRegions)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkBuffer, VkImage, VkImageLayout, uint, VkBufferImageCopy*, void>)vkCmdCopyBufferToImage_ptr)(commandBuffer, srcBuffer, dstImage, dstImageLayout, regionCount, pRegions);
	}

	public unsafe static void vkCmdCopyBufferToImage(VkCommandBuffer commandBuffer, VkBuffer srcBuffer, VkImage dstImage, VkImageLayout dstImageLayout, uint regionCount, ref VkBufferImageCopy pRegions)
	{
		fixed (VkBufferImageCopy* ptr = &pRegions)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkBuffer, VkImage, VkImageLayout, uint, VkBufferImageCopy*, void>)vkCmdCopyBufferToImage_ptr)(commandBuffer, srcBuffer, dstImage, dstImageLayout, regionCount, ptr);
		}
	}

	public unsafe static void vkCmdCopyBufferToImage(VkCommandBuffer commandBuffer, VkBuffer srcBuffer, VkImage dstImage, VkImageLayout dstImageLayout, uint regionCount, IntPtr pRegions)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkBuffer, VkImage, VkImageLayout, uint, IntPtr, void>)vkCmdCopyBufferToImage_ptr)(commandBuffer, srcBuffer, dstImage, dstImageLayout, regionCount, pRegions);
	}

	public unsafe static void vkCmdCopyImage(VkCommandBuffer commandBuffer, VkImage srcImage, VkImageLayout srcImageLayout, VkImage dstImage, VkImageLayout dstImageLayout, uint regionCount, VkImageCopy* pRegions)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkImage, VkImageLayout, VkImage, VkImageLayout, uint, VkImageCopy*, void>)vkCmdCopyImage_ptr)(commandBuffer, srcImage, srcImageLayout, dstImage, dstImageLayout, regionCount, pRegions);
	}

	public unsafe static void vkCmdCopyImage(VkCommandBuffer commandBuffer, VkImage srcImage, VkImageLayout srcImageLayout, VkImage dstImage, VkImageLayout dstImageLayout, uint regionCount, ref VkImageCopy pRegions)
	{
		fixed (VkImageCopy* ptr = &pRegions)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkImage, VkImageLayout, VkImage, VkImageLayout, uint, VkImageCopy*, void>)vkCmdCopyImage_ptr)(commandBuffer, srcImage, srcImageLayout, dstImage, dstImageLayout, regionCount, ptr);
		}
	}

	public unsafe static void vkCmdCopyImage(VkCommandBuffer commandBuffer, VkImage srcImage, VkImageLayout srcImageLayout, VkImage dstImage, VkImageLayout dstImageLayout, uint regionCount, IntPtr pRegions)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkImage, VkImageLayout, VkImage, VkImageLayout, uint, IntPtr, void>)vkCmdCopyImage_ptr)(commandBuffer, srcImage, srcImageLayout, dstImage, dstImageLayout, regionCount, pRegions);
	}

	public unsafe static void vkCmdCopyImageToBuffer(VkCommandBuffer commandBuffer, VkImage srcImage, VkImageLayout srcImageLayout, VkBuffer dstBuffer, uint regionCount, VkBufferImageCopy* pRegions)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkImage, VkImageLayout, VkBuffer, uint, VkBufferImageCopy*, void>)vkCmdCopyImageToBuffer_ptr)(commandBuffer, srcImage, srcImageLayout, dstBuffer, regionCount, pRegions);
	}

	public unsafe static void vkCmdCopyImageToBuffer(VkCommandBuffer commandBuffer, VkImage srcImage, VkImageLayout srcImageLayout, VkBuffer dstBuffer, uint regionCount, ref VkBufferImageCopy pRegions)
	{
		fixed (VkBufferImageCopy* ptr = &pRegions)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkImage, VkImageLayout, VkBuffer, uint, VkBufferImageCopy*, void>)vkCmdCopyImageToBuffer_ptr)(commandBuffer, srcImage, srcImageLayout, dstBuffer, regionCount, ptr);
		}
	}

	public unsafe static void vkCmdCopyImageToBuffer(VkCommandBuffer commandBuffer, VkImage srcImage, VkImageLayout srcImageLayout, VkBuffer dstBuffer, uint regionCount, IntPtr pRegions)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkImage, VkImageLayout, VkBuffer, uint, IntPtr, void>)vkCmdCopyImageToBuffer_ptr)(commandBuffer, srcImage, srcImageLayout, dstBuffer, regionCount, pRegions);
	}

	public unsafe static void vkCmdCopyQueryPoolResults(VkCommandBuffer commandBuffer, VkQueryPool queryPool, uint firstQuery, uint queryCount, VkBuffer dstBuffer, ulong dstOffset, ulong stride, VkQueryResultFlags flags)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkQueryPool, uint, uint, VkBuffer, ulong, ulong, VkQueryResultFlags, void>)vkCmdCopyQueryPoolResults_ptr)(commandBuffer, queryPool, firstQuery, queryCount, dstBuffer, dstOffset, stride, flags);
	}

	public unsafe static void vkCmdDebugMarkerBeginEXT(VkCommandBuffer commandBuffer, VkDebugMarkerMarkerInfoEXT* pMarkerInfo)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkDebugMarkerMarkerInfoEXT*, void>)vkCmdDebugMarkerBeginEXT_ptr)(commandBuffer, pMarkerInfo);
	}

	public unsafe static void vkCmdDebugMarkerBeginEXT(VkCommandBuffer commandBuffer, ref VkDebugMarkerMarkerInfoEXT pMarkerInfo)
	{
		fixed (VkDebugMarkerMarkerInfoEXT* ptr = &pMarkerInfo)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkDebugMarkerMarkerInfoEXT*, void>)vkCmdDebugMarkerBeginEXT_ptr)(commandBuffer, ptr);
		}
	}

	public unsafe static void vkCmdDebugMarkerBeginEXT(VkCommandBuffer commandBuffer, IntPtr pMarkerInfo)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, IntPtr, void>)vkCmdDebugMarkerBeginEXT_ptr)(commandBuffer, pMarkerInfo);
	}

	public unsafe static void vkCmdDebugMarkerEndEXT(VkCommandBuffer commandBuffer)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, void>)vkCmdDebugMarkerEndEXT_ptr)(commandBuffer);
	}

	public unsafe static void vkCmdDebugMarkerInsertEXT(VkCommandBuffer commandBuffer, VkDebugMarkerMarkerInfoEXT* pMarkerInfo)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkDebugMarkerMarkerInfoEXT*, void>)vkCmdDebugMarkerInsertEXT_ptr)(commandBuffer, pMarkerInfo);
	}

	public unsafe static void vkCmdDebugMarkerInsertEXT(VkCommandBuffer commandBuffer, ref VkDebugMarkerMarkerInfoEXT pMarkerInfo)
	{
		fixed (VkDebugMarkerMarkerInfoEXT* ptr = &pMarkerInfo)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkDebugMarkerMarkerInfoEXT*, void>)vkCmdDebugMarkerInsertEXT_ptr)(commandBuffer, ptr);
		}
	}

	public unsafe static void vkCmdDebugMarkerInsertEXT(VkCommandBuffer commandBuffer, IntPtr pMarkerInfo)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, IntPtr, void>)vkCmdDebugMarkerInsertEXT_ptr)(commandBuffer, pMarkerInfo);
	}

	public unsafe static void vkCmdDispatch(VkCommandBuffer commandBuffer, uint groupCountX, uint groupCountY, uint groupCountZ)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, uint, uint, void>)vkCmdDispatch_ptr)(commandBuffer, groupCountX, groupCountY, groupCountZ);
	}

	public unsafe static void vkCmdDispatchBaseKHX(VkCommandBuffer commandBuffer, uint baseGroupX, uint baseGroupY, uint baseGroupZ, uint groupCountX, uint groupCountY, uint groupCountZ)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, uint, uint, uint, uint, uint, void>)vkCmdDispatchBaseKHX_ptr)(commandBuffer, baseGroupX, baseGroupY, baseGroupZ, groupCountX, groupCountY, groupCountZ);
	}

	public unsafe static void vkCmdDispatchIndirect(VkCommandBuffer commandBuffer, VkBuffer buffer, ulong offset)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkBuffer, ulong, void>)vkCmdDispatchIndirect_ptr)(commandBuffer, buffer, offset);
	}

	public unsafe static void vkCmdDraw(VkCommandBuffer commandBuffer, uint vertexCount, uint instanceCount, uint firstVertex, uint firstInstance)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, uint, uint, uint, void>)vkCmdDraw_ptr)(commandBuffer, vertexCount, instanceCount, firstVertex, firstInstance);
	}

	public unsafe static void vkCmdDrawIndexed(VkCommandBuffer commandBuffer, uint indexCount, uint instanceCount, uint firstIndex, int vertexOffset, uint firstInstance)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, uint, uint, int, uint, void>)vkCmdDrawIndexed_ptr)(commandBuffer, indexCount, instanceCount, firstIndex, vertexOffset, firstInstance);
	}

	public unsafe static void vkCmdDrawIndexedIndirect(VkCommandBuffer commandBuffer, VkBuffer buffer, ulong offset, uint drawCount, uint stride)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkBuffer, ulong, uint, uint, void>)vkCmdDrawIndexedIndirect_ptr)(commandBuffer, buffer, offset, drawCount, stride);
	}

	public unsafe static void vkCmdDrawIndexedIndirectCountAMD(VkCommandBuffer commandBuffer, VkBuffer buffer, ulong offset, VkBuffer countBuffer, ulong countBufferOffset, uint maxDrawCount, uint stride)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkBuffer, ulong, VkBuffer, ulong, uint, uint, void>)vkCmdDrawIndexedIndirectCountAMD_ptr)(commandBuffer, buffer, offset, countBuffer, countBufferOffset, maxDrawCount, stride);
	}

	public unsafe static void vkCmdDrawIndirect(VkCommandBuffer commandBuffer, VkBuffer buffer, ulong offset, uint drawCount, uint stride)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkBuffer, ulong, uint, uint, void>)vkCmdDrawIndirect_ptr)(commandBuffer, buffer, offset, drawCount, stride);
	}

	public unsafe static void vkCmdDrawIndirectCountAMD(VkCommandBuffer commandBuffer, VkBuffer buffer, ulong offset, VkBuffer countBuffer, ulong countBufferOffset, uint maxDrawCount, uint stride)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkBuffer, ulong, VkBuffer, ulong, uint, uint, void>)vkCmdDrawIndirectCountAMD_ptr)(commandBuffer, buffer, offset, countBuffer, countBufferOffset, maxDrawCount, stride);
	}

	public unsafe static void vkCmdEndQuery(VkCommandBuffer commandBuffer, VkQueryPool queryPool, uint query)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkQueryPool, uint, void>)vkCmdEndQuery_ptr)(commandBuffer, queryPool, query);
	}

	public unsafe static void vkCmdEndRenderPass(VkCommandBuffer commandBuffer)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, void>)vkCmdEndRenderPass_ptr)(commandBuffer);
	}

	public unsafe static void vkCmdExecuteCommands(VkCommandBuffer commandBuffer, uint commandBufferCount, VkCommandBuffer* pCommandBuffers)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkCommandBuffer*, void>)vkCmdExecuteCommands_ptr)(commandBuffer, commandBufferCount, pCommandBuffers);
	}

	public unsafe static void vkCmdExecuteCommands(VkCommandBuffer commandBuffer, uint commandBufferCount, ref VkCommandBuffer pCommandBuffers)
	{
		fixed (VkCommandBuffer* ptr = &pCommandBuffers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkCommandBuffer*, void>)vkCmdExecuteCommands_ptr)(commandBuffer, commandBufferCount, ptr);
		}
	}

	public unsafe static void vkCmdExecuteCommands(VkCommandBuffer commandBuffer, uint commandBufferCount, IntPtr pCommandBuffers)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, IntPtr, void>)vkCmdExecuteCommands_ptr)(commandBuffer, commandBufferCount, pCommandBuffers);
	}

	public unsafe static void vkCmdFillBuffer(VkCommandBuffer commandBuffer, VkBuffer dstBuffer, ulong dstOffset, ulong size, uint data)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkBuffer, ulong, ulong, uint, void>)vkCmdFillBuffer_ptr)(commandBuffer, dstBuffer, dstOffset, size, data);
	}

	public unsafe static void vkCmdNextSubpass(VkCommandBuffer commandBuffer, VkSubpassContents contents)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkSubpassContents, void>)vkCmdNextSubpass_ptr)(commandBuffer, contents);
	}

	public unsafe static void vkCmdPipelineBarrier(VkCommandBuffer commandBuffer, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, VkDependencyFlags dependencyFlags, uint memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineStageFlags, VkPipelineStageFlags, VkDependencyFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdPipelineBarrier_ptr)(commandBuffer, srcStageMask, dstStageMask, dependencyFlags, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
	}

	public unsafe static void vkCmdPipelineBarrier(VkCommandBuffer commandBuffer, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, VkDependencyFlags dependencyFlags, uint memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, ref VkImageMemoryBarrier pImageMemoryBarriers)
	{
		fixed (VkImageMemoryBarrier* ptr = &pImageMemoryBarriers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineStageFlags, VkPipelineStageFlags, VkDependencyFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdPipelineBarrier_ptr)(commandBuffer, srcStageMask, dstStageMask, dependencyFlags, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, ptr);
		}
	}

	public unsafe static void vkCmdPipelineBarrier(VkCommandBuffer commandBuffer, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, VkDependencyFlags dependencyFlags, uint memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, IntPtr pImageMemoryBarriers)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineStageFlags, VkPipelineStageFlags, VkDependencyFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, IntPtr, void>)vkCmdPipelineBarrier_ptr)(commandBuffer, srcStageMask, dstStageMask, dependencyFlags, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
	}

	public unsafe static void vkCmdPipelineBarrier(VkCommandBuffer commandBuffer, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, VkDependencyFlags dependencyFlags, uint memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, ref VkBufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers)
	{
		fixed (VkBufferMemoryBarrier* ptr = &pBufferMemoryBarriers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineStageFlags, VkPipelineStageFlags, VkDependencyFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdPipelineBarrier_ptr)(commandBuffer, srcStageMask, dstStageMask, dependencyFlags, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, ptr, imageMemoryBarrierCount, pImageMemoryBarriers);
		}
	}

	public unsafe static void vkCmdPipelineBarrier(VkCommandBuffer commandBuffer, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, VkDependencyFlags dependencyFlags, uint memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, ref VkBufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, ref VkImageMemoryBarrier pImageMemoryBarriers)
	{
		fixed (VkBufferMemoryBarrier* ptr = &pBufferMemoryBarriers)
		{
			fixed (VkImageMemoryBarrier* ptr2 = &pImageMemoryBarriers)
			{
				((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineStageFlags, VkPipelineStageFlags, VkDependencyFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdPipelineBarrier_ptr)(commandBuffer, srcStageMask, dstStageMask, dependencyFlags, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, ptr, imageMemoryBarrierCount, ptr2);
			}
		}
	}

	public unsafe static void vkCmdPipelineBarrier(VkCommandBuffer commandBuffer, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, VkDependencyFlags dependencyFlags, uint memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, ref VkBufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, IntPtr pImageMemoryBarriers)
	{
		fixed (VkBufferMemoryBarrier* ptr = &pBufferMemoryBarriers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineStageFlags, VkPipelineStageFlags, VkDependencyFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, IntPtr, void>)vkCmdPipelineBarrier_ptr)(commandBuffer, srcStageMask, dstStageMask, dependencyFlags, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, ptr, imageMemoryBarrierCount, pImageMemoryBarriers);
		}
	}

	public unsafe static void vkCmdPipelineBarrier(VkCommandBuffer commandBuffer, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, VkDependencyFlags dependencyFlags, uint memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, IntPtr pBufferMemoryBarriers, uint imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineStageFlags, VkPipelineStageFlags, VkDependencyFlags, uint, VkMemoryBarrier*, uint, IntPtr, uint, VkImageMemoryBarrier*, void>)vkCmdPipelineBarrier_ptr)(commandBuffer, srcStageMask, dstStageMask, dependencyFlags, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
	}

	public unsafe static void vkCmdPipelineBarrier(VkCommandBuffer commandBuffer, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, VkDependencyFlags dependencyFlags, uint memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, IntPtr pBufferMemoryBarriers, uint imageMemoryBarrierCount, ref VkImageMemoryBarrier pImageMemoryBarriers)
	{
		fixed (VkImageMemoryBarrier* ptr = &pImageMemoryBarriers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineStageFlags, VkPipelineStageFlags, VkDependencyFlags, uint, VkMemoryBarrier*, uint, IntPtr, uint, VkImageMemoryBarrier*, void>)vkCmdPipelineBarrier_ptr)(commandBuffer, srcStageMask, dstStageMask, dependencyFlags, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, ptr);
		}
	}

	public unsafe static void vkCmdPipelineBarrier(VkCommandBuffer commandBuffer, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, VkDependencyFlags dependencyFlags, uint memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, IntPtr pBufferMemoryBarriers, uint imageMemoryBarrierCount, IntPtr pImageMemoryBarriers)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineStageFlags, VkPipelineStageFlags, VkDependencyFlags, uint, VkMemoryBarrier*, uint, IntPtr, uint, IntPtr, void>)vkCmdPipelineBarrier_ptr)(commandBuffer, srcStageMask, dstStageMask, dependencyFlags, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
	}

	public unsafe static void vkCmdPipelineBarrier(VkCommandBuffer commandBuffer, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, VkDependencyFlags dependencyFlags, uint memoryBarrierCount, ref VkMemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers)
	{
		fixed (VkMemoryBarrier* ptr = &pMemoryBarriers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineStageFlags, VkPipelineStageFlags, VkDependencyFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdPipelineBarrier_ptr)(commandBuffer, srcStageMask, dstStageMask, dependencyFlags, memoryBarrierCount, ptr, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
		}
	}

	public unsafe static void vkCmdPipelineBarrier(VkCommandBuffer commandBuffer, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, VkDependencyFlags dependencyFlags, uint memoryBarrierCount, ref VkMemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, ref VkImageMemoryBarrier pImageMemoryBarriers)
	{
		fixed (VkMemoryBarrier* ptr = &pMemoryBarriers)
		{
			fixed (VkImageMemoryBarrier* ptr2 = &pImageMemoryBarriers)
			{
				((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineStageFlags, VkPipelineStageFlags, VkDependencyFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdPipelineBarrier_ptr)(commandBuffer, srcStageMask, dstStageMask, dependencyFlags, memoryBarrierCount, ptr, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, ptr2);
			}
		}
	}

	public unsafe static void vkCmdPipelineBarrier(VkCommandBuffer commandBuffer, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, VkDependencyFlags dependencyFlags, uint memoryBarrierCount, ref VkMemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, IntPtr pImageMemoryBarriers)
	{
		fixed (VkMemoryBarrier* ptr = &pMemoryBarriers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineStageFlags, VkPipelineStageFlags, VkDependencyFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, IntPtr, void>)vkCmdPipelineBarrier_ptr)(commandBuffer, srcStageMask, dstStageMask, dependencyFlags, memoryBarrierCount, ptr, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
		}
	}

	public unsafe static void vkCmdPipelineBarrier(VkCommandBuffer commandBuffer, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, VkDependencyFlags dependencyFlags, uint memoryBarrierCount, ref VkMemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, ref VkBufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers)
	{
		fixed (VkMemoryBarrier* ptr = &pMemoryBarriers)
		{
			fixed (VkBufferMemoryBarrier* ptr2 = &pBufferMemoryBarriers)
			{
				((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineStageFlags, VkPipelineStageFlags, VkDependencyFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdPipelineBarrier_ptr)(commandBuffer, srcStageMask, dstStageMask, dependencyFlags, memoryBarrierCount, ptr, bufferMemoryBarrierCount, ptr2, imageMemoryBarrierCount, pImageMemoryBarriers);
			}
		}
	}

	public unsafe static void vkCmdPipelineBarrier(VkCommandBuffer commandBuffer, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, VkDependencyFlags dependencyFlags, uint memoryBarrierCount, ref VkMemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, ref VkBufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, ref VkImageMemoryBarrier pImageMemoryBarriers)
	{
		fixed (VkMemoryBarrier* ptr = &pMemoryBarriers)
		{
			fixed (VkBufferMemoryBarrier* ptr2 = &pBufferMemoryBarriers)
			{
				fixed (VkImageMemoryBarrier* ptr3 = &pImageMemoryBarriers)
				{
					((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineStageFlags, VkPipelineStageFlags, VkDependencyFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdPipelineBarrier_ptr)(commandBuffer, srcStageMask, dstStageMask, dependencyFlags, memoryBarrierCount, ptr, bufferMemoryBarrierCount, ptr2, imageMemoryBarrierCount, ptr3);
				}
			}
		}
	}

	public unsafe static void vkCmdPipelineBarrier(VkCommandBuffer commandBuffer, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, VkDependencyFlags dependencyFlags, uint memoryBarrierCount, ref VkMemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, ref VkBufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, IntPtr pImageMemoryBarriers)
	{
		fixed (VkMemoryBarrier* ptr = &pMemoryBarriers)
		{
			fixed (VkBufferMemoryBarrier* ptr2 = &pBufferMemoryBarriers)
			{
				((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineStageFlags, VkPipelineStageFlags, VkDependencyFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, IntPtr, void>)vkCmdPipelineBarrier_ptr)(commandBuffer, srcStageMask, dstStageMask, dependencyFlags, memoryBarrierCount, ptr, bufferMemoryBarrierCount, ptr2, imageMemoryBarrierCount, pImageMemoryBarriers);
			}
		}
	}

	public unsafe static void vkCmdPipelineBarrier(VkCommandBuffer commandBuffer, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, VkDependencyFlags dependencyFlags, uint memoryBarrierCount, ref VkMemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, IntPtr pBufferMemoryBarriers, uint imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers)
	{
		fixed (VkMemoryBarrier* ptr = &pMemoryBarriers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineStageFlags, VkPipelineStageFlags, VkDependencyFlags, uint, VkMemoryBarrier*, uint, IntPtr, uint, VkImageMemoryBarrier*, void>)vkCmdPipelineBarrier_ptr)(commandBuffer, srcStageMask, dstStageMask, dependencyFlags, memoryBarrierCount, ptr, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
		}
	}

	public unsafe static void vkCmdPipelineBarrier(VkCommandBuffer commandBuffer, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, VkDependencyFlags dependencyFlags, uint memoryBarrierCount, ref VkMemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, IntPtr pBufferMemoryBarriers, uint imageMemoryBarrierCount, ref VkImageMemoryBarrier pImageMemoryBarriers)
	{
		fixed (VkMemoryBarrier* ptr = &pMemoryBarriers)
		{
			fixed (VkImageMemoryBarrier* ptr2 = &pImageMemoryBarriers)
			{
				((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineStageFlags, VkPipelineStageFlags, VkDependencyFlags, uint, VkMemoryBarrier*, uint, IntPtr, uint, VkImageMemoryBarrier*, void>)vkCmdPipelineBarrier_ptr)(commandBuffer, srcStageMask, dstStageMask, dependencyFlags, memoryBarrierCount, ptr, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, ptr2);
			}
		}
	}

	public unsafe static void vkCmdPipelineBarrier(VkCommandBuffer commandBuffer, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, VkDependencyFlags dependencyFlags, uint memoryBarrierCount, ref VkMemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, IntPtr pBufferMemoryBarriers, uint imageMemoryBarrierCount, IntPtr pImageMemoryBarriers)
	{
		fixed (VkMemoryBarrier* ptr = &pMemoryBarriers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineStageFlags, VkPipelineStageFlags, VkDependencyFlags, uint, VkMemoryBarrier*, uint, IntPtr, uint, IntPtr, void>)vkCmdPipelineBarrier_ptr)(commandBuffer, srcStageMask, dstStageMask, dependencyFlags, memoryBarrierCount, ptr, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
		}
	}

	public unsafe static void vkCmdPipelineBarrier(VkCommandBuffer commandBuffer, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, VkDependencyFlags dependencyFlags, uint memoryBarrierCount, IntPtr pMemoryBarriers, uint bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineStageFlags, VkPipelineStageFlags, VkDependencyFlags, uint, IntPtr, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdPipelineBarrier_ptr)(commandBuffer, srcStageMask, dstStageMask, dependencyFlags, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
	}

	public unsafe static void vkCmdPipelineBarrier(VkCommandBuffer commandBuffer, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, VkDependencyFlags dependencyFlags, uint memoryBarrierCount, IntPtr pMemoryBarriers, uint bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, ref VkImageMemoryBarrier pImageMemoryBarriers)
	{
		fixed (VkImageMemoryBarrier* ptr = &pImageMemoryBarriers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineStageFlags, VkPipelineStageFlags, VkDependencyFlags, uint, IntPtr, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdPipelineBarrier_ptr)(commandBuffer, srcStageMask, dstStageMask, dependencyFlags, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, ptr);
		}
	}

	public unsafe static void vkCmdPipelineBarrier(VkCommandBuffer commandBuffer, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, VkDependencyFlags dependencyFlags, uint memoryBarrierCount, IntPtr pMemoryBarriers, uint bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, IntPtr pImageMemoryBarriers)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineStageFlags, VkPipelineStageFlags, VkDependencyFlags, uint, IntPtr, uint, VkBufferMemoryBarrier*, uint, IntPtr, void>)vkCmdPipelineBarrier_ptr)(commandBuffer, srcStageMask, dstStageMask, dependencyFlags, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
	}

	public unsafe static void vkCmdPipelineBarrier(VkCommandBuffer commandBuffer, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, VkDependencyFlags dependencyFlags, uint memoryBarrierCount, IntPtr pMemoryBarriers, uint bufferMemoryBarrierCount, ref VkBufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers)
	{
		fixed (VkBufferMemoryBarrier* ptr = &pBufferMemoryBarriers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineStageFlags, VkPipelineStageFlags, VkDependencyFlags, uint, IntPtr, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdPipelineBarrier_ptr)(commandBuffer, srcStageMask, dstStageMask, dependencyFlags, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, ptr, imageMemoryBarrierCount, pImageMemoryBarriers);
		}
	}

	public unsafe static void vkCmdPipelineBarrier(VkCommandBuffer commandBuffer, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, VkDependencyFlags dependencyFlags, uint memoryBarrierCount, IntPtr pMemoryBarriers, uint bufferMemoryBarrierCount, ref VkBufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, ref VkImageMemoryBarrier pImageMemoryBarriers)
	{
		fixed (VkBufferMemoryBarrier* ptr = &pBufferMemoryBarriers)
		{
			fixed (VkImageMemoryBarrier* ptr2 = &pImageMemoryBarriers)
			{
				((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineStageFlags, VkPipelineStageFlags, VkDependencyFlags, uint, IntPtr, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdPipelineBarrier_ptr)(commandBuffer, srcStageMask, dstStageMask, dependencyFlags, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, ptr, imageMemoryBarrierCount, ptr2);
			}
		}
	}

	public unsafe static void vkCmdPipelineBarrier(VkCommandBuffer commandBuffer, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, VkDependencyFlags dependencyFlags, uint memoryBarrierCount, IntPtr pMemoryBarriers, uint bufferMemoryBarrierCount, ref VkBufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, IntPtr pImageMemoryBarriers)
	{
		fixed (VkBufferMemoryBarrier* ptr = &pBufferMemoryBarriers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineStageFlags, VkPipelineStageFlags, VkDependencyFlags, uint, IntPtr, uint, VkBufferMemoryBarrier*, uint, IntPtr, void>)vkCmdPipelineBarrier_ptr)(commandBuffer, srcStageMask, dstStageMask, dependencyFlags, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, ptr, imageMemoryBarrierCount, pImageMemoryBarriers);
		}
	}

	public unsafe static void vkCmdPipelineBarrier(VkCommandBuffer commandBuffer, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, VkDependencyFlags dependencyFlags, uint memoryBarrierCount, IntPtr pMemoryBarriers, uint bufferMemoryBarrierCount, IntPtr pBufferMemoryBarriers, uint imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineStageFlags, VkPipelineStageFlags, VkDependencyFlags, uint, IntPtr, uint, IntPtr, uint, VkImageMemoryBarrier*, void>)vkCmdPipelineBarrier_ptr)(commandBuffer, srcStageMask, dstStageMask, dependencyFlags, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
	}

	public unsafe static void vkCmdPipelineBarrier(VkCommandBuffer commandBuffer, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, VkDependencyFlags dependencyFlags, uint memoryBarrierCount, IntPtr pMemoryBarriers, uint bufferMemoryBarrierCount, IntPtr pBufferMemoryBarriers, uint imageMemoryBarrierCount, ref VkImageMemoryBarrier pImageMemoryBarriers)
	{
		fixed (VkImageMemoryBarrier* ptr = &pImageMemoryBarriers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineStageFlags, VkPipelineStageFlags, VkDependencyFlags, uint, IntPtr, uint, IntPtr, uint, VkImageMemoryBarrier*, void>)vkCmdPipelineBarrier_ptr)(commandBuffer, srcStageMask, dstStageMask, dependencyFlags, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, ptr);
		}
	}

	public unsafe static void vkCmdPipelineBarrier(VkCommandBuffer commandBuffer, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, VkDependencyFlags dependencyFlags, uint memoryBarrierCount, IntPtr pMemoryBarriers, uint bufferMemoryBarrierCount, IntPtr pBufferMemoryBarriers, uint imageMemoryBarrierCount, IntPtr pImageMemoryBarriers)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineStageFlags, VkPipelineStageFlags, VkDependencyFlags, uint, IntPtr, uint, IntPtr, uint, IntPtr, void>)vkCmdPipelineBarrier_ptr)(commandBuffer, srcStageMask, dstStageMask, dependencyFlags, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
	}

	public unsafe static void vkCmdProcessCommandsNVX(VkCommandBuffer commandBuffer, VkCmdProcessCommandsInfoNVX* pProcessCommandsInfo)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkCmdProcessCommandsInfoNVX*, void>)vkCmdProcessCommandsNVX_ptr)(commandBuffer, pProcessCommandsInfo);
	}

	public unsafe static void vkCmdProcessCommandsNVX(VkCommandBuffer commandBuffer, ref VkCmdProcessCommandsInfoNVX pProcessCommandsInfo)
	{
		fixed (VkCmdProcessCommandsInfoNVX* ptr = &pProcessCommandsInfo)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkCmdProcessCommandsInfoNVX*, void>)vkCmdProcessCommandsNVX_ptr)(commandBuffer, ptr);
		}
	}

	public unsafe static void vkCmdProcessCommandsNVX(VkCommandBuffer commandBuffer, IntPtr pProcessCommandsInfo)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, IntPtr, void>)vkCmdProcessCommandsNVX_ptr)(commandBuffer, pProcessCommandsInfo);
	}

	public unsafe static void vkCmdPushConstants(VkCommandBuffer commandBuffer, VkPipelineLayout layout, VkShaderStageFlags stageFlags, uint offset, uint size, void* pValues)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineLayout, VkShaderStageFlags, uint, uint, void*, void>)vkCmdPushConstants_ptr)(commandBuffer, layout, stageFlags, offset, size, pValues);
	}

	public unsafe static void vkCmdPushDescriptorSetKHR(VkCommandBuffer commandBuffer, VkPipelineBindPoint pipelineBindPoint, VkPipelineLayout layout, uint set, uint descriptorWriteCount, VkWriteDescriptorSet* pDescriptorWrites)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineBindPoint, VkPipelineLayout, uint, uint, VkWriteDescriptorSet*, void>)vkCmdPushDescriptorSetKHR_ptr)(commandBuffer, pipelineBindPoint, layout, set, descriptorWriteCount, pDescriptorWrites);
	}

	public unsafe static void vkCmdPushDescriptorSetKHR(VkCommandBuffer commandBuffer, VkPipelineBindPoint pipelineBindPoint, VkPipelineLayout layout, uint set, uint descriptorWriteCount, ref VkWriteDescriptorSet pDescriptorWrites)
	{
		fixed (VkWriteDescriptorSet* ptr = &pDescriptorWrites)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineBindPoint, VkPipelineLayout, uint, uint, VkWriteDescriptorSet*, void>)vkCmdPushDescriptorSetKHR_ptr)(commandBuffer, pipelineBindPoint, layout, set, descriptorWriteCount, ptr);
		}
	}

	public unsafe static void vkCmdPushDescriptorSetKHR(VkCommandBuffer commandBuffer, VkPipelineBindPoint pipelineBindPoint, VkPipelineLayout layout, uint set, uint descriptorWriteCount, IntPtr pDescriptorWrites)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineBindPoint, VkPipelineLayout, uint, uint, IntPtr, void>)vkCmdPushDescriptorSetKHR_ptr)(commandBuffer, pipelineBindPoint, layout, set, descriptorWriteCount, pDescriptorWrites);
	}

	public unsafe static void vkCmdPushDescriptorSetWithTemplateKHR(VkCommandBuffer commandBuffer, VkDescriptorUpdateTemplateKHR descriptorUpdateTemplate, VkPipelineLayout layout, uint set, void* pData)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkDescriptorUpdateTemplateKHR, VkPipelineLayout, uint, void*, void>)vkCmdPushDescriptorSetWithTemplateKHR_ptr)(commandBuffer, descriptorUpdateTemplate, layout, set, pData);
	}

	public unsafe static void vkCmdReserveSpaceForCommandsNVX(VkCommandBuffer commandBuffer, VkCmdReserveSpaceForCommandsInfoNVX* pReserveSpaceInfo)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkCmdReserveSpaceForCommandsInfoNVX*, void>)vkCmdReserveSpaceForCommandsNVX_ptr)(commandBuffer, pReserveSpaceInfo);
	}

	public unsafe static void vkCmdReserveSpaceForCommandsNVX(VkCommandBuffer commandBuffer, ref VkCmdReserveSpaceForCommandsInfoNVX pReserveSpaceInfo)
	{
		fixed (VkCmdReserveSpaceForCommandsInfoNVX* ptr = &pReserveSpaceInfo)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkCmdReserveSpaceForCommandsInfoNVX*, void>)vkCmdReserveSpaceForCommandsNVX_ptr)(commandBuffer, ptr);
		}
	}

	public unsafe static void vkCmdReserveSpaceForCommandsNVX(VkCommandBuffer commandBuffer, IntPtr pReserveSpaceInfo)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, IntPtr, void>)vkCmdReserveSpaceForCommandsNVX_ptr)(commandBuffer, pReserveSpaceInfo);
	}

	public unsafe static void vkCmdResetEvent(VkCommandBuffer commandBuffer, VkEvent @event, VkPipelineStageFlags stageMask)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkEvent, VkPipelineStageFlags, void>)vkCmdResetEvent_ptr)(commandBuffer, @event, stageMask);
	}

	public unsafe static void vkCmdResetQueryPool(VkCommandBuffer commandBuffer, VkQueryPool queryPool, uint firstQuery, uint queryCount)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkQueryPool, uint, uint, void>)vkCmdResetQueryPool_ptr)(commandBuffer, queryPool, firstQuery, queryCount);
	}

	public unsafe static void vkCmdResolveImage(VkCommandBuffer commandBuffer, VkImage srcImage, VkImageLayout srcImageLayout, VkImage dstImage, VkImageLayout dstImageLayout, uint regionCount, VkImageResolve* pRegions)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkImage, VkImageLayout, VkImage, VkImageLayout, uint, VkImageResolve*, void>)vkCmdResolveImage_ptr)(commandBuffer, srcImage, srcImageLayout, dstImage, dstImageLayout, regionCount, pRegions);
	}

	public unsafe static void vkCmdResolveImage(VkCommandBuffer commandBuffer, VkImage srcImage, VkImageLayout srcImageLayout, VkImage dstImage, VkImageLayout dstImageLayout, uint regionCount, ref VkImageResolve pRegions)
	{
		fixed (VkImageResolve* ptr = &pRegions)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkImage, VkImageLayout, VkImage, VkImageLayout, uint, VkImageResolve*, void>)vkCmdResolveImage_ptr)(commandBuffer, srcImage, srcImageLayout, dstImage, dstImageLayout, regionCount, ptr);
		}
	}

	public unsafe static void vkCmdResolveImage(VkCommandBuffer commandBuffer, VkImage srcImage, VkImageLayout srcImageLayout, VkImage dstImage, VkImageLayout dstImageLayout, uint regionCount, IntPtr pRegions)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkImage, VkImageLayout, VkImage, VkImageLayout, uint, IntPtr, void>)vkCmdResolveImage_ptr)(commandBuffer, srcImage, srcImageLayout, dstImage, dstImageLayout, regionCount, pRegions);
	}

	public unsafe static void vkCmdSetBlendConstants(VkCommandBuffer commandBuffer, float blendConstants)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, float, void>)vkCmdSetBlendConstants_ptr)(commandBuffer, blendConstants);
	}

	public unsafe static void vkCmdSetDepthBias(VkCommandBuffer commandBuffer, float depthBiasConstantFactor, float depthBiasClamp, float depthBiasSlopeFactor)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, float, float, float, void>)vkCmdSetDepthBias_ptr)(commandBuffer, depthBiasConstantFactor, depthBiasClamp, depthBiasSlopeFactor);
	}

	public unsafe static void vkCmdSetDepthBounds(VkCommandBuffer commandBuffer, float minDepthBounds, float maxDepthBounds)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, float, float, void>)vkCmdSetDepthBounds_ptr)(commandBuffer, minDepthBounds, maxDepthBounds);
	}

	public unsafe static void vkCmdSetDeviceMaskKHX(VkCommandBuffer commandBuffer, uint deviceMask)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, void>)vkCmdSetDeviceMaskKHX_ptr)(commandBuffer, deviceMask);
	}

	public unsafe static void vkCmdSetDiscardRectangleEXT(VkCommandBuffer commandBuffer, uint firstDiscardRectangle, uint discardRectangleCount, VkRect2D* pDiscardRectangles)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, uint, VkRect2D*, void>)vkCmdSetDiscardRectangleEXT_ptr)(commandBuffer, firstDiscardRectangle, discardRectangleCount, pDiscardRectangles);
	}

	public unsafe static void vkCmdSetDiscardRectangleEXT(VkCommandBuffer commandBuffer, uint firstDiscardRectangle, uint discardRectangleCount, ref VkRect2D pDiscardRectangles)
	{
		fixed (VkRect2D* ptr = &pDiscardRectangles)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, uint, VkRect2D*, void>)vkCmdSetDiscardRectangleEXT_ptr)(commandBuffer, firstDiscardRectangle, discardRectangleCount, ptr);
		}
	}

	public unsafe static void vkCmdSetDiscardRectangleEXT(VkCommandBuffer commandBuffer, uint firstDiscardRectangle, uint discardRectangleCount, IntPtr pDiscardRectangles)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, uint, IntPtr, void>)vkCmdSetDiscardRectangleEXT_ptr)(commandBuffer, firstDiscardRectangle, discardRectangleCount, pDiscardRectangles);
	}

	public unsafe static void vkCmdSetEvent(VkCommandBuffer commandBuffer, VkEvent @event, VkPipelineStageFlags stageMask)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkEvent, VkPipelineStageFlags, void>)vkCmdSetEvent_ptr)(commandBuffer, @event, stageMask);
	}

	public unsafe static void vkCmdSetLineWidth(VkCommandBuffer commandBuffer, float lineWidth)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, float, void>)vkCmdSetLineWidth_ptr)(commandBuffer, lineWidth);
	}

	public unsafe static void vkCmdSetSampleLocationsEXT(VkCommandBuffer commandBuffer, VkSampleLocationsInfoEXT* pSampleLocationsInfo)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkSampleLocationsInfoEXT*, void>)vkCmdSetSampleLocationsEXT_ptr)(commandBuffer, pSampleLocationsInfo);
	}

	public unsafe static void vkCmdSetSampleLocationsEXT(VkCommandBuffer commandBuffer, ref VkSampleLocationsInfoEXT pSampleLocationsInfo)
	{
		fixed (VkSampleLocationsInfoEXT* ptr = &pSampleLocationsInfo)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkSampleLocationsInfoEXT*, void>)vkCmdSetSampleLocationsEXT_ptr)(commandBuffer, ptr);
		}
	}

	public unsafe static void vkCmdSetSampleLocationsEXT(VkCommandBuffer commandBuffer, IntPtr pSampleLocationsInfo)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, IntPtr, void>)vkCmdSetSampleLocationsEXT_ptr)(commandBuffer, pSampleLocationsInfo);
	}

	public unsafe static void vkCmdSetScissor(VkCommandBuffer commandBuffer, uint firstScissor, uint scissorCount, VkRect2D* pScissors)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, uint, VkRect2D*, void>)vkCmdSetScissor_ptr)(commandBuffer, firstScissor, scissorCount, pScissors);
	}

	public unsafe static void vkCmdSetScissor(VkCommandBuffer commandBuffer, uint firstScissor, uint scissorCount, ref VkRect2D pScissors)
	{
		fixed (VkRect2D* ptr = &pScissors)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, uint, VkRect2D*, void>)vkCmdSetScissor_ptr)(commandBuffer, firstScissor, scissorCount, ptr);
		}
	}

	public unsafe static void vkCmdSetScissor(VkCommandBuffer commandBuffer, uint firstScissor, uint scissorCount, IntPtr pScissors)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, uint, IntPtr, void>)vkCmdSetScissor_ptr)(commandBuffer, firstScissor, scissorCount, pScissors);
	}

	public unsafe static void vkCmdSetStencilCompareMask(VkCommandBuffer commandBuffer, VkStencilFaceFlags faceMask, uint compareMask)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkStencilFaceFlags, uint, void>)vkCmdSetStencilCompareMask_ptr)(commandBuffer, faceMask, compareMask);
	}

	public unsafe static void vkCmdSetStencilReference(VkCommandBuffer commandBuffer, VkStencilFaceFlags faceMask, uint reference)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkStencilFaceFlags, uint, void>)vkCmdSetStencilReference_ptr)(commandBuffer, faceMask, reference);
	}

	public unsafe static void vkCmdSetStencilWriteMask(VkCommandBuffer commandBuffer, VkStencilFaceFlags faceMask, uint writeMask)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkStencilFaceFlags, uint, void>)vkCmdSetStencilWriteMask_ptr)(commandBuffer, faceMask, writeMask);
	}

	public unsafe static void vkCmdSetViewport(VkCommandBuffer commandBuffer, uint firstViewport, uint viewportCount, VkViewport* pViewports)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, uint, VkViewport*, void>)vkCmdSetViewport_ptr)(commandBuffer, firstViewport, viewportCount, pViewports);
	}

	public unsafe static void vkCmdSetViewport(VkCommandBuffer commandBuffer, uint firstViewport, uint viewportCount, ref VkViewport pViewports)
	{
		fixed (VkViewport* ptr = &pViewports)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, uint, VkViewport*, void>)vkCmdSetViewport_ptr)(commandBuffer, firstViewport, viewportCount, ptr);
		}
	}

	public unsafe static void vkCmdSetViewport(VkCommandBuffer commandBuffer, uint firstViewport, uint viewportCount, IntPtr pViewports)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, uint, IntPtr, void>)vkCmdSetViewport_ptr)(commandBuffer, firstViewport, viewportCount, pViewports);
	}

	public unsafe static void vkCmdSetViewportWScalingNV(VkCommandBuffer commandBuffer, uint firstViewport, uint viewportCount, VkViewportWScalingNV* pViewportWScalings)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, uint, VkViewportWScalingNV*, void>)vkCmdSetViewportWScalingNV_ptr)(commandBuffer, firstViewport, viewportCount, pViewportWScalings);
	}

	public unsafe static void vkCmdSetViewportWScalingNV(VkCommandBuffer commandBuffer, uint firstViewport, uint viewportCount, ref VkViewportWScalingNV pViewportWScalings)
	{
		fixed (VkViewportWScalingNV* ptr = &pViewportWScalings)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, uint, VkViewportWScalingNV*, void>)vkCmdSetViewportWScalingNV_ptr)(commandBuffer, firstViewport, viewportCount, ptr);
		}
	}

	public unsafe static void vkCmdSetViewportWScalingNV(VkCommandBuffer commandBuffer, uint firstViewport, uint viewportCount, IntPtr pViewportWScalings)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, uint, IntPtr, void>)vkCmdSetViewportWScalingNV_ptr)(commandBuffer, firstViewport, viewportCount, pViewportWScalings);
	}

	public unsafe static void vkCmdUpdateBuffer(VkCommandBuffer commandBuffer, VkBuffer dstBuffer, ulong dstOffset, ulong dataSize, void* pData)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkBuffer, ulong, ulong, void*, void>)vkCmdUpdateBuffer_ptr)(commandBuffer, dstBuffer, dstOffset, dataSize, pData);
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, VkEvent* pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, VkEvent* pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, ref VkImageMemoryBarrier pImageMemoryBarriers)
	{
		fixed (VkImageMemoryBarrier* ptr = &pImageMemoryBarriers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, ptr);
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, VkEvent* pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, IntPtr pImageMemoryBarriers)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, IntPtr, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, VkEvent* pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, ref VkBufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers)
	{
		fixed (VkBufferMemoryBarrier* ptr = &pBufferMemoryBarriers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, ptr, imageMemoryBarrierCount, pImageMemoryBarriers);
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, VkEvent* pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, ref VkBufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, ref VkImageMemoryBarrier pImageMemoryBarriers)
	{
		fixed (VkBufferMemoryBarrier* ptr = &pBufferMemoryBarriers)
		{
			fixed (VkImageMemoryBarrier* ptr2 = &pImageMemoryBarriers)
			{
				((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, ptr, imageMemoryBarrierCount, ptr2);
			}
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, VkEvent* pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, ref VkBufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, IntPtr pImageMemoryBarriers)
	{
		fixed (VkBufferMemoryBarrier* ptr = &pBufferMemoryBarriers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, IntPtr, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, ptr, imageMemoryBarrierCount, pImageMemoryBarriers);
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, VkEvent* pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, IntPtr pBufferMemoryBarriers, uint imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, IntPtr, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, VkEvent* pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, IntPtr pBufferMemoryBarriers, uint imageMemoryBarrierCount, ref VkImageMemoryBarrier pImageMemoryBarriers)
	{
		fixed (VkImageMemoryBarrier* ptr = &pImageMemoryBarriers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, IntPtr, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, ptr);
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, VkEvent* pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, IntPtr pBufferMemoryBarriers, uint imageMemoryBarrierCount, IntPtr pImageMemoryBarriers)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, IntPtr, uint, IntPtr, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, VkEvent* pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, ref VkMemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers)
	{
		fixed (VkMemoryBarrier* ptr = &pMemoryBarriers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, ptr, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, VkEvent* pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, ref VkMemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, ref VkImageMemoryBarrier pImageMemoryBarriers)
	{
		fixed (VkMemoryBarrier* ptr = &pMemoryBarriers)
		{
			fixed (VkImageMemoryBarrier* ptr2 = &pImageMemoryBarriers)
			{
				((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, ptr, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, ptr2);
			}
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, VkEvent* pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, ref VkMemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, IntPtr pImageMemoryBarriers)
	{
		fixed (VkMemoryBarrier* ptr = &pMemoryBarriers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, IntPtr, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, ptr, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, VkEvent* pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, ref VkMemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, ref VkBufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers)
	{
		fixed (VkMemoryBarrier* ptr = &pMemoryBarriers)
		{
			fixed (VkBufferMemoryBarrier* ptr2 = &pBufferMemoryBarriers)
			{
				((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, ptr, bufferMemoryBarrierCount, ptr2, imageMemoryBarrierCount, pImageMemoryBarriers);
			}
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, VkEvent* pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, ref VkMemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, ref VkBufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, ref VkImageMemoryBarrier pImageMemoryBarriers)
	{
		fixed (VkMemoryBarrier* ptr = &pMemoryBarriers)
		{
			fixed (VkBufferMemoryBarrier* ptr2 = &pBufferMemoryBarriers)
			{
				fixed (VkImageMemoryBarrier* ptr3 = &pImageMemoryBarriers)
				{
					((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, ptr, bufferMemoryBarrierCount, ptr2, imageMemoryBarrierCount, ptr3);
				}
			}
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, VkEvent* pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, ref VkMemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, ref VkBufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, IntPtr pImageMemoryBarriers)
	{
		fixed (VkMemoryBarrier* ptr = &pMemoryBarriers)
		{
			fixed (VkBufferMemoryBarrier* ptr2 = &pBufferMemoryBarriers)
			{
				((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, IntPtr, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, ptr, bufferMemoryBarrierCount, ptr2, imageMemoryBarrierCount, pImageMemoryBarriers);
			}
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, VkEvent* pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, ref VkMemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, IntPtr pBufferMemoryBarriers, uint imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers)
	{
		fixed (VkMemoryBarrier* ptr = &pMemoryBarriers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, IntPtr, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, ptr, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, VkEvent* pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, ref VkMemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, IntPtr pBufferMemoryBarriers, uint imageMemoryBarrierCount, ref VkImageMemoryBarrier pImageMemoryBarriers)
	{
		fixed (VkMemoryBarrier* ptr = &pMemoryBarriers)
		{
			fixed (VkImageMemoryBarrier* ptr2 = &pImageMemoryBarriers)
			{
				((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, IntPtr, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, ptr, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, ptr2);
			}
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, VkEvent* pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, ref VkMemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, IntPtr pBufferMemoryBarriers, uint imageMemoryBarrierCount, IntPtr pImageMemoryBarriers)
	{
		fixed (VkMemoryBarrier* ptr = &pMemoryBarriers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, IntPtr, uint, IntPtr, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, ptr, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, VkEvent* pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, IntPtr pMemoryBarriers, uint bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, IntPtr, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, VkEvent* pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, IntPtr pMemoryBarriers, uint bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, ref VkImageMemoryBarrier pImageMemoryBarriers)
	{
		fixed (VkImageMemoryBarrier* ptr = &pImageMemoryBarriers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, IntPtr, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, ptr);
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, VkEvent* pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, IntPtr pMemoryBarriers, uint bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, IntPtr pImageMemoryBarriers)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, IntPtr, uint, VkBufferMemoryBarrier*, uint, IntPtr, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, VkEvent* pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, IntPtr pMemoryBarriers, uint bufferMemoryBarrierCount, ref VkBufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers)
	{
		fixed (VkBufferMemoryBarrier* ptr = &pBufferMemoryBarriers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, IntPtr, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, ptr, imageMemoryBarrierCount, pImageMemoryBarriers);
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, VkEvent* pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, IntPtr pMemoryBarriers, uint bufferMemoryBarrierCount, ref VkBufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, ref VkImageMemoryBarrier pImageMemoryBarriers)
	{
		fixed (VkBufferMemoryBarrier* ptr = &pBufferMemoryBarriers)
		{
			fixed (VkImageMemoryBarrier* ptr2 = &pImageMemoryBarriers)
			{
				((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, IntPtr, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, ptr, imageMemoryBarrierCount, ptr2);
			}
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, VkEvent* pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, IntPtr pMemoryBarriers, uint bufferMemoryBarrierCount, ref VkBufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, IntPtr pImageMemoryBarriers)
	{
		fixed (VkBufferMemoryBarrier* ptr = &pBufferMemoryBarriers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, IntPtr, uint, VkBufferMemoryBarrier*, uint, IntPtr, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, ptr, imageMemoryBarrierCount, pImageMemoryBarriers);
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, VkEvent* pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, IntPtr pMemoryBarriers, uint bufferMemoryBarrierCount, IntPtr pBufferMemoryBarriers, uint imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, IntPtr, uint, IntPtr, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, VkEvent* pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, IntPtr pMemoryBarriers, uint bufferMemoryBarrierCount, IntPtr pBufferMemoryBarriers, uint imageMemoryBarrierCount, ref VkImageMemoryBarrier pImageMemoryBarriers)
	{
		fixed (VkImageMemoryBarrier* ptr = &pImageMemoryBarriers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, IntPtr, uint, IntPtr, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, ptr);
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, VkEvent* pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, IntPtr pMemoryBarriers, uint bufferMemoryBarrierCount, IntPtr pBufferMemoryBarriers, uint imageMemoryBarrierCount, IntPtr pImageMemoryBarriers)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, IntPtr, uint, IntPtr, uint, IntPtr, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, ref VkEvent pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers)
	{
		fixed (VkEvent* ptr = &pEvents)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, ptr, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, ref VkEvent pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, ref VkImageMemoryBarrier pImageMemoryBarriers)
	{
		fixed (VkEvent* ptr = &pEvents)
		{
			fixed (VkImageMemoryBarrier* ptr2 = &pImageMemoryBarriers)
			{
				((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, ptr, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, ptr2);
			}
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, ref VkEvent pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, IntPtr pImageMemoryBarriers)
	{
		fixed (VkEvent* ptr = &pEvents)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, IntPtr, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, ptr, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, ref VkEvent pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, ref VkBufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers)
	{
		fixed (VkEvent* ptr = &pEvents)
		{
			fixed (VkBufferMemoryBarrier* ptr2 = &pBufferMemoryBarriers)
			{
				((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, ptr, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, ptr2, imageMemoryBarrierCount, pImageMemoryBarriers);
			}
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, ref VkEvent pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, ref VkBufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, ref VkImageMemoryBarrier pImageMemoryBarriers)
	{
		fixed (VkEvent* ptr = &pEvents)
		{
			fixed (VkBufferMemoryBarrier* ptr2 = &pBufferMemoryBarriers)
			{
				fixed (VkImageMemoryBarrier* ptr3 = &pImageMemoryBarriers)
				{
					((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, ptr, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, ptr2, imageMemoryBarrierCount, ptr3);
				}
			}
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, ref VkEvent pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, ref VkBufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, IntPtr pImageMemoryBarriers)
	{
		fixed (VkEvent* ptr = &pEvents)
		{
			fixed (VkBufferMemoryBarrier* ptr2 = &pBufferMemoryBarriers)
			{
				((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, IntPtr, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, ptr, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, ptr2, imageMemoryBarrierCount, pImageMemoryBarriers);
			}
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, ref VkEvent pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, IntPtr pBufferMemoryBarriers, uint imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers)
	{
		fixed (VkEvent* ptr = &pEvents)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, IntPtr, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, ptr, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, ref VkEvent pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, IntPtr pBufferMemoryBarriers, uint imageMemoryBarrierCount, ref VkImageMemoryBarrier pImageMemoryBarriers)
	{
		fixed (VkEvent* ptr = &pEvents)
		{
			fixed (VkImageMemoryBarrier* ptr2 = &pImageMemoryBarriers)
			{
				((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, IntPtr, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, ptr, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, ptr2);
			}
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, ref VkEvent pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, IntPtr pBufferMemoryBarriers, uint imageMemoryBarrierCount, IntPtr pImageMemoryBarriers)
	{
		fixed (VkEvent* ptr = &pEvents)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, IntPtr, uint, IntPtr, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, ptr, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, ref VkEvent pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, ref VkMemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers)
	{
		fixed (VkEvent* ptr = &pEvents)
		{
			fixed (VkMemoryBarrier* ptr2 = &pMemoryBarriers)
			{
				((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, ptr, srcStageMask, dstStageMask, memoryBarrierCount, ptr2, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
			}
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, ref VkEvent pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, ref VkMemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, ref VkImageMemoryBarrier pImageMemoryBarriers)
	{
		fixed (VkEvent* ptr = &pEvents)
		{
			fixed (VkMemoryBarrier* ptr2 = &pMemoryBarriers)
			{
				fixed (VkImageMemoryBarrier* ptr3 = &pImageMemoryBarriers)
				{
					((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, ptr, srcStageMask, dstStageMask, memoryBarrierCount, ptr2, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, ptr3);
				}
			}
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, ref VkEvent pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, ref VkMemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, IntPtr pImageMemoryBarriers)
	{
		fixed (VkEvent* ptr = &pEvents)
		{
			fixed (VkMemoryBarrier* ptr2 = &pMemoryBarriers)
			{
				((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, IntPtr, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, ptr, srcStageMask, dstStageMask, memoryBarrierCount, ptr2, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
			}
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, ref VkEvent pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, ref VkMemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, ref VkBufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers)
	{
		fixed (VkEvent* ptr = &pEvents)
		{
			fixed (VkMemoryBarrier* ptr2 = &pMemoryBarriers)
			{
				fixed (VkBufferMemoryBarrier* ptr3 = &pBufferMemoryBarriers)
				{
					((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, ptr, srcStageMask, dstStageMask, memoryBarrierCount, ptr2, bufferMemoryBarrierCount, ptr3, imageMemoryBarrierCount, pImageMemoryBarriers);
				}
			}
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, ref VkEvent pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, ref VkMemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, ref VkBufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, ref VkImageMemoryBarrier pImageMemoryBarriers)
	{
		fixed (VkEvent* ptr = &pEvents)
		{
			fixed (VkMemoryBarrier* ptr2 = &pMemoryBarriers)
			{
				fixed (VkBufferMemoryBarrier* ptr3 = &pBufferMemoryBarriers)
				{
					fixed (VkImageMemoryBarrier* ptr4 = &pImageMemoryBarriers)
					{
						((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, ptr, srcStageMask, dstStageMask, memoryBarrierCount, ptr2, bufferMemoryBarrierCount, ptr3, imageMemoryBarrierCount, ptr4);
					}
				}
			}
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, ref VkEvent pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, ref VkMemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, ref VkBufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, IntPtr pImageMemoryBarriers)
	{
		fixed (VkEvent* ptr = &pEvents)
		{
			fixed (VkMemoryBarrier* ptr2 = &pMemoryBarriers)
			{
				fixed (VkBufferMemoryBarrier* ptr3 = &pBufferMemoryBarriers)
				{
					((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, IntPtr, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, ptr, srcStageMask, dstStageMask, memoryBarrierCount, ptr2, bufferMemoryBarrierCount, ptr3, imageMemoryBarrierCount, pImageMemoryBarriers);
				}
			}
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, ref VkEvent pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, ref VkMemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, IntPtr pBufferMemoryBarriers, uint imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers)
	{
		fixed (VkEvent* ptr = &pEvents)
		{
			fixed (VkMemoryBarrier* ptr2 = &pMemoryBarriers)
			{
				((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, IntPtr, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, ptr, srcStageMask, dstStageMask, memoryBarrierCount, ptr2, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
			}
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, ref VkEvent pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, ref VkMemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, IntPtr pBufferMemoryBarriers, uint imageMemoryBarrierCount, ref VkImageMemoryBarrier pImageMemoryBarriers)
	{
		fixed (VkEvent* ptr = &pEvents)
		{
			fixed (VkMemoryBarrier* ptr2 = &pMemoryBarriers)
			{
				fixed (VkImageMemoryBarrier* ptr3 = &pImageMemoryBarriers)
				{
					((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, IntPtr, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, ptr, srcStageMask, dstStageMask, memoryBarrierCount, ptr2, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, ptr3);
				}
			}
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, ref VkEvent pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, ref VkMemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, IntPtr pBufferMemoryBarriers, uint imageMemoryBarrierCount, IntPtr pImageMemoryBarriers)
	{
		fixed (VkEvent* ptr = &pEvents)
		{
			fixed (VkMemoryBarrier* ptr2 = &pMemoryBarriers)
			{
				((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, IntPtr, uint, IntPtr, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, ptr, srcStageMask, dstStageMask, memoryBarrierCount, ptr2, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
			}
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, ref VkEvent pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, IntPtr pMemoryBarriers, uint bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers)
	{
		fixed (VkEvent* ptr = &pEvents)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, IntPtr, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, ptr, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, ref VkEvent pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, IntPtr pMemoryBarriers, uint bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, ref VkImageMemoryBarrier pImageMemoryBarriers)
	{
		fixed (VkEvent* ptr = &pEvents)
		{
			fixed (VkImageMemoryBarrier* ptr2 = &pImageMemoryBarriers)
			{
				((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, IntPtr, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, ptr, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, ptr2);
			}
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, ref VkEvent pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, IntPtr pMemoryBarriers, uint bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, IntPtr pImageMemoryBarriers)
	{
		fixed (VkEvent* ptr = &pEvents)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, IntPtr, uint, VkBufferMemoryBarrier*, uint, IntPtr, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, ptr, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, ref VkEvent pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, IntPtr pMemoryBarriers, uint bufferMemoryBarrierCount, ref VkBufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers)
	{
		fixed (VkEvent* ptr = &pEvents)
		{
			fixed (VkBufferMemoryBarrier* ptr2 = &pBufferMemoryBarriers)
			{
				((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, IntPtr, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, ptr, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, ptr2, imageMemoryBarrierCount, pImageMemoryBarriers);
			}
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, ref VkEvent pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, IntPtr pMemoryBarriers, uint bufferMemoryBarrierCount, ref VkBufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, ref VkImageMemoryBarrier pImageMemoryBarriers)
	{
		fixed (VkEvent* ptr = &pEvents)
		{
			fixed (VkBufferMemoryBarrier* ptr2 = &pBufferMemoryBarriers)
			{
				fixed (VkImageMemoryBarrier* ptr3 = &pImageMemoryBarriers)
				{
					((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, IntPtr, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, ptr, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, ptr2, imageMemoryBarrierCount, ptr3);
				}
			}
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, ref VkEvent pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, IntPtr pMemoryBarriers, uint bufferMemoryBarrierCount, ref VkBufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, IntPtr pImageMemoryBarriers)
	{
		fixed (VkEvent* ptr = &pEvents)
		{
			fixed (VkBufferMemoryBarrier* ptr2 = &pBufferMemoryBarriers)
			{
				((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, IntPtr, uint, VkBufferMemoryBarrier*, uint, IntPtr, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, ptr, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, ptr2, imageMemoryBarrierCount, pImageMemoryBarriers);
			}
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, ref VkEvent pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, IntPtr pMemoryBarriers, uint bufferMemoryBarrierCount, IntPtr pBufferMemoryBarriers, uint imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers)
	{
		fixed (VkEvent* ptr = &pEvents)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, IntPtr, uint, IntPtr, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, ptr, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, ref VkEvent pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, IntPtr pMemoryBarriers, uint bufferMemoryBarrierCount, IntPtr pBufferMemoryBarriers, uint imageMemoryBarrierCount, ref VkImageMemoryBarrier pImageMemoryBarriers)
	{
		fixed (VkEvent* ptr = &pEvents)
		{
			fixed (VkImageMemoryBarrier* ptr2 = &pImageMemoryBarriers)
			{
				((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, IntPtr, uint, IntPtr, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, ptr, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, ptr2);
			}
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, ref VkEvent pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, IntPtr pMemoryBarriers, uint bufferMemoryBarrierCount, IntPtr pBufferMemoryBarriers, uint imageMemoryBarrierCount, IntPtr pImageMemoryBarriers)
	{
		fixed (VkEvent* ptr = &pEvents)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, VkEvent*, VkPipelineStageFlags, VkPipelineStageFlags, uint, IntPtr, uint, IntPtr, uint, IntPtr, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, ptr, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, IntPtr pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, IntPtr, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, IntPtr pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, ref VkImageMemoryBarrier pImageMemoryBarriers)
	{
		fixed (VkImageMemoryBarrier* ptr = &pImageMemoryBarriers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, IntPtr, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, ptr);
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, IntPtr pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, IntPtr pImageMemoryBarriers)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, IntPtr, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, IntPtr, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, IntPtr pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, ref VkBufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers)
	{
		fixed (VkBufferMemoryBarrier* ptr = &pBufferMemoryBarriers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, IntPtr, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, ptr, imageMemoryBarrierCount, pImageMemoryBarriers);
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, IntPtr pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, ref VkBufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, ref VkImageMemoryBarrier pImageMemoryBarriers)
	{
		fixed (VkBufferMemoryBarrier* ptr = &pBufferMemoryBarriers)
		{
			fixed (VkImageMemoryBarrier* ptr2 = &pImageMemoryBarriers)
			{
				((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, IntPtr, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, ptr, imageMemoryBarrierCount, ptr2);
			}
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, IntPtr pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, ref VkBufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, IntPtr pImageMemoryBarriers)
	{
		fixed (VkBufferMemoryBarrier* ptr = &pBufferMemoryBarriers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, IntPtr, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, IntPtr, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, ptr, imageMemoryBarrierCount, pImageMemoryBarriers);
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, IntPtr pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, IntPtr pBufferMemoryBarriers, uint imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, IntPtr, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, IntPtr, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, IntPtr pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, IntPtr pBufferMemoryBarriers, uint imageMemoryBarrierCount, ref VkImageMemoryBarrier pImageMemoryBarriers)
	{
		fixed (VkImageMemoryBarrier* ptr = &pImageMemoryBarriers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, IntPtr, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, IntPtr, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, ptr);
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, IntPtr pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, IntPtr pBufferMemoryBarriers, uint imageMemoryBarrierCount, IntPtr pImageMemoryBarriers)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, IntPtr, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, IntPtr, uint, IntPtr, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, IntPtr pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, ref VkMemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers)
	{
		fixed (VkMemoryBarrier* ptr = &pMemoryBarriers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, IntPtr, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, ptr, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, IntPtr pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, ref VkMemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, ref VkImageMemoryBarrier pImageMemoryBarriers)
	{
		fixed (VkMemoryBarrier* ptr = &pMemoryBarriers)
		{
			fixed (VkImageMemoryBarrier* ptr2 = &pImageMemoryBarriers)
			{
				((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, IntPtr, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, ptr, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, ptr2);
			}
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, IntPtr pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, ref VkMemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, IntPtr pImageMemoryBarriers)
	{
		fixed (VkMemoryBarrier* ptr = &pMemoryBarriers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, IntPtr, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, IntPtr, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, ptr, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, IntPtr pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, ref VkMemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, ref VkBufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers)
	{
		fixed (VkMemoryBarrier* ptr = &pMemoryBarriers)
		{
			fixed (VkBufferMemoryBarrier* ptr2 = &pBufferMemoryBarriers)
			{
				((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, IntPtr, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, ptr, bufferMemoryBarrierCount, ptr2, imageMemoryBarrierCount, pImageMemoryBarriers);
			}
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, IntPtr pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, ref VkMemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, ref VkBufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, ref VkImageMemoryBarrier pImageMemoryBarriers)
	{
		fixed (VkMemoryBarrier* ptr = &pMemoryBarriers)
		{
			fixed (VkBufferMemoryBarrier* ptr2 = &pBufferMemoryBarriers)
			{
				fixed (VkImageMemoryBarrier* ptr3 = &pImageMemoryBarriers)
				{
					((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, IntPtr, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, ptr, bufferMemoryBarrierCount, ptr2, imageMemoryBarrierCount, ptr3);
				}
			}
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, IntPtr pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, ref VkMemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, ref VkBufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, IntPtr pImageMemoryBarriers)
	{
		fixed (VkMemoryBarrier* ptr = &pMemoryBarriers)
		{
			fixed (VkBufferMemoryBarrier* ptr2 = &pBufferMemoryBarriers)
			{
				((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, IntPtr, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, VkBufferMemoryBarrier*, uint, IntPtr, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, ptr, bufferMemoryBarrierCount, ptr2, imageMemoryBarrierCount, pImageMemoryBarriers);
			}
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, IntPtr pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, ref VkMemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, IntPtr pBufferMemoryBarriers, uint imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers)
	{
		fixed (VkMemoryBarrier* ptr = &pMemoryBarriers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, IntPtr, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, IntPtr, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, ptr, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, IntPtr pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, ref VkMemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, IntPtr pBufferMemoryBarriers, uint imageMemoryBarrierCount, ref VkImageMemoryBarrier pImageMemoryBarriers)
	{
		fixed (VkMemoryBarrier* ptr = &pMemoryBarriers)
		{
			fixed (VkImageMemoryBarrier* ptr2 = &pImageMemoryBarriers)
			{
				((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, IntPtr, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, IntPtr, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, ptr, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, ptr2);
			}
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, IntPtr pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, ref VkMemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, IntPtr pBufferMemoryBarriers, uint imageMemoryBarrierCount, IntPtr pImageMemoryBarriers)
	{
		fixed (VkMemoryBarrier* ptr = &pMemoryBarriers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, IntPtr, VkPipelineStageFlags, VkPipelineStageFlags, uint, VkMemoryBarrier*, uint, IntPtr, uint, IntPtr, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, ptr, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, IntPtr pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, IntPtr pMemoryBarriers, uint bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, IntPtr, VkPipelineStageFlags, VkPipelineStageFlags, uint, IntPtr, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, IntPtr pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, IntPtr pMemoryBarriers, uint bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, ref VkImageMemoryBarrier pImageMemoryBarriers)
	{
		fixed (VkImageMemoryBarrier* ptr = &pImageMemoryBarriers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, IntPtr, VkPipelineStageFlags, VkPipelineStageFlags, uint, IntPtr, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, ptr);
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, IntPtr pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, IntPtr pMemoryBarriers, uint bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, IntPtr pImageMemoryBarriers)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, IntPtr, VkPipelineStageFlags, VkPipelineStageFlags, uint, IntPtr, uint, VkBufferMemoryBarrier*, uint, IntPtr, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, IntPtr pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, IntPtr pMemoryBarriers, uint bufferMemoryBarrierCount, ref VkBufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers)
	{
		fixed (VkBufferMemoryBarrier* ptr = &pBufferMemoryBarriers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, IntPtr, VkPipelineStageFlags, VkPipelineStageFlags, uint, IntPtr, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, ptr, imageMemoryBarrierCount, pImageMemoryBarriers);
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, IntPtr pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, IntPtr pMemoryBarriers, uint bufferMemoryBarrierCount, ref VkBufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, ref VkImageMemoryBarrier pImageMemoryBarriers)
	{
		fixed (VkBufferMemoryBarrier* ptr = &pBufferMemoryBarriers)
		{
			fixed (VkImageMemoryBarrier* ptr2 = &pImageMemoryBarriers)
			{
				((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, IntPtr, VkPipelineStageFlags, VkPipelineStageFlags, uint, IntPtr, uint, VkBufferMemoryBarrier*, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, ptr, imageMemoryBarrierCount, ptr2);
			}
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, IntPtr pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, IntPtr pMemoryBarriers, uint bufferMemoryBarrierCount, ref VkBufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, IntPtr pImageMemoryBarriers)
	{
		fixed (VkBufferMemoryBarrier* ptr = &pBufferMemoryBarriers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, IntPtr, VkPipelineStageFlags, VkPipelineStageFlags, uint, IntPtr, uint, VkBufferMemoryBarrier*, uint, IntPtr, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, ptr, imageMemoryBarrierCount, pImageMemoryBarriers);
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, IntPtr pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, IntPtr pMemoryBarriers, uint bufferMemoryBarrierCount, IntPtr pBufferMemoryBarriers, uint imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, IntPtr, VkPipelineStageFlags, VkPipelineStageFlags, uint, IntPtr, uint, IntPtr, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, IntPtr pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, IntPtr pMemoryBarriers, uint bufferMemoryBarrierCount, IntPtr pBufferMemoryBarriers, uint imageMemoryBarrierCount, ref VkImageMemoryBarrier pImageMemoryBarriers)
	{
		fixed (VkImageMemoryBarrier* ptr = &pImageMemoryBarriers)
		{
			((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, IntPtr, VkPipelineStageFlags, VkPipelineStageFlags, uint, IntPtr, uint, IntPtr, uint, VkImageMemoryBarrier*, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, ptr);
		}
	}

	public unsafe static void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint eventCount, IntPtr pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint memoryBarrierCount, IntPtr pMemoryBarriers, uint bufferMemoryBarrierCount, IntPtr pBufferMemoryBarriers, uint imageMemoryBarrierCount, IntPtr pImageMemoryBarriers)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, uint, IntPtr, VkPipelineStageFlags, VkPipelineStageFlags, uint, IntPtr, uint, IntPtr, uint, IntPtr, void>)vkCmdWaitEvents_ptr)(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
	}

	public unsafe static void vkCmdWriteTimestamp(VkCommandBuffer commandBuffer, VkPipelineStageFlags pipelineStage, VkQueryPool queryPool, uint query)
	{
		((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkPipelineStageFlags, VkQueryPool, uint, void>)vkCmdWriteTimestamp_ptr)(commandBuffer, pipelineStage, queryPool, query);
	}

	public unsafe static VkResult vkCreateAndroidSurfaceKHR(VkInstance instance, VkAndroidSurfaceCreateInfoKHR* pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, VkAndroidSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateAndroidSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateAndroidSurfaceKHR(VkInstance instance, VkAndroidSurfaceCreateInfoKHR* pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkAndroidSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateAndroidSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateAndroidSurfaceKHR(VkInstance instance, VkAndroidSurfaceCreateInfoKHR* pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkAndroidSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateAndroidSurfaceKHR_ptr)(instance, pCreateInfo, ptr, pSurface);
		}
	}

	public unsafe static VkResult vkCreateAndroidSurfaceKHR(VkInstance instance, VkAndroidSurfaceCreateInfoKHR* pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkAndroidSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateAndroidSurfaceKHR_ptr)(instance, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateAndroidSurfaceKHR(VkInstance instance, VkAndroidSurfaceCreateInfoKHR* pCreateInfo, IntPtr pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, VkAndroidSurfaceCreateInfoKHR*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateAndroidSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateAndroidSurfaceKHR(VkInstance instance, VkAndroidSurfaceCreateInfoKHR* pCreateInfo, IntPtr pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkAndroidSurfaceCreateInfoKHR*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateAndroidSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateAndroidSurfaceKHR(VkInstance instance, ref VkAndroidSurfaceCreateInfoKHR pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkAndroidSurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkAndroidSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateAndroidSurfaceKHR_ptr)(instance, ptr, pAllocator, pSurface);
		}
	}

	public unsafe static VkResult vkCreateAndroidSurfaceKHR(VkInstance instance, ref VkAndroidSurfaceCreateInfoKHR pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkAndroidSurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkAndroidSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateAndroidSurfaceKHR_ptr)(instance, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateAndroidSurfaceKHR(VkInstance instance, ref VkAndroidSurfaceCreateInfoKHR pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkAndroidSurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkAndroidSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateAndroidSurfaceKHR_ptr)(instance, ptr, ptr2, pSurface);
			}
		}
	}

	public unsafe static VkResult vkCreateAndroidSurfaceKHR(VkInstance instance, ref VkAndroidSurfaceCreateInfoKHR pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkAndroidSurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkSurfaceKHR* ptr3 = &pSurface)
				{
					return ((delegate* unmanaged[Stdcall]<VkInstance, VkAndroidSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateAndroidSurfaceKHR_ptr)(instance, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreateAndroidSurfaceKHR(VkInstance instance, ref VkAndroidSurfaceCreateInfoKHR pCreateInfo, IntPtr pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkAndroidSurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkAndroidSurfaceCreateInfoKHR*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateAndroidSurfaceKHR_ptr)(instance, ptr, pAllocator, pSurface);
		}
	}

	public unsafe static VkResult vkCreateAndroidSurfaceKHR(VkInstance instance, ref VkAndroidSurfaceCreateInfoKHR pCreateInfo, IntPtr pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkAndroidSurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkAndroidSurfaceCreateInfoKHR*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateAndroidSurfaceKHR_ptr)(instance, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateAndroidSurfaceKHR(VkInstance instance, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateAndroidSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateAndroidSurfaceKHR(VkInstance instance, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateAndroidSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateAndroidSurfaceKHR(VkInstance instance, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateAndroidSurfaceKHR_ptr)(instance, pCreateInfo, ptr, pSurface);
		}
	}

	public unsafe static VkResult vkCreateAndroidSurfaceKHR(VkInstance instance, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateAndroidSurfaceKHR_ptr)(instance, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateAndroidSurfaceKHR(VkInstance instance, IntPtr pCreateInfo, IntPtr pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateAndroidSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateAndroidSurfaceKHR(VkInstance instance, IntPtr pCreateInfo, IntPtr pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateAndroidSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateBuffer(VkDevice device, VkBufferCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkBuffer* pBuffer)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkBufferCreateInfo*, VkAllocationCallbacks*, VkBuffer*, VkResult>)vkCreateBuffer_ptr)(device, pCreateInfo, pAllocator, pBuffer);
	}

	public unsafe static VkResult vkCreateBuffer(VkDevice device, VkBufferCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, out VkBuffer pBuffer)
	{
		fixed (VkBuffer* ptr = &pBuffer)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkBufferCreateInfo*, VkAllocationCallbacks*, VkBuffer*, VkResult>)vkCreateBuffer_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateBuffer(VkDevice device, VkBufferCreateInfo* pCreateInfo, ref VkAllocationCallbacks pAllocator, VkBuffer* pBuffer)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkBufferCreateInfo*, VkAllocationCallbacks*, VkBuffer*, VkResult>)vkCreateBuffer_ptr)(device, pCreateInfo, ptr, pBuffer);
		}
	}

	public unsafe static VkResult vkCreateBuffer(VkDevice device, VkBufferCreateInfo* pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkBuffer pBuffer)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkBuffer* ptr2 = &pBuffer)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkBufferCreateInfo*, VkAllocationCallbacks*, VkBuffer*, VkResult>)vkCreateBuffer_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateBuffer(VkDevice device, VkBufferCreateInfo* pCreateInfo, IntPtr pAllocator, VkBuffer* pBuffer)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkBufferCreateInfo*, IntPtr, VkBuffer*, VkResult>)vkCreateBuffer_ptr)(device, pCreateInfo, pAllocator, pBuffer);
	}

	public unsafe static VkResult vkCreateBuffer(VkDevice device, VkBufferCreateInfo* pCreateInfo, IntPtr pAllocator, out VkBuffer pBuffer)
	{
		fixed (VkBuffer* ptr = &pBuffer)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkBufferCreateInfo*, IntPtr, VkBuffer*, VkResult>)vkCreateBuffer_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateBuffer(VkDevice device, ref VkBufferCreateInfo pCreateInfo, VkAllocationCallbacks* pAllocator, VkBuffer* pBuffer)
	{
		fixed (VkBufferCreateInfo* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkBufferCreateInfo*, VkAllocationCallbacks*, VkBuffer*, VkResult>)vkCreateBuffer_ptr)(device, ptr, pAllocator, pBuffer);
		}
	}

	public unsafe static VkResult vkCreateBuffer(VkDevice device, ref VkBufferCreateInfo pCreateInfo, VkAllocationCallbacks* pAllocator, out VkBuffer pBuffer)
	{
		fixed (VkBufferCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkBuffer* ptr2 = &pBuffer)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkBufferCreateInfo*, VkAllocationCallbacks*, VkBuffer*, VkResult>)vkCreateBuffer_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateBuffer(VkDevice device, ref VkBufferCreateInfo pCreateInfo, ref VkAllocationCallbacks pAllocator, VkBuffer* pBuffer)
	{
		fixed (VkBufferCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkBufferCreateInfo*, VkAllocationCallbacks*, VkBuffer*, VkResult>)vkCreateBuffer_ptr)(device, ptr, ptr2, pBuffer);
			}
		}
	}

	public unsafe static VkResult vkCreateBuffer(VkDevice device, ref VkBufferCreateInfo pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkBuffer pBuffer)
	{
		fixed (VkBufferCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkBuffer* ptr3 = &pBuffer)
				{
					return ((delegate* unmanaged[Stdcall]<VkDevice, VkBufferCreateInfo*, VkAllocationCallbacks*, VkBuffer*, VkResult>)vkCreateBuffer_ptr)(device, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreateBuffer(VkDevice device, ref VkBufferCreateInfo pCreateInfo, IntPtr pAllocator, VkBuffer* pBuffer)
	{
		fixed (VkBufferCreateInfo* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkBufferCreateInfo*, IntPtr, VkBuffer*, VkResult>)vkCreateBuffer_ptr)(device, ptr, pAllocator, pBuffer);
		}
	}

	public unsafe static VkResult vkCreateBuffer(VkDevice device, ref VkBufferCreateInfo pCreateInfo, IntPtr pAllocator, out VkBuffer pBuffer)
	{
		fixed (VkBufferCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkBuffer* ptr2 = &pBuffer)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkBufferCreateInfo*, IntPtr, VkBuffer*, VkResult>)vkCreateBuffer_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateBuffer(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, VkBuffer* pBuffer)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkBuffer*, VkResult>)vkCreateBuffer_ptr)(device, pCreateInfo, pAllocator, pBuffer);
	}

	public unsafe static VkResult vkCreateBuffer(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, out VkBuffer pBuffer)
	{
		fixed (VkBuffer* ptr = &pBuffer)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkBuffer*, VkResult>)vkCreateBuffer_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateBuffer(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, VkBuffer* pBuffer)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkBuffer*, VkResult>)vkCreateBuffer_ptr)(device, pCreateInfo, ptr, pBuffer);
		}
	}

	public unsafe static VkResult vkCreateBuffer(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkBuffer pBuffer)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkBuffer* ptr2 = &pBuffer)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkBuffer*, VkResult>)vkCreateBuffer_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateBuffer(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, VkBuffer* pBuffer)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkBuffer*, VkResult>)vkCreateBuffer_ptr)(device, pCreateInfo, pAllocator, pBuffer);
	}

	public unsafe static VkResult vkCreateBuffer(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, out VkBuffer pBuffer)
	{
		fixed (VkBuffer* ptr = &pBuffer)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkBuffer*, VkResult>)vkCreateBuffer_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateBufferView(VkDevice device, VkBufferViewCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkBufferView* pView)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkBufferViewCreateInfo*, VkAllocationCallbacks*, VkBufferView*, VkResult>)vkCreateBufferView_ptr)(device, pCreateInfo, pAllocator, pView);
	}

	public unsafe static VkResult vkCreateBufferView(VkDevice device, VkBufferViewCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, out VkBufferView pView)
	{
		fixed (VkBufferView* ptr = &pView)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkBufferViewCreateInfo*, VkAllocationCallbacks*, VkBufferView*, VkResult>)vkCreateBufferView_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateBufferView(VkDevice device, VkBufferViewCreateInfo* pCreateInfo, ref VkAllocationCallbacks pAllocator, VkBufferView* pView)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkBufferViewCreateInfo*, VkAllocationCallbacks*, VkBufferView*, VkResult>)vkCreateBufferView_ptr)(device, pCreateInfo, ptr, pView);
		}
	}

	public unsafe static VkResult vkCreateBufferView(VkDevice device, VkBufferViewCreateInfo* pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkBufferView pView)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkBufferView* ptr2 = &pView)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkBufferViewCreateInfo*, VkAllocationCallbacks*, VkBufferView*, VkResult>)vkCreateBufferView_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateBufferView(VkDevice device, VkBufferViewCreateInfo* pCreateInfo, IntPtr pAllocator, VkBufferView* pView)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkBufferViewCreateInfo*, IntPtr, VkBufferView*, VkResult>)vkCreateBufferView_ptr)(device, pCreateInfo, pAllocator, pView);
	}

	public unsafe static VkResult vkCreateBufferView(VkDevice device, VkBufferViewCreateInfo* pCreateInfo, IntPtr pAllocator, out VkBufferView pView)
	{
		fixed (VkBufferView* ptr = &pView)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkBufferViewCreateInfo*, IntPtr, VkBufferView*, VkResult>)vkCreateBufferView_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateBufferView(VkDevice device, ref VkBufferViewCreateInfo pCreateInfo, VkAllocationCallbacks* pAllocator, VkBufferView* pView)
	{
		fixed (VkBufferViewCreateInfo* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkBufferViewCreateInfo*, VkAllocationCallbacks*, VkBufferView*, VkResult>)vkCreateBufferView_ptr)(device, ptr, pAllocator, pView);
		}
	}

	public unsafe static VkResult vkCreateBufferView(VkDevice device, ref VkBufferViewCreateInfo pCreateInfo, VkAllocationCallbacks* pAllocator, out VkBufferView pView)
	{
		fixed (VkBufferViewCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkBufferView* ptr2 = &pView)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkBufferViewCreateInfo*, VkAllocationCallbacks*, VkBufferView*, VkResult>)vkCreateBufferView_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateBufferView(VkDevice device, ref VkBufferViewCreateInfo pCreateInfo, ref VkAllocationCallbacks pAllocator, VkBufferView* pView)
	{
		fixed (VkBufferViewCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkBufferViewCreateInfo*, VkAllocationCallbacks*, VkBufferView*, VkResult>)vkCreateBufferView_ptr)(device, ptr, ptr2, pView);
			}
		}
	}

	public unsafe static VkResult vkCreateBufferView(VkDevice device, ref VkBufferViewCreateInfo pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkBufferView pView)
	{
		fixed (VkBufferViewCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkBufferView* ptr3 = &pView)
				{
					return ((delegate* unmanaged[Stdcall]<VkDevice, VkBufferViewCreateInfo*, VkAllocationCallbacks*, VkBufferView*, VkResult>)vkCreateBufferView_ptr)(device, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreateBufferView(VkDevice device, ref VkBufferViewCreateInfo pCreateInfo, IntPtr pAllocator, VkBufferView* pView)
	{
		fixed (VkBufferViewCreateInfo* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkBufferViewCreateInfo*, IntPtr, VkBufferView*, VkResult>)vkCreateBufferView_ptr)(device, ptr, pAllocator, pView);
		}
	}

	public unsafe static VkResult vkCreateBufferView(VkDevice device, ref VkBufferViewCreateInfo pCreateInfo, IntPtr pAllocator, out VkBufferView pView)
	{
		fixed (VkBufferViewCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkBufferView* ptr2 = &pView)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkBufferViewCreateInfo*, IntPtr, VkBufferView*, VkResult>)vkCreateBufferView_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateBufferView(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, VkBufferView* pView)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkBufferView*, VkResult>)vkCreateBufferView_ptr)(device, pCreateInfo, pAllocator, pView);
	}

	public unsafe static VkResult vkCreateBufferView(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, out VkBufferView pView)
	{
		fixed (VkBufferView* ptr = &pView)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkBufferView*, VkResult>)vkCreateBufferView_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateBufferView(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, VkBufferView* pView)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkBufferView*, VkResult>)vkCreateBufferView_ptr)(device, pCreateInfo, ptr, pView);
		}
	}

	public unsafe static VkResult vkCreateBufferView(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkBufferView pView)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkBufferView* ptr2 = &pView)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkBufferView*, VkResult>)vkCreateBufferView_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateBufferView(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, VkBufferView* pView)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkBufferView*, VkResult>)vkCreateBufferView_ptr)(device, pCreateInfo, pAllocator, pView);
	}

	public unsafe static VkResult vkCreateBufferView(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, out VkBufferView pView)
	{
		fixed (VkBufferView* ptr = &pView)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkBufferView*, VkResult>)vkCreateBufferView_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateCommandPool(VkDevice device, VkCommandPoolCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkCommandPool* pCommandPool)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkCommandPoolCreateInfo*, VkAllocationCallbacks*, VkCommandPool*, VkResult>)vkCreateCommandPool_ptr)(device, pCreateInfo, pAllocator, pCommandPool);
	}

	public unsafe static VkResult vkCreateCommandPool(VkDevice device, VkCommandPoolCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, out VkCommandPool pCommandPool)
	{
		fixed (VkCommandPool* ptr = &pCommandPool)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkCommandPoolCreateInfo*, VkAllocationCallbacks*, VkCommandPool*, VkResult>)vkCreateCommandPool_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateCommandPool(VkDevice device, VkCommandPoolCreateInfo* pCreateInfo, ref VkAllocationCallbacks pAllocator, VkCommandPool* pCommandPool)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkCommandPoolCreateInfo*, VkAllocationCallbacks*, VkCommandPool*, VkResult>)vkCreateCommandPool_ptr)(device, pCreateInfo, ptr, pCommandPool);
		}
	}

	public unsafe static VkResult vkCreateCommandPool(VkDevice device, VkCommandPoolCreateInfo* pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkCommandPool pCommandPool)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkCommandPool* ptr2 = &pCommandPool)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkCommandPoolCreateInfo*, VkAllocationCallbacks*, VkCommandPool*, VkResult>)vkCreateCommandPool_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateCommandPool(VkDevice device, VkCommandPoolCreateInfo* pCreateInfo, IntPtr pAllocator, VkCommandPool* pCommandPool)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkCommandPoolCreateInfo*, IntPtr, VkCommandPool*, VkResult>)vkCreateCommandPool_ptr)(device, pCreateInfo, pAllocator, pCommandPool);
	}

	public unsafe static VkResult vkCreateCommandPool(VkDevice device, VkCommandPoolCreateInfo* pCreateInfo, IntPtr pAllocator, out VkCommandPool pCommandPool)
	{
		fixed (VkCommandPool* ptr = &pCommandPool)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkCommandPoolCreateInfo*, IntPtr, VkCommandPool*, VkResult>)vkCreateCommandPool_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateCommandPool(VkDevice device, ref VkCommandPoolCreateInfo pCreateInfo, VkAllocationCallbacks* pAllocator, VkCommandPool* pCommandPool)
	{
		fixed (VkCommandPoolCreateInfo* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkCommandPoolCreateInfo*, VkAllocationCallbacks*, VkCommandPool*, VkResult>)vkCreateCommandPool_ptr)(device, ptr, pAllocator, pCommandPool);
		}
	}

	public unsafe static VkResult vkCreateCommandPool(VkDevice device, ref VkCommandPoolCreateInfo pCreateInfo, VkAllocationCallbacks* pAllocator, out VkCommandPool pCommandPool)
	{
		fixed (VkCommandPoolCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkCommandPool* ptr2 = &pCommandPool)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkCommandPoolCreateInfo*, VkAllocationCallbacks*, VkCommandPool*, VkResult>)vkCreateCommandPool_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateCommandPool(VkDevice device, ref VkCommandPoolCreateInfo pCreateInfo, ref VkAllocationCallbacks pAllocator, VkCommandPool* pCommandPool)
	{
		fixed (VkCommandPoolCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkCommandPoolCreateInfo*, VkAllocationCallbacks*, VkCommandPool*, VkResult>)vkCreateCommandPool_ptr)(device, ptr, ptr2, pCommandPool);
			}
		}
	}

	public unsafe static VkResult vkCreateCommandPool(VkDevice device, ref VkCommandPoolCreateInfo pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkCommandPool pCommandPool)
	{
		fixed (VkCommandPoolCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkCommandPool* ptr3 = &pCommandPool)
				{
					return ((delegate* unmanaged[Stdcall]<VkDevice, VkCommandPoolCreateInfo*, VkAllocationCallbacks*, VkCommandPool*, VkResult>)vkCreateCommandPool_ptr)(device, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreateCommandPool(VkDevice device, ref VkCommandPoolCreateInfo pCreateInfo, IntPtr pAllocator, VkCommandPool* pCommandPool)
	{
		fixed (VkCommandPoolCreateInfo* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkCommandPoolCreateInfo*, IntPtr, VkCommandPool*, VkResult>)vkCreateCommandPool_ptr)(device, ptr, pAllocator, pCommandPool);
		}
	}

	public unsafe static VkResult vkCreateCommandPool(VkDevice device, ref VkCommandPoolCreateInfo pCreateInfo, IntPtr pAllocator, out VkCommandPool pCommandPool)
	{
		fixed (VkCommandPoolCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkCommandPool* ptr2 = &pCommandPool)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkCommandPoolCreateInfo*, IntPtr, VkCommandPool*, VkResult>)vkCreateCommandPool_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateCommandPool(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, VkCommandPool* pCommandPool)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkCommandPool*, VkResult>)vkCreateCommandPool_ptr)(device, pCreateInfo, pAllocator, pCommandPool);
	}

	public unsafe static VkResult vkCreateCommandPool(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, out VkCommandPool pCommandPool)
	{
		fixed (VkCommandPool* ptr = &pCommandPool)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkCommandPool*, VkResult>)vkCreateCommandPool_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateCommandPool(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, VkCommandPool* pCommandPool)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkCommandPool*, VkResult>)vkCreateCommandPool_ptr)(device, pCreateInfo, ptr, pCommandPool);
		}
	}

	public unsafe static VkResult vkCreateCommandPool(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkCommandPool pCommandPool)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkCommandPool* ptr2 = &pCommandPool)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkCommandPool*, VkResult>)vkCreateCommandPool_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateCommandPool(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, VkCommandPool* pCommandPool)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkCommandPool*, VkResult>)vkCreateCommandPool_ptr)(device, pCreateInfo, pAllocator, pCommandPool);
	}

	public unsafe static VkResult vkCreateCommandPool(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, out VkCommandPool pCommandPool)
	{
		fixed (VkCommandPool* ptr = &pCommandPool)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkCommandPool*, VkResult>)vkCreateCommandPool_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateComputePipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, VkComputePipelineCreateInfo* pCreateInfos, VkAllocationCallbacks* pAllocator, VkPipeline* pPipelines)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, VkComputePipelineCreateInfo*, VkAllocationCallbacks*, VkPipeline*, VkResult>)vkCreateComputePipelines_ptr)(device, pipelineCache, createInfoCount, pCreateInfos, pAllocator, pPipelines);
	}

	public unsafe static VkResult vkCreateComputePipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, VkComputePipelineCreateInfo* pCreateInfos, VkAllocationCallbacks* pAllocator, out VkPipeline pPipelines)
	{
		fixed (VkPipeline* ptr = &pPipelines)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, VkComputePipelineCreateInfo*, VkAllocationCallbacks*, VkPipeline*, VkResult>)vkCreateComputePipelines_ptr)(device, pipelineCache, createInfoCount, pCreateInfos, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateComputePipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, VkComputePipelineCreateInfo* pCreateInfos, ref VkAllocationCallbacks pAllocator, VkPipeline* pPipelines)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, VkComputePipelineCreateInfo*, VkAllocationCallbacks*, VkPipeline*, VkResult>)vkCreateComputePipelines_ptr)(device, pipelineCache, createInfoCount, pCreateInfos, ptr, pPipelines);
		}
	}

	public unsafe static VkResult vkCreateComputePipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, VkComputePipelineCreateInfo* pCreateInfos, ref VkAllocationCallbacks pAllocator, out VkPipeline pPipelines)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkPipeline* ptr2 = &pPipelines)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, VkComputePipelineCreateInfo*, VkAllocationCallbacks*, VkPipeline*, VkResult>)vkCreateComputePipelines_ptr)(device, pipelineCache, createInfoCount, pCreateInfos, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateComputePipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, VkComputePipelineCreateInfo* pCreateInfos, IntPtr pAllocator, VkPipeline* pPipelines)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, VkComputePipelineCreateInfo*, IntPtr, VkPipeline*, VkResult>)vkCreateComputePipelines_ptr)(device, pipelineCache, createInfoCount, pCreateInfos, pAllocator, pPipelines);
	}

	public unsafe static VkResult vkCreateComputePipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, VkComputePipelineCreateInfo* pCreateInfos, IntPtr pAllocator, out VkPipeline pPipelines)
	{
		fixed (VkPipeline* ptr = &pPipelines)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, VkComputePipelineCreateInfo*, IntPtr, VkPipeline*, VkResult>)vkCreateComputePipelines_ptr)(device, pipelineCache, createInfoCount, pCreateInfos, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateComputePipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, ref VkComputePipelineCreateInfo pCreateInfos, VkAllocationCallbacks* pAllocator, VkPipeline* pPipelines)
	{
		fixed (VkComputePipelineCreateInfo* ptr = &pCreateInfos)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, VkComputePipelineCreateInfo*, VkAllocationCallbacks*, VkPipeline*, VkResult>)vkCreateComputePipelines_ptr)(device, pipelineCache, createInfoCount, ptr, pAllocator, pPipelines);
		}
	}

	public unsafe static VkResult vkCreateComputePipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, ref VkComputePipelineCreateInfo pCreateInfos, VkAllocationCallbacks* pAllocator, out VkPipeline pPipelines)
	{
		fixed (VkComputePipelineCreateInfo* ptr = &pCreateInfos)
		{
			fixed (VkPipeline* ptr2 = &pPipelines)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, VkComputePipelineCreateInfo*, VkAllocationCallbacks*, VkPipeline*, VkResult>)vkCreateComputePipelines_ptr)(device, pipelineCache, createInfoCount, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateComputePipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, ref VkComputePipelineCreateInfo pCreateInfos, ref VkAllocationCallbacks pAllocator, VkPipeline* pPipelines)
	{
		fixed (VkComputePipelineCreateInfo* ptr = &pCreateInfos)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, VkComputePipelineCreateInfo*, VkAllocationCallbacks*, VkPipeline*, VkResult>)vkCreateComputePipelines_ptr)(device, pipelineCache, createInfoCount, ptr, ptr2, pPipelines);
			}
		}
	}

	public unsafe static VkResult vkCreateComputePipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, ref VkComputePipelineCreateInfo pCreateInfos, ref VkAllocationCallbacks pAllocator, out VkPipeline pPipelines)
	{
		fixed (VkComputePipelineCreateInfo* ptr = &pCreateInfos)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkPipeline* ptr3 = &pPipelines)
				{
					return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, VkComputePipelineCreateInfo*, VkAllocationCallbacks*, VkPipeline*, VkResult>)vkCreateComputePipelines_ptr)(device, pipelineCache, createInfoCount, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreateComputePipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, ref VkComputePipelineCreateInfo pCreateInfos, IntPtr pAllocator, VkPipeline* pPipelines)
	{
		fixed (VkComputePipelineCreateInfo* ptr = &pCreateInfos)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, VkComputePipelineCreateInfo*, IntPtr, VkPipeline*, VkResult>)vkCreateComputePipelines_ptr)(device, pipelineCache, createInfoCount, ptr, pAllocator, pPipelines);
		}
	}

	public unsafe static VkResult vkCreateComputePipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, ref VkComputePipelineCreateInfo pCreateInfos, IntPtr pAllocator, out VkPipeline pPipelines)
	{
		fixed (VkComputePipelineCreateInfo* ptr = &pCreateInfos)
		{
			fixed (VkPipeline* ptr2 = &pPipelines)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, VkComputePipelineCreateInfo*, IntPtr, VkPipeline*, VkResult>)vkCreateComputePipelines_ptr)(device, pipelineCache, createInfoCount, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateComputePipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, IntPtr pCreateInfos, VkAllocationCallbacks* pAllocator, VkPipeline* pPipelines)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, IntPtr, VkAllocationCallbacks*, VkPipeline*, VkResult>)vkCreateComputePipelines_ptr)(device, pipelineCache, createInfoCount, pCreateInfos, pAllocator, pPipelines);
	}

	public unsafe static VkResult vkCreateComputePipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, IntPtr pCreateInfos, VkAllocationCallbacks* pAllocator, out VkPipeline pPipelines)
	{
		fixed (VkPipeline* ptr = &pPipelines)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, IntPtr, VkAllocationCallbacks*, VkPipeline*, VkResult>)vkCreateComputePipelines_ptr)(device, pipelineCache, createInfoCount, pCreateInfos, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateComputePipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, IntPtr pCreateInfos, ref VkAllocationCallbacks pAllocator, VkPipeline* pPipelines)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, IntPtr, VkAllocationCallbacks*, VkPipeline*, VkResult>)vkCreateComputePipelines_ptr)(device, pipelineCache, createInfoCount, pCreateInfos, ptr, pPipelines);
		}
	}

	public unsafe static VkResult vkCreateComputePipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, IntPtr pCreateInfos, ref VkAllocationCallbacks pAllocator, out VkPipeline pPipelines)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkPipeline* ptr2 = &pPipelines)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, IntPtr, VkAllocationCallbacks*, VkPipeline*, VkResult>)vkCreateComputePipelines_ptr)(device, pipelineCache, createInfoCount, pCreateInfos, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateComputePipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, IntPtr pCreateInfos, IntPtr pAllocator, VkPipeline* pPipelines)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, IntPtr, IntPtr, VkPipeline*, VkResult>)vkCreateComputePipelines_ptr)(device, pipelineCache, createInfoCount, pCreateInfos, pAllocator, pPipelines);
	}

	public unsafe static VkResult vkCreateComputePipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, IntPtr pCreateInfos, IntPtr pAllocator, out VkPipeline pPipelines)
	{
		fixed (VkPipeline* ptr = &pPipelines)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, IntPtr, IntPtr, VkPipeline*, VkResult>)vkCreateComputePipelines_ptr)(device, pipelineCache, createInfoCount, pCreateInfos, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateComputePipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, VkComputePipelineCreateInfo[] pCreateInfos, VkAllocationCallbacks* pAllocator, VkPipeline* pPipelines)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, VkComputePipelineCreateInfo[], VkAllocationCallbacks*, VkPipeline*, VkResult>)vkCreateComputePipelines_ptr)(device, pipelineCache, createInfoCount, pCreateInfos, pAllocator, pPipelines);
	}

	public unsafe static VkResult vkCreateComputePipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, VkComputePipelineCreateInfo[] pCreateInfos, VkAllocationCallbacks* pAllocator, out VkPipeline pPipelines)
	{
		fixed (VkPipeline* ptr = &pPipelines)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, VkComputePipelineCreateInfo[], VkAllocationCallbacks*, VkPipeline*, VkResult>)vkCreateComputePipelines_ptr)(device, pipelineCache, createInfoCount, pCreateInfos, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateComputePipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, VkComputePipelineCreateInfo[] pCreateInfos, ref VkAllocationCallbacks pAllocator, VkPipeline* pPipelines)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, VkComputePipelineCreateInfo[], VkAllocationCallbacks*, VkPipeline*, VkResult>)vkCreateComputePipelines_ptr)(device, pipelineCache, createInfoCount, pCreateInfos, ptr, pPipelines);
		}
	}

	public unsafe static VkResult vkCreateComputePipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, VkComputePipelineCreateInfo[] pCreateInfos, ref VkAllocationCallbacks pAllocator, out VkPipeline pPipelines)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkPipeline* ptr2 = &pPipelines)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, VkComputePipelineCreateInfo[], VkAllocationCallbacks*, VkPipeline*, VkResult>)vkCreateComputePipelines_ptr)(device, pipelineCache, createInfoCount, pCreateInfos, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateComputePipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, VkComputePipelineCreateInfo[] pCreateInfos, IntPtr pAllocator, VkPipeline* pPipelines)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, VkComputePipelineCreateInfo[], IntPtr, VkPipeline*, VkResult>)vkCreateComputePipelines_ptr)(device, pipelineCache, createInfoCount, pCreateInfos, pAllocator, pPipelines);
	}

	public unsafe static VkResult vkCreateComputePipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, VkComputePipelineCreateInfo[] pCreateInfos, IntPtr pAllocator, out VkPipeline pPipelines)
	{
		fixed (VkPipeline* ptr = &pPipelines)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, VkComputePipelineCreateInfo[], IntPtr, VkPipeline*, VkResult>)vkCreateComputePipelines_ptr)(device, pipelineCache, createInfoCount, pCreateInfos, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateDebugReportCallbackEXT(VkInstance instance, VkDebugReportCallbackCreateInfoEXT* pCreateInfo, VkAllocationCallbacks* pAllocator, VkDebugReportCallbackEXT* pCallback)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, VkDebugReportCallbackCreateInfoEXT*, VkAllocationCallbacks*, VkDebugReportCallbackEXT*, VkResult>)vkCreateDebugReportCallbackEXT_ptr)(instance, pCreateInfo, pAllocator, pCallback);
	}

	public unsafe static VkResult vkCreateDebugReportCallbackEXT(VkInstance instance, VkDebugReportCallbackCreateInfoEXT* pCreateInfo, VkAllocationCallbacks* pAllocator, out VkDebugReportCallbackEXT pCallback)
	{
		fixed (VkDebugReportCallbackEXT* ptr = &pCallback)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkDebugReportCallbackCreateInfoEXT*, VkAllocationCallbacks*, VkDebugReportCallbackEXT*, VkResult>)vkCreateDebugReportCallbackEXT_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateDebugReportCallbackEXT(VkInstance instance, VkDebugReportCallbackCreateInfoEXT* pCreateInfo, ref VkAllocationCallbacks pAllocator, VkDebugReportCallbackEXT* pCallback)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkDebugReportCallbackCreateInfoEXT*, VkAllocationCallbacks*, VkDebugReportCallbackEXT*, VkResult>)vkCreateDebugReportCallbackEXT_ptr)(instance, pCreateInfo, ptr, pCallback);
		}
	}

	public unsafe static VkResult vkCreateDebugReportCallbackEXT(VkInstance instance, VkDebugReportCallbackCreateInfoEXT* pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkDebugReportCallbackEXT pCallback)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkDebugReportCallbackEXT* ptr2 = &pCallback)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkDebugReportCallbackCreateInfoEXT*, VkAllocationCallbacks*, VkDebugReportCallbackEXT*, VkResult>)vkCreateDebugReportCallbackEXT_ptr)(instance, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateDebugReportCallbackEXT(VkInstance instance, VkDebugReportCallbackCreateInfoEXT* pCreateInfo, IntPtr pAllocator, VkDebugReportCallbackEXT* pCallback)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, VkDebugReportCallbackCreateInfoEXT*, IntPtr, VkDebugReportCallbackEXT*, VkResult>)vkCreateDebugReportCallbackEXT_ptr)(instance, pCreateInfo, pAllocator, pCallback);
	}

	public unsafe static VkResult vkCreateDebugReportCallbackEXT(VkInstance instance, VkDebugReportCallbackCreateInfoEXT* pCreateInfo, IntPtr pAllocator, out VkDebugReportCallbackEXT pCallback)
	{
		fixed (VkDebugReportCallbackEXT* ptr = &pCallback)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkDebugReportCallbackCreateInfoEXT*, IntPtr, VkDebugReportCallbackEXT*, VkResult>)vkCreateDebugReportCallbackEXT_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateDebugReportCallbackEXT(VkInstance instance, ref VkDebugReportCallbackCreateInfoEXT pCreateInfo, VkAllocationCallbacks* pAllocator, VkDebugReportCallbackEXT* pCallback)
	{
		fixed (VkDebugReportCallbackCreateInfoEXT* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkDebugReportCallbackCreateInfoEXT*, VkAllocationCallbacks*, VkDebugReportCallbackEXT*, VkResult>)vkCreateDebugReportCallbackEXT_ptr)(instance, ptr, pAllocator, pCallback);
		}
	}

	public unsafe static VkResult vkCreateDebugReportCallbackEXT(VkInstance instance, ref VkDebugReportCallbackCreateInfoEXT pCreateInfo, VkAllocationCallbacks* pAllocator, out VkDebugReportCallbackEXT pCallback)
	{
		fixed (VkDebugReportCallbackCreateInfoEXT* ptr = &pCreateInfo)
		{
			fixed (VkDebugReportCallbackEXT* ptr2 = &pCallback)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkDebugReportCallbackCreateInfoEXT*, VkAllocationCallbacks*, VkDebugReportCallbackEXT*, VkResult>)vkCreateDebugReportCallbackEXT_ptr)(instance, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateDebugReportCallbackEXT(VkInstance instance, ref VkDebugReportCallbackCreateInfoEXT pCreateInfo, ref VkAllocationCallbacks pAllocator, VkDebugReportCallbackEXT* pCallback)
	{
		fixed (VkDebugReportCallbackCreateInfoEXT* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkDebugReportCallbackCreateInfoEXT*, VkAllocationCallbacks*, VkDebugReportCallbackEXT*, VkResult>)vkCreateDebugReportCallbackEXT_ptr)(instance, ptr, ptr2, pCallback);
			}
		}
	}

	public unsafe static VkResult vkCreateDebugReportCallbackEXT(VkInstance instance, ref VkDebugReportCallbackCreateInfoEXT pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkDebugReportCallbackEXT pCallback)
	{
		fixed (VkDebugReportCallbackCreateInfoEXT* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkDebugReportCallbackEXT* ptr3 = &pCallback)
				{
					return ((delegate* unmanaged[Stdcall]<VkInstance, VkDebugReportCallbackCreateInfoEXT*, VkAllocationCallbacks*, VkDebugReportCallbackEXT*, VkResult>)vkCreateDebugReportCallbackEXT_ptr)(instance, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreateDebugReportCallbackEXT(VkInstance instance, ref VkDebugReportCallbackCreateInfoEXT pCreateInfo, IntPtr pAllocator, VkDebugReportCallbackEXT* pCallback)
	{
		fixed (VkDebugReportCallbackCreateInfoEXT* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkDebugReportCallbackCreateInfoEXT*, IntPtr, VkDebugReportCallbackEXT*, VkResult>)vkCreateDebugReportCallbackEXT_ptr)(instance, ptr, pAllocator, pCallback);
		}
	}

	public unsafe static VkResult vkCreateDebugReportCallbackEXT(VkInstance instance, ref VkDebugReportCallbackCreateInfoEXT pCreateInfo, IntPtr pAllocator, out VkDebugReportCallbackEXT pCallback)
	{
		fixed (VkDebugReportCallbackCreateInfoEXT* ptr = &pCreateInfo)
		{
			fixed (VkDebugReportCallbackEXT* ptr2 = &pCallback)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkDebugReportCallbackCreateInfoEXT*, IntPtr, VkDebugReportCallbackEXT*, VkResult>)vkCreateDebugReportCallbackEXT_ptr)(instance, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateDebugReportCallbackEXT(VkInstance instance, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, VkDebugReportCallbackEXT* pCallback)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkDebugReportCallbackEXT*, VkResult>)vkCreateDebugReportCallbackEXT_ptr)(instance, pCreateInfo, pAllocator, pCallback);
	}

	public unsafe static VkResult vkCreateDebugReportCallbackEXT(VkInstance instance, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, out VkDebugReportCallbackEXT pCallback)
	{
		fixed (VkDebugReportCallbackEXT* ptr = &pCallback)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkDebugReportCallbackEXT*, VkResult>)vkCreateDebugReportCallbackEXT_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateDebugReportCallbackEXT(VkInstance instance, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, VkDebugReportCallbackEXT* pCallback)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkDebugReportCallbackEXT*, VkResult>)vkCreateDebugReportCallbackEXT_ptr)(instance, pCreateInfo, ptr, pCallback);
		}
	}

	public unsafe static VkResult vkCreateDebugReportCallbackEXT(VkInstance instance, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkDebugReportCallbackEXT pCallback)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkDebugReportCallbackEXT* ptr2 = &pCallback)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkDebugReportCallbackEXT*, VkResult>)vkCreateDebugReportCallbackEXT_ptr)(instance, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateDebugReportCallbackEXT(VkInstance instance, IntPtr pCreateInfo, IntPtr pAllocator, VkDebugReportCallbackEXT* pCallback)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, IntPtr, VkDebugReportCallbackEXT*, VkResult>)vkCreateDebugReportCallbackEXT_ptr)(instance, pCreateInfo, pAllocator, pCallback);
	}

	public unsafe static VkResult vkCreateDebugReportCallbackEXT(VkInstance instance, IntPtr pCreateInfo, IntPtr pAllocator, out VkDebugReportCallbackEXT pCallback)
	{
		fixed (VkDebugReportCallbackEXT* ptr = &pCallback)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, IntPtr, VkDebugReportCallbackEXT*, VkResult>)vkCreateDebugReportCallbackEXT_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateDescriptorPool(VkDevice device, VkDescriptorPoolCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkDescriptorPool* pDescriptorPool)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorPoolCreateInfo*, VkAllocationCallbacks*, VkDescriptorPool*, VkResult>)vkCreateDescriptorPool_ptr)(device, pCreateInfo, pAllocator, pDescriptorPool);
	}

	public unsafe static VkResult vkCreateDescriptorPool(VkDevice device, VkDescriptorPoolCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, out VkDescriptorPool pDescriptorPool)
	{
		fixed (VkDescriptorPool* ptr = &pDescriptorPool)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorPoolCreateInfo*, VkAllocationCallbacks*, VkDescriptorPool*, VkResult>)vkCreateDescriptorPool_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateDescriptorPool(VkDevice device, VkDescriptorPoolCreateInfo* pCreateInfo, ref VkAllocationCallbacks pAllocator, VkDescriptorPool* pDescriptorPool)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorPoolCreateInfo*, VkAllocationCallbacks*, VkDescriptorPool*, VkResult>)vkCreateDescriptorPool_ptr)(device, pCreateInfo, ptr, pDescriptorPool);
		}
	}

	public unsafe static VkResult vkCreateDescriptorPool(VkDevice device, VkDescriptorPoolCreateInfo* pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkDescriptorPool pDescriptorPool)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkDescriptorPool* ptr2 = &pDescriptorPool)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorPoolCreateInfo*, VkAllocationCallbacks*, VkDescriptorPool*, VkResult>)vkCreateDescriptorPool_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateDescriptorPool(VkDevice device, VkDescriptorPoolCreateInfo* pCreateInfo, IntPtr pAllocator, VkDescriptorPool* pDescriptorPool)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorPoolCreateInfo*, IntPtr, VkDescriptorPool*, VkResult>)vkCreateDescriptorPool_ptr)(device, pCreateInfo, pAllocator, pDescriptorPool);
	}

	public unsafe static VkResult vkCreateDescriptorPool(VkDevice device, VkDescriptorPoolCreateInfo* pCreateInfo, IntPtr pAllocator, out VkDescriptorPool pDescriptorPool)
	{
		fixed (VkDescriptorPool* ptr = &pDescriptorPool)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorPoolCreateInfo*, IntPtr, VkDescriptorPool*, VkResult>)vkCreateDescriptorPool_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateDescriptorPool(VkDevice device, ref VkDescriptorPoolCreateInfo pCreateInfo, VkAllocationCallbacks* pAllocator, VkDescriptorPool* pDescriptorPool)
	{
		fixed (VkDescriptorPoolCreateInfo* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorPoolCreateInfo*, VkAllocationCallbacks*, VkDescriptorPool*, VkResult>)vkCreateDescriptorPool_ptr)(device, ptr, pAllocator, pDescriptorPool);
		}
	}

	public unsafe static VkResult vkCreateDescriptorPool(VkDevice device, ref VkDescriptorPoolCreateInfo pCreateInfo, VkAllocationCallbacks* pAllocator, out VkDescriptorPool pDescriptorPool)
	{
		fixed (VkDescriptorPoolCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkDescriptorPool* ptr2 = &pDescriptorPool)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorPoolCreateInfo*, VkAllocationCallbacks*, VkDescriptorPool*, VkResult>)vkCreateDescriptorPool_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateDescriptorPool(VkDevice device, ref VkDescriptorPoolCreateInfo pCreateInfo, ref VkAllocationCallbacks pAllocator, VkDescriptorPool* pDescriptorPool)
	{
		fixed (VkDescriptorPoolCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorPoolCreateInfo*, VkAllocationCallbacks*, VkDescriptorPool*, VkResult>)vkCreateDescriptorPool_ptr)(device, ptr, ptr2, pDescriptorPool);
			}
		}
	}

	public unsafe static VkResult vkCreateDescriptorPool(VkDevice device, ref VkDescriptorPoolCreateInfo pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkDescriptorPool pDescriptorPool)
	{
		fixed (VkDescriptorPoolCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkDescriptorPool* ptr3 = &pDescriptorPool)
				{
					return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorPoolCreateInfo*, VkAllocationCallbacks*, VkDescriptorPool*, VkResult>)vkCreateDescriptorPool_ptr)(device, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreateDescriptorPool(VkDevice device, ref VkDescriptorPoolCreateInfo pCreateInfo, IntPtr pAllocator, VkDescriptorPool* pDescriptorPool)
	{
		fixed (VkDescriptorPoolCreateInfo* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorPoolCreateInfo*, IntPtr, VkDescriptorPool*, VkResult>)vkCreateDescriptorPool_ptr)(device, ptr, pAllocator, pDescriptorPool);
		}
	}

	public unsafe static VkResult vkCreateDescriptorPool(VkDevice device, ref VkDescriptorPoolCreateInfo pCreateInfo, IntPtr pAllocator, out VkDescriptorPool pDescriptorPool)
	{
		fixed (VkDescriptorPoolCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkDescriptorPool* ptr2 = &pDescriptorPool)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorPoolCreateInfo*, IntPtr, VkDescriptorPool*, VkResult>)vkCreateDescriptorPool_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateDescriptorPool(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, VkDescriptorPool* pDescriptorPool)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkDescriptorPool*, VkResult>)vkCreateDescriptorPool_ptr)(device, pCreateInfo, pAllocator, pDescriptorPool);
	}

	public unsafe static VkResult vkCreateDescriptorPool(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, out VkDescriptorPool pDescriptorPool)
	{
		fixed (VkDescriptorPool* ptr = &pDescriptorPool)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkDescriptorPool*, VkResult>)vkCreateDescriptorPool_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateDescriptorPool(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, VkDescriptorPool* pDescriptorPool)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkDescriptorPool*, VkResult>)vkCreateDescriptorPool_ptr)(device, pCreateInfo, ptr, pDescriptorPool);
		}
	}

	public unsafe static VkResult vkCreateDescriptorPool(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkDescriptorPool pDescriptorPool)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkDescriptorPool* ptr2 = &pDescriptorPool)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkDescriptorPool*, VkResult>)vkCreateDescriptorPool_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateDescriptorPool(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, VkDescriptorPool* pDescriptorPool)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkDescriptorPool*, VkResult>)vkCreateDescriptorPool_ptr)(device, pCreateInfo, pAllocator, pDescriptorPool);
	}

	public unsafe static VkResult vkCreateDescriptorPool(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, out VkDescriptorPool pDescriptorPool)
	{
		fixed (VkDescriptorPool* ptr = &pDescriptorPool)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkDescriptorPool*, VkResult>)vkCreateDescriptorPool_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateDescriptorSetLayout(VkDevice device, VkDescriptorSetLayoutCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkDescriptorSetLayout* pSetLayout)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorSetLayoutCreateInfo*, VkAllocationCallbacks*, VkDescriptorSetLayout*, VkResult>)vkCreateDescriptorSetLayout_ptr)(device, pCreateInfo, pAllocator, pSetLayout);
	}

	public unsafe static VkResult vkCreateDescriptorSetLayout(VkDevice device, VkDescriptorSetLayoutCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, out VkDescriptorSetLayout pSetLayout)
	{
		fixed (VkDescriptorSetLayout* ptr = &pSetLayout)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorSetLayoutCreateInfo*, VkAllocationCallbacks*, VkDescriptorSetLayout*, VkResult>)vkCreateDescriptorSetLayout_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateDescriptorSetLayout(VkDevice device, VkDescriptorSetLayoutCreateInfo* pCreateInfo, ref VkAllocationCallbacks pAllocator, VkDescriptorSetLayout* pSetLayout)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorSetLayoutCreateInfo*, VkAllocationCallbacks*, VkDescriptorSetLayout*, VkResult>)vkCreateDescriptorSetLayout_ptr)(device, pCreateInfo, ptr, pSetLayout);
		}
	}

	public unsafe static VkResult vkCreateDescriptorSetLayout(VkDevice device, VkDescriptorSetLayoutCreateInfo* pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkDescriptorSetLayout pSetLayout)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkDescriptorSetLayout* ptr2 = &pSetLayout)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorSetLayoutCreateInfo*, VkAllocationCallbacks*, VkDescriptorSetLayout*, VkResult>)vkCreateDescriptorSetLayout_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateDescriptorSetLayout(VkDevice device, VkDescriptorSetLayoutCreateInfo* pCreateInfo, IntPtr pAllocator, VkDescriptorSetLayout* pSetLayout)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorSetLayoutCreateInfo*, IntPtr, VkDescriptorSetLayout*, VkResult>)vkCreateDescriptorSetLayout_ptr)(device, pCreateInfo, pAllocator, pSetLayout);
	}

	public unsafe static VkResult vkCreateDescriptorSetLayout(VkDevice device, VkDescriptorSetLayoutCreateInfo* pCreateInfo, IntPtr pAllocator, out VkDescriptorSetLayout pSetLayout)
	{
		fixed (VkDescriptorSetLayout* ptr = &pSetLayout)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorSetLayoutCreateInfo*, IntPtr, VkDescriptorSetLayout*, VkResult>)vkCreateDescriptorSetLayout_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateDescriptorSetLayout(VkDevice device, ref VkDescriptorSetLayoutCreateInfo pCreateInfo, VkAllocationCallbacks* pAllocator, VkDescriptorSetLayout* pSetLayout)
	{
		fixed (VkDescriptorSetLayoutCreateInfo* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorSetLayoutCreateInfo*, VkAllocationCallbacks*, VkDescriptorSetLayout*, VkResult>)vkCreateDescriptorSetLayout_ptr)(device, ptr, pAllocator, pSetLayout);
		}
	}

	public unsafe static VkResult vkCreateDescriptorSetLayout(VkDevice device, ref VkDescriptorSetLayoutCreateInfo pCreateInfo, VkAllocationCallbacks* pAllocator, out VkDescriptorSetLayout pSetLayout)
	{
		fixed (VkDescriptorSetLayoutCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkDescriptorSetLayout* ptr2 = &pSetLayout)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorSetLayoutCreateInfo*, VkAllocationCallbacks*, VkDescriptorSetLayout*, VkResult>)vkCreateDescriptorSetLayout_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateDescriptorSetLayout(VkDevice device, ref VkDescriptorSetLayoutCreateInfo pCreateInfo, ref VkAllocationCallbacks pAllocator, VkDescriptorSetLayout* pSetLayout)
	{
		fixed (VkDescriptorSetLayoutCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorSetLayoutCreateInfo*, VkAllocationCallbacks*, VkDescriptorSetLayout*, VkResult>)vkCreateDescriptorSetLayout_ptr)(device, ptr, ptr2, pSetLayout);
			}
		}
	}

	public unsafe static VkResult vkCreateDescriptorSetLayout(VkDevice device, ref VkDescriptorSetLayoutCreateInfo pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkDescriptorSetLayout pSetLayout)
	{
		fixed (VkDescriptorSetLayoutCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkDescriptorSetLayout* ptr3 = &pSetLayout)
				{
					return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorSetLayoutCreateInfo*, VkAllocationCallbacks*, VkDescriptorSetLayout*, VkResult>)vkCreateDescriptorSetLayout_ptr)(device, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreateDescriptorSetLayout(VkDevice device, ref VkDescriptorSetLayoutCreateInfo pCreateInfo, IntPtr pAllocator, VkDescriptorSetLayout* pSetLayout)
	{
		fixed (VkDescriptorSetLayoutCreateInfo* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorSetLayoutCreateInfo*, IntPtr, VkDescriptorSetLayout*, VkResult>)vkCreateDescriptorSetLayout_ptr)(device, ptr, pAllocator, pSetLayout);
		}
	}

	public unsafe static VkResult vkCreateDescriptorSetLayout(VkDevice device, ref VkDescriptorSetLayoutCreateInfo pCreateInfo, IntPtr pAllocator, out VkDescriptorSetLayout pSetLayout)
	{
		fixed (VkDescriptorSetLayoutCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkDescriptorSetLayout* ptr2 = &pSetLayout)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorSetLayoutCreateInfo*, IntPtr, VkDescriptorSetLayout*, VkResult>)vkCreateDescriptorSetLayout_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateDescriptorSetLayout(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, VkDescriptorSetLayout* pSetLayout)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkDescriptorSetLayout*, VkResult>)vkCreateDescriptorSetLayout_ptr)(device, pCreateInfo, pAllocator, pSetLayout);
	}

	public unsafe static VkResult vkCreateDescriptorSetLayout(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, out VkDescriptorSetLayout pSetLayout)
	{
		fixed (VkDescriptorSetLayout* ptr = &pSetLayout)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkDescriptorSetLayout*, VkResult>)vkCreateDescriptorSetLayout_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateDescriptorSetLayout(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, VkDescriptorSetLayout* pSetLayout)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkDescriptorSetLayout*, VkResult>)vkCreateDescriptorSetLayout_ptr)(device, pCreateInfo, ptr, pSetLayout);
		}
	}

	public unsafe static VkResult vkCreateDescriptorSetLayout(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkDescriptorSetLayout pSetLayout)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkDescriptorSetLayout* ptr2 = &pSetLayout)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkDescriptorSetLayout*, VkResult>)vkCreateDescriptorSetLayout_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateDescriptorSetLayout(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, VkDescriptorSetLayout* pSetLayout)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkDescriptorSetLayout*, VkResult>)vkCreateDescriptorSetLayout_ptr)(device, pCreateInfo, pAllocator, pSetLayout);
	}

	public unsafe static VkResult vkCreateDescriptorSetLayout(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, out VkDescriptorSetLayout pSetLayout)
	{
		fixed (VkDescriptorSetLayout* ptr = &pSetLayout)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkDescriptorSetLayout*, VkResult>)vkCreateDescriptorSetLayout_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateDescriptorUpdateTemplateKHR(VkDevice device, VkDescriptorUpdateTemplateCreateInfoKHR* pCreateInfo, VkAllocationCallbacks* pAllocator, VkDescriptorUpdateTemplateKHR* pDescriptorUpdateTemplate)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorUpdateTemplateCreateInfoKHR*, VkAllocationCallbacks*, VkDescriptorUpdateTemplateKHR*, VkResult>)vkCreateDescriptorUpdateTemplateKHR_ptr)(device, pCreateInfo, pAllocator, pDescriptorUpdateTemplate);
	}

	public unsafe static VkResult vkCreateDescriptorUpdateTemplateKHR(VkDevice device, VkDescriptorUpdateTemplateCreateInfoKHR* pCreateInfo, VkAllocationCallbacks* pAllocator, out VkDescriptorUpdateTemplateKHR pDescriptorUpdateTemplate)
	{
		fixed (VkDescriptorUpdateTemplateKHR* ptr = &pDescriptorUpdateTemplate)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorUpdateTemplateCreateInfoKHR*, VkAllocationCallbacks*, VkDescriptorUpdateTemplateKHR*, VkResult>)vkCreateDescriptorUpdateTemplateKHR_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateDescriptorUpdateTemplateKHR(VkDevice device, VkDescriptorUpdateTemplateCreateInfoKHR* pCreateInfo, ref VkAllocationCallbacks pAllocator, VkDescriptorUpdateTemplateKHR* pDescriptorUpdateTemplate)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorUpdateTemplateCreateInfoKHR*, VkAllocationCallbacks*, VkDescriptorUpdateTemplateKHR*, VkResult>)vkCreateDescriptorUpdateTemplateKHR_ptr)(device, pCreateInfo, ptr, pDescriptorUpdateTemplate);
		}
	}

	public unsafe static VkResult vkCreateDescriptorUpdateTemplateKHR(VkDevice device, VkDescriptorUpdateTemplateCreateInfoKHR* pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkDescriptorUpdateTemplateKHR pDescriptorUpdateTemplate)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkDescriptorUpdateTemplateKHR* ptr2 = &pDescriptorUpdateTemplate)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorUpdateTemplateCreateInfoKHR*, VkAllocationCallbacks*, VkDescriptorUpdateTemplateKHR*, VkResult>)vkCreateDescriptorUpdateTemplateKHR_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateDescriptorUpdateTemplateKHR(VkDevice device, VkDescriptorUpdateTemplateCreateInfoKHR* pCreateInfo, IntPtr pAllocator, VkDescriptorUpdateTemplateKHR* pDescriptorUpdateTemplate)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorUpdateTemplateCreateInfoKHR*, IntPtr, VkDescriptorUpdateTemplateKHR*, VkResult>)vkCreateDescriptorUpdateTemplateKHR_ptr)(device, pCreateInfo, pAllocator, pDescriptorUpdateTemplate);
	}

	public unsafe static VkResult vkCreateDescriptorUpdateTemplateKHR(VkDevice device, VkDescriptorUpdateTemplateCreateInfoKHR* pCreateInfo, IntPtr pAllocator, out VkDescriptorUpdateTemplateKHR pDescriptorUpdateTemplate)
	{
		fixed (VkDescriptorUpdateTemplateKHR* ptr = &pDescriptorUpdateTemplate)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorUpdateTemplateCreateInfoKHR*, IntPtr, VkDescriptorUpdateTemplateKHR*, VkResult>)vkCreateDescriptorUpdateTemplateKHR_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateDescriptorUpdateTemplateKHR(VkDevice device, ref VkDescriptorUpdateTemplateCreateInfoKHR pCreateInfo, VkAllocationCallbacks* pAllocator, VkDescriptorUpdateTemplateKHR* pDescriptorUpdateTemplate)
	{
		fixed (VkDescriptorUpdateTemplateCreateInfoKHR* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorUpdateTemplateCreateInfoKHR*, VkAllocationCallbacks*, VkDescriptorUpdateTemplateKHR*, VkResult>)vkCreateDescriptorUpdateTemplateKHR_ptr)(device, ptr, pAllocator, pDescriptorUpdateTemplate);
		}
	}

	public unsafe static VkResult vkCreateDescriptorUpdateTemplateKHR(VkDevice device, ref VkDescriptorUpdateTemplateCreateInfoKHR pCreateInfo, VkAllocationCallbacks* pAllocator, out VkDescriptorUpdateTemplateKHR pDescriptorUpdateTemplate)
	{
		fixed (VkDescriptorUpdateTemplateCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkDescriptorUpdateTemplateKHR* ptr2 = &pDescriptorUpdateTemplate)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorUpdateTemplateCreateInfoKHR*, VkAllocationCallbacks*, VkDescriptorUpdateTemplateKHR*, VkResult>)vkCreateDescriptorUpdateTemplateKHR_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateDescriptorUpdateTemplateKHR(VkDevice device, ref VkDescriptorUpdateTemplateCreateInfoKHR pCreateInfo, ref VkAllocationCallbacks pAllocator, VkDescriptorUpdateTemplateKHR* pDescriptorUpdateTemplate)
	{
		fixed (VkDescriptorUpdateTemplateCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorUpdateTemplateCreateInfoKHR*, VkAllocationCallbacks*, VkDescriptorUpdateTemplateKHR*, VkResult>)vkCreateDescriptorUpdateTemplateKHR_ptr)(device, ptr, ptr2, pDescriptorUpdateTemplate);
			}
		}
	}

	public unsafe static VkResult vkCreateDescriptorUpdateTemplateKHR(VkDevice device, ref VkDescriptorUpdateTemplateCreateInfoKHR pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkDescriptorUpdateTemplateKHR pDescriptorUpdateTemplate)
	{
		fixed (VkDescriptorUpdateTemplateCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkDescriptorUpdateTemplateKHR* ptr3 = &pDescriptorUpdateTemplate)
				{
					return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorUpdateTemplateCreateInfoKHR*, VkAllocationCallbacks*, VkDescriptorUpdateTemplateKHR*, VkResult>)vkCreateDescriptorUpdateTemplateKHR_ptr)(device, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreateDescriptorUpdateTemplateKHR(VkDevice device, ref VkDescriptorUpdateTemplateCreateInfoKHR pCreateInfo, IntPtr pAllocator, VkDescriptorUpdateTemplateKHR* pDescriptorUpdateTemplate)
	{
		fixed (VkDescriptorUpdateTemplateCreateInfoKHR* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorUpdateTemplateCreateInfoKHR*, IntPtr, VkDescriptorUpdateTemplateKHR*, VkResult>)vkCreateDescriptorUpdateTemplateKHR_ptr)(device, ptr, pAllocator, pDescriptorUpdateTemplate);
		}
	}

	public unsafe static VkResult vkCreateDescriptorUpdateTemplateKHR(VkDevice device, ref VkDescriptorUpdateTemplateCreateInfoKHR pCreateInfo, IntPtr pAllocator, out VkDescriptorUpdateTemplateKHR pDescriptorUpdateTemplate)
	{
		fixed (VkDescriptorUpdateTemplateCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkDescriptorUpdateTemplateKHR* ptr2 = &pDescriptorUpdateTemplate)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorUpdateTemplateCreateInfoKHR*, IntPtr, VkDescriptorUpdateTemplateKHR*, VkResult>)vkCreateDescriptorUpdateTemplateKHR_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateDescriptorUpdateTemplateKHR(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, VkDescriptorUpdateTemplateKHR* pDescriptorUpdateTemplate)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkDescriptorUpdateTemplateKHR*, VkResult>)vkCreateDescriptorUpdateTemplateKHR_ptr)(device, pCreateInfo, pAllocator, pDescriptorUpdateTemplate);
	}

	public unsafe static VkResult vkCreateDescriptorUpdateTemplateKHR(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, out VkDescriptorUpdateTemplateKHR pDescriptorUpdateTemplate)
	{
		fixed (VkDescriptorUpdateTemplateKHR* ptr = &pDescriptorUpdateTemplate)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkDescriptorUpdateTemplateKHR*, VkResult>)vkCreateDescriptorUpdateTemplateKHR_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateDescriptorUpdateTemplateKHR(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, VkDescriptorUpdateTemplateKHR* pDescriptorUpdateTemplate)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkDescriptorUpdateTemplateKHR*, VkResult>)vkCreateDescriptorUpdateTemplateKHR_ptr)(device, pCreateInfo, ptr, pDescriptorUpdateTemplate);
		}
	}

	public unsafe static VkResult vkCreateDescriptorUpdateTemplateKHR(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkDescriptorUpdateTemplateKHR pDescriptorUpdateTemplate)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkDescriptorUpdateTemplateKHR* ptr2 = &pDescriptorUpdateTemplate)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkDescriptorUpdateTemplateKHR*, VkResult>)vkCreateDescriptorUpdateTemplateKHR_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateDescriptorUpdateTemplateKHR(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, VkDescriptorUpdateTemplateKHR* pDescriptorUpdateTemplate)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkDescriptorUpdateTemplateKHR*, VkResult>)vkCreateDescriptorUpdateTemplateKHR_ptr)(device, pCreateInfo, pAllocator, pDescriptorUpdateTemplate);
	}

	public unsafe static VkResult vkCreateDescriptorUpdateTemplateKHR(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, out VkDescriptorUpdateTemplateKHR pDescriptorUpdateTemplate)
	{
		fixed (VkDescriptorUpdateTemplateKHR* ptr = &pDescriptorUpdateTemplate)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkDescriptorUpdateTemplateKHR*, VkResult>)vkCreateDescriptorUpdateTemplateKHR_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateDevice(VkPhysicalDevice physicalDevice, VkDeviceCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkDevice* pDevice)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDeviceCreateInfo*, VkAllocationCallbacks*, VkDevice*, VkResult>)vkCreateDevice_ptr)(physicalDevice, pCreateInfo, pAllocator, pDevice);
	}

	public unsafe static VkResult vkCreateDevice(VkPhysicalDevice physicalDevice, VkDeviceCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, out VkDevice pDevice)
	{
		fixed (VkDevice* ptr = &pDevice)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDeviceCreateInfo*, VkAllocationCallbacks*, VkDevice*, VkResult>)vkCreateDevice_ptr)(physicalDevice, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateDevice(VkPhysicalDevice physicalDevice, VkDeviceCreateInfo* pCreateInfo, ref VkAllocationCallbacks pAllocator, VkDevice* pDevice)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDeviceCreateInfo*, VkAllocationCallbacks*, VkDevice*, VkResult>)vkCreateDevice_ptr)(physicalDevice, pCreateInfo, ptr, pDevice);
		}
	}

	public unsafe static VkResult vkCreateDevice(VkPhysicalDevice physicalDevice, VkDeviceCreateInfo* pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkDevice pDevice)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkDevice* ptr2 = &pDevice)
			{
				return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDeviceCreateInfo*, VkAllocationCallbacks*, VkDevice*, VkResult>)vkCreateDevice_ptr)(physicalDevice, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateDevice(VkPhysicalDevice physicalDevice, VkDeviceCreateInfo* pCreateInfo, IntPtr pAllocator, VkDevice* pDevice)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDeviceCreateInfo*, IntPtr, VkDevice*, VkResult>)vkCreateDevice_ptr)(physicalDevice, pCreateInfo, pAllocator, pDevice);
	}

	public unsafe static VkResult vkCreateDevice(VkPhysicalDevice physicalDevice, VkDeviceCreateInfo* pCreateInfo, IntPtr pAllocator, out VkDevice pDevice)
	{
		fixed (VkDevice* ptr = &pDevice)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDeviceCreateInfo*, IntPtr, VkDevice*, VkResult>)vkCreateDevice_ptr)(physicalDevice, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateDevice(VkPhysicalDevice physicalDevice, ref VkDeviceCreateInfo pCreateInfo, VkAllocationCallbacks* pAllocator, VkDevice* pDevice)
	{
		fixed (VkDeviceCreateInfo* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDeviceCreateInfo*, VkAllocationCallbacks*, VkDevice*, VkResult>)vkCreateDevice_ptr)(physicalDevice, ptr, pAllocator, pDevice);
		}
	}

	public unsafe static VkResult vkCreateDevice(VkPhysicalDevice physicalDevice, ref VkDeviceCreateInfo pCreateInfo, VkAllocationCallbacks* pAllocator, out VkDevice pDevice)
	{
		fixed (VkDeviceCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkDevice* ptr2 = &pDevice)
			{
				return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDeviceCreateInfo*, VkAllocationCallbacks*, VkDevice*, VkResult>)vkCreateDevice_ptr)(physicalDevice, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateDevice(VkPhysicalDevice physicalDevice, ref VkDeviceCreateInfo pCreateInfo, ref VkAllocationCallbacks pAllocator, VkDevice* pDevice)
	{
		fixed (VkDeviceCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDeviceCreateInfo*, VkAllocationCallbacks*, VkDevice*, VkResult>)vkCreateDevice_ptr)(physicalDevice, ptr, ptr2, pDevice);
			}
		}
	}

	public unsafe static VkResult vkCreateDevice(VkPhysicalDevice physicalDevice, ref VkDeviceCreateInfo pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkDevice pDevice)
	{
		fixed (VkDeviceCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkDevice* ptr3 = &pDevice)
				{
					return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDeviceCreateInfo*, VkAllocationCallbacks*, VkDevice*, VkResult>)vkCreateDevice_ptr)(physicalDevice, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreateDevice(VkPhysicalDevice physicalDevice, ref VkDeviceCreateInfo pCreateInfo, IntPtr pAllocator, VkDevice* pDevice)
	{
		fixed (VkDeviceCreateInfo* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDeviceCreateInfo*, IntPtr, VkDevice*, VkResult>)vkCreateDevice_ptr)(physicalDevice, ptr, pAllocator, pDevice);
		}
	}

	public unsafe static VkResult vkCreateDevice(VkPhysicalDevice physicalDevice, ref VkDeviceCreateInfo pCreateInfo, IntPtr pAllocator, out VkDevice pDevice)
	{
		fixed (VkDeviceCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkDevice* ptr2 = &pDevice)
			{
				return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDeviceCreateInfo*, IntPtr, VkDevice*, VkResult>)vkCreateDevice_ptr)(physicalDevice, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateDevice(VkPhysicalDevice physicalDevice, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, VkDevice* pDevice)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, VkAllocationCallbacks*, VkDevice*, VkResult>)vkCreateDevice_ptr)(physicalDevice, pCreateInfo, pAllocator, pDevice);
	}

	public unsafe static VkResult vkCreateDevice(VkPhysicalDevice physicalDevice, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, out VkDevice pDevice)
	{
		fixed (VkDevice* ptr = &pDevice)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, VkAllocationCallbacks*, VkDevice*, VkResult>)vkCreateDevice_ptr)(physicalDevice, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateDevice(VkPhysicalDevice physicalDevice, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, VkDevice* pDevice)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, VkAllocationCallbacks*, VkDevice*, VkResult>)vkCreateDevice_ptr)(physicalDevice, pCreateInfo, ptr, pDevice);
		}
	}

	public unsafe static VkResult vkCreateDevice(VkPhysicalDevice physicalDevice, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkDevice pDevice)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkDevice* ptr2 = &pDevice)
			{
				return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, VkAllocationCallbacks*, VkDevice*, VkResult>)vkCreateDevice_ptr)(physicalDevice, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateDevice(VkPhysicalDevice physicalDevice, IntPtr pCreateInfo, IntPtr pAllocator, VkDevice* pDevice)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, IntPtr, VkDevice*, VkResult>)vkCreateDevice_ptr)(physicalDevice, pCreateInfo, pAllocator, pDevice);
	}

	public unsafe static VkResult vkCreateDevice(VkPhysicalDevice physicalDevice, IntPtr pCreateInfo, IntPtr pAllocator, out VkDevice pDevice)
	{
		fixed (VkDevice* ptr = &pDevice)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, IntPtr, VkDevice*, VkResult>)vkCreateDevice_ptr)(physicalDevice, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateDisplayModeKHR(VkPhysicalDevice physicalDevice, VkDisplayKHR display, VkDisplayModeCreateInfoKHR* pCreateInfo, VkAllocationCallbacks* pAllocator, VkDisplayModeKHR* pMode)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDisplayKHR, VkDisplayModeCreateInfoKHR*, VkAllocationCallbacks*, VkDisplayModeKHR*, VkResult>)vkCreateDisplayModeKHR_ptr)(physicalDevice, display, pCreateInfo, pAllocator, pMode);
	}

	public unsafe static VkResult vkCreateDisplayModeKHR(VkPhysicalDevice physicalDevice, VkDisplayKHR display, VkDisplayModeCreateInfoKHR* pCreateInfo, VkAllocationCallbacks* pAllocator, out VkDisplayModeKHR pMode)
	{
		fixed (VkDisplayModeKHR* ptr = &pMode)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDisplayKHR, VkDisplayModeCreateInfoKHR*, VkAllocationCallbacks*, VkDisplayModeKHR*, VkResult>)vkCreateDisplayModeKHR_ptr)(physicalDevice, display, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateDisplayModeKHR(VkPhysicalDevice physicalDevice, VkDisplayKHR display, VkDisplayModeCreateInfoKHR* pCreateInfo, ref VkAllocationCallbacks pAllocator, VkDisplayModeKHR* pMode)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDisplayKHR, VkDisplayModeCreateInfoKHR*, VkAllocationCallbacks*, VkDisplayModeKHR*, VkResult>)vkCreateDisplayModeKHR_ptr)(physicalDevice, display, pCreateInfo, ptr, pMode);
		}
	}

	public unsafe static VkResult vkCreateDisplayModeKHR(VkPhysicalDevice physicalDevice, VkDisplayKHR display, VkDisplayModeCreateInfoKHR* pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkDisplayModeKHR pMode)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkDisplayModeKHR* ptr2 = &pMode)
			{
				return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDisplayKHR, VkDisplayModeCreateInfoKHR*, VkAllocationCallbacks*, VkDisplayModeKHR*, VkResult>)vkCreateDisplayModeKHR_ptr)(physicalDevice, display, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateDisplayModeKHR(VkPhysicalDevice physicalDevice, VkDisplayKHR display, VkDisplayModeCreateInfoKHR* pCreateInfo, IntPtr pAllocator, VkDisplayModeKHR* pMode)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDisplayKHR, VkDisplayModeCreateInfoKHR*, IntPtr, VkDisplayModeKHR*, VkResult>)vkCreateDisplayModeKHR_ptr)(physicalDevice, display, pCreateInfo, pAllocator, pMode);
	}

	public unsafe static VkResult vkCreateDisplayModeKHR(VkPhysicalDevice physicalDevice, VkDisplayKHR display, VkDisplayModeCreateInfoKHR* pCreateInfo, IntPtr pAllocator, out VkDisplayModeKHR pMode)
	{
		fixed (VkDisplayModeKHR* ptr = &pMode)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDisplayKHR, VkDisplayModeCreateInfoKHR*, IntPtr, VkDisplayModeKHR*, VkResult>)vkCreateDisplayModeKHR_ptr)(physicalDevice, display, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateDisplayModeKHR(VkPhysicalDevice physicalDevice, VkDisplayKHR display, ref VkDisplayModeCreateInfoKHR pCreateInfo, VkAllocationCallbacks* pAllocator, VkDisplayModeKHR* pMode)
	{
		fixed (VkDisplayModeCreateInfoKHR* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDisplayKHR, VkDisplayModeCreateInfoKHR*, VkAllocationCallbacks*, VkDisplayModeKHR*, VkResult>)vkCreateDisplayModeKHR_ptr)(physicalDevice, display, ptr, pAllocator, pMode);
		}
	}

	public unsafe static VkResult vkCreateDisplayModeKHR(VkPhysicalDevice physicalDevice, VkDisplayKHR display, ref VkDisplayModeCreateInfoKHR pCreateInfo, VkAllocationCallbacks* pAllocator, out VkDisplayModeKHR pMode)
	{
		fixed (VkDisplayModeCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkDisplayModeKHR* ptr2 = &pMode)
			{
				return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDisplayKHR, VkDisplayModeCreateInfoKHR*, VkAllocationCallbacks*, VkDisplayModeKHR*, VkResult>)vkCreateDisplayModeKHR_ptr)(physicalDevice, display, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateDisplayModeKHR(VkPhysicalDevice physicalDevice, VkDisplayKHR display, ref VkDisplayModeCreateInfoKHR pCreateInfo, ref VkAllocationCallbacks pAllocator, VkDisplayModeKHR* pMode)
	{
		fixed (VkDisplayModeCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDisplayKHR, VkDisplayModeCreateInfoKHR*, VkAllocationCallbacks*, VkDisplayModeKHR*, VkResult>)vkCreateDisplayModeKHR_ptr)(physicalDevice, display, ptr, ptr2, pMode);
			}
		}
	}

	public unsafe static VkResult vkCreateDisplayModeKHR(VkPhysicalDevice physicalDevice, VkDisplayKHR display, ref VkDisplayModeCreateInfoKHR pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkDisplayModeKHR pMode)
	{
		fixed (VkDisplayModeCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkDisplayModeKHR* ptr3 = &pMode)
				{
					return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDisplayKHR, VkDisplayModeCreateInfoKHR*, VkAllocationCallbacks*, VkDisplayModeKHR*, VkResult>)vkCreateDisplayModeKHR_ptr)(physicalDevice, display, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreateDisplayModeKHR(VkPhysicalDevice physicalDevice, VkDisplayKHR display, ref VkDisplayModeCreateInfoKHR pCreateInfo, IntPtr pAllocator, VkDisplayModeKHR* pMode)
	{
		fixed (VkDisplayModeCreateInfoKHR* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDisplayKHR, VkDisplayModeCreateInfoKHR*, IntPtr, VkDisplayModeKHR*, VkResult>)vkCreateDisplayModeKHR_ptr)(physicalDevice, display, ptr, pAllocator, pMode);
		}
	}

	public unsafe static VkResult vkCreateDisplayModeKHR(VkPhysicalDevice physicalDevice, VkDisplayKHR display, ref VkDisplayModeCreateInfoKHR pCreateInfo, IntPtr pAllocator, out VkDisplayModeKHR pMode)
	{
		fixed (VkDisplayModeCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkDisplayModeKHR* ptr2 = &pMode)
			{
				return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDisplayKHR, VkDisplayModeCreateInfoKHR*, IntPtr, VkDisplayModeKHR*, VkResult>)vkCreateDisplayModeKHR_ptr)(physicalDevice, display, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateDisplayModeKHR(VkPhysicalDevice physicalDevice, VkDisplayKHR display, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, VkDisplayModeKHR* pMode)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDisplayKHR, IntPtr, VkAllocationCallbacks*, VkDisplayModeKHR*, VkResult>)vkCreateDisplayModeKHR_ptr)(physicalDevice, display, pCreateInfo, pAllocator, pMode);
	}

	public unsafe static VkResult vkCreateDisplayModeKHR(VkPhysicalDevice physicalDevice, VkDisplayKHR display, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, out VkDisplayModeKHR pMode)
	{
		fixed (VkDisplayModeKHR* ptr = &pMode)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDisplayKHR, IntPtr, VkAllocationCallbacks*, VkDisplayModeKHR*, VkResult>)vkCreateDisplayModeKHR_ptr)(physicalDevice, display, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateDisplayModeKHR(VkPhysicalDevice physicalDevice, VkDisplayKHR display, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, VkDisplayModeKHR* pMode)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDisplayKHR, IntPtr, VkAllocationCallbacks*, VkDisplayModeKHR*, VkResult>)vkCreateDisplayModeKHR_ptr)(physicalDevice, display, pCreateInfo, ptr, pMode);
		}
	}

	public unsafe static VkResult vkCreateDisplayModeKHR(VkPhysicalDevice physicalDevice, VkDisplayKHR display, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkDisplayModeKHR pMode)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkDisplayModeKHR* ptr2 = &pMode)
			{
				return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDisplayKHR, IntPtr, VkAllocationCallbacks*, VkDisplayModeKHR*, VkResult>)vkCreateDisplayModeKHR_ptr)(physicalDevice, display, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateDisplayModeKHR(VkPhysicalDevice physicalDevice, VkDisplayKHR display, IntPtr pCreateInfo, IntPtr pAllocator, VkDisplayModeKHR* pMode)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDisplayKHR, IntPtr, IntPtr, VkDisplayModeKHR*, VkResult>)vkCreateDisplayModeKHR_ptr)(physicalDevice, display, pCreateInfo, pAllocator, pMode);
	}

	public unsafe static VkResult vkCreateDisplayModeKHR(VkPhysicalDevice physicalDevice, VkDisplayKHR display, IntPtr pCreateInfo, IntPtr pAllocator, out VkDisplayModeKHR pMode)
	{
		fixed (VkDisplayModeKHR* ptr = &pMode)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDisplayKHR, IntPtr, IntPtr, VkDisplayModeKHR*, VkResult>)vkCreateDisplayModeKHR_ptr)(physicalDevice, display, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateDisplayPlaneSurfaceKHR(VkInstance instance, VkDisplaySurfaceCreateInfoKHR* pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, VkDisplaySurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateDisplayPlaneSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateDisplayPlaneSurfaceKHR(VkInstance instance, VkDisplaySurfaceCreateInfoKHR* pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkDisplaySurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateDisplayPlaneSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateDisplayPlaneSurfaceKHR(VkInstance instance, VkDisplaySurfaceCreateInfoKHR* pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkDisplaySurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateDisplayPlaneSurfaceKHR_ptr)(instance, pCreateInfo, ptr, pSurface);
		}
	}

	public unsafe static VkResult vkCreateDisplayPlaneSurfaceKHR(VkInstance instance, VkDisplaySurfaceCreateInfoKHR* pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkDisplaySurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateDisplayPlaneSurfaceKHR_ptr)(instance, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateDisplayPlaneSurfaceKHR(VkInstance instance, VkDisplaySurfaceCreateInfoKHR* pCreateInfo, IntPtr pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, VkDisplaySurfaceCreateInfoKHR*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateDisplayPlaneSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateDisplayPlaneSurfaceKHR(VkInstance instance, VkDisplaySurfaceCreateInfoKHR* pCreateInfo, IntPtr pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkDisplaySurfaceCreateInfoKHR*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateDisplayPlaneSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateDisplayPlaneSurfaceKHR(VkInstance instance, ref VkDisplaySurfaceCreateInfoKHR pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkDisplaySurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkDisplaySurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateDisplayPlaneSurfaceKHR_ptr)(instance, ptr, pAllocator, pSurface);
		}
	}

	public unsafe static VkResult vkCreateDisplayPlaneSurfaceKHR(VkInstance instance, ref VkDisplaySurfaceCreateInfoKHR pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkDisplaySurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkDisplaySurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateDisplayPlaneSurfaceKHR_ptr)(instance, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateDisplayPlaneSurfaceKHR(VkInstance instance, ref VkDisplaySurfaceCreateInfoKHR pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkDisplaySurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkDisplaySurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateDisplayPlaneSurfaceKHR_ptr)(instance, ptr, ptr2, pSurface);
			}
		}
	}

	public unsafe static VkResult vkCreateDisplayPlaneSurfaceKHR(VkInstance instance, ref VkDisplaySurfaceCreateInfoKHR pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkDisplaySurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkSurfaceKHR* ptr3 = &pSurface)
				{
					return ((delegate* unmanaged[Stdcall]<VkInstance, VkDisplaySurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateDisplayPlaneSurfaceKHR_ptr)(instance, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreateDisplayPlaneSurfaceKHR(VkInstance instance, ref VkDisplaySurfaceCreateInfoKHR pCreateInfo, IntPtr pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkDisplaySurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkDisplaySurfaceCreateInfoKHR*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateDisplayPlaneSurfaceKHR_ptr)(instance, ptr, pAllocator, pSurface);
		}
	}

	public unsafe static VkResult vkCreateDisplayPlaneSurfaceKHR(VkInstance instance, ref VkDisplaySurfaceCreateInfoKHR pCreateInfo, IntPtr pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkDisplaySurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkDisplaySurfaceCreateInfoKHR*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateDisplayPlaneSurfaceKHR_ptr)(instance, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateDisplayPlaneSurfaceKHR(VkInstance instance, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateDisplayPlaneSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateDisplayPlaneSurfaceKHR(VkInstance instance, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateDisplayPlaneSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateDisplayPlaneSurfaceKHR(VkInstance instance, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateDisplayPlaneSurfaceKHR_ptr)(instance, pCreateInfo, ptr, pSurface);
		}
	}

	public unsafe static VkResult vkCreateDisplayPlaneSurfaceKHR(VkInstance instance, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateDisplayPlaneSurfaceKHR_ptr)(instance, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateDisplayPlaneSurfaceKHR(VkInstance instance, IntPtr pCreateInfo, IntPtr pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateDisplayPlaneSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateDisplayPlaneSurfaceKHR(VkInstance instance, IntPtr pCreateInfo, IntPtr pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateDisplayPlaneSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateEvent(VkDevice device, VkEventCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkEvent* pEvent)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkEventCreateInfo*, VkAllocationCallbacks*, VkEvent*, VkResult>)vkCreateEvent_ptr)(device, pCreateInfo, pAllocator, pEvent);
	}

	public unsafe static VkResult vkCreateEvent(VkDevice device, VkEventCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, out VkEvent pEvent)
	{
		fixed (VkEvent* ptr = &pEvent)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkEventCreateInfo*, VkAllocationCallbacks*, VkEvent*, VkResult>)vkCreateEvent_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateEvent(VkDevice device, VkEventCreateInfo* pCreateInfo, ref VkAllocationCallbacks pAllocator, VkEvent* pEvent)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkEventCreateInfo*, VkAllocationCallbacks*, VkEvent*, VkResult>)vkCreateEvent_ptr)(device, pCreateInfo, ptr, pEvent);
		}
	}

	public unsafe static VkResult vkCreateEvent(VkDevice device, VkEventCreateInfo* pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkEvent pEvent)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkEvent* ptr2 = &pEvent)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkEventCreateInfo*, VkAllocationCallbacks*, VkEvent*, VkResult>)vkCreateEvent_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateEvent(VkDevice device, VkEventCreateInfo* pCreateInfo, IntPtr pAllocator, VkEvent* pEvent)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkEventCreateInfo*, IntPtr, VkEvent*, VkResult>)vkCreateEvent_ptr)(device, pCreateInfo, pAllocator, pEvent);
	}

	public unsafe static VkResult vkCreateEvent(VkDevice device, VkEventCreateInfo* pCreateInfo, IntPtr pAllocator, out VkEvent pEvent)
	{
		fixed (VkEvent* ptr = &pEvent)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkEventCreateInfo*, IntPtr, VkEvent*, VkResult>)vkCreateEvent_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateEvent(VkDevice device, ref VkEventCreateInfo pCreateInfo, VkAllocationCallbacks* pAllocator, VkEvent* pEvent)
	{
		fixed (VkEventCreateInfo* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkEventCreateInfo*, VkAllocationCallbacks*, VkEvent*, VkResult>)vkCreateEvent_ptr)(device, ptr, pAllocator, pEvent);
		}
	}

	public unsafe static VkResult vkCreateEvent(VkDevice device, ref VkEventCreateInfo pCreateInfo, VkAllocationCallbacks* pAllocator, out VkEvent pEvent)
	{
		fixed (VkEventCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkEvent* ptr2 = &pEvent)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkEventCreateInfo*, VkAllocationCallbacks*, VkEvent*, VkResult>)vkCreateEvent_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateEvent(VkDevice device, ref VkEventCreateInfo pCreateInfo, ref VkAllocationCallbacks pAllocator, VkEvent* pEvent)
	{
		fixed (VkEventCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkEventCreateInfo*, VkAllocationCallbacks*, VkEvent*, VkResult>)vkCreateEvent_ptr)(device, ptr, ptr2, pEvent);
			}
		}
	}

	public unsafe static VkResult vkCreateEvent(VkDevice device, ref VkEventCreateInfo pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkEvent pEvent)
	{
		fixed (VkEventCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkEvent* ptr3 = &pEvent)
				{
					return ((delegate* unmanaged[Stdcall]<VkDevice, VkEventCreateInfo*, VkAllocationCallbacks*, VkEvent*, VkResult>)vkCreateEvent_ptr)(device, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreateEvent(VkDevice device, ref VkEventCreateInfo pCreateInfo, IntPtr pAllocator, VkEvent* pEvent)
	{
		fixed (VkEventCreateInfo* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkEventCreateInfo*, IntPtr, VkEvent*, VkResult>)vkCreateEvent_ptr)(device, ptr, pAllocator, pEvent);
		}
	}

	public unsafe static VkResult vkCreateEvent(VkDevice device, ref VkEventCreateInfo pCreateInfo, IntPtr pAllocator, out VkEvent pEvent)
	{
		fixed (VkEventCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkEvent* ptr2 = &pEvent)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkEventCreateInfo*, IntPtr, VkEvent*, VkResult>)vkCreateEvent_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateEvent(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, VkEvent* pEvent)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkEvent*, VkResult>)vkCreateEvent_ptr)(device, pCreateInfo, pAllocator, pEvent);
	}

	public unsafe static VkResult vkCreateEvent(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, out VkEvent pEvent)
	{
		fixed (VkEvent* ptr = &pEvent)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkEvent*, VkResult>)vkCreateEvent_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateEvent(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, VkEvent* pEvent)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkEvent*, VkResult>)vkCreateEvent_ptr)(device, pCreateInfo, ptr, pEvent);
		}
	}

	public unsafe static VkResult vkCreateEvent(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkEvent pEvent)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkEvent* ptr2 = &pEvent)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkEvent*, VkResult>)vkCreateEvent_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateEvent(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, VkEvent* pEvent)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkEvent*, VkResult>)vkCreateEvent_ptr)(device, pCreateInfo, pAllocator, pEvent);
	}

	public unsafe static VkResult vkCreateEvent(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, out VkEvent pEvent)
	{
		fixed (VkEvent* ptr = &pEvent)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkEvent*, VkResult>)vkCreateEvent_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateFence(VkDevice device, VkFenceCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkFence* pFence)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkFenceCreateInfo*, VkAllocationCallbacks*, VkFence*, VkResult>)vkCreateFence_ptr)(device, pCreateInfo, pAllocator, pFence);
	}

	public unsafe static VkResult vkCreateFence(VkDevice device, VkFenceCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, out VkFence pFence)
	{
		fixed (VkFence* ptr = &pFence)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkFenceCreateInfo*, VkAllocationCallbacks*, VkFence*, VkResult>)vkCreateFence_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateFence(VkDevice device, VkFenceCreateInfo* pCreateInfo, ref VkAllocationCallbacks pAllocator, VkFence* pFence)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkFenceCreateInfo*, VkAllocationCallbacks*, VkFence*, VkResult>)vkCreateFence_ptr)(device, pCreateInfo, ptr, pFence);
		}
	}

	public unsafe static VkResult vkCreateFence(VkDevice device, VkFenceCreateInfo* pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkFence pFence)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkFence* ptr2 = &pFence)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkFenceCreateInfo*, VkAllocationCallbacks*, VkFence*, VkResult>)vkCreateFence_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateFence(VkDevice device, VkFenceCreateInfo* pCreateInfo, IntPtr pAllocator, VkFence* pFence)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkFenceCreateInfo*, IntPtr, VkFence*, VkResult>)vkCreateFence_ptr)(device, pCreateInfo, pAllocator, pFence);
	}

	public unsafe static VkResult vkCreateFence(VkDevice device, VkFenceCreateInfo* pCreateInfo, IntPtr pAllocator, out VkFence pFence)
	{
		fixed (VkFence* ptr = &pFence)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkFenceCreateInfo*, IntPtr, VkFence*, VkResult>)vkCreateFence_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateFence(VkDevice device, ref VkFenceCreateInfo pCreateInfo, VkAllocationCallbacks* pAllocator, VkFence* pFence)
	{
		fixed (VkFenceCreateInfo* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkFenceCreateInfo*, VkAllocationCallbacks*, VkFence*, VkResult>)vkCreateFence_ptr)(device, ptr, pAllocator, pFence);
		}
	}

	public unsafe static VkResult vkCreateFence(VkDevice device, ref VkFenceCreateInfo pCreateInfo, VkAllocationCallbacks* pAllocator, out VkFence pFence)
	{
		fixed (VkFenceCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkFence* ptr2 = &pFence)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkFenceCreateInfo*, VkAllocationCallbacks*, VkFence*, VkResult>)vkCreateFence_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateFence(VkDevice device, ref VkFenceCreateInfo pCreateInfo, ref VkAllocationCallbacks pAllocator, VkFence* pFence)
	{
		fixed (VkFenceCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkFenceCreateInfo*, VkAllocationCallbacks*, VkFence*, VkResult>)vkCreateFence_ptr)(device, ptr, ptr2, pFence);
			}
		}
	}

	public unsafe static VkResult vkCreateFence(VkDevice device, ref VkFenceCreateInfo pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkFence pFence)
	{
		fixed (VkFenceCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkFence* ptr3 = &pFence)
				{
					return ((delegate* unmanaged[Stdcall]<VkDevice, VkFenceCreateInfo*, VkAllocationCallbacks*, VkFence*, VkResult>)vkCreateFence_ptr)(device, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreateFence(VkDevice device, ref VkFenceCreateInfo pCreateInfo, IntPtr pAllocator, VkFence* pFence)
	{
		fixed (VkFenceCreateInfo* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkFenceCreateInfo*, IntPtr, VkFence*, VkResult>)vkCreateFence_ptr)(device, ptr, pAllocator, pFence);
		}
	}

	public unsafe static VkResult vkCreateFence(VkDevice device, ref VkFenceCreateInfo pCreateInfo, IntPtr pAllocator, out VkFence pFence)
	{
		fixed (VkFenceCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkFence* ptr2 = &pFence)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkFenceCreateInfo*, IntPtr, VkFence*, VkResult>)vkCreateFence_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateFence(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, VkFence* pFence)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkFence*, VkResult>)vkCreateFence_ptr)(device, pCreateInfo, pAllocator, pFence);
	}

	public unsafe static VkResult vkCreateFence(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, out VkFence pFence)
	{
		fixed (VkFence* ptr = &pFence)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkFence*, VkResult>)vkCreateFence_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateFence(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, VkFence* pFence)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkFence*, VkResult>)vkCreateFence_ptr)(device, pCreateInfo, ptr, pFence);
		}
	}

	public unsafe static VkResult vkCreateFence(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkFence pFence)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkFence* ptr2 = &pFence)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkFence*, VkResult>)vkCreateFence_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateFence(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, VkFence* pFence)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkFence*, VkResult>)vkCreateFence_ptr)(device, pCreateInfo, pAllocator, pFence);
	}

	public unsafe static VkResult vkCreateFence(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, out VkFence pFence)
	{
		fixed (VkFence* ptr = &pFence)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkFence*, VkResult>)vkCreateFence_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateFramebuffer(VkDevice device, VkFramebufferCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkFramebuffer* pFramebuffer)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkFramebufferCreateInfo*, VkAllocationCallbacks*, VkFramebuffer*, VkResult>)vkCreateFramebuffer_ptr)(device, pCreateInfo, pAllocator, pFramebuffer);
	}

	public unsafe static VkResult vkCreateFramebuffer(VkDevice device, VkFramebufferCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, out VkFramebuffer pFramebuffer)
	{
		fixed (VkFramebuffer* ptr = &pFramebuffer)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkFramebufferCreateInfo*, VkAllocationCallbacks*, VkFramebuffer*, VkResult>)vkCreateFramebuffer_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateFramebuffer(VkDevice device, VkFramebufferCreateInfo* pCreateInfo, ref VkAllocationCallbacks pAllocator, VkFramebuffer* pFramebuffer)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkFramebufferCreateInfo*, VkAllocationCallbacks*, VkFramebuffer*, VkResult>)vkCreateFramebuffer_ptr)(device, pCreateInfo, ptr, pFramebuffer);
		}
	}

	public unsafe static VkResult vkCreateFramebuffer(VkDevice device, VkFramebufferCreateInfo* pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkFramebuffer pFramebuffer)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkFramebuffer* ptr2 = &pFramebuffer)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkFramebufferCreateInfo*, VkAllocationCallbacks*, VkFramebuffer*, VkResult>)vkCreateFramebuffer_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateFramebuffer(VkDevice device, VkFramebufferCreateInfo* pCreateInfo, IntPtr pAllocator, VkFramebuffer* pFramebuffer)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkFramebufferCreateInfo*, IntPtr, VkFramebuffer*, VkResult>)vkCreateFramebuffer_ptr)(device, pCreateInfo, pAllocator, pFramebuffer);
	}

	public unsafe static VkResult vkCreateFramebuffer(VkDevice device, VkFramebufferCreateInfo* pCreateInfo, IntPtr pAllocator, out VkFramebuffer pFramebuffer)
	{
		fixed (VkFramebuffer* ptr = &pFramebuffer)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkFramebufferCreateInfo*, IntPtr, VkFramebuffer*, VkResult>)vkCreateFramebuffer_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateFramebuffer(VkDevice device, ref VkFramebufferCreateInfo pCreateInfo, VkAllocationCallbacks* pAllocator, VkFramebuffer* pFramebuffer)
	{
		fixed (VkFramebufferCreateInfo* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkFramebufferCreateInfo*, VkAllocationCallbacks*, VkFramebuffer*, VkResult>)vkCreateFramebuffer_ptr)(device, ptr, pAllocator, pFramebuffer);
		}
	}

	public unsafe static VkResult vkCreateFramebuffer(VkDevice device, ref VkFramebufferCreateInfo pCreateInfo, VkAllocationCallbacks* pAllocator, out VkFramebuffer pFramebuffer)
	{
		fixed (VkFramebufferCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkFramebuffer* ptr2 = &pFramebuffer)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkFramebufferCreateInfo*, VkAllocationCallbacks*, VkFramebuffer*, VkResult>)vkCreateFramebuffer_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateFramebuffer(VkDevice device, ref VkFramebufferCreateInfo pCreateInfo, ref VkAllocationCallbacks pAllocator, VkFramebuffer* pFramebuffer)
	{
		fixed (VkFramebufferCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkFramebufferCreateInfo*, VkAllocationCallbacks*, VkFramebuffer*, VkResult>)vkCreateFramebuffer_ptr)(device, ptr, ptr2, pFramebuffer);
			}
		}
	}

	public unsafe static VkResult vkCreateFramebuffer(VkDevice device, ref VkFramebufferCreateInfo pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkFramebuffer pFramebuffer)
	{
		fixed (VkFramebufferCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkFramebuffer* ptr3 = &pFramebuffer)
				{
					return ((delegate* unmanaged[Stdcall]<VkDevice, VkFramebufferCreateInfo*, VkAllocationCallbacks*, VkFramebuffer*, VkResult>)vkCreateFramebuffer_ptr)(device, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreateFramebuffer(VkDevice device, ref VkFramebufferCreateInfo pCreateInfo, IntPtr pAllocator, VkFramebuffer* pFramebuffer)
	{
		fixed (VkFramebufferCreateInfo* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkFramebufferCreateInfo*, IntPtr, VkFramebuffer*, VkResult>)vkCreateFramebuffer_ptr)(device, ptr, pAllocator, pFramebuffer);
		}
	}

	public unsafe static VkResult vkCreateFramebuffer(VkDevice device, ref VkFramebufferCreateInfo pCreateInfo, IntPtr pAllocator, out VkFramebuffer pFramebuffer)
	{
		fixed (VkFramebufferCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkFramebuffer* ptr2 = &pFramebuffer)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkFramebufferCreateInfo*, IntPtr, VkFramebuffer*, VkResult>)vkCreateFramebuffer_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateFramebuffer(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, VkFramebuffer* pFramebuffer)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkFramebuffer*, VkResult>)vkCreateFramebuffer_ptr)(device, pCreateInfo, pAllocator, pFramebuffer);
	}

	public unsafe static VkResult vkCreateFramebuffer(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, out VkFramebuffer pFramebuffer)
	{
		fixed (VkFramebuffer* ptr = &pFramebuffer)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkFramebuffer*, VkResult>)vkCreateFramebuffer_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateFramebuffer(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, VkFramebuffer* pFramebuffer)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkFramebuffer*, VkResult>)vkCreateFramebuffer_ptr)(device, pCreateInfo, ptr, pFramebuffer);
		}
	}

	public unsafe static VkResult vkCreateFramebuffer(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkFramebuffer pFramebuffer)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkFramebuffer* ptr2 = &pFramebuffer)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkFramebuffer*, VkResult>)vkCreateFramebuffer_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateFramebuffer(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, VkFramebuffer* pFramebuffer)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkFramebuffer*, VkResult>)vkCreateFramebuffer_ptr)(device, pCreateInfo, pAllocator, pFramebuffer);
	}

	public unsafe static VkResult vkCreateFramebuffer(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, out VkFramebuffer pFramebuffer)
	{
		fixed (VkFramebuffer* ptr = &pFramebuffer)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkFramebuffer*, VkResult>)vkCreateFramebuffer_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateGraphicsPipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, VkGraphicsPipelineCreateInfo* pCreateInfos, VkAllocationCallbacks* pAllocator, VkPipeline* pPipelines)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, VkGraphicsPipelineCreateInfo*, VkAllocationCallbacks*, VkPipeline*, VkResult>)vkCreateGraphicsPipelines_ptr)(device, pipelineCache, createInfoCount, pCreateInfos, pAllocator, pPipelines);
	}

	public unsafe static VkResult vkCreateGraphicsPipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, VkGraphicsPipelineCreateInfo* pCreateInfos, VkAllocationCallbacks* pAllocator, out VkPipeline pPipelines)
	{
		fixed (VkPipeline* ptr = &pPipelines)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, VkGraphicsPipelineCreateInfo*, VkAllocationCallbacks*, VkPipeline*, VkResult>)vkCreateGraphicsPipelines_ptr)(device, pipelineCache, createInfoCount, pCreateInfos, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateGraphicsPipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, VkGraphicsPipelineCreateInfo* pCreateInfos, ref VkAllocationCallbacks pAllocator, VkPipeline* pPipelines)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, VkGraphicsPipelineCreateInfo*, VkAllocationCallbacks*, VkPipeline*, VkResult>)vkCreateGraphicsPipelines_ptr)(device, pipelineCache, createInfoCount, pCreateInfos, ptr, pPipelines);
		}
	}

	public unsafe static VkResult vkCreateGraphicsPipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, VkGraphicsPipelineCreateInfo* pCreateInfos, ref VkAllocationCallbacks pAllocator, out VkPipeline pPipelines)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkPipeline* ptr2 = &pPipelines)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, VkGraphicsPipelineCreateInfo*, VkAllocationCallbacks*, VkPipeline*, VkResult>)vkCreateGraphicsPipelines_ptr)(device, pipelineCache, createInfoCount, pCreateInfos, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateGraphicsPipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, VkGraphicsPipelineCreateInfo* pCreateInfos, IntPtr pAllocator, VkPipeline* pPipelines)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, VkGraphicsPipelineCreateInfo*, IntPtr, VkPipeline*, VkResult>)vkCreateGraphicsPipelines_ptr)(device, pipelineCache, createInfoCount, pCreateInfos, pAllocator, pPipelines);
	}

	public unsafe static VkResult vkCreateGraphicsPipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, VkGraphicsPipelineCreateInfo* pCreateInfos, IntPtr pAllocator, out VkPipeline pPipelines)
	{
		fixed (VkPipeline* ptr = &pPipelines)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, VkGraphicsPipelineCreateInfo*, IntPtr, VkPipeline*, VkResult>)vkCreateGraphicsPipelines_ptr)(device, pipelineCache, createInfoCount, pCreateInfos, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateGraphicsPipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, ref VkGraphicsPipelineCreateInfo pCreateInfos, VkAllocationCallbacks* pAllocator, VkPipeline* pPipelines)
	{
		fixed (VkGraphicsPipelineCreateInfo* ptr = &pCreateInfos)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, VkGraphicsPipelineCreateInfo*, VkAllocationCallbacks*, VkPipeline*, VkResult>)vkCreateGraphicsPipelines_ptr)(device, pipelineCache, createInfoCount, ptr, pAllocator, pPipelines);
		}
	}

	public unsafe static VkResult vkCreateGraphicsPipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, ref VkGraphicsPipelineCreateInfo pCreateInfos, VkAllocationCallbacks* pAllocator, out VkPipeline pPipelines)
	{
		fixed (VkGraphicsPipelineCreateInfo* ptr = &pCreateInfos)
		{
			fixed (VkPipeline* ptr2 = &pPipelines)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, VkGraphicsPipelineCreateInfo*, VkAllocationCallbacks*, VkPipeline*, VkResult>)vkCreateGraphicsPipelines_ptr)(device, pipelineCache, createInfoCount, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateGraphicsPipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, ref VkGraphicsPipelineCreateInfo pCreateInfos, ref VkAllocationCallbacks pAllocator, VkPipeline* pPipelines)
	{
		fixed (VkGraphicsPipelineCreateInfo* ptr = &pCreateInfos)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, VkGraphicsPipelineCreateInfo*, VkAllocationCallbacks*, VkPipeline*, VkResult>)vkCreateGraphicsPipelines_ptr)(device, pipelineCache, createInfoCount, ptr, ptr2, pPipelines);
			}
		}
	}

	public unsafe static VkResult vkCreateGraphicsPipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, ref VkGraphicsPipelineCreateInfo pCreateInfos, ref VkAllocationCallbacks pAllocator, out VkPipeline pPipelines)
	{
		fixed (VkGraphicsPipelineCreateInfo* ptr = &pCreateInfos)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkPipeline* ptr3 = &pPipelines)
				{
					return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, VkGraphicsPipelineCreateInfo*, VkAllocationCallbacks*, VkPipeline*, VkResult>)vkCreateGraphicsPipelines_ptr)(device, pipelineCache, createInfoCount, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreateGraphicsPipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, ref VkGraphicsPipelineCreateInfo pCreateInfos, IntPtr pAllocator, VkPipeline* pPipelines)
	{
		fixed (VkGraphicsPipelineCreateInfo* ptr = &pCreateInfos)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, VkGraphicsPipelineCreateInfo*, IntPtr, VkPipeline*, VkResult>)vkCreateGraphicsPipelines_ptr)(device, pipelineCache, createInfoCount, ptr, pAllocator, pPipelines);
		}
	}

	public unsafe static VkResult vkCreateGraphicsPipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, ref VkGraphicsPipelineCreateInfo pCreateInfos, IntPtr pAllocator, out VkPipeline pPipelines)
	{
		fixed (VkGraphicsPipelineCreateInfo* ptr = &pCreateInfos)
		{
			fixed (VkPipeline* ptr2 = &pPipelines)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, VkGraphicsPipelineCreateInfo*, IntPtr, VkPipeline*, VkResult>)vkCreateGraphicsPipelines_ptr)(device, pipelineCache, createInfoCount, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateGraphicsPipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, IntPtr pCreateInfos, VkAllocationCallbacks* pAllocator, VkPipeline* pPipelines)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, IntPtr, VkAllocationCallbacks*, VkPipeline*, VkResult>)vkCreateGraphicsPipelines_ptr)(device, pipelineCache, createInfoCount, pCreateInfos, pAllocator, pPipelines);
	}

	public unsafe static VkResult vkCreateGraphicsPipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, IntPtr pCreateInfos, VkAllocationCallbacks* pAllocator, out VkPipeline pPipelines)
	{
		fixed (VkPipeline* ptr = &pPipelines)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, IntPtr, VkAllocationCallbacks*, VkPipeline*, VkResult>)vkCreateGraphicsPipelines_ptr)(device, pipelineCache, createInfoCount, pCreateInfos, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateGraphicsPipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, IntPtr pCreateInfos, ref VkAllocationCallbacks pAllocator, VkPipeline* pPipelines)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, IntPtr, VkAllocationCallbacks*, VkPipeline*, VkResult>)vkCreateGraphicsPipelines_ptr)(device, pipelineCache, createInfoCount, pCreateInfos, ptr, pPipelines);
		}
	}

	public unsafe static VkResult vkCreateGraphicsPipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, IntPtr pCreateInfos, ref VkAllocationCallbacks pAllocator, out VkPipeline pPipelines)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkPipeline* ptr2 = &pPipelines)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, IntPtr, VkAllocationCallbacks*, VkPipeline*, VkResult>)vkCreateGraphicsPipelines_ptr)(device, pipelineCache, createInfoCount, pCreateInfos, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateGraphicsPipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, IntPtr pCreateInfos, IntPtr pAllocator, VkPipeline* pPipelines)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, IntPtr, IntPtr, VkPipeline*, VkResult>)vkCreateGraphicsPipelines_ptr)(device, pipelineCache, createInfoCount, pCreateInfos, pAllocator, pPipelines);
	}

	public unsafe static VkResult vkCreateGraphicsPipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, IntPtr pCreateInfos, IntPtr pAllocator, out VkPipeline pPipelines)
	{
		fixed (VkPipeline* ptr = &pPipelines)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, IntPtr, IntPtr, VkPipeline*, VkResult>)vkCreateGraphicsPipelines_ptr)(device, pipelineCache, createInfoCount, pCreateInfos, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateGraphicsPipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, VkGraphicsPipelineCreateInfo[] pCreateInfos, VkAllocationCallbacks* pAllocator, VkPipeline* pPipelines)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, VkGraphicsPipelineCreateInfo[], VkAllocationCallbacks*, VkPipeline*, VkResult>)vkCreateGraphicsPipelines_ptr)(device, pipelineCache, createInfoCount, pCreateInfos, pAllocator, pPipelines);
	}

	public unsafe static VkResult vkCreateGraphicsPipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, VkGraphicsPipelineCreateInfo[] pCreateInfos, VkAllocationCallbacks* pAllocator, out VkPipeline pPipelines)
	{
		fixed (VkPipeline* ptr = &pPipelines)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, VkGraphicsPipelineCreateInfo[], VkAllocationCallbacks*, VkPipeline*, VkResult>)vkCreateGraphicsPipelines_ptr)(device, pipelineCache, createInfoCount, pCreateInfos, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateGraphicsPipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, VkGraphicsPipelineCreateInfo[] pCreateInfos, ref VkAllocationCallbacks pAllocator, VkPipeline* pPipelines)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, VkGraphicsPipelineCreateInfo[], VkAllocationCallbacks*, VkPipeline*, VkResult>)vkCreateGraphicsPipelines_ptr)(device, pipelineCache, createInfoCount, pCreateInfos, ptr, pPipelines);
		}
	}

	public unsafe static VkResult vkCreateGraphicsPipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, VkGraphicsPipelineCreateInfo[] pCreateInfos, ref VkAllocationCallbacks pAllocator, out VkPipeline pPipelines)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkPipeline* ptr2 = &pPipelines)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, VkGraphicsPipelineCreateInfo[], VkAllocationCallbacks*, VkPipeline*, VkResult>)vkCreateGraphicsPipelines_ptr)(device, pipelineCache, createInfoCount, pCreateInfos, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateGraphicsPipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, VkGraphicsPipelineCreateInfo[] pCreateInfos, IntPtr pAllocator, VkPipeline* pPipelines)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, VkGraphicsPipelineCreateInfo[], IntPtr, VkPipeline*, VkResult>)vkCreateGraphicsPipelines_ptr)(device, pipelineCache, createInfoCount, pCreateInfos, pAllocator, pPipelines);
	}

	public unsafe static VkResult vkCreateGraphicsPipelines(VkDevice device, VkPipelineCache pipelineCache, uint createInfoCount, VkGraphicsPipelineCreateInfo[] pCreateInfos, IntPtr pAllocator, out VkPipeline pPipelines)
	{
		fixed (VkPipeline* ptr = &pPipelines)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, VkGraphicsPipelineCreateInfo[], IntPtr, VkPipeline*, VkResult>)vkCreateGraphicsPipelines_ptr)(device, pipelineCache, createInfoCount, pCreateInfos, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateImage(VkDevice device, VkImageCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkImage* pImage)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkImageCreateInfo*, VkAllocationCallbacks*, VkImage*, VkResult>)vkCreateImage_ptr)(device, pCreateInfo, pAllocator, pImage);
	}

	public unsafe static VkResult vkCreateImage(VkDevice device, VkImageCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, out VkImage pImage)
	{
		fixed (VkImage* ptr = &pImage)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkImageCreateInfo*, VkAllocationCallbacks*, VkImage*, VkResult>)vkCreateImage_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateImage(VkDevice device, VkImageCreateInfo* pCreateInfo, ref VkAllocationCallbacks pAllocator, VkImage* pImage)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkImageCreateInfo*, VkAllocationCallbacks*, VkImage*, VkResult>)vkCreateImage_ptr)(device, pCreateInfo, ptr, pImage);
		}
	}

	public unsafe static VkResult vkCreateImage(VkDevice device, VkImageCreateInfo* pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkImage pImage)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkImage* ptr2 = &pImage)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkImageCreateInfo*, VkAllocationCallbacks*, VkImage*, VkResult>)vkCreateImage_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateImage(VkDevice device, VkImageCreateInfo* pCreateInfo, IntPtr pAllocator, VkImage* pImage)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkImageCreateInfo*, IntPtr, VkImage*, VkResult>)vkCreateImage_ptr)(device, pCreateInfo, pAllocator, pImage);
	}

	public unsafe static VkResult vkCreateImage(VkDevice device, VkImageCreateInfo* pCreateInfo, IntPtr pAllocator, out VkImage pImage)
	{
		fixed (VkImage* ptr = &pImage)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkImageCreateInfo*, IntPtr, VkImage*, VkResult>)vkCreateImage_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateImage(VkDevice device, ref VkImageCreateInfo pCreateInfo, VkAllocationCallbacks* pAllocator, VkImage* pImage)
	{
		fixed (VkImageCreateInfo* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkImageCreateInfo*, VkAllocationCallbacks*, VkImage*, VkResult>)vkCreateImage_ptr)(device, ptr, pAllocator, pImage);
		}
	}

	public unsafe static VkResult vkCreateImage(VkDevice device, ref VkImageCreateInfo pCreateInfo, VkAllocationCallbacks* pAllocator, out VkImage pImage)
	{
		fixed (VkImageCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkImage* ptr2 = &pImage)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkImageCreateInfo*, VkAllocationCallbacks*, VkImage*, VkResult>)vkCreateImage_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateImage(VkDevice device, ref VkImageCreateInfo pCreateInfo, ref VkAllocationCallbacks pAllocator, VkImage* pImage)
	{
		fixed (VkImageCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkImageCreateInfo*, VkAllocationCallbacks*, VkImage*, VkResult>)vkCreateImage_ptr)(device, ptr, ptr2, pImage);
			}
		}
	}

	public unsafe static VkResult vkCreateImage(VkDevice device, ref VkImageCreateInfo pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkImage pImage)
	{
		fixed (VkImageCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkImage* ptr3 = &pImage)
				{
					return ((delegate* unmanaged[Stdcall]<VkDevice, VkImageCreateInfo*, VkAllocationCallbacks*, VkImage*, VkResult>)vkCreateImage_ptr)(device, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreateImage(VkDevice device, ref VkImageCreateInfo pCreateInfo, IntPtr pAllocator, VkImage* pImage)
	{
		fixed (VkImageCreateInfo* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkImageCreateInfo*, IntPtr, VkImage*, VkResult>)vkCreateImage_ptr)(device, ptr, pAllocator, pImage);
		}
	}

	public unsafe static VkResult vkCreateImage(VkDevice device, ref VkImageCreateInfo pCreateInfo, IntPtr pAllocator, out VkImage pImage)
	{
		fixed (VkImageCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkImage* ptr2 = &pImage)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkImageCreateInfo*, IntPtr, VkImage*, VkResult>)vkCreateImage_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateImage(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, VkImage* pImage)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkImage*, VkResult>)vkCreateImage_ptr)(device, pCreateInfo, pAllocator, pImage);
	}

	public unsafe static VkResult vkCreateImage(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, out VkImage pImage)
	{
		fixed (VkImage* ptr = &pImage)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkImage*, VkResult>)vkCreateImage_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateImage(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, VkImage* pImage)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkImage*, VkResult>)vkCreateImage_ptr)(device, pCreateInfo, ptr, pImage);
		}
	}

	public unsafe static VkResult vkCreateImage(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkImage pImage)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkImage* ptr2 = &pImage)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkImage*, VkResult>)vkCreateImage_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateImage(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, VkImage* pImage)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkImage*, VkResult>)vkCreateImage_ptr)(device, pCreateInfo, pAllocator, pImage);
	}

	public unsafe static VkResult vkCreateImage(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, out VkImage pImage)
	{
		fixed (VkImage* ptr = &pImage)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkImage*, VkResult>)vkCreateImage_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateImageView(VkDevice device, VkImageViewCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkImageView* pView)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkImageViewCreateInfo*, VkAllocationCallbacks*, VkImageView*, VkResult>)vkCreateImageView_ptr)(device, pCreateInfo, pAllocator, pView);
	}

	public unsafe static VkResult vkCreateImageView(VkDevice device, VkImageViewCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, out VkImageView pView)
	{
		fixed (VkImageView* ptr = &pView)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkImageViewCreateInfo*, VkAllocationCallbacks*, VkImageView*, VkResult>)vkCreateImageView_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateImageView(VkDevice device, VkImageViewCreateInfo* pCreateInfo, ref VkAllocationCallbacks pAllocator, VkImageView* pView)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkImageViewCreateInfo*, VkAllocationCallbacks*, VkImageView*, VkResult>)vkCreateImageView_ptr)(device, pCreateInfo, ptr, pView);
		}
	}

	public unsafe static VkResult vkCreateImageView(VkDevice device, VkImageViewCreateInfo* pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkImageView pView)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkImageView* ptr2 = &pView)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkImageViewCreateInfo*, VkAllocationCallbacks*, VkImageView*, VkResult>)vkCreateImageView_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateImageView(VkDevice device, VkImageViewCreateInfo* pCreateInfo, IntPtr pAllocator, VkImageView* pView)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkImageViewCreateInfo*, IntPtr, VkImageView*, VkResult>)vkCreateImageView_ptr)(device, pCreateInfo, pAllocator, pView);
	}

	public unsafe static VkResult vkCreateImageView(VkDevice device, VkImageViewCreateInfo* pCreateInfo, IntPtr pAllocator, out VkImageView pView)
	{
		fixed (VkImageView* ptr = &pView)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkImageViewCreateInfo*, IntPtr, VkImageView*, VkResult>)vkCreateImageView_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateImageView(VkDevice device, ref VkImageViewCreateInfo pCreateInfo, VkAllocationCallbacks* pAllocator, VkImageView* pView)
	{
		fixed (VkImageViewCreateInfo* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkImageViewCreateInfo*, VkAllocationCallbacks*, VkImageView*, VkResult>)vkCreateImageView_ptr)(device, ptr, pAllocator, pView);
		}
	}

	public unsafe static VkResult vkCreateImageView(VkDevice device, ref VkImageViewCreateInfo pCreateInfo, VkAllocationCallbacks* pAllocator, out VkImageView pView)
	{
		fixed (VkImageViewCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkImageView* ptr2 = &pView)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkImageViewCreateInfo*, VkAllocationCallbacks*, VkImageView*, VkResult>)vkCreateImageView_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateImageView(VkDevice device, ref VkImageViewCreateInfo pCreateInfo, ref VkAllocationCallbacks pAllocator, VkImageView* pView)
	{
		fixed (VkImageViewCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkImageViewCreateInfo*, VkAllocationCallbacks*, VkImageView*, VkResult>)vkCreateImageView_ptr)(device, ptr, ptr2, pView);
			}
		}
	}

	public unsafe static VkResult vkCreateImageView(VkDevice device, ref VkImageViewCreateInfo pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkImageView pView)
	{
		fixed (VkImageViewCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkImageView* ptr3 = &pView)
				{
					return ((delegate* unmanaged[Stdcall]<VkDevice, VkImageViewCreateInfo*, VkAllocationCallbacks*, VkImageView*, VkResult>)vkCreateImageView_ptr)(device, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreateImageView(VkDevice device, ref VkImageViewCreateInfo pCreateInfo, IntPtr pAllocator, VkImageView* pView)
	{
		fixed (VkImageViewCreateInfo* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkImageViewCreateInfo*, IntPtr, VkImageView*, VkResult>)vkCreateImageView_ptr)(device, ptr, pAllocator, pView);
		}
	}

	public unsafe static VkResult vkCreateImageView(VkDevice device, ref VkImageViewCreateInfo pCreateInfo, IntPtr pAllocator, out VkImageView pView)
	{
		fixed (VkImageViewCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkImageView* ptr2 = &pView)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkImageViewCreateInfo*, IntPtr, VkImageView*, VkResult>)vkCreateImageView_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateImageView(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, VkImageView* pView)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkImageView*, VkResult>)vkCreateImageView_ptr)(device, pCreateInfo, pAllocator, pView);
	}

	public unsafe static VkResult vkCreateImageView(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, out VkImageView pView)
	{
		fixed (VkImageView* ptr = &pView)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkImageView*, VkResult>)vkCreateImageView_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateImageView(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, VkImageView* pView)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkImageView*, VkResult>)vkCreateImageView_ptr)(device, pCreateInfo, ptr, pView);
		}
	}

	public unsafe static VkResult vkCreateImageView(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkImageView pView)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkImageView* ptr2 = &pView)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkImageView*, VkResult>)vkCreateImageView_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateImageView(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, VkImageView* pView)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkImageView*, VkResult>)vkCreateImageView_ptr)(device, pCreateInfo, pAllocator, pView);
	}

	public unsafe static VkResult vkCreateImageView(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, out VkImageView pView)
	{
		fixed (VkImageView* ptr = &pView)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkImageView*, VkResult>)vkCreateImageView_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateIndirectCommandsLayoutNVX(VkDevice device, VkIndirectCommandsLayoutCreateInfoNVX* pCreateInfo, VkAllocationCallbacks* pAllocator, VkIndirectCommandsLayoutNVX* pIndirectCommandsLayout)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkIndirectCommandsLayoutCreateInfoNVX*, VkAllocationCallbacks*, VkIndirectCommandsLayoutNVX*, VkResult>)vkCreateIndirectCommandsLayoutNVX_ptr)(device, pCreateInfo, pAllocator, pIndirectCommandsLayout);
	}

	public unsafe static VkResult vkCreateIndirectCommandsLayoutNVX(VkDevice device, VkIndirectCommandsLayoutCreateInfoNVX* pCreateInfo, VkAllocationCallbacks* pAllocator, out VkIndirectCommandsLayoutNVX pIndirectCommandsLayout)
	{
		fixed (VkIndirectCommandsLayoutNVX* ptr = &pIndirectCommandsLayout)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkIndirectCommandsLayoutCreateInfoNVX*, VkAllocationCallbacks*, VkIndirectCommandsLayoutNVX*, VkResult>)vkCreateIndirectCommandsLayoutNVX_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateIndirectCommandsLayoutNVX(VkDevice device, VkIndirectCommandsLayoutCreateInfoNVX* pCreateInfo, ref VkAllocationCallbacks pAllocator, VkIndirectCommandsLayoutNVX* pIndirectCommandsLayout)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkIndirectCommandsLayoutCreateInfoNVX*, VkAllocationCallbacks*, VkIndirectCommandsLayoutNVX*, VkResult>)vkCreateIndirectCommandsLayoutNVX_ptr)(device, pCreateInfo, ptr, pIndirectCommandsLayout);
		}
	}

	public unsafe static VkResult vkCreateIndirectCommandsLayoutNVX(VkDevice device, VkIndirectCommandsLayoutCreateInfoNVX* pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkIndirectCommandsLayoutNVX pIndirectCommandsLayout)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkIndirectCommandsLayoutNVX* ptr2 = &pIndirectCommandsLayout)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkIndirectCommandsLayoutCreateInfoNVX*, VkAllocationCallbacks*, VkIndirectCommandsLayoutNVX*, VkResult>)vkCreateIndirectCommandsLayoutNVX_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateIndirectCommandsLayoutNVX(VkDevice device, VkIndirectCommandsLayoutCreateInfoNVX* pCreateInfo, IntPtr pAllocator, VkIndirectCommandsLayoutNVX* pIndirectCommandsLayout)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkIndirectCommandsLayoutCreateInfoNVX*, IntPtr, VkIndirectCommandsLayoutNVX*, VkResult>)vkCreateIndirectCommandsLayoutNVX_ptr)(device, pCreateInfo, pAllocator, pIndirectCommandsLayout);
	}

	public unsafe static VkResult vkCreateIndirectCommandsLayoutNVX(VkDevice device, VkIndirectCommandsLayoutCreateInfoNVX* pCreateInfo, IntPtr pAllocator, out VkIndirectCommandsLayoutNVX pIndirectCommandsLayout)
	{
		fixed (VkIndirectCommandsLayoutNVX* ptr = &pIndirectCommandsLayout)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkIndirectCommandsLayoutCreateInfoNVX*, IntPtr, VkIndirectCommandsLayoutNVX*, VkResult>)vkCreateIndirectCommandsLayoutNVX_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateIndirectCommandsLayoutNVX(VkDevice device, ref VkIndirectCommandsLayoutCreateInfoNVX pCreateInfo, VkAllocationCallbacks* pAllocator, VkIndirectCommandsLayoutNVX* pIndirectCommandsLayout)
	{
		fixed (VkIndirectCommandsLayoutCreateInfoNVX* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkIndirectCommandsLayoutCreateInfoNVX*, VkAllocationCallbacks*, VkIndirectCommandsLayoutNVX*, VkResult>)vkCreateIndirectCommandsLayoutNVX_ptr)(device, ptr, pAllocator, pIndirectCommandsLayout);
		}
	}

	public unsafe static VkResult vkCreateIndirectCommandsLayoutNVX(VkDevice device, ref VkIndirectCommandsLayoutCreateInfoNVX pCreateInfo, VkAllocationCallbacks* pAllocator, out VkIndirectCommandsLayoutNVX pIndirectCommandsLayout)
	{
		fixed (VkIndirectCommandsLayoutCreateInfoNVX* ptr = &pCreateInfo)
		{
			fixed (VkIndirectCommandsLayoutNVX* ptr2 = &pIndirectCommandsLayout)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkIndirectCommandsLayoutCreateInfoNVX*, VkAllocationCallbacks*, VkIndirectCommandsLayoutNVX*, VkResult>)vkCreateIndirectCommandsLayoutNVX_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateIndirectCommandsLayoutNVX(VkDevice device, ref VkIndirectCommandsLayoutCreateInfoNVX pCreateInfo, ref VkAllocationCallbacks pAllocator, VkIndirectCommandsLayoutNVX* pIndirectCommandsLayout)
	{
		fixed (VkIndirectCommandsLayoutCreateInfoNVX* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkIndirectCommandsLayoutCreateInfoNVX*, VkAllocationCallbacks*, VkIndirectCommandsLayoutNVX*, VkResult>)vkCreateIndirectCommandsLayoutNVX_ptr)(device, ptr, ptr2, pIndirectCommandsLayout);
			}
		}
	}

	public unsafe static VkResult vkCreateIndirectCommandsLayoutNVX(VkDevice device, ref VkIndirectCommandsLayoutCreateInfoNVX pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkIndirectCommandsLayoutNVX pIndirectCommandsLayout)
	{
		fixed (VkIndirectCommandsLayoutCreateInfoNVX* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkIndirectCommandsLayoutNVX* ptr3 = &pIndirectCommandsLayout)
				{
					return ((delegate* unmanaged[Stdcall]<VkDevice, VkIndirectCommandsLayoutCreateInfoNVX*, VkAllocationCallbacks*, VkIndirectCommandsLayoutNVX*, VkResult>)vkCreateIndirectCommandsLayoutNVX_ptr)(device, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreateIndirectCommandsLayoutNVX(VkDevice device, ref VkIndirectCommandsLayoutCreateInfoNVX pCreateInfo, IntPtr pAllocator, VkIndirectCommandsLayoutNVX* pIndirectCommandsLayout)
	{
		fixed (VkIndirectCommandsLayoutCreateInfoNVX* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkIndirectCommandsLayoutCreateInfoNVX*, IntPtr, VkIndirectCommandsLayoutNVX*, VkResult>)vkCreateIndirectCommandsLayoutNVX_ptr)(device, ptr, pAllocator, pIndirectCommandsLayout);
		}
	}

	public unsafe static VkResult vkCreateIndirectCommandsLayoutNVX(VkDevice device, ref VkIndirectCommandsLayoutCreateInfoNVX pCreateInfo, IntPtr pAllocator, out VkIndirectCommandsLayoutNVX pIndirectCommandsLayout)
	{
		fixed (VkIndirectCommandsLayoutCreateInfoNVX* ptr = &pCreateInfo)
		{
			fixed (VkIndirectCommandsLayoutNVX* ptr2 = &pIndirectCommandsLayout)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkIndirectCommandsLayoutCreateInfoNVX*, IntPtr, VkIndirectCommandsLayoutNVX*, VkResult>)vkCreateIndirectCommandsLayoutNVX_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateIndirectCommandsLayoutNVX(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, VkIndirectCommandsLayoutNVX* pIndirectCommandsLayout)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkIndirectCommandsLayoutNVX*, VkResult>)vkCreateIndirectCommandsLayoutNVX_ptr)(device, pCreateInfo, pAllocator, pIndirectCommandsLayout);
	}

	public unsafe static VkResult vkCreateIndirectCommandsLayoutNVX(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, out VkIndirectCommandsLayoutNVX pIndirectCommandsLayout)
	{
		fixed (VkIndirectCommandsLayoutNVX* ptr = &pIndirectCommandsLayout)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkIndirectCommandsLayoutNVX*, VkResult>)vkCreateIndirectCommandsLayoutNVX_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateIndirectCommandsLayoutNVX(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, VkIndirectCommandsLayoutNVX* pIndirectCommandsLayout)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkIndirectCommandsLayoutNVX*, VkResult>)vkCreateIndirectCommandsLayoutNVX_ptr)(device, pCreateInfo, ptr, pIndirectCommandsLayout);
		}
	}

	public unsafe static VkResult vkCreateIndirectCommandsLayoutNVX(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkIndirectCommandsLayoutNVX pIndirectCommandsLayout)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkIndirectCommandsLayoutNVX* ptr2 = &pIndirectCommandsLayout)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkIndirectCommandsLayoutNVX*, VkResult>)vkCreateIndirectCommandsLayoutNVX_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateIndirectCommandsLayoutNVX(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, VkIndirectCommandsLayoutNVX* pIndirectCommandsLayout)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkIndirectCommandsLayoutNVX*, VkResult>)vkCreateIndirectCommandsLayoutNVX_ptr)(device, pCreateInfo, pAllocator, pIndirectCommandsLayout);
	}

	public unsafe static VkResult vkCreateIndirectCommandsLayoutNVX(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, out VkIndirectCommandsLayoutNVX pIndirectCommandsLayout)
	{
		fixed (VkIndirectCommandsLayoutNVX* ptr = &pIndirectCommandsLayout)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkIndirectCommandsLayoutNVX*, VkResult>)vkCreateIndirectCommandsLayoutNVX_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateInstance(VkInstanceCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkInstance* pInstance)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstanceCreateInfo*, VkAllocationCallbacks*, VkInstance*, VkResult>)vkCreateInstance_ptr)(pCreateInfo, pAllocator, pInstance);
	}

	public unsafe static VkResult vkCreateInstance(VkInstanceCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, out VkInstance pInstance)
	{
		fixed (VkInstance* ptr = &pInstance)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstanceCreateInfo*, VkAllocationCallbacks*, VkInstance*, VkResult>)vkCreateInstance_ptr)(pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateInstance(VkInstanceCreateInfo* pCreateInfo, ref VkAllocationCallbacks pAllocator, VkInstance* pInstance)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstanceCreateInfo*, VkAllocationCallbacks*, VkInstance*, VkResult>)vkCreateInstance_ptr)(pCreateInfo, ptr, pInstance);
		}
	}

	public unsafe static VkResult vkCreateInstance(VkInstanceCreateInfo* pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkInstance pInstance)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkInstance* ptr2 = &pInstance)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstanceCreateInfo*, VkAllocationCallbacks*, VkInstance*, VkResult>)vkCreateInstance_ptr)(pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateInstance(VkInstanceCreateInfo* pCreateInfo, IntPtr pAllocator, VkInstance* pInstance)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstanceCreateInfo*, IntPtr, VkInstance*, VkResult>)vkCreateInstance_ptr)(pCreateInfo, pAllocator, pInstance);
	}

	public unsafe static VkResult vkCreateInstance(VkInstanceCreateInfo* pCreateInfo, IntPtr pAllocator, out VkInstance pInstance)
	{
		fixed (VkInstance* ptr = &pInstance)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstanceCreateInfo*, IntPtr, VkInstance*, VkResult>)vkCreateInstance_ptr)(pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateInstance(ref VkInstanceCreateInfo pCreateInfo, VkAllocationCallbacks* pAllocator, VkInstance* pInstance)
	{
		fixed (VkInstanceCreateInfo* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstanceCreateInfo*, VkAllocationCallbacks*, VkInstance*, VkResult>)vkCreateInstance_ptr)(ptr, pAllocator, pInstance);
		}
	}

	public unsafe static VkResult vkCreateInstance(ref VkInstanceCreateInfo pCreateInfo, VkAllocationCallbacks* pAllocator, out VkInstance pInstance)
	{
		fixed (VkInstanceCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkInstance* ptr2 = &pInstance)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstanceCreateInfo*, VkAllocationCallbacks*, VkInstance*, VkResult>)vkCreateInstance_ptr)(ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateInstance(ref VkInstanceCreateInfo pCreateInfo, ref VkAllocationCallbacks pAllocator, VkInstance* pInstance)
	{
		fixed (VkInstanceCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstanceCreateInfo*, VkAllocationCallbacks*, VkInstance*, VkResult>)vkCreateInstance_ptr)(ptr, ptr2, pInstance);
			}
		}
	}

	public unsafe static VkResult vkCreateInstance(ref VkInstanceCreateInfo pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkInstance pInstance)
	{
		fixed (VkInstanceCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkInstance* ptr3 = &pInstance)
				{
					return ((delegate* unmanaged[Stdcall]<VkInstanceCreateInfo*, VkAllocationCallbacks*, VkInstance*, VkResult>)vkCreateInstance_ptr)(ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreateInstance(ref VkInstanceCreateInfo pCreateInfo, IntPtr pAllocator, VkInstance* pInstance)
	{
		fixed (VkInstanceCreateInfo* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstanceCreateInfo*, IntPtr, VkInstance*, VkResult>)vkCreateInstance_ptr)(ptr, pAllocator, pInstance);
		}
	}

	public unsafe static VkResult vkCreateInstance(ref VkInstanceCreateInfo pCreateInfo, IntPtr pAllocator, out VkInstance pInstance)
	{
		fixed (VkInstanceCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkInstance* ptr2 = &pInstance)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstanceCreateInfo*, IntPtr, VkInstance*, VkResult>)vkCreateInstance_ptr)(ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateInstance(IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, VkInstance* pInstance)
	{
		return ((delegate* unmanaged[Stdcall]<IntPtr, VkAllocationCallbacks*, VkInstance*, VkResult>)vkCreateInstance_ptr)(pCreateInfo, pAllocator, pInstance);
	}

	public unsafe static VkResult vkCreateInstance(IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, out VkInstance pInstance)
	{
		fixed (VkInstance* ptr = &pInstance)
		{
			return ((delegate* unmanaged[Stdcall]<IntPtr, VkAllocationCallbacks*, VkInstance*, VkResult>)vkCreateInstance_ptr)(pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateInstance(IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, VkInstance* pInstance)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<IntPtr, VkAllocationCallbacks*, VkInstance*, VkResult>)vkCreateInstance_ptr)(pCreateInfo, ptr, pInstance);
		}
	}

	public unsafe static VkResult vkCreateInstance(IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkInstance pInstance)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkInstance* ptr2 = &pInstance)
			{
				return ((delegate* unmanaged[Stdcall]<IntPtr, VkAllocationCallbacks*, VkInstance*, VkResult>)vkCreateInstance_ptr)(pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateInstance(IntPtr pCreateInfo, IntPtr pAllocator, VkInstance* pInstance)
	{
		return ((delegate* unmanaged[Stdcall]<IntPtr, IntPtr, VkInstance*, VkResult>)vkCreateInstance_ptr)(pCreateInfo, pAllocator, pInstance);
	}

	public unsafe static VkResult vkCreateInstance(IntPtr pCreateInfo, IntPtr pAllocator, out VkInstance pInstance)
	{
		fixed (VkInstance* ptr = &pInstance)
		{
			return ((delegate* unmanaged[Stdcall]<IntPtr, IntPtr, VkInstance*, VkResult>)vkCreateInstance_ptr)(pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateIOSSurfaceMVK(VkInstance instance, VkIOSSurfaceCreateInfoMVK* pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, VkIOSSurfaceCreateInfoMVK*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateIOSSurfaceMVK_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateIOSSurfaceMVK(VkInstance instance, VkIOSSurfaceCreateInfoMVK* pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkIOSSurfaceCreateInfoMVK*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateIOSSurfaceMVK_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateIOSSurfaceMVK(VkInstance instance, VkIOSSurfaceCreateInfoMVK* pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkIOSSurfaceCreateInfoMVK*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateIOSSurfaceMVK_ptr)(instance, pCreateInfo, ptr, pSurface);
		}
	}

	public unsafe static VkResult vkCreateIOSSurfaceMVK(VkInstance instance, VkIOSSurfaceCreateInfoMVK* pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkIOSSurfaceCreateInfoMVK*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateIOSSurfaceMVK_ptr)(instance, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateIOSSurfaceMVK(VkInstance instance, VkIOSSurfaceCreateInfoMVK* pCreateInfo, IntPtr pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, VkIOSSurfaceCreateInfoMVK*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateIOSSurfaceMVK_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateIOSSurfaceMVK(VkInstance instance, VkIOSSurfaceCreateInfoMVK* pCreateInfo, IntPtr pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkIOSSurfaceCreateInfoMVK*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateIOSSurfaceMVK_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateIOSSurfaceMVK(VkInstance instance, ref VkIOSSurfaceCreateInfoMVK pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkIOSSurfaceCreateInfoMVK* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkIOSSurfaceCreateInfoMVK*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateIOSSurfaceMVK_ptr)(instance, ptr, pAllocator, pSurface);
		}
	}

	public unsafe static VkResult vkCreateIOSSurfaceMVK(VkInstance instance, ref VkIOSSurfaceCreateInfoMVK pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkIOSSurfaceCreateInfoMVK* ptr = &pCreateInfo)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkIOSSurfaceCreateInfoMVK*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateIOSSurfaceMVK_ptr)(instance, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateIOSSurfaceMVK(VkInstance instance, ref VkIOSSurfaceCreateInfoMVK pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkIOSSurfaceCreateInfoMVK* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkIOSSurfaceCreateInfoMVK*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateIOSSurfaceMVK_ptr)(instance, ptr, ptr2, pSurface);
			}
		}
	}

	public unsafe static VkResult vkCreateIOSSurfaceMVK(VkInstance instance, ref VkIOSSurfaceCreateInfoMVK pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkIOSSurfaceCreateInfoMVK* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkSurfaceKHR* ptr3 = &pSurface)
				{
					return ((delegate* unmanaged[Stdcall]<VkInstance, VkIOSSurfaceCreateInfoMVK*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateIOSSurfaceMVK_ptr)(instance, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreateIOSSurfaceMVK(VkInstance instance, ref VkIOSSurfaceCreateInfoMVK pCreateInfo, IntPtr pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkIOSSurfaceCreateInfoMVK* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkIOSSurfaceCreateInfoMVK*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateIOSSurfaceMVK_ptr)(instance, ptr, pAllocator, pSurface);
		}
	}

	public unsafe static VkResult vkCreateIOSSurfaceMVK(VkInstance instance, ref VkIOSSurfaceCreateInfoMVK pCreateInfo, IntPtr pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkIOSSurfaceCreateInfoMVK* ptr = &pCreateInfo)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkIOSSurfaceCreateInfoMVK*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateIOSSurfaceMVK_ptr)(instance, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateIOSSurfaceMVK(VkInstance instance, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateIOSSurfaceMVK_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateIOSSurfaceMVK(VkInstance instance, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateIOSSurfaceMVK_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateIOSSurfaceMVK(VkInstance instance, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateIOSSurfaceMVK_ptr)(instance, pCreateInfo, ptr, pSurface);
		}
	}

	public unsafe static VkResult vkCreateIOSSurfaceMVK(VkInstance instance, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateIOSSurfaceMVK_ptr)(instance, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateIOSSurfaceMVK(VkInstance instance, IntPtr pCreateInfo, IntPtr pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateIOSSurfaceMVK_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateIOSSurfaceMVK(VkInstance instance, IntPtr pCreateInfo, IntPtr pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateIOSSurfaceMVK_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateMacOSSurfaceMVK(VkInstance instance, VkMacOSSurfaceCreateInfoMVK* pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, VkMacOSSurfaceCreateInfoMVK*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateMacOSSurfaceMVK_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateMacOSSurfaceMVK(VkInstance instance, VkMacOSSurfaceCreateInfoMVK* pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkMacOSSurfaceCreateInfoMVK*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateMacOSSurfaceMVK_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateMacOSSurfaceMVK(VkInstance instance, VkMacOSSurfaceCreateInfoMVK* pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkMacOSSurfaceCreateInfoMVK*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateMacOSSurfaceMVK_ptr)(instance, pCreateInfo, ptr, pSurface);
		}
	}

	public unsafe static VkResult vkCreateMacOSSurfaceMVK(VkInstance instance, VkMacOSSurfaceCreateInfoMVK* pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkMacOSSurfaceCreateInfoMVK*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateMacOSSurfaceMVK_ptr)(instance, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateMacOSSurfaceMVK(VkInstance instance, VkMacOSSurfaceCreateInfoMVK* pCreateInfo, IntPtr pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, VkMacOSSurfaceCreateInfoMVK*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateMacOSSurfaceMVK_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateMacOSSurfaceMVK(VkInstance instance, VkMacOSSurfaceCreateInfoMVK* pCreateInfo, IntPtr pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkMacOSSurfaceCreateInfoMVK*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateMacOSSurfaceMVK_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateMacOSSurfaceMVK(VkInstance instance, ref VkMacOSSurfaceCreateInfoMVK pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkMacOSSurfaceCreateInfoMVK* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkMacOSSurfaceCreateInfoMVK*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateMacOSSurfaceMVK_ptr)(instance, ptr, pAllocator, pSurface);
		}
	}

	public unsafe static VkResult vkCreateMacOSSurfaceMVK(VkInstance instance, ref VkMacOSSurfaceCreateInfoMVK pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkMacOSSurfaceCreateInfoMVK* ptr = &pCreateInfo)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkMacOSSurfaceCreateInfoMVK*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateMacOSSurfaceMVK_ptr)(instance, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateMacOSSurfaceMVK(VkInstance instance, ref VkMacOSSurfaceCreateInfoMVK pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkMacOSSurfaceCreateInfoMVK* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkMacOSSurfaceCreateInfoMVK*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateMacOSSurfaceMVK_ptr)(instance, ptr, ptr2, pSurface);
			}
		}
	}

	public unsafe static VkResult vkCreateMacOSSurfaceMVK(VkInstance instance, ref VkMacOSSurfaceCreateInfoMVK pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkMacOSSurfaceCreateInfoMVK* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkSurfaceKHR* ptr3 = &pSurface)
				{
					return ((delegate* unmanaged[Stdcall]<VkInstance, VkMacOSSurfaceCreateInfoMVK*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateMacOSSurfaceMVK_ptr)(instance, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreateMacOSSurfaceMVK(VkInstance instance, ref VkMacOSSurfaceCreateInfoMVK pCreateInfo, IntPtr pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkMacOSSurfaceCreateInfoMVK* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkMacOSSurfaceCreateInfoMVK*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateMacOSSurfaceMVK_ptr)(instance, ptr, pAllocator, pSurface);
		}
	}

	public unsafe static VkResult vkCreateMacOSSurfaceMVK(VkInstance instance, ref VkMacOSSurfaceCreateInfoMVK pCreateInfo, IntPtr pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkMacOSSurfaceCreateInfoMVK* ptr = &pCreateInfo)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkMacOSSurfaceCreateInfoMVK*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateMacOSSurfaceMVK_ptr)(instance, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateMacOSSurfaceMVK(VkInstance instance, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateMacOSSurfaceMVK_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateMacOSSurfaceMVK(VkInstance instance, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateMacOSSurfaceMVK_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateMacOSSurfaceMVK(VkInstance instance, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateMacOSSurfaceMVK_ptr)(instance, pCreateInfo, ptr, pSurface);
		}
	}

	public unsafe static VkResult vkCreateMacOSSurfaceMVK(VkInstance instance, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateMacOSSurfaceMVK_ptr)(instance, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateMacOSSurfaceMVK(VkInstance instance, IntPtr pCreateInfo, IntPtr pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateMacOSSurfaceMVK_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateMacOSSurfaceMVK(VkInstance instance, IntPtr pCreateInfo, IntPtr pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateMacOSSurfaceMVK_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateMirSurfaceKHR(VkInstance instance, VkMirSurfaceCreateInfoKHR* pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, VkMirSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateMirSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateMirSurfaceKHR(VkInstance instance, VkMirSurfaceCreateInfoKHR* pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkMirSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateMirSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateMirSurfaceKHR(VkInstance instance, VkMirSurfaceCreateInfoKHR* pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkMirSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateMirSurfaceKHR_ptr)(instance, pCreateInfo, ptr, pSurface);
		}
	}

	public unsafe static VkResult vkCreateMirSurfaceKHR(VkInstance instance, VkMirSurfaceCreateInfoKHR* pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkMirSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateMirSurfaceKHR_ptr)(instance, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateMirSurfaceKHR(VkInstance instance, VkMirSurfaceCreateInfoKHR* pCreateInfo, IntPtr pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, VkMirSurfaceCreateInfoKHR*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateMirSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateMirSurfaceKHR(VkInstance instance, VkMirSurfaceCreateInfoKHR* pCreateInfo, IntPtr pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkMirSurfaceCreateInfoKHR*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateMirSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateMirSurfaceKHR(VkInstance instance, ref VkMirSurfaceCreateInfoKHR pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkMirSurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkMirSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateMirSurfaceKHR_ptr)(instance, ptr, pAllocator, pSurface);
		}
	}

	public unsafe static VkResult vkCreateMirSurfaceKHR(VkInstance instance, ref VkMirSurfaceCreateInfoKHR pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkMirSurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkMirSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateMirSurfaceKHR_ptr)(instance, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateMirSurfaceKHR(VkInstance instance, ref VkMirSurfaceCreateInfoKHR pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkMirSurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkMirSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateMirSurfaceKHR_ptr)(instance, ptr, ptr2, pSurface);
			}
		}
	}

	public unsafe static VkResult vkCreateMirSurfaceKHR(VkInstance instance, ref VkMirSurfaceCreateInfoKHR pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkMirSurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkSurfaceKHR* ptr3 = &pSurface)
				{
					return ((delegate* unmanaged[Stdcall]<VkInstance, VkMirSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateMirSurfaceKHR_ptr)(instance, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreateMirSurfaceKHR(VkInstance instance, ref VkMirSurfaceCreateInfoKHR pCreateInfo, IntPtr pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkMirSurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkMirSurfaceCreateInfoKHR*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateMirSurfaceKHR_ptr)(instance, ptr, pAllocator, pSurface);
		}
	}

	public unsafe static VkResult vkCreateMirSurfaceKHR(VkInstance instance, ref VkMirSurfaceCreateInfoKHR pCreateInfo, IntPtr pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkMirSurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkMirSurfaceCreateInfoKHR*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateMirSurfaceKHR_ptr)(instance, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateMirSurfaceKHR(VkInstance instance, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateMirSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateMirSurfaceKHR(VkInstance instance, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateMirSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateMirSurfaceKHR(VkInstance instance, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateMirSurfaceKHR_ptr)(instance, pCreateInfo, ptr, pSurface);
		}
	}

	public unsafe static VkResult vkCreateMirSurfaceKHR(VkInstance instance, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateMirSurfaceKHR_ptr)(instance, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateMirSurfaceKHR(VkInstance instance, IntPtr pCreateInfo, IntPtr pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateMirSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateMirSurfaceKHR(VkInstance instance, IntPtr pCreateInfo, IntPtr pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateMirSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateObjectTableNVX(VkDevice device, VkObjectTableCreateInfoNVX* pCreateInfo, VkAllocationCallbacks* pAllocator, VkObjectTableNVX* pObjectTable)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkObjectTableCreateInfoNVX*, VkAllocationCallbacks*, VkObjectTableNVX*, VkResult>)vkCreateObjectTableNVX_ptr)(device, pCreateInfo, pAllocator, pObjectTable);
	}

	public unsafe static VkResult vkCreateObjectTableNVX(VkDevice device, VkObjectTableCreateInfoNVX* pCreateInfo, VkAllocationCallbacks* pAllocator, out VkObjectTableNVX pObjectTable)
	{
		fixed (VkObjectTableNVX* ptr = &pObjectTable)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkObjectTableCreateInfoNVX*, VkAllocationCallbacks*, VkObjectTableNVX*, VkResult>)vkCreateObjectTableNVX_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateObjectTableNVX(VkDevice device, VkObjectTableCreateInfoNVX* pCreateInfo, ref VkAllocationCallbacks pAllocator, VkObjectTableNVX* pObjectTable)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkObjectTableCreateInfoNVX*, VkAllocationCallbacks*, VkObjectTableNVX*, VkResult>)vkCreateObjectTableNVX_ptr)(device, pCreateInfo, ptr, pObjectTable);
		}
	}

	public unsafe static VkResult vkCreateObjectTableNVX(VkDevice device, VkObjectTableCreateInfoNVX* pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkObjectTableNVX pObjectTable)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkObjectTableNVX* ptr2 = &pObjectTable)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkObjectTableCreateInfoNVX*, VkAllocationCallbacks*, VkObjectTableNVX*, VkResult>)vkCreateObjectTableNVX_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateObjectTableNVX(VkDevice device, VkObjectTableCreateInfoNVX* pCreateInfo, IntPtr pAllocator, VkObjectTableNVX* pObjectTable)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkObjectTableCreateInfoNVX*, IntPtr, VkObjectTableNVX*, VkResult>)vkCreateObjectTableNVX_ptr)(device, pCreateInfo, pAllocator, pObjectTable);
	}

	public unsafe static VkResult vkCreateObjectTableNVX(VkDevice device, VkObjectTableCreateInfoNVX* pCreateInfo, IntPtr pAllocator, out VkObjectTableNVX pObjectTable)
	{
		fixed (VkObjectTableNVX* ptr = &pObjectTable)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkObjectTableCreateInfoNVX*, IntPtr, VkObjectTableNVX*, VkResult>)vkCreateObjectTableNVX_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateObjectTableNVX(VkDevice device, ref VkObjectTableCreateInfoNVX pCreateInfo, VkAllocationCallbacks* pAllocator, VkObjectTableNVX* pObjectTable)
	{
		fixed (VkObjectTableCreateInfoNVX* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkObjectTableCreateInfoNVX*, VkAllocationCallbacks*, VkObjectTableNVX*, VkResult>)vkCreateObjectTableNVX_ptr)(device, ptr, pAllocator, pObjectTable);
		}
	}

	public unsafe static VkResult vkCreateObjectTableNVX(VkDevice device, ref VkObjectTableCreateInfoNVX pCreateInfo, VkAllocationCallbacks* pAllocator, out VkObjectTableNVX pObjectTable)
	{
		fixed (VkObjectTableCreateInfoNVX* ptr = &pCreateInfo)
		{
			fixed (VkObjectTableNVX* ptr2 = &pObjectTable)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkObjectTableCreateInfoNVX*, VkAllocationCallbacks*, VkObjectTableNVX*, VkResult>)vkCreateObjectTableNVX_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateObjectTableNVX(VkDevice device, ref VkObjectTableCreateInfoNVX pCreateInfo, ref VkAllocationCallbacks pAllocator, VkObjectTableNVX* pObjectTable)
	{
		fixed (VkObjectTableCreateInfoNVX* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkObjectTableCreateInfoNVX*, VkAllocationCallbacks*, VkObjectTableNVX*, VkResult>)vkCreateObjectTableNVX_ptr)(device, ptr, ptr2, pObjectTable);
			}
		}
	}

	public unsafe static VkResult vkCreateObjectTableNVX(VkDevice device, ref VkObjectTableCreateInfoNVX pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkObjectTableNVX pObjectTable)
	{
		fixed (VkObjectTableCreateInfoNVX* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkObjectTableNVX* ptr3 = &pObjectTable)
				{
					return ((delegate* unmanaged[Stdcall]<VkDevice, VkObjectTableCreateInfoNVX*, VkAllocationCallbacks*, VkObjectTableNVX*, VkResult>)vkCreateObjectTableNVX_ptr)(device, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreateObjectTableNVX(VkDevice device, ref VkObjectTableCreateInfoNVX pCreateInfo, IntPtr pAllocator, VkObjectTableNVX* pObjectTable)
	{
		fixed (VkObjectTableCreateInfoNVX* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkObjectTableCreateInfoNVX*, IntPtr, VkObjectTableNVX*, VkResult>)vkCreateObjectTableNVX_ptr)(device, ptr, pAllocator, pObjectTable);
		}
	}

	public unsafe static VkResult vkCreateObjectTableNVX(VkDevice device, ref VkObjectTableCreateInfoNVX pCreateInfo, IntPtr pAllocator, out VkObjectTableNVX pObjectTable)
	{
		fixed (VkObjectTableCreateInfoNVX* ptr = &pCreateInfo)
		{
			fixed (VkObjectTableNVX* ptr2 = &pObjectTable)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkObjectTableCreateInfoNVX*, IntPtr, VkObjectTableNVX*, VkResult>)vkCreateObjectTableNVX_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateObjectTableNVX(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, VkObjectTableNVX* pObjectTable)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkObjectTableNVX*, VkResult>)vkCreateObjectTableNVX_ptr)(device, pCreateInfo, pAllocator, pObjectTable);
	}

	public unsafe static VkResult vkCreateObjectTableNVX(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, out VkObjectTableNVX pObjectTable)
	{
		fixed (VkObjectTableNVX* ptr = &pObjectTable)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkObjectTableNVX*, VkResult>)vkCreateObjectTableNVX_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateObjectTableNVX(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, VkObjectTableNVX* pObjectTable)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkObjectTableNVX*, VkResult>)vkCreateObjectTableNVX_ptr)(device, pCreateInfo, ptr, pObjectTable);
		}
	}

	public unsafe static VkResult vkCreateObjectTableNVX(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkObjectTableNVX pObjectTable)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkObjectTableNVX* ptr2 = &pObjectTable)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkObjectTableNVX*, VkResult>)vkCreateObjectTableNVX_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateObjectTableNVX(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, VkObjectTableNVX* pObjectTable)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkObjectTableNVX*, VkResult>)vkCreateObjectTableNVX_ptr)(device, pCreateInfo, pAllocator, pObjectTable);
	}

	public unsafe static VkResult vkCreateObjectTableNVX(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, out VkObjectTableNVX pObjectTable)
	{
		fixed (VkObjectTableNVX* ptr = &pObjectTable)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkObjectTableNVX*, VkResult>)vkCreateObjectTableNVX_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreatePipelineCache(VkDevice device, VkPipelineCacheCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkPipelineCache* pPipelineCache)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCacheCreateInfo*, VkAllocationCallbacks*, VkPipelineCache*, VkResult>)vkCreatePipelineCache_ptr)(device, pCreateInfo, pAllocator, pPipelineCache);
	}

	public unsafe static VkResult vkCreatePipelineCache(VkDevice device, VkPipelineCacheCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, out VkPipelineCache pPipelineCache)
	{
		fixed (VkPipelineCache* ptr = &pPipelineCache)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCacheCreateInfo*, VkAllocationCallbacks*, VkPipelineCache*, VkResult>)vkCreatePipelineCache_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreatePipelineCache(VkDevice device, VkPipelineCacheCreateInfo* pCreateInfo, ref VkAllocationCallbacks pAllocator, VkPipelineCache* pPipelineCache)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCacheCreateInfo*, VkAllocationCallbacks*, VkPipelineCache*, VkResult>)vkCreatePipelineCache_ptr)(device, pCreateInfo, ptr, pPipelineCache);
		}
	}

	public unsafe static VkResult vkCreatePipelineCache(VkDevice device, VkPipelineCacheCreateInfo* pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkPipelineCache pPipelineCache)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkPipelineCache* ptr2 = &pPipelineCache)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCacheCreateInfo*, VkAllocationCallbacks*, VkPipelineCache*, VkResult>)vkCreatePipelineCache_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreatePipelineCache(VkDevice device, VkPipelineCacheCreateInfo* pCreateInfo, IntPtr pAllocator, VkPipelineCache* pPipelineCache)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCacheCreateInfo*, IntPtr, VkPipelineCache*, VkResult>)vkCreatePipelineCache_ptr)(device, pCreateInfo, pAllocator, pPipelineCache);
	}

	public unsafe static VkResult vkCreatePipelineCache(VkDevice device, VkPipelineCacheCreateInfo* pCreateInfo, IntPtr pAllocator, out VkPipelineCache pPipelineCache)
	{
		fixed (VkPipelineCache* ptr = &pPipelineCache)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCacheCreateInfo*, IntPtr, VkPipelineCache*, VkResult>)vkCreatePipelineCache_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreatePipelineCache(VkDevice device, ref VkPipelineCacheCreateInfo pCreateInfo, VkAllocationCallbacks* pAllocator, VkPipelineCache* pPipelineCache)
	{
		fixed (VkPipelineCacheCreateInfo* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCacheCreateInfo*, VkAllocationCallbacks*, VkPipelineCache*, VkResult>)vkCreatePipelineCache_ptr)(device, ptr, pAllocator, pPipelineCache);
		}
	}

	public unsafe static VkResult vkCreatePipelineCache(VkDevice device, ref VkPipelineCacheCreateInfo pCreateInfo, VkAllocationCallbacks* pAllocator, out VkPipelineCache pPipelineCache)
	{
		fixed (VkPipelineCacheCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkPipelineCache* ptr2 = &pPipelineCache)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCacheCreateInfo*, VkAllocationCallbacks*, VkPipelineCache*, VkResult>)vkCreatePipelineCache_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreatePipelineCache(VkDevice device, ref VkPipelineCacheCreateInfo pCreateInfo, ref VkAllocationCallbacks pAllocator, VkPipelineCache* pPipelineCache)
	{
		fixed (VkPipelineCacheCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCacheCreateInfo*, VkAllocationCallbacks*, VkPipelineCache*, VkResult>)vkCreatePipelineCache_ptr)(device, ptr, ptr2, pPipelineCache);
			}
		}
	}

	public unsafe static VkResult vkCreatePipelineCache(VkDevice device, ref VkPipelineCacheCreateInfo pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkPipelineCache pPipelineCache)
	{
		fixed (VkPipelineCacheCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkPipelineCache* ptr3 = &pPipelineCache)
				{
					return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCacheCreateInfo*, VkAllocationCallbacks*, VkPipelineCache*, VkResult>)vkCreatePipelineCache_ptr)(device, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreatePipelineCache(VkDevice device, ref VkPipelineCacheCreateInfo pCreateInfo, IntPtr pAllocator, VkPipelineCache* pPipelineCache)
	{
		fixed (VkPipelineCacheCreateInfo* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCacheCreateInfo*, IntPtr, VkPipelineCache*, VkResult>)vkCreatePipelineCache_ptr)(device, ptr, pAllocator, pPipelineCache);
		}
	}

	public unsafe static VkResult vkCreatePipelineCache(VkDevice device, ref VkPipelineCacheCreateInfo pCreateInfo, IntPtr pAllocator, out VkPipelineCache pPipelineCache)
	{
		fixed (VkPipelineCacheCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkPipelineCache* ptr2 = &pPipelineCache)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCacheCreateInfo*, IntPtr, VkPipelineCache*, VkResult>)vkCreatePipelineCache_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreatePipelineCache(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, VkPipelineCache* pPipelineCache)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkPipelineCache*, VkResult>)vkCreatePipelineCache_ptr)(device, pCreateInfo, pAllocator, pPipelineCache);
	}

	public unsafe static VkResult vkCreatePipelineCache(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, out VkPipelineCache pPipelineCache)
	{
		fixed (VkPipelineCache* ptr = &pPipelineCache)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkPipelineCache*, VkResult>)vkCreatePipelineCache_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreatePipelineCache(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, VkPipelineCache* pPipelineCache)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkPipelineCache*, VkResult>)vkCreatePipelineCache_ptr)(device, pCreateInfo, ptr, pPipelineCache);
		}
	}

	public unsafe static VkResult vkCreatePipelineCache(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkPipelineCache pPipelineCache)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkPipelineCache* ptr2 = &pPipelineCache)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkPipelineCache*, VkResult>)vkCreatePipelineCache_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreatePipelineCache(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, VkPipelineCache* pPipelineCache)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkPipelineCache*, VkResult>)vkCreatePipelineCache_ptr)(device, pCreateInfo, pAllocator, pPipelineCache);
	}

	public unsafe static VkResult vkCreatePipelineCache(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, out VkPipelineCache pPipelineCache)
	{
		fixed (VkPipelineCache* ptr = &pPipelineCache)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkPipelineCache*, VkResult>)vkCreatePipelineCache_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreatePipelineLayout(VkDevice device, VkPipelineLayoutCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkPipelineLayout* pPipelineLayout)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineLayoutCreateInfo*, VkAllocationCallbacks*, VkPipelineLayout*, VkResult>)vkCreatePipelineLayout_ptr)(device, pCreateInfo, pAllocator, pPipelineLayout);
	}

	public unsafe static VkResult vkCreatePipelineLayout(VkDevice device, VkPipelineLayoutCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, out VkPipelineLayout pPipelineLayout)
	{
		fixed (VkPipelineLayout* ptr = &pPipelineLayout)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineLayoutCreateInfo*, VkAllocationCallbacks*, VkPipelineLayout*, VkResult>)vkCreatePipelineLayout_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreatePipelineLayout(VkDevice device, VkPipelineLayoutCreateInfo* pCreateInfo, ref VkAllocationCallbacks pAllocator, VkPipelineLayout* pPipelineLayout)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineLayoutCreateInfo*, VkAllocationCallbacks*, VkPipelineLayout*, VkResult>)vkCreatePipelineLayout_ptr)(device, pCreateInfo, ptr, pPipelineLayout);
		}
	}

	public unsafe static VkResult vkCreatePipelineLayout(VkDevice device, VkPipelineLayoutCreateInfo* pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkPipelineLayout pPipelineLayout)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkPipelineLayout* ptr2 = &pPipelineLayout)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineLayoutCreateInfo*, VkAllocationCallbacks*, VkPipelineLayout*, VkResult>)vkCreatePipelineLayout_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreatePipelineLayout(VkDevice device, VkPipelineLayoutCreateInfo* pCreateInfo, IntPtr pAllocator, VkPipelineLayout* pPipelineLayout)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineLayoutCreateInfo*, IntPtr, VkPipelineLayout*, VkResult>)vkCreatePipelineLayout_ptr)(device, pCreateInfo, pAllocator, pPipelineLayout);
	}

	public unsafe static VkResult vkCreatePipelineLayout(VkDevice device, VkPipelineLayoutCreateInfo* pCreateInfo, IntPtr pAllocator, out VkPipelineLayout pPipelineLayout)
	{
		fixed (VkPipelineLayout* ptr = &pPipelineLayout)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineLayoutCreateInfo*, IntPtr, VkPipelineLayout*, VkResult>)vkCreatePipelineLayout_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreatePipelineLayout(VkDevice device, ref VkPipelineLayoutCreateInfo pCreateInfo, VkAllocationCallbacks* pAllocator, VkPipelineLayout* pPipelineLayout)
	{
		fixed (VkPipelineLayoutCreateInfo* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineLayoutCreateInfo*, VkAllocationCallbacks*, VkPipelineLayout*, VkResult>)vkCreatePipelineLayout_ptr)(device, ptr, pAllocator, pPipelineLayout);
		}
	}

	public unsafe static VkResult vkCreatePipelineLayout(VkDevice device, ref VkPipelineLayoutCreateInfo pCreateInfo, VkAllocationCallbacks* pAllocator, out VkPipelineLayout pPipelineLayout)
	{
		fixed (VkPipelineLayoutCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkPipelineLayout* ptr2 = &pPipelineLayout)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineLayoutCreateInfo*, VkAllocationCallbacks*, VkPipelineLayout*, VkResult>)vkCreatePipelineLayout_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreatePipelineLayout(VkDevice device, ref VkPipelineLayoutCreateInfo pCreateInfo, ref VkAllocationCallbacks pAllocator, VkPipelineLayout* pPipelineLayout)
	{
		fixed (VkPipelineLayoutCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineLayoutCreateInfo*, VkAllocationCallbacks*, VkPipelineLayout*, VkResult>)vkCreatePipelineLayout_ptr)(device, ptr, ptr2, pPipelineLayout);
			}
		}
	}

	public unsafe static VkResult vkCreatePipelineLayout(VkDevice device, ref VkPipelineLayoutCreateInfo pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkPipelineLayout pPipelineLayout)
	{
		fixed (VkPipelineLayoutCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkPipelineLayout* ptr3 = &pPipelineLayout)
				{
					return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineLayoutCreateInfo*, VkAllocationCallbacks*, VkPipelineLayout*, VkResult>)vkCreatePipelineLayout_ptr)(device, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreatePipelineLayout(VkDevice device, ref VkPipelineLayoutCreateInfo pCreateInfo, IntPtr pAllocator, VkPipelineLayout* pPipelineLayout)
	{
		fixed (VkPipelineLayoutCreateInfo* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineLayoutCreateInfo*, IntPtr, VkPipelineLayout*, VkResult>)vkCreatePipelineLayout_ptr)(device, ptr, pAllocator, pPipelineLayout);
		}
	}

	public unsafe static VkResult vkCreatePipelineLayout(VkDevice device, ref VkPipelineLayoutCreateInfo pCreateInfo, IntPtr pAllocator, out VkPipelineLayout pPipelineLayout)
	{
		fixed (VkPipelineLayoutCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkPipelineLayout* ptr2 = &pPipelineLayout)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineLayoutCreateInfo*, IntPtr, VkPipelineLayout*, VkResult>)vkCreatePipelineLayout_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreatePipelineLayout(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, VkPipelineLayout* pPipelineLayout)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkPipelineLayout*, VkResult>)vkCreatePipelineLayout_ptr)(device, pCreateInfo, pAllocator, pPipelineLayout);
	}

	public unsafe static VkResult vkCreatePipelineLayout(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, out VkPipelineLayout pPipelineLayout)
	{
		fixed (VkPipelineLayout* ptr = &pPipelineLayout)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkPipelineLayout*, VkResult>)vkCreatePipelineLayout_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreatePipelineLayout(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, VkPipelineLayout* pPipelineLayout)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkPipelineLayout*, VkResult>)vkCreatePipelineLayout_ptr)(device, pCreateInfo, ptr, pPipelineLayout);
		}
	}

	public unsafe static VkResult vkCreatePipelineLayout(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkPipelineLayout pPipelineLayout)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkPipelineLayout* ptr2 = &pPipelineLayout)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkPipelineLayout*, VkResult>)vkCreatePipelineLayout_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreatePipelineLayout(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, VkPipelineLayout* pPipelineLayout)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkPipelineLayout*, VkResult>)vkCreatePipelineLayout_ptr)(device, pCreateInfo, pAllocator, pPipelineLayout);
	}

	public unsafe static VkResult vkCreatePipelineLayout(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, out VkPipelineLayout pPipelineLayout)
	{
		fixed (VkPipelineLayout* ptr = &pPipelineLayout)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkPipelineLayout*, VkResult>)vkCreatePipelineLayout_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateQueryPool(VkDevice device, VkQueryPoolCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkQueryPool* pQueryPool)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkQueryPoolCreateInfo*, VkAllocationCallbacks*, VkQueryPool*, VkResult>)vkCreateQueryPool_ptr)(device, pCreateInfo, pAllocator, pQueryPool);
	}

	public unsafe static VkResult vkCreateQueryPool(VkDevice device, VkQueryPoolCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, out VkQueryPool pQueryPool)
	{
		fixed (VkQueryPool* ptr = &pQueryPool)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkQueryPoolCreateInfo*, VkAllocationCallbacks*, VkQueryPool*, VkResult>)vkCreateQueryPool_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateQueryPool(VkDevice device, VkQueryPoolCreateInfo* pCreateInfo, ref VkAllocationCallbacks pAllocator, VkQueryPool* pQueryPool)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkQueryPoolCreateInfo*, VkAllocationCallbacks*, VkQueryPool*, VkResult>)vkCreateQueryPool_ptr)(device, pCreateInfo, ptr, pQueryPool);
		}
	}

	public unsafe static VkResult vkCreateQueryPool(VkDevice device, VkQueryPoolCreateInfo* pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkQueryPool pQueryPool)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkQueryPool* ptr2 = &pQueryPool)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkQueryPoolCreateInfo*, VkAllocationCallbacks*, VkQueryPool*, VkResult>)vkCreateQueryPool_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateQueryPool(VkDevice device, VkQueryPoolCreateInfo* pCreateInfo, IntPtr pAllocator, VkQueryPool* pQueryPool)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkQueryPoolCreateInfo*, IntPtr, VkQueryPool*, VkResult>)vkCreateQueryPool_ptr)(device, pCreateInfo, pAllocator, pQueryPool);
	}

	public unsafe static VkResult vkCreateQueryPool(VkDevice device, VkQueryPoolCreateInfo* pCreateInfo, IntPtr pAllocator, out VkQueryPool pQueryPool)
	{
		fixed (VkQueryPool* ptr = &pQueryPool)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkQueryPoolCreateInfo*, IntPtr, VkQueryPool*, VkResult>)vkCreateQueryPool_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateQueryPool(VkDevice device, ref VkQueryPoolCreateInfo pCreateInfo, VkAllocationCallbacks* pAllocator, VkQueryPool* pQueryPool)
	{
		fixed (VkQueryPoolCreateInfo* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkQueryPoolCreateInfo*, VkAllocationCallbacks*, VkQueryPool*, VkResult>)vkCreateQueryPool_ptr)(device, ptr, pAllocator, pQueryPool);
		}
	}

	public unsafe static VkResult vkCreateQueryPool(VkDevice device, ref VkQueryPoolCreateInfo pCreateInfo, VkAllocationCallbacks* pAllocator, out VkQueryPool pQueryPool)
	{
		fixed (VkQueryPoolCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkQueryPool* ptr2 = &pQueryPool)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkQueryPoolCreateInfo*, VkAllocationCallbacks*, VkQueryPool*, VkResult>)vkCreateQueryPool_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateQueryPool(VkDevice device, ref VkQueryPoolCreateInfo pCreateInfo, ref VkAllocationCallbacks pAllocator, VkQueryPool* pQueryPool)
	{
		fixed (VkQueryPoolCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkQueryPoolCreateInfo*, VkAllocationCallbacks*, VkQueryPool*, VkResult>)vkCreateQueryPool_ptr)(device, ptr, ptr2, pQueryPool);
			}
		}
	}

	public unsafe static VkResult vkCreateQueryPool(VkDevice device, ref VkQueryPoolCreateInfo pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkQueryPool pQueryPool)
	{
		fixed (VkQueryPoolCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkQueryPool* ptr3 = &pQueryPool)
				{
					return ((delegate* unmanaged[Stdcall]<VkDevice, VkQueryPoolCreateInfo*, VkAllocationCallbacks*, VkQueryPool*, VkResult>)vkCreateQueryPool_ptr)(device, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreateQueryPool(VkDevice device, ref VkQueryPoolCreateInfo pCreateInfo, IntPtr pAllocator, VkQueryPool* pQueryPool)
	{
		fixed (VkQueryPoolCreateInfo* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkQueryPoolCreateInfo*, IntPtr, VkQueryPool*, VkResult>)vkCreateQueryPool_ptr)(device, ptr, pAllocator, pQueryPool);
		}
	}

	public unsafe static VkResult vkCreateQueryPool(VkDevice device, ref VkQueryPoolCreateInfo pCreateInfo, IntPtr pAllocator, out VkQueryPool pQueryPool)
	{
		fixed (VkQueryPoolCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkQueryPool* ptr2 = &pQueryPool)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkQueryPoolCreateInfo*, IntPtr, VkQueryPool*, VkResult>)vkCreateQueryPool_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateQueryPool(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, VkQueryPool* pQueryPool)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkQueryPool*, VkResult>)vkCreateQueryPool_ptr)(device, pCreateInfo, pAllocator, pQueryPool);
	}

	public unsafe static VkResult vkCreateQueryPool(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, out VkQueryPool pQueryPool)
	{
		fixed (VkQueryPool* ptr = &pQueryPool)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkQueryPool*, VkResult>)vkCreateQueryPool_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateQueryPool(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, VkQueryPool* pQueryPool)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkQueryPool*, VkResult>)vkCreateQueryPool_ptr)(device, pCreateInfo, ptr, pQueryPool);
		}
	}

	public unsafe static VkResult vkCreateQueryPool(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkQueryPool pQueryPool)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkQueryPool* ptr2 = &pQueryPool)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkQueryPool*, VkResult>)vkCreateQueryPool_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateQueryPool(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, VkQueryPool* pQueryPool)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkQueryPool*, VkResult>)vkCreateQueryPool_ptr)(device, pCreateInfo, pAllocator, pQueryPool);
	}

	public unsafe static VkResult vkCreateQueryPool(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, out VkQueryPool pQueryPool)
	{
		fixed (VkQueryPool* ptr = &pQueryPool)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkQueryPool*, VkResult>)vkCreateQueryPool_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateRenderPass(VkDevice device, VkRenderPassCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkRenderPass* pRenderPass)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkRenderPassCreateInfo*, VkAllocationCallbacks*, VkRenderPass*, VkResult>)vkCreateRenderPass_ptr)(device, pCreateInfo, pAllocator, pRenderPass);
	}

	public unsafe static VkResult vkCreateRenderPass(VkDevice device, VkRenderPassCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, out VkRenderPass pRenderPass)
	{
		fixed (VkRenderPass* ptr = &pRenderPass)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkRenderPassCreateInfo*, VkAllocationCallbacks*, VkRenderPass*, VkResult>)vkCreateRenderPass_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateRenderPass(VkDevice device, VkRenderPassCreateInfo* pCreateInfo, ref VkAllocationCallbacks pAllocator, VkRenderPass* pRenderPass)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkRenderPassCreateInfo*, VkAllocationCallbacks*, VkRenderPass*, VkResult>)vkCreateRenderPass_ptr)(device, pCreateInfo, ptr, pRenderPass);
		}
	}

	public unsafe static VkResult vkCreateRenderPass(VkDevice device, VkRenderPassCreateInfo* pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkRenderPass pRenderPass)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkRenderPass* ptr2 = &pRenderPass)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkRenderPassCreateInfo*, VkAllocationCallbacks*, VkRenderPass*, VkResult>)vkCreateRenderPass_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateRenderPass(VkDevice device, VkRenderPassCreateInfo* pCreateInfo, IntPtr pAllocator, VkRenderPass* pRenderPass)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkRenderPassCreateInfo*, IntPtr, VkRenderPass*, VkResult>)vkCreateRenderPass_ptr)(device, pCreateInfo, pAllocator, pRenderPass);
	}

	public unsafe static VkResult vkCreateRenderPass(VkDevice device, VkRenderPassCreateInfo* pCreateInfo, IntPtr pAllocator, out VkRenderPass pRenderPass)
	{
		fixed (VkRenderPass* ptr = &pRenderPass)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkRenderPassCreateInfo*, IntPtr, VkRenderPass*, VkResult>)vkCreateRenderPass_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateRenderPass(VkDevice device, ref VkRenderPassCreateInfo pCreateInfo, VkAllocationCallbacks* pAllocator, VkRenderPass* pRenderPass)
	{
		fixed (VkRenderPassCreateInfo* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkRenderPassCreateInfo*, VkAllocationCallbacks*, VkRenderPass*, VkResult>)vkCreateRenderPass_ptr)(device, ptr, pAllocator, pRenderPass);
		}
	}

	public unsafe static VkResult vkCreateRenderPass(VkDevice device, ref VkRenderPassCreateInfo pCreateInfo, VkAllocationCallbacks* pAllocator, out VkRenderPass pRenderPass)
	{
		fixed (VkRenderPassCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkRenderPass* ptr2 = &pRenderPass)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkRenderPassCreateInfo*, VkAllocationCallbacks*, VkRenderPass*, VkResult>)vkCreateRenderPass_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateRenderPass(VkDevice device, ref VkRenderPassCreateInfo pCreateInfo, ref VkAllocationCallbacks pAllocator, VkRenderPass* pRenderPass)
	{
		fixed (VkRenderPassCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkRenderPassCreateInfo*, VkAllocationCallbacks*, VkRenderPass*, VkResult>)vkCreateRenderPass_ptr)(device, ptr, ptr2, pRenderPass);
			}
		}
	}

	public unsafe static VkResult vkCreateRenderPass(VkDevice device, ref VkRenderPassCreateInfo pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkRenderPass pRenderPass)
	{
		fixed (VkRenderPassCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkRenderPass* ptr3 = &pRenderPass)
				{
					return ((delegate* unmanaged[Stdcall]<VkDevice, VkRenderPassCreateInfo*, VkAllocationCallbacks*, VkRenderPass*, VkResult>)vkCreateRenderPass_ptr)(device, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreateRenderPass(VkDevice device, ref VkRenderPassCreateInfo pCreateInfo, IntPtr pAllocator, VkRenderPass* pRenderPass)
	{
		fixed (VkRenderPassCreateInfo* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkRenderPassCreateInfo*, IntPtr, VkRenderPass*, VkResult>)vkCreateRenderPass_ptr)(device, ptr, pAllocator, pRenderPass);
		}
	}

	public unsafe static VkResult vkCreateRenderPass(VkDevice device, ref VkRenderPassCreateInfo pCreateInfo, IntPtr pAllocator, out VkRenderPass pRenderPass)
	{
		fixed (VkRenderPassCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkRenderPass* ptr2 = &pRenderPass)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkRenderPassCreateInfo*, IntPtr, VkRenderPass*, VkResult>)vkCreateRenderPass_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateRenderPass(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, VkRenderPass* pRenderPass)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkRenderPass*, VkResult>)vkCreateRenderPass_ptr)(device, pCreateInfo, pAllocator, pRenderPass);
	}

	public unsafe static VkResult vkCreateRenderPass(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, out VkRenderPass pRenderPass)
	{
		fixed (VkRenderPass* ptr = &pRenderPass)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkRenderPass*, VkResult>)vkCreateRenderPass_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateRenderPass(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, VkRenderPass* pRenderPass)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkRenderPass*, VkResult>)vkCreateRenderPass_ptr)(device, pCreateInfo, ptr, pRenderPass);
		}
	}

	public unsafe static VkResult vkCreateRenderPass(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkRenderPass pRenderPass)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkRenderPass* ptr2 = &pRenderPass)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkRenderPass*, VkResult>)vkCreateRenderPass_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateRenderPass(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, VkRenderPass* pRenderPass)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkRenderPass*, VkResult>)vkCreateRenderPass_ptr)(device, pCreateInfo, pAllocator, pRenderPass);
	}

	public unsafe static VkResult vkCreateRenderPass(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, out VkRenderPass pRenderPass)
	{
		fixed (VkRenderPass* ptr = &pRenderPass)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkRenderPass*, VkResult>)vkCreateRenderPass_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateSampler(VkDevice device, VkSamplerCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkSampler* pSampler)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkSamplerCreateInfo*, VkAllocationCallbacks*, VkSampler*, VkResult>)vkCreateSampler_ptr)(device, pCreateInfo, pAllocator, pSampler);
	}

	public unsafe static VkResult vkCreateSampler(VkDevice device, VkSamplerCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSampler pSampler)
	{
		fixed (VkSampler* ptr = &pSampler)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkSamplerCreateInfo*, VkAllocationCallbacks*, VkSampler*, VkResult>)vkCreateSampler_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateSampler(VkDevice device, VkSamplerCreateInfo* pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSampler* pSampler)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkSamplerCreateInfo*, VkAllocationCallbacks*, VkSampler*, VkResult>)vkCreateSampler_ptr)(device, pCreateInfo, ptr, pSampler);
		}
	}

	public unsafe static VkResult vkCreateSampler(VkDevice device, VkSamplerCreateInfo* pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSampler pSampler)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkSampler* ptr2 = &pSampler)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkSamplerCreateInfo*, VkAllocationCallbacks*, VkSampler*, VkResult>)vkCreateSampler_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateSampler(VkDevice device, VkSamplerCreateInfo* pCreateInfo, IntPtr pAllocator, VkSampler* pSampler)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkSamplerCreateInfo*, IntPtr, VkSampler*, VkResult>)vkCreateSampler_ptr)(device, pCreateInfo, pAllocator, pSampler);
	}

	public unsafe static VkResult vkCreateSampler(VkDevice device, VkSamplerCreateInfo* pCreateInfo, IntPtr pAllocator, out VkSampler pSampler)
	{
		fixed (VkSampler* ptr = &pSampler)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkSamplerCreateInfo*, IntPtr, VkSampler*, VkResult>)vkCreateSampler_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateSampler(VkDevice device, ref VkSamplerCreateInfo pCreateInfo, VkAllocationCallbacks* pAllocator, VkSampler* pSampler)
	{
		fixed (VkSamplerCreateInfo* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkSamplerCreateInfo*, VkAllocationCallbacks*, VkSampler*, VkResult>)vkCreateSampler_ptr)(device, ptr, pAllocator, pSampler);
		}
	}

	public unsafe static VkResult vkCreateSampler(VkDevice device, ref VkSamplerCreateInfo pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSampler pSampler)
	{
		fixed (VkSamplerCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkSampler* ptr2 = &pSampler)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkSamplerCreateInfo*, VkAllocationCallbacks*, VkSampler*, VkResult>)vkCreateSampler_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateSampler(VkDevice device, ref VkSamplerCreateInfo pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSampler* pSampler)
	{
		fixed (VkSamplerCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkSamplerCreateInfo*, VkAllocationCallbacks*, VkSampler*, VkResult>)vkCreateSampler_ptr)(device, ptr, ptr2, pSampler);
			}
		}
	}

	public unsafe static VkResult vkCreateSampler(VkDevice device, ref VkSamplerCreateInfo pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSampler pSampler)
	{
		fixed (VkSamplerCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkSampler* ptr3 = &pSampler)
				{
					return ((delegate* unmanaged[Stdcall]<VkDevice, VkSamplerCreateInfo*, VkAllocationCallbacks*, VkSampler*, VkResult>)vkCreateSampler_ptr)(device, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreateSampler(VkDevice device, ref VkSamplerCreateInfo pCreateInfo, IntPtr pAllocator, VkSampler* pSampler)
	{
		fixed (VkSamplerCreateInfo* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkSamplerCreateInfo*, IntPtr, VkSampler*, VkResult>)vkCreateSampler_ptr)(device, ptr, pAllocator, pSampler);
		}
	}

	public unsafe static VkResult vkCreateSampler(VkDevice device, ref VkSamplerCreateInfo pCreateInfo, IntPtr pAllocator, out VkSampler pSampler)
	{
		fixed (VkSamplerCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkSampler* ptr2 = &pSampler)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkSamplerCreateInfo*, IntPtr, VkSampler*, VkResult>)vkCreateSampler_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateSampler(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, VkSampler* pSampler)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkSampler*, VkResult>)vkCreateSampler_ptr)(device, pCreateInfo, pAllocator, pSampler);
	}

	public unsafe static VkResult vkCreateSampler(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSampler pSampler)
	{
		fixed (VkSampler* ptr = &pSampler)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkSampler*, VkResult>)vkCreateSampler_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateSampler(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSampler* pSampler)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkSampler*, VkResult>)vkCreateSampler_ptr)(device, pCreateInfo, ptr, pSampler);
		}
	}

	public unsafe static VkResult vkCreateSampler(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSampler pSampler)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkSampler* ptr2 = &pSampler)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkSampler*, VkResult>)vkCreateSampler_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateSampler(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, VkSampler* pSampler)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkSampler*, VkResult>)vkCreateSampler_ptr)(device, pCreateInfo, pAllocator, pSampler);
	}

	public unsafe static VkResult vkCreateSampler(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, out VkSampler pSampler)
	{
		fixed (VkSampler* ptr = &pSampler)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkSampler*, VkResult>)vkCreateSampler_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateSamplerYcbcrConversionKHR(VkDevice device, VkSamplerYcbcrConversionCreateInfoKHR* pCreateInfo, VkAllocationCallbacks* pAllocator, VkSamplerYcbcrConversionKHR* pYcbcrConversion)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkSamplerYcbcrConversionCreateInfoKHR*, VkAllocationCallbacks*, VkSamplerYcbcrConversionKHR*, VkResult>)vkCreateSamplerYcbcrConversionKHR_ptr)(device, pCreateInfo, pAllocator, pYcbcrConversion);
	}

	public unsafe static VkResult vkCreateSamplerYcbcrConversionKHR(VkDevice device, VkSamplerYcbcrConversionCreateInfoKHR* pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSamplerYcbcrConversionKHR pYcbcrConversion)
	{
		fixed (VkSamplerYcbcrConversionKHR* ptr = &pYcbcrConversion)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkSamplerYcbcrConversionCreateInfoKHR*, VkAllocationCallbacks*, VkSamplerYcbcrConversionKHR*, VkResult>)vkCreateSamplerYcbcrConversionKHR_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateSamplerYcbcrConversionKHR(VkDevice device, VkSamplerYcbcrConversionCreateInfoKHR* pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSamplerYcbcrConversionKHR* pYcbcrConversion)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkSamplerYcbcrConversionCreateInfoKHR*, VkAllocationCallbacks*, VkSamplerYcbcrConversionKHR*, VkResult>)vkCreateSamplerYcbcrConversionKHR_ptr)(device, pCreateInfo, ptr, pYcbcrConversion);
		}
	}

	public unsafe static VkResult vkCreateSamplerYcbcrConversionKHR(VkDevice device, VkSamplerYcbcrConversionCreateInfoKHR* pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSamplerYcbcrConversionKHR pYcbcrConversion)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkSamplerYcbcrConversionKHR* ptr2 = &pYcbcrConversion)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkSamplerYcbcrConversionCreateInfoKHR*, VkAllocationCallbacks*, VkSamplerYcbcrConversionKHR*, VkResult>)vkCreateSamplerYcbcrConversionKHR_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateSamplerYcbcrConversionKHR(VkDevice device, VkSamplerYcbcrConversionCreateInfoKHR* pCreateInfo, IntPtr pAllocator, VkSamplerYcbcrConversionKHR* pYcbcrConversion)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkSamplerYcbcrConversionCreateInfoKHR*, IntPtr, VkSamplerYcbcrConversionKHR*, VkResult>)vkCreateSamplerYcbcrConversionKHR_ptr)(device, pCreateInfo, pAllocator, pYcbcrConversion);
	}

	public unsafe static VkResult vkCreateSamplerYcbcrConversionKHR(VkDevice device, VkSamplerYcbcrConversionCreateInfoKHR* pCreateInfo, IntPtr pAllocator, out VkSamplerYcbcrConversionKHR pYcbcrConversion)
	{
		fixed (VkSamplerYcbcrConversionKHR* ptr = &pYcbcrConversion)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkSamplerYcbcrConversionCreateInfoKHR*, IntPtr, VkSamplerYcbcrConversionKHR*, VkResult>)vkCreateSamplerYcbcrConversionKHR_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateSamplerYcbcrConversionKHR(VkDevice device, ref VkSamplerYcbcrConversionCreateInfoKHR pCreateInfo, VkAllocationCallbacks* pAllocator, VkSamplerYcbcrConversionKHR* pYcbcrConversion)
	{
		fixed (VkSamplerYcbcrConversionCreateInfoKHR* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkSamplerYcbcrConversionCreateInfoKHR*, VkAllocationCallbacks*, VkSamplerYcbcrConversionKHR*, VkResult>)vkCreateSamplerYcbcrConversionKHR_ptr)(device, ptr, pAllocator, pYcbcrConversion);
		}
	}

	public unsafe static VkResult vkCreateSamplerYcbcrConversionKHR(VkDevice device, ref VkSamplerYcbcrConversionCreateInfoKHR pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSamplerYcbcrConversionKHR pYcbcrConversion)
	{
		fixed (VkSamplerYcbcrConversionCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkSamplerYcbcrConversionKHR* ptr2 = &pYcbcrConversion)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkSamplerYcbcrConversionCreateInfoKHR*, VkAllocationCallbacks*, VkSamplerYcbcrConversionKHR*, VkResult>)vkCreateSamplerYcbcrConversionKHR_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateSamplerYcbcrConversionKHR(VkDevice device, ref VkSamplerYcbcrConversionCreateInfoKHR pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSamplerYcbcrConversionKHR* pYcbcrConversion)
	{
		fixed (VkSamplerYcbcrConversionCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkSamplerYcbcrConversionCreateInfoKHR*, VkAllocationCallbacks*, VkSamplerYcbcrConversionKHR*, VkResult>)vkCreateSamplerYcbcrConversionKHR_ptr)(device, ptr, ptr2, pYcbcrConversion);
			}
		}
	}

	public unsafe static VkResult vkCreateSamplerYcbcrConversionKHR(VkDevice device, ref VkSamplerYcbcrConversionCreateInfoKHR pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSamplerYcbcrConversionKHR pYcbcrConversion)
	{
		fixed (VkSamplerYcbcrConversionCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkSamplerYcbcrConversionKHR* ptr3 = &pYcbcrConversion)
				{
					return ((delegate* unmanaged[Stdcall]<VkDevice, VkSamplerYcbcrConversionCreateInfoKHR*, VkAllocationCallbacks*, VkSamplerYcbcrConversionKHR*, VkResult>)vkCreateSamplerYcbcrConversionKHR_ptr)(device, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreateSamplerYcbcrConversionKHR(VkDevice device, ref VkSamplerYcbcrConversionCreateInfoKHR pCreateInfo, IntPtr pAllocator, VkSamplerYcbcrConversionKHR* pYcbcrConversion)
	{
		fixed (VkSamplerYcbcrConversionCreateInfoKHR* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkSamplerYcbcrConversionCreateInfoKHR*, IntPtr, VkSamplerYcbcrConversionKHR*, VkResult>)vkCreateSamplerYcbcrConversionKHR_ptr)(device, ptr, pAllocator, pYcbcrConversion);
		}
	}

	public unsafe static VkResult vkCreateSamplerYcbcrConversionKHR(VkDevice device, ref VkSamplerYcbcrConversionCreateInfoKHR pCreateInfo, IntPtr pAllocator, out VkSamplerYcbcrConversionKHR pYcbcrConversion)
	{
		fixed (VkSamplerYcbcrConversionCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkSamplerYcbcrConversionKHR* ptr2 = &pYcbcrConversion)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkSamplerYcbcrConversionCreateInfoKHR*, IntPtr, VkSamplerYcbcrConversionKHR*, VkResult>)vkCreateSamplerYcbcrConversionKHR_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateSamplerYcbcrConversionKHR(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, VkSamplerYcbcrConversionKHR* pYcbcrConversion)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkSamplerYcbcrConversionKHR*, VkResult>)vkCreateSamplerYcbcrConversionKHR_ptr)(device, pCreateInfo, pAllocator, pYcbcrConversion);
	}

	public unsafe static VkResult vkCreateSamplerYcbcrConversionKHR(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSamplerYcbcrConversionKHR pYcbcrConversion)
	{
		fixed (VkSamplerYcbcrConversionKHR* ptr = &pYcbcrConversion)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkSamplerYcbcrConversionKHR*, VkResult>)vkCreateSamplerYcbcrConversionKHR_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateSamplerYcbcrConversionKHR(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSamplerYcbcrConversionKHR* pYcbcrConversion)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkSamplerYcbcrConversionKHR*, VkResult>)vkCreateSamplerYcbcrConversionKHR_ptr)(device, pCreateInfo, ptr, pYcbcrConversion);
		}
	}

	public unsafe static VkResult vkCreateSamplerYcbcrConversionKHR(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSamplerYcbcrConversionKHR pYcbcrConversion)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkSamplerYcbcrConversionKHR* ptr2 = &pYcbcrConversion)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkSamplerYcbcrConversionKHR*, VkResult>)vkCreateSamplerYcbcrConversionKHR_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateSamplerYcbcrConversionKHR(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, VkSamplerYcbcrConversionKHR* pYcbcrConversion)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkSamplerYcbcrConversionKHR*, VkResult>)vkCreateSamplerYcbcrConversionKHR_ptr)(device, pCreateInfo, pAllocator, pYcbcrConversion);
	}

	public unsafe static VkResult vkCreateSamplerYcbcrConversionKHR(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, out VkSamplerYcbcrConversionKHR pYcbcrConversion)
	{
		fixed (VkSamplerYcbcrConversionKHR* ptr = &pYcbcrConversion)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkSamplerYcbcrConversionKHR*, VkResult>)vkCreateSamplerYcbcrConversionKHR_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateSemaphore(VkDevice device, VkSemaphoreCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkSemaphore* pSemaphore)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkSemaphoreCreateInfo*, VkAllocationCallbacks*, VkSemaphore*, VkResult>)vkCreateSemaphore_ptr)(device, pCreateInfo, pAllocator, pSemaphore);
	}

	public unsafe static VkResult vkCreateSemaphore(VkDevice device, VkSemaphoreCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSemaphore pSemaphore)
	{
		fixed (VkSemaphore* ptr = &pSemaphore)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkSemaphoreCreateInfo*, VkAllocationCallbacks*, VkSemaphore*, VkResult>)vkCreateSemaphore_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateSemaphore(VkDevice device, VkSemaphoreCreateInfo* pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSemaphore* pSemaphore)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkSemaphoreCreateInfo*, VkAllocationCallbacks*, VkSemaphore*, VkResult>)vkCreateSemaphore_ptr)(device, pCreateInfo, ptr, pSemaphore);
		}
	}

	public unsafe static VkResult vkCreateSemaphore(VkDevice device, VkSemaphoreCreateInfo* pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSemaphore pSemaphore)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkSemaphore* ptr2 = &pSemaphore)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkSemaphoreCreateInfo*, VkAllocationCallbacks*, VkSemaphore*, VkResult>)vkCreateSemaphore_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateSemaphore(VkDevice device, VkSemaphoreCreateInfo* pCreateInfo, IntPtr pAllocator, VkSemaphore* pSemaphore)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkSemaphoreCreateInfo*, IntPtr, VkSemaphore*, VkResult>)vkCreateSemaphore_ptr)(device, pCreateInfo, pAllocator, pSemaphore);
	}

	public unsafe static VkResult vkCreateSemaphore(VkDevice device, VkSemaphoreCreateInfo* pCreateInfo, IntPtr pAllocator, out VkSemaphore pSemaphore)
	{
		fixed (VkSemaphore* ptr = &pSemaphore)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkSemaphoreCreateInfo*, IntPtr, VkSemaphore*, VkResult>)vkCreateSemaphore_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateSemaphore(VkDevice device, ref VkSemaphoreCreateInfo pCreateInfo, VkAllocationCallbacks* pAllocator, VkSemaphore* pSemaphore)
	{
		fixed (VkSemaphoreCreateInfo* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkSemaphoreCreateInfo*, VkAllocationCallbacks*, VkSemaphore*, VkResult>)vkCreateSemaphore_ptr)(device, ptr, pAllocator, pSemaphore);
		}
	}

	public unsafe static VkResult vkCreateSemaphore(VkDevice device, ref VkSemaphoreCreateInfo pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSemaphore pSemaphore)
	{
		fixed (VkSemaphoreCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkSemaphore* ptr2 = &pSemaphore)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkSemaphoreCreateInfo*, VkAllocationCallbacks*, VkSemaphore*, VkResult>)vkCreateSemaphore_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateSemaphore(VkDevice device, ref VkSemaphoreCreateInfo pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSemaphore* pSemaphore)
	{
		fixed (VkSemaphoreCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkSemaphoreCreateInfo*, VkAllocationCallbacks*, VkSemaphore*, VkResult>)vkCreateSemaphore_ptr)(device, ptr, ptr2, pSemaphore);
			}
		}
	}

	public unsafe static VkResult vkCreateSemaphore(VkDevice device, ref VkSemaphoreCreateInfo pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSemaphore pSemaphore)
	{
		fixed (VkSemaphoreCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkSemaphore* ptr3 = &pSemaphore)
				{
					return ((delegate* unmanaged[Stdcall]<VkDevice, VkSemaphoreCreateInfo*, VkAllocationCallbacks*, VkSemaphore*, VkResult>)vkCreateSemaphore_ptr)(device, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreateSemaphore(VkDevice device, ref VkSemaphoreCreateInfo pCreateInfo, IntPtr pAllocator, VkSemaphore* pSemaphore)
	{
		fixed (VkSemaphoreCreateInfo* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkSemaphoreCreateInfo*, IntPtr, VkSemaphore*, VkResult>)vkCreateSemaphore_ptr)(device, ptr, pAllocator, pSemaphore);
		}
	}

	public unsafe static VkResult vkCreateSemaphore(VkDevice device, ref VkSemaphoreCreateInfo pCreateInfo, IntPtr pAllocator, out VkSemaphore pSemaphore)
	{
		fixed (VkSemaphoreCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkSemaphore* ptr2 = &pSemaphore)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkSemaphoreCreateInfo*, IntPtr, VkSemaphore*, VkResult>)vkCreateSemaphore_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateSemaphore(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, VkSemaphore* pSemaphore)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkSemaphore*, VkResult>)vkCreateSemaphore_ptr)(device, pCreateInfo, pAllocator, pSemaphore);
	}

	public unsafe static VkResult vkCreateSemaphore(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSemaphore pSemaphore)
	{
		fixed (VkSemaphore* ptr = &pSemaphore)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkSemaphore*, VkResult>)vkCreateSemaphore_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateSemaphore(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSemaphore* pSemaphore)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkSemaphore*, VkResult>)vkCreateSemaphore_ptr)(device, pCreateInfo, ptr, pSemaphore);
		}
	}

	public unsafe static VkResult vkCreateSemaphore(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSemaphore pSemaphore)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkSemaphore* ptr2 = &pSemaphore)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkSemaphore*, VkResult>)vkCreateSemaphore_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateSemaphore(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, VkSemaphore* pSemaphore)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkSemaphore*, VkResult>)vkCreateSemaphore_ptr)(device, pCreateInfo, pAllocator, pSemaphore);
	}

	public unsafe static VkResult vkCreateSemaphore(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, out VkSemaphore pSemaphore)
	{
		fixed (VkSemaphore* ptr = &pSemaphore)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkSemaphore*, VkResult>)vkCreateSemaphore_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateShaderModule(VkDevice device, VkShaderModuleCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkShaderModule* pShaderModule)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkShaderModuleCreateInfo*, VkAllocationCallbacks*, VkShaderModule*, VkResult>)vkCreateShaderModule_ptr)(device, pCreateInfo, pAllocator, pShaderModule);
	}

	public unsafe static VkResult vkCreateShaderModule(VkDevice device, VkShaderModuleCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, out VkShaderModule pShaderModule)
	{
		fixed (VkShaderModule* ptr = &pShaderModule)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkShaderModuleCreateInfo*, VkAllocationCallbacks*, VkShaderModule*, VkResult>)vkCreateShaderModule_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateShaderModule(VkDevice device, VkShaderModuleCreateInfo* pCreateInfo, ref VkAllocationCallbacks pAllocator, VkShaderModule* pShaderModule)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkShaderModuleCreateInfo*, VkAllocationCallbacks*, VkShaderModule*, VkResult>)vkCreateShaderModule_ptr)(device, pCreateInfo, ptr, pShaderModule);
		}
	}

	public unsafe static VkResult vkCreateShaderModule(VkDevice device, VkShaderModuleCreateInfo* pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkShaderModule pShaderModule)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkShaderModule* ptr2 = &pShaderModule)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkShaderModuleCreateInfo*, VkAllocationCallbacks*, VkShaderModule*, VkResult>)vkCreateShaderModule_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateShaderModule(VkDevice device, VkShaderModuleCreateInfo* pCreateInfo, IntPtr pAllocator, VkShaderModule* pShaderModule)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkShaderModuleCreateInfo*, IntPtr, VkShaderModule*, VkResult>)vkCreateShaderModule_ptr)(device, pCreateInfo, pAllocator, pShaderModule);
	}

	public unsafe static VkResult vkCreateShaderModule(VkDevice device, VkShaderModuleCreateInfo* pCreateInfo, IntPtr pAllocator, out VkShaderModule pShaderModule)
	{
		fixed (VkShaderModule* ptr = &pShaderModule)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkShaderModuleCreateInfo*, IntPtr, VkShaderModule*, VkResult>)vkCreateShaderModule_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateShaderModule(VkDevice device, ref VkShaderModuleCreateInfo pCreateInfo, VkAllocationCallbacks* pAllocator, VkShaderModule* pShaderModule)
	{
		fixed (VkShaderModuleCreateInfo* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkShaderModuleCreateInfo*, VkAllocationCallbacks*, VkShaderModule*, VkResult>)vkCreateShaderModule_ptr)(device, ptr, pAllocator, pShaderModule);
		}
	}

	public unsafe static VkResult vkCreateShaderModule(VkDevice device, ref VkShaderModuleCreateInfo pCreateInfo, VkAllocationCallbacks* pAllocator, out VkShaderModule pShaderModule)
	{
		fixed (VkShaderModuleCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkShaderModule* ptr2 = &pShaderModule)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkShaderModuleCreateInfo*, VkAllocationCallbacks*, VkShaderModule*, VkResult>)vkCreateShaderModule_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateShaderModule(VkDevice device, ref VkShaderModuleCreateInfo pCreateInfo, ref VkAllocationCallbacks pAllocator, VkShaderModule* pShaderModule)
	{
		fixed (VkShaderModuleCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkShaderModuleCreateInfo*, VkAllocationCallbacks*, VkShaderModule*, VkResult>)vkCreateShaderModule_ptr)(device, ptr, ptr2, pShaderModule);
			}
		}
	}

	public unsafe static VkResult vkCreateShaderModule(VkDevice device, ref VkShaderModuleCreateInfo pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkShaderModule pShaderModule)
	{
		fixed (VkShaderModuleCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkShaderModule* ptr3 = &pShaderModule)
				{
					return ((delegate* unmanaged[Stdcall]<VkDevice, VkShaderModuleCreateInfo*, VkAllocationCallbacks*, VkShaderModule*, VkResult>)vkCreateShaderModule_ptr)(device, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreateShaderModule(VkDevice device, ref VkShaderModuleCreateInfo pCreateInfo, IntPtr pAllocator, VkShaderModule* pShaderModule)
	{
		fixed (VkShaderModuleCreateInfo* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkShaderModuleCreateInfo*, IntPtr, VkShaderModule*, VkResult>)vkCreateShaderModule_ptr)(device, ptr, pAllocator, pShaderModule);
		}
	}

	public unsafe static VkResult vkCreateShaderModule(VkDevice device, ref VkShaderModuleCreateInfo pCreateInfo, IntPtr pAllocator, out VkShaderModule pShaderModule)
	{
		fixed (VkShaderModuleCreateInfo* ptr = &pCreateInfo)
		{
			fixed (VkShaderModule* ptr2 = &pShaderModule)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkShaderModuleCreateInfo*, IntPtr, VkShaderModule*, VkResult>)vkCreateShaderModule_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateShaderModule(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, VkShaderModule* pShaderModule)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkShaderModule*, VkResult>)vkCreateShaderModule_ptr)(device, pCreateInfo, pAllocator, pShaderModule);
	}

	public unsafe static VkResult vkCreateShaderModule(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, out VkShaderModule pShaderModule)
	{
		fixed (VkShaderModule* ptr = &pShaderModule)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkShaderModule*, VkResult>)vkCreateShaderModule_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateShaderModule(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, VkShaderModule* pShaderModule)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkShaderModule*, VkResult>)vkCreateShaderModule_ptr)(device, pCreateInfo, ptr, pShaderModule);
		}
	}

	public unsafe static VkResult vkCreateShaderModule(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkShaderModule pShaderModule)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkShaderModule* ptr2 = &pShaderModule)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkShaderModule*, VkResult>)vkCreateShaderModule_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateShaderModule(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, VkShaderModule* pShaderModule)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkShaderModule*, VkResult>)vkCreateShaderModule_ptr)(device, pCreateInfo, pAllocator, pShaderModule);
	}

	public unsafe static VkResult vkCreateShaderModule(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, out VkShaderModule pShaderModule)
	{
		fixed (VkShaderModule* ptr = &pShaderModule)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkShaderModule*, VkResult>)vkCreateShaderModule_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateSharedSwapchainsKHR(VkDevice device, uint swapchainCount, VkSwapchainCreateInfoKHR* pCreateInfos, VkAllocationCallbacks* pAllocator, VkSwapchainKHR* pSwapchains)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, uint, VkSwapchainCreateInfoKHR*, VkAllocationCallbacks*, VkSwapchainKHR*, VkResult>)vkCreateSharedSwapchainsKHR_ptr)(device, swapchainCount, pCreateInfos, pAllocator, pSwapchains);
	}

	public unsafe static VkResult vkCreateSharedSwapchainsKHR(VkDevice device, uint swapchainCount, VkSwapchainCreateInfoKHR* pCreateInfos, VkAllocationCallbacks* pAllocator, out VkSwapchainKHR pSwapchains)
	{
		fixed (VkSwapchainKHR* ptr = &pSwapchains)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, uint, VkSwapchainCreateInfoKHR*, VkAllocationCallbacks*, VkSwapchainKHR*, VkResult>)vkCreateSharedSwapchainsKHR_ptr)(device, swapchainCount, pCreateInfos, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateSharedSwapchainsKHR(VkDevice device, uint swapchainCount, VkSwapchainCreateInfoKHR* pCreateInfos, ref VkAllocationCallbacks pAllocator, VkSwapchainKHR* pSwapchains)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, uint, VkSwapchainCreateInfoKHR*, VkAllocationCallbacks*, VkSwapchainKHR*, VkResult>)vkCreateSharedSwapchainsKHR_ptr)(device, swapchainCount, pCreateInfos, ptr, pSwapchains);
		}
	}

	public unsafe static VkResult vkCreateSharedSwapchainsKHR(VkDevice device, uint swapchainCount, VkSwapchainCreateInfoKHR* pCreateInfos, ref VkAllocationCallbacks pAllocator, out VkSwapchainKHR pSwapchains)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkSwapchainKHR* ptr2 = &pSwapchains)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, uint, VkSwapchainCreateInfoKHR*, VkAllocationCallbacks*, VkSwapchainKHR*, VkResult>)vkCreateSharedSwapchainsKHR_ptr)(device, swapchainCount, pCreateInfos, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateSharedSwapchainsKHR(VkDevice device, uint swapchainCount, VkSwapchainCreateInfoKHR* pCreateInfos, IntPtr pAllocator, VkSwapchainKHR* pSwapchains)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, uint, VkSwapchainCreateInfoKHR*, IntPtr, VkSwapchainKHR*, VkResult>)vkCreateSharedSwapchainsKHR_ptr)(device, swapchainCount, pCreateInfos, pAllocator, pSwapchains);
	}

	public unsafe static VkResult vkCreateSharedSwapchainsKHR(VkDevice device, uint swapchainCount, VkSwapchainCreateInfoKHR* pCreateInfos, IntPtr pAllocator, out VkSwapchainKHR pSwapchains)
	{
		fixed (VkSwapchainKHR* ptr = &pSwapchains)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, uint, VkSwapchainCreateInfoKHR*, IntPtr, VkSwapchainKHR*, VkResult>)vkCreateSharedSwapchainsKHR_ptr)(device, swapchainCount, pCreateInfos, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateSharedSwapchainsKHR(VkDevice device, uint swapchainCount, ref VkSwapchainCreateInfoKHR pCreateInfos, VkAllocationCallbacks* pAllocator, VkSwapchainKHR* pSwapchains)
	{
		fixed (VkSwapchainCreateInfoKHR* ptr = &pCreateInfos)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, uint, VkSwapchainCreateInfoKHR*, VkAllocationCallbacks*, VkSwapchainKHR*, VkResult>)vkCreateSharedSwapchainsKHR_ptr)(device, swapchainCount, ptr, pAllocator, pSwapchains);
		}
	}

	public unsafe static VkResult vkCreateSharedSwapchainsKHR(VkDevice device, uint swapchainCount, ref VkSwapchainCreateInfoKHR pCreateInfos, VkAllocationCallbacks* pAllocator, out VkSwapchainKHR pSwapchains)
	{
		fixed (VkSwapchainCreateInfoKHR* ptr = &pCreateInfos)
		{
			fixed (VkSwapchainKHR* ptr2 = &pSwapchains)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, uint, VkSwapchainCreateInfoKHR*, VkAllocationCallbacks*, VkSwapchainKHR*, VkResult>)vkCreateSharedSwapchainsKHR_ptr)(device, swapchainCount, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateSharedSwapchainsKHR(VkDevice device, uint swapchainCount, ref VkSwapchainCreateInfoKHR pCreateInfos, ref VkAllocationCallbacks pAllocator, VkSwapchainKHR* pSwapchains)
	{
		fixed (VkSwapchainCreateInfoKHR* ptr = &pCreateInfos)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, uint, VkSwapchainCreateInfoKHR*, VkAllocationCallbacks*, VkSwapchainKHR*, VkResult>)vkCreateSharedSwapchainsKHR_ptr)(device, swapchainCount, ptr, ptr2, pSwapchains);
			}
		}
	}

	public unsafe static VkResult vkCreateSharedSwapchainsKHR(VkDevice device, uint swapchainCount, ref VkSwapchainCreateInfoKHR pCreateInfos, ref VkAllocationCallbacks pAllocator, out VkSwapchainKHR pSwapchains)
	{
		fixed (VkSwapchainCreateInfoKHR* ptr = &pCreateInfos)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkSwapchainKHR* ptr3 = &pSwapchains)
				{
					return ((delegate* unmanaged[Stdcall]<VkDevice, uint, VkSwapchainCreateInfoKHR*, VkAllocationCallbacks*, VkSwapchainKHR*, VkResult>)vkCreateSharedSwapchainsKHR_ptr)(device, swapchainCount, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreateSharedSwapchainsKHR(VkDevice device, uint swapchainCount, ref VkSwapchainCreateInfoKHR pCreateInfos, IntPtr pAllocator, VkSwapchainKHR* pSwapchains)
	{
		fixed (VkSwapchainCreateInfoKHR* ptr = &pCreateInfos)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, uint, VkSwapchainCreateInfoKHR*, IntPtr, VkSwapchainKHR*, VkResult>)vkCreateSharedSwapchainsKHR_ptr)(device, swapchainCount, ptr, pAllocator, pSwapchains);
		}
	}

	public unsafe static VkResult vkCreateSharedSwapchainsKHR(VkDevice device, uint swapchainCount, ref VkSwapchainCreateInfoKHR pCreateInfos, IntPtr pAllocator, out VkSwapchainKHR pSwapchains)
	{
		fixed (VkSwapchainCreateInfoKHR* ptr = &pCreateInfos)
		{
			fixed (VkSwapchainKHR* ptr2 = &pSwapchains)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, uint, VkSwapchainCreateInfoKHR*, IntPtr, VkSwapchainKHR*, VkResult>)vkCreateSharedSwapchainsKHR_ptr)(device, swapchainCount, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateSharedSwapchainsKHR(VkDevice device, uint swapchainCount, IntPtr pCreateInfos, VkAllocationCallbacks* pAllocator, VkSwapchainKHR* pSwapchains)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, uint, IntPtr, VkAllocationCallbacks*, VkSwapchainKHR*, VkResult>)vkCreateSharedSwapchainsKHR_ptr)(device, swapchainCount, pCreateInfos, pAllocator, pSwapchains);
	}

	public unsafe static VkResult vkCreateSharedSwapchainsKHR(VkDevice device, uint swapchainCount, IntPtr pCreateInfos, VkAllocationCallbacks* pAllocator, out VkSwapchainKHR pSwapchains)
	{
		fixed (VkSwapchainKHR* ptr = &pSwapchains)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, uint, IntPtr, VkAllocationCallbacks*, VkSwapchainKHR*, VkResult>)vkCreateSharedSwapchainsKHR_ptr)(device, swapchainCount, pCreateInfos, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateSharedSwapchainsKHR(VkDevice device, uint swapchainCount, IntPtr pCreateInfos, ref VkAllocationCallbacks pAllocator, VkSwapchainKHR* pSwapchains)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, uint, IntPtr, VkAllocationCallbacks*, VkSwapchainKHR*, VkResult>)vkCreateSharedSwapchainsKHR_ptr)(device, swapchainCount, pCreateInfos, ptr, pSwapchains);
		}
	}

	public unsafe static VkResult vkCreateSharedSwapchainsKHR(VkDevice device, uint swapchainCount, IntPtr pCreateInfos, ref VkAllocationCallbacks pAllocator, out VkSwapchainKHR pSwapchains)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkSwapchainKHR* ptr2 = &pSwapchains)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, uint, IntPtr, VkAllocationCallbacks*, VkSwapchainKHR*, VkResult>)vkCreateSharedSwapchainsKHR_ptr)(device, swapchainCount, pCreateInfos, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateSharedSwapchainsKHR(VkDevice device, uint swapchainCount, IntPtr pCreateInfos, IntPtr pAllocator, VkSwapchainKHR* pSwapchains)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, uint, IntPtr, IntPtr, VkSwapchainKHR*, VkResult>)vkCreateSharedSwapchainsKHR_ptr)(device, swapchainCount, pCreateInfos, pAllocator, pSwapchains);
	}

	public unsafe static VkResult vkCreateSharedSwapchainsKHR(VkDevice device, uint swapchainCount, IntPtr pCreateInfos, IntPtr pAllocator, out VkSwapchainKHR pSwapchains)
	{
		fixed (VkSwapchainKHR* ptr = &pSwapchains)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, uint, IntPtr, IntPtr, VkSwapchainKHR*, VkResult>)vkCreateSharedSwapchainsKHR_ptr)(device, swapchainCount, pCreateInfos, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateSharedSwapchainsKHR(VkDevice device, uint swapchainCount, VkSwapchainCreateInfoKHR[] pCreateInfos, VkAllocationCallbacks* pAllocator, VkSwapchainKHR* pSwapchains)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, uint, VkSwapchainCreateInfoKHR[], VkAllocationCallbacks*, VkSwapchainKHR*, VkResult>)vkCreateSharedSwapchainsKHR_ptr)(device, swapchainCount, pCreateInfos, pAllocator, pSwapchains);
	}

	public unsafe static VkResult vkCreateSharedSwapchainsKHR(VkDevice device, uint swapchainCount, VkSwapchainCreateInfoKHR[] pCreateInfos, VkAllocationCallbacks* pAllocator, out VkSwapchainKHR pSwapchains)
	{
		fixed (VkSwapchainKHR* ptr = &pSwapchains)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, uint, VkSwapchainCreateInfoKHR[], VkAllocationCallbacks*, VkSwapchainKHR*, VkResult>)vkCreateSharedSwapchainsKHR_ptr)(device, swapchainCount, pCreateInfos, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateSharedSwapchainsKHR(VkDevice device, uint swapchainCount, VkSwapchainCreateInfoKHR[] pCreateInfos, ref VkAllocationCallbacks pAllocator, VkSwapchainKHR* pSwapchains)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, uint, VkSwapchainCreateInfoKHR[], VkAllocationCallbacks*, VkSwapchainKHR*, VkResult>)vkCreateSharedSwapchainsKHR_ptr)(device, swapchainCount, pCreateInfos, ptr, pSwapchains);
		}
	}

	public unsafe static VkResult vkCreateSharedSwapchainsKHR(VkDevice device, uint swapchainCount, VkSwapchainCreateInfoKHR[] pCreateInfos, ref VkAllocationCallbacks pAllocator, out VkSwapchainKHR pSwapchains)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkSwapchainKHR* ptr2 = &pSwapchains)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, uint, VkSwapchainCreateInfoKHR[], VkAllocationCallbacks*, VkSwapchainKHR*, VkResult>)vkCreateSharedSwapchainsKHR_ptr)(device, swapchainCount, pCreateInfos, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateSharedSwapchainsKHR(VkDevice device, uint swapchainCount, VkSwapchainCreateInfoKHR[] pCreateInfos, IntPtr pAllocator, VkSwapchainKHR* pSwapchains)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, uint, VkSwapchainCreateInfoKHR[], IntPtr, VkSwapchainKHR*, VkResult>)vkCreateSharedSwapchainsKHR_ptr)(device, swapchainCount, pCreateInfos, pAllocator, pSwapchains);
	}

	public unsafe static VkResult vkCreateSharedSwapchainsKHR(VkDevice device, uint swapchainCount, VkSwapchainCreateInfoKHR[] pCreateInfos, IntPtr pAllocator, out VkSwapchainKHR pSwapchains)
	{
		fixed (VkSwapchainKHR* ptr = &pSwapchains)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, uint, VkSwapchainCreateInfoKHR[], IntPtr, VkSwapchainKHR*, VkResult>)vkCreateSharedSwapchainsKHR_ptr)(device, swapchainCount, pCreateInfos, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateSwapchainKHR(VkDevice device, VkSwapchainCreateInfoKHR* pCreateInfo, VkAllocationCallbacks* pAllocator, VkSwapchainKHR* pSwapchain)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkSwapchainCreateInfoKHR*, VkAllocationCallbacks*, VkSwapchainKHR*, VkResult>)vkCreateSwapchainKHR_ptr)(device, pCreateInfo, pAllocator, pSwapchain);
	}

	public unsafe static VkResult vkCreateSwapchainKHR(VkDevice device, VkSwapchainCreateInfoKHR* pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSwapchainKHR pSwapchain)
	{
		fixed (VkSwapchainKHR* ptr = &pSwapchain)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkSwapchainCreateInfoKHR*, VkAllocationCallbacks*, VkSwapchainKHR*, VkResult>)vkCreateSwapchainKHR_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateSwapchainKHR(VkDevice device, VkSwapchainCreateInfoKHR* pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSwapchainKHR* pSwapchain)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkSwapchainCreateInfoKHR*, VkAllocationCallbacks*, VkSwapchainKHR*, VkResult>)vkCreateSwapchainKHR_ptr)(device, pCreateInfo, ptr, pSwapchain);
		}
	}

	public unsafe static VkResult vkCreateSwapchainKHR(VkDevice device, VkSwapchainCreateInfoKHR* pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSwapchainKHR pSwapchain)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkSwapchainKHR* ptr2 = &pSwapchain)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkSwapchainCreateInfoKHR*, VkAllocationCallbacks*, VkSwapchainKHR*, VkResult>)vkCreateSwapchainKHR_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateSwapchainKHR(VkDevice device, VkSwapchainCreateInfoKHR* pCreateInfo, IntPtr pAllocator, VkSwapchainKHR* pSwapchain)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkSwapchainCreateInfoKHR*, IntPtr, VkSwapchainKHR*, VkResult>)vkCreateSwapchainKHR_ptr)(device, pCreateInfo, pAllocator, pSwapchain);
	}

	public unsafe static VkResult vkCreateSwapchainKHR(VkDevice device, VkSwapchainCreateInfoKHR* pCreateInfo, IntPtr pAllocator, out VkSwapchainKHR pSwapchain)
	{
		fixed (VkSwapchainKHR* ptr = &pSwapchain)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkSwapchainCreateInfoKHR*, IntPtr, VkSwapchainKHR*, VkResult>)vkCreateSwapchainKHR_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateSwapchainKHR(VkDevice device, ref VkSwapchainCreateInfoKHR pCreateInfo, VkAllocationCallbacks* pAllocator, VkSwapchainKHR* pSwapchain)
	{
		fixed (VkSwapchainCreateInfoKHR* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkSwapchainCreateInfoKHR*, VkAllocationCallbacks*, VkSwapchainKHR*, VkResult>)vkCreateSwapchainKHR_ptr)(device, ptr, pAllocator, pSwapchain);
		}
	}

	public unsafe static VkResult vkCreateSwapchainKHR(VkDevice device, ref VkSwapchainCreateInfoKHR pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSwapchainKHR pSwapchain)
	{
		fixed (VkSwapchainCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkSwapchainKHR* ptr2 = &pSwapchain)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkSwapchainCreateInfoKHR*, VkAllocationCallbacks*, VkSwapchainKHR*, VkResult>)vkCreateSwapchainKHR_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateSwapchainKHR(VkDevice device, ref VkSwapchainCreateInfoKHR pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSwapchainKHR* pSwapchain)
	{
		fixed (VkSwapchainCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkSwapchainCreateInfoKHR*, VkAllocationCallbacks*, VkSwapchainKHR*, VkResult>)vkCreateSwapchainKHR_ptr)(device, ptr, ptr2, pSwapchain);
			}
		}
	}

	public unsafe static VkResult vkCreateSwapchainKHR(VkDevice device, ref VkSwapchainCreateInfoKHR pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSwapchainKHR pSwapchain)
	{
		fixed (VkSwapchainCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkSwapchainKHR* ptr3 = &pSwapchain)
				{
					return ((delegate* unmanaged[Stdcall]<VkDevice, VkSwapchainCreateInfoKHR*, VkAllocationCallbacks*, VkSwapchainKHR*, VkResult>)vkCreateSwapchainKHR_ptr)(device, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreateSwapchainKHR(VkDevice device, ref VkSwapchainCreateInfoKHR pCreateInfo, IntPtr pAllocator, VkSwapchainKHR* pSwapchain)
	{
		fixed (VkSwapchainCreateInfoKHR* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkSwapchainCreateInfoKHR*, IntPtr, VkSwapchainKHR*, VkResult>)vkCreateSwapchainKHR_ptr)(device, ptr, pAllocator, pSwapchain);
		}
	}

	public unsafe static VkResult vkCreateSwapchainKHR(VkDevice device, ref VkSwapchainCreateInfoKHR pCreateInfo, IntPtr pAllocator, out VkSwapchainKHR pSwapchain)
	{
		fixed (VkSwapchainCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkSwapchainKHR* ptr2 = &pSwapchain)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkSwapchainCreateInfoKHR*, IntPtr, VkSwapchainKHR*, VkResult>)vkCreateSwapchainKHR_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateSwapchainKHR(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, VkSwapchainKHR* pSwapchain)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkSwapchainKHR*, VkResult>)vkCreateSwapchainKHR_ptr)(device, pCreateInfo, pAllocator, pSwapchain);
	}

	public unsafe static VkResult vkCreateSwapchainKHR(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSwapchainKHR pSwapchain)
	{
		fixed (VkSwapchainKHR* ptr = &pSwapchain)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkSwapchainKHR*, VkResult>)vkCreateSwapchainKHR_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateSwapchainKHR(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSwapchainKHR* pSwapchain)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkSwapchainKHR*, VkResult>)vkCreateSwapchainKHR_ptr)(device, pCreateInfo, ptr, pSwapchain);
		}
	}

	public unsafe static VkResult vkCreateSwapchainKHR(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSwapchainKHR pSwapchain)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkSwapchainKHR* ptr2 = &pSwapchain)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkSwapchainKHR*, VkResult>)vkCreateSwapchainKHR_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateSwapchainKHR(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, VkSwapchainKHR* pSwapchain)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkSwapchainKHR*, VkResult>)vkCreateSwapchainKHR_ptr)(device, pCreateInfo, pAllocator, pSwapchain);
	}

	public unsafe static VkResult vkCreateSwapchainKHR(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, out VkSwapchainKHR pSwapchain)
	{
		fixed (VkSwapchainKHR* ptr = &pSwapchain)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkSwapchainKHR*, VkResult>)vkCreateSwapchainKHR_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateValidationCacheEXT(VkDevice device, VkValidationCacheCreateInfoEXT* pCreateInfo, VkAllocationCallbacks* pAllocator, VkValidationCacheEXT* pValidationCache)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkValidationCacheCreateInfoEXT*, VkAllocationCallbacks*, VkValidationCacheEXT*, VkResult>)vkCreateValidationCacheEXT_ptr)(device, pCreateInfo, pAllocator, pValidationCache);
	}

	public unsafe static VkResult vkCreateValidationCacheEXT(VkDevice device, VkValidationCacheCreateInfoEXT* pCreateInfo, VkAllocationCallbacks* pAllocator, out VkValidationCacheEXT pValidationCache)
	{
		fixed (VkValidationCacheEXT* ptr = &pValidationCache)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkValidationCacheCreateInfoEXT*, VkAllocationCallbacks*, VkValidationCacheEXT*, VkResult>)vkCreateValidationCacheEXT_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateValidationCacheEXT(VkDevice device, VkValidationCacheCreateInfoEXT* pCreateInfo, ref VkAllocationCallbacks pAllocator, VkValidationCacheEXT* pValidationCache)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkValidationCacheCreateInfoEXT*, VkAllocationCallbacks*, VkValidationCacheEXT*, VkResult>)vkCreateValidationCacheEXT_ptr)(device, pCreateInfo, ptr, pValidationCache);
		}
	}

	public unsafe static VkResult vkCreateValidationCacheEXT(VkDevice device, VkValidationCacheCreateInfoEXT* pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkValidationCacheEXT pValidationCache)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkValidationCacheEXT* ptr2 = &pValidationCache)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkValidationCacheCreateInfoEXT*, VkAllocationCallbacks*, VkValidationCacheEXT*, VkResult>)vkCreateValidationCacheEXT_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateValidationCacheEXT(VkDevice device, VkValidationCacheCreateInfoEXT* pCreateInfo, IntPtr pAllocator, VkValidationCacheEXT* pValidationCache)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkValidationCacheCreateInfoEXT*, IntPtr, VkValidationCacheEXT*, VkResult>)vkCreateValidationCacheEXT_ptr)(device, pCreateInfo, pAllocator, pValidationCache);
	}

	public unsafe static VkResult vkCreateValidationCacheEXT(VkDevice device, VkValidationCacheCreateInfoEXT* pCreateInfo, IntPtr pAllocator, out VkValidationCacheEXT pValidationCache)
	{
		fixed (VkValidationCacheEXT* ptr = &pValidationCache)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkValidationCacheCreateInfoEXT*, IntPtr, VkValidationCacheEXT*, VkResult>)vkCreateValidationCacheEXT_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateValidationCacheEXT(VkDevice device, ref VkValidationCacheCreateInfoEXT pCreateInfo, VkAllocationCallbacks* pAllocator, VkValidationCacheEXT* pValidationCache)
	{
		fixed (VkValidationCacheCreateInfoEXT* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkValidationCacheCreateInfoEXT*, VkAllocationCallbacks*, VkValidationCacheEXT*, VkResult>)vkCreateValidationCacheEXT_ptr)(device, ptr, pAllocator, pValidationCache);
		}
	}

	public unsafe static VkResult vkCreateValidationCacheEXT(VkDevice device, ref VkValidationCacheCreateInfoEXT pCreateInfo, VkAllocationCallbacks* pAllocator, out VkValidationCacheEXT pValidationCache)
	{
		fixed (VkValidationCacheCreateInfoEXT* ptr = &pCreateInfo)
		{
			fixed (VkValidationCacheEXT* ptr2 = &pValidationCache)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkValidationCacheCreateInfoEXT*, VkAllocationCallbacks*, VkValidationCacheEXT*, VkResult>)vkCreateValidationCacheEXT_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateValidationCacheEXT(VkDevice device, ref VkValidationCacheCreateInfoEXT pCreateInfo, ref VkAllocationCallbacks pAllocator, VkValidationCacheEXT* pValidationCache)
	{
		fixed (VkValidationCacheCreateInfoEXT* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkValidationCacheCreateInfoEXT*, VkAllocationCallbacks*, VkValidationCacheEXT*, VkResult>)vkCreateValidationCacheEXT_ptr)(device, ptr, ptr2, pValidationCache);
			}
		}
	}

	public unsafe static VkResult vkCreateValidationCacheEXT(VkDevice device, ref VkValidationCacheCreateInfoEXT pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkValidationCacheEXT pValidationCache)
	{
		fixed (VkValidationCacheCreateInfoEXT* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkValidationCacheEXT* ptr3 = &pValidationCache)
				{
					return ((delegate* unmanaged[Stdcall]<VkDevice, VkValidationCacheCreateInfoEXT*, VkAllocationCallbacks*, VkValidationCacheEXT*, VkResult>)vkCreateValidationCacheEXT_ptr)(device, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreateValidationCacheEXT(VkDevice device, ref VkValidationCacheCreateInfoEXT pCreateInfo, IntPtr pAllocator, VkValidationCacheEXT* pValidationCache)
	{
		fixed (VkValidationCacheCreateInfoEXT* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkValidationCacheCreateInfoEXT*, IntPtr, VkValidationCacheEXT*, VkResult>)vkCreateValidationCacheEXT_ptr)(device, ptr, pAllocator, pValidationCache);
		}
	}

	public unsafe static VkResult vkCreateValidationCacheEXT(VkDevice device, ref VkValidationCacheCreateInfoEXT pCreateInfo, IntPtr pAllocator, out VkValidationCacheEXT pValidationCache)
	{
		fixed (VkValidationCacheCreateInfoEXT* ptr = &pCreateInfo)
		{
			fixed (VkValidationCacheEXT* ptr2 = &pValidationCache)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkValidationCacheCreateInfoEXT*, IntPtr, VkValidationCacheEXT*, VkResult>)vkCreateValidationCacheEXT_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateValidationCacheEXT(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, VkValidationCacheEXT* pValidationCache)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkValidationCacheEXT*, VkResult>)vkCreateValidationCacheEXT_ptr)(device, pCreateInfo, pAllocator, pValidationCache);
	}

	public unsafe static VkResult vkCreateValidationCacheEXT(VkDevice device, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, out VkValidationCacheEXT pValidationCache)
	{
		fixed (VkValidationCacheEXT* ptr = &pValidationCache)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkValidationCacheEXT*, VkResult>)vkCreateValidationCacheEXT_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateValidationCacheEXT(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, VkValidationCacheEXT* pValidationCache)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkValidationCacheEXT*, VkResult>)vkCreateValidationCacheEXT_ptr)(device, pCreateInfo, ptr, pValidationCache);
		}
	}

	public unsafe static VkResult vkCreateValidationCacheEXT(VkDevice device, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkValidationCacheEXT pValidationCache)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkValidationCacheEXT* ptr2 = &pValidationCache)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkValidationCacheEXT*, VkResult>)vkCreateValidationCacheEXT_ptr)(device, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateValidationCacheEXT(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, VkValidationCacheEXT* pValidationCache)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkValidationCacheEXT*, VkResult>)vkCreateValidationCacheEXT_ptr)(device, pCreateInfo, pAllocator, pValidationCache);
	}

	public unsafe static VkResult vkCreateValidationCacheEXT(VkDevice device, IntPtr pCreateInfo, IntPtr pAllocator, out VkValidationCacheEXT pValidationCache)
	{
		fixed (VkValidationCacheEXT* ptr = &pValidationCache)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkValidationCacheEXT*, VkResult>)vkCreateValidationCacheEXT_ptr)(device, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateViSurfaceNN(VkInstance instance, VkViSurfaceCreateInfoNN* pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, VkViSurfaceCreateInfoNN*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateViSurfaceNN_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateViSurfaceNN(VkInstance instance, VkViSurfaceCreateInfoNN* pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkViSurfaceCreateInfoNN*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateViSurfaceNN_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateViSurfaceNN(VkInstance instance, VkViSurfaceCreateInfoNN* pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkViSurfaceCreateInfoNN*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateViSurfaceNN_ptr)(instance, pCreateInfo, ptr, pSurface);
		}
	}

	public unsafe static VkResult vkCreateViSurfaceNN(VkInstance instance, VkViSurfaceCreateInfoNN* pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkViSurfaceCreateInfoNN*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateViSurfaceNN_ptr)(instance, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateViSurfaceNN(VkInstance instance, VkViSurfaceCreateInfoNN* pCreateInfo, IntPtr pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, VkViSurfaceCreateInfoNN*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateViSurfaceNN_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateViSurfaceNN(VkInstance instance, VkViSurfaceCreateInfoNN* pCreateInfo, IntPtr pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkViSurfaceCreateInfoNN*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateViSurfaceNN_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateViSurfaceNN(VkInstance instance, ref VkViSurfaceCreateInfoNN pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkViSurfaceCreateInfoNN* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkViSurfaceCreateInfoNN*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateViSurfaceNN_ptr)(instance, ptr, pAllocator, pSurface);
		}
	}

	public unsafe static VkResult vkCreateViSurfaceNN(VkInstance instance, ref VkViSurfaceCreateInfoNN pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkViSurfaceCreateInfoNN* ptr = &pCreateInfo)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkViSurfaceCreateInfoNN*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateViSurfaceNN_ptr)(instance, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateViSurfaceNN(VkInstance instance, ref VkViSurfaceCreateInfoNN pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkViSurfaceCreateInfoNN* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkViSurfaceCreateInfoNN*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateViSurfaceNN_ptr)(instance, ptr, ptr2, pSurface);
			}
		}
	}

	public unsafe static VkResult vkCreateViSurfaceNN(VkInstance instance, ref VkViSurfaceCreateInfoNN pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkViSurfaceCreateInfoNN* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkSurfaceKHR* ptr3 = &pSurface)
				{
					return ((delegate* unmanaged[Stdcall]<VkInstance, VkViSurfaceCreateInfoNN*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateViSurfaceNN_ptr)(instance, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreateViSurfaceNN(VkInstance instance, ref VkViSurfaceCreateInfoNN pCreateInfo, IntPtr pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkViSurfaceCreateInfoNN* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkViSurfaceCreateInfoNN*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateViSurfaceNN_ptr)(instance, ptr, pAllocator, pSurface);
		}
	}

	public unsafe static VkResult vkCreateViSurfaceNN(VkInstance instance, ref VkViSurfaceCreateInfoNN pCreateInfo, IntPtr pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkViSurfaceCreateInfoNN* ptr = &pCreateInfo)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkViSurfaceCreateInfoNN*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateViSurfaceNN_ptr)(instance, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateViSurfaceNN(VkInstance instance, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateViSurfaceNN_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateViSurfaceNN(VkInstance instance, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateViSurfaceNN_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateViSurfaceNN(VkInstance instance, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateViSurfaceNN_ptr)(instance, pCreateInfo, ptr, pSurface);
		}
	}

	public unsafe static VkResult vkCreateViSurfaceNN(VkInstance instance, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateViSurfaceNN_ptr)(instance, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateViSurfaceNN(VkInstance instance, IntPtr pCreateInfo, IntPtr pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateViSurfaceNN_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateViSurfaceNN(VkInstance instance, IntPtr pCreateInfo, IntPtr pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateViSurfaceNN_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateWaylandSurfaceKHR(VkInstance instance, VkWaylandSurfaceCreateInfoKHR* pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, VkWaylandSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateWaylandSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateWaylandSurfaceKHR(VkInstance instance, VkWaylandSurfaceCreateInfoKHR* pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkWaylandSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateWaylandSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateWaylandSurfaceKHR(VkInstance instance, VkWaylandSurfaceCreateInfoKHR* pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkWaylandSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateWaylandSurfaceKHR_ptr)(instance, pCreateInfo, ptr, pSurface);
		}
	}

	public unsafe static VkResult vkCreateWaylandSurfaceKHR(VkInstance instance, VkWaylandSurfaceCreateInfoKHR* pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkWaylandSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateWaylandSurfaceKHR_ptr)(instance, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateWaylandSurfaceKHR(VkInstance instance, VkWaylandSurfaceCreateInfoKHR* pCreateInfo, IntPtr pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, VkWaylandSurfaceCreateInfoKHR*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateWaylandSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateWaylandSurfaceKHR(VkInstance instance, VkWaylandSurfaceCreateInfoKHR* pCreateInfo, IntPtr pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkWaylandSurfaceCreateInfoKHR*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateWaylandSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateWaylandSurfaceKHR(VkInstance instance, ref VkWaylandSurfaceCreateInfoKHR pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkWaylandSurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkWaylandSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateWaylandSurfaceKHR_ptr)(instance, ptr, pAllocator, pSurface);
		}
	}

	public unsafe static VkResult vkCreateWaylandSurfaceKHR(VkInstance instance, ref VkWaylandSurfaceCreateInfoKHR pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkWaylandSurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkWaylandSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateWaylandSurfaceKHR_ptr)(instance, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateWaylandSurfaceKHR(VkInstance instance, ref VkWaylandSurfaceCreateInfoKHR pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkWaylandSurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkWaylandSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateWaylandSurfaceKHR_ptr)(instance, ptr, ptr2, pSurface);
			}
		}
	}

	public unsafe static VkResult vkCreateWaylandSurfaceKHR(VkInstance instance, ref VkWaylandSurfaceCreateInfoKHR pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkWaylandSurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkSurfaceKHR* ptr3 = &pSurface)
				{
					return ((delegate* unmanaged[Stdcall]<VkInstance, VkWaylandSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateWaylandSurfaceKHR_ptr)(instance, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreateWaylandSurfaceKHR(VkInstance instance, ref VkWaylandSurfaceCreateInfoKHR pCreateInfo, IntPtr pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkWaylandSurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkWaylandSurfaceCreateInfoKHR*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateWaylandSurfaceKHR_ptr)(instance, ptr, pAllocator, pSurface);
		}
	}

	public unsafe static VkResult vkCreateWaylandSurfaceKHR(VkInstance instance, ref VkWaylandSurfaceCreateInfoKHR pCreateInfo, IntPtr pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkWaylandSurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkWaylandSurfaceCreateInfoKHR*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateWaylandSurfaceKHR_ptr)(instance, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateWaylandSurfaceKHR(VkInstance instance, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateWaylandSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateWaylandSurfaceKHR(VkInstance instance, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateWaylandSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateWaylandSurfaceKHR(VkInstance instance, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateWaylandSurfaceKHR_ptr)(instance, pCreateInfo, ptr, pSurface);
		}
	}

	public unsafe static VkResult vkCreateWaylandSurfaceKHR(VkInstance instance, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateWaylandSurfaceKHR_ptr)(instance, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateWaylandSurfaceKHR(VkInstance instance, IntPtr pCreateInfo, IntPtr pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateWaylandSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateWaylandSurfaceKHR(VkInstance instance, IntPtr pCreateInfo, IntPtr pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateWaylandSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateWin32SurfaceKHR(VkInstance instance, VkWin32SurfaceCreateInfoKHR* pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, VkWin32SurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateWin32SurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateWin32SurfaceKHR(VkInstance instance, VkWin32SurfaceCreateInfoKHR* pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkWin32SurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateWin32SurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateWin32SurfaceKHR(VkInstance instance, VkWin32SurfaceCreateInfoKHR* pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkWin32SurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateWin32SurfaceKHR_ptr)(instance, pCreateInfo, ptr, pSurface);
		}
	}

	public unsafe static VkResult vkCreateWin32SurfaceKHR(VkInstance instance, VkWin32SurfaceCreateInfoKHR* pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkWin32SurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateWin32SurfaceKHR_ptr)(instance, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateWin32SurfaceKHR(VkInstance instance, VkWin32SurfaceCreateInfoKHR* pCreateInfo, IntPtr pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, VkWin32SurfaceCreateInfoKHR*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateWin32SurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateWin32SurfaceKHR(VkInstance instance, VkWin32SurfaceCreateInfoKHR* pCreateInfo, IntPtr pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkWin32SurfaceCreateInfoKHR*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateWin32SurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateWin32SurfaceKHR(VkInstance instance, ref VkWin32SurfaceCreateInfoKHR pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkWin32SurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkWin32SurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateWin32SurfaceKHR_ptr)(instance, ptr, pAllocator, pSurface);
		}
	}

	public unsafe static VkResult vkCreateWin32SurfaceKHR(VkInstance instance, ref VkWin32SurfaceCreateInfoKHR pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkWin32SurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkWin32SurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateWin32SurfaceKHR_ptr)(instance, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateWin32SurfaceKHR(VkInstance instance, ref VkWin32SurfaceCreateInfoKHR pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkWin32SurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkWin32SurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateWin32SurfaceKHR_ptr)(instance, ptr, ptr2, pSurface);
			}
		}
	}

	public unsafe static VkResult vkCreateWin32SurfaceKHR(VkInstance instance, ref VkWin32SurfaceCreateInfoKHR pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkWin32SurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkSurfaceKHR* ptr3 = &pSurface)
				{
					return ((delegate* unmanaged[Stdcall]<VkInstance, VkWin32SurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateWin32SurfaceKHR_ptr)(instance, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreateWin32SurfaceKHR(VkInstance instance, ref VkWin32SurfaceCreateInfoKHR pCreateInfo, IntPtr pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkWin32SurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkWin32SurfaceCreateInfoKHR*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateWin32SurfaceKHR_ptr)(instance, ptr, pAllocator, pSurface);
		}
	}

	public unsafe static VkResult vkCreateWin32SurfaceKHR(VkInstance instance, ref VkWin32SurfaceCreateInfoKHR pCreateInfo, IntPtr pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkWin32SurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkWin32SurfaceCreateInfoKHR*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateWin32SurfaceKHR_ptr)(instance, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateWin32SurfaceKHR(VkInstance instance, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateWin32SurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateWin32SurfaceKHR(VkInstance instance, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateWin32SurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateWin32SurfaceKHR(VkInstance instance, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateWin32SurfaceKHR_ptr)(instance, pCreateInfo, ptr, pSurface);
		}
	}

	public unsafe static VkResult vkCreateWin32SurfaceKHR(VkInstance instance, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateWin32SurfaceKHR_ptr)(instance, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateWin32SurfaceKHR(VkInstance instance, IntPtr pCreateInfo, IntPtr pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateWin32SurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateWin32SurfaceKHR(VkInstance instance, IntPtr pCreateInfo, IntPtr pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateWin32SurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateXcbSurfaceKHR(VkInstance instance, VkXcbSurfaceCreateInfoKHR* pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, VkXcbSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateXcbSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateXcbSurfaceKHR(VkInstance instance, VkXcbSurfaceCreateInfoKHR* pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkXcbSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateXcbSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateXcbSurfaceKHR(VkInstance instance, VkXcbSurfaceCreateInfoKHR* pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkXcbSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateXcbSurfaceKHR_ptr)(instance, pCreateInfo, ptr, pSurface);
		}
	}

	public unsafe static VkResult vkCreateXcbSurfaceKHR(VkInstance instance, VkXcbSurfaceCreateInfoKHR* pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkXcbSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateXcbSurfaceKHR_ptr)(instance, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateXcbSurfaceKHR(VkInstance instance, VkXcbSurfaceCreateInfoKHR* pCreateInfo, IntPtr pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, VkXcbSurfaceCreateInfoKHR*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateXcbSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateXcbSurfaceKHR(VkInstance instance, VkXcbSurfaceCreateInfoKHR* pCreateInfo, IntPtr pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkXcbSurfaceCreateInfoKHR*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateXcbSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateXcbSurfaceKHR(VkInstance instance, ref VkXcbSurfaceCreateInfoKHR pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkXcbSurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkXcbSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateXcbSurfaceKHR_ptr)(instance, ptr, pAllocator, pSurface);
		}
	}

	public unsafe static VkResult vkCreateXcbSurfaceKHR(VkInstance instance, ref VkXcbSurfaceCreateInfoKHR pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkXcbSurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkXcbSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateXcbSurfaceKHR_ptr)(instance, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateXcbSurfaceKHR(VkInstance instance, ref VkXcbSurfaceCreateInfoKHR pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkXcbSurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkXcbSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateXcbSurfaceKHR_ptr)(instance, ptr, ptr2, pSurface);
			}
		}
	}

	public unsafe static VkResult vkCreateXcbSurfaceKHR(VkInstance instance, ref VkXcbSurfaceCreateInfoKHR pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkXcbSurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkSurfaceKHR* ptr3 = &pSurface)
				{
					return ((delegate* unmanaged[Stdcall]<VkInstance, VkXcbSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateXcbSurfaceKHR_ptr)(instance, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreateXcbSurfaceKHR(VkInstance instance, ref VkXcbSurfaceCreateInfoKHR pCreateInfo, IntPtr pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkXcbSurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkXcbSurfaceCreateInfoKHR*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateXcbSurfaceKHR_ptr)(instance, ptr, pAllocator, pSurface);
		}
	}

	public unsafe static VkResult vkCreateXcbSurfaceKHR(VkInstance instance, ref VkXcbSurfaceCreateInfoKHR pCreateInfo, IntPtr pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkXcbSurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkXcbSurfaceCreateInfoKHR*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateXcbSurfaceKHR_ptr)(instance, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateXcbSurfaceKHR(VkInstance instance, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateXcbSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateXcbSurfaceKHR(VkInstance instance, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateXcbSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateXcbSurfaceKHR(VkInstance instance, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateXcbSurfaceKHR_ptr)(instance, pCreateInfo, ptr, pSurface);
		}
	}

	public unsafe static VkResult vkCreateXcbSurfaceKHR(VkInstance instance, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateXcbSurfaceKHR_ptr)(instance, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateXcbSurfaceKHR(VkInstance instance, IntPtr pCreateInfo, IntPtr pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateXcbSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateXcbSurfaceKHR(VkInstance instance, IntPtr pCreateInfo, IntPtr pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateXcbSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateXlibSurfaceKHR(VkInstance instance, VkXlibSurfaceCreateInfoKHR* pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, VkXlibSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateXlibSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateXlibSurfaceKHR(VkInstance instance, VkXlibSurfaceCreateInfoKHR* pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkXlibSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateXlibSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateXlibSurfaceKHR(VkInstance instance, VkXlibSurfaceCreateInfoKHR* pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkXlibSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateXlibSurfaceKHR_ptr)(instance, pCreateInfo, ptr, pSurface);
		}
	}

	public unsafe static VkResult vkCreateXlibSurfaceKHR(VkInstance instance, VkXlibSurfaceCreateInfoKHR* pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkXlibSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateXlibSurfaceKHR_ptr)(instance, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateXlibSurfaceKHR(VkInstance instance, VkXlibSurfaceCreateInfoKHR* pCreateInfo, IntPtr pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, VkXlibSurfaceCreateInfoKHR*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateXlibSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateXlibSurfaceKHR(VkInstance instance, VkXlibSurfaceCreateInfoKHR* pCreateInfo, IntPtr pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkXlibSurfaceCreateInfoKHR*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateXlibSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateXlibSurfaceKHR(VkInstance instance, ref VkXlibSurfaceCreateInfoKHR pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkXlibSurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkXlibSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateXlibSurfaceKHR_ptr)(instance, ptr, pAllocator, pSurface);
		}
	}

	public unsafe static VkResult vkCreateXlibSurfaceKHR(VkInstance instance, ref VkXlibSurfaceCreateInfoKHR pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkXlibSurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkXlibSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateXlibSurfaceKHR_ptr)(instance, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateXlibSurfaceKHR(VkInstance instance, ref VkXlibSurfaceCreateInfoKHR pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkXlibSurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkXlibSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateXlibSurfaceKHR_ptr)(instance, ptr, ptr2, pSurface);
			}
		}
	}

	public unsafe static VkResult vkCreateXlibSurfaceKHR(VkInstance instance, ref VkXlibSurfaceCreateInfoKHR pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkXlibSurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkSurfaceKHR* ptr3 = &pSurface)
				{
					return ((delegate* unmanaged[Stdcall]<VkInstance, VkXlibSurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateXlibSurfaceKHR_ptr)(instance, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkCreateXlibSurfaceKHR(VkInstance instance, ref VkXlibSurfaceCreateInfoKHR pCreateInfo, IntPtr pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkXlibSurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, VkXlibSurfaceCreateInfoKHR*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateXlibSurfaceKHR_ptr)(instance, ptr, pAllocator, pSurface);
		}
	}

	public unsafe static VkResult vkCreateXlibSurfaceKHR(VkInstance instance, ref VkXlibSurfaceCreateInfoKHR pCreateInfo, IntPtr pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkXlibSurfaceCreateInfoKHR* ptr = &pCreateInfo)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, VkXlibSurfaceCreateInfoKHR*, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateXlibSurfaceKHR_ptr)(instance, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateXlibSurfaceKHR(VkInstance instance, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateXlibSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateXlibSurfaceKHR(VkInstance instance, IntPtr pCreateInfo, VkAllocationCallbacks* pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateXlibSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkCreateXlibSurfaceKHR(VkInstance instance, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, VkSurfaceKHR* pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateXlibSurfaceKHR_ptr)(instance, pCreateInfo, ptr, pSurface);
		}
	}

	public unsafe static VkResult vkCreateXlibSurfaceKHR(VkInstance instance, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkSurfaceKHR* ptr2 = &pSurface)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)vkCreateXlibSurfaceKHR_ptr)(instance, pCreateInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkCreateXlibSurfaceKHR(VkInstance instance, IntPtr pCreateInfo, IntPtr pAllocator, VkSurfaceKHR* pSurface)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateXlibSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, pSurface);
	}

	public unsafe static VkResult vkCreateXlibSurfaceKHR(VkInstance instance, IntPtr pCreateInfo, IntPtr pAllocator, out VkSurfaceKHR pSurface)
	{
		fixed (VkSurfaceKHR* ptr = &pSurface)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, IntPtr, VkSurfaceKHR*, VkResult>)vkCreateXlibSurfaceKHR_ptr)(instance, pCreateInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkDebugMarkerSetObjectNameEXT(VkDevice device, VkDebugMarkerObjectNameInfoEXT* pNameInfo)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkDebugMarkerObjectNameInfoEXT*, VkResult>)vkDebugMarkerSetObjectNameEXT_ptr)(device, pNameInfo);
	}

	public unsafe static VkResult vkDebugMarkerSetObjectNameEXT(VkDevice device, ref VkDebugMarkerObjectNameInfoEXT pNameInfo)
	{
		fixed (VkDebugMarkerObjectNameInfoEXT* ptr = &pNameInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDebugMarkerObjectNameInfoEXT*, VkResult>)vkDebugMarkerSetObjectNameEXT_ptr)(device, ptr);
		}
	}

	public unsafe static VkResult vkDebugMarkerSetObjectNameEXT(VkDevice device, IntPtr pNameInfo)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkResult>)vkDebugMarkerSetObjectNameEXT_ptr)(device, pNameInfo);
	}

	public unsafe static VkResult vkDebugMarkerSetObjectTagEXT(VkDevice device, VkDebugMarkerObjectTagInfoEXT* pTagInfo)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkDebugMarkerObjectTagInfoEXT*, VkResult>)vkDebugMarkerSetObjectTagEXT_ptr)(device, pTagInfo);
	}

	public unsafe static VkResult vkDebugMarkerSetObjectTagEXT(VkDevice device, ref VkDebugMarkerObjectTagInfoEXT pTagInfo)
	{
		fixed (VkDebugMarkerObjectTagInfoEXT* ptr = &pTagInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDebugMarkerObjectTagInfoEXT*, VkResult>)vkDebugMarkerSetObjectTagEXT_ptr)(device, ptr);
		}
	}

	public unsafe static VkResult vkDebugMarkerSetObjectTagEXT(VkDevice device, IntPtr pTagInfo)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkResult>)vkDebugMarkerSetObjectTagEXT_ptr)(device, pTagInfo);
	}

	public unsafe static void vkDebugReportMessageEXT(VkInstance instance, VkDebugReportFlagsEXT flags, VkDebugReportObjectTypeEXT objectType, ulong @object, UIntPtr location, int messageCode, byte* pLayerPrefix, byte* pMessage)
	{
		((delegate* unmanaged[Stdcall]<VkInstance, VkDebugReportFlagsEXT, VkDebugReportObjectTypeEXT, ulong, UIntPtr, int, byte*, byte*, void>)vkDebugReportMessageEXT_ptr)(instance, flags, objectType, @object, location, messageCode, pLayerPrefix, pMessage);
	}

	public unsafe static void vkDebugReportMessageEXT(VkInstance instance, VkDebugReportFlagsEXT flags, VkDebugReportObjectTypeEXT objectType, ulong @object, UIntPtr location, int messageCode, byte* pLayerPrefix, string pMessage)
	{
		StringHandle stringHandle = BindingsHelpers.StringToHGlobalUtf8(pMessage);
		((delegate* unmanaged[Stdcall]<VkInstance, VkDebugReportFlagsEXT, VkDebugReportObjectTypeEXT, ulong, UIntPtr, int, byte*, StringHandle, void>)vkDebugReportMessageEXT_ptr)(instance, flags, objectType, @object, location, messageCode, pLayerPrefix, stringHandle);
		BindingsHelpers.FreeHGlobal(stringHandle);
	}

	public unsafe static void vkDebugReportMessageEXT(VkInstance instance, VkDebugReportFlagsEXT flags, VkDebugReportObjectTypeEXT objectType, ulong @object, UIntPtr location, int messageCode, string pLayerPrefix, byte* pMessage)
	{
		StringHandle stringHandle = BindingsHelpers.StringToHGlobalUtf8(pLayerPrefix);
		((delegate* unmanaged[Stdcall]<VkInstance, VkDebugReportFlagsEXT, VkDebugReportObjectTypeEXT, ulong, UIntPtr, int, StringHandle, byte*, void>)vkDebugReportMessageEXT_ptr)(instance, flags, objectType, @object, location, messageCode, stringHandle, pMessage);
		BindingsHelpers.FreeHGlobal(stringHandle);
	}

	public unsafe static void vkDebugReportMessageEXT(VkInstance instance, VkDebugReportFlagsEXT flags, VkDebugReportObjectTypeEXT objectType, ulong @object, UIntPtr location, int messageCode, string pLayerPrefix, string pMessage)
	{
		StringHandle stringHandle = BindingsHelpers.StringToHGlobalUtf8(pLayerPrefix);
		StringHandle stringHandle2 = BindingsHelpers.StringToHGlobalUtf8(pMessage);
		((delegate* unmanaged[Stdcall]<VkInstance, VkDebugReportFlagsEXT, VkDebugReportObjectTypeEXT, ulong, UIntPtr, int, StringHandle, StringHandle, void>)vkDebugReportMessageEXT_ptr)(instance, flags, objectType, @object, location, messageCode, stringHandle, stringHandle2);
		BindingsHelpers.FreeHGlobal(stringHandle);
		BindingsHelpers.FreeHGlobal(stringHandle2);
	}

	public unsafe static void vkDestroyBuffer(VkDevice device, VkBuffer buffer, VkAllocationCallbacks* pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkBuffer, VkAllocationCallbacks*, void>)vkDestroyBuffer_ptr)(device, buffer, pAllocator);
	}

	public unsafe static void vkDestroyBuffer(VkDevice device, VkBuffer buffer, ref VkAllocationCallbacks pAllocator)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkBuffer, VkAllocationCallbacks*, void>)vkDestroyBuffer_ptr)(device, buffer, ptr);
		}
	}

	public unsafe static void vkDestroyBuffer(VkDevice device, VkBuffer buffer, IntPtr pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkBuffer, IntPtr, void>)vkDestroyBuffer_ptr)(device, buffer, pAllocator);
	}

	public unsafe static void vkDestroyBufferView(VkDevice device, VkBufferView bufferView, VkAllocationCallbacks* pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkBufferView, VkAllocationCallbacks*, void>)vkDestroyBufferView_ptr)(device, bufferView, pAllocator);
	}

	public unsafe static void vkDestroyBufferView(VkDevice device, VkBufferView bufferView, ref VkAllocationCallbacks pAllocator)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkBufferView, VkAllocationCallbacks*, void>)vkDestroyBufferView_ptr)(device, bufferView, ptr);
		}
	}

	public unsafe static void vkDestroyBufferView(VkDevice device, VkBufferView bufferView, IntPtr pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkBufferView, IntPtr, void>)vkDestroyBufferView_ptr)(device, bufferView, pAllocator);
	}

	public unsafe static void vkDestroyCommandPool(VkDevice device, VkCommandPool commandPool, VkAllocationCallbacks* pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkCommandPool, VkAllocationCallbacks*, void>)vkDestroyCommandPool_ptr)(device, commandPool, pAllocator);
	}

	public unsafe static void vkDestroyCommandPool(VkDevice device, VkCommandPool commandPool, ref VkAllocationCallbacks pAllocator)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkCommandPool, VkAllocationCallbacks*, void>)vkDestroyCommandPool_ptr)(device, commandPool, ptr);
		}
	}

	public unsafe static void vkDestroyCommandPool(VkDevice device, VkCommandPool commandPool, IntPtr pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkCommandPool, IntPtr, void>)vkDestroyCommandPool_ptr)(device, commandPool, pAllocator);
	}

	public unsafe static void vkDestroyDebugReportCallbackEXT(VkInstance instance, VkDebugReportCallbackEXT callback, VkAllocationCallbacks* pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkInstance, VkDebugReportCallbackEXT, VkAllocationCallbacks*, void>)vkDestroyDebugReportCallbackEXT_ptr)(instance, callback, pAllocator);
	}

	public unsafe static void vkDestroyDebugReportCallbackEXT(VkInstance instance, VkDebugReportCallbackEXT callback, ref VkAllocationCallbacks pAllocator)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			((delegate* unmanaged[Stdcall]<VkInstance, VkDebugReportCallbackEXT, VkAllocationCallbacks*, void>)vkDestroyDebugReportCallbackEXT_ptr)(instance, callback, ptr);
		}
	}

	public unsafe static void vkDestroyDebugReportCallbackEXT(VkInstance instance, VkDebugReportCallbackEXT callback, IntPtr pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkInstance, VkDebugReportCallbackEXT, IntPtr, void>)vkDestroyDebugReportCallbackEXT_ptr)(instance, callback, pAllocator);
	}

	public unsafe static void vkDestroyDescriptorPool(VkDevice device, VkDescriptorPool descriptorPool, VkAllocationCallbacks* pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorPool, VkAllocationCallbacks*, void>)vkDestroyDescriptorPool_ptr)(device, descriptorPool, pAllocator);
	}

	public unsafe static void vkDestroyDescriptorPool(VkDevice device, VkDescriptorPool descriptorPool, ref VkAllocationCallbacks pAllocator)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorPool, VkAllocationCallbacks*, void>)vkDestroyDescriptorPool_ptr)(device, descriptorPool, ptr);
		}
	}

	public unsafe static void vkDestroyDescriptorPool(VkDevice device, VkDescriptorPool descriptorPool, IntPtr pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorPool, IntPtr, void>)vkDestroyDescriptorPool_ptr)(device, descriptorPool, pAllocator);
	}

	public unsafe static void vkDestroyDescriptorSetLayout(VkDevice device, VkDescriptorSetLayout descriptorSetLayout, VkAllocationCallbacks* pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorSetLayout, VkAllocationCallbacks*, void>)vkDestroyDescriptorSetLayout_ptr)(device, descriptorSetLayout, pAllocator);
	}

	public unsafe static void vkDestroyDescriptorSetLayout(VkDevice device, VkDescriptorSetLayout descriptorSetLayout, ref VkAllocationCallbacks pAllocator)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorSetLayout, VkAllocationCallbacks*, void>)vkDestroyDescriptorSetLayout_ptr)(device, descriptorSetLayout, ptr);
		}
	}

	public unsafe static void vkDestroyDescriptorSetLayout(VkDevice device, VkDescriptorSetLayout descriptorSetLayout, IntPtr pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorSetLayout, IntPtr, void>)vkDestroyDescriptorSetLayout_ptr)(device, descriptorSetLayout, pAllocator);
	}

	public unsafe static void vkDestroyDescriptorUpdateTemplateKHR(VkDevice device, VkDescriptorUpdateTemplateKHR descriptorUpdateTemplate, VkAllocationCallbacks* pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorUpdateTemplateKHR, VkAllocationCallbacks*, void>)vkDestroyDescriptorUpdateTemplateKHR_ptr)(device, descriptorUpdateTemplate, pAllocator);
	}

	public unsafe static void vkDestroyDescriptorUpdateTemplateKHR(VkDevice device, VkDescriptorUpdateTemplateKHR descriptorUpdateTemplate, ref VkAllocationCallbacks pAllocator)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorUpdateTemplateKHR, VkAllocationCallbacks*, void>)vkDestroyDescriptorUpdateTemplateKHR_ptr)(device, descriptorUpdateTemplate, ptr);
		}
	}

	public unsafe static void vkDestroyDescriptorUpdateTemplateKHR(VkDevice device, VkDescriptorUpdateTemplateKHR descriptorUpdateTemplate, IntPtr pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorUpdateTemplateKHR, IntPtr, void>)vkDestroyDescriptorUpdateTemplateKHR_ptr)(device, descriptorUpdateTemplate, pAllocator);
	}

	public unsafe static void vkDestroyDevice(VkDevice device, VkAllocationCallbacks* pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkAllocationCallbacks*, void>)vkDestroyDevice_ptr)(device, pAllocator);
	}

	public unsafe static void vkDestroyDevice(VkDevice device, ref VkAllocationCallbacks pAllocator)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkAllocationCallbacks*, void>)vkDestroyDevice_ptr)(device, ptr);
		}
	}

	public unsafe static void vkDestroyDevice(VkDevice device, IntPtr pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, void>)vkDestroyDevice_ptr)(device, pAllocator);
	}

	public unsafe static void vkDestroyEvent(VkDevice device, VkEvent @event, VkAllocationCallbacks* pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkEvent, VkAllocationCallbacks*, void>)vkDestroyEvent_ptr)(device, @event, pAllocator);
	}

	public unsafe static void vkDestroyEvent(VkDevice device, VkEvent @event, ref VkAllocationCallbacks pAllocator)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkEvent, VkAllocationCallbacks*, void>)vkDestroyEvent_ptr)(device, @event, ptr);
		}
	}

	public unsafe static void vkDestroyEvent(VkDevice device, VkEvent @event, IntPtr pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkEvent, IntPtr, void>)vkDestroyEvent_ptr)(device, @event, pAllocator);
	}

	public unsafe static void vkDestroyFence(VkDevice device, VkFence fence, VkAllocationCallbacks* pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkFence, VkAllocationCallbacks*, void>)vkDestroyFence_ptr)(device, fence, pAllocator);
	}

	public unsafe static void vkDestroyFence(VkDevice device, VkFence fence, ref VkAllocationCallbacks pAllocator)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkFence, VkAllocationCallbacks*, void>)vkDestroyFence_ptr)(device, fence, ptr);
		}
	}

	public unsafe static void vkDestroyFence(VkDevice device, VkFence fence, IntPtr pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkFence, IntPtr, void>)vkDestroyFence_ptr)(device, fence, pAllocator);
	}

	public unsafe static void vkDestroyFramebuffer(VkDevice device, VkFramebuffer framebuffer, VkAllocationCallbacks* pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkFramebuffer, VkAllocationCallbacks*, void>)vkDestroyFramebuffer_ptr)(device, framebuffer, pAllocator);
	}

	public unsafe static void vkDestroyFramebuffer(VkDevice device, VkFramebuffer framebuffer, ref VkAllocationCallbacks pAllocator)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkFramebuffer, VkAllocationCallbacks*, void>)vkDestroyFramebuffer_ptr)(device, framebuffer, ptr);
		}
	}

	public unsafe static void vkDestroyFramebuffer(VkDevice device, VkFramebuffer framebuffer, IntPtr pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkFramebuffer, IntPtr, void>)vkDestroyFramebuffer_ptr)(device, framebuffer, pAllocator);
	}

	public unsafe static void vkDestroyImage(VkDevice device, VkImage image, VkAllocationCallbacks* pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkImage, VkAllocationCallbacks*, void>)vkDestroyImage_ptr)(device, image, pAllocator);
	}

	public unsafe static void vkDestroyImage(VkDevice device, VkImage image, ref VkAllocationCallbacks pAllocator)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkImage, VkAllocationCallbacks*, void>)vkDestroyImage_ptr)(device, image, ptr);
		}
	}

	public unsafe static void vkDestroyImage(VkDevice device, VkImage image, IntPtr pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkImage, IntPtr, void>)vkDestroyImage_ptr)(device, image, pAllocator);
	}

	public unsafe static void vkDestroyImageView(VkDevice device, VkImageView imageView, VkAllocationCallbacks* pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkImageView, VkAllocationCallbacks*, void>)vkDestroyImageView_ptr)(device, imageView, pAllocator);
	}

	public unsafe static void vkDestroyImageView(VkDevice device, VkImageView imageView, ref VkAllocationCallbacks pAllocator)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkImageView, VkAllocationCallbacks*, void>)vkDestroyImageView_ptr)(device, imageView, ptr);
		}
	}

	public unsafe static void vkDestroyImageView(VkDevice device, VkImageView imageView, IntPtr pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkImageView, IntPtr, void>)vkDestroyImageView_ptr)(device, imageView, pAllocator);
	}

	public unsafe static void vkDestroyIndirectCommandsLayoutNVX(VkDevice device, VkIndirectCommandsLayoutNVX indirectCommandsLayout, VkAllocationCallbacks* pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkIndirectCommandsLayoutNVX, VkAllocationCallbacks*, void>)vkDestroyIndirectCommandsLayoutNVX_ptr)(device, indirectCommandsLayout, pAllocator);
	}

	public unsafe static void vkDestroyIndirectCommandsLayoutNVX(VkDevice device, VkIndirectCommandsLayoutNVX indirectCommandsLayout, ref VkAllocationCallbacks pAllocator)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkIndirectCommandsLayoutNVX, VkAllocationCallbacks*, void>)vkDestroyIndirectCommandsLayoutNVX_ptr)(device, indirectCommandsLayout, ptr);
		}
	}

	public unsafe static void vkDestroyIndirectCommandsLayoutNVX(VkDevice device, VkIndirectCommandsLayoutNVX indirectCommandsLayout, IntPtr pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkIndirectCommandsLayoutNVX, IntPtr, void>)vkDestroyIndirectCommandsLayoutNVX_ptr)(device, indirectCommandsLayout, pAllocator);
	}

	public unsafe static void vkDestroyInstance(VkInstance instance, VkAllocationCallbacks* pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkInstance, VkAllocationCallbacks*, void>)vkDestroyInstance_ptr)(instance, pAllocator);
	}

	public unsafe static void vkDestroyInstance(VkInstance instance, ref VkAllocationCallbacks pAllocator)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			((delegate* unmanaged[Stdcall]<VkInstance, VkAllocationCallbacks*, void>)vkDestroyInstance_ptr)(instance, ptr);
		}
	}

	public unsafe static void vkDestroyInstance(VkInstance instance, IntPtr pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, void>)vkDestroyInstance_ptr)(instance, pAllocator);
	}

	public unsafe static void vkDestroyObjectTableNVX(VkDevice device, VkObjectTableNVX objectTable, VkAllocationCallbacks* pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkObjectTableNVX, VkAllocationCallbacks*, void>)vkDestroyObjectTableNVX_ptr)(device, objectTable, pAllocator);
	}

	public unsafe static void vkDestroyObjectTableNVX(VkDevice device, VkObjectTableNVX objectTable, ref VkAllocationCallbacks pAllocator)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkObjectTableNVX, VkAllocationCallbacks*, void>)vkDestroyObjectTableNVX_ptr)(device, objectTable, ptr);
		}
	}

	public unsafe static void vkDestroyObjectTableNVX(VkDevice device, VkObjectTableNVX objectTable, IntPtr pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkObjectTableNVX, IntPtr, void>)vkDestroyObjectTableNVX_ptr)(device, objectTable, pAllocator);
	}

	public unsafe static void vkDestroyPipeline(VkDevice device, VkPipeline pipeline, VkAllocationCallbacks* pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkPipeline, VkAllocationCallbacks*, void>)vkDestroyPipeline_ptr)(device, pipeline, pAllocator);
	}

	public unsafe static void vkDestroyPipeline(VkDevice device, VkPipeline pipeline, ref VkAllocationCallbacks pAllocator)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkPipeline, VkAllocationCallbacks*, void>)vkDestroyPipeline_ptr)(device, pipeline, ptr);
		}
	}

	public unsafe static void vkDestroyPipeline(VkDevice device, VkPipeline pipeline, IntPtr pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkPipeline, IntPtr, void>)vkDestroyPipeline_ptr)(device, pipeline, pAllocator);
	}

	public unsafe static void vkDestroyPipelineCache(VkDevice device, VkPipelineCache pipelineCache, VkAllocationCallbacks* pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, VkAllocationCallbacks*, void>)vkDestroyPipelineCache_ptr)(device, pipelineCache, pAllocator);
	}

	public unsafe static void vkDestroyPipelineCache(VkDevice device, VkPipelineCache pipelineCache, ref VkAllocationCallbacks pAllocator)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, VkAllocationCallbacks*, void>)vkDestroyPipelineCache_ptr)(device, pipelineCache, ptr);
		}
	}

	public unsafe static void vkDestroyPipelineCache(VkDevice device, VkPipelineCache pipelineCache, IntPtr pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, IntPtr, void>)vkDestroyPipelineCache_ptr)(device, pipelineCache, pAllocator);
	}

	public unsafe static void vkDestroyPipelineLayout(VkDevice device, VkPipelineLayout pipelineLayout, VkAllocationCallbacks* pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineLayout, VkAllocationCallbacks*, void>)vkDestroyPipelineLayout_ptr)(device, pipelineLayout, pAllocator);
	}

	public unsafe static void vkDestroyPipelineLayout(VkDevice device, VkPipelineLayout pipelineLayout, ref VkAllocationCallbacks pAllocator)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineLayout, VkAllocationCallbacks*, void>)vkDestroyPipelineLayout_ptr)(device, pipelineLayout, ptr);
		}
	}

	public unsafe static void vkDestroyPipelineLayout(VkDevice device, VkPipelineLayout pipelineLayout, IntPtr pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineLayout, IntPtr, void>)vkDestroyPipelineLayout_ptr)(device, pipelineLayout, pAllocator);
	}

	public unsafe static void vkDestroyQueryPool(VkDevice device, VkQueryPool queryPool, VkAllocationCallbacks* pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkQueryPool, VkAllocationCallbacks*, void>)vkDestroyQueryPool_ptr)(device, queryPool, pAllocator);
	}

	public unsafe static void vkDestroyQueryPool(VkDevice device, VkQueryPool queryPool, ref VkAllocationCallbacks pAllocator)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkQueryPool, VkAllocationCallbacks*, void>)vkDestroyQueryPool_ptr)(device, queryPool, ptr);
		}
	}

	public unsafe static void vkDestroyQueryPool(VkDevice device, VkQueryPool queryPool, IntPtr pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkQueryPool, IntPtr, void>)vkDestroyQueryPool_ptr)(device, queryPool, pAllocator);
	}

	public unsafe static void vkDestroyRenderPass(VkDevice device, VkRenderPass renderPass, VkAllocationCallbacks* pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkRenderPass, VkAllocationCallbacks*, void>)vkDestroyRenderPass_ptr)(device, renderPass, pAllocator);
	}

	public unsafe static void vkDestroyRenderPass(VkDevice device, VkRenderPass renderPass, ref VkAllocationCallbacks pAllocator)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkRenderPass, VkAllocationCallbacks*, void>)vkDestroyRenderPass_ptr)(device, renderPass, ptr);
		}
	}

	public unsafe static void vkDestroyRenderPass(VkDevice device, VkRenderPass renderPass, IntPtr pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkRenderPass, IntPtr, void>)vkDestroyRenderPass_ptr)(device, renderPass, pAllocator);
	}

	public unsafe static void vkDestroySampler(VkDevice device, VkSampler sampler, VkAllocationCallbacks* pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkSampler, VkAllocationCallbacks*, void>)vkDestroySampler_ptr)(device, sampler, pAllocator);
	}

	public unsafe static void vkDestroySampler(VkDevice device, VkSampler sampler, ref VkAllocationCallbacks pAllocator)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkSampler, VkAllocationCallbacks*, void>)vkDestroySampler_ptr)(device, sampler, ptr);
		}
	}

	public unsafe static void vkDestroySampler(VkDevice device, VkSampler sampler, IntPtr pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkSampler, IntPtr, void>)vkDestroySampler_ptr)(device, sampler, pAllocator);
	}

	public unsafe static void vkDestroySamplerYcbcrConversionKHR(VkDevice device, VkSamplerYcbcrConversionKHR ycbcrConversion, VkAllocationCallbacks* pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkSamplerYcbcrConversionKHR, VkAllocationCallbacks*, void>)vkDestroySamplerYcbcrConversionKHR_ptr)(device, ycbcrConversion, pAllocator);
	}

	public unsafe static void vkDestroySamplerYcbcrConversionKHR(VkDevice device, VkSamplerYcbcrConversionKHR ycbcrConversion, ref VkAllocationCallbacks pAllocator)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkSamplerYcbcrConversionKHR, VkAllocationCallbacks*, void>)vkDestroySamplerYcbcrConversionKHR_ptr)(device, ycbcrConversion, ptr);
		}
	}

	public unsafe static void vkDestroySamplerYcbcrConversionKHR(VkDevice device, VkSamplerYcbcrConversionKHR ycbcrConversion, IntPtr pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkSamplerYcbcrConversionKHR, IntPtr, void>)vkDestroySamplerYcbcrConversionKHR_ptr)(device, ycbcrConversion, pAllocator);
	}

	public unsafe static void vkDestroySemaphore(VkDevice device, VkSemaphore semaphore, VkAllocationCallbacks* pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkSemaphore, VkAllocationCallbacks*, void>)vkDestroySemaphore_ptr)(device, semaphore, pAllocator);
	}

	public unsafe static void vkDestroySemaphore(VkDevice device, VkSemaphore semaphore, ref VkAllocationCallbacks pAllocator)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkSemaphore, VkAllocationCallbacks*, void>)vkDestroySemaphore_ptr)(device, semaphore, ptr);
		}
	}

	public unsafe static void vkDestroySemaphore(VkDevice device, VkSemaphore semaphore, IntPtr pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkSemaphore, IntPtr, void>)vkDestroySemaphore_ptr)(device, semaphore, pAllocator);
	}

	public unsafe static void vkDestroyShaderModule(VkDevice device, VkShaderModule shaderModule, VkAllocationCallbacks* pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkShaderModule, VkAllocationCallbacks*, void>)vkDestroyShaderModule_ptr)(device, shaderModule, pAllocator);
	}

	public unsafe static void vkDestroyShaderModule(VkDevice device, VkShaderModule shaderModule, ref VkAllocationCallbacks pAllocator)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkShaderModule, VkAllocationCallbacks*, void>)vkDestroyShaderModule_ptr)(device, shaderModule, ptr);
		}
	}

	public unsafe static void vkDestroyShaderModule(VkDevice device, VkShaderModule shaderModule, IntPtr pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkShaderModule, IntPtr, void>)vkDestroyShaderModule_ptr)(device, shaderModule, pAllocator);
	}

	public unsafe static void vkDestroySurfaceKHR(VkInstance instance, VkSurfaceKHR surface, VkAllocationCallbacks* pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkInstance, VkSurfaceKHR, VkAllocationCallbacks*, void>)vkDestroySurfaceKHR_ptr)(instance, surface, pAllocator);
	}

	public unsafe static void vkDestroySurfaceKHR(VkInstance instance, VkSurfaceKHR surface, ref VkAllocationCallbacks pAllocator)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			((delegate* unmanaged[Stdcall]<VkInstance, VkSurfaceKHR, VkAllocationCallbacks*, void>)vkDestroySurfaceKHR_ptr)(instance, surface, ptr);
		}
	}

	public unsafe static void vkDestroySurfaceKHR(VkInstance instance, VkSurfaceKHR surface, IntPtr pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkInstance, VkSurfaceKHR, IntPtr, void>)vkDestroySurfaceKHR_ptr)(instance, surface, pAllocator);
	}

	public unsafe static void vkDestroySwapchainKHR(VkDevice device, VkSwapchainKHR swapchain, VkAllocationCallbacks* pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkSwapchainKHR, VkAllocationCallbacks*, void>)vkDestroySwapchainKHR_ptr)(device, swapchain, pAllocator);
	}

	public unsafe static void vkDestroySwapchainKHR(VkDevice device, VkSwapchainKHR swapchain, ref VkAllocationCallbacks pAllocator)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkSwapchainKHR, VkAllocationCallbacks*, void>)vkDestroySwapchainKHR_ptr)(device, swapchain, ptr);
		}
	}

	public unsafe static void vkDestroySwapchainKHR(VkDevice device, VkSwapchainKHR swapchain, IntPtr pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkSwapchainKHR, IntPtr, void>)vkDestroySwapchainKHR_ptr)(device, swapchain, pAllocator);
	}

	public unsafe static void vkDestroyValidationCacheEXT(VkDevice device, VkValidationCacheEXT validationCache, VkAllocationCallbacks* pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkValidationCacheEXT, VkAllocationCallbacks*, void>)vkDestroyValidationCacheEXT_ptr)(device, validationCache, pAllocator);
	}

	public unsafe static void vkDestroyValidationCacheEXT(VkDevice device, VkValidationCacheEXT validationCache, ref VkAllocationCallbacks pAllocator)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkValidationCacheEXT, VkAllocationCallbacks*, void>)vkDestroyValidationCacheEXT_ptr)(device, validationCache, ptr);
		}
	}

	public unsafe static void vkDestroyValidationCacheEXT(VkDevice device, VkValidationCacheEXT validationCache, IntPtr pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkValidationCacheEXT, IntPtr, void>)vkDestroyValidationCacheEXT_ptr)(device, validationCache, pAllocator);
	}

	public unsafe static VkResult vkDeviceWaitIdle(VkDevice device)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkResult>)vkDeviceWaitIdle_ptr)(device);
	}

	public unsafe static VkResult vkDisplayPowerControlEXT(VkDevice device, VkDisplayKHR display, VkDisplayPowerInfoEXT* pDisplayPowerInfo)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkDisplayKHR, VkDisplayPowerInfoEXT*, VkResult>)vkDisplayPowerControlEXT_ptr)(device, display, pDisplayPowerInfo);
	}

	public unsafe static VkResult vkDisplayPowerControlEXT(VkDevice device, VkDisplayKHR display, ref VkDisplayPowerInfoEXT pDisplayPowerInfo)
	{
		fixed (VkDisplayPowerInfoEXT* ptr = &pDisplayPowerInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDisplayKHR, VkDisplayPowerInfoEXT*, VkResult>)vkDisplayPowerControlEXT_ptr)(device, display, ptr);
		}
	}

	public unsafe static VkResult vkDisplayPowerControlEXT(VkDevice device, VkDisplayKHR display, IntPtr pDisplayPowerInfo)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkDisplayKHR, IntPtr, VkResult>)vkDisplayPowerControlEXT_ptr)(device, display, pDisplayPowerInfo);
	}

	public unsafe static VkResult vkEndCommandBuffer(VkCommandBuffer commandBuffer)
	{
		return ((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkResult>)vkEndCommandBuffer_ptr)(commandBuffer);
	}

	public unsafe static VkResult vkEnumerateDeviceExtensionProperties(VkPhysicalDevice physicalDevice, byte* pLayerName, uint* pPropertyCount, VkExtensionProperties* pProperties)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, byte*, uint*, VkExtensionProperties*, VkResult>)vkEnumerateDeviceExtensionProperties_ptr)(physicalDevice, pLayerName, pPropertyCount, pProperties);
	}

	public unsafe static VkResult vkEnumerateDeviceExtensionProperties(VkPhysicalDevice physicalDevice, byte* pLayerName, uint* pPropertyCount, ref VkExtensionProperties pProperties)
	{
		fixed (VkExtensionProperties* ptr = &pProperties)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, byte*, uint*, VkExtensionProperties*, VkResult>)vkEnumerateDeviceExtensionProperties_ptr)(physicalDevice, pLayerName, pPropertyCount, ptr);
		}
	}

	public unsafe static VkResult vkEnumerateDeviceExtensionProperties(VkPhysicalDevice physicalDevice, byte* pLayerName, uint* pPropertyCount, IntPtr pProperties)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, byte*, uint*, IntPtr, VkResult>)vkEnumerateDeviceExtensionProperties_ptr)(physicalDevice, pLayerName, pPropertyCount, pProperties);
	}

	public unsafe static VkResult vkEnumerateDeviceExtensionProperties(VkPhysicalDevice physicalDevice, byte* pLayerName, ref uint pPropertyCount, VkExtensionProperties* pProperties)
	{
		fixed (uint* ptr = &pPropertyCount)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, byte*, uint*, VkExtensionProperties*, VkResult>)vkEnumerateDeviceExtensionProperties_ptr)(physicalDevice, pLayerName, ptr, pProperties);
		}
	}

	public unsafe static VkResult vkEnumerateDeviceExtensionProperties(VkPhysicalDevice physicalDevice, byte* pLayerName, ref uint pPropertyCount, ref VkExtensionProperties pProperties)
	{
		fixed (uint* ptr = &pPropertyCount)
		{
			fixed (VkExtensionProperties* ptr2 = &pProperties)
			{
				return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, byte*, uint*, VkExtensionProperties*, VkResult>)vkEnumerateDeviceExtensionProperties_ptr)(physicalDevice, pLayerName, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkEnumerateDeviceExtensionProperties(VkPhysicalDevice physicalDevice, byte* pLayerName, ref uint pPropertyCount, IntPtr pProperties)
	{
		fixed (uint* ptr = &pPropertyCount)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, byte*, uint*, IntPtr, VkResult>)vkEnumerateDeviceExtensionProperties_ptr)(physicalDevice, pLayerName, ptr, pProperties);
		}
	}

	public unsafe static VkResult vkEnumerateDeviceExtensionProperties(VkPhysicalDevice physicalDevice, byte* pLayerName, IntPtr pPropertyCount, VkExtensionProperties* pProperties)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, byte*, IntPtr, VkExtensionProperties*, VkResult>)vkEnumerateDeviceExtensionProperties_ptr)(physicalDevice, pLayerName, pPropertyCount, pProperties);
	}

	public unsafe static VkResult vkEnumerateDeviceExtensionProperties(VkPhysicalDevice physicalDevice, byte* pLayerName, IntPtr pPropertyCount, ref VkExtensionProperties pProperties)
	{
		fixed (VkExtensionProperties* ptr = &pProperties)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, byte*, IntPtr, VkExtensionProperties*, VkResult>)vkEnumerateDeviceExtensionProperties_ptr)(physicalDevice, pLayerName, pPropertyCount, ptr);
		}
	}

	public unsafe static VkResult vkEnumerateDeviceExtensionProperties(VkPhysicalDevice physicalDevice, byte* pLayerName, IntPtr pPropertyCount, IntPtr pProperties)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, byte*, IntPtr, IntPtr, VkResult>)vkEnumerateDeviceExtensionProperties_ptr)(physicalDevice, pLayerName, pPropertyCount, pProperties);
	}

	public unsafe static VkResult vkEnumerateDeviceExtensionProperties(VkPhysicalDevice physicalDevice, string pLayerName, uint* pPropertyCount, VkExtensionProperties* pProperties)
	{
		StringHandle stringHandle = BindingsHelpers.StringToHGlobalUtf8(pLayerName);
		VkResult result = ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, StringHandle, uint*, VkExtensionProperties*, VkResult>)vkEnumerateDeviceExtensionProperties_ptr)(physicalDevice, stringHandle, pPropertyCount, pProperties);
		BindingsHelpers.FreeHGlobal(stringHandle);
		return result;
	}

	public unsafe static VkResult vkEnumerateDeviceExtensionProperties(VkPhysicalDevice physicalDevice, string pLayerName, uint* pPropertyCount, ref VkExtensionProperties pProperties)
	{
		StringHandle stringHandle = BindingsHelpers.StringToHGlobalUtf8(pLayerName);
		fixed (VkExtensionProperties* ptr = &pProperties)
		{
			VkResult result = ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, StringHandle, uint*, VkExtensionProperties*, VkResult>)vkEnumerateDeviceExtensionProperties_ptr)(physicalDevice, stringHandle, pPropertyCount, ptr);
			BindingsHelpers.FreeHGlobal(stringHandle);
			return result;
		}
	}

	public unsafe static VkResult vkEnumerateDeviceExtensionProperties(VkPhysicalDevice physicalDevice, string pLayerName, uint* pPropertyCount, IntPtr pProperties)
	{
		StringHandle stringHandle = BindingsHelpers.StringToHGlobalUtf8(pLayerName);
		VkResult result = ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, StringHandle, uint*, IntPtr, VkResult>)vkEnumerateDeviceExtensionProperties_ptr)(physicalDevice, stringHandle, pPropertyCount, pProperties);
		BindingsHelpers.FreeHGlobal(stringHandle);
		return result;
	}

	public unsafe static VkResult vkEnumerateDeviceExtensionProperties(VkPhysicalDevice physicalDevice, string pLayerName, ref uint pPropertyCount, VkExtensionProperties* pProperties)
	{
		StringHandle stringHandle = BindingsHelpers.StringToHGlobalUtf8(pLayerName);
		fixed (uint* ptr = &pPropertyCount)
		{
			VkResult result = ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, StringHandle, uint*, VkExtensionProperties*, VkResult>)vkEnumerateDeviceExtensionProperties_ptr)(physicalDevice, stringHandle, ptr, pProperties);
			BindingsHelpers.FreeHGlobal(stringHandle);
			return result;
		}
	}

	public unsafe static VkResult vkEnumerateDeviceExtensionProperties(VkPhysicalDevice physicalDevice, string pLayerName, ref uint pPropertyCount, ref VkExtensionProperties pProperties)
	{
		StringHandle stringHandle = BindingsHelpers.StringToHGlobalUtf8(pLayerName);
		fixed (uint* ptr = &pPropertyCount)
		{
			fixed (VkExtensionProperties* ptr2 = &pProperties)
			{
				VkResult result = ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, StringHandle, uint*, VkExtensionProperties*, VkResult>)vkEnumerateDeviceExtensionProperties_ptr)(physicalDevice, stringHandle, ptr, ptr2);
				BindingsHelpers.FreeHGlobal(stringHandle);
				return result;
			}
		}
	}

	public unsafe static VkResult vkEnumerateDeviceExtensionProperties(VkPhysicalDevice physicalDevice, string pLayerName, ref uint pPropertyCount, IntPtr pProperties)
	{
		StringHandle stringHandle = BindingsHelpers.StringToHGlobalUtf8(pLayerName);
		fixed (uint* ptr = &pPropertyCount)
		{
			VkResult result = ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, StringHandle, uint*, IntPtr, VkResult>)vkEnumerateDeviceExtensionProperties_ptr)(physicalDevice, stringHandle, ptr, pProperties);
			BindingsHelpers.FreeHGlobal(stringHandle);
			return result;
		}
	}

	public unsafe static VkResult vkEnumerateDeviceExtensionProperties(VkPhysicalDevice physicalDevice, string pLayerName, IntPtr pPropertyCount, VkExtensionProperties* pProperties)
	{
		StringHandle stringHandle = BindingsHelpers.StringToHGlobalUtf8(pLayerName);
		VkResult result = ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, StringHandle, IntPtr, VkExtensionProperties*, VkResult>)vkEnumerateDeviceExtensionProperties_ptr)(physicalDevice, stringHandle, pPropertyCount, pProperties);
		BindingsHelpers.FreeHGlobal(stringHandle);
		return result;
	}

	public unsafe static VkResult vkEnumerateDeviceExtensionProperties(VkPhysicalDevice physicalDevice, string pLayerName, IntPtr pPropertyCount, ref VkExtensionProperties pProperties)
	{
		StringHandle stringHandle = BindingsHelpers.StringToHGlobalUtf8(pLayerName);
		fixed (VkExtensionProperties* ptr = &pProperties)
		{
			VkResult result = ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, StringHandle, IntPtr, VkExtensionProperties*, VkResult>)vkEnumerateDeviceExtensionProperties_ptr)(physicalDevice, stringHandle, pPropertyCount, ptr);
			BindingsHelpers.FreeHGlobal(stringHandle);
			return result;
		}
	}

	public unsafe static VkResult vkEnumerateDeviceExtensionProperties(VkPhysicalDevice physicalDevice, string pLayerName, IntPtr pPropertyCount, IntPtr pProperties)
	{
		StringHandle stringHandle = BindingsHelpers.StringToHGlobalUtf8(pLayerName);
		VkResult result = ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, StringHandle, IntPtr, IntPtr, VkResult>)vkEnumerateDeviceExtensionProperties_ptr)(physicalDevice, stringHandle, pPropertyCount, pProperties);
		BindingsHelpers.FreeHGlobal(stringHandle);
		return result;
	}

	public unsafe static VkResult vkEnumerateDeviceLayerProperties(VkPhysicalDevice physicalDevice, uint* pPropertyCount, VkLayerProperties* pProperties)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint*, VkLayerProperties*, VkResult>)vkEnumerateDeviceLayerProperties_ptr)(physicalDevice, pPropertyCount, pProperties);
	}

	public unsafe static VkResult vkEnumerateDeviceLayerProperties(VkPhysicalDevice physicalDevice, uint* pPropertyCount, ref VkLayerProperties pProperties)
	{
		fixed (VkLayerProperties* ptr = &pProperties)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint*, VkLayerProperties*, VkResult>)vkEnumerateDeviceLayerProperties_ptr)(physicalDevice, pPropertyCount, ptr);
		}
	}

	public unsafe static VkResult vkEnumerateDeviceLayerProperties(VkPhysicalDevice physicalDevice, uint* pPropertyCount, IntPtr pProperties)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint*, IntPtr, VkResult>)vkEnumerateDeviceLayerProperties_ptr)(physicalDevice, pPropertyCount, pProperties);
	}

	public unsafe static VkResult vkEnumerateDeviceLayerProperties(VkPhysicalDevice physicalDevice, ref uint pPropertyCount, VkLayerProperties* pProperties)
	{
		fixed (uint* ptr = &pPropertyCount)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint*, VkLayerProperties*, VkResult>)vkEnumerateDeviceLayerProperties_ptr)(physicalDevice, ptr, pProperties);
		}
	}

	public unsafe static VkResult vkEnumerateDeviceLayerProperties(VkPhysicalDevice physicalDevice, ref uint pPropertyCount, ref VkLayerProperties pProperties)
	{
		fixed (uint* ptr = &pPropertyCount)
		{
			fixed (VkLayerProperties* ptr2 = &pProperties)
			{
				return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint*, VkLayerProperties*, VkResult>)vkEnumerateDeviceLayerProperties_ptr)(physicalDevice, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkEnumerateDeviceLayerProperties(VkPhysicalDevice physicalDevice, ref uint pPropertyCount, IntPtr pProperties)
	{
		fixed (uint* ptr = &pPropertyCount)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint*, IntPtr, VkResult>)vkEnumerateDeviceLayerProperties_ptr)(physicalDevice, ptr, pProperties);
		}
	}

	public unsafe static VkResult vkEnumerateDeviceLayerProperties(VkPhysicalDevice physicalDevice, IntPtr pPropertyCount, VkLayerProperties* pProperties)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, VkLayerProperties*, VkResult>)vkEnumerateDeviceLayerProperties_ptr)(physicalDevice, pPropertyCount, pProperties);
	}

	public unsafe static VkResult vkEnumerateDeviceLayerProperties(VkPhysicalDevice physicalDevice, IntPtr pPropertyCount, ref VkLayerProperties pProperties)
	{
		fixed (VkLayerProperties* ptr = &pProperties)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, VkLayerProperties*, VkResult>)vkEnumerateDeviceLayerProperties_ptr)(physicalDevice, pPropertyCount, ptr);
		}
	}

	public unsafe static VkResult vkEnumerateDeviceLayerProperties(VkPhysicalDevice physicalDevice, IntPtr pPropertyCount, IntPtr pProperties)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, IntPtr, VkResult>)vkEnumerateDeviceLayerProperties_ptr)(physicalDevice, pPropertyCount, pProperties);
	}

	public unsafe static VkResult vkEnumerateInstanceExtensionProperties(byte* pLayerName, uint* pPropertyCount, VkExtensionProperties* pProperties)
	{
		return ((delegate* unmanaged[Stdcall]<byte*, uint*, VkExtensionProperties*, VkResult>)vkEnumerateInstanceExtensionProperties_ptr)(pLayerName, pPropertyCount, pProperties);
	}

	public unsafe static VkResult vkEnumerateInstanceExtensionProperties(byte* pLayerName, uint* pPropertyCount, ref VkExtensionProperties pProperties)
	{
		fixed (VkExtensionProperties* ptr = &pProperties)
		{
			return ((delegate* unmanaged[Stdcall]<byte*, uint*, VkExtensionProperties*, VkResult>)vkEnumerateInstanceExtensionProperties_ptr)(pLayerName, pPropertyCount, ptr);
		}
	}

	public unsafe static VkResult vkEnumerateInstanceExtensionProperties(byte* pLayerName, uint* pPropertyCount, IntPtr pProperties)
	{
		return ((delegate* unmanaged[Stdcall]<byte*, uint*, IntPtr, VkResult>)vkEnumerateInstanceExtensionProperties_ptr)(pLayerName, pPropertyCount, pProperties);
	}

	public unsafe static VkResult vkEnumerateInstanceExtensionProperties(byte* pLayerName, ref uint pPropertyCount, VkExtensionProperties* pProperties)
	{
		fixed (uint* ptr = &pPropertyCount)
		{
			return ((delegate* unmanaged[Stdcall]<byte*, uint*, VkExtensionProperties*, VkResult>)vkEnumerateInstanceExtensionProperties_ptr)(pLayerName, ptr, pProperties);
		}
	}

	public unsafe static VkResult vkEnumerateInstanceExtensionProperties(byte* pLayerName, ref uint pPropertyCount, ref VkExtensionProperties pProperties)
	{
		fixed (uint* ptr = &pPropertyCount)
		{
			fixed (VkExtensionProperties* ptr2 = &pProperties)
			{
				return ((delegate* unmanaged[Stdcall]<byte*, uint*, VkExtensionProperties*, VkResult>)vkEnumerateInstanceExtensionProperties_ptr)(pLayerName, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkEnumerateInstanceExtensionProperties(byte* pLayerName, ref uint pPropertyCount, IntPtr pProperties)
	{
		fixed (uint* ptr = &pPropertyCount)
		{
			return ((delegate* unmanaged[Stdcall]<byte*, uint*, IntPtr, VkResult>)vkEnumerateInstanceExtensionProperties_ptr)(pLayerName, ptr, pProperties);
		}
	}

	public unsafe static VkResult vkEnumerateInstanceExtensionProperties(byte* pLayerName, IntPtr pPropertyCount, VkExtensionProperties* pProperties)
	{
		return ((delegate* unmanaged[Stdcall]<byte*, IntPtr, VkExtensionProperties*, VkResult>)vkEnumerateInstanceExtensionProperties_ptr)(pLayerName, pPropertyCount, pProperties);
	}

	public unsafe static VkResult vkEnumerateInstanceExtensionProperties(byte* pLayerName, IntPtr pPropertyCount, ref VkExtensionProperties pProperties)
	{
		fixed (VkExtensionProperties* ptr = &pProperties)
		{
			return ((delegate* unmanaged[Stdcall]<byte*, IntPtr, VkExtensionProperties*, VkResult>)vkEnumerateInstanceExtensionProperties_ptr)(pLayerName, pPropertyCount, ptr);
		}
	}

	public unsafe static VkResult vkEnumerateInstanceExtensionProperties(byte* pLayerName, IntPtr pPropertyCount, IntPtr pProperties)
	{
		return ((delegate* unmanaged[Stdcall]<byte*, IntPtr, IntPtr, VkResult>)vkEnumerateInstanceExtensionProperties_ptr)(pLayerName, pPropertyCount, pProperties);
	}

	public unsafe static VkResult vkEnumerateInstanceExtensionProperties(string pLayerName, uint* pPropertyCount, VkExtensionProperties* pProperties)
	{
		StringHandle stringHandle = BindingsHelpers.StringToHGlobalUtf8(pLayerName);
		VkResult result = ((delegate* unmanaged[Stdcall]<StringHandle, uint*, VkExtensionProperties*, VkResult>)vkEnumerateInstanceExtensionProperties_ptr)(stringHandle, pPropertyCount, pProperties);
		BindingsHelpers.FreeHGlobal(stringHandle);
		return result;
	}

	public unsafe static VkResult vkEnumerateInstanceExtensionProperties(string pLayerName, uint* pPropertyCount, ref VkExtensionProperties pProperties)
	{
		StringHandle stringHandle = BindingsHelpers.StringToHGlobalUtf8(pLayerName);
		fixed (VkExtensionProperties* ptr = &pProperties)
		{
			VkResult result = ((delegate* unmanaged[Stdcall]<StringHandle, uint*, VkExtensionProperties*, VkResult>)vkEnumerateInstanceExtensionProperties_ptr)(stringHandle, pPropertyCount, ptr);
			BindingsHelpers.FreeHGlobal(stringHandle);
			return result;
		}
	}

	public unsafe static VkResult vkEnumerateInstanceExtensionProperties(string pLayerName, uint* pPropertyCount, IntPtr pProperties)
	{
		StringHandle stringHandle = BindingsHelpers.StringToHGlobalUtf8(pLayerName);
		VkResult result = ((delegate* unmanaged[Stdcall]<StringHandle, uint*, IntPtr, VkResult>)vkEnumerateInstanceExtensionProperties_ptr)(stringHandle, pPropertyCount, pProperties);
		BindingsHelpers.FreeHGlobal(stringHandle);
		return result;
	}

	public unsafe static VkResult vkEnumerateInstanceExtensionProperties(string pLayerName, ref uint pPropertyCount, VkExtensionProperties* pProperties)
	{
		StringHandle stringHandle = BindingsHelpers.StringToHGlobalUtf8(pLayerName);
		fixed (uint* ptr = &pPropertyCount)
		{
			VkResult result = ((delegate* unmanaged[Stdcall]<StringHandle, uint*, VkExtensionProperties*, VkResult>)vkEnumerateInstanceExtensionProperties_ptr)(stringHandle, ptr, pProperties);
			BindingsHelpers.FreeHGlobal(stringHandle);
			return result;
		}
	}

	public unsafe static VkResult vkEnumerateInstanceExtensionProperties(string pLayerName, ref uint pPropertyCount, ref VkExtensionProperties pProperties)
	{
		StringHandle stringHandle = BindingsHelpers.StringToHGlobalUtf8(pLayerName);
		fixed (uint* ptr = &pPropertyCount)
		{
			fixed (VkExtensionProperties* ptr2 = &pProperties)
			{
				VkResult result = ((delegate* unmanaged[Stdcall]<StringHandle, uint*, VkExtensionProperties*, VkResult>)vkEnumerateInstanceExtensionProperties_ptr)(stringHandle, ptr, ptr2);
				BindingsHelpers.FreeHGlobal(stringHandle);
				return result;
			}
		}
	}

	public unsafe static VkResult vkEnumerateInstanceExtensionProperties(string pLayerName, ref uint pPropertyCount, IntPtr pProperties)
	{
		StringHandle stringHandle = BindingsHelpers.StringToHGlobalUtf8(pLayerName);
		fixed (uint* ptr = &pPropertyCount)
		{
			VkResult result = ((delegate* unmanaged[Stdcall]<StringHandle, uint*, IntPtr, VkResult>)vkEnumerateInstanceExtensionProperties_ptr)(stringHandle, ptr, pProperties);
			BindingsHelpers.FreeHGlobal(stringHandle);
			return result;
		}
	}

	public unsafe static VkResult vkEnumerateInstanceExtensionProperties(string pLayerName, IntPtr pPropertyCount, VkExtensionProperties* pProperties)
	{
		StringHandle stringHandle = BindingsHelpers.StringToHGlobalUtf8(pLayerName);
		VkResult result = ((delegate* unmanaged[Stdcall]<StringHandle, IntPtr, VkExtensionProperties*, VkResult>)vkEnumerateInstanceExtensionProperties_ptr)(stringHandle, pPropertyCount, pProperties);
		BindingsHelpers.FreeHGlobal(stringHandle);
		return result;
	}

	public unsafe static VkResult vkEnumerateInstanceExtensionProperties(string pLayerName, IntPtr pPropertyCount, ref VkExtensionProperties pProperties)
	{
		StringHandle stringHandle = BindingsHelpers.StringToHGlobalUtf8(pLayerName);
		fixed (VkExtensionProperties* ptr = &pProperties)
		{
			VkResult result = ((delegate* unmanaged[Stdcall]<StringHandle, IntPtr, VkExtensionProperties*, VkResult>)vkEnumerateInstanceExtensionProperties_ptr)(stringHandle, pPropertyCount, ptr);
			BindingsHelpers.FreeHGlobal(stringHandle);
			return result;
		}
	}

	public unsafe static VkResult vkEnumerateInstanceExtensionProperties(string pLayerName, IntPtr pPropertyCount, IntPtr pProperties)
	{
		StringHandle stringHandle = BindingsHelpers.StringToHGlobalUtf8(pLayerName);
		VkResult result = ((delegate* unmanaged[Stdcall]<StringHandle, IntPtr, IntPtr, VkResult>)vkEnumerateInstanceExtensionProperties_ptr)(stringHandle, pPropertyCount, pProperties);
		BindingsHelpers.FreeHGlobal(stringHandle);
		return result;
	}

	public unsafe static VkResult vkEnumerateInstanceLayerProperties(uint* pPropertyCount, VkLayerProperties* pProperties)
	{
		return ((delegate* unmanaged[Stdcall]<uint*, VkLayerProperties*, VkResult>)vkEnumerateInstanceLayerProperties_ptr)(pPropertyCount, pProperties);
	}

	public unsafe static VkResult vkEnumerateInstanceLayerProperties(uint* pPropertyCount, ref VkLayerProperties pProperties)
	{
		fixed (VkLayerProperties* ptr = &pProperties)
		{
			return ((delegate* unmanaged[Stdcall]<uint*, VkLayerProperties*, VkResult>)vkEnumerateInstanceLayerProperties_ptr)(pPropertyCount, ptr);
		}
	}

	public unsafe static VkResult vkEnumerateInstanceLayerProperties(uint* pPropertyCount, IntPtr pProperties)
	{
		return ((delegate* unmanaged[Stdcall]<uint*, IntPtr, VkResult>)vkEnumerateInstanceLayerProperties_ptr)(pPropertyCount, pProperties);
	}

	public unsafe static VkResult vkEnumerateInstanceLayerProperties(ref uint pPropertyCount, VkLayerProperties* pProperties)
	{
		fixed (uint* ptr = &pPropertyCount)
		{
			return ((delegate* unmanaged[Stdcall]<uint*, VkLayerProperties*, VkResult>)vkEnumerateInstanceLayerProperties_ptr)(ptr, pProperties);
		}
	}

	public unsafe static VkResult vkEnumerateInstanceLayerProperties(ref uint pPropertyCount, ref VkLayerProperties pProperties)
	{
		fixed (uint* ptr = &pPropertyCount)
		{
			fixed (VkLayerProperties* ptr2 = &pProperties)
			{
				return ((delegate* unmanaged[Stdcall]<uint*, VkLayerProperties*, VkResult>)vkEnumerateInstanceLayerProperties_ptr)(ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkEnumerateInstanceLayerProperties(ref uint pPropertyCount, IntPtr pProperties)
	{
		fixed (uint* ptr = &pPropertyCount)
		{
			return ((delegate* unmanaged[Stdcall]<uint*, IntPtr, VkResult>)vkEnumerateInstanceLayerProperties_ptr)(ptr, pProperties);
		}
	}

	public unsafe static VkResult vkEnumerateInstanceLayerProperties(IntPtr pPropertyCount, VkLayerProperties* pProperties)
	{
		return ((delegate* unmanaged[Stdcall]<IntPtr, VkLayerProperties*, VkResult>)vkEnumerateInstanceLayerProperties_ptr)(pPropertyCount, pProperties);
	}

	public unsafe static VkResult vkEnumerateInstanceLayerProperties(IntPtr pPropertyCount, ref VkLayerProperties pProperties)
	{
		fixed (VkLayerProperties* ptr = &pProperties)
		{
			return ((delegate* unmanaged[Stdcall]<IntPtr, VkLayerProperties*, VkResult>)vkEnumerateInstanceLayerProperties_ptr)(pPropertyCount, ptr);
		}
	}

	public unsafe static VkResult vkEnumerateInstanceLayerProperties(IntPtr pPropertyCount, IntPtr pProperties)
	{
		return ((delegate* unmanaged[Stdcall]<IntPtr, IntPtr, VkResult>)vkEnumerateInstanceLayerProperties_ptr)(pPropertyCount, pProperties);
	}

	public unsafe static VkResult vkEnumeratePhysicalDeviceGroupsKHX(VkInstance instance, uint* pPhysicalDeviceGroupCount, VkPhysicalDeviceGroupPropertiesKHX* pPhysicalDeviceGroupProperties)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, uint*, VkPhysicalDeviceGroupPropertiesKHX*, VkResult>)vkEnumeratePhysicalDeviceGroupsKHX_ptr)(instance, pPhysicalDeviceGroupCount, pPhysicalDeviceGroupProperties);
	}

	public unsafe static VkResult vkEnumeratePhysicalDeviceGroupsKHX(VkInstance instance, uint* pPhysicalDeviceGroupCount, ref VkPhysicalDeviceGroupPropertiesKHX pPhysicalDeviceGroupProperties)
	{
		fixed (VkPhysicalDeviceGroupPropertiesKHX* ptr = &pPhysicalDeviceGroupProperties)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, uint*, VkPhysicalDeviceGroupPropertiesKHX*, VkResult>)vkEnumeratePhysicalDeviceGroupsKHX_ptr)(instance, pPhysicalDeviceGroupCount, ptr);
		}
	}

	public unsafe static VkResult vkEnumeratePhysicalDeviceGroupsKHX(VkInstance instance, uint* pPhysicalDeviceGroupCount, IntPtr pPhysicalDeviceGroupProperties)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, uint*, IntPtr, VkResult>)vkEnumeratePhysicalDeviceGroupsKHX_ptr)(instance, pPhysicalDeviceGroupCount, pPhysicalDeviceGroupProperties);
	}

	public unsafe static VkResult vkEnumeratePhysicalDeviceGroupsKHX(VkInstance instance, ref uint pPhysicalDeviceGroupCount, VkPhysicalDeviceGroupPropertiesKHX* pPhysicalDeviceGroupProperties)
	{
		fixed (uint* ptr = &pPhysicalDeviceGroupCount)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, uint*, VkPhysicalDeviceGroupPropertiesKHX*, VkResult>)vkEnumeratePhysicalDeviceGroupsKHX_ptr)(instance, ptr, pPhysicalDeviceGroupProperties);
		}
	}

	public unsafe static VkResult vkEnumeratePhysicalDeviceGroupsKHX(VkInstance instance, ref uint pPhysicalDeviceGroupCount, ref VkPhysicalDeviceGroupPropertiesKHX pPhysicalDeviceGroupProperties)
	{
		fixed (uint* ptr = &pPhysicalDeviceGroupCount)
		{
			fixed (VkPhysicalDeviceGroupPropertiesKHX* ptr2 = &pPhysicalDeviceGroupProperties)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, uint*, VkPhysicalDeviceGroupPropertiesKHX*, VkResult>)vkEnumeratePhysicalDeviceGroupsKHX_ptr)(instance, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkEnumeratePhysicalDeviceGroupsKHX(VkInstance instance, ref uint pPhysicalDeviceGroupCount, IntPtr pPhysicalDeviceGroupProperties)
	{
		fixed (uint* ptr = &pPhysicalDeviceGroupCount)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, uint*, IntPtr, VkResult>)vkEnumeratePhysicalDeviceGroupsKHX_ptr)(instance, ptr, pPhysicalDeviceGroupProperties);
		}
	}

	public unsafe static VkResult vkEnumeratePhysicalDeviceGroupsKHX(VkInstance instance, IntPtr pPhysicalDeviceGroupCount, VkPhysicalDeviceGroupPropertiesKHX* pPhysicalDeviceGroupProperties)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkPhysicalDeviceGroupPropertiesKHX*, VkResult>)vkEnumeratePhysicalDeviceGroupsKHX_ptr)(instance, pPhysicalDeviceGroupCount, pPhysicalDeviceGroupProperties);
	}

	public unsafe static VkResult vkEnumeratePhysicalDeviceGroupsKHX(VkInstance instance, IntPtr pPhysicalDeviceGroupCount, ref VkPhysicalDeviceGroupPropertiesKHX pPhysicalDeviceGroupProperties)
	{
		fixed (VkPhysicalDeviceGroupPropertiesKHX* ptr = &pPhysicalDeviceGroupProperties)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkPhysicalDeviceGroupPropertiesKHX*, VkResult>)vkEnumeratePhysicalDeviceGroupsKHX_ptr)(instance, pPhysicalDeviceGroupCount, ptr);
		}
	}

	public unsafe static VkResult vkEnumeratePhysicalDeviceGroupsKHX(VkInstance instance, IntPtr pPhysicalDeviceGroupCount, IntPtr pPhysicalDeviceGroupProperties)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, IntPtr, VkResult>)vkEnumeratePhysicalDeviceGroupsKHX_ptr)(instance, pPhysicalDeviceGroupCount, pPhysicalDeviceGroupProperties);
	}

	public unsafe static VkResult vkEnumeratePhysicalDevices(VkInstance instance, uint* pPhysicalDeviceCount, VkPhysicalDevice* pPhysicalDevices)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, uint*, VkPhysicalDevice*, VkResult>)vkEnumeratePhysicalDevices_ptr)(instance, pPhysicalDeviceCount, pPhysicalDevices);
	}

	public unsafe static VkResult vkEnumeratePhysicalDevices(VkInstance instance, uint* pPhysicalDeviceCount, ref VkPhysicalDevice pPhysicalDevices)
	{
		fixed (VkPhysicalDevice* ptr = &pPhysicalDevices)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, uint*, VkPhysicalDevice*, VkResult>)vkEnumeratePhysicalDevices_ptr)(instance, pPhysicalDeviceCount, ptr);
		}
	}

	public unsafe static VkResult vkEnumeratePhysicalDevices(VkInstance instance, uint* pPhysicalDeviceCount, IntPtr pPhysicalDevices)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, uint*, IntPtr, VkResult>)vkEnumeratePhysicalDevices_ptr)(instance, pPhysicalDeviceCount, pPhysicalDevices);
	}

	public unsafe static VkResult vkEnumeratePhysicalDevices(VkInstance instance, ref uint pPhysicalDeviceCount, VkPhysicalDevice* pPhysicalDevices)
	{
		fixed (uint* ptr = &pPhysicalDeviceCount)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, uint*, VkPhysicalDevice*, VkResult>)vkEnumeratePhysicalDevices_ptr)(instance, ptr, pPhysicalDevices);
		}
	}

	public unsafe static VkResult vkEnumeratePhysicalDevices(VkInstance instance, ref uint pPhysicalDeviceCount, ref VkPhysicalDevice pPhysicalDevices)
	{
		fixed (uint* ptr = &pPhysicalDeviceCount)
		{
			fixed (VkPhysicalDevice* ptr2 = &pPhysicalDevices)
			{
				return ((delegate* unmanaged[Stdcall]<VkInstance, uint*, VkPhysicalDevice*, VkResult>)vkEnumeratePhysicalDevices_ptr)(instance, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkEnumeratePhysicalDevices(VkInstance instance, ref uint pPhysicalDeviceCount, IntPtr pPhysicalDevices)
	{
		fixed (uint* ptr = &pPhysicalDeviceCount)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, uint*, IntPtr, VkResult>)vkEnumeratePhysicalDevices_ptr)(instance, ptr, pPhysicalDevices);
		}
	}

	public unsafe static VkResult vkEnumeratePhysicalDevices(VkInstance instance, IntPtr pPhysicalDeviceCount, VkPhysicalDevice* pPhysicalDevices)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkPhysicalDevice*, VkResult>)vkEnumeratePhysicalDevices_ptr)(instance, pPhysicalDeviceCount, pPhysicalDevices);
	}

	public unsafe static VkResult vkEnumeratePhysicalDevices(VkInstance instance, IntPtr pPhysicalDeviceCount, ref VkPhysicalDevice pPhysicalDevices)
	{
		fixed (VkPhysicalDevice* ptr = &pPhysicalDevices)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, VkPhysicalDevice*, VkResult>)vkEnumeratePhysicalDevices_ptr)(instance, pPhysicalDeviceCount, ptr);
		}
	}

	public unsafe static VkResult vkEnumeratePhysicalDevices(VkInstance instance, IntPtr pPhysicalDeviceCount, IntPtr pPhysicalDevices)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, IntPtr, IntPtr, VkResult>)vkEnumeratePhysicalDevices_ptr)(instance, pPhysicalDeviceCount, pPhysicalDevices);
	}

	public unsafe static VkResult vkFlushMappedMemoryRanges(VkDevice device, uint memoryRangeCount, VkMappedMemoryRange* pMemoryRanges)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, uint, VkMappedMemoryRange*, VkResult>)vkFlushMappedMemoryRanges_ptr)(device, memoryRangeCount, pMemoryRanges);
	}

	public unsafe static VkResult vkFlushMappedMemoryRanges(VkDevice device, uint memoryRangeCount, ref VkMappedMemoryRange pMemoryRanges)
	{
		fixed (VkMappedMemoryRange* ptr = &pMemoryRanges)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, uint, VkMappedMemoryRange*, VkResult>)vkFlushMappedMemoryRanges_ptr)(device, memoryRangeCount, ptr);
		}
	}

	public unsafe static VkResult vkFlushMappedMemoryRanges(VkDevice device, uint memoryRangeCount, IntPtr pMemoryRanges)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, uint, IntPtr, VkResult>)vkFlushMappedMemoryRanges_ptr)(device, memoryRangeCount, pMemoryRanges);
	}

	public unsafe static void vkFreeCommandBuffers(VkDevice device, VkCommandPool commandPool, uint commandBufferCount, VkCommandBuffer* pCommandBuffers)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkCommandPool, uint, VkCommandBuffer*, void>)vkFreeCommandBuffers_ptr)(device, commandPool, commandBufferCount, pCommandBuffers);
	}

	public unsafe static void vkFreeCommandBuffers(VkDevice device, VkCommandPool commandPool, uint commandBufferCount, ref VkCommandBuffer pCommandBuffers)
	{
		fixed (VkCommandBuffer* ptr = &pCommandBuffers)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkCommandPool, uint, VkCommandBuffer*, void>)vkFreeCommandBuffers_ptr)(device, commandPool, commandBufferCount, ptr);
		}
	}

	public unsafe static void vkFreeCommandBuffers(VkDevice device, VkCommandPool commandPool, uint commandBufferCount, IntPtr pCommandBuffers)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkCommandPool, uint, IntPtr, void>)vkFreeCommandBuffers_ptr)(device, commandPool, commandBufferCount, pCommandBuffers);
	}

	public unsafe static VkResult vkFreeDescriptorSets(VkDevice device, VkDescriptorPool descriptorPool, uint descriptorSetCount, VkDescriptorSet* pDescriptorSets)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorPool, uint, VkDescriptorSet*, VkResult>)vkFreeDescriptorSets_ptr)(device, descriptorPool, descriptorSetCount, pDescriptorSets);
	}

	public unsafe static VkResult vkFreeDescriptorSets(VkDevice device, VkDescriptorPool descriptorPool, uint descriptorSetCount, ref VkDescriptorSet pDescriptorSets)
	{
		fixed (VkDescriptorSet* ptr = &pDescriptorSets)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorPool, uint, VkDescriptorSet*, VkResult>)vkFreeDescriptorSets_ptr)(device, descriptorPool, descriptorSetCount, ptr);
		}
	}

	public unsafe static VkResult vkFreeDescriptorSets(VkDevice device, VkDescriptorPool descriptorPool, uint descriptorSetCount, IntPtr pDescriptorSets)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorPool, uint, IntPtr, VkResult>)vkFreeDescriptorSets_ptr)(device, descriptorPool, descriptorSetCount, pDescriptorSets);
	}

	public unsafe static void vkFreeMemory(VkDevice device, VkDeviceMemory memory, VkAllocationCallbacks* pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkDeviceMemory, VkAllocationCallbacks*, void>)vkFreeMemory_ptr)(device, memory, pAllocator);
	}

	public unsafe static void vkFreeMemory(VkDevice device, VkDeviceMemory memory, ref VkAllocationCallbacks pAllocator)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkDeviceMemory, VkAllocationCallbacks*, void>)vkFreeMemory_ptr)(device, memory, ptr);
		}
	}

	public unsafe static void vkFreeMemory(VkDevice device, VkDeviceMemory memory, IntPtr pAllocator)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkDeviceMemory, IntPtr, void>)vkFreeMemory_ptr)(device, memory, pAllocator);
	}

	public unsafe static void vkGetBufferMemoryRequirements(VkDevice device, VkBuffer buffer, VkMemoryRequirements* pMemoryRequirements)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkBuffer, VkMemoryRequirements*, void>)vkGetBufferMemoryRequirements_ptr)(device, buffer, pMemoryRequirements);
	}

	public unsafe static void vkGetBufferMemoryRequirements(VkDevice device, VkBuffer buffer, out VkMemoryRequirements pMemoryRequirements)
	{
		fixed (VkMemoryRequirements* ptr = &pMemoryRequirements)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkBuffer, VkMemoryRequirements*, void>)vkGetBufferMemoryRequirements_ptr)(device, buffer, ptr);
		}
	}

	public unsafe static void vkGetBufferMemoryRequirements2KHR(VkDevice device, VkBufferMemoryRequirementsInfo2KHR* pInfo, VkMemoryRequirements2KHR* pMemoryRequirements)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkBufferMemoryRequirementsInfo2KHR*, VkMemoryRequirements2KHR*, void>)vkGetBufferMemoryRequirements2KHR_ptr)(device, pInfo, pMemoryRequirements);
	}

	public unsafe static void vkGetBufferMemoryRequirements2KHR(VkDevice device, VkBufferMemoryRequirementsInfo2KHR* pInfo, out VkMemoryRequirements2KHR pMemoryRequirements)
	{
		fixed (VkMemoryRequirements2KHR* ptr = &pMemoryRequirements)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkBufferMemoryRequirementsInfo2KHR*, VkMemoryRequirements2KHR*, void>)vkGetBufferMemoryRequirements2KHR_ptr)(device, pInfo, ptr);
		}
	}

	public unsafe static void vkGetBufferMemoryRequirements2KHR(VkDevice device, ref VkBufferMemoryRequirementsInfo2KHR pInfo, VkMemoryRequirements2KHR* pMemoryRequirements)
	{
		fixed (VkBufferMemoryRequirementsInfo2KHR* ptr = &pInfo)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkBufferMemoryRequirementsInfo2KHR*, VkMemoryRequirements2KHR*, void>)vkGetBufferMemoryRequirements2KHR_ptr)(device, ptr, pMemoryRequirements);
		}
	}

	public unsafe static void vkGetBufferMemoryRequirements2KHR(VkDevice device, ref VkBufferMemoryRequirementsInfo2KHR pInfo, out VkMemoryRequirements2KHR pMemoryRequirements)
	{
		fixed (VkBufferMemoryRequirementsInfo2KHR* ptr = &pInfo)
		{
			fixed (VkMemoryRequirements2KHR* ptr2 = &pMemoryRequirements)
			{
				((delegate* unmanaged[Stdcall]<VkDevice, VkBufferMemoryRequirementsInfo2KHR*, VkMemoryRequirements2KHR*, void>)vkGetBufferMemoryRequirements2KHR_ptr)(device, ptr, ptr2);
			}
		}
	}

	public unsafe static void vkGetBufferMemoryRequirements2KHR(VkDevice device, IntPtr pInfo, VkMemoryRequirements2KHR* pMemoryRequirements)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkMemoryRequirements2KHR*, void>)vkGetBufferMemoryRequirements2KHR_ptr)(device, pInfo, pMemoryRequirements);
	}

	public unsafe static void vkGetBufferMemoryRequirements2KHR(VkDevice device, IntPtr pInfo, out VkMemoryRequirements2KHR pMemoryRequirements)
	{
		fixed (VkMemoryRequirements2KHR* ptr = &pMemoryRequirements)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkMemoryRequirements2KHR*, void>)vkGetBufferMemoryRequirements2KHR_ptr)(device, pInfo, ptr);
		}
	}

	public unsafe static void vkGetDeviceGroupPeerMemoryFeaturesKHX(VkDevice device, uint heapIndex, uint localDeviceIndex, uint remoteDeviceIndex, VkPeerMemoryFeatureFlagsKHX* pPeerMemoryFeatures)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, uint, uint, uint, VkPeerMemoryFeatureFlagsKHX*, void>)vkGetDeviceGroupPeerMemoryFeaturesKHX_ptr)(device, heapIndex, localDeviceIndex, remoteDeviceIndex, pPeerMemoryFeatures);
	}

	public unsafe static void vkGetDeviceGroupPeerMemoryFeaturesKHX(VkDevice device, uint heapIndex, uint localDeviceIndex, uint remoteDeviceIndex, out VkPeerMemoryFeatureFlagsKHX pPeerMemoryFeatures)
	{
		fixed (VkPeerMemoryFeatureFlagsKHX* ptr = &pPeerMemoryFeatures)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, uint, uint, uint, VkPeerMemoryFeatureFlagsKHX*, void>)vkGetDeviceGroupPeerMemoryFeaturesKHX_ptr)(device, heapIndex, localDeviceIndex, remoteDeviceIndex, ptr);
		}
	}

	public unsafe static VkResult vkGetDeviceGroupPresentCapabilitiesKHX(VkDevice device, VkDeviceGroupPresentCapabilitiesKHX* pDeviceGroupPresentCapabilities)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkDeviceGroupPresentCapabilitiesKHX*, VkResult>)vkGetDeviceGroupPresentCapabilitiesKHX_ptr)(device, pDeviceGroupPresentCapabilities);
	}

	public unsafe static VkResult vkGetDeviceGroupPresentCapabilitiesKHX(VkDevice device, out VkDeviceGroupPresentCapabilitiesKHX pDeviceGroupPresentCapabilities)
	{
		fixed (VkDeviceGroupPresentCapabilitiesKHX* ptr = &pDeviceGroupPresentCapabilities)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDeviceGroupPresentCapabilitiesKHX*, VkResult>)vkGetDeviceGroupPresentCapabilitiesKHX_ptr)(device, ptr);
		}
	}

	public unsafe static VkResult vkGetDeviceGroupSurfacePresentModesKHX(VkDevice device, VkSurfaceKHR surface, VkDeviceGroupPresentModeFlagsKHX* pModes)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkSurfaceKHR, VkDeviceGroupPresentModeFlagsKHX*, VkResult>)vkGetDeviceGroupSurfacePresentModesKHX_ptr)(device, surface, pModes);
	}

	public unsafe static VkResult vkGetDeviceGroupSurfacePresentModesKHX(VkDevice device, VkSurfaceKHR surface, out VkDeviceGroupPresentModeFlagsKHX pModes)
	{
		fixed (VkDeviceGroupPresentModeFlagsKHX* ptr = &pModes)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkSurfaceKHR, VkDeviceGroupPresentModeFlagsKHX*, VkResult>)vkGetDeviceGroupSurfacePresentModesKHX_ptr)(device, surface, ptr);
		}
	}

	public unsafe static void vkGetDeviceMemoryCommitment(VkDevice device, VkDeviceMemory memory, ulong* pCommittedMemoryInBytes)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkDeviceMemory, ulong*, void>)vkGetDeviceMemoryCommitment_ptr)(device, memory, pCommittedMemoryInBytes);
	}

	public unsafe static void vkGetDeviceMemoryCommitment(VkDevice device, VkDeviceMemory memory, out ulong pCommittedMemoryInBytes)
	{
		fixed (ulong* ptr = &pCommittedMemoryInBytes)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkDeviceMemory, ulong*, void>)vkGetDeviceMemoryCommitment_ptr)(device, memory, ptr);
		}
	}

	public unsafe static IntPtr vkGetDeviceProcAddr(VkDevice device, byte* pName)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, byte*, IntPtr>)vkGetDeviceProcAddr_ptr)(device, pName);
	}

	public unsafe static IntPtr vkGetDeviceProcAddr(VkDevice device, out byte pName)
	{
		fixed (byte* ptr = &pName)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, byte*, IntPtr>)vkGetDeviceProcAddr_ptr)(device, ptr);
		}
	}

	public unsafe static void vkGetDeviceQueue(VkDevice device, uint queueFamilyIndex, uint queueIndex, VkQueue* pQueue)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, uint, uint, VkQueue*, void>)vkGetDeviceQueue_ptr)(device, queueFamilyIndex, queueIndex, pQueue);
	}

	public unsafe static void vkGetDeviceQueue(VkDevice device, uint queueFamilyIndex, uint queueIndex, out VkQueue pQueue)
	{
		fixed (VkQueue* ptr = &pQueue)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, uint, uint, VkQueue*, void>)vkGetDeviceQueue_ptr)(device, queueFamilyIndex, queueIndex, ptr);
		}
	}

	public unsafe static VkResult vkGetDisplayModePropertiesKHR(VkPhysicalDevice physicalDevice, VkDisplayKHR display, uint* pPropertyCount, VkDisplayModePropertiesKHR* pProperties)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDisplayKHR, uint*, VkDisplayModePropertiesKHR*, VkResult>)vkGetDisplayModePropertiesKHR_ptr)(physicalDevice, display, pPropertyCount, pProperties);
	}

	public unsafe static VkResult vkGetDisplayModePropertiesKHR(VkPhysicalDevice physicalDevice, VkDisplayKHR display, uint* pPropertyCount, out VkDisplayModePropertiesKHR pProperties)
	{
		fixed (VkDisplayModePropertiesKHR* ptr = &pProperties)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDisplayKHR, uint*, VkDisplayModePropertiesKHR*, VkResult>)vkGetDisplayModePropertiesKHR_ptr)(physicalDevice, display, pPropertyCount, ptr);
		}
	}

	public unsafe static VkResult vkGetDisplayModePropertiesKHR(VkPhysicalDevice physicalDevice, VkDisplayKHR display, ref uint pPropertyCount, VkDisplayModePropertiesKHR* pProperties)
	{
		fixed (uint* ptr = &pPropertyCount)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDisplayKHR, uint*, VkDisplayModePropertiesKHR*, VkResult>)vkGetDisplayModePropertiesKHR_ptr)(physicalDevice, display, ptr, pProperties);
		}
	}

	public unsafe static VkResult vkGetDisplayModePropertiesKHR(VkPhysicalDevice physicalDevice, VkDisplayKHR display, ref uint pPropertyCount, out VkDisplayModePropertiesKHR pProperties)
	{
		fixed (uint* ptr = &pPropertyCount)
		{
			fixed (VkDisplayModePropertiesKHR* ptr2 = &pProperties)
			{
				return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDisplayKHR, uint*, VkDisplayModePropertiesKHR*, VkResult>)vkGetDisplayModePropertiesKHR_ptr)(physicalDevice, display, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkGetDisplayModePropertiesKHR(VkPhysicalDevice physicalDevice, VkDisplayKHR display, IntPtr pPropertyCount, VkDisplayModePropertiesKHR* pProperties)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDisplayKHR, IntPtr, VkDisplayModePropertiesKHR*, VkResult>)vkGetDisplayModePropertiesKHR_ptr)(physicalDevice, display, pPropertyCount, pProperties);
	}

	public unsafe static VkResult vkGetDisplayModePropertiesKHR(VkPhysicalDevice physicalDevice, VkDisplayKHR display, IntPtr pPropertyCount, out VkDisplayModePropertiesKHR pProperties)
	{
		fixed (VkDisplayModePropertiesKHR* ptr = &pProperties)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDisplayKHR, IntPtr, VkDisplayModePropertiesKHR*, VkResult>)vkGetDisplayModePropertiesKHR_ptr)(physicalDevice, display, pPropertyCount, ptr);
		}
	}

	public unsafe static VkResult vkGetDisplayPlaneCapabilitiesKHR(VkPhysicalDevice physicalDevice, VkDisplayModeKHR mode, uint planeIndex, VkDisplayPlaneCapabilitiesKHR* pCapabilities)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDisplayModeKHR, uint, VkDisplayPlaneCapabilitiesKHR*, VkResult>)vkGetDisplayPlaneCapabilitiesKHR_ptr)(physicalDevice, mode, planeIndex, pCapabilities);
	}

	public unsafe static VkResult vkGetDisplayPlaneCapabilitiesKHR(VkPhysicalDevice physicalDevice, VkDisplayModeKHR mode, uint planeIndex, out VkDisplayPlaneCapabilitiesKHR pCapabilities)
	{
		fixed (VkDisplayPlaneCapabilitiesKHR* ptr = &pCapabilities)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDisplayModeKHR, uint, VkDisplayPlaneCapabilitiesKHR*, VkResult>)vkGetDisplayPlaneCapabilitiesKHR_ptr)(physicalDevice, mode, planeIndex, ptr);
		}
	}

	public unsafe static VkResult vkGetDisplayPlaneSupportedDisplaysKHR(VkPhysicalDevice physicalDevice, uint planeIndex, uint* pDisplayCount, VkDisplayKHR* pDisplays)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint, uint*, VkDisplayKHR*, VkResult>)vkGetDisplayPlaneSupportedDisplaysKHR_ptr)(physicalDevice, planeIndex, pDisplayCount, pDisplays);
	}

	public unsafe static VkResult vkGetDisplayPlaneSupportedDisplaysKHR(VkPhysicalDevice physicalDevice, uint planeIndex, uint* pDisplayCount, out VkDisplayKHR pDisplays)
	{
		fixed (VkDisplayKHR* ptr = &pDisplays)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint, uint*, VkDisplayKHR*, VkResult>)vkGetDisplayPlaneSupportedDisplaysKHR_ptr)(physicalDevice, planeIndex, pDisplayCount, ptr);
		}
	}

	public unsafe static VkResult vkGetDisplayPlaneSupportedDisplaysKHR(VkPhysicalDevice physicalDevice, uint planeIndex, ref uint pDisplayCount, VkDisplayKHR* pDisplays)
	{
		fixed (uint* ptr = &pDisplayCount)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint, uint*, VkDisplayKHR*, VkResult>)vkGetDisplayPlaneSupportedDisplaysKHR_ptr)(physicalDevice, planeIndex, ptr, pDisplays);
		}
	}

	public unsafe static VkResult vkGetDisplayPlaneSupportedDisplaysKHR(VkPhysicalDevice physicalDevice, uint planeIndex, ref uint pDisplayCount, out VkDisplayKHR pDisplays)
	{
		fixed (uint* ptr = &pDisplayCount)
		{
			fixed (VkDisplayKHR* ptr2 = &pDisplays)
			{
				return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint, uint*, VkDisplayKHR*, VkResult>)vkGetDisplayPlaneSupportedDisplaysKHR_ptr)(physicalDevice, planeIndex, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkGetDisplayPlaneSupportedDisplaysKHR(VkPhysicalDevice physicalDevice, uint planeIndex, IntPtr pDisplayCount, VkDisplayKHR* pDisplays)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint, IntPtr, VkDisplayKHR*, VkResult>)vkGetDisplayPlaneSupportedDisplaysKHR_ptr)(physicalDevice, planeIndex, pDisplayCount, pDisplays);
	}

	public unsafe static VkResult vkGetDisplayPlaneSupportedDisplaysKHR(VkPhysicalDevice physicalDevice, uint planeIndex, IntPtr pDisplayCount, out VkDisplayKHR pDisplays)
	{
		fixed (VkDisplayKHR* ptr = &pDisplays)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint, IntPtr, VkDisplayKHR*, VkResult>)vkGetDisplayPlaneSupportedDisplaysKHR_ptr)(physicalDevice, planeIndex, pDisplayCount, ptr);
		}
	}

	public unsafe static VkResult vkGetEventStatus(VkDevice device, VkEvent @event)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkEvent, VkResult>)vkGetEventStatus_ptr)(device, @event);
	}

	public unsafe static VkResult vkGetFenceFdKHR(VkDevice device, VkFenceGetFdInfoKHR* pGetFdInfo, int* pFd)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkFenceGetFdInfoKHR*, int*, VkResult>)vkGetFenceFdKHR_ptr)(device, pGetFdInfo, pFd);
	}

	public unsafe static VkResult vkGetFenceFdKHR(VkDevice device, VkFenceGetFdInfoKHR* pGetFdInfo, out int pFd)
	{
		fixed (int* ptr = &pFd)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkFenceGetFdInfoKHR*, int*, VkResult>)vkGetFenceFdKHR_ptr)(device, pGetFdInfo, ptr);
		}
	}

	public unsafe static VkResult vkGetFenceFdKHR(VkDevice device, ref VkFenceGetFdInfoKHR pGetFdInfo, int* pFd)
	{
		fixed (VkFenceGetFdInfoKHR* ptr = &pGetFdInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkFenceGetFdInfoKHR*, int*, VkResult>)vkGetFenceFdKHR_ptr)(device, ptr, pFd);
		}
	}

	public unsafe static VkResult vkGetFenceFdKHR(VkDevice device, ref VkFenceGetFdInfoKHR pGetFdInfo, out int pFd)
	{
		fixed (VkFenceGetFdInfoKHR* ptr = &pGetFdInfo)
		{
			fixed (int* ptr2 = &pFd)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkFenceGetFdInfoKHR*, int*, VkResult>)vkGetFenceFdKHR_ptr)(device, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkGetFenceFdKHR(VkDevice device, IntPtr pGetFdInfo, int* pFd)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, int*, VkResult>)vkGetFenceFdKHR_ptr)(device, pGetFdInfo, pFd);
	}

	public unsafe static VkResult vkGetFenceFdKHR(VkDevice device, IntPtr pGetFdInfo, out int pFd)
	{
		fixed (int* ptr = &pFd)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, int*, VkResult>)vkGetFenceFdKHR_ptr)(device, pGetFdInfo, ptr);
		}
	}

	public unsafe static VkResult vkGetFenceStatus(VkDevice device, VkFence fence)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkFence, VkResult>)vkGetFenceStatus_ptr)(device, fence);
	}

	public unsafe static VkResult vkGetFenceWin32HandleKHR(VkDevice device, VkFenceGetWin32HandleInfoKHR* pGetWin32HandleInfo, HANDLE* pHandle)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkFenceGetWin32HandleInfoKHR*, HANDLE*, VkResult>)vkGetFenceWin32HandleKHR_ptr)(device, pGetWin32HandleInfo, pHandle);
	}

	public unsafe static VkResult vkGetFenceWin32HandleKHR(VkDevice device, VkFenceGetWin32HandleInfoKHR* pGetWin32HandleInfo, out HANDLE pHandle)
	{
		fixed (HANDLE* ptr = &pHandle)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkFenceGetWin32HandleInfoKHR*, HANDLE*, VkResult>)vkGetFenceWin32HandleKHR_ptr)(device, pGetWin32HandleInfo, ptr);
		}
	}

	public unsafe static VkResult vkGetFenceWin32HandleKHR(VkDevice device, ref VkFenceGetWin32HandleInfoKHR pGetWin32HandleInfo, HANDLE* pHandle)
	{
		fixed (VkFenceGetWin32HandleInfoKHR* ptr = &pGetWin32HandleInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkFenceGetWin32HandleInfoKHR*, HANDLE*, VkResult>)vkGetFenceWin32HandleKHR_ptr)(device, ptr, pHandle);
		}
	}

	public unsafe static VkResult vkGetFenceWin32HandleKHR(VkDevice device, ref VkFenceGetWin32HandleInfoKHR pGetWin32HandleInfo, out HANDLE pHandle)
	{
		fixed (VkFenceGetWin32HandleInfoKHR* ptr = &pGetWin32HandleInfo)
		{
			fixed (HANDLE* ptr2 = &pHandle)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkFenceGetWin32HandleInfoKHR*, HANDLE*, VkResult>)vkGetFenceWin32HandleKHR_ptr)(device, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkGetFenceWin32HandleKHR(VkDevice device, IntPtr pGetWin32HandleInfo, HANDLE* pHandle)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, HANDLE*, VkResult>)vkGetFenceWin32HandleKHR_ptr)(device, pGetWin32HandleInfo, pHandle);
	}

	public unsafe static VkResult vkGetFenceWin32HandleKHR(VkDevice device, IntPtr pGetWin32HandleInfo, out HANDLE pHandle)
	{
		fixed (HANDLE* ptr = &pHandle)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, HANDLE*, VkResult>)vkGetFenceWin32HandleKHR_ptr)(device, pGetWin32HandleInfo, ptr);
		}
	}

	public unsafe static void vkGetImageMemoryRequirements(VkDevice device, VkImage image, VkMemoryRequirements* pMemoryRequirements)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkImage, VkMemoryRequirements*, void>)vkGetImageMemoryRequirements_ptr)(device, image, pMemoryRequirements);
	}

	public unsafe static void vkGetImageMemoryRequirements(VkDevice device, VkImage image, out VkMemoryRequirements pMemoryRequirements)
	{
		fixed (VkMemoryRequirements* ptr = &pMemoryRequirements)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkImage, VkMemoryRequirements*, void>)vkGetImageMemoryRequirements_ptr)(device, image, ptr);
		}
	}

	public unsafe static void vkGetImageMemoryRequirements2KHR(VkDevice device, VkImageMemoryRequirementsInfo2KHR* pInfo, VkMemoryRequirements2KHR* pMemoryRequirements)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkImageMemoryRequirementsInfo2KHR*, VkMemoryRequirements2KHR*, void>)vkGetImageMemoryRequirements2KHR_ptr)(device, pInfo, pMemoryRequirements);
	}

	public unsafe static void vkGetImageMemoryRequirements2KHR(VkDevice device, VkImageMemoryRequirementsInfo2KHR* pInfo, out VkMemoryRequirements2KHR pMemoryRequirements)
	{
		fixed (VkMemoryRequirements2KHR* ptr = &pMemoryRequirements)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkImageMemoryRequirementsInfo2KHR*, VkMemoryRequirements2KHR*, void>)vkGetImageMemoryRequirements2KHR_ptr)(device, pInfo, ptr);
		}
	}

	public unsafe static void vkGetImageMemoryRequirements2KHR(VkDevice device, ref VkImageMemoryRequirementsInfo2KHR pInfo, VkMemoryRequirements2KHR* pMemoryRequirements)
	{
		fixed (VkImageMemoryRequirementsInfo2KHR* ptr = &pInfo)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkImageMemoryRequirementsInfo2KHR*, VkMemoryRequirements2KHR*, void>)vkGetImageMemoryRequirements2KHR_ptr)(device, ptr, pMemoryRequirements);
		}
	}

	public unsafe static void vkGetImageMemoryRequirements2KHR(VkDevice device, ref VkImageMemoryRequirementsInfo2KHR pInfo, out VkMemoryRequirements2KHR pMemoryRequirements)
	{
		fixed (VkImageMemoryRequirementsInfo2KHR* ptr = &pInfo)
		{
			fixed (VkMemoryRequirements2KHR* ptr2 = &pMemoryRequirements)
			{
				((delegate* unmanaged[Stdcall]<VkDevice, VkImageMemoryRequirementsInfo2KHR*, VkMemoryRequirements2KHR*, void>)vkGetImageMemoryRequirements2KHR_ptr)(device, ptr, ptr2);
			}
		}
	}

	public unsafe static void vkGetImageMemoryRequirements2KHR(VkDevice device, IntPtr pInfo, VkMemoryRequirements2KHR* pMemoryRequirements)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkMemoryRequirements2KHR*, void>)vkGetImageMemoryRequirements2KHR_ptr)(device, pInfo, pMemoryRequirements);
	}

	public unsafe static void vkGetImageMemoryRequirements2KHR(VkDevice device, IntPtr pInfo, out VkMemoryRequirements2KHR pMemoryRequirements)
	{
		fixed (VkMemoryRequirements2KHR* ptr = &pMemoryRequirements)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkMemoryRequirements2KHR*, void>)vkGetImageMemoryRequirements2KHR_ptr)(device, pInfo, ptr);
		}
	}

	public unsafe static void vkGetImageSparseMemoryRequirements(VkDevice device, VkImage image, uint* pSparseMemoryRequirementCount, VkSparseImageMemoryRequirements* pSparseMemoryRequirements)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkImage, uint*, VkSparseImageMemoryRequirements*, void>)vkGetImageSparseMemoryRequirements_ptr)(device, image, pSparseMemoryRequirementCount, pSparseMemoryRequirements);
	}

	public unsafe static void vkGetImageSparseMemoryRequirements(VkDevice device, VkImage image, uint* pSparseMemoryRequirementCount, out VkSparseImageMemoryRequirements pSparseMemoryRequirements)
	{
		fixed (VkSparseImageMemoryRequirements* ptr = &pSparseMemoryRequirements)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkImage, uint*, VkSparseImageMemoryRequirements*, void>)vkGetImageSparseMemoryRequirements_ptr)(device, image, pSparseMemoryRequirementCount, ptr);
		}
	}

	public unsafe static void vkGetImageSparseMemoryRequirements(VkDevice device, VkImage image, ref uint pSparseMemoryRequirementCount, VkSparseImageMemoryRequirements* pSparseMemoryRequirements)
	{
		fixed (uint* ptr = &pSparseMemoryRequirementCount)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkImage, uint*, VkSparseImageMemoryRequirements*, void>)vkGetImageSparseMemoryRequirements_ptr)(device, image, ptr, pSparseMemoryRequirements);
		}
	}

	public unsafe static void vkGetImageSparseMemoryRequirements(VkDevice device, VkImage image, ref uint pSparseMemoryRequirementCount, out VkSparseImageMemoryRequirements pSparseMemoryRequirements)
	{
		fixed (uint* ptr = &pSparseMemoryRequirementCount)
		{
			fixed (VkSparseImageMemoryRequirements* ptr2 = &pSparseMemoryRequirements)
			{
				((delegate* unmanaged[Stdcall]<VkDevice, VkImage, uint*, VkSparseImageMemoryRequirements*, void>)vkGetImageSparseMemoryRequirements_ptr)(device, image, ptr, ptr2);
			}
		}
	}

	public unsafe static void vkGetImageSparseMemoryRequirements(VkDevice device, VkImage image, IntPtr pSparseMemoryRequirementCount, VkSparseImageMemoryRequirements* pSparseMemoryRequirements)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkImage, IntPtr, VkSparseImageMemoryRequirements*, void>)vkGetImageSparseMemoryRequirements_ptr)(device, image, pSparseMemoryRequirementCount, pSparseMemoryRequirements);
	}

	public unsafe static void vkGetImageSparseMemoryRequirements(VkDevice device, VkImage image, IntPtr pSparseMemoryRequirementCount, out VkSparseImageMemoryRequirements pSparseMemoryRequirements)
	{
		fixed (VkSparseImageMemoryRequirements* ptr = &pSparseMemoryRequirements)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkImage, IntPtr, VkSparseImageMemoryRequirements*, void>)vkGetImageSparseMemoryRequirements_ptr)(device, image, pSparseMemoryRequirementCount, ptr);
		}
	}

	public unsafe static void vkGetImageSparseMemoryRequirements2KHR(VkDevice device, VkImageSparseMemoryRequirementsInfo2KHR* pInfo, uint* pSparseMemoryRequirementCount, VkSparseImageMemoryRequirements2KHR* pSparseMemoryRequirements)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkImageSparseMemoryRequirementsInfo2KHR*, uint*, VkSparseImageMemoryRequirements2KHR*, void>)vkGetImageSparseMemoryRequirements2KHR_ptr)(device, pInfo, pSparseMemoryRequirementCount, pSparseMemoryRequirements);
	}

	public unsafe static void vkGetImageSparseMemoryRequirements2KHR(VkDevice device, VkImageSparseMemoryRequirementsInfo2KHR* pInfo, uint* pSparseMemoryRequirementCount, out VkSparseImageMemoryRequirements2KHR pSparseMemoryRequirements)
	{
		fixed (VkSparseImageMemoryRequirements2KHR* ptr = &pSparseMemoryRequirements)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkImageSparseMemoryRequirementsInfo2KHR*, uint*, VkSparseImageMemoryRequirements2KHR*, void>)vkGetImageSparseMemoryRequirements2KHR_ptr)(device, pInfo, pSparseMemoryRequirementCount, ptr);
		}
	}

	public unsafe static void vkGetImageSparseMemoryRequirements2KHR(VkDevice device, VkImageSparseMemoryRequirementsInfo2KHR* pInfo, ref uint pSparseMemoryRequirementCount, VkSparseImageMemoryRequirements2KHR* pSparseMemoryRequirements)
	{
		fixed (uint* ptr = &pSparseMemoryRequirementCount)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkImageSparseMemoryRequirementsInfo2KHR*, uint*, VkSparseImageMemoryRequirements2KHR*, void>)vkGetImageSparseMemoryRequirements2KHR_ptr)(device, pInfo, ptr, pSparseMemoryRequirements);
		}
	}

	public unsafe static void vkGetImageSparseMemoryRequirements2KHR(VkDevice device, VkImageSparseMemoryRequirementsInfo2KHR* pInfo, ref uint pSparseMemoryRequirementCount, out VkSparseImageMemoryRequirements2KHR pSparseMemoryRequirements)
	{
		fixed (uint* ptr = &pSparseMemoryRequirementCount)
		{
			fixed (VkSparseImageMemoryRequirements2KHR* ptr2 = &pSparseMemoryRequirements)
			{
				((delegate* unmanaged[Stdcall]<VkDevice, VkImageSparseMemoryRequirementsInfo2KHR*, uint*, VkSparseImageMemoryRequirements2KHR*, void>)vkGetImageSparseMemoryRequirements2KHR_ptr)(device, pInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static void vkGetImageSparseMemoryRequirements2KHR(VkDevice device, VkImageSparseMemoryRequirementsInfo2KHR* pInfo, IntPtr pSparseMemoryRequirementCount, VkSparseImageMemoryRequirements2KHR* pSparseMemoryRequirements)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkImageSparseMemoryRequirementsInfo2KHR*, IntPtr, VkSparseImageMemoryRequirements2KHR*, void>)vkGetImageSparseMemoryRequirements2KHR_ptr)(device, pInfo, pSparseMemoryRequirementCount, pSparseMemoryRequirements);
	}

	public unsafe static void vkGetImageSparseMemoryRequirements2KHR(VkDevice device, VkImageSparseMemoryRequirementsInfo2KHR* pInfo, IntPtr pSparseMemoryRequirementCount, out VkSparseImageMemoryRequirements2KHR pSparseMemoryRequirements)
	{
		fixed (VkSparseImageMemoryRequirements2KHR* ptr = &pSparseMemoryRequirements)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkImageSparseMemoryRequirementsInfo2KHR*, IntPtr, VkSparseImageMemoryRequirements2KHR*, void>)vkGetImageSparseMemoryRequirements2KHR_ptr)(device, pInfo, pSparseMemoryRequirementCount, ptr);
		}
	}

	public unsafe static void vkGetImageSparseMemoryRequirements2KHR(VkDevice device, ref VkImageSparseMemoryRequirementsInfo2KHR pInfo, uint* pSparseMemoryRequirementCount, VkSparseImageMemoryRequirements2KHR* pSparseMemoryRequirements)
	{
		fixed (VkImageSparseMemoryRequirementsInfo2KHR* ptr = &pInfo)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkImageSparseMemoryRequirementsInfo2KHR*, uint*, VkSparseImageMemoryRequirements2KHR*, void>)vkGetImageSparseMemoryRequirements2KHR_ptr)(device, ptr, pSparseMemoryRequirementCount, pSparseMemoryRequirements);
		}
	}

	public unsafe static void vkGetImageSparseMemoryRequirements2KHR(VkDevice device, ref VkImageSparseMemoryRequirementsInfo2KHR pInfo, uint* pSparseMemoryRequirementCount, out VkSparseImageMemoryRequirements2KHR pSparseMemoryRequirements)
	{
		fixed (VkImageSparseMemoryRequirementsInfo2KHR* ptr = &pInfo)
		{
			fixed (VkSparseImageMemoryRequirements2KHR* ptr2 = &pSparseMemoryRequirements)
			{
				((delegate* unmanaged[Stdcall]<VkDevice, VkImageSparseMemoryRequirementsInfo2KHR*, uint*, VkSparseImageMemoryRequirements2KHR*, void>)vkGetImageSparseMemoryRequirements2KHR_ptr)(device, ptr, pSparseMemoryRequirementCount, ptr2);
			}
		}
	}

	public unsafe static void vkGetImageSparseMemoryRequirements2KHR(VkDevice device, ref VkImageSparseMemoryRequirementsInfo2KHR pInfo, ref uint pSparseMemoryRequirementCount, VkSparseImageMemoryRequirements2KHR* pSparseMemoryRequirements)
	{
		fixed (VkImageSparseMemoryRequirementsInfo2KHR* ptr = &pInfo)
		{
			fixed (uint* ptr2 = &pSparseMemoryRequirementCount)
			{
				((delegate* unmanaged[Stdcall]<VkDevice, VkImageSparseMemoryRequirementsInfo2KHR*, uint*, VkSparseImageMemoryRequirements2KHR*, void>)vkGetImageSparseMemoryRequirements2KHR_ptr)(device, ptr, ptr2, pSparseMemoryRequirements);
			}
		}
	}

	public unsafe static void vkGetImageSparseMemoryRequirements2KHR(VkDevice device, ref VkImageSparseMemoryRequirementsInfo2KHR pInfo, ref uint pSparseMemoryRequirementCount, out VkSparseImageMemoryRequirements2KHR pSparseMemoryRequirements)
	{
		fixed (VkImageSparseMemoryRequirementsInfo2KHR* ptr = &pInfo)
		{
			fixed (uint* ptr2 = &pSparseMemoryRequirementCount)
			{
				fixed (VkSparseImageMemoryRequirements2KHR* ptr3 = &pSparseMemoryRequirements)
				{
					((delegate* unmanaged[Stdcall]<VkDevice, VkImageSparseMemoryRequirementsInfo2KHR*, uint*, VkSparseImageMemoryRequirements2KHR*, void>)vkGetImageSparseMemoryRequirements2KHR_ptr)(device, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static void vkGetImageSparseMemoryRequirements2KHR(VkDevice device, ref VkImageSparseMemoryRequirementsInfo2KHR pInfo, IntPtr pSparseMemoryRequirementCount, VkSparseImageMemoryRequirements2KHR* pSparseMemoryRequirements)
	{
		fixed (VkImageSparseMemoryRequirementsInfo2KHR* ptr = &pInfo)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkImageSparseMemoryRequirementsInfo2KHR*, IntPtr, VkSparseImageMemoryRequirements2KHR*, void>)vkGetImageSparseMemoryRequirements2KHR_ptr)(device, ptr, pSparseMemoryRequirementCount, pSparseMemoryRequirements);
		}
	}

	public unsafe static void vkGetImageSparseMemoryRequirements2KHR(VkDevice device, ref VkImageSparseMemoryRequirementsInfo2KHR pInfo, IntPtr pSparseMemoryRequirementCount, out VkSparseImageMemoryRequirements2KHR pSparseMemoryRequirements)
	{
		fixed (VkImageSparseMemoryRequirementsInfo2KHR* ptr = &pInfo)
		{
			fixed (VkSparseImageMemoryRequirements2KHR* ptr2 = &pSparseMemoryRequirements)
			{
				((delegate* unmanaged[Stdcall]<VkDevice, VkImageSparseMemoryRequirementsInfo2KHR*, IntPtr, VkSparseImageMemoryRequirements2KHR*, void>)vkGetImageSparseMemoryRequirements2KHR_ptr)(device, ptr, pSparseMemoryRequirementCount, ptr2);
			}
		}
	}

	public unsafe static void vkGetImageSparseMemoryRequirements2KHR(VkDevice device, IntPtr pInfo, uint* pSparseMemoryRequirementCount, VkSparseImageMemoryRequirements2KHR* pSparseMemoryRequirements)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, uint*, VkSparseImageMemoryRequirements2KHR*, void>)vkGetImageSparseMemoryRequirements2KHR_ptr)(device, pInfo, pSparseMemoryRequirementCount, pSparseMemoryRequirements);
	}

	public unsafe static void vkGetImageSparseMemoryRequirements2KHR(VkDevice device, IntPtr pInfo, uint* pSparseMemoryRequirementCount, out VkSparseImageMemoryRequirements2KHR pSparseMemoryRequirements)
	{
		fixed (VkSparseImageMemoryRequirements2KHR* ptr = &pSparseMemoryRequirements)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, uint*, VkSparseImageMemoryRequirements2KHR*, void>)vkGetImageSparseMemoryRequirements2KHR_ptr)(device, pInfo, pSparseMemoryRequirementCount, ptr);
		}
	}

	public unsafe static void vkGetImageSparseMemoryRequirements2KHR(VkDevice device, IntPtr pInfo, ref uint pSparseMemoryRequirementCount, VkSparseImageMemoryRequirements2KHR* pSparseMemoryRequirements)
	{
		fixed (uint* ptr = &pSparseMemoryRequirementCount)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, uint*, VkSparseImageMemoryRequirements2KHR*, void>)vkGetImageSparseMemoryRequirements2KHR_ptr)(device, pInfo, ptr, pSparseMemoryRequirements);
		}
	}

	public unsafe static void vkGetImageSparseMemoryRequirements2KHR(VkDevice device, IntPtr pInfo, ref uint pSparseMemoryRequirementCount, out VkSparseImageMemoryRequirements2KHR pSparseMemoryRequirements)
	{
		fixed (uint* ptr = &pSparseMemoryRequirementCount)
		{
			fixed (VkSparseImageMemoryRequirements2KHR* ptr2 = &pSparseMemoryRequirements)
			{
				((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, uint*, VkSparseImageMemoryRequirements2KHR*, void>)vkGetImageSparseMemoryRequirements2KHR_ptr)(device, pInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static void vkGetImageSparseMemoryRequirements2KHR(VkDevice device, IntPtr pInfo, IntPtr pSparseMemoryRequirementCount, VkSparseImageMemoryRequirements2KHR* pSparseMemoryRequirements)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkSparseImageMemoryRequirements2KHR*, void>)vkGetImageSparseMemoryRequirements2KHR_ptr)(device, pInfo, pSparseMemoryRequirementCount, pSparseMemoryRequirements);
	}

	public unsafe static void vkGetImageSparseMemoryRequirements2KHR(VkDevice device, IntPtr pInfo, IntPtr pSparseMemoryRequirementCount, out VkSparseImageMemoryRequirements2KHR pSparseMemoryRequirements)
	{
		fixed (VkSparseImageMemoryRequirements2KHR* ptr = &pSparseMemoryRequirements)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkSparseImageMemoryRequirements2KHR*, void>)vkGetImageSparseMemoryRequirements2KHR_ptr)(device, pInfo, pSparseMemoryRequirementCount, ptr);
		}
	}

	public unsafe static void vkGetImageSubresourceLayout(VkDevice device, VkImage image, VkImageSubresource* pSubresource, VkSubresourceLayout* pLayout)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkImage, VkImageSubresource*, VkSubresourceLayout*, void>)vkGetImageSubresourceLayout_ptr)(device, image, pSubresource, pLayout);
	}

	public unsafe static void vkGetImageSubresourceLayout(VkDevice device, VkImage image, VkImageSubresource* pSubresource, out VkSubresourceLayout pLayout)
	{
		fixed (VkSubresourceLayout* ptr = &pLayout)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkImage, VkImageSubresource*, VkSubresourceLayout*, void>)vkGetImageSubresourceLayout_ptr)(device, image, pSubresource, ptr);
		}
	}

	public unsafe static void vkGetImageSubresourceLayout(VkDevice device, VkImage image, ref VkImageSubresource pSubresource, VkSubresourceLayout* pLayout)
	{
		fixed (VkImageSubresource* ptr = &pSubresource)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkImage, VkImageSubresource*, VkSubresourceLayout*, void>)vkGetImageSubresourceLayout_ptr)(device, image, ptr, pLayout);
		}
	}

	public unsafe static void vkGetImageSubresourceLayout(VkDevice device, VkImage image, ref VkImageSubresource pSubresource, out VkSubresourceLayout pLayout)
	{
		fixed (VkImageSubresource* ptr = &pSubresource)
		{
			fixed (VkSubresourceLayout* ptr2 = &pLayout)
			{
				((delegate* unmanaged[Stdcall]<VkDevice, VkImage, VkImageSubresource*, VkSubresourceLayout*, void>)vkGetImageSubresourceLayout_ptr)(device, image, ptr, ptr2);
			}
		}
	}

	public unsafe static void vkGetImageSubresourceLayout(VkDevice device, VkImage image, IntPtr pSubresource, VkSubresourceLayout* pLayout)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkImage, IntPtr, VkSubresourceLayout*, void>)vkGetImageSubresourceLayout_ptr)(device, image, pSubresource, pLayout);
	}

	public unsafe static void vkGetImageSubresourceLayout(VkDevice device, VkImage image, IntPtr pSubresource, out VkSubresourceLayout pLayout)
	{
		fixed (VkSubresourceLayout* ptr = &pLayout)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkImage, IntPtr, VkSubresourceLayout*, void>)vkGetImageSubresourceLayout_ptr)(device, image, pSubresource, ptr);
		}
	}

	public unsafe static IntPtr vkGetInstanceProcAddr(VkInstance instance, byte* pName)
	{
		return ((delegate* unmanaged[Stdcall]<VkInstance, byte*, IntPtr>)vkGetInstanceProcAddr_ptr)(instance, pName);
	}

	public unsafe static IntPtr vkGetInstanceProcAddr(VkInstance instance, out byte pName)
	{
		fixed (byte* ptr = &pName)
		{
			return ((delegate* unmanaged[Stdcall]<VkInstance, byte*, IntPtr>)vkGetInstanceProcAddr_ptr)(instance, ptr);
		}
	}

	public unsafe static VkResult vkGetMemoryFdKHR(VkDevice device, VkMemoryGetFdInfoKHR* pGetFdInfo, int* pFd)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkMemoryGetFdInfoKHR*, int*, VkResult>)vkGetMemoryFdKHR_ptr)(device, pGetFdInfo, pFd);
	}

	public unsafe static VkResult vkGetMemoryFdKHR(VkDevice device, VkMemoryGetFdInfoKHR* pGetFdInfo, out int pFd)
	{
		fixed (int* ptr = &pFd)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkMemoryGetFdInfoKHR*, int*, VkResult>)vkGetMemoryFdKHR_ptr)(device, pGetFdInfo, ptr);
		}
	}

	public unsafe static VkResult vkGetMemoryFdKHR(VkDevice device, ref VkMemoryGetFdInfoKHR pGetFdInfo, int* pFd)
	{
		fixed (VkMemoryGetFdInfoKHR* ptr = &pGetFdInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkMemoryGetFdInfoKHR*, int*, VkResult>)vkGetMemoryFdKHR_ptr)(device, ptr, pFd);
		}
	}

	public unsafe static VkResult vkGetMemoryFdKHR(VkDevice device, ref VkMemoryGetFdInfoKHR pGetFdInfo, out int pFd)
	{
		fixed (VkMemoryGetFdInfoKHR* ptr = &pGetFdInfo)
		{
			fixed (int* ptr2 = &pFd)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkMemoryGetFdInfoKHR*, int*, VkResult>)vkGetMemoryFdKHR_ptr)(device, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkGetMemoryFdKHR(VkDevice device, IntPtr pGetFdInfo, int* pFd)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, int*, VkResult>)vkGetMemoryFdKHR_ptr)(device, pGetFdInfo, pFd);
	}

	public unsafe static VkResult vkGetMemoryFdKHR(VkDevice device, IntPtr pGetFdInfo, out int pFd)
	{
		fixed (int* ptr = &pFd)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, int*, VkResult>)vkGetMemoryFdKHR_ptr)(device, pGetFdInfo, ptr);
		}
	}

	public unsafe static VkResult vkGetMemoryFdPropertiesKHR(VkDevice device, VkExternalMemoryHandleTypeFlagsKHR handleType, int fd, VkMemoryFdPropertiesKHR* pMemoryFdProperties)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkExternalMemoryHandleTypeFlagsKHR, int, VkMemoryFdPropertiesKHR*, VkResult>)vkGetMemoryFdPropertiesKHR_ptr)(device, handleType, fd, pMemoryFdProperties);
	}

	public unsafe static VkResult vkGetMemoryFdPropertiesKHR(VkDevice device, VkExternalMemoryHandleTypeFlagsKHR handleType, int fd, out VkMemoryFdPropertiesKHR pMemoryFdProperties)
	{
		fixed (VkMemoryFdPropertiesKHR* ptr = &pMemoryFdProperties)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkExternalMemoryHandleTypeFlagsKHR, int, VkMemoryFdPropertiesKHR*, VkResult>)vkGetMemoryFdPropertiesKHR_ptr)(device, handleType, fd, ptr);
		}
	}

	public unsafe static VkResult vkGetMemoryHostPointerPropertiesEXT(VkDevice device, VkExternalMemoryHandleTypeFlagsKHR handleType, void* pHostPointer, VkMemoryHostPointerPropertiesEXT* pMemoryHostPointerProperties)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkExternalMemoryHandleTypeFlagsKHR, void*, VkMemoryHostPointerPropertiesEXT*, VkResult>)vkGetMemoryHostPointerPropertiesEXT_ptr)(device, handleType, pHostPointer, pMemoryHostPointerProperties);
	}

	public unsafe static VkResult vkGetMemoryHostPointerPropertiesEXT(VkDevice device, VkExternalMemoryHandleTypeFlagsKHR handleType, void* pHostPointer, out VkMemoryHostPointerPropertiesEXT pMemoryHostPointerProperties)
	{
		fixed (VkMemoryHostPointerPropertiesEXT* ptr = &pMemoryHostPointerProperties)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkExternalMemoryHandleTypeFlagsKHR, void*, VkMemoryHostPointerPropertiesEXT*, VkResult>)vkGetMemoryHostPointerPropertiesEXT_ptr)(device, handleType, pHostPointer, ptr);
		}
	}

	public unsafe static VkResult vkGetMemoryWin32HandleKHR(VkDevice device, VkMemoryGetWin32HandleInfoKHR* pGetWin32HandleInfo, HANDLE* pHandle)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkMemoryGetWin32HandleInfoKHR*, HANDLE*, VkResult>)vkGetMemoryWin32HandleKHR_ptr)(device, pGetWin32HandleInfo, pHandle);
	}

	public unsafe static VkResult vkGetMemoryWin32HandleKHR(VkDevice device, VkMemoryGetWin32HandleInfoKHR* pGetWin32HandleInfo, out HANDLE pHandle)
	{
		fixed (HANDLE* ptr = &pHandle)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkMemoryGetWin32HandleInfoKHR*, HANDLE*, VkResult>)vkGetMemoryWin32HandleKHR_ptr)(device, pGetWin32HandleInfo, ptr);
		}
	}

	public unsafe static VkResult vkGetMemoryWin32HandleKHR(VkDevice device, ref VkMemoryGetWin32HandleInfoKHR pGetWin32HandleInfo, HANDLE* pHandle)
	{
		fixed (VkMemoryGetWin32HandleInfoKHR* ptr = &pGetWin32HandleInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkMemoryGetWin32HandleInfoKHR*, HANDLE*, VkResult>)vkGetMemoryWin32HandleKHR_ptr)(device, ptr, pHandle);
		}
	}

	public unsafe static VkResult vkGetMemoryWin32HandleKHR(VkDevice device, ref VkMemoryGetWin32HandleInfoKHR pGetWin32HandleInfo, out HANDLE pHandle)
	{
		fixed (VkMemoryGetWin32HandleInfoKHR* ptr = &pGetWin32HandleInfo)
		{
			fixed (HANDLE* ptr2 = &pHandle)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkMemoryGetWin32HandleInfoKHR*, HANDLE*, VkResult>)vkGetMemoryWin32HandleKHR_ptr)(device, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkGetMemoryWin32HandleKHR(VkDevice device, IntPtr pGetWin32HandleInfo, HANDLE* pHandle)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, HANDLE*, VkResult>)vkGetMemoryWin32HandleKHR_ptr)(device, pGetWin32HandleInfo, pHandle);
	}

	public unsafe static VkResult vkGetMemoryWin32HandleKHR(VkDevice device, IntPtr pGetWin32HandleInfo, out HANDLE pHandle)
	{
		fixed (HANDLE* ptr = &pHandle)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, HANDLE*, VkResult>)vkGetMemoryWin32HandleKHR_ptr)(device, pGetWin32HandleInfo, ptr);
		}
	}

	public unsafe static VkResult vkGetMemoryWin32HandleNV(VkDevice device, VkDeviceMemory memory, VkExternalMemoryHandleTypeFlagsNV handleType, HANDLE* pHandle)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkDeviceMemory, VkExternalMemoryHandleTypeFlagsNV, HANDLE*, VkResult>)vkGetMemoryWin32HandleNV_ptr)(device, memory, handleType, pHandle);
	}

	public unsafe static VkResult vkGetMemoryWin32HandleNV(VkDevice device, VkDeviceMemory memory, VkExternalMemoryHandleTypeFlagsNV handleType, out HANDLE pHandle)
	{
		fixed (HANDLE* ptr = &pHandle)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDeviceMemory, VkExternalMemoryHandleTypeFlagsNV, HANDLE*, VkResult>)vkGetMemoryWin32HandleNV_ptr)(device, memory, handleType, ptr);
		}
	}

	public unsafe static VkResult vkGetMemoryWin32HandlePropertiesKHR(VkDevice device, VkExternalMemoryHandleTypeFlagsKHR handleType, HANDLE handle, VkMemoryWin32HandlePropertiesKHR* pMemoryWin32HandleProperties)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkExternalMemoryHandleTypeFlagsKHR, HANDLE, VkMemoryWin32HandlePropertiesKHR*, VkResult>)vkGetMemoryWin32HandlePropertiesKHR_ptr)(device, handleType, handle, pMemoryWin32HandleProperties);
	}

	public unsafe static VkResult vkGetMemoryWin32HandlePropertiesKHR(VkDevice device, VkExternalMemoryHandleTypeFlagsKHR handleType, HANDLE handle, out VkMemoryWin32HandlePropertiesKHR pMemoryWin32HandleProperties)
	{
		fixed (VkMemoryWin32HandlePropertiesKHR* ptr = &pMemoryWin32HandleProperties)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkExternalMemoryHandleTypeFlagsKHR, HANDLE, VkMemoryWin32HandlePropertiesKHR*, VkResult>)vkGetMemoryWin32HandlePropertiesKHR_ptr)(device, handleType, handle, ptr);
		}
	}

	public unsafe static VkResult vkGetPastPresentationTimingGOOGLE(VkDevice device, VkSwapchainKHR swapchain, uint* pPresentationTimingCount, VkPastPresentationTimingGOOGLE* pPresentationTimings)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkSwapchainKHR, uint*, VkPastPresentationTimingGOOGLE*, VkResult>)vkGetPastPresentationTimingGOOGLE_ptr)(device, swapchain, pPresentationTimingCount, pPresentationTimings);
	}

	public unsafe static VkResult vkGetPastPresentationTimingGOOGLE(VkDevice device, VkSwapchainKHR swapchain, uint* pPresentationTimingCount, out VkPastPresentationTimingGOOGLE pPresentationTimings)
	{
		fixed (VkPastPresentationTimingGOOGLE* ptr = &pPresentationTimings)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkSwapchainKHR, uint*, VkPastPresentationTimingGOOGLE*, VkResult>)vkGetPastPresentationTimingGOOGLE_ptr)(device, swapchain, pPresentationTimingCount, ptr);
		}
	}

	public unsafe static VkResult vkGetPastPresentationTimingGOOGLE(VkDevice device, VkSwapchainKHR swapchain, ref uint pPresentationTimingCount, VkPastPresentationTimingGOOGLE* pPresentationTimings)
	{
		fixed (uint* ptr = &pPresentationTimingCount)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkSwapchainKHR, uint*, VkPastPresentationTimingGOOGLE*, VkResult>)vkGetPastPresentationTimingGOOGLE_ptr)(device, swapchain, ptr, pPresentationTimings);
		}
	}

	public unsafe static VkResult vkGetPastPresentationTimingGOOGLE(VkDevice device, VkSwapchainKHR swapchain, ref uint pPresentationTimingCount, out VkPastPresentationTimingGOOGLE pPresentationTimings)
	{
		fixed (uint* ptr = &pPresentationTimingCount)
		{
			fixed (VkPastPresentationTimingGOOGLE* ptr2 = &pPresentationTimings)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkSwapchainKHR, uint*, VkPastPresentationTimingGOOGLE*, VkResult>)vkGetPastPresentationTimingGOOGLE_ptr)(device, swapchain, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkGetPastPresentationTimingGOOGLE(VkDevice device, VkSwapchainKHR swapchain, IntPtr pPresentationTimingCount, VkPastPresentationTimingGOOGLE* pPresentationTimings)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkSwapchainKHR, IntPtr, VkPastPresentationTimingGOOGLE*, VkResult>)vkGetPastPresentationTimingGOOGLE_ptr)(device, swapchain, pPresentationTimingCount, pPresentationTimings);
	}

	public unsafe static VkResult vkGetPastPresentationTimingGOOGLE(VkDevice device, VkSwapchainKHR swapchain, IntPtr pPresentationTimingCount, out VkPastPresentationTimingGOOGLE pPresentationTimings)
	{
		fixed (VkPastPresentationTimingGOOGLE* ptr = &pPresentationTimings)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkSwapchainKHR, IntPtr, VkPastPresentationTimingGOOGLE*, VkResult>)vkGetPastPresentationTimingGOOGLE_ptr)(device, swapchain, pPresentationTimingCount, ptr);
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceDisplayPlanePropertiesKHR(VkPhysicalDevice physicalDevice, uint* pPropertyCount, VkDisplayPlanePropertiesKHR* pProperties)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint*, VkDisplayPlanePropertiesKHR*, VkResult>)vkGetPhysicalDeviceDisplayPlanePropertiesKHR_ptr)(physicalDevice, pPropertyCount, pProperties);
	}

	public unsafe static VkResult vkGetPhysicalDeviceDisplayPlanePropertiesKHR(VkPhysicalDevice physicalDevice, uint* pPropertyCount, out VkDisplayPlanePropertiesKHR pProperties)
	{
		fixed (VkDisplayPlanePropertiesKHR* ptr = &pProperties)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint*, VkDisplayPlanePropertiesKHR*, VkResult>)vkGetPhysicalDeviceDisplayPlanePropertiesKHR_ptr)(physicalDevice, pPropertyCount, ptr);
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceDisplayPlanePropertiesKHR(VkPhysicalDevice physicalDevice, ref uint pPropertyCount, VkDisplayPlanePropertiesKHR* pProperties)
	{
		fixed (uint* ptr = &pPropertyCount)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint*, VkDisplayPlanePropertiesKHR*, VkResult>)vkGetPhysicalDeviceDisplayPlanePropertiesKHR_ptr)(physicalDevice, ptr, pProperties);
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceDisplayPlanePropertiesKHR(VkPhysicalDevice physicalDevice, ref uint pPropertyCount, out VkDisplayPlanePropertiesKHR pProperties)
	{
		fixed (uint* ptr = &pPropertyCount)
		{
			fixed (VkDisplayPlanePropertiesKHR* ptr2 = &pProperties)
			{
				return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint*, VkDisplayPlanePropertiesKHR*, VkResult>)vkGetPhysicalDeviceDisplayPlanePropertiesKHR_ptr)(physicalDevice, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceDisplayPlanePropertiesKHR(VkPhysicalDevice physicalDevice, IntPtr pPropertyCount, VkDisplayPlanePropertiesKHR* pProperties)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, VkDisplayPlanePropertiesKHR*, VkResult>)vkGetPhysicalDeviceDisplayPlanePropertiesKHR_ptr)(physicalDevice, pPropertyCount, pProperties);
	}

	public unsafe static VkResult vkGetPhysicalDeviceDisplayPlanePropertiesKHR(VkPhysicalDevice physicalDevice, IntPtr pPropertyCount, out VkDisplayPlanePropertiesKHR pProperties)
	{
		fixed (VkDisplayPlanePropertiesKHR* ptr = &pProperties)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, VkDisplayPlanePropertiesKHR*, VkResult>)vkGetPhysicalDeviceDisplayPlanePropertiesKHR_ptr)(physicalDevice, pPropertyCount, ptr);
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceDisplayPropertiesKHR(VkPhysicalDevice physicalDevice, uint* pPropertyCount, VkDisplayPropertiesKHR* pProperties)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint*, VkDisplayPropertiesKHR*, VkResult>)vkGetPhysicalDeviceDisplayPropertiesKHR_ptr)(physicalDevice, pPropertyCount, pProperties);
	}

	public unsafe static VkResult vkGetPhysicalDeviceDisplayPropertiesKHR(VkPhysicalDevice physicalDevice, uint* pPropertyCount, out VkDisplayPropertiesKHR pProperties)
	{
		fixed (VkDisplayPropertiesKHR* ptr = &pProperties)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint*, VkDisplayPropertiesKHR*, VkResult>)vkGetPhysicalDeviceDisplayPropertiesKHR_ptr)(physicalDevice, pPropertyCount, ptr);
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceDisplayPropertiesKHR(VkPhysicalDevice physicalDevice, ref uint pPropertyCount, VkDisplayPropertiesKHR* pProperties)
	{
		fixed (uint* ptr = &pPropertyCount)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint*, VkDisplayPropertiesKHR*, VkResult>)vkGetPhysicalDeviceDisplayPropertiesKHR_ptr)(physicalDevice, ptr, pProperties);
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceDisplayPropertiesKHR(VkPhysicalDevice physicalDevice, ref uint pPropertyCount, out VkDisplayPropertiesKHR pProperties)
	{
		fixed (uint* ptr = &pPropertyCount)
		{
			fixed (VkDisplayPropertiesKHR* ptr2 = &pProperties)
			{
				return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint*, VkDisplayPropertiesKHR*, VkResult>)vkGetPhysicalDeviceDisplayPropertiesKHR_ptr)(physicalDevice, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceDisplayPropertiesKHR(VkPhysicalDevice physicalDevice, IntPtr pPropertyCount, VkDisplayPropertiesKHR* pProperties)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, VkDisplayPropertiesKHR*, VkResult>)vkGetPhysicalDeviceDisplayPropertiesKHR_ptr)(physicalDevice, pPropertyCount, pProperties);
	}

	public unsafe static VkResult vkGetPhysicalDeviceDisplayPropertiesKHR(VkPhysicalDevice physicalDevice, IntPtr pPropertyCount, out VkDisplayPropertiesKHR pProperties)
	{
		fixed (VkDisplayPropertiesKHR* ptr = &pProperties)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, VkDisplayPropertiesKHR*, VkResult>)vkGetPhysicalDeviceDisplayPropertiesKHR_ptr)(physicalDevice, pPropertyCount, ptr);
		}
	}

	public unsafe static void vkGetPhysicalDeviceExternalBufferPropertiesKHR(VkPhysicalDevice physicalDevice, VkPhysicalDeviceExternalBufferInfoKHR* pExternalBufferInfo, VkExternalBufferPropertiesKHR* pExternalBufferProperties)
	{
		((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceExternalBufferInfoKHR*, VkExternalBufferPropertiesKHR*, void>)vkGetPhysicalDeviceExternalBufferPropertiesKHR_ptr)(physicalDevice, pExternalBufferInfo, pExternalBufferProperties);
	}

	public unsafe static void vkGetPhysicalDeviceExternalBufferPropertiesKHR(VkPhysicalDevice physicalDevice, VkPhysicalDeviceExternalBufferInfoKHR* pExternalBufferInfo, out VkExternalBufferPropertiesKHR pExternalBufferProperties)
	{
		fixed (VkExternalBufferPropertiesKHR* ptr = &pExternalBufferProperties)
		{
			((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceExternalBufferInfoKHR*, VkExternalBufferPropertiesKHR*, void>)vkGetPhysicalDeviceExternalBufferPropertiesKHR_ptr)(physicalDevice, pExternalBufferInfo, ptr);
		}
	}

	public unsafe static void vkGetPhysicalDeviceExternalBufferPropertiesKHR(VkPhysicalDevice physicalDevice, ref VkPhysicalDeviceExternalBufferInfoKHR pExternalBufferInfo, VkExternalBufferPropertiesKHR* pExternalBufferProperties)
	{
		fixed (VkPhysicalDeviceExternalBufferInfoKHR* ptr = &pExternalBufferInfo)
		{
			((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceExternalBufferInfoKHR*, VkExternalBufferPropertiesKHR*, void>)vkGetPhysicalDeviceExternalBufferPropertiesKHR_ptr)(physicalDevice, ptr, pExternalBufferProperties);
		}
	}

	public unsafe static void vkGetPhysicalDeviceExternalBufferPropertiesKHR(VkPhysicalDevice physicalDevice, ref VkPhysicalDeviceExternalBufferInfoKHR pExternalBufferInfo, out VkExternalBufferPropertiesKHR pExternalBufferProperties)
	{
		fixed (VkPhysicalDeviceExternalBufferInfoKHR* ptr = &pExternalBufferInfo)
		{
			fixed (VkExternalBufferPropertiesKHR* ptr2 = &pExternalBufferProperties)
			{
				((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceExternalBufferInfoKHR*, VkExternalBufferPropertiesKHR*, void>)vkGetPhysicalDeviceExternalBufferPropertiesKHR_ptr)(physicalDevice, ptr, ptr2);
			}
		}
	}

	public unsafe static void vkGetPhysicalDeviceExternalBufferPropertiesKHR(VkPhysicalDevice physicalDevice, IntPtr pExternalBufferInfo, VkExternalBufferPropertiesKHR* pExternalBufferProperties)
	{
		((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, VkExternalBufferPropertiesKHR*, void>)vkGetPhysicalDeviceExternalBufferPropertiesKHR_ptr)(physicalDevice, pExternalBufferInfo, pExternalBufferProperties);
	}

	public unsafe static void vkGetPhysicalDeviceExternalBufferPropertiesKHR(VkPhysicalDevice physicalDevice, IntPtr pExternalBufferInfo, out VkExternalBufferPropertiesKHR pExternalBufferProperties)
	{
		fixed (VkExternalBufferPropertiesKHR* ptr = &pExternalBufferProperties)
		{
			((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, VkExternalBufferPropertiesKHR*, void>)vkGetPhysicalDeviceExternalBufferPropertiesKHR_ptr)(physicalDevice, pExternalBufferInfo, ptr);
		}
	}

	public unsafe static void vkGetPhysicalDeviceExternalFencePropertiesKHR(VkPhysicalDevice physicalDevice, VkPhysicalDeviceExternalFenceInfoKHR* pExternalFenceInfo, VkExternalFencePropertiesKHR* pExternalFenceProperties)
	{
		((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceExternalFenceInfoKHR*, VkExternalFencePropertiesKHR*, void>)vkGetPhysicalDeviceExternalFencePropertiesKHR_ptr)(physicalDevice, pExternalFenceInfo, pExternalFenceProperties);
	}

	public unsafe static void vkGetPhysicalDeviceExternalFencePropertiesKHR(VkPhysicalDevice physicalDevice, VkPhysicalDeviceExternalFenceInfoKHR* pExternalFenceInfo, out VkExternalFencePropertiesKHR pExternalFenceProperties)
	{
		fixed (VkExternalFencePropertiesKHR* ptr = &pExternalFenceProperties)
		{
			((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceExternalFenceInfoKHR*, VkExternalFencePropertiesKHR*, void>)vkGetPhysicalDeviceExternalFencePropertiesKHR_ptr)(physicalDevice, pExternalFenceInfo, ptr);
		}
	}

	public unsafe static void vkGetPhysicalDeviceExternalFencePropertiesKHR(VkPhysicalDevice physicalDevice, ref VkPhysicalDeviceExternalFenceInfoKHR pExternalFenceInfo, VkExternalFencePropertiesKHR* pExternalFenceProperties)
	{
		fixed (VkPhysicalDeviceExternalFenceInfoKHR* ptr = &pExternalFenceInfo)
		{
			((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceExternalFenceInfoKHR*, VkExternalFencePropertiesKHR*, void>)vkGetPhysicalDeviceExternalFencePropertiesKHR_ptr)(physicalDevice, ptr, pExternalFenceProperties);
		}
	}

	public unsafe static void vkGetPhysicalDeviceExternalFencePropertiesKHR(VkPhysicalDevice physicalDevice, ref VkPhysicalDeviceExternalFenceInfoKHR pExternalFenceInfo, out VkExternalFencePropertiesKHR pExternalFenceProperties)
	{
		fixed (VkPhysicalDeviceExternalFenceInfoKHR* ptr = &pExternalFenceInfo)
		{
			fixed (VkExternalFencePropertiesKHR* ptr2 = &pExternalFenceProperties)
			{
				((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceExternalFenceInfoKHR*, VkExternalFencePropertiesKHR*, void>)vkGetPhysicalDeviceExternalFencePropertiesKHR_ptr)(physicalDevice, ptr, ptr2);
			}
		}
	}

	public unsafe static void vkGetPhysicalDeviceExternalFencePropertiesKHR(VkPhysicalDevice physicalDevice, IntPtr pExternalFenceInfo, VkExternalFencePropertiesKHR* pExternalFenceProperties)
	{
		((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, VkExternalFencePropertiesKHR*, void>)vkGetPhysicalDeviceExternalFencePropertiesKHR_ptr)(physicalDevice, pExternalFenceInfo, pExternalFenceProperties);
	}

	public unsafe static void vkGetPhysicalDeviceExternalFencePropertiesKHR(VkPhysicalDevice physicalDevice, IntPtr pExternalFenceInfo, out VkExternalFencePropertiesKHR pExternalFenceProperties)
	{
		fixed (VkExternalFencePropertiesKHR* ptr = &pExternalFenceProperties)
		{
			((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, VkExternalFencePropertiesKHR*, void>)vkGetPhysicalDeviceExternalFencePropertiesKHR_ptr)(physicalDevice, pExternalFenceInfo, ptr);
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceExternalImageFormatPropertiesNV(VkPhysicalDevice physicalDevice, VkFormat format, VkImageType type, VkImageTiling tiling, VkImageUsageFlags usage, VkImageCreateFlags flags, VkExternalMemoryHandleTypeFlagsNV externalHandleType, VkExternalImageFormatPropertiesNV* pExternalImageFormatProperties)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkFormat, VkImageType, VkImageTiling, VkImageUsageFlags, VkImageCreateFlags, VkExternalMemoryHandleTypeFlagsNV, VkExternalImageFormatPropertiesNV*, VkResult>)vkGetPhysicalDeviceExternalImageFormatPropertiesNV_ptr)(physicalDevice, format, type, tiling, usage, flags, externalHandleType, pExternalImageFormatProperties);
	}

	public unsafe static VkResult vkGetPhysicalDeviceExternalImageFormatPropertiesNV(VkPhysicalDevice physicalDevice, VkFormat format, VkImageType type, VkImageTiling tiling, VkImageUsageFlags usage, VkImageCreateFlags flags, VkExternalMemoryHandleTypeFlagsNV externalHandleType, out VkExternalImageFormatPropertiesNV pExternalImageFormatProperties)
	{
		fixed (VkExternalImageFormatPropertiesNV* ptr = &pExternalImageFormatProperties)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkFormat, VkImageType, VkImageTiling, VkImageUsageFlags, VkImageCreateFlags, VkExternalMemoryHandleTypeFlagsNV, VkExternalImageFormatPropertiesNV*, VkResult>)vkGetPhysicalDeviceExternalImageFormatPropertiesNV_ptr)(physicalDevice, format, type, tiling, usage, flags, externalHandleType, ptr);
		}
	}

	public unsafe static void vkGetPhysicalDeviceExternalSemaphorePropertiesKHR(VkPhysicalDevice physicalDevice, VkPhysicalDeviceExternalSemaphoreInfoKHR* pExternalSemaphoreInfo, VkExternalSemaphorePropertiesKHR* pExternalSemaphoreProperties)
	{
		((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceExternalSemaphoreInfoKHR*, VkExternalSemaphorePropertiesKHR*, void>)vkGetPhysicalDeviceExternalSemaphorePropertiesKHR_ptr)(physicalDevice, pExternalSemaphoreInfo, pExternalSemaphoreProperties);
	}

	public unsafe static void vkGetPhysicalDeviceExternalSemaphorePropertiesKHR(VkPhysicalDevice physicalDevice, VkPhysicalDeviceExternalSemaphoreInfoKHR* pExternalSemaphoreInfo, out VkExternalSemaphorePropertiesKHR pExternalSemaphoreProperties)
	{
		fixed (VkExternalSemaphorePropertiesKHR* ptr = &pExternalSemaphoreProperties)
		{
			((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceExternalSemaphoreInfoKHR*, VkExternalSemaphorePropertiesKHR*, void>)vkGetPhysicalDeviceExternalSemaphorePropertiesKHR_ptr)(physicalDevice, pExternalSemaphoreInfo, ptr);
		}
	}

	public unsafe static void vkGetPhysicalDeviceExternalSemaphorePropertiesKHR(VkPhysicalDevice physicalDevice, ref VkPhysicalDeviceExternalSemaphoreInfoKHR pExternalSemaphoreInfo, VkExternalSemaphorePropertiesKHR* pExternalSemaphoreProperties)
	{
		fixed (VkPhysicalDeviceExternalSemaphoreInfoKHR* ptr = &pExternalSemaphoreInfo)
		{
			((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceExternalSemaphoreInfoKHR*, VkExternalSemaphorePropertiesKHR*, void>)vkGetPhysicalDeviceExternalSemaphorePropertiesKHR_ptr)(physicalDevice, ptr, pExternalSemaphoreProperties);
		}
	}

	public unsafe static void vkGetPhysicalDeviceExternalSemaphorePropertiesKHR(VkPhysicalDevice physicalDevice, ref VkPhysicalDeviceExternalSemaphoreInfoKHR pExternalSemaphoreInfo, out VkExternalSemaphorePropertiesKHR pExternalSemaphoreProperties)
	{
		fixed (VkPhysicalDeviceExternalSemaphoreInfoKHR* ptr = &pExternalSemaphoreInfo)
		{
			fixed (VkExternalSemaphorePropertiesKHR* ptr2 = &pExternalSemaphoreProperties)
			{
				((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceExternalSemaphoreInfoKHR*, VkExternalSemaphorePropertiesKHR*, void>)vkGetPhysicalDeviceExternalSemaphorePropertiesKHR_ptr)(physicalDevice, ptr, ptr2);
			}
		}
	}

	public unsafe static void vkGetPhysicalDeviceExternalSemaphorePropertiesKHR(VkPhysicalDevice physicalDevice, IntPtr pExternalSemaphoreInfo, VkExternalSemaphorePropertiesKHR* pExternalSemaphoreProperties)
	{
		((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, VkExternalSemaphorePropertiesKHR*, void>)vkGetPhysicalDeviceExternalSemaphorePropertiesKHR_ptr)(physicalDevice, pExternalSemaphoreInfo, pExternalSemaphoreProperties);
	}

	public unsafe static void vkGetPhysicalDeviceExternalSemaphorePropertiesKHR(VkPhysicalDevice physicalDevice, IntPtr pExternalSemaphoreInfo, out VkExternalSemaphorePropertiesKHR pExternalSemaphoreProperties)
	{
		fixed (VkExternalSemaphorePropertiesKHR* ptr = &pExternalSemaphoreProperties)
		{
			((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, VkExternalSemaphorePropertiesKHR*, void>)vkGetPhysicalDeviceExternalSemaphorePropertiesKHR_ptr)(physicalDevice, pExternalSemaphoreInfo, ptr);
		}
	}

	public unsafe static void vkGetPhysicalDeviceFeatures(VkPhysicalDevice physicalDevice, VkPhysicalDeviceFeatures* pFeatures)
	{
		((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceFeatures*, void>)vkGetPhysicalDeviceFeatures_ptr)(physicalDevice, pFeatures);
	}

	public unsafe static void vkGetPhysicalDeviceFeatures(VkPhysicalDevice physicalDevice, out VkPhysicalDeviceFeatures pFeatures)
	{
		fixed (VkPhysicalDeviceFeatures* ptr = &pFeatures)
		{
			((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceFeatures*, void>)vkGetPhysicalDeviceFeatures_ptr)(physicalDevice, ptr);
		}
	}

	public unsafe static void vkGetPhysicalDeviceFeatures2KHR(VkPhysicalDevice physicalDevice, VkPhysicalDeviceFeatures2KHR* pFeatures)
	{
		((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceFeatures2KHR*, void>)vkGetPhysicalDeviceFeatures2KHR_ptr)(physicalDevice, pFeatures);
	}

	public unsafe static void vkGetPhysicalDeviceFeatures2KHR(VkPhysicalDevice physicalDevice, out VkPhysicalDeviceFeatures2KHR pFeatures)
	{
		fixed (VkPhysicalDeviceFeatures2KHR* ptr = &pFeatures)
		{
			((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceFeatures2KHR*, void>)vkGetPhysicalDeviceFeatures2KHR_ptr)(physicalDevice, ptr);
		}
	}

	public unsafe static void vkGetPhysicalDeviceFormatProperties(VkPhysicalDevice physicalDevice, VkFormat format, VkFormatProperties* pFormatProperties)
	{
		((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkFormat, VkFormatProperties*, void>)vkGetPhysicalDeviceFormatProperties_ptr)(physicalDevice, format, pFormatProperties);
	}

	public unsafe static void vkGetPhysicalDeviceFormatProperties(VkPhysicalDevice physicalDevice, VkFormat format, out VkFormatProperties pFormatProperties)
	{
		fixed (VkFormatProperties* ptr = &pFormatProperties)
		{
			((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkFormat, VkFormatProperties*, void>)vkGetPhysicalDeviceFormatProperties_ptr)(physicalDevice, format, ptr);
		}
	}

	public unsafe static void vkGetPhysicalDeviceFormatProperties2KHR(VkPhysicalDevice physicalDevice, VkFormat format, VkFormatProperties2KHR* pFormatProperties)
	{
		((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkFormat, VkFormatProperties2KHR*, void>)vkGetPhysicalDeviceFormatProperties2KHR_ptr)(physicalDevice, format, pFormatProperties);
	}

	public unsafe static void vkGetPhysicalDeviceFormatProperties2KHR(VkPhysicalDevice physicalDevice, VkFormat format, out VkFormatProperties2KHR pFormatProperties)
	{
		fixed (VkFormatProperties2KHR* ptr = &pFormatProperties)
		{
			((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkFormat, VkFormatProperties2KHR*, void>)vkGetPhysicalDeviceFormatProperties2KHR_ptr)(physicalDevice, format, ptr);
		}
	}

	public unsafe static void vkGetPhysicalDeviceGeneratedCommandsPropertiesNVX(VkPhysicalDevice physicalDevice, VkDeviceGeneratedCommandsFeaturesNVX* pFeatures, VkDeviceGeneratedCommandsLimitsNVX* pLimits)
	{
		((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDeviceGeneratedCommandsFeaturesNVX*, VkDeviceGeneratedCommandsLimitsNVX*, void>)vkGetPhysicalDeviceGeneratedCommandsPropertiesNVX_ptr)(physicalDevice, pFeatures, pLimits);
	}

	public unsafe static void vkGetPhysicalDeviceGeneratedCommandsPropertiesNVX(VkPhysicalDevice physicalDevice, VkDeviceGeneratedCommandsFeaturesNVX* pFeatures, out VkDeviceGeneratedCommandsLimitsNVX pLimits)
	{
		fixed (VkDeviceGeneratedCommandsLimitsNVX* ptr = &pLimits)
		{
			((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDeviceGeneratedCommandsFeaturesNVX*, VkDeviceGeneratedCommandsLimitsNVX*, void>)vkGetPhysicalDeviceGeneratedCommandsPropertiesNVX_ptr)(physicalDevice, pFeatures, ptr);
		}
	}

	public unsafe static void vkGetPhysicalDeviceGeneratedCommandsPropertiesNVX(VkPhysicalDevice physicalDevice, ref VkDeviceGeneratedCommandsFeaturesNVX pFeatures, VkDeviceGeneratedCommandsLimitsNVX* pLimits)
	{
		fixed (VkDeviceGeneratedCommandsFeaturesNVX* ptr = &pFeatures)
		{
			((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDeviceGeneratedCommandsFeaturesNVX*, VkDeviceGeneratedCommandsLimitsNVX*, void>)vkGetPhysicalDeviceGeneratedCommandsPropertiesNVX_ptr)(physicalDevice, ptr, pLimits);
		}
	}

	public unsafe static void vkGetPhysicalDeviceGeneratedCommandsPropertiesNVX(VkPhysicalDevice physicalDevice, ref VkDeviceGeneratedCommandsFeaturesNVX pFeatures, out VkDeviceGeneratedCommandsLimitsNVX pLimits)
	{
		fixed (VkDeviceGeneratedCommandsFeaturesNVX* ptr = &pFeatures)
		{
			fixed (VkDeviceGeneratedCommandsLimitsNVX* ptr2 = &pLimits)
			{
				((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDeviceGeneratedCommandsFeaturesNVX*, VkDeviceGeneratedCommandsLimitsNVX*, void>)vkGetPhysicalDeviceGeneratedCommandsPropertiesNVX_ptr)(physicalDevice, ptr, ptr2);
			}
		}
	}

	public unsafe static void vkGetPhysicalDeviceGeneratedCommandsPropertiesNVX(VkPhysicalDevice physicalDevice, IntPtr pFeatures, VkDeviceGeneratedCommandsLimitsNVX* pLimits)
	{
		((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, VkDeviceGeneratedCommandsLimitsNVX*, void>)vkGetPhysicalDeviceGeneratedCommandsPropertiesNVX_ptr)(physicalDevice, pFeatures, pLimits);
	}

	public unsafe static void vkGetPhysicalDeviceGeneratedCommandsPropertiesNVX(VkPhysicalDevice physicalDevice, IntPtr pFeatures, out VkDeviceGeneratedCommandsLimitsNVX pLimits)
	{
		fixed (VkDeviceGeneratedCommandsLimitsNVX* ptr = &pLimits)
		{
			((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, VkDeviceGeneratedCommandsLimitsNVX*, void>)vkGetPhysicalDeviceGeneratedCommandsPropertiesNVX_ptr)(physicalDevice, pFeatures, ptr);
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceImageFormatProperties(VkPhysicalDevice physicalDevice, VkFormat format, VkImageType type, VkImageTiling tiling, VkImageUsageFlags usage, VkImageCreateFlags flags, VkImageFormatProperties* pImageFormatProperties)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkFormat, VkImageType, VkImageTiling, VkImageUsageFlags, VkImageCreateFlags, VkImageFormatProperties*, VkResult>)vkGetPhysicalDeviceImageFormatProperties_ptr)(physicalDevice, format, type, tiling, usage, flags, pImageFormatProperties);
	}

	public unsafe static VkResult vkGetPhysicalDeviceImageFormatProperties(VkPhysicalDevice physicalDevice, VkFormat format, VkImageType type, VkImageTiling tiling, VkImageUsageFlags usage, VkImageCreateFlags flags, out VkImageFormatProperties pImageFormatProperties)
	{
		fixed (VkImageFormatProperties* ptr = &pImageFormatProperties)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkFormat, VkImageType, VkImageTiling, VkImageUsageFlags, VkImageCreateFlags, VkImageFormatProperties*, VkResult>)vkGetPhysicalDeviceImageFormatProperties_ptr)(physicalDevice, format, type, tiling, usage, flags, ptr);
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceImageFormatProperties2KHR(VkPhysicalDevice physicalDevice, VkPhysicalDeviceImageFormatInfo2KHR* pImageFormatInfo, VkImageFormatProperties2KHR* pImageFormatProperties)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceImageFormatInfo2KHR*, VkImageFormatProperties2KHR*, VkResult>)vkGetPhysicalDeviceImageFormatProperties2KHR_ptr)(physicalDevice, pImageFormatInfo, pImageFormatProperties);
	}

	public unsafe static VkResult vkGetPhysicalDeviceImageFormatProperties2KHR(VkPhysicalDevice physicalDevice, VkPhysicalDeviceImageFormatInfo2KHR* pImageFormatInfo, out VkImageFormatProperties2KHR pImageFormatProperties)
	{
		fixed (VkImageFormatProperties2KHR* ptr = &pImageFormatProperties)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceImageFormatInfo2KHR*, VkImageFormatProperties2KHR*, VkResult>)vkGetPhysicalDeviceImageFormatProperties2KHR_ptr)(physicalDevice, pImageFormatInfo, ptr);
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceImageFormatProperties2KHR(VkPhysicalDevice physicalDevice, ref VkPhysicalDeviceImageFormatInfo2KHR pImageFormatInfo, VkImageFormatProperties2KHR* pImageFormatProperties)
	{
		fixed (VkPhysicalDeviceImageFormatInfo2KHR* ptr = &pImageFormatInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceImageFormatInfo2KHR*, VkImageFormatProperties2KHR*, VkResult>)vkGetPhysicalDeviceImageFormatProperties2KHR_ptr)(physicalDevice, ptr, pImageFormatProperties);
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceImageFormatProperties2KHR(VkPhysicalDevice physicalDevice, ref VkPhysicalDeviceImageFormatInfo2KHR pImageFormatInfo, out VkImageFormatProperties2KHR pImageFormatProperties)
	{
		fixed (VkPhysicalDeviceImageFormatInfo2KHR* ptr = &pImageFormatInfo)
		{
			fixed (VkImageFormatProperties2KHR* ptr2 = &pImageFormatProperties)
			{
				return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceImageFormatInfo2KHR*, VkImageFormatProperties2KHR*, VkResult>)vkGetPhysicalDeviceImageFormatProperties2KHR_ptr)(physicalDevice, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceImageFormatProperties2KHR(VkPhysicalDevice physicalDevice, IntPtr pImageFormatInfo, VkImageFormatProperties2KHR* pImageFormatProperties)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, VkImageFormatProperties2KHR*, VkResult>)vkGetPhysicalDeviceImageFormatProperties2KHR_ptr)(physicalDevice, pImageFormatInfo, pImageFormatProperties);
	}

	public unsafe static VkResult vkGetPhysicalDeviceImageFormatProperties2KHR(VkPhysicalDevice physicalDevice, IntPtr pImageFormatInfo, out VkImageFormatProperties2KHR pImageFormatProperties)
	{
		fixed (VkImageFormatProperties2KHR* ptr = &pImageFormatProperties)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, VkImageFormatProperties2KHR*, VkResult>)vkGetPhysicalDeviceImageFormatProperties2KHR_ptr)(physicalDevice, pImageFormatInfo, ptr);
		}
	}

	public unsafe static void vkGetPhysicalDeviceMemoryProperties(VkPhysicalDevice physicalDevice, VkPhysicalDeviceMemoryProperties* pMemoryProperties)
	{
		((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceMemoryProperties*, void>)vkGetPhysicalDeviceMemoryProperties_ptr)(physicalDevice, pMemoryProperties);
	}

	public unsafe static void vkGetPhysicalDeviceMemoryProperties(VkPhysicalDevice physicalDevice, out VkPhysicalDeviceMemoryProperties pMemoryProperties)
	{
		fixed (VkPhysicalDeviceMemoryProperties* ptr = &pMemoryProperties)
		{
			((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceMemoryProperties*, void>)vkGetPhysicalDeviceMemoryProperties_ptr)(physicalDevice, ptr);
		}
	}

	public unsafe static void vkGetPhysicalDeviceMemoryProperties2KHR(VkPhysicalDevice physicalDevice, VkPhysicalDeviceMemoryProperties2KHR* pMemoryProperties)
	{
		((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceMemoryProperties2KHR*, void>)vkGetPhysicalDeviceMemoryProperties2KHR_ptr)(physicalDevice, pMemoryProperties);
	}

	public unsafe static void vkGetPhysicalDeviceMemoryProperties2KHR(VkPhysicalDevice physicalDevice, out VkPhysicalDeviceMemoryProperties2KHR pMemoryProperties)
	{
		fixed (VkPhysicalDeviceMemoryProperties2KHR* ptr = &pMemoryProperties)
		{
			((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceMemoryProperties2KHR*, void>)vkGetPhysicalDeviceMemoryProperties2KHR_ptr)(physicalDevice, ptr);
		}
	}

	public unsafe static VkBool32 vkGetPhysicalDeviceMirPresentationSupportKHR(VkPhysicalDevice physicalDevice, uint queueFamilyIndex, MirConnection* connection)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint, MirConnection*, VkBool32>)vkGetPhysicalDeviceMirPresentationSupportKHR_ptr)(physicalDevice, queueFamilyIndex, connection);
	}

	public unsafe static VkBool32 vkGetPhysicalDeviceMirPresentationSupportKHR(VkPhysicalDevice physicalDevice, uint queueFamilyIndex, out MirConnection connection)
	{
		fixed (MirConnection* ptr = &connection)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint, MirConnection*, VkBool32>)vkGetPhysicalDeviceMirPresentationSupportKHR_ptr)(physicalDevice, queueFamilyIndex, ptr);
		}
	}

	public unsafe static void vkGetPhysicalDeviceMultisamplePropertiesEXT(VkPhysicalDevice physicalDevice, VkSampleCountFlags samples, VkMultisamplePropertiesEXT* pMultisampleProperties)
	{
		((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkSampleCountFlags, VkMultisamplePropertiesEXT*, void>)vkGetPhysicalDeviceMultisamplePropertiesEXT_ptr)(physicalDevice, samples, pMultisampleProperties);
	}

	public unsafe static void vkGetPhysicalDeviceMultisamplePropertiesEXT(VkPhysicalDevice physicalDevice, VkSampleCountFlags samples, out VkMultisamplePropertiesEXT pMultisampleProperties)
	{
		fixed (VkMultisamplePropertiesEXT* ptr = &pMultisampleProperties)
		{
			((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkSampleCountFlags, VkMultisamplePropertiesEXT*, void>)vkGetPhysicalDeviceMultisamplePropertiesEXT_ptr)(physicalDevice, samples, ptr);
		}
	}

	public unsafe static VkResult vkGetPhysicalDevicePresentRectanglesKHX(VkPhysicalDevice physicalDevice, VkSurfaceKHR surface, uint* pRectCount, VkRect2D* pRects)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkSurfaceKHR, uint*, VkRect2D*, VkResult>)vkGetPhysicalDevicePresentRectanglesKHX_ptr)(physicalDevice, surface, pRectCount, pRects);
	}

	public unsafe static VkResult vkGetPhysicalDevicePresentRectanglesKHX(VkPhysicalDevice physicalDevice, VkSurfaceKHR surface, uint* pRectCount, out VkRect2D pRects)
	{
		fixed (VkRect2D* ptr = &pRects)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkSurfaceKHR, uint*, VkRect2D*, VkResult>)vkGetPhysicalDevicePresentRectanglesKHX_ptr)(physicalDevice, surface, pRectCount, ptr);
		}
	}

	public unsafe static VkResult vkGetPhysicalDevicePresentRectanglesKHX(VkPhysicalDevice physicalDevice, VkSurfaceKHR surface, ref uint pRectCount, VkRect2D* pRects)
	{
		fixed (uint* ptr = &pRectCount)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkSurfaceKHR, uint*, VkRect2D*, VkResult>)vkGetPhysicalDevicePresentRectanglesKHX_ptr)(physicalDevice, surface, ptr, pRects);
		}
	}

	public unsafe static VkResult vkGetPhysicalDevicePresentRectanglesKHX(VkPhysicalDevice physicalDevice, VkSurfaceKHR surface, ref uint pRectCount, out VkRect2D pRects)
	{
		fixed (uint* ptr = &pRectCount)
		{
			fixed (VkRect2D* ptr2 = &pRects)
			{
				return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkSurfaceKHR, uint*, VkRect2D*, VkResult>)vkGetPhysicalDevicePresentRectanglesKHX_ptr)(physicalDevice, surface, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkGetPhysicalDevicePresentRectanglesKHX(VkPhysicalDevice physicalDevice, VkSurfaceKHR surface, IntPtr pRectCount, VkRect2D* pRects)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkSurfaceKHR, IntPtr, VkRect2D*, VkResult>)vkGetPhysicalDevicePresentRectanglesKHX_ptr)(physicalDevice, surface, pRectCount, pRects);
	}

	public unsafe static VkResult vkGetPhysicalDevicePresentRectanglesKHX(VkPhysicalDevice physicalDevice, VkSurfaceKHR surface, IntPtr pRectCount, out VkRect2D pRects)
	{
		fixed (VkRect2D* ptr = &pRects)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkSurfaceKHR, IntPtr, VkRect2D*, VkResult>)vkGetPhysicalDevicePresentRectanglesKHX_ptr)(physicalDevice, surface, pRectCount, ptr);
		}
	}

	public unsafe static void vkGetPhysicalDeviceProperties(VkPhysicalDevice physicalDevice, VkPhysicalDeviceProperties* pProperties)
	{
		((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceProperties*, void>)vkGetPhysicalDeviceProperties_ptr)(physicalDevice, pProperties);
	}

	public unsafe static void vkGetPhysicalDeviceProperties(VkPhysicalDevice physicalDevice, out VkPhysicalDeviceProperties pProperties)
	{
		fixed (VkPhysicalDeviceProperties* ptr = &pProperties)
		{
			((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceProperties*, void>)vkGetPhysicalDeviceProperties_ptr)(physicalDevice, ptr);
		}
	}

	public unsafe static void vkGetPhysicalDeviceProperties2KHR(VkPhysicalDevice physicalDevice, VkPhysicalDeviceProperties2KHR* pProperties)
	{
		((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceProperties2KHR*, void>)vkGetPhysicalDeviceProperties2KHR_ptr)(physicalDevice, pProperties);
	}

	public unsafe static void vkGetPhysicalDeviceProperties2KHR(VkPhysicalDevice physicalDevice, out VkPhysicalDeviceProperties2KHR pProperties)
	{
		fixed (VkPhysicalDeviceProperties2KHR* ptr = &pProperties)
		{
			((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceProperties2KHR*, void>)vkGetPhysicalDeviceProperties2KHR_ptr)(physicalDevice, ptr);
		}
	}

	public unsafe static void vkGetPhysicalDeviceQueueFamilyProperties(VkPhysicalDevice physicalDevice, uint* pQueueFamilyPropertyCount, VkQueueFamilyProperties* pQueueFamilyProperties)
	{
		((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint*, VkQueueFamilyProperties*, void>)vkGetPhysicalDeviceQueueFamilyProperties_ptr)(physicalDevice, pQueueFamilyPropertyCount, pQueueFamilyProperties);
	}

	public unsafe static void vkGetPhysicalDeviceQueueFamilyProperties(VkPhysicalDevice physicalDevice, uint* pQueueFamilyPropertyCount, out VkQueueFamilyProperties pQueueFamilyProperties)
	{
		fixed (VkQueueFamilyProperties* ptr = &pQueueFamilyProperties)
		{
			((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint*, VkQueueFamilyProperties*, void>)vkGetPhysicalDeviceQueueFamilyProperties_ptr)(physicalDevice, pQueueFamilyPropertyCount, ptr);
		}
	}

	public unsafe static void vkGetPhysicalDeviceQueueFamilyProperties(VkPhysicalDevice physicalDevice, ref uint pQueueFamilyPropertyCount, VkQueueFamilyProperties* pQueueFamilyProperties)
	{
		fixed (uint* ptr = &pQueueFamilyPropertyCount)
		{
			((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint*, VkQueueFamilyProperties*, void>)vkGetPhysicalDeviceQueueFamilyProperties_ptr)(physicalDevice, ptr, pQueueFamilyProperties);
		}
	}

	public unsafe static void vkGetPhysicalDeviceQueueFamilyProperties(VkPhysicalDevice physicalDevice, ref uint pQueueFamilyPropertyCount, out VkQueueFamilyProperties pQueueFamilyProperties)
	{
		fixed (uint* ptr = &pQueueFamilyPropertyCount)
		{
			fixed (VkQueueFamilyProperties* ptr2 = &pQueueFamilyProperties)
			{
				((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint*, VkQueueFamilyProperties*, void>)vkGetPhysicalDeviceQueueFamilyProperties_ptr)(physicalDevice, ptr, ptr2);
			}
		}
	}

	public unsafe static void vkGetPhysicalDeviceQueueFamilyProperties(VkPhysicalDevice physicalDevice, IntPtr pQueueFamilyPropertyCount, VkQueueFamilyProperties* pQueueFamilyProperties)
	{
		((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, VkQueueFamilyProperties*, void>)vkGetPhysicalDeviceQueueFamilyProperties_ptr)(physicalDevice, pQueueFamilyPropertyCount, pQueueFamilyProperties);
	}

	public unsafe static void vkGetPhysicalDeviceQueueFamilyProperties(VkPhysicalDevice physicalDevice, IntPtr pQueueFamilyPropertyCount, out VkQueueFamilyProperties pQueueFamilyProperties)
	{
		fixed (VkQueueFamilyProperties* ptr = &pQueueFamilyProperties)
		{
			((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, VkQueueFamilyProperties*, void>)vkGetPhysicalDeviceQueueFamilyProperties_ptr)(physicalDevice, pQueueFamilyPropertyCount, ptr);
		}
	}

	public unsafe static void vkGetPhysicalDeviceQueueFamilyProperties2KHR(VkPhysicalDevice physicalDevice, uint* pQueueFamilyPropertyCount, VkQueueFamilyProperties2KHR* pQueueFamilyProperties)
	{
		((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint*, VkQueueFamilyProperties2KHR*, void>)vkGetPhysicalDeviceQueueFamilyProperties2KHR_ptr)(physicalDevice, pQueueFamilyPropertyCount, pQueueFamilyProperties);
	}

	public unsafe static void vkGetPhysicalDeviceQueueFamilyProperties2KHR(VkPhysicalDevice physicalDevice, uint* pQueueFamilyPropertyCount, out VkQueueFamilyProperties2KHR pQueueFamilyProperties)
	{
		fixed (VkQueueFamilyProperties2KHR* ptr = &pQueueFamilyProperties)
		{
			((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint*, VkQueueFamilyProperties2KHR*, void>)vkGetPhysicalDeviceQueueFamilyProperties2KHR_ptr)(physicalDevice, pQueueFamilyPropertyCount, ptr);
		}
	}

	public unsafe static void vkGetPhysicalDeviceQueueFamilyProperties2KHR(VkPhysicalDevice physicalDevice, ref uint pQueueFamilyPropertyCount, VkQueueFamilyProperties2KHR* pQueueFamilyProperties)
	{
		fixed (uint* ptr = &pQueueFamilyPropertyCount)
		{
			((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint*, VkQueueFamilyProperties2KHR*, void>)vkGetPhysicalDeviceQueueFamilyProperties2KHR_ptr)(physicalDevice, ptr, pQueueFamilyProperties);
		}
	}

	public unsafe static void vkGetPhysicalDeviceQueueFamilyProperties2KHR(VkPhysicalDevice physicalDevice, ref uint pQueueFamilyPropertyCount, out VkQueueFamilyProperties2KHR pQueueFamilyProperties)
	{
		fixed (uint* ptr = &pQueueFamilyPropertyCount)
		{
			fixed (VkQueueFamilyProperties2KHR* ptr2 = &pQueueFamilyProperties)
			{
				((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint*, VkQueueFamilyProperties2KHR*, void>)vkGetPhysicalDeviceQueueFamilyProperties2KHR_ptr)(physicalDevice, ptr, ptr2);
			}
		}
	}

	public unsafe static void vkGetPhysicalDeviceQueueFamilyProperties2KHR(VkPhysicalDevice physicalDevice, IntPtr pQueueFamilyPropertyCount, VkQueueFamilyProperties2KHR* pQueueFamilyProperties)
	{
		((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, VkQueueFamilyProperties2KHR*, void>)vkGetPhysicalDeviceQueueFamilyProperties2KHR_ptr)(physicalDevice, pQueueFamilyPropertyCount, pQueueFamilyProperties);
	}

	public unsafe static void vkGetPhysicalDeviceQueueFamilyProperties2KHR(VkPhysicalDevice physicalDevice, IntPtr pQueueFamilyPropertyCount, out VkQueueFamilyProperties2KHR pQueueFamilyProperties)
	{
		fixed (VkQueueFamilyProperties2KHR* ptr = &pQueueFamilyProperties)
		{
			((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, VkQueueFamilyProperties2KHR*, void>)vkGetPhysicalDeviceQueueFamilyProperties2KHR_ptr)(physicalDevice, pQueueFamilyPropertyCount, ptr);
		}
	}

	public unsafe static void vkGetPhysicalDeviceSparseImageFormatProperties(VkPhysicalDevice physicalDevice, VkFormat format, VkImageType type, VkSampleCountFlags samples, VkImageUsageFlags usage, VkImageTiling tiling, uint* pPropertyCount, VkSparseImageFormatProperties* pProperties)
	{
		((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkFormat, VkImageType, VkSampleCountFlags, VkImageUsageFlags, VkImageTiling, uint*, VkSparseImageFormatProperties*, void>)vkGetPhysicalDeviceSparseImageFormatProperties_ptr)(physicalDevice, format, type, samples, usage, tiling, pPropertyCount, pProperties);
	}

	public unsafe static void vkGetPhysicalDeviceSparseImageFormatProperties(VkPhysicalDevice physicalDevice, VkFormat format, VkImageType type, VkSampleCountFlags samples, VkImageUsageFlags usage, VkImageTiling tiling, uint* pPropertyCount, out VkSparseImageFormatProperties pProperties)
	{
		fixed (VkSparseImageFormatProperties* ptr = &pProperties)
		{
			((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkFormat, VkImageType, VkSampleCountFlags, VkImageUsageFlags, VkImageTiling, uint*, VkSparseImageFormatProperties*, void>)vkGetPhysicalDeviceSparseImageFormatProperties_ptr)(physicalDevice, format, type, samples, usage, tiling, pPropertyCount, ptr);
		}
	}

	public unsafe static void vkGetPhysicalDeviceSparseImageFormatProperties(VkPhysicalDevice physicalDevice, VkFormat format, VkImageType type, VkSampleCountFlags samples, VkImageUsageFlags usage, VkImageTiling tiling, ref uint pPropertyCount, VkSparseImageFormatProperties* pProperties)
	{
		fixed (uint* ptr = &pPropertyCount)
		{
			((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkFormat, VkImageType, VkSampleCountFlags, VkImageUsageFlags, VkImageTiling, uint*, VkSparseImageFormatProperties*, void>)vkGetPhysicalDeviceSparseImageFormatProperties_ptr)(physicalDevice, format, type, samples, usage, tiling, ptr, pProperties);
		}
	}

	public unsafe static void vkGetPhysicalDeviceSparseImageFormatProperties(VkPhysicalDevice physicalDevice, VkFormat format, VkImageType type, VkSampleCountFlags samples, VkImageUsageFlags usage, VkImageTiling tiling, ref uint pPropertyCount, out VkSparseImageFormatProperties pProperties)
	{
		fixed (uint* ptr = &pPropertyCount)
		{
			fixed (VkSparseImageFormatProperties* ptr2 = &pProperties)
			{
				((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkFormat, VkImageType, VkSampleCountFlags, VkImageUsageFlags, VkImageTiling, uint*, VkSparseImageFormatProperties*, void>)vkGetPhysicalDeviceSparseImageFormatProperties_ptr)(physicalDevice, format, type, samples, usage, tiling, ptr, ptr2);
			}
		}
	}

	public unsafe static void vkGetPhysicalDeviceSparseImageFormatProperties(VkPhysicalDevice physicalDevice, VkFormat format, VkImageType type, VkSampleCountFlags samples, VkImageUsageFlags usage, VkImageTiling tiling, IntPtr pPropertyCount, VkSparseImageFormatProperties* pProperties)
	{
		((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkFormat, VkImageType, VkSampleCountFlags, VkImageUsageFlags, VkImageTiling, IntPtr, VkSparseImageFormatProperties*, void>)vkGetPhysicalDeviceSparseImageFormatProperties_ptr)(physicalDevice, format, type, samples, usage, tiling, pPropertyCount, pProperties);
	}

	public unsafe static void vkGetPhysicalDeviceSparseImageFormatProperties(VkPhysicalDevice physicalDevice, VkFormat format, VkImageType type, VkSampleCountFlags samples, VkImageUsageFlags usage, VkImageTiling tiling, IntPtr pPropertyCount, out VkSparseImageFormatProperties pProperties)
	{
		fixed (VkSparseImageFormatProperties* ptr = &pProperties)
		{
			((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkFormat, VkImageType, VkSampleCountFlags, VkImageUsageFlags, VkImageTiling, IntPtr, VkSparseImageFormatProperties*, void>)vkGetPhysicalDeviceSparseImageFormatProperties_ptr)(physicalDevice, format, type, samples, usage, tiling, pPropertyCount, ptr);
		}
	}

	public unsafe static void vkGetPhysicalDeviceSparseImageFormatProperties2KHR(VkPhysicalDevice physicalDevice, VkPhysicalDeviceSparseImageFormatInfo2KHR* pFormatInfo, uint* pPropertyCount, VkSparseImageFormatProperties2KHR* pProperties)
	{
		((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceSparseImageFormatInfo2KHR*, uint*, VkSparseImageFormatProperties2KHR*, void>)vkGetPhysicalDeviceSparseImageFormatProperties2KHR_ptr)(physicalDevice, pFormatInfo, pPropertyCount, pProperties);
	}

	public unsafe static void vkGetPhysicalDeviceSparseImageFormatProperties2KHR(VkPhysicalDevice physicalDevice, VkPhysicalDeviceSparseImageFormatInfo2KHR* pFormatInfo, uint* pPropertyCount, out VkSparseImageFormatProperties2KHR pProperties)
	{
		fixed (VkSparseImageFormatProperties2KHR* ptr = &pProperties)
		{
			((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceSparseImageFormatInfo2KHR*, uint*, VkSparseImageFormatProperties2KHR*, void>)vkGetPhysicalDeviceSparseImageFormatProperties2KHR_ptr)(physicalDevice, pFormatInfo, pPropertyCount, ptr);
		}
	}

	public unsafe static void vkGetPhysicalDeviceSparseImageFormatProperties2KHR(VkPhysicalDevice physicalDevice, VkPhysicalDeviceSparseImageFormatInfo2KHR* pFormatInfo, ref uint pPropertyCount, VkSparseImageFormatProperties2KHR* pProperties)
	{
		fixed (uint* ptr = &pPropertyCount)
		{
			((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceSparseImageFormatInfo2KHR*, uint*, VkSparseImageFormatProperties2KHR*, void>)vkGetPhysicalDeviceSparseImageFormatProperties2KHR_ptr)(physicalDevice, pFormatInfo, ptr, pProperties);
		}
	}

	public unsafe static void vkGetPhysicalDeviceSparseImageFormatProperties2KHR(VkPhysicalDevice physicalDevice, VkPhysicalDeviceSparseImageFormatInfo2KHR* pFormatInfo, ref uint pPropertyCount, out VkSparseImageFormatProperties2KHR pProperties)
	{
		fixed (uint* ptr = &pPropertyCount)
		{
			fixed (VkSparseImageFormatProperties2KHR* ptr2 = &pProperties)
			{
				((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceSparseImageFormatInfo2KHR*, uint*, VkSparseImageFormatProperties2KHR*, void>)vkGetPhysicalDeviceSparseImageFormatProperties2KHR_ptr)(physicalDevice, pFormatInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static void vkGetPhysicalDeviceSparseImageFormatProperties2KHR(VkPhysicalDevice physicalDevice, VkPhysicalDeviceSparseImageFormatInfo2KHR* pFormatInfo, IntPtr pPropertyCount, VkSparseImageFormatProperties2KHR* pProperties)
	{
		((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceSparseImageFormatInfo2KHR*, IntPtr, VkSparseImageFormatProperties2KHR*, void>)vkGetPhysicalDeviceSparseImageFormatProperties2KHR_ptr)(physicalDevice, pFormatInfo, pPropertyCount, pProperties);
	}

	public unsafe static void vkGetPhysicalDeviceSparseImageFormatProperties2KHR(VkPhysicalDevice physicalDevice, VkPhysicalDeviceSparseImageFormatInfo2KHR* pFormatInfo, IntPtr pPropertyCount, out VkSparseImageFormatProperties2KHR pProperties)
	{
		fixed (VkSparseImageFormatProperties2KHR* ptr = &pProperties)
		{
			((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceSparseImageFormatInfo2KHR*, IntPtr, VkSparseImageFormatProperties2KHR*, void>)vkGetPhysicalDeviceSparseImageFormatProperties2KHR_ptr)(physicalDevice, pFormatInfo, pPropertyCount, ptr);
		}
	}

	public unsafe static void vkGetPhysicalDeviceSparseImageFormatProperties2KHR(VkPhysicalDevice physicalDevice, ref VkPhysicalDeviceSparseImageFormatInfo2KHR pFormatInfo, uint* pPropertyCount, VkSparseImageFormatProperties2KHR* pProperties)
	{
		fixed (VkPhysicalDeviceSparseImageFormatInfo2KHR* ptr = &pFormatInfo)
		{
			((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceSparseImageFormatInfo2KHR*, uint*, VkSparseImageFormatProperties2KHR*, void>)vkGetPhysicalDeviceSparseImageFormatProperties2KHR_ptr)(physicalDevice, ptr, pPropertyCount, pProperties);
		}
	}

	public unsafe static void vkGetPhysicalDeviceSparseImageFormatProperties2KHR(VkPhysicalDevice physicalDevice, ref VkPhysicalDeviceSparseImageFormatInfo2KHR pFormatInfo, uint* pPropertyCount, out VkSparseImageFormatProperties2KHR pProperties)
	{
		fixed (VkPhysicalDeviceSparseImageFormatInfo2KHR* ptr = &pFormatInfo)
		{
			fixed (VkSparseImageFormatProperties2KHR* ptr2 = &pProperties)
			{
				((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceSparseImageFormatInfo2KHR*, uint*, VkSparseImageFormatProperties2KHR*, void>)vkGetPhysicalDeviceSparseImageFormatProperties2KHR_ptr)(physicalDevice, ptr, pPropertyCount, ptr2);
			}
		}
	}

	public unsafe static void vkGetPhysicalDeviceSparseImageFormatProperties2KHR(VkPhysicalDevice physicalDevice, ref VkPhysicalDeviceSparseImageFormatInfo2KHR pFormatInfo, ref uint pPropertyCount, VkSparseImageFormatProperties2KHR* pProperties)
	{
		fixed (VkPhysicalDeviceSparseImageFormatInfo2KHR* ptr = &pFormatInfo)
		{
			fixed (uint* ptr2 = &pPropertyCount)
			{
				((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceSparseImageFormatInfo2KHR*, uint*, VkSparseImageFormatProperties2KHR*, void>)vkGetPhysicalDeviceSparseImageFormatProperties2KHR_ptr)(physicalDevice, ptr, ptr2, pProperties);
			}
		}
	}

	public unsafe static void vkGetPhysicalDeviceSparseImageFormatProperties2KHR(VkPhysicalDevice physicalDevice, ref VkPhysicalDeviceSparseImageFormatInfo2KHR pFormatInfo, ref uint pPropertyCount, out VkSparseImageFormatProperties2KHR pProperties)
	{
		fixed (VkPhysicalDeviceSparseImageFormatInfo2KHR* ptr = &pFormatInfo)
		{
			fixed (uint* ptr2 = &pPropertyCount)
			{
				fixed (VkSparseImageFormatProperties2KHR* ptr3 = &pProperties)
				{
					((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceSparseImageFormatInfo2KHR*, uint*, VkSparseImageFormatProperties2KHR*, void>)vkGetPhysicalDeviceSparseImageFormatProperties2KHR_ptr)(physicalDevice, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static void vkGetPhysicalDeviceSparseImageFormatProperties2KHR(VkPhysicalDevice physicalDevice, ref VkPhysicalDeviceSparseImageFormatInfo2KHR pFormatInfo, IntPtr pPropertyCount, VkSparseImageFormatProperties2KHR* pProperties)
	{
		fixed (VkPhysicalDeviceSparseImageFormatInfo2KHR* ptr = &pFormatInfo)
		{
			((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceSparseImageFormatInfo2KHR*, IntPtr, VkSparseImageFormatProperties2KHR*, void>)vkGetPhysicalDeviceSparseImageFormatProperties2KHR_ptr)(physicalDevice, ptr, pPropertyCount, pProperties);
		}
	}

	public unsafe static void vkGetPhysicalDeviceSparseImageFormatProperties2KHR(VkPhysicalDevice physicalDevice, ref VkPhysicalDeviceSparseImageFormatInfo2KHR pFormatInfo, IntPtr pPropertyCount, out VkSparseImageFormatProperties2KHR pProperties)
	{
		fixed (VkPhysicalDeviceSparseImageFormatInfo2KHR* ptr = &pFormatInfo)
		{
			fixed (VkSparseImageFormatProperties2KHR* ptr2 = &pProperties)
			{
				((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceSparseImageFormatInfo2KHR*, IntPtr, VkSparseImageFormatProperties2KHR*, void>)vkGetPhysicalDeviceSparseImageFormatProperties2KHR_ptr)(physicalDevice, ptr, pPropertyCount, ptr2);
			}
		}
	}

	public unsafe static void vkGetPhysicalDeviceSparseImageFormatProperties2KHR(VkPhysicalDevice physicalDevice, IntPtr pFormatInfo, uint* pPropertyCount, VkSparseImageFormatProperties2KHR* pProperties)
	{
		((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, uint*, VkSparseImageFormatProperties2KHR*, void>)vkGetPhysicalDeviceSparseImageFormatProperties2KHR_ptr)(physicalDevice, pFormatInfo, pPropertyCount, pProperties);
	}

	public unsafe static void vkGetPhysicalDeviceSparseImageFormatProperties2KHR(VkPhysicalDevice physicalDevice, IntPtr pFormatInfo, uint* pPropertyCount, out VkSparseImageFormatProperties2KHR pProperties)
	{
		fixed (VkSparseImageFormatProperties2KHR* ptr = &pProperties)
		{
			((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, uint*, VkSparseImageFormatProperties2KHR*, void>)vkGetPhysicalDeviceSparseImageFormatProperties2KHR_ptr)(physicalDevice, pFormatInfo, pPropertyCount, ptr);
		}
	}

	public unsafe static void vkGetPhysicalDeviceSparseImageFormatProperties2KHR(VkPhysicalDevice physicalDevice, IntPtr pFormatInfo, ref uint pPropertyCount, VkSparseImageFormatProperties2KHR* pProperties)
	{
		fixed (uint* ptr = &pPropertyCount)
		{
			((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, uint*, VkSparseImageFormatProperties2KHR*, void>)vkGetPhysicalDeviceSparseImageFormatProperties2KHR_ptr)(physicalDevice, pFormatInfo, ptr, pProperties);
		}
	}

	public unsafe static void vkGetPhysicalDeviceSparseImageFormatProperties2KHR(VkPhysicalDevice physicalDevice, IntPtr pFormatInfo, ref uint pPropertyCount, out VkSparseImageFormatProperties2KHR pProperties)
	{
		fixed (uint* ptr = &pPropertyCount)
		{
			fixed (VkSparseImageFormatProperties2KHR* ptr2 = &pProperties)
			{
				((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, uint*, VkSparseImageFormatProperties2KHR*, void>)vkGetPhysicalDeviceSparseImageFormatProperties2KHR_ptr)(physicalDevice, pFormatInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static void vkGetPhysicalDeviceSparseImageFormatProperties2KHR(VkPhysicalDevice physicalDevice, IntPtr pFormatInfo, IntPtr pPropertyCount, VkSparseImageFormatProperties2KHR* pProperties)
	{
		((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, IntPtr, VkSparseImageFormatProperties2KHR*, void>)vkGetPhysicalDeviceSparseImageFormatProperties2KHR_ptr)(physicalDevice, pFormatInfo, pPropertyCount, pProperties);
	}

	public unsafe static void vkGetPhysicalDeviceSparseImageFormatProperties2KHR(VkPhysicalDevice physicalDevice, IntPtr pFormatInfo, IntPtr pPropertyCount, out VkSparseImageFormatProperties2KHR pProperties)
	{
		fixed (VkSparseImageFormatProperties2KHR* ptr = &pProperties)
		{
			((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, IntPtr, VkSparseImageFormatProperties2KHR*, void>)vkGetPhysicalDeviceSparseImageFormatProperties2KHR_ptr)(physicalDevice, pFormatInfo, pPropertyCount, ptr);
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfaceCapabilities2EXT(VkPhysicalDevice physicalDevice, VkSurfaceKHR surface, VkSurfaceCapabilities2EXT* pSurfaceCapabilities)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkSurfaceKHR, VkSurfaceCapabilities2EXT*, VkResult>)vkGetPhysicalDeviceSurfaceCapabilities2EXT_ptr)(physicalDevice, surface, pSurfaceCapabilities);
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfaceCapabilities2EXT(VkPhysicalDevice physicalDevice, VkSurfaceKHR surface, out VkSurfaceCapabilities2EXT pSurfaceCapabilities)
	{
		fixed (VkSurfaceCapabilities2EXT* ptr = &pSurfaceCapabilities)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkSurfaceKHR, VkSurfaceCapabilities2EXT*, VkResult>)vkGetPhysicalDeviceSurfaceCapabilities2EXT_ptr)(physicalDevice, surface, ptr);
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfaceCapabilities2KHR(VkPhysicalDevice physicalDevice, VkPhysicalDeviceSurfaceInfo2KHR* pSurfaceInfo, VkSurfaceCapabilities2KHR* pSurfaceCapabilities)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceSurfaceInfo2KHR*, VkSurfaceCapabilities2KHR*, VkResult>)vkGetPhysicalDeviceSurfaceCapabilities2KHR_ptr)(physicalDevice, pSurfaceInfo, pSurfaceCapabilities);
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfaceCapabilities2KHR(VkPhysicalDevice physicalDevice, VkPhysicalDeviceSurfaceInfo2KHR* pSurfaceInfo, out VkSurfaceCapabilities2KHR pSurfaceCapabilities)
	{
		fixed (VkSurfaceCapabilities2KHR* ptr = &pSurfaceCapabilities)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceSurfaceInfo2KHR*, VkSurfaceCapabilities2KHR*, VkResult>)vkGetPhysicalDeviceSurfaceCapabilities2KHR_ptr)(physicalDevice, pSurfaceInfo, ptr);
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfaceCapabilities2KHR(VkPhysicalDevice physicalDevice, ref VkPhysicalDeviceSurfaceInfo2KHR pSurfaceInfo, VkSurfaceCapabilities2KHR* pSurfaceCapabilities)
	{
		fixed (VkPhysicalDeviceSurfaceInfo2KHR* ptr = &pSurfaceInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceSurfaceInfo2KHR*, VkSurfaceCapabilities2KHR*, VkResult>)vkGetPhysicalDeviceSurfaceCapabilities2KHR_ptr)(physicalDevice, ptr, pSurfaceCapabilities);
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfaceCapabilities2KHR(VkPhysicalDevice physicalDevice, ref VkPhysicalDeviceSurfaceInfo2KHR pSurfaceInfo, out VkSurfaceCapabilities2KHR pSurfaceCapabilities)
	{
		fixed (VkPhysicalDeviceSurfaceInfo2KHR* ptr = &pSurfaceInfo)
		{
			fixed (VkSurfaceCapabilities2KHR* ptr2 = &pSurfaceCapabilities)
			{
				return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceSurfaceInfo2KHR*, VkSurfaceCapabilities2KHR*, VkResult>)vkGetPhysicalDeviceSurfaceCapabilities2KHR_ptr)(physicalDevice, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfaceCapabilities2KHR(VkPhysicalDevice physicalDevice, IntPtr pSurfaceInfo, VkSurfaceCapabilities2KHR* pSurfaceCapabilities)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, VkSurfaceCapabilities2KHR*, VkResult>)vkGetPhysicalDeviceSurfaceCapabilities2KHR_ptr)(physicalDevice, pSurfaceInfo, pSurfaceCapabilities);
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfaceCapabilities2KHR(VkPhysicalDevice physicalDevice, IntPtr pSurfaceInfo, out VkSurfaceCapabilities2KHR pSurfaceCapabilities)
	{
		fixed (VkSurfaceCapabilities2KHR* ptr = &pSurfaceCapabilities)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, VkSurfaceCapabilities2KHR*, VkResult>)vkGetPhysicalDeviceSurfaceCapabilities2KHR_ptr)(physicalDevice, pSurfaceInfo, ptr);
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfaceCapabilitiesKHR(VkPhysicalDevice physicalDevice, VkSurfaceKHR surface, VkSurfaceCapabilitiesKHR* pSurfaceCapabilities)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkSurfaceKHR, VkSurfaceCapabilitiesKHR*, VkResult>)vkGetPhysicalDeviceSurfaceCapabilitiesKHR_ptr)(physicalDevice, surface, pSurfaceCapabilities);
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfaceCapabilitiesKHR(VkPhysicalDevice physicalDevice, VkSurfaceKHR surface, out VkSurfaceCapabilitiesKHR pSurfaceCapabilities)
	{
		fixed (VkSurfaceCapabilitiesKHR* ptr = &pSurfaceCapabilities)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkSurfaceKHR, VkSurfaceCapabilitiesKHR*, VkResult>)vkGetPhysicalDeviceSurfaceCapabilitiesKHR_ptr)(physicalDevice, surface, ptr);
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfaceFormats2KHR(VkPhysicalDevice physicalDevice, VkPhysicalDeviceSurfaceInfo2KHR* pSurfaceInfo, uint* pSurfaceFormatCount, VkSurfaceFormat2KHR* pSurfaceFormats)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceSurfaceInfo2KHR*, uint*, VkSurfaceFormat2KHR*, VkResult>)vkGetPhysicalDeviceSurfaceFormats2KHR_ptr)(physicalDevice, pSurfaceInfo, pSurfaceFormatCount, pSurfaceFormats);
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfaceFormats2KHR(VkPhysicalDevice physicalDevice, VkPhysicalDeviceSurfaceInfo2KHR* pSurfaceInfo, uint* pSurfaceFormatCount, out VkSurfaceFormat2KHR pSurfaceFormats)
	{
		fixed (VkSurfaceFormat2KHR* ptr = &pSurfaceFormats)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceSurfaceInfo2KHR*, uint*, VkSurfaceFormat2KHR*, VkResult>)vkGetPhysicalDeviceSurfaceFormats2KHR_ptr)(physicalDevice, pSurfaceInfo, pSurfaceFormatCount, ptr);
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfaceFormats2KHR(VkPhysicalDevice physicalDevice, VkPhysicalDeviceSurfaceInfo2KHR* pSurfaceInfo, ref uint pSurfaceFormatCount, VkSurfaceFormat2KHR* pSurfaceFormats)
	{
		fixed (uint* ptr = &pSurfaceFormatCount)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceSurfaceInfo2KHR*, uint*, VkSurfaceFormat2KHR*, VkResult>)vkGetPhysicalDeviceSurfaceFormats2KHR_ptr)(physicalDevice, pSurfaceInfo, ptr, pSurfaceFormats);
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfaceFormats2KHR(VkPhysicalDevice physicalDevice, VkPhysicalDeviceSurfaceInfo2KHR* pSurfaceInfo, ref uint pSurfaceFormatCount, out VkSurfaceFormat2KHR pSurfaceFormats)
	{
		fixed (uint* ptr = &pSurfaceFormatCount)
		{
			fixed (VkSurfaceFormat2KHR* ptr2 = &pSurfaceFormats)
			{
				return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceSurfaceInfo2KHR*, uint*, VkSurfaceFormat2KHR*, VkResult>)vkGetPhysicalDeviceSurfaceFormats2KHR_ptr)(physicalDevice, pSurfaceInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfaceFormats2KHR(VkPhysicalDevice physicalDevice, VkPhysicalDeviceSurfaceInfo2KHR* pSurfaceInfo, IntPtr pSurfaceFormatCount, VkSurfaceFormat2KHR* pSurfaceFormats)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceSurfaceInfo2KHR*, IntPtr, VkSurfaceFormat2KHR*, VkResult>)vkGetPhysicalDeviceSurfaceFormats2KHR_ptr)(physicalDevice, pSurfaceInfo, pSurfaceFormatCount, pSurfaceFormats);
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfaceFormats2KHR(VkPhysicalDevice physicalDevice, VkPhysicalDeviceSurfaceInfo2KHR* pSurfaceInfo, IntPtr pSurfaceFormatCount, out VkSurfaceFormat2KHR pSurfaceFormats)
	{
		fixed (VkSurfaceFormat2KHR* ptr = &pSurfaceFormats)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceSurfaceInfo2KHR*, IntPtr, VkSurfaceFormat2KHR*, VkResult>)vkGetPhysicalDeviceSurfaceFormats2KHR_ptr)(physicalDevice, pSurfaceInfo, pSurfaceFormatCount, ptr);
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfaceFormats2KHR(VkPhysicalDevice physicalDevice, ref VkPhysicalDeviceSurfaceInfo2KHR pSurfaceInfo, uint* pSurfaceFormatCount, VkSurfaceFormat2KHR* pSurfaceFormats)
	{
		fixed (VkPhysicalDeviceSurfaceInfo2KHR* ptr = &pSurfaceInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceSurfaceInfo2KHR*, uint*, VkSurfaceFormat2KHR*, VkResult>)vkGetPhysicalDeviceSurfaceFormats2KHR_ptr)(physicalDevice, ptr, pSurfaceFormatCount, pSurfaceFormats);
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfaceFormats2KHR(VkPhysicalDevice physicalDevice, ref VkPhysicalDeviceSurfaceInfo2KHR pSurfaceInfo, uint* pSurfaceFormatCount, out VkSurfaceFormat2KHR pSurfaceFormats)
	{
		fixed (VkPhysicalDeviceSurfaceInfo2KHR* ptr = &pSurfaceInfo)
		{
			fixed (VkSurfaceFormat2KHR* ptr2 = &pSurfaceFormats)
			{
				return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceSurfaceInfo2KHR*, uint*, VkSurfaceFormat2KHR*, VkResult>)vkGetPhysicalDeviceSurfaceFormats2KHR_ptr)(physicalDevice, ptr, pSurfaceFormatCount, ptr2);
			}
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfaceFormats2KHR(VkPhysicalDevice physicalDevice, ref VkPhysicalDeviceSurfaceInfo2KHR pSurfaceInfo, ref uint pSurfaceFormatCount, VkSurfaceFormat2KHR* pSurfaceFormats)
	{
		fixed (VkPhysicalDeviceSurfaceInfo2KHR* ptr = &pSurfaceInfo)
		{
			fixed (uint* ptr2 = &pSurfaceFormatCount)
			{
				return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceSurfaceInfo2KHR*, uint*, VkSurfaceFormat2KHR*, VkResult>)vkGetPhysicalDeviceSurfaceFormats2KHR_ptr)(physicalDevice, ptr, ptr2, pSurfaceFormats);
			}
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfaceFormats2KHR(VkPhysicalDevice physicalDevice, ref VkPhysicalDeviceSurfaceInfo2KHR pSurfaceInfo, ref uint pSurfaceFormatCount, out VkSurfaceFormat2KHR pSurfaceFormats)
	{
		fixed (VkPhysicalDeviceSurfaceInfo2KHR* ptr = &pSurfaceInfo)
		{
			fixed (uint* ptr2 = &pSurfaceFormatCount)
			{
				fixed (VkSurfaceFormat2KHR* ptr3 = &pSurfaceFormats)
				{
					return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceSurfaceInfo2KHR*, uint*, VkSurfaceFormat2KHR*, VkResult>)vkGetPhysicalDeviceSurfaceFormats2KHR_ptr)(physicalDevice, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfaceFormats2KHR(VkPhysicalDevice physicalDevice, ref VkPhysicalDeviceSurfaceInfo2KHR pSurfaceInfo, IntPtr pSurfaceFormatCount, VkSurfaceFormat2KHR* pSurfaceFormats)
	{
		fixed (VkPhysicalDeviceSurfaceInfo2KHR* ptr = &pSurfaceInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceSurfaceInfo2KHR*, IntPtr, VkSurfaceFormat2KHR*, VkResult>)vkGetPhysicalDeviceSurfaceFormats2KHR_ptr)(physicalDevice, ptr, pSurfaceFormatCount, pSurfaceFormats);
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfaceFormats2KHR(VkPhysicalDevice physicalDevice, ref VkPhysicalDeviceSurfaceInfo2KHR pSurfaceInfo, IntPtr pSurfaceFormatCount, out VkSurfaceFormat2KHR pSurfaceFormats)
	{
		fixed (VkPhysicalDeviceSurfaceInfo2KHR* ptr = &pSurfaceInfo)
		{
			fixed (VkSurfaceFormat2KHR* ptr2 = &pSurfaceFormats)
			{
				return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkPhysicalDeviceSurfaceInfo2KHR*, IntPtr, VkSurfaceFormat2KHR*, VkResult>)vkGetPhysicalDeviceSurfaceFormats2KHR_ptr)(physicalDevice, ptr, pSurfaceFormatCount, ptr2);
			}
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfaceFormats2KHR(VkPhysicalDevice physicalDevice, IntPtr pSurfaceInfo, uint* pSurfaceFormatCount, VkSurfaceFormat2KHR* pSurfaceFormats)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, uint*, VkSurfaceFormat2KHR*, VkResult>)vkGetPhysicalDeviceSurfaceFormats2KHR_ptr)(physicalDevice, pSurfaceInfo, pSurfaceFormatCount, pSurfaceFormats);
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfaceFormats2KHR(VkPhysicalDevice physicalDevice, IntPtr pSurfaceInfo, uint* pSurfaceFormatCount, out VkSurfaceFormat2KHR pSurfaceFormats)
	{
		fixed (VkSurfaceFormat2KHR* ptr = &pSurfaceFormats)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, uint*, VkSurfaceFormat2KHR*, VkResult>)vkGetPhysicalDeviceSurfaceFormats2KHR_ptr)(physicalDevice, pSurfaceInfo, pSurfaceFormatCount, ptr);
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfaceFormats2KHR(VkPhysicalDevice physicalDevice, IntPtr pSurfaceInfo, ref uint pSurfaceFormatCount, VkSurfaceFormat2KHR* pSurfaceFormats)
	{
		fixed (uint* ptr = &pSurfaceFormatCount)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, uint*, VkSurfaceFormat2KHR*, VkResult>)vkGetPhysicalDeviceSurfaceFormats2KHR_ptr)(physicalDevice, pSurfaceInfo, ptr, pSurfaceFormats);
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfaceFormats2KHR(VkPhysicalDevice physicalDevice, IntPtr pSurfaceInfo, ref uint pSurfaceFormatCount, out VkSurfaceFormat2KHR pSurfaceFormats)
	{
		fixed (uint* ptr = &pSurfaceFormatCount)
		{
			fixed (VkSurfaceFormat2KHR* ptr2 = &pSurfaceFormats)
			{
				return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, uint*, VkSurfaceFormat2KHR*, VkResult>)vkGetPhysicalDeviceSurfaceFormats2KHR_ptr)(physicalDevice, pSurfaceInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfaceFormats2KHR(VkPhysicalDevice physicalDevice, IntPtr pSurfaceInfo, IntPtr pSurfaceFormatCount, VkSurfaceFormat2KHR* pSurfaceFormats)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, IntPtr, VkSurfaceFormat2KHR*, VkResult>)vkGetPhysicalDeviceSurfaceFormats2KHR_ptr)(physicalDevice, pSurfaceInfo, pSurfaceFormatCount, pSurfaceFormats);
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfaceFormats2KHR(VkPhysicalDevice physicalDevice, IntPtr pSurfaceInfo, IntPtr pSurfaceFormatCount, out VkSurfaceFormat2KHR pSurfaceFormats)
	{
		fixed (VkSurfaceFormat2KHR* ptr = &pSurfaceFormats)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, IntPtr, VkSurfaceFormat2KHR*, VkResult>)vkGetPhysicalDeviceSurfaceFormats2KHR_ptr)(physicalDevice, pSurfaceInfo, pSurfaceFormatCount, ptr);
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfaceFormatsKHR(VkPhysicalDevice physicalDevice, VkSurfaceKHR surface, uint* pSurfaceFormatCount, VkSurfaceFormatKHR* pSurfaceFormats)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkSurfaceKHR, uint*, VkSurfaceFormatKHR*, VkResult>)vkGetPhysicalDeviceSurfaceFormatsKHR_ptr)(physicalDevice, surface, pSurfaceFormatCount, pSurfaceFormats);
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfaceFormatsKHR(VkPhysicalDevice physicalDevice, VkSurfaceKHR surface, uint* pSurfaceFormatCount, out VkSurfaceFormatKHR pSurfaceFormats)
	{
		fixed (VkSurfaceFormatKHR* ptr = &pSurfaceFormats)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkSurfaceKHR, uint*, VkSurfaceFormatKHR*, VkResult>)vkGetPhysicalDeviceSurfaceFormatsKHR_ptr)(physicalDevice, surface, pSurfaceFormatCount, ptr);
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfaceFormatsKHR(VkPhysicalDevice physicalDevice, VkSurfaceKHR surface, ref uint pSurfaceFormatCount, VkSurfaceFormatKHR* pSurfaceFormats)
	{
		fixed (uint* ptr = &pSurfaceFormatCount)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkSurfaceKHR, uint*, VkSurfaceFormatKHR*, VkResult>)vkGetPhysicalDeviceSurfaceFormatsKHR_ptr)(physicalDevice, surface, ptr, pSurfaceFormats);
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfaceFormatsKHR(VkPhysicalDevice physicalDevice, VkSurfaceKHR surface, ref uint pSurfaceFormatCount, out VkSurfaceFormatKHR pSurfaceFormats)
	{
		fixed (uint* ptr = &pSurfaceFormatCount)
		{
			fixed (VkSurfaceFormatKHR* ptr2 = &pSurfaceFormats)
			{
				return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkSurfaceKHR, uint*, VkSurfaceFormatKHR*, VkResult>)vkGetPhysicalDeviceSurfaceFormatsKHR_ptr)(physicalDevice, surface, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfaceFormatsKHR(VkPhysicalDevice physicalDevice, VkSurfaceKHR surface, IntPtr pSurfaceFormatCount, VkSurfaceFormatKHR* pSurfaceFormats)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkSurfaceKHR, IntPtr, VkSurfaceFormatKHR*, VkResult>)vkGetPhysicalDeviceSurfaceFormatsKHR_ptr)(physicalDevice, surface, pSurfaceFormatCount, pSurfaceFormats);
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfaceFormatsKHR(VkPhysicalDevice physicalDevice, VkSurfaceKHR surface, IntPtr pSurfaceFormatCount, out VkSurfaceFormatKHR pSurfaceFormats)
	{
		fixed (VkSurfaceFormatKHR* ptr = &pSurfaceFormats)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkSurfaceKHR, IntPtr, VkSurfaceFormatKHR*, VkResult>)vkGetPhysicalDeviceSurfaceFormatsKHR_ptr)(physicalDevice, surface, pSurfaceFormatCount, ptr);
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfacePresentModesKHR(VkPhysicalDevice physicalDevice, VkSurfaceKHR surface, uint* pPresentModeCount, VkPresentModeKHR* pPresentModes)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkSurfaceKHR, uint*, VkPresentModeKHR*, VkResult>)vkGetPhysicalDeviceSurfacePresentModesKHR_ptr)(physicalDevice, surface, pPresentModeCount, pPresentModes);
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfacePresentModesKHR(VkPhysicalDevice physicalDevice, VkSurfaceKHR surface, uint* pPresentModeCount, out VkPresentModeKHR pPresentModes)
	{
		fixed (VkPresentModeKHR* ptr = &pPresentModes)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkSurfaceKHR, uint*, VkPresentModeKHR*, VkResult>)vkGetPhysicalDeviceSurfacePresentModesKHR_ptr)(physicalDevice, surface, pPresentModeCount, ptr);
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfacePresentModesKHR(VkPhysicalDevice physicalDevice, VkSurfaceKHR surface, ref uint pPresentModeCount, VkPresentModeKHR* pPresentModes)
	{
		fixed (uint* ptr = &pPresentModeCount)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkSurfaceKHR, uint*, VkPresentModeKHR*, VkResult>)vkGetPhysicalDeviceSurfacePresentModesKHR_ptr)(physicalDevice, surface, ptr, pPresentModes);
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfacePresentModesKHR(VkPhysicalDevice physicalDevice, VkSurfaceKHR surface, ref uint pPresentModeCount, out VkPresentModeKHR pPresentModes)
	{
		fixed (uint* ptr = &pPresentModeCount)
		{
			fixed (VkPresentModeKHR* ptr2 = &pPresentModes)
			{
				return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkSurfaceKHR, uint*, VkPresentModeKHR*, VkResult>)vkGetPhysicalDeviceSurfacePresentModesKHR_ptr)(physicalDevice, surface, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfacePresentModesKHR(VkPhysicalDevice physicalDevice, VkSurfaceKHR surface, IntPtr pPresentModeCount, VkPresentModeKHR* pPresentModes)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkSurfaceKHR, IntPtr, VkPresentModeKHR*, VkResult>)vkGetPhysicalDeviceSurfacePresentModesKHR_ptr)(physicalDevice, surface, pPresentModeCount, pPresentModes);
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfacePresentModesKHR(VkPhysicalDevice physicalDevice, VkSurfaceKHR surface, IntPtr pPresentModeCount, out VkPresentModeKHR pPresentModes)
	{
		fixed (VkPresentModeKHR* ptr = &pPresentModes)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkSurfaceKHR, IntPtr, VkPresentModeKHR*, VkResult>)vkGetPhysicalDeviceSurfacePresentModesKHR_ptr)(physicalDevice, surface, pPresentModeCount, ptr);
		}
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfaceSupportKHR(VkPhysicalDevice physicalDevice, uint queueFamilyIndex, VkSurfaceKHR surface, VkBool32* pSupported)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint, VkSurfaceKHR, VkBool32*, VkResult>)vkGetPhysicalDeviceSurfaceSupportKHR_ptr)(physicalDevice, queueFamilyIndex, surface, pSupported);
	}

	public unsafe static VkResult vkGetPhysicalDeviceSurfaceSupportKHR(VkPhysicalDevice physicalDevice, uint queueFamilyIndex, VkSurfaceKHR surface, out VkBool32 pSupported)
	{
		fixed (VkBool32* ptr = &pSupported)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint, VkSurfaceKHR, VkBool32*, VkResult>)vkGetPhysicalDeviceSurfaceSupportKHR_ptr)(physicalDevice, queueFamilyIndex, surface, ptr);
		}
	}

	public unsafe static VkBool32 vkGetPhysicalDeviceWaylandPresentationSupportKHR(VkPhysicalDevice physicalDevice, uint queueFamilyIndex, wl_display* display)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint, wl_display*, VkBool32>)vkGetPhysicalDeviceWaylandPresentationSupportKHR_ptr)(physicalDevice, queueFamilyIndex, display);
	}

	public unsafe static VkBool32 vkGetPhysicalDeviceWaylandPresentationSupportKHR(VkPhysicalDevice physicalDevice, uint queueFamilyIndex, out wl_display display)
	{
		fixed (wl_display* ptr = &display)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint, wl_display*, VkBool32>)vkGetPhysicalDeviceWaylandPresentationSupportKHR_ptr)(physicalDevice, queueFamilyIndex, ptr);
		}
	}

	public unsafe static VkBool32 vkGetPhysicalDeviceWin32PresentationSupportKHR(VkPhysicalDevice physicalDevice, uint queueFamilyIndex)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint, VkBool32>)vkGetPhysicalDeviceWin32PresentationSupportKHR_ptr)(physicalDevice, queueFamilyIndex);
	}

	public unsafe static VkBool32 vkGetPhysicalDeviceXcbPresentationSupportKHR(VkPhysicalDevice physicalDevice, uint queueFamilyIndex, xcb_connection_t* connection, xcb_visualid_t visual_id)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint, xcb_connection_t*, xcb_visualid_t, VkBool32>)vkGetPhysicalDeviceXcbPresentationSupportKHR_ptr)(physicalDevice, queueFamilyIndex, connection, visual_id);
	}

	public unsafe static VkBool32 vkGetPhysicalDeviceXcbPresentationSupportKHR(VkPhysicalDevice physicalDevice, uint queueFamilyIndex, ref xcb_connection_t connection, xcb_visualid_t visual_id)
	{
		fixed (xcb_connection_t* ptr = &connection)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint, xcb_connection_t*, xcb_visualid_t, VkBool32>)vkGetPhysicalDeviceXcbPresentationSupportKHR_ptr)(physicalDevice, queueFamilyIndex, ptr, visual_id);
		}
	}

	public unsafe static VkBool32 vkGetPhysicalDeviceXcbPresentationSupportKHR(VkPhysicalDevice physicalDevice, uint queueFamilyIndex, IntPtr connection, xcb_visualid_t visual_id)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint, IntPtr, xcb_visualid_t, VkBool32>)vkGetPhysicalDeviceXcbPresentationSupportKHR_ptr)(physicalDevice, queueFamilyIndex, connection, visual_id);
	}

	public unsafe static VkBool32 vkGetPhysicalDeviceXlibPresentationSupportKHR(VkPhysicalDevice physicalDevice, uint queueFamilyIndex, Display* dpy, VisualID visualID)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint, Display*, VisualID, VkBool32>)vkGetPhysicalDeviceXlibPresentationSupportKHR_ptr)(physicalDevice, queueFamilyIndex, dpy, visualID);
	}

	public unsafe static VkBool32 vkGetPhysicalDeviceXlibPresentationSupportKHR(VkPhysicalDevice physicalDevice, uint queueFamilyIndex, ref Display dpy, VisualID visualID)
	{
		fixed (Display* ptr = &dpy)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint, Display*, VisualID, VkBool32>)vkGetPhysicalDeviceXlibPresentationSupportKHR_ptr)(physicalDevice, queueFamilyIndex, ptr, visualID);
		}
	}

	public unsafe static VkBool32 vkGetPhysicalDeviceXlibPresentationSupportKHR(VkPhysicalDevice physicalDevice, uint queueFamilyIndex, IntPtr dpy, VisualID visualID)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, uint, IntPtr, VisualID, VkBool32>)vkGetPhysicalDeviceXlibPresentationSupportKHR_ptr)(physicalDevice, queueFamilyIndex, dpy, visualID);
	}

	public unsafe static VkResult vkGetPipelineCacheData(VkDevice device, VkPipelineCache pipelineCache, UIntPtr* pDataSize, void* pData)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, UIntPtr*, void*, VkResult>)vkGetPipelineCacheData_ptr)(device, pipelineCache, pDataSize, pData);
	}

	public unsafe static VkResult vkGetPipelineCacheData(VkDevice device, VkPipelineCache pipelineCache, ref UIntPtr pDataSize, void* pData)
	{
		fixed (UIntPtr* ptr = &pDataSize)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, UIntPtr*, void*, VkResult>)vkGetPipelineCacheData_ptr)(device, pipelineCache, ptr, pData);
		}
	}

	public unsafe static VkResult vkGetPipelineCacheData(VkDevice device, VkPipelineCache pipelineCache, IntPtr pDataSize, void* pData)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, IntPtr, void*, VkResult>)vkGetPipelineCacheData_ptr)(device, pipelineCache, pDataSize, pData);
	}

	public unsafe static VkResult vkGetQueryPoolResults(VkDevice device, VkQueryPool queryPool, uint firstQuery, uint queryCount, UIntPtr dataSize, void* pData, ulong stride, VkQueryResultFlags flags)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkQueryPool, uint, uint, UIntPtr, void*, ulong, VkQueryResultFlags, VkResult>)vkGetQueryPoolResults_ptr)(device, queryPool, firstQuery, queryCount, dataSize, pData, stride, flags);
	}

	public unsafe static VkResult vkGetRandROutputDisplayEXT(VkPhysicalDevice physicalDevice, Display* dpy, IntPtr rrOutput, VkDisplayKHR* pDisplay)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, Display*, IntPtr, VkDisplayKHR*, VkResult>)vkGetRandROutputDisplayEXT_ptr)(physicalDevice, dpy, rrOutput, pDisplay);
	}

	public unsafe static VkResult vkGetRandROutputDisplayEXT(VkPhysicalDevice physicalDevice, Display* dpy, IntPtr rrOutput, out VkDisplayKHR pDisplay)
	{
		fixed (VkDisplayKHR* ptr = &pDisplay)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, Display*, IntPtr, VkDisplayKHR*, VkResult>)vkGetRandROutputDisplayEXT_ptr)(physicalDevice, dpy, rrOutput, ptr);
		}
	}

	public unsafe static VkResult vkGetRandROutputDisplayEXT(VkPhysicalDevice physicalDevice, ref Display dpy, IntPtr rrOutput, VkDisplayKHR* pDisplay)
	{
		fixed (Display* ptr = &dpy)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, Display*, IntPtr, VkDisplayKHR*, VkResult>)vkGetRandROutputDisplayEXT_ptr)(physicalDevice, ptr, rrOutput, pDisplay);
		}
	}

	public unsafe static VkResult vkGetRandROutputDisplayEXT(VkPhysicalDevice physicalDevice, ref Display dpy, IntPtr rrOutput, out VkDisplayKHR pDisplay)
	{
		fixed (Display* ptr = &dpy)
		{
			fixed (VkDisplayKHR* ptr2 = &pDisplay)
			{
				return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, Display*, IntPtr, VkDisplayKHR*, VkResult>)vkGetRandROutputDisplayEXT_ptr)(physicalDevice, ptr, rrOutput, ptr2);
			}
		}
	}

	public unsafe static VkResult vkGetRandROutputDisplayEXT(VkPhysicalDevice physicalDevice, IntPtr dpy, IntPtr rrOutput, VkDisplayKHR* pDisplay)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, IntPtr, VkDisplayKHR*, VkResult>)vkGetRandROutputDisplayEXT_ptr)(physicalDevice, dpy, rrOutput, pDisplay);
	}

	public unsafe static VkResult vkGetRandROutputDisplayEXT(VkPhysicalDevice physicalDevice, IntPtr dpy, IntPtr rrOutput, out VkDisplayKHR pDisplay)
	{
		fixed (VkDisplayKHR* ptr = &pDisplay)
		{
			return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, IntPtr, IntPtr, VkDisplayKHR*, VkResult>)vkGetRandROutputDisplayEXT_ptr)(physicalDevice, dpy, rrOutput, ptr);
		}
	}

	public unsafe static VkResult vkGetRefreshCycleDurationGOOGLE(VkDevice device, VkSwapchainKHR swapchain, VkRefreshCycleDurationGOOGLE* pDisplayTimingProperties)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkSwapchainKHR, VkRefreshCycleDurationGOOGLE*, VkResult>)vkGetRefreshCycleDurationGOOGLE_ptr)(device, swapchain, pDisplayTimingProperties);
	}

	public unsafe static VkResult vkGetRefreshCycleDurationGOOGLE(VkDevice device, VkSwapchainKHR swapchain, out VkRefreshCycleDurationGOOGLE pDisplayTimingProperties)
	{
		fixed (VkRefreshCycleDurationGOOGLE* ptr = &pDisplayTimingProperties)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkSwapchainKHR, VkRefreshCycleDurationGOOGLE*, VkResult>)vkGetRefreshCycleDurationGOOGLE_ptr)(device, swapchain, ptr);
		}
	}

	public unsafe static void vkGetRenderAreaGranularity(VkDevice device, VkRenderPass renderPass, VkExtent2D* pGranularity)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkRenderPass, VkExtent2D*, void>)vkGetRenderAreaGranularity_ptr)(device, renderPass, pGranularity);
	}

	public unsafe static void vkGetRenderAreaGranularity(VkDevice device, VkRenderPass renderPass, out VkExtent2D pGranularity)
	{
		fixed (VkExtent2D* ptr = &pGranularity)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, VkRenderPass, VkExtent2D*, void>)vkGetRenderAreaGranularity_ptr)(device, renderPass, ptr);
		}
	}

	public unsafe static VkResult vkGetSemaphoreFdKHR(VkDevice device, VkSemaphoreGetFdInfoKHR* pGetFdInfo, int* pFd)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkSemaphoreGetFdInfoKHR*, int*, VkResult>)vkGetSemaphoreFdKHR_ptr)(device, pGetFdInfo, pFd);
	}

	public unsafe static VkResult vkGetSemaphoreFdKHR(VkDevice device, VkSemaphoreGetFdInfoKHR* pGetFdInfo, out int pFd)
	{
		fixed (int* ptr = &pFd)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkSemaphoreGetFdInfoKHR*, int*, VkResult>)vkGetSemaphoreFdKHR_ptr)(device, pGetFdInfo, ptr);
		}
	}

	public unsafe static VkResult vkGetSemaphoreFdKHR(VkDevice device, ref VkSemaphoreGetFdInfoKHR pGetFdInfo, int* pFd)
	{
		fixed (VkSemaphoreGetFdInfoKHR* ptr = &pGetFdInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkSemaphoreGetFdInfoKHR*, int*, VkResult>)vkGetSemaphoreFdKHR_ptr)(device, ptr, pFd);
		}
	}

	public unsafe static VkResult vkGetSemaphoreFdKHR(VkDevice device, ref VkSemaphoreGetFdInfoKHR pGetFdInfo, out int pFd)
	{
		fixed (VkSemaphoreGetFdInfoKHR* ptr = &pGetFdInfo)
		{
			fixed (int* ptr2 = &pFd)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkSemaphoreGetFdInfoKHR*, int*, VkResult>)vkGetSemaphoreFdKHR_ptr)(device, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkGetSemaphoreFdKHR(VkDevice device, IntPtr pGetFdInfo, int* pFd)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, int*, VkResult>)vkGetSemaphoreFdKHR_ptr)(device, pGetFdInfo, pFd);
	}

	public unsafe static VkResult vkGetSemaphoreFdKHR(VkDevice device, IntPtr pGetFdInfo, out int pFd)
	{
		fixed (int* ptr = &pFd)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, int*, VkResult>)vkGetSemaphoreFdKHR_ptr)(device, pGetFdInfo, ptr);
		}
	}

	public unsafe static VkResult vkGetSemaphoreWin32HandleKHR(VkDevice device, VkSemaphoreGetWin32HandleInfoKHR* pGetWin32HandleInfo, HANDLE* pHandle)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkSemaphoreGetWin32HandleInfoKHR*, HANDLE*, VkResult>)vkGetSemaphoreWin32HandleKHR_ptr)(device, pGetWin32HandleInfo, pHandle);
	}

	public unsafe static VkResult vkGetSemaphoreWin32HandleKHR(VkDevice device, VkSemaphoreGetWin32HandleInfoKHR* pGetWin32HandleInfo, out HANDLE pHandle)
	{
		fixed (HANDLE* ptr = &pHandle)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkSemaphoreGetWin32HandleInfoKHR*, HANDLE*, VkResult>)vkGetSemaphoreWin32HandleKHR_ptr)(device, pGetWin32HandleInfo, ptr);
		}
	}

	public unsafe static VkResult vkGetSemaphoreWin32HandleKHR(VkDevice device, ref VkSemaphoreGetWin32HandleInfoKHR pGetWin32HandleInfo, HANDLE* pHandle)
	{
		fixed (VkSemaphoreGetWin32HandleInfoKHR* ptr = &pGetWin32HandleInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkSemaphoreGetWin32HandleInfoKHR*, HANDLE*, VkResult>)vkGetSemaphoreWin32HandleKHR_ptr)(device, ptr, pHandle);
		}
	}

	public unsafe static VkResult vkGetSemaphoreWin32HandleKHR(VkDevice device, ref VkSemaphoreGetWin32HandleInfoKHR pGetWin32HandleInfo, out HANDLE pHandle)
	{
		fixed (VkSemaphoreGetWin32HandleInfoKHR* ptr = &pGetWin32HandleInfo)
		{
			fixed (HANDLE* ptr2 = &pHandle)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkSemaphoreGetWin32HandleInfoKHR*, HANDLE*, VkResult>)vkGetSemaphoreWin32HandleKHR_ptr)(device, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkGetSemaphoreWin32HandleKHR(VkDevice device, IntPtr pGetWin32HandleInfo, HANDLE* pHandle)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, HANDLE*, VkResult>)vkGetSemaphoreWin32HandleKHR_ptr)(device, pGetWin32HandleInfo, pHandle);
	}

	public unsafe static VkResult vkGetSemaphoreWin32HandleKHR(VkDevice device, IntPtr pGetWin32HandleInfo, out HANDLE pHandle)
	{
		fixed (HANDLE* ptr = &pHandle)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, HANDLE*, VkResult>)vkGetSemaphoreWin32HandleKHR_ptr)(device, pGetWin32HandleInfo, ptr);
		}
	}

	public unsafe static VkResult vkGetShaderInfoAMD(VkDevice device, VkPipeline pipeline, VkShaderStageFlags shaderStage, VkShaderInfoTypeAMD infoType, UIntPtr* pInfoSize, void* pInfo)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipeline, VkShaderStageFlags, VkShaderInfoTypeAMD, UIntPtr*, void*, VkResult>)vkGetShaderInfoAMD_ptr)(device, pipeline, shaderStage, infoType, pInfoSize, pInfo);
	}

	public unsafe static VkResult vkGetShaderInfoAMD(VkDevice device, VkPipeline pipeline, VkShaderStageFlags shaderStage, VkShaderInfoTypeAMD infoType, ref UIntPtr pInfoSize, void* pInfo)
	{
		fixed (UIntPtr* ptr = &pInfoSize)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipeline, VkShaderStageFlags, VkShaderInfoTypeAMD, UIntPtr*, void*, VkResult>)vkGetShaderInfoAMD_ptr)(device, pipeline, shaderStage, infoType, ptr, pInfo);
		}
	}

	public unsafe static VkResult vkGetShaderInfoAMD(VkDevice device, VkPipeline pipeline, VkShaderStageFlags shaderStage, VkShaderInfoTypeAMD infoType, IntPtr pInfoSize, void* pInfo)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipeline, VkShaderStageFlags, VkShaderInfoTypeAMD, IntPtr, void*, VkResult>)vkGetShaderInfoAMD_ptr)(device, pipeline, shaderStage, infoType, pInfoSize, pInfo);
	}

	public unsafe static VkResult vkGetSwapchainCounterEXT(VkDevice device, VkSwapchainKHR swapchain, VkSurfaceCounterFlagsEXT counter, ulong* pCounterValue)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkSwapchainKHR, VkSurfaceCounterFlagsEXT, ulong*, VkResult>)vkGetSwapchainCounterEXT_ptr)(device, swapchain, counter, pCounterValue);
	}

	public unsafe static VkResult vkGetSwapchainCounterEXT(VkDevice device, VkSwapchainKHR swapchain, VkSurfaceCounterFlagsEXT counter, out ulong pCounterValue)
	{
		fixed (ulong* ptr = &pCounterValue)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkSwapchainKHR, VkSurfaceCounterFlagsEXT, ulong*, VkResult>)vkGetSwapchainCounterEXT_ptr)(device, swapchain, counter, ptr);
		}
	}

	public unsafe static VkResult vkGetSwapchainGrallocUsageANDROID(VkDevice device, VkFormat format, VkImageUsageFlags imageUsage, int* grallocUsage)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkFormat, VkImageUsageFlags, int*, VkResult>)vkGetSwapchainGrallocUsageANDROID_ptr)(device, format, imageUsage, grallocUsage);
	}

	public unsafe static VkResult vkGetSwapchainGrallocUsageANDROID(VkDevice device, VkFormat format, VkImageUsageFlags imageUsage, out int grallocUsage)
	{
		fixed (int* ptr = &grallocUsage)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkFormat, VkImageUsageFlags, int*, VkResult>)vkGetSwapchainGrallocUsageANDROID_ptr)(device, format, imageUsage, ptr);
		}
	}

	public unsafe static VkResult vkGetSwapchainImagesKHR(VkDevice device, VkSwapchainKHR swapchain, uint* pSwapchainImageCount, VkImage* pSwapchainImages)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkSwapchainKHR, uint*, VkImage*, VkResult>)vkGetSwapchainImagesKHR_ptr)(device, swapchain, pSwapchainImageCount, pSwapchainImages);
	}

	public unsafe static VkResult vkGetSwapchainImagesKHR(VkDevice device, VkSwapchainKHR swapchain, uint* pSwapchainImageCount, out VkImage pSwapchainImages)
	{
		fixed (VkImage* ptr = &pSwapchainImages)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkSwapchainKHR, uint*, VkImage*, VkResult>)vkGetSwapchainImagesKHR_ptr)(device, swapchain, pSwapchainImageCount, ptr);
		}
	}

	public unsafe static VkResult vkGetSwapchainImagesKHR(VkDevice device, VkSwapchainKHR swapchain, ref uint pSwapchainImageCount, VkImage* pSwapchainImages)
	{
		fixed (uint* ptr = &pSwapchainImageCount)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkSwapchainKHR, uint*, VkImage*, VkResult>)vkGetSwapchainImagesKHR_ptr)(device, swapchain, ptr, pSwapchainImages);
		}
	}

	public unsafe static VkResult vkGetSwapchainImagesKHR(VkDevice device, VkSwapchainKHR swapchain, ref uint pSwapchainImageCount, out VkImage pSwapchainImages)
	{
		fixed (uint* ptr = &pSwapchainImageCount)
		{
			fixed (VkImage* ptr2 = &pSwapchainImages)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkSwapchainKHR, uint*, VkImage*, VkResult>)vkGetSwapchainImagesKHR_ptr)(device, swapchain, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkGetSwapchainImagesKHR(VkDevice device, VkSwapchainKHR swapchain, IntPtr pSwapchainImageCount, VkImage* pSwapchainImages)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkSwapchainKHR, IntPtr, VkImage*, VkResult>)vkGetSwapchainImagesKHR_ptr)(device, swapchain, pSwapchainImageCount, pSwapchainImages);
	}

	public unsafe static VkResult vkGetSwapchainImagesKHR(VkDevice device, VkSwapchainKHR swapchain, IntPtr pSwapchainImageCount, out VkImage pSwapchainImages)
	{
		fixed (VkImage* ptr = &pSwapchainImages)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkSwapchainKHR, IntPtr, VkImage*, VkResult>)vkGetSwapchainImagesKHR_ptr)(device, swapchain, pSwapchainImageCount, ptr);
		}
	}

	public unsafe static VkResult vkGetSwapchainStatusKHR(VkDevice device, VkSwapchainKHR swapchain)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkSwapchainKHR, VkResult>)vkGetSwapchainStatusKHR_ptr)(device, swapchain);
	}

	public unsafe static VkResult vkGetValidationCacheDataEXT(VkDevice device, VkValidationCacheEXT validationCache, UIntPtr* pDataSize, void* pData)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkValidationCacheEXT, UIntPtr*, void*, VkResult>)vkGetValidationCacheDataEXT_ptr)(device, validationCache, pDataSize, pData);
	}

	public unsafe static VkResult vkGetValidationCacheDataEXT(VkDevice device, VkValidationCacheEXT validationCache, ref UIntPtr pDataSize, void* pData)
	{
		fixed (UIntPtr* ptr = &pDataSize)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkValidationCacheEXT, UIntPtr*, void*, VkResult>)vkGetValidationCacheDataEXT_ptr)(device, validationCache, ptr, pData);
		}
	}

	public unsafe static VkResult vkGetValidationCacheDataEXT(VkDevice device, VkValidationCacheEXT validationCache, IntPtr pDataSize, void* pData)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkValidationCacheEXT, IntPtr, void*, VkResult>)vkGetValidationCacheDataEXT_ptr)(device, validationCache, pDataSize, pData);
	}

	public unsafe static VkResult vkImportFenceFdKHR(VkDevice device, VkImportFenceFdInfoKHR* pImportFenceFdInfo)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkImportFenceFdInfoKHR*, VkResult>)vkImportFenceFdKHR_ptr)(device, pImportFenceFdInfo);
	}

	public unsafe static VkResult vkImportFenceFdKHR(VkDevice device, ref VkImportFenceFdInfoKHR pImportFenceFdInfo)
	{
		fixed (VkImportFenceFdInfoKHR* ptr = &pImportFenceFdInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkImportFenceFdInfoKHR*, VkResult>)vkImportFenceFdKHR_ptr)(device, ptr);
		}
	}

	public unsafe static VkResult vkImportFenceFdKHR(VkDevice device, IntPtr pImportFenceFdInfo)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkResult>)vkImportFenceFdKHR_ptr)(device, pImportFenceFdInfo);
	}

	public unsafe static VkResult vkImportFenceWin32HandleKHR(VkDevice device, VkImportFenceWin32HandleInfoKHR* pImportFenceWin32HandleInfo)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkImportFenceWin32HandleInfoKHR*, VkResult>)vkImportFenceWin32HandleKHR_ptr)(device, pImportFenceWin32HandleInfo);
	}

	public unsafe static VkResult vkImportFenceWin32HandleKHR(VkDevice device, ref VkImportFenceWin32HandleInfoKHR pImportFenceWin32HandleInfo)
	{
		fixed (VkImportFenceWin32HandleInfoKHR* ptr = &pImportFenceWin32HandleInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkImportFenceWin32HandleInfoKHR*, VkResult>)vkImportFenceWin32HandleKHR_ptr)(device, ptr);
		}
	}

	public unsafe static VkResult vkImportFenceWin32HandleKHR(VkDevice device, IntPtr pImportFenceWin32HandleInfo)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkResult>)vkImportFenceWin32HandleKHR_ptr)(device, pImportFenceWin32HandleInfo);
	}

	public unsafe static VkResult vkImportSemaphoreFdKHR(VkDevice device, VkImportSemaphoreFdInfoKHR* pImportSemaphoreFdInfo)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkImportSemaphoreFdInfoKHR*, VkResult>)vkImportSemaphoreFdKHR_ptr)(device, pImportSemaphoreFdInfo);
	}

	public unsafe static VkResult vkImportSemaphoreFdKHR(VkDevice device, ref VkImportSemaphoreFdInfoKHR pImportSemaphoreFdInfo)
	{
		fixed (VkImportSemaphoreFdInfoKHR* ptr = &pImportSemaphoreFdInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkImportSemaphoreFdInfoKHR*, VkResult>)vkImportSemaphoreFdKHR_ptr)(device, ptr);
		}
	}

	public unsafe static VkResult vkImportSemaphoreFdKHR(VkDevice device, IntPtr pImportSemaphoreFdInfo)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkResult>)vkImportSemaphoreFdKHR_ptr)(device, pImportSemaphoreFdInfo);
	}

	public unsafe static VkResult vkImportSemaphoreWin32HandleKHR(VkDevice device, VkImportSemaphoreWin32HandleInfoKHR* pImportSemaphoreWin32HandleInfo)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkImportSemaphoreWin32HandleInfoKHR*, VkResult>)vkImportSemaphoreWin32HandleKHR_ptr)(device, pImportSemaphoreWin32HandleInfo);
	}

	public unsafe static VkResult vkImportSemaphoreWin32HandleKHR(VkDevice device, ref VkImportSemaphoreWin32HandleInfoKHR pImportSemaphoreWin32HandleInfo)
	{
		fixed (VkImportSemaphoreWin32HandleInfoKHR* ptr = &pImportSemaphoreWin32HandleInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkImportSemaphoreWin32HandleInfoKHR*, VkResult>)vkImportSemaphoreWin32HandleKHR_ptr)(device, ptr);
		}
	}

	public unsafe static VkResult vkImportSemaphoreWin32HandleKHR(VkDevice device, IntPtr pImportSemaphoreWin32HandleInfo)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkResult>)vkImportSemaphoreWin32HandleKHR_ptr)(device, pImportSemaphoreWin32HandleInfo);
	}

	public unsafe static VkResult vkInvalidateMappedMemoryRanges(VkDevice device, uint memoryRangeCount, VkMappedMemoryRange* pMemoryRanges)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, uint, VkMappedMemoryRange*, VkResult>)vkInvalidateMappedMemoryRanges_ptr)(device, memoryRangeCount, pMemoryRanges);
	}

	public unsafe static VkResult vkInvalidateMappedMemoryRanges(VkDevice device, uint memoryRangeCount, ref VkMappedMemoryRange pMemoryRanges)
	{
		fixed (VkMappedMemoryRange* ptr = &pMemoryRanges)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, uint, VkMappedMemoryRange*, VkResult>)vkInvalidateMappedMemoryRanges_ptr)(device, memoryRangeCount, ptr);
		}
	}

	public unsafe static VkResult vkInvalidateMappedMemoryRanges(VkDevice device, uint memoryRangeCount, IntPtr pMemoryRanges)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, uint, IntPtr, VkResult>)vkInvalidateMappedMemoryRanges_ptr)(device, memoryRangeCount, pMemoryRanges);
	}

	public unsafe static VkResult vkMapMemory(VkDevice device, VkDeviceMemory memory, ulong offset, ulong size, uint flags, void** ppData)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkDeviceMemory, ulong, ulong, uint, void**, VkResult>)vkMapMemory_ptr)(device, memory, offset, size, flags, ppData);
	}

	public unsafe static VkResult vkMergePipelineCaches(VkDevice device, VkPipelineCache dstCache, uint srcCacheCount, VkPipelineCache* pSrcCaches)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, VkPipelineCache*, VkResult>)vkMergePipelineCaches_ptr)(device, dstCache, srcCacheCount, pSrcCaches);
	}

	public unsafe static VkResult vkMergePipelineCaches(VkDevice device, VkPipelineCache dstCache, uint srcCacheCount, ref VkPipelineCache pSrcCaches)
	{
		fixed (VkPipelineCache* ptr = &pSrcCaches)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, VkPipelineCache*, VkResult>)vkMergePipelineCaches_ptr)(device, dstCache, srcCacheCount, ptr);
		}
	}

	public unsafe static VkResult vkMergePipelineCaches(VkDevice device, VkPipelineCache dstCache, uint srcCacheCount, IntPtr pSrcCaches)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkPipelineCache, uint, IntPtr, VkResult>)vkMergePipelineCaches_ptr)(device, dstCache, srcCacheCount, pSrcCaches);
	}

	public unsafe static VkResult vkMergeValidationCachesEXT(VkDevice device, VkValidationCacheEXT dstCache, uint srcCacheCount, VkValidationCacheEXT* pSrcCaches)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkValidationCacheEXT, uint, VkValidationCacheEXT*, VkResult>)vkMergeValidationCachesEXT_ptr)(device, dstCache, srcCacheCount, pSrcCaches);
	}

	public unsafe static VkResult vkMergeValidationCachesEXT(VkDevice device, VkValidationCacheEXT dstCache, uint srcCacheCount, ref VkValidationCacheEXT pSrcCaches)
	{
		fixed (VkValidationCacheEXT* ptr = &pSrcCaches)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkValidationCacheEXT, uint, VkValidationCacheEXT*, VkResult>)vkMergeValidationCachesEXT_ptr)(device, dstCache, srcCacheCount, ptr);
		}
	}

	public unsafe static VkResult vkMergeValidationCachesEXT(VkDevice device, VkValidationCacheEXT dstCache, uint srcCacheCount, IntPtr pSrcCaches)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkValidationCacheEXT, uint, IntPtr, VkResult>)vkMergeValidationCachesEXT_ptr)(device, dstCache, srcCacheCount, pSrcCaches);
	}

	public unsafe static VkResult vkQueueBindSparse(VkQueue queue, uint bindInfoCount, VkBindSparseInfo* pBindInfo, VkFence fence)
	{
		return ((delegate* unmanaged[Stdcall]<VkQueue, uint, VkBindSparseInfo*, VkFence, VkResult>)vkQueueBindSparse_ptr)(queue, bindInfoCount, pBindInfo, fence);
	}

	public unsafe static VkResult vkQueueBindSparse(VkQueue queue, uint bindInfoCount, ref VkBindSparseInfo pBindInfo, VkFence fence)
	{
		fixed (VkBindSparseInfo* ptr = &pBindInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkQueue, uint, VkBindSparseInfo*, VkFence, VkResult>)vkQueueBindSparse_ptr)(queue, bindInfoCount, ptr, fence);
		}
	}

	public unsafe static VkResult vkQueueBindSparse(VkQueue queue, uint bindInfoCount, IntPtr pBindInfo, VkFence fence)
	{
		return ((delegate* unmanaged[Stdcall]<VkQueue, uint, IntPtr, VkFence, VkResult>)vkQueueBindSparse_ptr)(queue, bindInfoCount, pBindInfo, fence);
	}

	public unsafe static VkResult vkQueuePresentKHR(VkQueue queue, VkPresentInfoKHR* pPresentInfo)
	{
		return ((delegate* unmanaged[Stdcall]<VkQueue, VkPresentInfoKHR*, VkResult>)vkQueuePresentKHR_ptr)(queue, pPresentInfo);
	}

	public unsafe static VkResult vkQueuePresentKHR(VkQueue queue, ref VkPresentInfoKHR pPresentInfo)
	{
		fixed (VkPresentInfoKHR* ptr = &pPresentInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkQueue, VkPresentInfoKHR*, VkResult>)vkQueuePresentKHR_ptr)(queue, ptr);
		}
	}

	public unsafe static VkResult vkQueuePresentKHR(VkQueue queue, IntPtr pPresentInfo)
	{
		return ((delegate* unmanaged[Stdcall]<VkQueue, IntPtr, VkResult>)vkQueuePresentKHR_ptr)(queue, pPresentInfo);
	}

	public unsafe static VkResult vkQueueSignalReleaseImageANDROID(VkQueue queue, uint waitSemaphoreCount, VkSemaphore* pWaitSemaphores, VkImage image, int* pNativeFenceFd)
	{
		return ((delegate* unmanaged[Stdcall]<VkQueue, uint, VkSemaphore*, VkImage, int*, VkResult>)vkQueueSignalReleaseImageANDROID_ptr)(queue, waitSemaphoreCount, pWaitSemaphores, image, pNativeFenceFd);
	}

	public unsafe static VkResult vkQueueSignalReleaseImageANDROID(VkQueue queue, uint waitSemaphoreCount, VkSemaphore* pWaitSemaphores, VkImage image, ref int pNativeFenceFd)
	{
		fixed (int* ptr = &pNativeFenceFd)
		{
			return ((delegate* unmanaged[Stdcall]<VkQueue, uint, VkSemaphore*, VkImage, int*, VkResult>)vkQueueSignalReleaseImageANDROID_ptr)(queue, waitSemaphoreCount, pWaitSemaphores, image, ptr);
		}
	}

	public unsafe static VkResult vkQueueSignalReleaseImageANDROID(VkQueue queue, uint waitSemaphoreCount, VkSemaphore* pWaitSemaphores, VkImage image, IntPtr pNativeFenceFd)
	{
		return ((delegate* unmanaged[Stdcall]<VkQueue, uint, VkSemaphore*, VkImage, IntPtr, VkResult>)vkQueueSignalReleaseImageANDROID_ptr)(queue, waitSemaphoreCount, pWaitSemaphores, image, pNativeFenceFd);
	}

	public unsafe static VkResult vkQueueSignalReleaseImageANDROID(VkQueue queue, uint waitSemaphoreCount, ref VkSemaphore pWaitSemaphores, VkImage image, int* pNativeFenceFd)
	{
		fixed (VkSemaphore* ptr = &pWaitSemaphores)
		{
			return ((delegate* unmanaged[Stdcall]<VkQueue, uint, VkSemaphore*, VkImage, int*, VkResult>)vkQueueSignalReleaseImageANDROID_ptr)(queue, waitSemaphoreCount, ptr, image, pNativeFenceFd);
		}
	}

	public unsafe static VkResult vkQueueSignalReleaseImageANDROID(VkQueue queue, uint waitSemaphoreCount, ref VkSemaphore pWaitSemaphores, VkImage image, ref int pNativeFenceFd)
	{
		fixed (VkSemaphore* ptr = &pWaitSemaphores)
		{
			fixed (int* ptr2 = &pNativeFenceFd)
			{
				return ((delegate* unmanaged[Stdcall]<VkQueue, uint, VkSemaphore*, VkImage, int*, VkResult>)vkQueueSignalReleaseImageANDROID_ptr)(queue, waitSemaphoreCount, ptr, image, ptr2);
			}
		}
	}

	public unsafe static VkResult vkQueueSignalReleaseImageANDROID(VkQueue queue, uint waitSemaphoreCount, ref VkSemaphore pWaitSemaphores, VkImage image, IntPtr pNativeFenceFd)
	{
		fixed (VkSemaphore* ptr = &pWaitSemaphores)
		{
			return ((delegate* unmanaged[Stdcall]<VkQueue, uint, VkSemaphore*, VkImage, IntPtr, VkResult>)vkQueueSignalReleaseImageANDROID_ptr)(queue, waitSemaphoreCount, ptr, image, pNativeFenceFd);
		}
	}

	public unsafe static VkResult vkQueueSignalReleaseImageANDROID(VkQueue queue, uint waitSemaphoreCount, IntPtr pWaitSemaphores, VkImage image, int* pNativeFenceFd)
	{
		return ((delegate* unmanaged[Stdcall]<VkQueue, uint, IntPtr, VkImage, int*, VkResult>)vkQueueSignalReleaseImageANDROID_ptr)(queue, waitSemaphoreCount, pWaitSemaphores, image, pNativeFenceFd);
	}

	public unsafe static VkResult vkQueueSignalReleaseImageANDROID(VkQueue queue, uint waitSemaphoreCount, IntPtr pWaitSemaphores, VkImage image, ref int pNativeFenceFd)
	{
		fixed (int* ptr = &pNativeFenceFd)
		{
			return ((delegate* unmanaged[Stdcall]<VkQueue, uint, IntPtr, VkImage, int*, VkResult>)vkQueueSignalReleaseImageANDROID_ptr)(queue, waitSemaphoreCount, pWaitSemaphores, image, ptr);
		}
	}

	public unsafe static VkResult vkQueueSignalReleaseImageANDROID(VkQueue queue, uint waitSemaphoreCount, IntPtr pWaitSemaphores, VkImage image, IntPtr pNativeFenceFd)
	{
		return ((delegate* unmanaged[Stdcall]<VkQueue, uint, IntPtr, VkImage, IntPtr, VkResult>)vkQueueSignalReleaseImageANDROID_ptr)(queue, waitSemaphoreCount, pWaitSemaphores, image, pNativeFenceFd);
	}

	public unsafe static VkResult vkQueueSubmit(VkQueue queue, uint submitCount, VkSubmitInfo* pSubmits, VkFence fence)
	{
		return ((delegate* unmanaged[Stdcall]<VkQueue, uint, VkSubmitInfo*, VkFence, VkResult>)vkQueueSubmit_ptr)(queue, submitCount, pSubmits, fence);
	}

	public unsafe static VkResult vkQueueSubmit(VkQueue queue, uint submitCount, ref VkSubmitInfo pSubmits, VkFence fence)
	{
		fixed (VkSubmitInfo* ptr = &pSubmits)
		{
			return ((delegate* unmanaged[Stdcall]<VkQueue, uint, VkSubmitInfo*, VkFence, VkResult>)vkQueueSubmit_ptr)(queue, submitCount, ptr, fence);
		}
	}

	public unsafe static VkResult vkQueueSubmit(VkQueue queue, uint submitCount, IntPtr pSubmits, VkFence fence)
	{
		return ((delegate* unmanaged[Stdcall]<VkQueue, uint, IntPtr, VkFence, VkResult>)vkQueueSubmit_ptr)(queue, submitCount, pSubmits, fence);
	}

	public unsafe static VkResult vkQueueWaitIdle(VkQueue queue)
	{
		return ((delegate* unmanaged[Stdcall]<VkQueue, VkResult>)vkQueueWaitIdle_ptr)(queue);
	}

	public unsafe static VkResult vkRegisterDeviceEventEXT(VkDevice device, VkDeviceEventInfoEXT* pDeviceEventInfo, VkAllocationCallbacks* pAllocator, VkFence* pFence)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkDeviceEventInfoEXT*, VkAllocationCallbacks*, VkFence*, VkResult>)vkRegisterDeviceEventEXT_ptr)(device, pDeviceEventInfo, pAllocator, pFence);
	}

	public unsafe static VkResult vkRegisterDeviceEventEXT(VkDevice device, VkDeviceEventInfoEXT* pDeviceEventInfo, VkAllocationCallbacks* pAllocator, ref VkFence pFence)
	{
		fixed (VkFence* ptr = &pFence)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDeviceEventInfoEXT*, VkAllocationCallbacks*, VkFence*, VkResult>)vkRegisterDeviceEventEXT_ptr)(device, pDeviceEventInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkRegisterDeviceEventEXT(VkDevice device, VkDeviceEventInfoEXT* pDeviceEventInfo, VkAllocationCallbacks* pAllocator, IntPtr pFence)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkDeviceEventInfoEXT*, VkAllocationCallbacks*, IntPtr, VkResult>)vkRegisterDeviceEventEXT_ptr)(device, pDeviceEventInfo, pAllocator, pFence);
	}

	public unsafe static VkResult vkRegisterDeviceEventEXT(VkDevice device, VkDeviceEventInfoEXT* pDeviceEventInfo, ref VkAllocationCallbacks pAllocator, VkFence* pFence)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDeviceEventInfoEXT*, VkAllocationCallbacks*, VkFence*, VkResult>)vkRegisterDeviceEventEXT_ptr)(device, pDeviceEventInfo, ptr, pFence);
		}
	}

	public unsafe static VkResult vkRegisterDeviceEventEXT(VkDevice device, VkDeviceEventInfoEXT* pDeviceEventInfo, ref VkAllocationCallbacks pAllocator, ref VkFence pFence)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkFence* ptr2 = &pFence)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkDeviceEventInfoEXT*, VkAllocationCallbacks*, VkFence*, VkResult>)vkRegisterDeviceEventEXT_ptr)(device, pDeviceEventInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkRegisterDeviceEventEXT(VkDevice device, VkDeviceEventInfoEXT* pDeviceEventInfo, ref VkAllocationCallbacks pAllocator, IntPtr pFence)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDeviceEventInfoEXT*, VkAllocationCallbacks*, IntPtr, VkResult>)vkRegisterDeviceEventEXT_ptr)(device, pDeviceEventInfo, ptr, pFence);
		}
	}

	public unsafe static VkResult vkRegisterDeviceEventEXT(VkDevice device, VkDeviceEventInfoEXT* pDeviceEventInfo, IntPtr pAllocator, VkFence* pFence)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkDeviceEventInfoEXT*, IntPtr, VkFence*, VkResult>)vkRegisterDeviceEventEXT_ptr)(device, pDeviceEventInfo, pAllocator, pFence);
	}

	public unsafe static VkResult vkRegisterDeviceEventEXT(VkDevice device, VkDeviceEventInfoEXT* pDeviceEventInfo, IntPtr pAllocator, ref VkFence pFence)
	{
		fixed (VkFence* ptr = &pFence)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDeviceEventInfoEXT*, IntPtr, VkFence*, VkResult>)vkRegisterDeviceEventEXT_ptr)(device, pDeviceEventInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkRegisterDeviceEventEXT(VkDevice device, VkDeviceEventInfoEXT* pDeviceEventInfo, IntPtr pAllocator, IntPtr pFence)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkDeviceEventInfoEXT*, IntPtr, IntPtr, VkResult>)vkRegisterDeviceEventEXT_ptr)(device, pDeviceEventInfo, pAllocator, pFence);
	}

	public unsafe static VkResult vkRegisterDeviceEventEXT(VkDevice device, ref VkDeviceEventInfoEXT pDeviceEventInfo, VkAllocationCallbacks* pAllocator, VkFence* pFence)
	{
		fixed (VkDeviceEventInfoEXT* ptr = &pDeviceEventInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDeviceEventInfoEXT*, VkAllocationCallbacks*, VkFence*, VkResult>)vkRegisterDeviceEventEXT_ptr)(device, ptr, pAllocator, pFence);
		}
	}

	public unsafe static VkResult vkRegisterDeviceEventEXT(VkDevice device, ref VkDeviceEventInfoEXT pDeviceEventInfo, VkAllocationCallbacks* pAllocator, ref VkFence pFence)
	{
		fixed (VkDeviceEventInfoEXT* ptr = &pDeviceEventInfo)
		{
			fixed (VkFence* ptr2 = &pFence)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkDeviceEventInfoEXT*, VkAllocationCallbacks*, VkFence*, VkResult>)vkRegisterDeviceEventEXT_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkRegisterDeviceEventEXT(VkDevice device, ref VkDeviceEventInfoEXT pDeviceEventInfo, VkAllocationCallbacks* pAllocator, IntPtr pFence)
	{
		fixed (VkDeviceEventInfoEXT* ptr = &pDeviceEventInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDeviceEventInfoEXT*, VkAllocationCallbacks*, IntPtr, VkResult>)vkRegisterDeviceEventEXT_ptr)(device, ptr, pAllocator, pFence);
		}
	}

	public unsafe static VkResult vkRegisterDeviceEventEXT(VkDevice device, ref VkDeviceEventInfoEXT pDeviceEventInfo, ref VkAllocationCallbacks pAllocator, VkFence* pFence)
	{
		fixed (VkDeviceEventInfoEXT* ptr = &pDeviceEventInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkDeviceEventInfoEXT*, VkAllocationCallbacks*, VkFence*, VkResult>)vkRegisterDeviceEventEXT_ptr)(device, ptr, ptr2, pFence);
			}
		}
	}

	public unsafe static VkResult vkRegisterDeviceEventEXT(VkDevice device, ref VkDeviceEventInfoEXT pDeviceEventInfo, ref VkAllocationCallbacks pAllocator, ref VkFence pFence)
	{
		fixed (VkDeviceEventInfoEXT* ptr = &pDeviceEventInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkFence* ptr3 = &pFence)
				{
					return ((delegate* unmanaged[Stdcall]<VkDevice, VkDeviceEventInfoEXT*, VkAllocationCallbacks*, VkFence*, VkResult>)vkRegisterDeviceEventEXT_ptr)(device, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkRegisterDeviceEventEXT(VkDevice device, ref VkDeviceEventInfoEXT pDeviceEventInfo, ref VkAllocationCallbacks pAllocator, IntPtr pFence)
	{
		fixed (VkDeviceEventInfoEXT* ptr = &pDeviceEventInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkDeviceEventInfoEXT*, VkAllocationCallbacks*, IntPtr, VkResult>)vkRegisterDeviceEventEXT_ptr)(device, ptr, ptr2, pFence);
			}
		}
	}

	public unsafe static VkResult vkRegisterDeviceEventEXT(VkDevice device, ref VkDeviceEventInfoEXT pDeviceEventInfo, IntPtr pAllocator, VkFence* pFence)
	{
		fixed (VkDeviceEventInfoEXT* ptr = &pDeviceEventInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDeviceEventInfoEXT*, IntPtr, VkFence*, VkResult>)vkRegisterDeviceEventEXT_ptr)(device, ptr, pAllocator, pFence);
		}
	}

	public unsafe static VkResult vkRegisterDeviceEventEXT(VkDevice device, ref VkDeviceEventInfoEXT pDeviceEventInfo, IntPtr pAllocator, ref VkFence pFence)
	{
		fixed (VkDeviceEventInfoEXT* ptr = &pDeviceEventInfo)
		{
			fixed (VkFence* ptr2 = &pFence)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkDeviceEventInfoEXT*, IntPtr, VkFence*, VkResult>)vkRegisterDeviceEventEXT_ptr)(device, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkRegisterDeviceEventEXT(VkDevice device, ref VkDeviceEventInfoEXT pDeviceEventInfo, IntPtr pAllocator, IntPtr pFence)
	{
		fixed (VkDeviceEventInfoEXT* ptr = &pDeviceEventInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDeviceEventInfoEXT*, IntPtr, IntPtr, VkResult>)vkRegisterDeviceEventEXT_ptr)(device, ptr, pAllocator, pFence);
		}
	}

	public unsafe static VkResult vkRegisterDeviceEventEXT(VkDevice device, IntPtr pDeviceEventInfo, VkAllocationCallbacks* pAllocator, VkFence* pFence)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkFence*, VkResult>)vkRegisterDeviceEventEXT_ptr)(device, pDeviceEventInfo, pAllocator, pFence);
	}

	public unsafe static VkResult vkRegisterDeviceEventEXT(VkDevice device, IntPtr pDeviceEventInfo, VkAllocationCallbacks* pAllocator, ref VkFence pFence)
	{
		fixed (VkFence* ptr = &pFence)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkFence*, VkResult>)vkRegisterDeviceEventEXT_ptr)(device, pDeviceEventInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkRegisterDeviceEventEXT(VkDevice device, IntPtr pDeviceEventInfo, VkAllocationCallbacks* pAllocator, IntPtr pFence)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, IntPtr, VkResult>)vkRegisterDeviceEventEXT_ptr)(device, pDeviceEventInfo, pAllocator, pFence);
	}

	public unsafe static VkResult vkRegisterDeviceEventEXT(VkDevice device, IntPtr pDeviceEventInfo, ref VkAllocationCallbacks pAllocator, VkFence* pFence)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkFence*, VkResult>)vkRegisterDeviceEventEXT_ptr)(device, pDeviceEventInfo, ptr, pFence);
		}
	}

	public unsafe static VkResult vkRegisterDeviceEventEXT(VkDevice device, IntPtr pDeviceEventInfo, ref VkAllocationCallbacks pAllocator, ref VkFence pFence)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkFence* ptr2 = &pFence)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, VkFence*, VkResult>)vkRegisterDeviceEventEXT_ptr)(device, pDeviceEventInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkRegisterDeviceEventEXT(VkDevice device, IntPtr pDeviceEventInfo, ref VkAllocationCallbacks pAllocator, IntPtr pFence)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, VkAllocationCallbacks*, IntPtr, VkResult>)vkRegisterDeviceEventEXT_ptr)(device, pDeviceEventInfo, ptr, pFence);
		}
	}

	public unsafe static VkResult vkRegisterDeviceEventEXT(VkDevice device, IntPtr pDeviceEventInfo, IntPtr pAllocator, VkFence* pFence)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkFence*, VkResult>)vkRegisterDeviceEventEXT_ptr)(device, pDeviceEventInfo, pAllocator, pFence);
	}

	public unsafe static VkResult vkRegisterDeviceEventEXT(VkDevice device, IntPtr pDeviceEventInfo, IntPtr pAllocator, ref VkFence pFence)
	{
		fixed (VkFence* ptr = &pFence)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, VkFence*, VkResult>)vkRegisterDeviceEventEXT_ptr)(device, pDeviceEventInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkRegisterDeviceEventEXT(VkDevice device, IntPtr pDeviceEventInfo, IntPtr pAllocator, IntPtr pFence)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, IntPtr, IntPtr, IntPtr, VkResult>)vkRegisterDeviceEventEXT_ptr)(device, pDeviceEventInfo, pAllocator, pFence);
	}

	public unsafe static VkResult vkRegisterDisplayEventEXT(VkDevice device, VkDisplayKHR display, VkDisplayEventInfoEXT* pDisplayEventInfo, VkAllocationCallbacks* pAllocator, VkFence* pFence)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkDisplayKHR, VkDisplayEventInfoEXT*, VkAllocationCallbacks*, VkFence*, VkResult>)vkRegisterDisplayEventEXT_ptr)(device, display, pDisplayEventInfo, pAllocator, pFence);
	}

	public unsafe static VkResult vkRegisterDisplayEventEXT(VkDevice device, VkDisplayKHR display, VkDisplayEventInfoEXT* pDisplayEventInfo, VkAllocationCallbacks* pAllocator, ref VkFence pFence)
	{
		fixed (VkFence* ptr = &pFence)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDisplayKHR, VkDisplayEventInfoEXT*, VkAllocationCallbacks*, VkFence*, VkResult>)vkRegisterDisplayEventEXT_ptr)(device, display, pDisplayEventInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkRegisterDisplayEventEXT(VkDevice device, VkDisplayKHR display, VkDisplayEventInfoEXT* pDisplayEventInfo, VkAllocationCallbacks* pAllocator, IntPtr pFence)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkDisplayKHR, VkDisplayEventInfoEXT*, VkAllocationCallbacks*, IntPtr, VkResult>)vkRegisterDisplayEventEXT_ptr)(device, display, pDisplayEventInfo, pAllocator, pFence);
	}

	public unsafe static VkResult vkRegisterDisplayEventEXT(VkDevice device, VkDisplayKHR display, VkDisplayEventInfoEXT* pDisplayEventInfo, ref VkAllocationCallbacks pAllocator, VkFence* pFence)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDisplayKHR, VkDisplayEventInfoEXT*, VkAllocationCallbacks*, VkFence*, VkResult>)vkRegisterDisplayEventEXT_ptr)(device, display, pDisplayEventInfo, ptr, pFence);
		}
	}

	public unsafe static VkResult vkRegisterDisplayEventEXT(VkDevice device, VkDisplayKHR display, VkDisplayEventInfoEXT* pDisplayEventInfo, ref VkAllocationCallbacks pAllocator, ref VkFence pFence)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkFence* ptr2 = &pFence)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkDisplayKHR, VkDisplayEventInfoEXT*, VkAllocationCallbacks*, VkFence*, VkResult>)vkRegisterDisplayEventEXT_ptr)(device, display, pDisplayEventInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkRegisterDisplayEventEXT(VkDevice device, VkDisplayKHR display, VkDisplayEventInfoEXT* pDisplayEventInfo, ref VkAllocationCallbacks pAllocator, IntPtr pFence)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDisplayKHR, VkDisplayEventInfoEXT*, VkAllocationCallbacks*, IntPtr, VkResult>)vkRegisterDisplayEventEXT_ptr)(device, display, pDisplayEventInfo, ptr, pFence);
		}
	}

	public unsafe static VkResult vkRegisterDisplayEventEXT(VkDevice device, VkDisplayKHR display, VkDisplayEventInfoEXT* pDisplayEventInfo, IntPtr pAllocator, VkFence* pFence)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkDisplayKHR, VkDisplayEventInfoEXT*, IntPtr, VkFence*, VkResult>)vkRegisterDisplayEventEXT_ptr)(device, display, pDisplayEventInfo, pAllocator, pFence);
	}

	public unsafe static VkResult vkRegisterDisplayEventEXT(VkDevice device, VkDisplayKHR display, VkDisplayEventInfoEXT* pDisplayEventInfo, IntPtr pAllocator, ref VkFence pFence)
	{
		fixed (VkFence* ptr = &pFence)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDisplayKHR, VkDisplayEventInfoEXT*, IntPtr, VkFence*, VkResult>)vkRegisterDisplayEventEXT_ptr)(device, display, pDisplayEventInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkRegisterDisplayEventEXT(VkDevice device, VkDisplayKHR display, VkDisplayEventInfoEXT* pDisplayEventInfo, IntPtr pAllocator, IntPtr pFence)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkDisplayKHR, VkDisplayEventInfoEXT*, IntPtr, IntPtr, VkResult>)vkRegisterDisplayEventEXT_ptr)(device, display, pDisplayEventInfo, pAllocator, pFence);
	}

	public unsafe static VkResult vkRegisterDisplayEventEXT(VkDevice device, VkDisplayKHR display, ref VkDisplayEventInfoEXT pDisplayEventInfo, VkAllocationCallbacks* pAllocator, VkFence* pFence)
	{
		fixed (VkDisplayEventInfoEXT* ptr = &pDisplayEventInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDisplayKHR, VkDisplayEventInfoEXT*, VkAllocationCallbacks*, VkFence*, VkResult>)vkRegisterDisplayEventEXT_ptr)(device, display, ptr, pAllocator, pFence);
		}
	}

	public unsafe static VkResult vkRegisterDisplayEventEXT(VkDevice device, VkDisplayKHR display, ref VkDisplayEventInfoEXT pDisplayEventInfo, VkAllocationCallbacks* pAllocator, ref VkFence pFence)
	{
		fixed (VkDisplayEventInfoEXT* ptr = &pDisplayEventInfo)
		{
			fixed (VkFence* ptr2 = &pFence)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkDisplayKHR, VkDisplayEventInfoEXT*, VkAllocationCallbacks*, VkFence*, VkResult>)vkRegisterDisplayEventEXT_ptr)(device, display, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkRegisterDisplayEventEXT(VkDevice device, VkDisplayKHR display, ref VkDisplayEventInfoEXT pDisplayEventInfo, VkAllocationCallbacks* pAllocator, IntPtr pFence)
	{
		fixed (VkDisplayEventInfoEXT* ptr = &pDisplayEventInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDisplayKHR, VkDisplayEventInfoEXT*, VkAllocationCallbacks*, IntPtr, VkResult>)vkRegisterDisplayEventEXT_ptr)(device, display, ptr, pAllocator, pFence);
		}
	}

	public unsafe static VkResult vkRegisterDisplayEventEXT(VkDevice device, VkDisplayKHR display, ref VkDisplayEventInfoEXT pDisplayEventInfo, ref VkAllocationCallbacks pAllocator, VkFence* pFence)
	{
		fixed (VkDisplayEventInfoEXT* ptr = &pDisplayEventInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkDisplayKHR, VkDisplayEventInfoEXT*, VkAllocationCallbacks*, VkFence*, VkResult>)vkRegisterDisplayEventEXT_ptr)(device, display, ptr, ptr2, pFence);
			}
		}
	}

	public unsafe static VkResult vkRegisterDisplayEventEXT(VkDevice device, VkDisplayKHR display, ref VkDisplayEventInfoEXT pDisplayEventInfo, ref VkAllocationCallbacks pAllocator, ref VkFence pFence)
	{
		fixed (VkDisplayEventInfoEXT* ptr = &pDisplayEventInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				fixed (VkFence* ptr3 = &pFence)
				{
					return ((delegate* unmanaged[Stdcall]<VkDevice, VkDisplayKHR, VkDisplayEventInfoEXT*, VkAllocationCallbacks*, VkFence*, VkResult>)vkRegisterDisplayEventEXT_ptr)(device, display, ptr, ptr2, ptr3);
				}
			}
		}
	}

	public unsafe static VkResult vkRegisterDisplayEventEXT(VkDevice device, VkDisplayKHR display, ref VkDisplayEventInfoEXT pDisplayEventInfo, ref VkAllocationCallbacks pAllocator, IntPtr pFence)
	{
		fixed (VkDisplayEventInfoEXT* ptr = &pDisplayEventInfo)
		{
			fixed (VkAllocationCallbacks* ptr2 = &pAllocator)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkDisplayKHR, VkDisplayEventInfoEXT*, VkAllocationCallbacks*, IntPtr, VkResult>)vkRegisterDisplayEventEXT_ptr)(device, display, ptr, ptr2, pFence);
			}
		}
	}

	public unsafe static VkResult vkRegisterDisplayEventEXT(VkDevice device, VkDisplayKHR display, ref VkDisplayEventInfoEXT pDisplayEventInfo, IntPtr pAllocator, VkFence* pFence)
	{
		fixed (VkDisplayEventInfoEXT* ptr = &pDisplayEventInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDisplayKHR, VkDisplayEventInfoEXT*, IntPtr, VkFence*, VkResult>)vkRegisterDisplayEventEXT_ptr)(device, display, ptr, pAllocator, pFence);
		}
	}

	public unsafe static VkResult vkRegisterDisplayEventEXT(VkDevice device, VkDisplayKHR display, ref VkDisplayEventInfoEXT pDisplayEventInfo, IntPtr pAllocator, ref VkFence pFence)
	{
		fixed (VkDisplayEventInfoEXT* ptr = &pDisplayEventInfo)
		{
			fixed (VkFence* ptr2 = &pFence)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkDisplayKHR, VkDisplayEventInfoEXT*, IntPtr, VkFence*, VkResult>)vkRegisterDisplayEventEXT_ptr)(device, display, ptr, pAllocator, ptr2);
			}
		}
	}

	public unsafe static VkResult vkRegisterDisplayEventEXT(VkDevice device, VkDisplayKHR display, ref VkDisplayEventInfoEXT pDisplayEventInfo, IntPtr pAllocator, IntPtr pFence)
	{
		fixed (VkDisplayEventInfoEXT* ptr = &pDisplayEventInfo)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDisplayKHR, VkDisplayEventInfoEXT*, IntPtr, IntPtr, VkResult>)vkRegisterDisplayEventEXT_ptr)(device, display, ptr, pAllocator, pFence);
		}
	}

	public unsafe static VkResult vkRegisterDisplayEventEXT(VkDevice device, VkDisplayKHR display, IntPtr pDisplayEventInfo, VkAllocationCallbacks* pAllocator, VkFence* pFence)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkDisplayKHR, IntPtr, VkAllocationCallbacks*, VkFence*, VkResult>)vkRegisterDisplayEventEXT_ptr)(device, display, pDisplayEventInfo, pAllocator, pFence);
	}

	public unsafe static VkResult vkRegisterDisplayEventEXT(VkDevice device, VkDisplayKHR display, IntPtr pDisplayEventInfo, VkAllocationCallbacks* pAllocator, ref VkFence pFence)
	{
		fixed (VkFence* ptr = &pFence)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDisplayKHR, IntPtr, VkAllocationCallbacks*, VkFence*, VkResult>)vkRegisterDisplayEventEXT_ptr)(device, display, pDisplayEventInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkRegisterDisplayEventEXT(VkDevice device, VkDisplayKHR display, IntPtr pDisplayEventInfo, VkAllocationCallbacks* pAllocator, IntPtr pFence)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkDisplayKHR, IntPtr, VkAllocationCallbacks*, IntPtr, VkResult>)vkRegisterDisplayEventEXT_ptr)(device, display, pDisplayEventInfo, pAllocator, pFence);
	}

	public unsafe static VkResult vkRegisterDisplayEventEXT(VkDevice device, VkDisplayKHR display, IntPtr pDisplayEventInfo, ref VkAllocationCallbacks pAllocator, VkFence* pFence)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDisplayKHR, IntPtr, VkAllocationCallbacks*, VkFence*, VkResult>)vkRegisterDisplayEventEXT_ptr)(device, display, pDisplayEventInfo, ptr, pFence);
		}
	}

	public unsafe static VkResult vkRegisterDisplayEventEXT(VkDevice device, VkDisplayKHR display, IntPtr pDisplayEventInfo, ref VkAllocationCallbacks pAllocator, ref VkFence pFence)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			fixed (VkFence* ptr2 = &pFence)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkDisplayKHR, IntPtr, VkAllocationCallbacks*, VkFence*, VkResult>)vkRegisterDisplayEventEXT_ptr)(device, display, pDisplayEventInfo, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkRegisterDisplayEventEXT(VkDevice device, VkDisplayKHR display, IntPtr pDisplayEventInfo, ref VkAllocationCallbacks pAllocator, IntPtr pFence)
	{
		fixed (VkAllocationCallbacks* ptr = &pAllocator)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDisplayKHR, IntPtr, VkAllocationCallbacks*, IntPtr, VkResult>)vkRegisterDisplayEventEXT_ptr)(device, display, pDisplayEventInfo, ptr, pFence);
		}
	}

	public unsafe static VkResult vkRegisterDisplayEventEXT(VkDevice device, VkDisplayKHR display, IntPtr pDisplayEventInfo, IntPtr pAllocator, VkFence* pFence)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkDisplayKHR, IntPtr, IntPtr, VkFence*, VkResult>)vkRegisterDisplayEventEXT_ptr)(device, display, pDisplayEventInfo, pAllocator, pFence);
	}

	public unsafe static VkResult vkRegisterDisplayEventEXT(VkDevice device, VkDisplayKHR display, IntPtr pDisplayEventInfo, IntPtr pAllocator, ref VkFence pFence)
	{
		fixed (VkFence* ptr = &pFence)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkDisplayKHR, IntPtr, IntPtr, VkFence*, VkResult>)vkRegisterDisplayEventEXT_ptr)(device, display, pDisplayEventInfo, pAllocator, ptr);
		}
	}

	public unsafe static VkResult vkRegisterDisplayEventEXT(VkDevice device, VkDisplayKHR display, IntPtr pDisplayEventInfo, IntPtr pAllocator, IntPtr pFence)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkDisplayKHR, IntPtr, IntPtr, IntPtr, VkResult>)vkRegisterDisplayEventEXT_ptr)(device, display, pDisplayEventInfo, pAllocator, pFence);
	}

	public unsafe static VkResult vkRegisterObjectsNVX(VkDevice device, VkObjectTableNVX objectTable, uint objectCount, VkObjectTableEntryNVX** ppObjectTableEntries, uint* pObjectIndices)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkObjectTableNVX, uint, VkObjectTableEntryNVX**, uint*, VkResult>)vkRegisterObjectsNVX_ptr)(device, objectTable, objectCount, ppObjectTableEntries, pObjectIndices);
	}

	public unsafe static VkResult vkRegisterObjectsNVX(VkDevice device, VkObjectTableNVX objectTable, uint objectCount, VkObjectTableEntryNVX** ppObjectTableEntries, ref uint pObjectIndices)
	{
		fixed (uint* ptr = &pObjectIndices)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkObjectTableNVX, uint, VkObjectTableEntryNVX**, uint*, VkResult>)vkRegisterObjectsNVX_ptr)(device, objectTable, objectCount, ppObjectTableEntries, ptr);
		}
	}

	public unsafe static VkResult vkRegisterObjectsNVX(VkDevice device, VkObjectTableNVX objectTable, uint objectCount, VkObjectTableEntryNVX** ppObjectTableEntries, IntPtr pObjectIndices)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkObjectTableNVX, uint, VkObjectTableEntryNVX**, IntPtr, VkResult>)vkRegisterObjectsNVX_ptr)(device, objectTable, objectCount, ppObjectTableEntries, pObjectIndices);
	}

	public unsafe static VkResult vkRegisterObjectsNVX(VkDevice device, VkObjectTableNVX objectTable, uint objectCount, ref VkObjectTableEntryNVX* ppObjectTableEntries, uint* pObjectIndices)
	{
		fixed (VkObjectTableEntryNVX** ptr = &ppObjectTableEntries)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkObjectTableNVX, uint, VkObjectTableEntryNVX*, uint*, VkResult>)vkRegisterObjectsNVX_ptr)(device, objectTable, objectCount, (VkObjectTableEntryNVX*)ptr, pObjectIndices);
		}
	}

	public unsafe static VkResult vkRegisterObjectsNVX(VkDevice device, VkObjectTableNVX objectTable, uint objectCount, ref VkObjectTableEntryNVX* ppObjectTableEntries, ref uint pObjectIndices)
	{
		fixed (VkObjectTableEntryNVX** ptr = &ppObjectTableEntries)
		{
			fixed (uint* ptr2 = &pObjectIndices)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkObjectTableNVX, uint, VkObjectTableEntryNVX*, uint*, VkResult>)vkRegisterObjectsNVX_ptr)(device, objectTable, objectCount, (VkObjectTableEntryNVX*)ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkRegisterObjectsNVX(VkDevice device, VkObjectTableNVX objectTable, uint objectCount, ref VkObjectTableEntryNVX* ppObjectTableEntries, IntPtr pObjectIndices)
	{
		fixed (VkObjectTableEntryNVX** ptr = &ppObjectTableEntries)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkObjectTableNVX, uint, VkObjectTableEntryNVX*, IntPtr, VkResult>)vkRegisterObjectsNVX_ptr)(device, objectTable, objectCount, (VkObjectTableEntryNVX*)ptr, pObjectIndices);
		}
	}

	public unsafe static VkResult vkRegisterObjectsNVX(VkDevice device, VkObjectTableNVX objectTable, uint objectCount, IntPtr ppObjectTableEntries, uint* pObjectIndices)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkObjectTableNVX, uint, IntPtr, uint*, VkResult>)vkRegisterObjectsNVX_ptr)(device, objectTable, objectCount, ppObjectTableEntries, pObjectIndices);
	}

	public unsafe static VkResult vkRegisterObjectsNVX(VkDevice device, VkObjectTableNVX objectTable, uint objectCount, IntPtr ppObjectTableEntries, ref uint pObjectIndices)
	{
		fixed (uint* ptr = &pObjectIndices)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkObjectTableNVX, uint, IntPtr, uint*, VkResult>)vkRegisterObjectsNVX_ptr)(device, objectTable, objectCount, ppObjectTableEntries, ptr);
		}
	}

	public unsafe static VkResult vkRegisterObjectsNVX(VkDevice device, VkObjectTableNVX objectTable, uint objectCount, IntPtr ppObjectTableEntries, IntPtr pObjectIndices)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkObjectTableNVX, uint, IntPtr, IntPtr, VkResult>)vkRegisterObjectsNVX_ptr)(device, objectTable, objectCount, ppObjectTableEntries, pObjectIndices);
	}

	public unsafe static VkResult vkReleaseDisplayEXT(VkPhysicalDevice physicalDevice, VkDisplayKHR display)
	{
		return ((delegate* unmanaged[Stdcall]<VkPhysicalDevice, VkDisplayKHR, VkResult>)vkReleaseDisplayEXT_ptr)(physicalDevice, display);
	}

	public unsafe static VkResult vkResetCommandBuffer(VkCommandBuffer commandBuffer, VkCommandBufferResetFlags flags)
	{
		return ((delegate* unmanaged[Stdcall]<VkCommandBuffer, VkCommandBufferResetFlags, VkResult>)vkResetCommandBuffer_ptr)(commandBuffer, flags);
	}

	public unsafe static VkResult vkResetCommandPool(VkDevice device, VkCommandPool commandPool, VkCommandPoolResetFlags flags)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkCommandPool, VkCommandPoolResetFlags, VkResult>)vkResetCommandPool_ptr)(device, commandPool, flags);
	}

	public unsafe static VkResult vkResetDescriptorPool(VkDevice device, VkDescriptorPool descriptorPool, uint flags)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorPool, uint, VkResult>)vkResetDescriptorPool_ptr)(device, descriptorPool, flags);
	}

	public unsafe static VkResult vkResetEvent(VkDevice device, VkEvent @event)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkEvent, VkResult>)vkResetEvent_ptr)(device, @event);
	}

	public unsafe static VkResult vkResetFences(VkDevice device, uint fenceCount, VkFence* pFences)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, uint, VkFence*, VkResult>)vkResetFences_ptr)(device, fenceCount, pFences);
	}

	public unsafe static VkResult vkResetFences(VkDevice device, uint fenceCount, ref VkFence pFences)
	{
		fixed (VkFence* ptr = &pFences)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, uint, VkFence*, VkResult>)vkResetFences_ptr)(device, fenceCount, ptr);
		}
	}

	public unsafe static VkResult vkResetFences(VkDevice device, uint fenceCount, IntPtr pFences)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, uint, IntPtr, VkResult>)vkResetFences_ptr)(device, fenceCount, pFences);
	}

	public unsafe static VkResult vkSetEvent(VkDevice device, VkEvent @event)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkEvent, VkResult>)vkSetEvent_ptr)(device, @event);
	}

	public unsafe static void vkSetHdrMetadataEXT(VkDevice device, uint swapchainCount, VkSwapchainKHR* pSwapchains, VkHdrMetadataEXT* pMetadata)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, uint, VkSwapchainKHR*, VkHdrMetadataEXT*, void>)vkSetHdrMetadataEXT_ptr)(device, swapchainCount, pSwapchains, pMetadata);
	}

	public unsafe static void vkSetHdrMetadataEXT(VkDevice device, uint swapchainCount, VkSwapchainKHR* pSwapchains, ref VkHdrMetadataEXT pMetadata)
	{
		fixed (VkHdrMetadataEXT* ptr = &pMetadata)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, uint, VkSwapchainKHR*, VkHdrMetadataEXT*, void>)vkSetHdrMetadataEXT_ptr)(device, swapchainCount, pSwapchains, ptr);
		}
	}

	public unsafe static void vkSetHdrMetadataEXT(VkDevice device, uint swapchainCount, VkSwapchainKHR* pSwapchains, IntPtr pMetadata)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, uint, VkSwapchainKHR*, IntPtr, void>)vkSetHdrMetadataEXT_ptr)(device, swapchainCount, pSwapchains, pMetadata);
	}

	public unsafe static void vkSetHdrMetadataEXT(VkDevice device, uint swapchainCount, ref VkSwapchainKHR pSwapchains, VkHdrMetadataEXT* pMetadata)
	{
		fixed (VkSwapchainKHR* ptr = &pSwapchains)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, uint, VkSwapchainKHR*, VkHdrMetadataEXT*, void>)vkSetHdrMetadataEXT_ptr)(device, swapchainCount, ptr, pMetadata);
		}
	}

	public unsafe static void vkSetHdrMetadataEXT(VkDevice device, uint swapchainCount, ref VkSwapchainKHR pSwapchains, ref VkHdrMetadataEXT pMetadata)
	{
		fixed (VkSwapchainKHR* ptr = &pSwapchains)
		{
			fixed (VkHdrMetadataEXT* ptr2 = &pMetadata)
			{
				((delegate* unmanaged[Stdcall]<VkDevice, uint, VkSwapchainKHR*, VkHdrMetadataEXT*, void>)vkSetHdrMetadataEXT_ptr)(device, swapchainCount, ptr, ptr2);
			}
		}
	}

	public unsafe static void vkSetHdrMetadataEXT(VkDevice device, uint swapchainCount, ref VkSwapchainKHR pSwapchains, IntPtr pMetadata)
	{
		fixed (VkSwapchainKHR* ptr = &pSwapchains)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, uint, VkSwapchainKHR*, IntPtr, void>)vkSetHdrMetadataEXT_ptr)(device, swapchainCount, ptr, pMetadata);
		}
	}

	public unsafe static void vkSetHdrMetadataEXT(VkDevice device, uint swapchainCount, IntPtr pSwapchains, VkHdrMetadataEXT* pMetadata)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, uint, IntPtr, VkHdrMetadataEXT*, void>)vkSetHdrMetadataEXT_ptr)(device, swapchainCount, pSwapchains, pMetadata);
	}

	public unsafe static void vkSetHdrMetadataEXT(VkDevice device, uint swapchainCount, IntPtr pSwapchains, ref VkHdrMetadataEXT pMetadata)
	{
		fixed (VkHdrMetadataEXT* ptr = &pMetadata)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, uint, IntPtr, VkHdrMetadataEXT*, void>)vkSetHdrMetadataEXT_ptr)(device, swapchainCount, pSwapchains, ptr);
		}
	}

	public unsafe static void vkSetHdrMetadataEXT(VkDevice device, uint swapchainCount, IntPtr pSwapchains, IntPtr pMetadata)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, uint, IntPtr, IntPtr, void>)vkSetHdrMetadataEXT_ptr)(device, swapchainCount, pSwapchains, pMetadata);
	}

	public unsafe static void vkTrimCommandPoolKHR(VkDevice device, VkCommandPool commandPool, uint flags)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkCommandPool, uint, void>)vkTrimCommandPoolKHR_ptr)(device, commandPool, flags);
	}

	public unsafe static void vkUnmapMemory(VkDevice device, VkDeviceMemory memory)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkDeviceMemory, void>)vkUnmapMemory_ptr)(device, memory);
	}

	public unsafe static VkResult vkUnregisterObjectsNVX(VkDevice device, VkObjectTableNVX objectTable, uint objectCount, VkObjectEntryTypeNVX* pObjectEntryTypes, uint* pObjectIndices)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkObjectTableNVX, uint, VkObjectEntryTypeNVX*, uint*, VkResult>)vkUnregisterObjectsNVX_ptr)(device, objectTable, objectCount, pObjectEntryTypes, pObjectIndices);
	}

	public unsafe static VkResult vkUnregisterObjectsNVX(VkDevice device, VkObjectTableNVX objectTable, uint objectCount, VkObjectEntryTypeNVX* pObjectEntryTypes, ref uint pObjectIndices)
	{
		fixed (uint* ptr = &pObjectIndices)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkObjectTableNVX, uint, VkObjectEntryTypeNVX*, uint*, VkResult>)vkUnregisterObjectsNVX_ptr)(device, objectTable, objectCount, pObjectEntryTypes, ptr);
		}
	}

	public unsafe static VkResult vkUnregisterObjectsNVX(VkDevice device, VkObjectTableNVX objectTable, uint objectCount, VkObjectEntryTypeNVX* pObjectEntryTypes, IntPtr pObjectIndices)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkObjectTableNVX, uint, VkObjectEntryTypeNVX*, IntPtr, VkResult>)vkUnregisterObjectsNVX_ptr)(device, objectTable, objectCount, pObjectEntryTypes, pObjectIndices);
	}

	public unsafe static VkResult vkUnregisterObjectsNVX(VkDevice device, VkObjectTableNVX objectTable, uint objectCount, ref VkObjectEntryTypeNVX pObjectEntryTypes, uint* pObjectIndices)
	{
		fixed (VkObjectEntryTypeNVX* ptr = &pObjectEntryTypes)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkObjectTableNVX, uint, VkObjectEntryTypeNVX*, uint*, VkResult>)vkUnregisterObjectsNVX_ptr)(device, objectTable, objectCount, ptr, pObjectIndices);
		}
	}

	public unsafe static VkResult vkUnregisterObjectsNVX(VkDevice device, VkObjectTableNVX objectTable, uint objectCount, ref VkObjectEntryTypeNVX pObjectEntryTypes, ref uint pObjectIndices)
	{
		fixed (VkObjectEntryTypeNVX* ptr = &pObjectEntryTypes)
		{
			fixed (uint* ptr2 = &pObjectIndices)
			{
				return ((delegate* unmanaged[Stdcall]<VkDevice, VkObjectTableNVX, uint, VkObjectEntryTypeNVX*, uint*, VkResult>)vkUnregisterObjectsNVX_ptr)(device, objectTable, objectCount, ptr, ptr2);
			}
		}
	}

	public unsafe static VkResult vkUnregisterObjectsNVX(VkDevice device, VkObjectTableNVX objectTable, uint objectCount, ref VkObjectEntryTypeNVX pObjectEntryTypes, IntPtr pObjectIndices)
	{
		fixed (VkObjectEntryTypeNVX* ptr = &pObjectEntryTypes)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkObjectTableNVX, uint, VkObjectEntryTypeNVX*, IntPtr, VkResult>)vkUnregisterObjectsNVX_ptr)(device, objectTable, objectCount, ptr, pObjectIndices);
		}
	}

	public unsafe static VkResult vkUnregisterObjectsNVX(VkDevice device, VkObjectTableNVX objectTable, uint objectCount, IntPtr pObjectEntryTypes, uint* pObjectIndices)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkObjectTableNVX, uint, IntPtr, uint*, VkResult>)vkUnregisterObjectsNVX_ptr)(device, objectTable, objectCount, pObjectEntryTypes, pObjectIndices);
	}

	public unsafe static VkResult vkUnregisterObjectsNVX(VkDevice device, VkObjectTableNVX objectTable, uint objectCount, IntPtr pObjectEntryTypes, ref uint pObjectIndices)
	{
		fixed (uint* ptr = &pObjectIndices)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, VkObjectTableNVX, uint, IntPtr, uint*, VkResult>)vkUnregisterObjectsNVX_ptr)(device, objectTable, objectCount, pObjectEntryTypes, ptr);
		}
	}

	public unsafe static VkResult vkUnregisterObjectsNVX(VkDevice device, VkObjectTableNVX objectTable, uint objectCount, IntPtr pObjectEntryTypes, IntPtr pObjectIndices)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, VkObjectTableNVX, uint, IntPtr, IntPtr, VkResult>)vkUnregisterObjectsNVX_ptr)(device, objectTable, objectCount, pObjectEntryTypes, pObjectIndices);
	}

	public unsafe static void vkUpdateDescriptorSets(VkDevice device, uint descriptorWriteCount, VkWriteDescriptorSet* pDescriptorWrites, uint descriptorCopyCount, VkCopyDescriptorSet* pDescriptorCopies)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, uint, VkWriteDescriptorSet*, uint, VkCopyDescriptorSet*, void>)vkUpdateDescriptorSets_ptr)(device, descriptorWriteCount, pDescriptorWrites, descriptorCopyCount, pDescriptorCopies);
	}

	public unsafe static void vkUpdateDescriptorSets(VkDevice device, uint descriptorWriteCount, VkWriteDescriptorSet* pDescriptorWrites, uint descriptorCopyCount, ref VkCopyDescriptorSet pDescriptorCopies)
	{
		fixed (VkCopyDescriptorSet* ptr = &pDescriptorCopies)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, uint, VkWriteDescriptorSet*, uint, VkCopyDescriptorSet*, void>)vkUpdateDescriptorSets_ptr)(device, descriptorWriteCount, pDescriptorWrites, descriptorCopyCount, ptr);
		}
	}

	public unsafe static void vkUpdateDescriptorSets(VkDevice device, uint descriptorWriteCount, VkWriteDescriptorSet* pDescriptorWrites, uint descriptorCopyCount, IntPtr pDescriptorCopies)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, uint, VkWriteDescriptorSet*, uint, IntPtr, void>)vkUpdateDescriptorSets_ptr)(device, descriptorWriteCount, pDescriptorWrites, descriptorCopyCount, pDescriptorCopies);
	}

	public unsafe static void vkUpdateDescriptorSets(VkDevice device, uint descriptorWriteCount, ref VkWriteDescriptorSet pDescriptorWrites, uint descriptorCopyCount, VkCopyDescriptorSet* pDescriptorCopies)
	{
		fixed (VkWriteDescriptorSet* ptr = &pDescriptorWrites)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, uint, VkWriteDescriptorSet*, uint, VkCopyDescriptorSet*, void>)vkUpdateDescriptorSets_ptr)(device, descriptorWriteCount, ptr, descriptorCopyCount, pDescriptorCopies);
		}
	}

	public unsafe static void vkUpdateDescriptorSets(VkDevice device, uint descriptorWriteCount, ref VkWriteDescriptorSet pDescriptorWrites, uint descriptorCopyCount, ref VkCopyDescriptorSet pDescriptorCopies)
	{
		fixed (VkWriteDescriptorSet* ptr = &pDescriptorWrites)
		{
			fixed (VkCopyDescriptorSet* ptr2 = &pDescriptorCopies)
			{
				((delegate* unmanaged[Stdcall]<VkDevice, uint, VkWriteDescriptorSet*, uint, VkCopyDescriptorSet*, void>)vkUpdateDescriptorSets_ptr)(device, descriptorWriteCount, ptr, descriptorCopyCount, ptr2);
			}
		}
	}

	public unsafe static void vkUpdateDescriptorSets(VkDevice device, uint descriptorWriteCount, ref VkWriteDescriptorSet pDescriptorWrites, uint descriptorCopyCount, IntPtr pDescriptorCopies)
	{
		fixed (VkWriteDescriptorSet* ptr = &pDescriptorWrites)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, uint, VkWriteDescriptorSet*, uint, IntPtr, void>)vkUpdateDescriptorSets_ptr)(device, descriptorWriteCount, ptr, descriptorCopyCount, pDescriptorCopies);
		}
	}

	public unsafe static void vkUpdateDescriptorSets(VkDevice device, uint descriptorWriteCount, IntPtr pDescriptorWrites, uint descriptorCopyCount, VkCopyDescriptorSet* pDescriptorCopies)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, uint, IntPtr, uint, VkCopyDescriptorSet*, void>)vkUpdateDescriptorSets_ptr)(device, descriptorWriteCount, pDescriptorWrites, descriptorCopyCount, pDescriptorCopies);
	}

	public unsafe static void vkUpdateDescriptorSets(VkDevice device, uint descriptorWriteCount, IntPtr pDescriptorWrites, uint descriptorCopyCount, ref VkCopyDescriptorSet pDescriptorCopies)
	{
		fixed (VkCopyDescriptorSet* ptr = &pDescriptorCopies)
		{
			((delegate* unmanaged[Stdcall]<VkDevice, uint, IntPtr, uint, VkCopyDescriptorSet*, void>)vkUpdateDescriptorSets_ptr)(device, descriptorWriteCount, pDescriptorWrites, descriptorCopyCount, ptr);
		}
	}

	public unsafe static void vkUpdateDescriptorSets(VkDevice device, uint descriptorWriteCount, IntPtr pDescriptorWrites, uint descriptorCopyCount, IntPtr pDescriptorCopies)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, uint, IntPtr, uint, IntPtr, void>)vkUpdateDescriptorSets_ptr)(device, descriptorWriteCount, pDescriptorWrites, descriptorCopyCount, pDescriptorCopies);
	}

	public unsafe static void vkUpdateDescriptorSetWithTemplateKHR(VkDevice device, VkDescriptorSet descriptorSet, VkDescriptorUpdateTemplateKHR descriptorUpdateTemplate, void* pData)
	{
		((delegate* unmanaged[Stdcall]<VkDevice, VkDescriptorSet, VkDescriptorUpdateTemplateKHR, void*, void>)vkUpdateDescriptorSetWithTemplateKHR_ptr)(device, descriptorSet, descriptorUpdateTemplate, pData);
	}

	public unsafe static VkResult vkWaitForFences(VkDevice device, uint fenceCount, VkFence* pFences, VkBool32 waitAll, ulong timeout)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, uint, VkFence*, VkBool32, ulong, VkResult>)vkWaitForFences_ptr)(device, fenceCount, pFences, waitAll, timeout);
	}

	public unsafe static VkResult vkWaitForFences(VkDevice device, uint fenceCount, ref VkFence pFences, VkBool32 waitAll, ulong timeout)
	{
		fixed (VkFence* ptr = &pFences)
		{
			return ((delegate* unmanaged[Stdcall]<VkDevice, uint, VkFence*, VkBool32, ulong, VkResult>)vkWaitForFences_ptr)(device, fenceCount, ptr, waitAll, timeout);
		}
	}

	public unsafe static VkResult vkWaitForFences(VkDevice device, uint fenceCount, IntPtr pFences, VkBool32 waitAll, ulong timeout)
	{
		return ((delegate* unmanaged[Stdcall]<VkDevice, uint, IntPtr, VkBool32, ulong, VkResult>)vkWaitForFences_ptr)(device, fenceCount, pFences, waitAll, timeout);
	}

	private static void LoadFunctionPointers()
	{
		vkCreateInstance_ptr = s_nativeLib.LoadFunctionPointer("vkCreateInstance");
		vkDestroyInstance_ptr = s_nativeLib.LoadFunctionPointer("vkDestroyInstance");
		vkEnumeratePhysicalDevices_ptr = s_nativeLib.LoadFunctionPointer("vkEnumeratePhysicalDevices");
		vkGetDeviceProcAddr_ptr = s_nativeLib.LoadFunctionPointer("vkGetDeviceProcAddr");
		vkGetInstanceProcAddr_ptr = s_nativeLib.LoadFunctionPointer("vkGetInstanceProcAddr");
		vkGetPhysicalDeviceProperties_ptr = s_nativeLib.LoadFunctionPointer("vkGetPhysicalDeviceProperties");
		vkGetPhysicalDeviceQueueFamilyProperties_ptr = s_nativeLib.LoadFunctionPointer("vkGetPhysicalDeviceQueueFamilyProperties");
		vkGetPhysicalDeviceMemoryProperties_ptr = s_nativeLib.LoadFunctionPointer("vkGetPhysicalDeviceMemoryProperties");
		vkGetPhysicalDeviceFeatures_ptr = s_nativeLib.LoadFunctionPointer("vkGetPhysicalDeviceFeatures");
		vkGetPhysicalDeviceFormatProperties_ptr = s_nativeLib.LoadFunctionPointer("vkGetPhysicalDeviceFormatProperties");
		vkGetPhysicalDeviceImageFormatProperties_ptr = s_nativeLib.LoadFunctionPointer("vkGetPhysicalDeviceImageFormatProperties");
		vkCreateDevice_ptr = s_nativeLib.LoadFunctionPointer("vkCreateDevice");
		vkDestroyDevice_ptr = s_nativeLib.LoadFunctionPointer("vkDestroyDevice");
		vkEnumerateInstanceLayerProperties_ptr = s_nativeLib.LoadFunctionPointer("vkEnumerateInstanceLayerProperties");
		vkEnumerateInstanceExtensionProperties_ptr = s_nativeLib.LoadFunctionPointer("vkEnumerateInstanceExtensionProperties");
		vkEnumerateDeviceLayerProperties_ptr = s_nativeLib.LoadFunctionPointer("vkEnumerateDeviceLayerProperties");
		vkEnumerateDeviceExtensionProperties_ptr = s_nativeLib.LoadFunctionPointer("vkEnumerateDeviceExtensionProperties");
		vkGetDeviceQueue_ptr = s_nativeLib.LoadFunctionPointer("vkGetDeviceQueue");
		vkQueueSubmit_ptr = s_nativeLib.LoadFunctionPointer("vkQueueSubmit");
		vkQueueWaitIdle_ptr = s_nativeLib.LoadFunctionPointer("vkQueueWaitIdle");
		vkDeviceWaitIdle_ptr = s_nativeLib.LoadFunctionPointer("vkDeviceWaitIdle");
		vkAllocateMemory_ptr = s_nativeLib.LoadFunctionPointer("vkAllocateMemory");
		vkFreeMemory_ptr = s_nativeLib.LoadFunctionPointer("vkFreeMemory");
		vkMapMemory_ptr = s_nativeLib.LoadFunctionPointer("vkMapMemory");
		vkUnmapMemory_ptr = s_nativeLib.LoadFunctionPointer("vkUnmapMemory");
		vkFlushMappedMemoryRanges_ptr = s_nativeLib.LoadFunctionPointer("vkFlushMappedMemoryRanges");
		vkInvalidateMappedMemoryRanges_ptr = s_nativeLib.LoadFunctionPointer("vkInvalidateMappedMemoryRanges");
		vkGetDeviceMemoryCommitment_ptr = s_nativeLib.LoadFunctionPointer("vkGetDeviceMemoryCommitment");
		vkGetBufferMemoryRequirements_ptr = s_nativeLib.LoadFunctionPointer("vkGetBufferMemoryRequirements");
		vkBindBufferMemory_ptr = s_nativeLib.LoadFunctionPointer("vkBindBufferMemory");
		vkGetImageMemoryRequirements_ptr = s_nativeLib.LoadFunctionPointer("vkGetImageMemoryRequirements");
		vkBindImageMemory_ptr = s_nativeLib.LoadFunctionPointer("vkBindImageMemory");
		vkGetImageSparseMemoryRequirements_ptr = s_nativeLib.LoadFunctionPointer("vkGetImageSparseMemoryRequirements");
		vkGetPhysicalDeviceSparseImageFormatProperties_ptr = s_nativeLib.LoadFunctionPointer("vkGetPhysicalDeviceSparseImageFormatProperties");
		vkQueueBindSparse_ptr = s_nativeLib.LoadFunctionPointer("vkQueueBindSparse");
		vkCreateFence_ptr = s_nativeLib.LoadFunctionPointer("vkCreateFence");
		vkDestroyFence_ptr = s_nativeLib.LoadFunctionPointer("vkDestroyFence");
		vkResetFences_ptr = s_nativeLib.LoadFunctionPointer("vkResetFences");
		vkGetFenceStatus_ptr = s_nativeLib.LoadFunctionPointer("vkGetFenceStatus");
		vkWaitForFences_ptr = s_nativeLib.LoadFunctionPointer("vkWaitForFences");
		vkCreateSemaphore_ptr = s_nativeLib.LoadFunctionPointer("vkCreateSemaphore");
		vkDestroySemaphore_ptr = s_nativeLib.LoadFunctionPointer("vkDestroySemaphore");
		vkCreateEvent_ptr = s_nativeLib.LoadFunctionPointer("vkCreateEvent");
		vkDestroyEvent_ptr = s_nativeLib.LoadFunctionPointer("vkDestroyEvent");
		vkGetEventStatus_ptr = s_nativeLib.LoadFunctionPointer("vkGetEventStatus");
		vkSetEvent_ptr = s_nativeLib.LoadFunctionPointer("vkSetEvent");
		vkResetEvent_ptr = s_nativeLib.LoadFunctionPointer("vkResetEvent");
		vkCreateQueryPool_ptr = s_nativeLib.LoadFunctionPointer("vkCreateQueryPool");
		vkDestroyQueryPool_ptr = s_nativeLib.LoadFunctionPointer("vkDestroyQueryPool");
		vkGetQueryPoolResults_ptr = s_nativeLib.LoadFunctionPointer("vkGetQueryPoolResults");
		vkCreateBuffer_ptr = s_nativeLib.LoadFunctionPointer("vkCreateBuffer");
		vkDestroyBuffer_ptr = s_nativeLib.LoadFunctionPointer("vkDestroyBuffer");
		vkCreateBufferView_ptr = s_nativeLib.LoadFunctionPointer("vkCreateBufferView");
		vkDestroyBufferView_ptr = s_nativeLib.LoadFunctionPointer("vkDestroyBufferView");
		vkCreateImage_ptr = s_nativeLib.LoadFunctionPointer("vkCreateImage");
		vkDestroyImage_ptr = s_nativeLib.LoadFunctionPointer("vkDestroyImage");
		vkGetImageSubresourceLayout_ptr = s_nativeLib.LoadFunctionPointer("vkGetImageSubresourceLayout");
		vkCreateImageView_ptr = s_nativeLib.LoadFunctionPointer("vkCreateImageView");
		vkDestroyImageView_ptr = s_nativeLib.LoadFunctionPointer("vkDestroyImageView");
		vkCreateShaderModule_ptr = s_nativeLib.LoadFunctionPointer("vkCreateShaderModule");
		vkDestroyShaderModule_ptr = s_nativeLib.LoadFunctionPointer("vkDestroyShaderModule");
		vkCreatePipelineCache_ptr = s_nativeLib.LoadFunctionPointer("vkCreatePipelineCache");
		vkDestroyPipelineCache_ptr = s_nativeLib.LoadFunctionPointer("vkDestroyPipelineCache");
		vkGetPipelineCacheData_ptr = s_nativeLib.LoadFunctionPointer("vkGetPipelineCacheData");
		vkMergePipelineCaches_ptr = s_nativeLib.LoadFunctionPointer("vkMergePipelineCaches");
		vkCreateGraphicsPipelines_ptr = s_nativeLib.LoadFunctionPointer("vkCreateGraphicsPipelines");
		vkCreateComputePipelines_ptr = s_nativeLib.LoadFunctionPointer("vkCreateComputePipelines");
		vkDestroyPipeline_ptr = s_nativeLib.LoadFunctionPointer("vkDestroyPipeline");
		vkCreatePipelineLayout_ptr = s_nativeLib.LoadFunctionPointer("vkCreatePipelineLayout");
		vkDestroyPipelineLayout_ptr = s_nativeLib.LoadFunctionPointer("vkDestroyPipelineLayout");
		vkCreateSampler_ptr = s_nativeLib.LoadFunctionPointer("vkCreateSampler");
		vkDestroySampler_ptr = s_nativeLib.LoadFunctionPointer("vkDestroySampler");
		vkCreateDescriptorSetLayout_ptr = s_nativeLib.LoadFunctionPointer("vkCreateDescriptorSetLayout");
		vkDestroyDescriptorSetLayout_ptr = s_nativeLib.LoadFunctionPointer("vkDestroyDescriptorSetLayout");
		vkCreateDescriptorPool_ptr = s_nativeLib.LoadFunctionPointer("vkCreateDescriptorPool");
		vkDestroyDescriptorPool_ptr = s_nativeLib.LoadFunctionPointer("vkDestroyDescriptorPool");
		vkResetDescriptorPool_ptr = s_nativeLib.LoadFunctionPointer("vkResetDescriptorPool");
		vkAllocateDescriptorSets_ptr = s_nativeLib.LoadFunctionPointer("vkAllocateDescriptorSets");
		vkFreeDescriptorSets_ptr = s_nativeLib.LoadFunctionPointer("vkFreeDescriptorSets");
		vkUpdateDescriptorSets_ptr = s_nativeLib.LoadFunctionPointer("vkUpdateDescriptorSets");
		vkCreateFramebuffer_ptr = s_nativeLib.LoadFunctionPointer("vkCreateFramebuffer");
		vkDestroyFramebuffer_ptr = s_nativeLib.LoadFunctionPointer("vkDestroyFramebuffer");
		vkCreateRenderPass_ptr = s_nativeLib.LoadFunctionPointer("vkCreateRenderPass");
		vkDestroyRenderPass_ptr = s_nativeLib.LoadFunctionPointer("vkDestroyRenderPass");
		vkGetRenderAreaGranularity_ptr = s_nativeLib.LoadFunctionPointer("vkGetRenderAreaGranularity");
		vkCreateCommandPool_ptr = s_nativeLib.LoadFunctionPointer("vkCreateCommandPool");
		vkDestroyCommandPool_ptr = s_nativeLib.LoadFunctionPointer("vkDestroyCommandPool");
		vkResetCommandPool_ptr = s_nativeLib.LoadFunctionPointer("vkResetCommandPool");
		vkAllocateCommandBuffers_ptr = s_nativeLib.LoadFunctionPointer("vkAllocateCommandBuffers");
		vkFreeCommandBuffers_ptr = s_nativeLib.LoadFunctionPointer("vkFreeCommandBuffers");
		vkBeginCommandBuffer_ptr = s_nativeLib.LoadFunctionPointer("vkBeginCommandBuffer");
		vkEndCommandBuffer_ptr = s_nativeLib.LoadFunctionPointer("vkEndCommandBuffer");
		vkResetCommandBuffer_ptr = s_nativeLib.LoadFunctionPointer("vkResetCommandBuffer");
		vkCmdBindPipeline_ptr = s_nativeLib.LoadFunctionPointer("vkCmdBindPipeline");
		vkCmdSetViewport_ptr = s_nativeLib.LoadFunctionPointer("vkCmdSetViewport");
		vkCmdSetScissor_ptr = s_nativeLib.LoadFunctionPointer("vkCmdSetScissor");
		vkCmdSetLineWidth_ptr = s_nativeLib.LoadFunctionPointer("vkCmdSetLineWidth");
		vkCmdSetDepthBias_ptr = s_nativeLib.LoadFunctionPointer("vkCmdSetDepthBias");
		vkCmdSetBlendConstants_ptr = s_nativeLib.LoadFunctionPointer("vkCmdSetBlendConstants");
		vkCmdSetDepthBounds_ptr = s_nativeLib.LoadFunctionPointer("vkCmdSetDepthBounds");
		vkCmdSetStencilCompareMask_ptr = s_nativeLib.LoadFunctionPointer("vkCmdSetStencilCompareMask");
		vkCmdSetStencilWriteMask_ptr = s_nativeLib.LoadFunctionPointer("vkCmdSetStencilWriteMask");
		vkCmdSetStencilReference_ptr = s_nativeLib.LoadFunctionPointer("vkCmdSetStencilReference");
		vkCmdBindDescriptorSets_ptr = s_nativeLib.LoadFunctionPointer("vkCmdBindDescriptorSets");
		vkCmdBindIndexBuffer_ptr = s_nativeLib.LoadFunctionPointer("vkCmdBindIndexBuffer");
		vkCmdBindVertexBuffers_ptr = s_nativeLib.LoadFunctionPointer("vkCmdBindVertexBuffers");
		vkCmdDraw_ptr = s_nativeLib.LoadFunctionPointer("vkCmdDraw");
		vkCmdDrawIndexed_ptr = s_nativeLib.LoadFunctionPointer("vkCmdDrawIndexed");
		vkCmdDrawIndirect_ptr = s_nativeLib.LoadFunctionPointer("vkCmdDrawIndirect");
		vkCmdDrawIndexedIndirect_ptr = s_nativeLib.LoadFunctionPointer("vkCmdDrawIndexedIndirect");
		vkCmdDispatch_ptr = s_nativeLib.LoadFunctionPointer("vkCmdDispatch");
		vkCmdDispatchIndirect_ptr = s_nativeLib.LoadFunctionPointer("vkCmdDispatchIndirect");
		vkCmdCopyBuffer_ptr = s_nativeLib.LoadFunctionPointer("vkCmdCopyBuffer");
		vkCmdCopyImage_ptr = s_nativeLib.LoadFunctionPointer("vkCmdCopyImage");
		vkCmdBlitImage_ptr = s_nativeLib.LoadFunctionPointer("vkCmdBlitImage");
		vkCmdCopyBufferToImage_ptr = s_nativeLib.LoadFunctionPointer("vkCmdCopyBufferToImage");
		vkCmdCopyImageToBuffer_ptr = s_nativeLib.LoadFunctionPointer("vkCmdCopyImageToBuffer");
		vkCmdUpdateBuffer_ptr = s_nativeLib.LoadFunctionPointer("vkCmdUpdateBuffer");
		vkCmdFillBuffer_ptr = s_nativeLib.LoadFunctionPointer("vkCmdFillBuffer");
		vkCmdClearColorImage_ptr = s_nativeLib.LoadFunctionPointer("vkCmdClearColorImage");
		vkCmdClearDepthStencilImage_ptr = s_nativeLib.LoadFunctionPointer("vkCmdClearDepthStencilImage");
		vkCmdClearAttachments_ptr = s_nativeLib.LoadFunctionPointer("vkCmdClearAttachments");
		vkCmdResolveImage_ptr = s_nativeLib.LoadFunctionPointer("vkCmdResolveImage");
		vkCmdSetEvent_ptr = s_nativeLib.LoadFunctionPointer("vkCmdSetEvent");
		vkCmdResetEvent_ptr = s_nativeLib.LoadFunctionPointer("vkCmdResetEvent");
		vkCmdWaitEvents_ptr = s_nativeLib.LoadFunctionPointer("vkCmdWaitEvents");
		vkCmdPipelineBarrier_ptr = s_nativeLib.LoadFunctionPointer("vkCmdPipelineBarrier");
		vkCmdBeginQuery_ptr = s_nativeLib.LoadFunctionPointer("vkCmdBeginQuery");
		vkCmdEndQuery_ptr = s_nativeLib.LoadFunctionPointer("vkCmdEndQuery");
		vkCmdResetQueryPool_ptr = s_nativeLib.LoadFunctionPointer("vkCmdResetQueryPool");
		vkCmdWriteTimestamp_ptr = s_nativeLib.LoadFunctionPointer("vkCmdWriteTimestamp");
		vkCmdCopyQueryPoolResults_ptr = s_nativeLib.LoadFunctionPointer("vkCmdCopyQueryPoolResults");
		vkCmdPushConstants_ptr = s_nativeLib.LoadFunctionPointer("vkCmdPushConstants");
		vkCmdBeginRenderPass_ptr = s_nativeLib.LoadFunctionPointer("vkCmdBeginRenderPass");
		vkCmdNextSubpass_ptr = s_nativeLib.LoadFunctionPointer("vkCmdNextSubpass");
		vkCmdEndRenderPass_ptr = s_nativeLib.LoadFunctionPointer("vkCmdEndRenderPass");
		vkCmdExecuteCommands_ptr = s_nativeLib.LoadFunctionPointer("vkCmdExecuteCommands");
		vkCreateAndroidSurfaceKHR_ptr = s_nativeLib.LoadFunctionPointer("vkCreateAndroidSurfaceKHR");
		vkGetPhysicalDeviceDisplayPropertiesKHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetPhysicalDeviceDisplayPropertiesKHR");
		vkGetPhysicalDeviceDisplayPlanePropertiesKHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetPhysicalDeviceDisplayPlanePropertiesKHR");
		vkGetDisplayPlaneSupportedDisplaysKHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetDisplayPlaneSupportedDisplaysKHR");
		vkGetDisplayModePropertiesKHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetDisplayModePropertiesKHR");
		vkCreateDisplayModeKHR_ptr = s_nativeLib.LoadFunctionPointer("vkCreateDisplayModeKHR");
		vkGetDisplayPlaneCapabilitiesKHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetDisplayPlaneCapabilitiesKHR");
		vkCreateDisplayPlaneSurfaceKHR_ptr = s_nativeLib.LoadFunctionPointer("vkCreateDisplayPlaneSurfaceKHR");
		vkCreateSharedSwapchainsKHR_ptr = s_nativeLib.LoadFunctionPointer("vkCreateSharedSwapchainsKHR");
		vkCreateMirSurfaceKHR_ptr = s_nativeLib.LoadFunctionPointer("vkCreateMirSurfaceKHR");
		vkGetPhysicalDeviceMirPresentationSupportKHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetPhysicalDeviceMirPresentationSupportKHR");
		vkDestroySurfaceKHR_ptr = s_nativeLib.LoadFunctionPointer("vkDestroySurfaceKHR");
		vkGetPhysicalDeviceSurfaceSupportKHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetPhysicalDeviceSurfaceSupportKHR");
		vkGetPhysicalDeviceSurfaceCapabilitiesKHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetPhysicalDeviceSurfaceCapabilitiesKHR");
		vkGetPhysicalDeviceSurfaceFormatsKHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetPhysicalDeviceSurfaceFormatsKHR");
		vkGetPhysicalDeviceSurfacePresentModesKHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetPhysicalDeviceSurfacePresentModesKHR");
		vkCreateSwapchainKHR_ptr = s_nativeLib.LoadFunctionPointer("vkCreateSwapchainKHR");
		vkDestroySwapchainKHR_ptr = s_nativeLib.LoadFunctionPointer("vkDestroySwapchainKHR");
		vkGetSwapchainImagesKHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetSwapchainImagesKHR");
		vkAcquireNextImageKHR_ptr = s_nativeLib.LoadFunctionPointer("vkAcquireNextImageKHR");
		vkQueuePresentKHR_ptr = s_nativeLib.LoadFunctionPointer("vkQueuePresentKHR");
		vkCreateViSurfaceNN_ptr = s_nativeLib.LoadFunctionPointer("vkCreateViSurfaceNN");
		vkCreateWaylandSurfaceKHR_ptr = s_nativeLib.LoadFunctionPointer("vkCreateWaylandSurfaceKHR");
		vkGetPhysicalDeviceWaylandPresentationSupportKHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetPhysicalDeviceWaylandPresentationSupportKHR");
		vkCreateWin32SurfaceKHR_ptr = s_nativeLib.LoadFunctionPointer("vkCreateWin32SurfaceKHR");
		vkGetPhysicalDeviceWin32PresentationSupportKHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetPhysicalDeviceWin32PresentationSupportKHR");
		vkCreateXlibSurfaceKHR_ptr = s_nativeLib.LoadFunctionPointer("vkCreateXlibSurfaceKHR");
		vkGetPhysicalDeviceXlibPresentationSupportKHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetPhysicalDeviceXlibPresentationSupportKHR");
		vkCreateXcbSurfaceKHR_ptr = s_nativeLib.LoadFunctionPointer("vkCreateXcbSurfaceKHR");
		vkGetPhysicalDeviceXcbPresentationSupportKHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetPhysicalDeviceXcbPresentationSupportKHR");
		vkCreateDebugReportCallbackEXT_ptr = s_nativeLib.LoadFunctionPointer("vkCreateDebugReportCallbackEXT");
		vkDestroyDebugReportCallbackEXT_ptr = s_nativeLib.LoadFunctionPointer("vkDestroyDebugReportCallbackEXT");
		vkDebugReportMessageEXT_ptr = s_nativeLib.LoadFunctionPointer("vkDebugReportMessageEXT");
		vkDebugMarkerSetObjectNameEXT_ptr = s_nativeLib.LoadFunctionPointer("vkDebugMarkerSetObjectNameEXT");
		vkDebugMarkerSetObjectTagEXT_ptr = s_nativeLib.LoadFunctionPointer("vkDebugMarkerSetObjectTagEXT");
		vkCmdDebugMarkerBeginEXT_ptr = s_nativeLib.LoadFunctionPointer("vkCmdDebugMarkerBeginEXT");
		vkCmdDebugMarkerEndEXT_ptr = s_nativeLib.LoadFunctionPointer("vkCmdDebugMarkerEndEXT");
		vkCmdDebugMarkerInsertEXT_ptr = s_nativeLib.LoadFunctionPointer("vkCmdDebugMarkerInsertEXT");
		vkGetPhysicalDeviceExternalImageFormatPropertiesNV_ptr = s_nativeLib.LoadFunctionPointer("vkGetPhysicalDeviceExternalImageFormatPropertiesNV");
		vkGetMemoryWin32HandleNV_ptr = s_nativeLib.LoadFunctionPointer("vkGetMemoryWin32HandleNV");
		vkCmdDrawIndirectCountAMD_ptr = s_nativeLib.LoadFunctionPointer("vkCmdDrawIndirectCountAMD");
		vkCmdDrawIndexedIndirectCountAMD_ptr = s_nativeLib.LoadFunctionPointer("vkCmdDrawIndexedIndirectCountAMD");
		vkCmdProcessCommandsNVX_ptr = s_nativeLib.LoadFunctionPointer("vkCmdProcessCommandsNVX");
		vkCmdReserveSpaceForCommandsNVX_ptr = s_nativeLib.LoadFunctionPointer("vkCmdReserveSpaceForCommandsNVX");
		vkCreateIndirectCommandsLayoutNVX_ptr = s_nativeLib.LoadFunctionPointer("vkCreateIndirectCommandsLayoutNVX");
		vkDestroyIndirectCommandsLayoutNVX_ptr = s_nativeLib.LoadFunctionPointer("vkDestroyIndirectCommandsLayoutNVX");
		vkCreateObjectTableNVX_ptr = s_nativeLib.LoadFunctionPointer("vkCreateObjectTableNVX");
		vkDestroyObjectTableNVX_ptr = s_nativeLib.LoadFunctionPointer("vkDestroyObjectTableNVX");
		vkRegisterObjectsNVX_ptr = s_nativeLib.LoadFunctionPointer("vkRegisterObjectsNVX");
		vkUnregisterObjectsNVX_ptr = s_nativeLib.LoadFunctionPointer("vkUnregisterObjectsNVX");
		vkGetPhysicalDeviceGeneratedCommandsPropertiesNVX_ptr = s_nativeLib.LoadFunctionPointer("vkGetPhysicalDeviceGeneratedCommandsPropertiesNVX");
		vkGetPhysicalDeviceFeatures2KHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetPhysicalDeviceFeatures2KHR");
		vkGetPhysicalDeviceProperties2KHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetPhysicalDeviceProperties2KHR");
		vkGetPhysicalDeviceFormatProperties2KHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetPhysicalDeviceFormatProperties2KHR");
		vkGetPhysicalDeviceImageFormatProperties2KHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetPhysicalDeviceImageFormatProperties2KHR");
		vkGetPhysicalDeviceQueueFamilyProperties2KHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetPhysicalDeviceQueueFamilyProperties2KHR");
		vkGetPhysicalDeviceMemoryProperties2KHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetPhysicalDeviceMemoryProperties2KHR");
		vkGetPhysicalDeviceSparseImageFormatProperties2KHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetPhysicalDeviceSparseImageFormatProperties2KHR");
		vkCmdPushDescriptorSetKHR_ptr = s_nativeLib.LoadFunctionPointer("vkCmdPushDescriptorSetKHR");
		vkTrimCommandPoolKHR_ptr = s_nativeLib.LoadFunctionPointer("vkTrimCommandPoolKHR");
		vkGetPhysicalDeviceExternalBufferPropertiesKHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetPhysicalDeviceExternalBufferPropertiesKHR");
		vkGetMemoryWin32HandleKHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetMemoryWin32HandleKHR");
		vkGetMemoryWin32HandlePropertiesKHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetMemoryWin32HandlePropertiesKHR");
		vkGetMemoryFdKHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetMemoryFdKHR");
		vkGetMemoryFdPropertiesKHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetMemoryFdPropertiesKHR");
		vkGetPhysicalDeviceExternalSemaphorePropertiesKHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetPhysicalDeviceExternalSemaphorePropertiesKHR");
		vkGetSemaphoreWin32HandleKHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetSemaphoreWin32HandleKHR");
		vkImportSemaphoreWin32HandleKHR_ptr = s_nativeLib.LoadFunctionPointer("vkImportSemaphoreWin32HandleKHR");
		vkGetSemaphoreFdKHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetSemaphoreFdKHR");
		vkImportSemaphoreFdKHR_ptr = s_nativeLib.LoadFunctionPointer("vkImportSemaphoreFdKHR");
		vkGetPhysicalDeviceExternalFencePropertiesKHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetPhysicalDeviceExternalFencePropertiesKHR");
		vkGetFenceWin32HandleKHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetFenceWin32HandleKHR");
		vkImportFenceWin32HandleKHR_ptr = s_nativeLib.LoadFunctionPointer("vkImportFenceWin32HandleKHR");
		vkGetFenceFdKHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetFenceFdKHR");
		vkImportFenceFdKHR_ptr = s_nativeLib.LoadFunctionPointer("vkImportFenceFdKHR");
		vkReleaseDisplayEXT_ptr = s_nativeLib.LoadFunctionPointer("vkReleaseDisplayEXT");
		vkAcquireXlibDisplayEXT_ptr = s_nativeLib.LoadFunctionPointer("vkAcquireXlibDisplayEXT");
		vkGetRandROutputDisplayEXT_ptr = s_nativeLib.LoadFunctionPointer("vkGetRandROutputDisplayEXT");
		vkDisplayPowerControlEXT_ptr = s_nativeLib.LoadFunctionPointer("vkDisplayPowerControlEXT");
		vkRegisterDeviceEventEXT_ptr = s_nativeLib.LoadFunctionPointer("vkRegisterDeviceEventEXT");
		vkRegisterDisplayEventEXT_ptr = s_nativeLib.LoadFunctionPointer("vkRegisterDisplayEventEXT");
		vkGetSwapchainCounterEXT_ptr = s_nativeLib.LoadFunctionPointer("vkGetSwapchainCounterEXT");
		vkGetPhysicalDeviceSurfaceCapabilities2EXT_ptr = s_nativeLib.LoadFunctionPointer("vkGetPhysicalDeviceSurfaceCapabilities2EXT");
		vkEnumeratePhysicalDeviceGroupsKHX_ptr = s_nativeLib.LoadFunctionPointer("vkEnumeratePhysicalDeviceGroupsKHX");
		vkGetDeviceGroupPeerMemoryFeaturesKHX_ptr = s_nativeLib.LoadFunctionPointer("vkGetDeviceGroupPeerMemoryFeaturesKHX");
		vkBindBufferMemory2KHR_ptr = s_nativeLib.LoadFunctionPointer("vkBindBufferMemory2KHR");
		vkBindImageMemory2KHR_ptr = s_nativeLib.LoadFunctionPointer("vkBindImageMemory2KHR");
		vkCmdSetDeviceMaskKHX_ptr = s_nativeLib.LoadFunctionPointer("vkCmdSetDeviceMaskKHX");
		vkGetDeviceGroupPresentCapabilitiesKHX_ptr = s_nativeLib.LoadFunctionPointer("vkGetDeviceGroupPresentCapabilitiesKHX");
		vkGetDeviceGroupSurfacePresentModesKHX_ptr = s_nativeLib.LoadFunctionPointer("vkGetDeviceGroupSurfacePresentModesKHX");
		vkAcquireNextImage2KHX_ptr = s_nativeLib.LoadFunctionPointer("vkAcquireNextImage2KHX");
		vkCmdDispatchBaseKHX_ptr = s_nativeLib.LoadFunctionPointer("vkCmdDispatchBaseKHX");
		vkGetPhysicalDevicePresentRectanglesKHX_ptr = s_nativeLib.LoadFunctionPointer("vkGetPhysicalDevicePresentRectanglesKHX");
		vkCreateDescriptorUpdateTemplateKHR_ptr = s_nativeLib.LoadFunctionPointer("vkCreateDescriptorUpdateTemplateKHR");
		vkDestroyDescriptorUpdateTemplateKHR_ptr = s_nativeLib.LoadFunctionPointer("vkDestroyDescriptorUpdateTemplateKHR");
		vkUpdateDescriptorSetWithTemplateKHR_ptr = s_nativeLib.LoadFunctionPointer("vkUpdateDescriptorSetWithTemplateKHR");
		vkCmdPushDescriptorSetWithTemplateKHR_ptr = s_nativeLib.LoadFunctionPointer("vkCmdPushDescriptorSetWithTemplateKHR");
		vkSetHdrMetadataEXT_ptr = s_nativeLib.LoadFunctionPointer("vkSetHdrMetadataEXT");
		vkGetSwapchainStatusKHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetSwapchainStatusKHR");
		vkGetRefreshCycleDurationGOOGLE_ptr = s_nativeLib.LoadFunctionPointer("vkGetRefreshCycleDurationGOOGLE");
		vkGetPastPresentationTimingGOOGLE_ptr = s_nativeLib.LoadFunctionPointer("vkGetPastPresentationTimingGOOGLE");
		vkCreateIOSSurfaceMVK_ptr = s_nativeLib.LoadFunctionPointer("vkCreateIOSSurfaceMVK");
		vkCreateMacOSSurfaceMVK_ptr = s_nativeLib.LoadFunctionPointer("vkCreateMacOSSurfaceMVK");
		vkCmdSetViewportWScalingNV_ptr = s_nativeLib.LoadFunctionPointer("vkCmdSetViewportWScalingNV");
		vkCmdSetDiscardRectangleEXT_ptr = s_nativeLib.LoadFunctionPointer("vkCmdSetDiscardRectangleEXT");
		vkCmdSetSampleLocationsEXT_ptr = s_nativeLib.LoadFunctionPointer("vkCmdSetSampleLocationsEXT");
		vkGetPhysicalDeviceMultisamplePropertiesEXT_ptr = s_nativeLib.LoadFunctionPointer("vkGetPhysicalDeviceMultisamplePropertiesEXT");
		vkGetPhysicalDeviceSurfaceCapabilities2KHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetPhysicalDeviceSurfaceCapabilities2KHR");
		vkGetPhysicalDeviceSurfaceFormats2KHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetPhysicalDeviceSurfaceFormats2KHR");
		vkGetBufferMemoryRequirements2KHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetBufferMemoryRequirements2KHR");
		vkGetImageMemoryRequirements2KHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetImageMemoryRequirements2KHR");
		vkGetImageSparseMemoryRequirements2KHR_ptr = s_nativeLib.LoadFunctionPointer("vkGetImageSparseMemoryRequirements2KHR");
		vkCreateSamplerYcbcrConversionKHR_ptr = s_nativeLib.LoadFunctionPointer("vkCreateSamplerYcbcrConversionKHR");
		vkDestroySamplerYcbcrConversionKHR_ptr = s_nativeLib.LoadFunctionPointer("vkDestroySamplerYcbcrConversionKHR");
		vkCreateValidationCacheEXT_ptr = s_nativeLib.LoadFunctionPointer("vkCreateValidationCacheEXT");
		vkDestroyValidationCacheEXT_ptr = s_nativeLib.LoadFunctionPointer("vkDestroyValidationCacheEXT");
		vkGetValidationCacheDataEXT_ptr = s_nativeLib.LoadFunctionPointer("vkGetValidationCacheDataEXT");
		vkMergeValidationCachesEXT_ptr = s_nativeLib.LoadFunctionPointer("vkMergeValidationCachesEXT");
		vkGetSwapchainGrallocUsageANDROID_ptr = s_nativeLib.LoadFunctionPointer("vkGetSwapchainGrallocUsageANDROID");
		vkAcquireImageANDROID_ptr = s_nativeLib.LoadFunctionPointer("vkAcquireImageANDROID");
		vkQueueSignalReleaseImageANDROID_ptr = s_nativeLib.LoadFunctionPointer("vkQueueSignalReleaseImageANDROID");
		vkGetShaderInfoAMD_ptr = s_nativeLib.LoadFunctionPointer("vkGetShaderInfoAMD");
		vkGetMemoryHostPointerPropertiesEXT_ptr = s_nativeLib.LoadFunctionPointer("vkGetMemoryHostPointerPropertiesEXT");
	}
}
