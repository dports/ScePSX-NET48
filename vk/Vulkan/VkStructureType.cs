namespace Vulkan;

public enum VkStructureType
{
	ApplicationInfo = 0,
	InstanceCreateInfo = 1,
	DeviceQueueCreateInfo = 2,
	DeviceCreateInfo = 3,
	SubmitInfo = 4,
	MemoryAllocateInfo = 5,
	MappedMemoryRange = 6,
	BindSparseInfo = 7,
	FenceCreateInfo = 8,
	SemaphoreCreateInfo = 9,
	EventCreateInfo = 10,
	QueryPoolCreateInfo = 11,
	BufferCreateInfo = 12,
	BufferViewCreateInfo = 13,
	ImageCreateInfo = 14,
	ImageViewCreateInfo = 15,
	ShaderModuleCreateInfo = 16,
	PipelineCacheCreateInfo = 17,
	PipelineShaderStageCreateInfo = 18,
	PipelineVertexInputStateCreateInfo = 19,
	PipelineInputAssemblyStateCreateInfo = 20,
	PipelineTessellationStateCreateInfo = 21,
	PipelineViewportStateCreateInfo = 22,
	PipelineRasterizationStateCreateInfo = 23,
	PipelineMultisampleStateCreateInfo = 24,
	PipelineDepthStencilStateCreateInfo = 25,
	PipelineColorBlendStateCreateInfo = 26,
	PipelineDynamicStateCreateInfo = 27,
	GraphicsPipelineCreateInfo = 28,
	ComputePipelineCreateInfo = 29,
	PipelineLayoutCreateInfo = 30,
	SamplerCreateInfo = 31,
	DescriptorSetLayoutCreateInfo = 32,
	DescriptorPoolCreateInfo = 33,
	DescriptorSetAllocateInfo = 34,
	WriteDescriptorSet = 35,
	CopyDescriptorSet = 36,
	FramebufferCreateInfo = 37,
	RenderPassCreateInfo = 38,
	CommandPoolCreateInfo = 39,
	CommandBufferAllocateInfo = 40,
	CommandBufferInheritanceInfo = 41,
	CommandBufferBeginInfo = 42,
	RenderPassBeginInfo = 43,
	BufferMemoryBarrier = 44,
	ImageMemoryBarrier = 45,
	MemoryBarrier = 46,
	LoaderInstanceCreateInfo = 47,
	LoaderDeviceCreateInfo = 48,
	SwapchainCreateInfoKHR = 1000001000,
	PresentInfoKHR = 1000001001,
	DisplayModeCreateInfoKHR = 1000002000,
	DisplaySurfaceCreateInfoKHR = 1000002001,
	DisplayPresentInfoKHR = 1000003000,
	XlibSurfaceCreateInfoKHR = 1000004000,
	XcbSurfaceCreateInfoKHR = 1000005000,
	WaylandSurfaceCreateInfoKHR = 1000006000,
	MirSurfaceCreateInfoKHR = 1000007000,
	AndroidSurfaceCreateInfoKHR = 1000008000,
	Win32SurfaceCreateInfoKHR = 1000009000,
	NativeBufferAndroid = 1000010000,
	DebugReportCallbackCreateInfoEXT = 1000011000,
	PipelineRasterizationStateRasterizationOrderAMD = 1000018000,
	DebugMarkerObjectNameInfoEXT = 1000022000,
	DebugMarkerObjectTagInfoEXT = 1000022001,
	DebugMarkerMarkerInfoEXT = 1000022002,
	DedicatedAllocationImageCreateInfoNV = 1000026000,
	DedicatedAllocationBufferCreateInfoNV = 1000026001,
	DedicatedAllocationMemoryAllocateInfoNV = 1000026002,
	TextureLodGatherFormatPropertiesAMD = 1000041000,
	RenderPassMultiviewCreateInfoKHX = 1000053000,
	PhysicalDeviceMultiviewFeaturesKHX = 1000053001,
	PhysicalDeviceMultiviewPropertiesKHX = 1000053002,
	ExternalMemoryImageCreateInfoNV = 1000056000,
	ExportMemoryAllocateInfoNV = 1000056001,
	ImportMemoryWin32HandleInfoNV = 1000057000,
	ExportMemoryWin32HandleInfoNV = 1000057001,
	Win32KeyedMutexAcquireReleaseInfoNV = 1000058000,
	PhysicalDeviceFeatures2KHR = 1000059000,
	PhysicalDeviceProperties2KHR = 1000059001,
	FormatProperties2KHR = 1000059002,
	ImageFormatProperties2KHR = 1000059003,
	PhysicalDeviceImageFormatInfo2KHR = 1000059004,
	QueueFamilyProperties2KHR = 1000059005,
	PhysicalDeviceMemoryProperties2KHR = 1000059006,
	SparseImageFormatProperties2KHR = 1000059007,
	PhysicalDeviceSparseImageFormatInfo2KHR = 1000059008,
	MemoryAllocateInfoKHX = 1000060000,
	DeviceGroupRenderPassBeginInfoKHX = 1000060003,
	DeviceGroupCommandBufferBeginInfoKHX = 1000060004,
	DeviceGroupSubmitInfoKHX = 1000060005,
	DeviceGroupBindSparseInfoKHX = 1000060006,
	AcquireNextImageInfoKHX = 1000060010,
	BindBufferMemoryDeviceGroupInfoKHX = 1000060013,
	BindImageMemoryDeviceGroupInfoKHX = 1000060014,
	DeviceGroupPresentCapabilitiesKHX = 1000060007,
	ImageSwapchainCreateInfoKHX = 1000060008,
	BindImageMemorySwapchainInfoKHX = 1000060009,
	DeviceGroupPresentInfoKHX = 1000060011,
	DeviceGroupSwapchainCreateInfoKHX = 1000060012,
	ValidationEXT = 1000061000,
	ViSurfaceCreateInfoNn = 1000062000,
	PhysicalDeviceGroupPropertiesKHX = 1000070000,
	DeviceGroupDeviceCreateInfoKHX = 1000070001,
	PhysicalDeviceExternalImageFormatInfoKHR = 1000071000,
	ExternalImageFormatPropertiesKHR = 1000071001,
	PhysicalDeviceExternalBufferInfoKHR = 1000071002,
	ExternalBufferPropertiesKHR = 1000071003,
	PhysicalDeviceIdPropertiesKHR = 1000071004,
	ExternalMemoryBufferCreateInfoKHR = 1000072000,
	ExternalMemoryImageCreateInfoKHR = 1000072001,
	ExportMemoryAllocateInfoKHR = 1000072002,
	ImportMemoryWin32HandleInfoKHR = 1000073000,
	ExportMemoryWin32HandleInfoKHR = 1000073001,
	MemoryWin32HandlePropertiesKHR = 1000073002,
	MemoryGetWin32HandleInfoKHR = 1000073003,
	ImportMemoryFdInfoKHR = 1000074000,
	MemoryFdPropertiesKHR = 1000074001,
	MemoryGetFdInfoKHR = 1000074002,
	Win32KeyedMutexAcquireReleaseInfoKHR = 1000075000,
	PhysicalDeviceExternalSemaphoreInfoKHR = 1000076000,
	ExternalSemaphorePropertiesKHR = 1000076001,
	ExportSemaphoreCreateInfoKHR = 1000077000,
	ImportSemaphoreWin32HandleInfoKHR = 1000078000,
	ExportSemaphoreWin32HandleInfoKHR = 1000078001,
	D3d12FenceSubmitInfoKHR = 1000078002,
	SemaphoreGetWin32HandleInfoKHR = 1000078003,
	ImportSemaphoreFdInfoKHR = 1000079000,
	SemaphoreGetFdInfoKHR = 1000079001,
	PhysicalDevicePushDescriptorPropertiesKHR = 1000080000,
	PhysicalDevice16bitStorageFeaturesKHR = 1000083000,
	PresentRegionsKHR = 1000084000,
	DescriptorUpdateTemplateCreateInfoKHR = 1000085000,
	ObjectTableCreateInfoNVX = 1000086000,
	IndirectCommandsLayoutCreateInfoNVX = 1000086001,
	CmdProcessCommandsInfoNVX = 1000086002,
	CmdReserveSpaceForCommandsInfoNVX = 1000086003,
	DeviceGeneratedCommandsLimitsNVX = 1000086004,
	DeviceGeneratedCommandsFeaturesNVX = 1000086005,
	PipelineViewportWScalingStateCreateInfoNV = 1000087000,
	SurfaceCapabilities2EXT = 1000090000,
	DisplayPowerInfoEXT = 1000091000,
	DeviceEventInfoEXT = 1000091001,
	DisplayEventInfoEXT = 1000091002,
	SwapchainCounterCreateInfoEXT = 1000091003,
	PresentTimesInfoGoogle = 1000092000,
	PhysicalDeviceMultiviewPerViewAttributesPropertiesNVX = 1000097000,
	PipelineViewportSwizzleStateCreateInfoNV = 1000098000,
	PhysicalDeviceDiscardRectanglePropertiesEXT = 1000099000,
	PipelineDiscardRectangleStateCreateInfoEXT = 1000099001,
	PhysicalDeviceConservativeRasterizationPropertiesEXT = 1000101000,
	PipelineRasterizationConservativeStateCreateInfoEXT = 1000101001,
	HdrMetadataEXT = 1000105000,
	SharedPresentSurfaceCapabilitiesKHR = 1000111000,
	PhysicalDeviceExternalFenceInfoKHR = 1000112000,
	ExternalFencePropertiesKHR = 1000112001,
	ExportFenceCreateInfoKHR = 1000113000,
	ImportFenceWin32HandleInfoKHR = 1000114000,
	ExportFenceWin32HandleInfoKHR = 1000114001,
	FenceGetWin32HandleInfoKHR = 1000114002,
	ImportFenceFdInfoKHR = 1000115000,
	FenceGetFdInfoKHR = 1000115001,
	PhysicalDevicePointClippingPropertiesKHR = 1000117000,
	RenderPassInputAttachmentAspectCreateInfoKHR = 1000117001,
	ImageViewUsageCreateInfoKHR = 1000117002,
	PipelineTessellationDomainOriginStateCreateInfoKHR = 1000117003,
	PhysicalDeviceSurfaceInfo2KHR = 1000119000,
	SurfaceCapabilities2KHR = 1000119001,
	SurfaceFormat2KHR = 1000119002,
	PhysicalDeviceVariablePointerFeaturesKHR = 1000120000,
	IosSurfaceCreateInfoMvk = 1000122000,
	MacosSurfaceCreateInfoMvk = 1000123000,
	MemoryDedicatedRequirementsKHR = 1000127000,
	MemoryDedicatedAllocateInfoKHR = 1000127001,
	PhysicalDeviceSamplerFilterMinmaxPropertiesEXT = 1000130000,
	SamplerReductionModeCreateInfoEXT = 1000130001,
	SampleLocationsInfoEXT = 1000143000,
	RenderPassSampleLocationsBeginInfoEXT = 1000143001,
	PipelineSampleLocationsStateCreateInfoEXT = 1000143002,
	PhysicalDeviceSampleLocationsPropertiesEXT = 1000143003,
	MultisamplePropertiesEXT = 1000143004,
	BufferMemoryRequirementsInfo2KHR = 1000146000,
	ImageMemoryRequirementsInfo2KHR = 1000146001,
	ImageSparseMemoryRequirementsInfo2KHR = 1000146002,
	MemoryRequirements2KHR = 1000146003,
	SparseImageMemoryRequirements2KHR = 1000146004,
	ImageFormatListCreateInfoKHR = 1000147000,
	PhysicalDeviceBlendOperationAdvancedFeaturesEXT = 1000148000,
	PhysicalDeviceBlendOperationAdvancedPropertiesEXT = 1000148001,
	PipelineColorBlendAdvancedStateCreateInfoEXT = 1000148002,
	PipelineCoverageToColorStateCreateInfoNV = 1000149000,
	PipelineCoverageModulationStateCreateInfoNV = 1000152000,
	SamplerYcbcrConversionCreateInfoKHR = 1000156000,
	SamplerYcbcrConversionInfoKHR = 1000156001,
	BindImagePlaneMemoryInfoKHR = 1000156002,
	ImagePlaneMemoryRequirementsInfoKHR = 1000156003,
	PhysicalDeviceSamplerYcbcrConversionFeaturesKHR = 1000156004,
	SamplerYcbcrConversionImageFormatPropertiesKHR = 1000156005,
	BindBufferMemoryInfoKHR = 1000157000,
	BindImageMemoryInfoKHR = 1000157001,
	ValidationCacheCreateInfoEXT = 1000160000,
	ShaderModuleValidationCacheCreateInfoEXT = 1000160001,
	DeviceQueueGlobalPriorityCreateInfoEXT = 1000174000,
	ImportMemoryHostPointerInfoEXT = 1000178000,
	MemoryHostPointerPropertiesEXT = 1000178001,
	PhysicalDeviceExternalMemoryHostPropertiesEXT = 1000178002
}
