using System;

namespace Vulkan;

public unsafe delegate uint PFN_vkDebugReportCallbackEXT(uint flags, VkDebugReportObjectTypeEXT objectType, ulong @object, UIntPtr location, int messageCode, byte* pLayerPrefix, byte* pMessage, void* pUserData);
