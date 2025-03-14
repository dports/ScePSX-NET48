namespace Vulkan;

public enum VkResult
{
	Success = 0,
	NotReady = 1,
	Timeout = 2,
	EventSet = 3,
	EventReset = 4,
	Incomplete = 5,
	ErrorOutOfHostMemory = -1,
	ErrorOutOfDeviceMemory = -2,
	ErrorInitializationFailed = -3,
	ErrorDeviceLost = -4,
	ErrorMemoryMapFailed = -5,
	ErrorLayerNotPresent = -6,
	ErrorExtensionNotPresent = -7,
	ErrorFeatureNotPresent = -8,
	ErrorIncompatibleDriver = -9,
	ErrorTooManyObjects = -10,
	ErrorFormatNotSupported = -11,
	ErrorFragmentedPool = -12,
	ErrorSurfaceLostKHR = -1000000000,
	ErrorNativeWindowInUseKHR = -1000000001,
	SuboptimalKHR = 1000001003,
	ErrorOutOfDateKHR = -1000001004,
	ErrorIncompatibleDisplayKHR = -1000003001,
	ErrorValidationFailedEXT = -1000011001,
	ErrorInvalidShaderNV = -1000012000,
	ErrorOutOfPoolMemoryKHR = -1000069000,
	ErrorInvalidExternalHandleKHR = -1000072003,
	ErrorNotPermittedEXT = -1000174001
}
