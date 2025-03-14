namespace Vulkan;

public static class RawConstants
{
	public const uint VK_MAX_PHYSICAL_DEVICE_NAME_SIZE = 256u;

	public const uint VK_UUID_SIZE = 16u;

	public const uint VK_LUID_SIZE_KHR = 8u;

	public const uint VK_MAX_EXTENSION_NAME_SIZE = 256u;

	public const uint VK_MAX_DESCRIPTION_SIZE = 256u;

	public const uint VK_MAX_MEMORY_TYPES = 32u;

	public const uint VK_MAX_MEMORY_HEAPS = 16u;

	public const float VK_LOD_CLAMP_NONE = 1000f;

	public const uint VK_REMAINING_MIP_LEVELS = uint.MaxValue;

	public const uint VK_REMAINING_ARRAY_LAYERS = uint.MaxValue;

	public const ulong VK_WHOLE_SIZE = ulong.MaxValue;

	public const uint VK_ATTACHMENT_UNUSED = uint.MaxValue;

	public const uint VK_TRUE = 1u;

	public const uint VK_FALSE = 0u;

	public const uint VK_QUEUE_FAMILY_IGNORED = uint.MaxValue;

	public const uint VK_QUEUE_FAMILY_EXTERNAL_KHR = 4294967294u;

	public const uint VK_QUEUE_FAMILY_FOREIGN_EXT = 4294967293u;

	public const uint VK_SUBPASS_EXTERNAL = uint.MaxValue;

	public const uint VK_MAX_DEVICE_GROUP_SIZE_KHX = 32u;

	public const VkImageLayout VK_IMAGE_LAYOUT_UNDEFINED = VkImageLayout.Undefined;

	public const VkImageLayout VK_IMAGE_LAYOUT_GENERAL = VkImageLayout.General;

	public const VkImageLayout VK_IMAGE_LAYOUT_COLOR_ATTACHMENT_OPTIMAL = VkImageLayout.ColorAttachmentOptimal;

	public const VkImageLayout VK_IMAGE_LAYOUT_DEPTH_STENCIL_ATTACHMENT_OPTIMAL = VkImageLayout.DepthStencilAttachmentOptimal;

	public const VkImageLayout VK_IMAGE_LAYOUT_DEPTH_STENCIL_READ_ONLY_OPTIMAL = VkImageLayout.DepthStencilReadOnlyOptimal;

	public const VkImageLayout VK_IMAGE_LAYOUT_SHADER_READ_ONLY_OPTIMAL = VkImageLayout.ShaderReadOnlyOptimal;

	public const VkImageLayout VK_IMAGE_LAYOUT_TRANSFER_SRC_OPTIMAL = VkImageLayout.TransferSrcOptimal;

	public const VkImageLayout VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL = VkImageLayout.TransferDstOptimal;

	public const VkImageLayout VK_IMAGE_LAYOUT_PREINITIALIZED = VkImageLayout.Preinitialized;

	public const VkImageLayout VK_IMAGE_LAYOUT_PRESENT_SRC_KHR = VkImageLayout.PresentSrcKHR;

	public const VkImageLayout VK_IMAGE_LAYOUT_SHARED_PRESENT_KHR = VkImageLayout.SharedPresentKHR;

	public const VkImageLayout VK_IMAGE_LAYOUT_DEPTH_READ_ONLY_STENCIL_ATTACHMENT_OPTIMAL_KHR = VkImageLayout.DepthReadOnlyStencilAttachmentOptimalKHR;

	public const VkImageLayout VK_IMAGE_LAYOUT_DEPTH_ATTACHMENT_STENCIL_READ_ONLY_OPTIMAL_KHR = VkImageLayout.DepthAttachmentStencilReadOnlyOptimalKHR;

	public const VkAttachmentLoadOp VK_ATTACHMENT_LOAD_OP_LOAD = VkAttachmentLoadOp.Load;

	public const VkAttachmentLoadOp VK_ATTACHMENT_LOAD_OP_CLEAR = VkAttachmentLoadOp.Clear;

	public const VkAttachmentLoadOp VK_ATTACHMENT_LOAD_OP_DONT_CARE = VkAttachmentLoadOp.DontCare;

	public const VkAttachmentStoreOp VK_ATTACHMENT_STORE_OP_STORE = VkAttachmentStoreOp.Store;

	public const VkAttachmentStoreOp VK_ATTACHMENT_STORE_OP_DONT_CARE = VkAttachmentStoreOp.DontCare;

	public const VkImageType VK_IMAGE_TYPE_1D = VkImageType.Image1D;

	public const VkImageType VK_IMAGE_TYPE_2D = VkImageType.Image2D;

	public const VkImageType VK_IMAGE_TYPE_3D = VkImageType.Image3D;

	public const VkImageTiling VK_IMAGE_TILING_OPTIMAL = VkImageTiling.Optimal;

	public const VkImageTiling VK_IMAGE_TILING_LINEAR = VkImageTiling.Linear;

	public const VkImageViewType VK_IMAGE_VIEW_TYPE_1D = VkImageViewType.Image1D;

	public const VkImageViewType VK_IMAGE_VIEW_TYPE_2D = VkImageViewType.Image2D;

	public const VkImageViewType VK_IMAGE_VIEW_TYPE_3D = VkImageViewType.Image3D;

	public const VkImageViewType VK_IMAGE_VIEW_TYPE_CUBE = VkImageViewType.ImageCube;

	public const VkImageViewType VK_IMAGE_VIEW_TYPE_1D_ARRAY = VkImageViewType.Image1DArray;

	public const VkImageViewType VK_IMAGE_VIEW_TYPE_2D_ARRAY = VkImageViewType.Image2DArray;

	public const VkImageViewType VK_IMAGE_VIEW_TYPE_CUBE_ARRAY = VkImageViewType.ImageCubeArray;

	public const VkCommandBufferLevel VK_COMMAND_BUFFER_LEVEL_PRIMARY = VkCommandBufferLevel.Primary;

	public const VkCommandBufferLevel VK_COMMAND_BUFFER_LEVEL_SECONDARY = VkCommandBufferLevel.Secondary;

	public const VkComponentSwizzle VK_COMPONENT_SWIZZLE_IDENTITY = VkComponentSwizzle.Identity;

	public const VkComponentSwizzle VK_COMPONENT_SWIZZLE_ZERO = VkComponentSwizzle.Zero;

	public const VkComponentSwizzle VK_COMPONENT_SWIZZLE_ONE = VkComponentSwizzle.One;

	public const VkComponentSwizzle VK_COMPONENT_SWIZZLE_R = VkComponentSwizzle.R;

	public const VkComponentSwizzle VK_COMPONENT_SWIZZLE_G = VkComponentSwizzle.G;

	public const VkComponentSwizzle VK_COMPONENT_SWIZZLE_B = VkComponentSwizzle.B;

	public const VkComponentSwizzle VK_COMPONENT_SWIZZLE_A = VkComponentSwizzle.A;

	public const VkDescriptorType VK_DESCRIPTOR_TYPE_SAMPLER = VkDescriptorType.Sampler;

	public const VkDescriptorType VK_DESCRIPTOR_TYPE_COMBINED_IMAGE_SAMPLER = VkDescriptorType.CombinedImageSampler;

	public const VkDescriptorType VK_DESCRIPTOR_TYPE_SAMPLED_IMAGE = VkDescriptorType.SampledImage;

	public const VkDescriptorType VK_DESCRIPTOR_TYPE_STORAGE_IMAGE = VkDescriptorType.StorageImage;

	public const VkDescriptorType VK_DESCRIPTOR_TYPE_UNIFORM_TEXEL_BUFFER = VkDescriptorType.UniformTexelBuffer;

	public const VkDescriptorType VK_DESCRIPTOR_TYPE_STORAGE_TEXEL_BUFFER = VkDescriptorType.StorageTexelBuffer;

	public const VkDescriptorType VK_DESCRIPTOR_TYPE_UNIFORM_BUFFER = VkDescriptorType.UniformBuffer;

	public const VkDescriptorType VK_DESCRIPTOR_TYPE_STORAGE_BUFFER = VkDescriptorType.StorageBuffer;

	public const VkDescriptorType VK_DESCRIPTOR_TYPE_UNIFORM_BUFFER_DYNAMIC = VkDescriptorType.UniformBufferDynamic;

	public const VkDescriptorType VK_DESCRIPTOR_TYPE_STORAGE_BUFFER_DYNAMIC = VkDescriptorType.StorageBufferDynamic;

	public const VkDescriptorType VK_DESCRIPTOR_TYPE_INPUT_ATTACHMENT = VkDescriptorType.InputAttachment;

	public const VkQueryType VK_QUERY_TYPE_OCCLUSION = VkQueryType.Occlusion;

	public const VkQueryType VK_QUERY_TYPE_PIPELINE_STATISTICS = VkQueryType.PipelineStatistics;

	public const VkQueryType VK_QUERY_TYPE_TIMESTAMP = VkQueryType.Timestamp;

	public const VkBorderColor VK_BORDER_COLOR_FLOAT_TRANSPARENT_BLACK = VkBorderColor.FloatTransparentBlack;

	public const VkBorderColor VK_BORDER_COLOR_INT_TRANSPARENT_BLACK = VkBorderColor.IntTransparentBlack;

	public const VkBorderColor VK_BORDER_COLOR_FLOAT_OPAQUE_BLACK = VkBorderColor.FloatOpaqueBlack;

	public const VkBorderColor VK_BORDER_COLOR_INT_OPAQUE_BLACK = VkBorderColor.IntOpaqueBlack;

	public const VkBorderColor VK_BORDER_COLOR_FLOAT_OPAQUE_WHITE = VkBorderColor.FloatOpaqueWhite;

	public const VkBorderColor VK_BORDER_COLOR_INT_OPAQUE_WHITE = VkBorderColor.IntOpaqueWhite;

	public const VkPipelineBindPoint VK_PIPELINE_BIND_POINT_GRAPHICS = VkPipelineBindPoint.Graphics;

	public const VkPipelineBindPoint VK_PIPELINE_BIND_POINT_COMPUTE = VkPipelineBindPoint.Compute;

	public const VkPipelineCacheHeaderVersion VK_PIPELINE_CACHE_HEADER_VERSION_ONE = VkPipelineCacheHeaderVersion.One;

	public const VkPrimitiveTopology VK_PRIMITIVE_TOPOLOGY_POINT_LIST = VkPrimitiveTopology.PointList;

	public const VkPrimitiveTopology VK_PRIMITIVE_TOPOLOGY_LINE_LIST = VkPrimitiveTopology.LineList;

	public const VkPrimitiveTopology VK_PRIMITIVE_TOPOLOGY_LINE_STRIP = VkPrimitiveTopology.LineStrip;

	public const VkPrimitiveTopology VK_PRIMITIVE_TOPOLOGY_TRIANGLE_LIST = VkPrimitiveTopology.TriangleList;

	public const VkPrimitiveTopology VK_PRIMITIVE_TOPOLOGY_TRIANGLE_STRIP = VkPrimitiveTopology.TriangleStrip;

	public const VkPrimitiveTopology VK_PRIMITIVE_TOPOLOGY_TRIANGLE_FAN = VkPrimitiveTopology.TriangleFan;

	public const VkPrimitiveTopology VK_PRIMITIVE_TOPOLOGY_LINE_LIST_WITH_ADJACENCY = VkPrimitiveTopology.LineListWithAdjacency;

	public const VkPrimitiveTopology VK_PRIMITIVE_TOPOLOGY_LINE_STRIP_WITH_ADJACENCY = VkPrimitiveTopology.LineStripWithAdjacency;

	public const VkPrimitiveTopology VK_PRIMITIVE_TOPOLOGY_TRIANGLE_LIST_WITH_ADJACENCY = VkPrimitiveTopology.TriangleListWithAdjacency;

	public const VkPrimitiveTopology VK_PRIMITIVE_TOPOLOGY_TRIANGLE_STRIP_WITH_ADJACENCY = VkPrimitiveTopology.TriangleStripWithAdjacency;

	public const VkPrimitiveTopology VK_PRIMITIVE_TOPOLOGY_PATCH_LIST = VkPrimitiveTopology.PatchList;

	public const VkSharingMode VK_SHARING_MODE_EXCLUSIVE = VkSharingMode.Exclusive;

	public const VkSharingMode VK_SHARING_MODE_CONCURRENT = VkSharingMode.Concurrent;

	public const VkIndexType VK_INDEX_TYPE_UINT16 = VkIndexType.Uint16;

	public const VkIndexType VK_INDEX_TYPE_UINT32 = VkIndexType.Uint32;

	public const VkFilter VK_FILTER_NEAREST = VkFilter.Nearest;

	public const VkFilter VK_FILTER_LINEAR = VkFilter.Linear;

	public const VkFilter VK_FILTER_CUBIC_IMG = VkFilter.CubicImg;

	public const VkSamplerMipmapMode VK_SAMPLER_MIPMAP_MODE_NEAREST = VkSamplerMipmapMode.Nearest;

	public const VkSamplerMipmapMode VK_SAMPLER_MIPMAP_MODE_LINEAR = VkSamplerMipmapMode.Linear;

	public const VkSamplerAddressMode VK_SAMPLER_ADDRESS_MODE_REPEAT = VkSamplerAddressMode.Repeat;

	public const VkSamplerAddressMode VK_SAMPLER_ADDRESS_MODE_MIRRORED_REPEAT = VkSamplerAddressMode.MirroredRepeat;

	public const VkSamplerAddressMode VK_SAMPLER_ADDRESS_MODE_CLAMP_TO_EDGE = VkSamplerAddressMode.ClampToEdge;

	public const VkSamplerAddressMode VK_SAMPLER_ADDRESS_MODE_CLAMP_TO_BORDER = VkSamplerAddressMode.ClampToBorder;

	public const VkSamplerAddressMode VK_SAMPLER_ADDRESS_MODE_MIRROR_CLAMP_TO_EDGE = VkSamplerAddressMode.MirrorClampToEdge;

	public const VkCompareOp VK_COMPARE_OP_NEVER = VkCompareOp.Never;

	public const VkCompareOp VK_COMPARE_OP_LESS = VkCompareOp.Less;

	public const VkCompareOp VK_COMPARE_OP_EQUAL = VkCompareOp.Equal;

	public const VkCompareOp VK_COMPARE_OP_LESS_OR_EQUAL = VkCompareOp.LessOrEqual;

	public const VkCompareOp VK_COMPARE_OP_GREATER = VkCompareOp.Greater;

	public const VkCompareOp VK_COMPARE_OP_NOT_EQUAL = VkCompareOp.NotEqual;

	public const VkCompareOp VK_COMPARE_OP_GREATER_OR_EQUAL = VkCompareOp.GreaterOrEqual;

	public const VkCompareOp VK_COMPARE_OP_ALWAYS = VkCompareOp.Always;

	public const VkPolygonMode VK_POLYGON_MODE_FILL = VkPolygonMode.Fill;

	public const VkPolygonMode VK_POLYGON_MODE_LINE = VkPolygonMode.Line;

	public const VkPolygonMode VK_POLYGON_MODE_POINT = VkPolygonMode.Point;

	public const VkPolygonMode VK_POLYGON_MODE_FILL_RECTANGLE_NV = VkPolygonMode.FillRectangleNV;

	public const VkCullModeFlags VK_CULL_MODE_NONE = VkCullModeFlags.None;

	public const VkCullModeFlags VK_CULL_MODE_FRONT_BIT = VkCullModeFlags.Front;

	public const VkCullModeFlags VK_CULL_MODE_BACK_BIT = VkCullModeFlags.Back;

	public const VkCullModeFlags VK_CULL_MODE_FRONT_AND_BACK = VkCullModeFlags.FrontAndBack;

	public const VkFrontFace VK_FRONT_FACE_COUNTER_CLOCKWISE = VkFrontFace.CounterClockwise;

	public const VkFrontFace VK_FRONT_FACE_CLOCKWISE = VkFrontFace.Clockwise;

	public const VkBlendFactor VK_BLEND_FACTOR_ZERO = VkBlendFactor.Zero;

	public const VkBlendFactor VK_BLEND_FACTOR_ONE = VkBlendFactor.One;

	public const VkBlendFactor VK_BLEND_FACTOR_SRC_COLOR = VkBlendFactor.SrcColor;

	public const VkBlendFactor VK_BLEND_FACTOR_ONE_MINUS_SRC_COLOR = VkBlendFactor.OneMinusSrcColor;

	public const VkBlendFactor VK_BLEND_FACTOR_DST_COLOR = VkBlendFactor.DstColor;

	public const VkBlendFactor VK_BLEND_FACTOR_ONE_MINUS_DST_COLOR = VkBlendFactor.OneMinusDstColor;

	public const VkBlendFactor VK_BLEND_FACTOR_SRC_ALPHA = VkBlendFactor.SrcAlpha;

	public const VkBlendFactor VK_BLEND_FACTOR_ONE_MINUS_SRC_ALPHA = VkBlendFactor.OneMinusSrcAlpha;

	public const VkBlendFactor VK_BLEND_FACTOR_DST_ALPHA = VkBlendFactor.DstAlpha;

	public const VkBlendFactor VK_BLEND_FACTOR_ONE_MINUS_DST_ALPHA = VkBlendFactor.OneMinusDstAlpha;

	public const VkBlendFactor VK_BLEND_FACTOR_CONSTANT_COLOR = VkBlendFactor.ConstantColor;

	public const VkBlendFactor VK_BLEND_FACTOR_ONE_MINUS_CONSTANT_COLOR = VkBlendFactor.OneMinusConstantColor;

	public const VkBlendFactor VK_BLEND_FACTOR_CONSTANT_ALPHA = VkBlendFactor.ConstantAlpha;

	public const VkBlendFactor VK_BLEND_FACTOR_ONE_MINUS_CONSTANT_ALPHA = VkBlendFactor.OneMinusConstantAlpha;

	public const VkBlendFactor VK_BLEND_FACTOR_SRC_ALPHA_SATURATE = VkBlendFactor.SrcAlphaSaturate;

	public const VkBlendFactor VK_BLEND_FACTOR_SRC1_COLOR = VkBlendFactor.Src1Color;

	public const VkBlendFactor VK_BLEND_FACTOR_ONE_MINUS_SRC1_COLOR = VkBlendFactor.OneMinusSrc1Color;

	public const VkBlendFactor VK_BLEND_FACTOR_SRC1_ALPHA = VkBlendFactor.Src1Alpha;

	public const VkBlendFactor VK_BLEND_FACTOR_ONE_MINUS_SRC1_ALPHA = VkBlendFactor.OneMinusSrc1Alpha;

	public const VkBlendOp VK_BLEND_OP_ADD = VkBlendOp.Add;

	public const VkBlendOp VK_BLEND_OP_SUBTRACT = VkBlendOp.Subtract;

	public const VkBlendOp VK_BLEND_OP_REVERSE_SUBTRACT = VkBlendOp.ReverseSubtract;

	public const VkBlendOp VK_BLEND_OP_MIN = VkBlendOp.Min;

	public const VkBlendOp VK_BLEND_OP_MAX = VkBlendOp.Max;

	public const VkBlendOp VK_BLEND_OP_ZERO_EXT = VkBlendOp.ZeroEXT;

	public const VkBlendOp VK_BLEND_OP_SRC_EXT = VkBlendOp.SrcEXT;

	public const VkBlendOp VK_BLEND_OP_DST_EXT = VkBlendOp.DstEXT;

	public const VkBlendOp VK_BLEND_OP_SRC_OVER_EXT = VkBlendOp.SrcOverEXT;

	public const VkBlendOp VK_BLEND_OP_DST_OVER_EXT = VkBlendOp.DstOverEXT;

	public const VkBlendOp VK_BLEND_OP_SRC_IN_EXT = VkBlendOp.SrcInEXT;

	public const VkBlendOp VK_BLEND_OP_DST_IN_EXT = VkBlendOp.DstInEXT;

	public const VkBlendOp VK_BLEND_OP_SRC_OUT_EXT = VkBlendOp.SrcOutEXT;

	public const VkBlendOp VK_BLEND_OP_DST_OUT_EXT = VkBlendOp.DstOutEXT;

	public const VkBlendOp VK_BLEND_OP_SRC_ATOP_EXT = VkBlendOp.SrcAtopEXT;

	public const VkBlendOp VK_BLEND_OP_DST_ATOP_EXT = VkBlendOp.DstAtopEXT;

	public const VkBlendOp VK_BLEND_OP_XOR_EXT = VkBlendOp.XorEXT;

	public const VkBlendOp VK_BLEND_OP_MULTIPLY_EXT = VkBlendOp.MultiplyEXT;

	public const VkBlendOp VK_BLEND_OP_SCREEN_EXT = VkBlendOp.ScreenEXT;

	public const VkBlendOp VK_BLEND_OP_OVERLAY_EXT = VkBlendOp.OverlayEXT;

	public const VkBlendOp VK_BLEND_OP_DARKEN_EXT = VkBlendOp.DarkenEXT;

	public const VkBlendOp VK_BLEND_OP_LIGHTEN_EXT = VkBlendOp.LightenEXT;

	public const VkBlendOp VK_BLEND_OP_COLORDODGE_EXT = VkBlendOp.ColordodgeEXT;

	public const VkBlendOp VK_BLEND_OP_COLORBURN_EXT = VkBlendOp.ColorburnEXT;

	public const VkBlendOp VK_BLEND_OP_HARDLIGHT_EXT = VkBlendOp.HardlightEXT;

	public const VkBlendOp VK_BLEND_OP_SOFTLIGHT_EXT = VkBlendOp.SoftlightEXT;

	public const VkBlendOp VK_BLEND_OP_DIFFERENCE_EXT = VkBlendOp.DifferenceEXT;

	public const VkBlendOp VK_BLEND_OP_EXCLUSION_EXT = VkBlendOp.ExclusionEXT;

	public const VkBlendOp VK_BLEND_OP_INVERT_EXT = VkBlendOp.InvertEXT;

	public const VkBlendOp VK_BLEND_OP_INVERT_RGB_EXT = VkBlendOp.InvertRgbEXT;

	public const VkBlendOp VK_BLEND_OP_LINEARDODGE_EXT = VkBlendOp.LineardodgeEXT;

	public const VkBlendOp VK_BLEND_OP_LINEARBURN_EXT = VkBlendOp.LinearburnEXT;

	public const VkBlendOp VK_BLEND_OP_VIVIDLIGHT_EXT = VkBlendOp.VividlightEXT;

	public const VkBlendOp VK_BLEND_OP_LINEARLIGHT_EXT = VkBlendOp.LinearlightEXT;

	public const VkBlendOp VK_BLEND_OP_PINLIGHT_EXT = VkBlendOp.PinlightEXT;

	public const VkBlendOp VK_BLEND_OP_HARDMIX_EXT = VkBlendOp.HardmixEXT;

	public const VkBlendOp VK_BLEND_OP_HSL_HUE_EXT = VkBlendOp.HslHueEXT;

	public const VkBlendOp VK_BLEND_OP_HSL_SATURATION_EXT = VkBlendOp.HslSaturationEXT;

	public const VkBlendOp VK_BLEND_OP_HSL_COLOR_EXT = VkBlendOp.HslColorEXT;

	public const VkBlendOp VK_BLEND_OP_HSL_LUMINOSITY_EXT = VkBlendOp.HslLuminosityEXT;

	public const VkBlendOp VK_BLEND_OP_PLUS_EXT = VkBlendOp.PlusEXT;

	public const VkBlendOp VK_BLEND_OP_PLUS_CLAMPED_EXT = VkBlendOp.PlusClampedEXT;

	public const VkBlendOp VK_BLEND_OP_PLUS_CLAMPED_ALPHA_EXT = VkBlendOp.PlusClampedAlphaEXT;

	public const VkBlendOp VK_BLEND_OP_PLUS_DARKER_EXT = VkBlendOp.PlusDarkerEXT;

	public const VkBlendOp VK_BLEND_OP_MINUS_EXT = VkBlendOp.MinusEXT;

	public const VkBlendOp VK_BLEND_OP_MINUS_CLAMPED_EXT = VkBlendOp.MinusClampedEXT;

	public const VkBlendOp VK_BLEND_OP_CONTRAST_EXT = VkBlendOp.ContrastEXT;

	public const VkBlendOp VK_BLEND_OP_INVERT_OVG_EXT = VkBlendOp.InvertOvgEXT;

	public const VkBlendOp VK_BLEND_OP_RED_EXT = VkBlendOp.RedEXT;

	public const VkBlendOp VK_BLEND_OP_GREEN_EXT = VkBlendOp.GreenEXT;

	public const VkBlendOp VK_BLEND_OP_BLUE_EXT = VkBlendOp.BlueEXT;

	public const VkStencilOp VK_STENCIL_OP_KEEP = VkStencilOp.Keep;

	public const VkStencilOp VK_STENCIL_OP_ZERO = VkStencilOp.Zero;

	public const VkStencilOp VK_STENCIL_OP_REPLACE = VkStencilOp.Replace;

	public const VkStencilOp VK_STENCIL_OP_INCREMENT_AND_CLAMP = VkStencilOp.IncrementAndClamp;

	public const VkStencilOp VK_STENCIL_OP_DECREMENT_AND_CLAMP = VkStencilOp.DecrementAndClamp;

	public const VkStencilOp VK_STENCIL_OP_INVERT = VkStencilOp.Invert;

	public const VkStencilOp VK_STENCIL_OP_INCREMENT_AND_WRAP = VkStencilOp.IncrementAndWrap;

	public const VkStencilOp VK_STENCIL_OP_DECREMENT_AND_WRAP = VkStencilOp.DecrementAndWrap;

	public const VkLogicOp VK_LOGIC_OP_CLEAR = VkLogicOp.Clear;

	public const VkLogicOp VK_LOGIC_OP_AND = VkLogicOp.And;

	public const VkLogicOp VK_LOGIC_OP_AND_REVERSE = VkLogicOp.AndReverse;

	public const VkLogicOp VK_LOGIC_OP_COPY = VkLogicOp.Copy;

	public const VkLogicOp VK_LOGIC_OP_AND_INVERTED = VkLogicOp.AndInverted;

	public const VkLogicOp VK_LOGIC_OP_NO_OP = VkLogicOp.NoOp;

	public const VkLogicOp VK_LOGIC_OP_XOR = VkLogicOp.Xor;

	public const VkLogicOp VK_LOGIC_OP_OR = VkLogicOp.Or;

	public const VkLogicOp VK_LOGIC_OP_NOR = VkLogicOp.Nor;

	public const VkLogicOp VK_LOGIC_OP_EQUIVALENT = VkLogicOp.Equivalent;

	public const VkLogicOp VK_LOGIC_OP_INVERT = VkLogicOp.Invert;

	public const VkLogicOp VK_LOGIC_OP_OR_REVERSE = VkLogicOp.OrReverse;

	public const VkLogicOp VK_LOGIC_OP_COPY_INVERTED = VkLogicOp.CopyInverted;

	public const VkLogicOp VK_LOGIC_OP_OR_INVERTED = VkLogicOp.OrInverted;

	public const VkLogicOp VK_LOGIC_OP_NAND = VkLogicOp.Nand;

	public const VkLogicOp VK_LOGIC_OP_SET = VkLogicOp.Set;

	public const VkInternalAllocationType VK_INTERNAL_ALLOCATION_TYPE_EXECUTABLE = VkInternalAllocationType.Executable;

	public const VkSystemAllocationScope VK_SYSTEM_ALLOCATION_SCOPE_COMMAND = VkSystemAllocationScope.Command;

	public const VkSystemAllocationScope VK_SYSTEM_ALLOCATION_SCOPE_OBJECT = VkSystemAllocationScope.Object;

	public const VkSystemAllocationScope VK_SYSTEM_ALLOCATION_SCOPE_CACHE = VkSystemAllocationScope.Cache;

	public const VkSystemAllocationScope VK_SYSTEM_ALLOCATION_SCOPE_DEVICE = VkSystemAllocationScope.Device;

	public const VkSystemAllocationScope VK_SYSTEM_ALLOCATION_SCOPE_INSTANCE = VkSystemAllocationScope.Instance;

	public const VkPhysicalDeviceType VK_PHYSICAL_DEVICE_TYPE_OTHER = VkPhysicalDeviceType.Other;

	public const VkPhysicalDeviceType VK_PHYSICAL_DEVICE_TYPE_INTEGRATED_GPU = VkPhysicalDeviceType.IntegratedGpu;

	public const VkPhysicalDeviceType VK_PHYSICAL_DEVICE_TYPE_DISCRETE_GPU = VkPhysicalDeviceType.DiscreteGpu;

	public const VkPhysicalDeviceType VK_PHYSICAL_DEVICE_TYPE_VIRTUAL_GPU = VkPhysicalDeviceType.VirtualGpu;

	public const VkPhysicalDeviceType VK_PHYSICAL_DEVICE_TYPE_CPU = VkPhysicalDeviceType.Cpu;

	public const VkVertexInputRate VK_VERTEX_INPUT_RATE_VERTEX = VkVertexInputRate.Vertex;

	public const VkVertexInputRate VK_VERTEX_INPUT_RATE_INSTANCE = VkVertexInputRate.Instance;

	public const VkFormat VK_FORMAT_UNDEFINED = VkFormat.Undefined;

	public const VkFormat VK_FORMAT_R4G4_UNORM_PACK8 = VkFormat.R4g4UnormPack8;

	public const VkFormat VK_FORMAT_R4G4B4A4_UNORM_PACK16 = VkFormat.R4g4b4a4UnormPack16;

	public const VkFormat VK_FORMAT_B4G4R4A4_UNORM_PACK16 = VkFormat.B4g4r4a4UnormPack16;

	public const VkFormat VK_FORMAT_R5G6B5_UNORM_PACK16 = VkFormat.R5g6b5UnormPack16;

	public const VkFormat VK_FORMAT_B5G6R5_UNORM_PACK16 = VkFormat.B5g6r5UnormPack16;

	public const VkFormat VK_FORMAT_R5G5B5A1_UNORM_PACK16 = VkFormat.R5g5b5a1UnormPack16;

	public const VkFormat VK_FORMAT_B5G5R5A1_UNORM_PACK16 = VkFormat.B5g5r5a1UnormPack16;

	public const VkFormat VK_FORMAT_A1R5G5B5_UNORM_PACK16 = VkFormat.A1r5g5b5UnormPack16;

	public const VkFormat VK_FORMAT_R8_UNORM = VkFormat.R8Unorm;

	public const VkFormat VK_FORMAT_R8_SNORM = VkFormat.R8Snorm;

	public const VkFormat VK_FORMAT_R8_USCALED = VkFormat.R8Uscaled;

	public const VkFormat VK_FORMAT_R8_SSCALED = VkFormat.R8Sscaled;

	public const VkFormat VK_FORMAT_R8_UINT = VkFormat.R8Uint;

	public const VkFormat VK_FORMAT_R8_SINT = VkFormat.R8Sint;

	public const VkFormat VK_FORMAT_R8_SRGB = VkFormat.R8Srgb;

	public const VkFormat VK_FORMAT_R8G8_UNORM = VkFormat.R8g8Unorm;

	public const VkFormat VK_FORMAT_R8G8_SNORM = VkFormat.R8g8Snorm;

	public const VkFormat VK_FORMAT_R8G8_USCALED = VkFormat.R8g8Uscaled;

	public const VkFormat VK_FORMAT_R8G8_SSCALED = VkFormat.R8g8Sscaled;

	public const VkFormat VK_FORMAT_R8G8_UINT = VkFormat.R8g8Uint;

	public const VkFormat VK_FORMAT_R8G8_SINT = VkFormat.R8g8Sint;

	public const VkFormat VK_FORMAT_R8G8_SRGB = VkFormat.R8g8Srgb;

	public const VkFormat VK_FORMAT_R8G8B8_UNORM = VkFormat.R8g8b8Unorm;

	public const VkFormat VK_FORMAT_R8G8B8_SNORM = VkFormat.R8g8b8Snorm;

	public const VkFormat VK_FORMAT_R8G8B8_USCALED = VkFormat.R8g8b8Uscaled;

	public const VkFormat VK_FORMAT_R8G8B8_SSCALED = VkFormat.R8g8b8Sscaled;

	public const VkFormat VK_FORMAT_R8G8B8_UINT = VkFormat.R8g8b8Uint;

	public const VkFormat VK_FORMAT_R8G8B8_SINT = VkFormat.R8g8b8Sint;

	public const VkFormat VK_FORMAT_R8G8B8_SRGB = VkFormat.R8g8b8Srgb;

	public const VkFormat VK_FORMAT_B8G8R8_UNORM = VkFormat.B8g8r8Unorm;

	public const VkFormat VK_FORMAT_B8G8R8_SNORM = VkFormat.B8g8r8Snorm;

	public const VkFormat VK_FORMAT_B8G8R8_USCALED = VkFormat.B8g8r8Uscaled;

	public const VkFormat VK_FORMAT_B8G8R8_SSCALED = VkFormat.B8g8r8Sscaled;

	public const VkFormat VK_FORMAT_B8G8R8_UINT = VkFormat.B8g8r8Uint;

	public const VkFormat VK_FORMAT_B8G8R8_SINT = VkFormat.B8g8r8Sint;

	public const VkFormat VK_FORMAT_B8G8R8_SRGB = VkFormat.B8g8r8Srgb;

	public const VkFormat VK_FORMAT_R8G8B8A8_UNORM = VkFormat.R8g8b8a8Unorm;

	public const VkFormat VK_FORMAT_R8G8B8A8_SNORM = VkFormat.R8g8b8a8Snorm;

	public const VkFormat VK_FORMAT_R8G8B8A8_USCALED = VkFormat.R8g8b8a8Uscaled;

	public const VkFormat VK_FORMAT_R8G8B8A8_SSCALED = VkFormat.R8g8b8a8Sscaled;

	public const VkFormat VK_FORMAT_R8G8B8A8_UINT = VkFormat.R8g8b8a8Uint;

	public const VkFormat VK_FORMAT_R8G8B8A8_SINT = VkFormat.R8g8b8a8Sint;

	public const VkFormat VK_FORMAT_R8G8B8A8_SRGB = VkFormat.R8g8b8a8Srgb;

	public const VkFormat VK_FORMAT_B8G8R8A8_UNORM = VkFormat.B8g8r8a8Unorm;

	public const VkFormat VK_FORMAT_B8G8R8A8_SNORM = VkFormat.B8g8r8a8Snorm;

	public const VkFormat VK_FORMAT_B8G8R8A8_USCALED = VkFormat.B8g8r8a8Uscaled;

	public const VkFormat VK_FORMAT_B8G8R8A8_SSCALED = VkFormat.B8g8r8a8Sscaled;

	public const VkFormat VK_FORMAT_B8G8R8A8_UINT = VkFormat.B8g8r8a8Uint;

	public const VkFormat VK_FORMAT_B8G8R8A8_SINT = VkFormat.B8g8r8a8Sint;

	public const VkFormat VK_FORMAT_B8G8R8A8_SRGB = VkFormat.B8g8r8a8Srgb;

	public const VkFormat VK_FORMAT_A8B8G8R8_UNORM_PACK32 = VkFormat.A8b8g8r8UnormPack32;

	public const VkFormat VK_FORMAT_A8B8G8R8_SNORM_PACK32 = VkFormat.A8b8g8r8SnormPack32;

	public const VkFormat VK_FORMAT_A8B8G8R8_USCALED_PACK32 = VkFormat.A8b8g8r8UscaledPack32;

	public const VkFormat VK_FORMAT_A8B8G8R8_SSCALED_PACK32 = VkFormat.A8b8g8r8SscaledPack32;

	public const VkFormat VK_FORMAT_A8B8G8R8_UINT_PACK32 = VkFormat.A8b8g8r8UintPack32;

	public const VkFormat VK_FORMAT_A8B8G8R8_SINT_PACK32 = VkFormat.A8b8g8r8SintPack32;

	public const VkFormat VK_FORMAT_A8B8G8R8_SRGB_PACK32 = VkFormat.A8b8g8r8SrgbPack32;

	public const VkFormat VK_FORMAT_A2R10G10B10_UNORM_PACK32 = VkFormat.A2r10g10b10UnormPack32;

	public const VkFormat VK_FORMAT_A2R10G10B10_SNORM_PACK32 = VkFormat.A2r10g10b10SnormPack32;

	public const VkFormat VK_FORMAT_A2R10G10B10_USCALED_PACK32 = VkFormat.A2r10g10b10UscaledPack32;

	public const VkFormat VK_FORMAT_A2R10G10B10_SSCALED_PACK32 = VkFormat.A2r10g10b10SscaledPack32;

	public const VkFormat VK_FORMAT_A2R10G10B10_UINT_PACK32 = VkFormat.A2r10g10b10UintPack32;

	public const VkFormat VK_FORMAT_A2R10G10B10_SINT_PACK32 = VkFormat.A2r10g10b10SintPack32;

	public const VkFormat VK_FORMAT_A2B10G10R10_UNORM_PACK32 = VkFormat.A2b10g10r10UnormPack32;

	public const VkFormat VK_FORMAT_A2B10G10R10_SNORM_PACK32 = VkFormat.A2b10g10r10SnormPack32;

	public const VkFormat VK_FORMAT_A2B10G10R10_USCALED_PACK32 = VkFormat.A2b10g10r10UscaledPack32;

	public const VkFormat VK_FORMAT_A2B10G10R10_SSCALED_PACK32 = VkFormat.A2b10g10r10SscaledPack32;

	public const VkFormat VK_FORMAT_A2B10G10R10_UINT_PACK32 = VkFormat.A2b10g10r10UintPack32;

	public const VkFormat VK_FORMAT_A2B10G10R10_SINT_PACK32 = VkFormat.A2b10g10r10SintPack32;

	public const VkFormat VK_FORMAT_R16_UNORM = VkFormat.R16Unorm;

	public const VkFormat VK_FORMAT_R16_SNORM = VkFormat.R16Snorm;

	public const VkFormat VK_FORMAT_R16_USCALED = VkFormat.R16Uscaled;

	public const VkFormat VK_FORMAT_R16_SSCALED = VkFormat.R16Sscaled;

	public const VkFormat VK_FORMAT_R16_UINT = VkFormat.R16Uint;

	public const VkFormat VK_FORMAT_R16_SINT = VkFormat.R16Sint;

	public const VkFormat VK_FORMAT_R16_SFLOAT = VkFormat.R16Sfloat;

	public const VkFormat VK_FORMAT_R16G16_UNORM = VkFormat.R16g16Unorm;

	public const VkFormat VK_FORMAT_R16G16_SNORM = VkFormat.R16g16Snorm;

	public const VkFormat VK_FORMAT_R16G16_USCALED = VkFormat.R16g16Uscaled;

	public const VkFormat VK_FORMAT_R16G16_SSCALED = VkFormat.R16g16Sscaled;

	public const VkFormat VK_FORMAT_R16G16_UINT = VkFormat.R16g16Uint;

	public const VkFormat VK_FORMAT_R16G16_SINT = VkFormat.R16g16Sint;

	public const VkFormat VK_FORMAT_R16G16_SFLOAT = VkFormat.R16g16Sfloat;

	public const VkFormat VK_FORMAT_R16G16B16_UNORM = VkFormat.R16g16b16Unorm;

	public const VkFormat VK_FORMAT_R16G16B16_SNORM = VkFormat.R16g16b16Snorm;

	public const VkFormat VK_FORMAT_R16G16B16_USCALED = VkFormat.R16g16b16Uscaled;

	public const VkFormat VK_FORMAT_R16G16B16_SSCALED = VkFormat.R16g16b16Sscaled;

	public const VkFormat VK_FORMAT_R16G16B16_UINT = VkFormat.R16g16b16Uint;

	public const VkFormat VK_FORMAT_R16G16B16_SINT = VkFormat.R16g16b16Sint;

	public const VkFormat VK_FORMAT_R16G16B16_SFLOAT = VkFormat.R16g16b16Sfloat;

	public const VkFormat VK_FORMAT_R16G16B16A16_UNORM = VkFormat.R16g16b16a16Unorm;

	public const VkFormat VK_FORMAT_R16G16B16A16_SNORM = VkFormat.R16g16b16a16Snorm;

	public const VkFormat VK_FORMAT_R16G16B16A16_USCALED = VkFormat.R16g16b16a16Uscaled;

	public const VkFormat VK_FORMAT_R16G16B16A16_SSCALED = VkFormat.R16g16b16a16Sscaled;

	public const VkFormat VK_FORMAT_R16G16B16A16_UINT = VkFormat.R16g16b16a16Uint;

	public const VkFormat VK_FORMAT_R16G16B16A16_SINT = VkFormat.R16g16b16a16Sint;

	public const VkFormat VK_FORMAT_R16G16B16A16_SFLOAT = VkFormat.R16g16b16a16Sfloat;

	public const VkFormat VK_FORMAT_R32_UINT = VkFormat.R32Uint;

	public const VkFormat VK_FORMAT_R32_SINT = VkFormat.R32Sint;

	public const VkFormat VK_FORMAT_R32_SFLOAT = VkFormat.R32Sfloat;

	public const VkFormat VK_FORMAT_R32G32_UINT = VkFormat.R32g32Uint;

	public const VkFormat VK_FORMAT_R32G32_SINT = VkFormat.R32g32Sint;

	public const VkFormat VK_FORMAT_R32G32_SFLOAT = VkFormat.R32g32Sfloat;

	public const VkFormat VK_FORMAT_R32G32B32_UINT = VkFormat.R32g32b32Uint;

	public const VkFormat VK_FORMAT_R32G32B32_SINT = VkFormat.R32g32b32Sint;

	public const VkFormat VK_FORMAT_R32G32B32_SFLOAT = VkFormat.R32g32b32Sfloat;

	public const VkFormat VK_FORMAT_R32G32B32A32_UINT = VkFormat.R32g32b32a32Uint;

	public const VkFormat VK_FORMAT_R32G32B32A32_SINT = VkFormat.R32g32b32a32Sint;

	public const VkFormat VK_FORMAT_R32G32B32A32_SFLOAT = VkFormat.R32g32b32a32Sfloat;

	public const VkFormat VK_FORMAT_R64_UINT = VkFormat.R64Uint;

	public const VkFormat VK_FORMAT_R64_SINT = VkFormat.R64Sint;

	public const VkFormat VK_FORMAT_R64_SFLOAT = VkFormat.R64Sfloat;

	public const VkFormat VK_FORMAT_R64G64_UINT = VkFormat.R64g64Uint;

	public const VkFormat VK_FORMAT_R64G64_SINT = VkFormat.R64g64Sint;

	public const VkFormat VK_FORMAT_R64G64_SFLOAT = VkFormat.R64g64Sfloat;

	public const VkFormat VK_FORMAT_R64G64B64_UINT = VkFormat.R64g64b64Uint;

	public const VkFormat VK_FORMAT_R64G64B64_SINT = VkFormat.R64g64b64Sint;

	public const VkFormat VK_FORMAT_R64G64B64_SFLOAT = VkFormat.R64g64b64Sfloat;

	public const VkFormat VK_FORMAT_R64G64B64A64_UINT = VkFormat.R64g64b64a64Uint;

	public const VkFormat VK_FORMAT_R64G64B64A64_SINT = VkFormat.R64g64b64a64Sint;

	public const VkFormat VK_FORMAT_R64G64B64A64_SFLOAT = VkFormat.R64g64b64a64Sfloat;

	public const VkFormat VK_FORMAT_B10G11R11_UFLOAT_PACK32 = VkFormat.B10g11r11UfloatPack32;

	public const VkFormat VK_FORMAT_E5B9G9R9_UFLOAT_PACK32 = VkFormat.E5b9g9r9UfloatPack32;

	public const VkFormat VK_FORMAT_D16_UNORM = VkFormat.D16Unorm;

	public const VkFormat VK_FORMAT_X8_D24_UNORM_PACK32 = VkFormat.X8D24UnormPack32;

	public const VkFormat VK_FORMAT_D32_SFLOAT = VkFormat.D32Sfloat;

	public const VkFormat VK_FORMAT_S8_UINT = VkFormat.S8Uint;

	public const VkFormat VK_FORMAT_D16_UNORM_S8_UINT = VkFormat.D16UnormS8Uint;

	public const VkFormat VK_FORMAT_D24_UNORM_S8_UINT = VkFormat.D24UnormS8Uint;

	public const VkFormat VK_FORMAT_D32_SFLOAT_S8_UINT = VkFormat.D32SfloatS8Uint;

	public const VkFormat VK_FORMAT_BC1_RGB_UNORM_BLOCK = VkFormat.Bc1RgbUnormBlock;

	public const VkFormat VK_FORMAT_BC1_RGB_SRGB_BLOCK = VkFormat.Bc1RgbSrgbBlock;

	public const VkFormat VK_FORMAT_BC1_RGBA_UNORM_BLOCK = VkFormat.Bc1RgbaUnormBlock;

	public const VkFormat VK_FORMAT_BC1_RGBA_SRGB_BLOCK = VkFormat.Bc1RgbaSrgbBlock;

	public const VkFormat VK_FORMAT_BC2_UNORM_BLOCK = VkFormat.Bc2UnormBlock;

	public const VkFormat VK_FORMAT_BC2_SRGB_BLOCK = VkFormat.Bc2SrgbBlock;

	public const VkFormat VK_FORMAT_BC3_UNORM_BLOCK = VkFormat.Bc3UnormBlock;

	public const VkFormat VK_FORMAT_BC3_SRGB_BLOCK = VkFormat.Bc3SrgbBlock;

	public const VkFormat VK_FORMAT_BC4_UNORM_BLOCK = VkFormat.Bc4UnormBlock;

	public const VkFormat VK_FORMAT_BC4_SNORM_BLOCK = VkFormat.Bc4SnormBlock;

	public const VkFormat VK_FORMAT_BC5_UNORM_BLOCK = VkFormat.Bc5UnormBlock;

	public const VkFormat VK_FORMAT_BC5_SNORM_BLOCK = VkFormat.Bc5SnormBlock;

	public const VkFormat VK_FORMAT_BC6H_UFLOAT_BLOCK = VkFormat.Bc6hUfloatBlock;

	public const VkFormat VK_FORMAT_BC6H_SFLOAT_BLOCK = VkFormat.Bc6hSfloatBlock;

	public const VkFormat VK_FORMAT_BC7_UNORM_BLOCK = VkFormat.Bc7UnormBlock;

	public const VkFormat VK_FORMAT_BC7_SRGB_BLOCK = VkFormat.Bc7SrgbBlock;

	public const VkFormat VK_FORMAT_ETC2_R8G8B8_UNORM_BLOCK = VkFormat.Etc2R8g8b8UnormBlock;

	public const VkFormat VK_FORMAT_ETC2_R8G8B8_SRGB_BLOCK = VkFormat.Etc2R8g8b8SrgbBlock;

	public const VkFormat VK_FORMAT_ETC2_R8G8B8A1_UNORM_BLOCK = VkFormat.Etc2R8g8b8a1UnormBlock;

	public const VkFormat VK_FORMAT_ETC2_R8G8B8A1_SRGB_BLOCK = VkFormat.Etc2R8g8b8a1SrgbBlock;

	public const VkFormat VK_FORMAT_ETC2_R8G8B8A8_UNORM_BLOCK = VkFormat.Etc2R8g8b8a8UnormBlock;

	public const VkFormat VK_FORMAT_ETC2_R8G8B8A8_SRGB_BLOCK = VkFormat.Etc2R8g8b8a8SrgbBlock;

	public const VkFormat VK_FORMAT_EAC_R11_UNORM_BLOCK = VkFormat.EacR11UnormBlock;

	public const VkFormat VK_FORMAT_EAC_R11_SNORM_BLOCK = VkFormat.EacR11SnormBlock;

	public const VkFormat VK_FORMAT_EAC_R11G11_UNORM_BLOCK = VkFormat.EacR11g11UnormBlock;

	public const VkFormat VK_FORMAT_EAC_R11G11_SNORM_BLOCK = VkFormat.EacR11g11SnormBlock;

	public const VkFormat VK_FORMAT_ASTC_4x4_UNORM_BLOCK = VkFormat.Astc4x4UnormBlock;

	public const VkFormat VK_FORMAT_ASTC_4x4_SRGB_BLOCK = VkFormat.Astc4x4SrgbBlock;

	public const VkFormat VK_FORMAT_ASTC_5x4_UNORM_BLOCK = VkFormat.Astc5x4UnormBlock;

	public const VkFormat VK_FORMAT_ASTC_5x4_SRGB_BLOCK = VkFormat.Astc5x4SrgbBlock;

	public const VkFormat VK_FORMAT_ASTC_5x5_UNORM_BLOCK = VkFormat.Astc5x5UnormBlock;

	public const VkFormat VK_FORMAT_ASTC_5x5_SRGB_BLOCK = VkFormat.Astc5x5SrgbBlock;

	public const VkFormat VK_FORMAT_ASTC_6x5_UNORM_BLOCK = VkFormat.Astc6x5UnormBlock;

	public const VkFormat VK_FORMAT_ASTC_6x5_SRGB_BLOCK = VkFormat.Astc6x5SrgbBlock;

	public const VkFormat VK_FORMAT_ASTC_6x6_UNORM_BLOCK = VkFormat.Astc6x6UnormBlock;

	public const VkFormat VK_FORMAT_ASTC_6x6_SRGB_BLOCK = VkFormat.Astc6x6SrgbBlock;

	public const VkFormat VK_FORMAT_ASTC_8x5_UNORM_BLOCK = VkFormat.Astc8x5UnormBlock;

	public const VkFormat VK_FORMAT_ASTC_8x5_SRGB_BLOCK = VkFormat.Astc8x5SrgbBlock;

	public const VkFormat VK_FORMAT_ASTC_8x6_UNORM_BLOCK = VkFormat.Astc8x6UnormBlock;

	public const VkFormat VK_FORMAT_ASTC_8x6_SRGB_BLOCK = VkFormat.Astc8x6SrgbBlock;

	public const VkFormat VK_FORMAT_ASTC_8x8_UNORM_BLOCK = VkFormat.Astc8x8UnormBlock;

	public const VkFormat VK_FORMAT_ASTC_8x8_SRGB_BLOCK = VkFormat.Astc8x8SrgbBlock;

	public const VkFormat VK_FORMAT_ASTC_10x5_UNORM_BLOCK = VkFormat.Astc10x5UnormBlock;

	public const VkFormat VK_FORMAT_ASTC_10x5_SRGB_BLOCK = VkFormat.Astc10x5SrgbBlock;

	public const VkFormat VK_FORMAT_ASTC_10x6_UNORM_BLOCK = VkFormat.Astc10x6UnormBlock;

	public const VkFormat VK_FORMAT_ASTC_10x6_SRGB_BLOCK = VkFormat.Astc10x6SrgbBlock;

	public const VkFormat VK_FORMAT_ASTC_10x8_UNORM_BLOCK = VkFormat.Astc10x8UnormBlock;

	public const VkFormat VK_FORMAT_ASTC_10x8_SRGB_BLOCK = VkFormat.Astc10x8SrgbBlock;

	public const VkFormat VK_FORMAT_ASTC_10x10_UNORM_BLOCK = VkFormat.Astc10x10UnormBlock;

	public const VkFormat VK_FORMAT_ASTC_10x10_SRGB_BLOCK = VkFormat.Astc10x10SrgbBlock;

	public const VkFormat VK_FORMAT_ASTC_12x10_UNORM_BLOCK = VkFormat.Astc12x10UnormBlock;

	public const VkFormat VK_FORMAT_ASTC_12x10_SRGB_BLOCK = VkFormat.Astc12x10SrgbBlock;

	public const VkFormat VK_FORMAT_ASTC_12x12_UNORM_BLOCK = VkFormat.Astc12x12UnormBlock;

	public const VkFormat VK_FORMAT_ASTC_12x12_SRGB_BLOCK = VkFormat.Astc12x12SrgbBlock;

	public const VkFormat VK_FORMAT_PVRTC1_2BPP_UNORM_BLOCK_IMG = VkFormat.Pvrtc12bppUnormBlockImg;

	public const VkFormat VK_FORMAT_PVRTC1_4BPP_UNORM_BLOCK_IMG = VkFormat.Pvrtc14bppUnormBlockImg;

	public const VkFormat VK_FORMAT_PVRTC2_2BPP_UNORM_BLOCK_IMG = VkFormat.Pvrtc22bppUnormBlockImg;

	public const VkFormat VK_FORMAT_PVRTC2_4BPP_UNORM_BLOCK_IMG = VkFormat.Pvrtc24bppUnormBlockImg;

	public const VkFormat VK_FORMAT_PVRTC1_2BPP_SRGB_BLOCK_IMG = VkFormat.Pvrtc12bppSrgbBlockImg;

	public const VkFormat VK_FORMAT_PVRTC1_4BPP_SRGB_BLOCK_IMG = VkFormat.Pvrtc14bppSrgbBlockImg;

	public const VkFormat VK_FORMAT_PVRTC2_2BPP_SRGB_BLOCK_IMG = VkFormat.Pvrtc22bppSrgbBlockImg;

	public const VkFormat VK_FORMAT_PVRTC2_4BPP_SRGB_BLOCK_IMG = VkFormat.Pvrtc24bppSrgbBlockImg;

	public const VkFormat VK_FORMAT_G8B8G8R8_422_UNORM_KHR = VkFormat.G8b8g8r8422UnormKHR;

	public const VkFormat VK_FORMAT_B8G8R8G8_422_UNORM_KHR = VkFormat.B8g8r8g8422UnormKHR;

	public const VkFormat VK_FORMAT_G8_B8_R8_3PLANE_420_UNORM_KHR = VkFormat.G8B8R83plane420UnormKHR;

	public const VkFormat VK_FORMAT_G8_B8R8_2PLANE_420_UNORM_KHR = VkFormat.G8B8r82plane420UnormKHR;

	public const VkFormat VK_FORMAT_G8_B8_R8_3PLANE_422_UNORM_KHR = VkFormat.G8B8R83plane422UnormKHR;

	public const VkFormat VK_FORMAT_G8_B8R8_2PLANE_422_UNORM_KHR = VkFormat.G8B8r82plane422UnormKHR;

	public const VkFormat VK_FORMAT_G8_B8_R8_3PLANE_444_UNORM_KHR = VkFormat.G8B8R83plane444UnormKHR;

	public const VkFormat VK_FORMAT_R10X6_UNORM_PACK16_KHR = VkFormat.R10x6UnormPack16KHR;

	public const VkFormat VK_FORMAT_R10X6G10X6_UNORM_2PACK16_KHR = VkFormat.R10x6g10x6Unorm2pack16KHR;

	public const VkFormat VK_FORMAT_R10X6G10X6B10X6A10X6_UNORM_4PACK16_KHR = VkFormat.R10x6g10x6b10x6a10x6Unorm4pack16KHR;

	public const VkFormat VK_FORMAT_G10X6B10X6G10X6R10X6_422_UNORM_4PACK16_KHR = VkFormat.G10x6b10x6g10x6r10x6422Unorm4pack16KHR;

	public const VkFormat VK_FORMAT_B10X6G10X6R10X6G10X6_422_UNORM_4PACK16_KHR = VkFormat.B10x6g10x6r10x6g10x6422Unorm4pack16KHR;

	public const VkFormat VK_FORMAT_G10X6_B10X6_R10X6_3PLANE_420_UNORM_3PACK16_KHR = VkFormat.G10x6B10x6R10x63plane420Unorm3pack16KHR;

	public const VkFormat VK_FORMAT_G10X6_B10X6R10X6_2PLANE_420_UNORM_3PACK16_KHR = VkFormat.G10x6B10x6r10x62plane420Unorm3pack16KHR;

	public const VkFormat VK_FORMAT_G10X6_B10X6_R10X6_3PLANE_422_UNORM_3PACK16_KHR = VkFormat.G10x6B10x6R10x63plane422Unorm3pack16KHR;

	public const VkFormat VK_FORMAT_G10X6_B10X6R10X6_2PLANE_422_UNORM_3PACK16_KHR = VkFormat.G10x6B10x6r10x62plane422Unorm3pack16KHR;

	public const VkFormat VK_FORMAT_G10X6_B10X6_R10X6_3PLANE_444_UNORM_3PACK16_KHR = VkFormat.G10x6B10x6R10x63plane444Unorm3pack16KHR;

	public const VkFormat VK_FORMAT_R12X4_UNORM_PACK16_KHR = VkFormat.R12x4UnormPack16KHR;

	public const VkFormat VK_FORMAT_R12X4G12X4_UNORM_2PACK16_KHR = VkFormat.R12x4g12x4Unorm2pack16KHR;

	public const VkFormat VK_FORMAT_R12X4G12X4B12X4A12X4_UNORM_4PACK16_KHR = VkFormat.R12x4g12x4b12x4a12x4Unorm4pack16KHR;

	public const VkFormat VK_FORMAT_G12X4B12X4G12X4R12X4_422_UNORM_4PACK16_KHR = VkFormat.G12x4b12x4g12x4r12x4422Unorm4pack16KHR;

	public const VkFormat VK_FORMAT_B12X4G12X4R12X4G12X4_422_UNORM_4PACK16_KHR = VkFormat.B12x4g12x4r12x4g12x4422Unorm4pack16KHR;

	public const VkFormat VK_FORMAT_G12X4_B12X4_R12X4_3PLANE_420_UNORM_3PACK16_KHR = VkFormat.G12x4B12x4R12x43plane420Unorm3pack16KHR;

	public const VkFormat VK_FORMAT_G12X4_B12X4R12X4_2PLANE_420_UNORM_3PACK16_KHR = VkFormat.G12x4B12x4r12x42plane420Unorm3pack16KHR;

	public const VkFormat VK_FORMAT_G12X4_B12X4_R12X4_3PLANE_422_UNORM_3PACK16_KHR = VkFormat.G12x4B12x4R12x43plane422Unorm3pack16KHR;

	public const VkFormat VK_FORMAT_G12X4_B12X4R12X4_2PLANE_422_UNORM_3PACK16_KHR = VkFormat.G12x4B12x4r12x42plane422Unorm3pack16KHR;

	public const VkFormat VK_FORMAT_G12X4_B12X4_R12X4_3PLANE_444_UNORM_3PACK16_KHR = VkFormat.G12x4B12x4R12x43plane444Unorm3pack16KHR;

	public const VkFormat VK_FORMAT_G16B16G16R16_422_UNORM_KHR = VkFormat.G16b16g16r16422UnormKHR;

	public const VkFormat VK_FORMAT_B16G16R16G16_422_UNORM_KHR = VkFormat.B16g16r16g16422UnormKHR;

	public const VkFormat VK_FORMAT_G16_B16_R16_3PLANE_420_UNORM_KHR = VkFormat.G16B16R163plane420UnormKHR;

	public const VkFormat VK_FORMAT_G16_B16R16_2PLANE_420_UNORM_KHR = VkFormat.G16B16r162plane420UnormKHR;

	public const VkFormat VK_FORMAT_G16_B16_R16_3PLANE_422_UNORM_KHR = VkFormat.G16B16R163plane422UnormKHR;

	public const VkFormat VK_FORMAT_G16_B16R16_2PLANE_422_UNORM_KHR = VkFormat.G16B16r162plane422UnormKHR;

	public const VkFormat VK_FORMAT_G16_B16_R16_3PLANE_444_UNORM_KHR = VkFormat.G16B16R163plane444UnormKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_APPLICATION_INFO = VkStructureType.ApplicationInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_INSTANCE_CREATE_INFO = VkStructureType.InstanceCreateInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_DEVICE_QUEUE_CREATE_INFO = VkStructureType.DeviceQueueCreateInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_DEVICE_CREATE_INFO = VkStructureType.DeviceCreateInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_SUBMIT_INFO = VkStructureType.SubmitInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_MEMORY_ALLOCATE_INFO = VkStructureType.MemoryAllocateInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_MAPPED_MEMORY_RANGE = VkStructureType.MappedMemoryRange;

	public const VkStructureType VK_STRUCTURE_TYPE_BIND_SPARSE_INFO = VkStructureType.BindSparseInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_FENCE_CREATE_INFO = VkStructureType.FenceCreateInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_SEMAPHORE_CREATE_INFO = VkStructureType.SemaphoreCreateInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_EVENT_CREATE_INFO = VkStructureType.EventCreateInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_QUERY_POOL_CREATE_INFO = VkStructureType.QueryPoolCreateInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_BUFFER_CREATE_INFO = VkStructureType.BufferCreateInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_BUFFER_VIEW_CREATE_INFO = VkStructureType.BufferViewCreateInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_IMAGE_CREATE_INFO = VkStructureType.ImageCreateInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_IMAGE_VIEW_CREATE_INFO = VkStructureType.ImageViewCreateInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_SHADER_MODULE_CREATE_INFO = VkStructureType.ShaderModuleCreateInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_PIPELINE_CACHE_CREATE_INFO = VkStructureType.PipelineCacheCreateInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_PIPELINE_SHADER_STAGE_CREATE_INFO = VkStructureType.PipelineShaderStageCreateInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_PIPELINE_VERTEX_INPUT_STATE_CREATE_INFO = VkStructureType.PipelineVertexInputStateCreateInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_PIPELINE_INPUT_ASSEMBLY_STATE_CREATE_INFO = VkStructureType.PipelineInputAssemblyStateCreateInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_PIPELINE_TESSELLATION_STATE_CREATE_INFO = VkStructureType.PipelineTessellationStateCreateInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_PIPELINE_VIEWPORT_STATE_CREATE_INFO = VkStructureType.PipelineViewportStateCreateInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_PIPELINE_RASTERIZATION_STATE_CREATE_INFO = VkStructureType.PipelineRasterizationStateCreateInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_PIPELINE_MULTISAMPLE_STATE_CREATE_INFO = VkStructureType.PipelineMultisampleStateCreateInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_PIPELINE_DEPTH_STENCIL_STATE_CREATE_INFO = VkStructureType.PipelineDepthStencilStateCreateInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_PIPELINE_COLOR_BLEND_STATE_CREATE_INFO = VkStructureType.PipelineColorBlendStateCreateInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_PIPELINE_DYNAMIC_STATE_CREATE_INFO = VkStructureType.PipelineDynamicStateCreateInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_GRAPHICS_PIPELINE_CREATE_INFO = VkStructureType.GraphicsPipelineCreateInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_COMPUTE_PIPELINE_CREATE_INFO = VkStructureType.ComputePipelineCreateInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_PIPELINE_LAYOUT_CREATE_INFO = VkStructureType.PipelineLayoutCreateInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_SAMPLER_CREATE_INFO = VkStructureType.SamplerCreateInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_DESCRIPTOR_SET_LAYOUT_CREATE_INFO = VkStructureType.DescriptorSetLayoutCreateInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_DESCRIPTOR_POOL_CREATE_INFO = VkStructureType.DescriptorPoolCreateInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_DESCRIPTOR_SET_ALLOCATE_INFO = VkStructureType.DescriptorSetAllocateInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_WRITE_DESCRIPTOR_SET = VkStructureType.WriteDescriptorSet;

	public const VkStructureType VK_STRUCTURE_TYPE_COPY_DESCRIPTOR_SET = VkStructureType.CopyDescriptorSet;

	public const VkStructureType VK_STRUCTURE_TYPE_FRAMEBUFFER_CREATE_INFO = VkStructureType.FramebufferCreateInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_RENDER_PASS_CREATE_INFO = VkStructureType.RenderPassCreateInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_COMMAND_POOL_CREATE_INFO = VkStructureType.CommandPoolCreateInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_COMMAND_BUFFER_ALLOCATE_INFO = VkStructureType.CommandBufferAllocateInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_COMMAND_BUFFER_INHERITANCE_INFO = VkStructureType.CommandBufferInheritanceInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_COMMAND_BUFFER_BEGIN_INFO = VkStructureType.CommandBufferBeginInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_RENDER_PASS_BEGIN_INFO = VkStructureType.RenderPassBeginInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_BUFFER_MEMORY_BARRIER = VkStructureType.BufferMemoryBarrier;

	public const VkStructureType VK_STRUCTURE_TYPE_IMAGE_MEMORY_BARRIER = VkStructureType.ImageMemoryBarrier;

	public const VkStructureType VK_STRUCTURE_TYPE_MEMORY_BARRIER = VkStructureType.MemoryBarrier;

	public const VkStructureType VK_STRUCTURE_TYPE_LOADER_INSTANCE_CREATE_INFO = VkStructureType.LoaderInstanceCreateInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_LOADER_DEVICE_CREATE_INFO = VkStructureType.LoaderDeviceCreateInfo;

	public const VkStructureType VK_STRUCTURE_TYPE_SWAPCHAIN_CREATE_INFO_KHR = VkStructureType.SwapchainCreateInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_PRESENT_INFO_KHR = VkStructureType.PresentInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_DISPLAY_MODE_CREATE_INFO_KHR = VkStructureType.DisplayModeCreateInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_DISPLAY_SURFACE_CREATE_INFO_KHR = VkStructureType.DisplaySurfaceCreateInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_DISPLAY_PRESENT_INFO_KHR = VkStructureType.DisplayPresentInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_XLIB_SURFACE_CREATE_INFO_KHR = VkStructureType.XlibSurfaceCreateInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_XCB_SURFACE_CREATE_INFO_KHR = VkStructureType.XcbSurfaceCreateInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_WAYLAND_SURFACE_CREATE_INFO_KHR = VkStructureType.WaylandSurfaceCreateInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_MIR_SURFACE_CREATE_INFO_KHR = VkStructureType.MirSurfaceCreateInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_ANDROID_SURFACE_CREATE_INFO_KHR = VkStructureType.AndroidSurfaceCreateInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_WIN32_SURFACE_CREATE_INFO_KHR = VkStructureType.Win32SurfaceCreateInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_NATIVE_BUFFER_ANDROID = VkStructureType.NativeBufferAndroid;

	public const VkStructureType VK_STRUCTURE_TYPE_DEBUG_REPORT_CALLBACK_CREATE_INFO_EXT = VkStructureType.DebugReportCallbackCreateInfoEXT;

	public const VkStructureType VK_STRUCTURE_TYPE_PIPELINE_RASTERIZATION_STATE_RASTERIZATION_ORDER_AMD = VkStructureType.PipelineRasterizationStateRasterizationOrderAMD;

	public const VkStructureType VK_STRUCTURE_TYPE_DEBUG_MARKER_OBJECT_NAME_INFO_EXT = VkStructureType.DebugMarkerObjectNameInfoEXT;

	public const VkStructureType VK_STRUCTURE_TYPE_DEBUG_MARKER_OBJECT_TAG_INFO_EXT = VkStructureType.DebugMarkerObjectTagInfoEXT;

	public const VkStructureType VK_STRUCTURE_TYPE_DEBUG_MARKER_MARKER_INFO_EXT = VkStructureType.DebugMarkerMarkerInfoEXT;

	public const VkStructureType VK_STRUCTURE_TYPE_DEDICATED_ALLOCATION_IMAGE_CREATE_INFO_NV = VkStructureType.DedicatedAllocationImageCreateInfoNV;

	public const VkStructureType VK_STRUCTURE_TYPE_DEDICATED_ALLOCATION_BUFFER_CREATE_INFO_NV = VkStructureType.DedicatedAllocationBufferCreateInfoNV;

	public const VkStructureType VK_STRUCTURE_TYPE_DEDICATED_ALLOCATION_MEMORY_ALLOCATE_INFO_NV = VkStructureType.DedicatedAllocationMemoryAllocateInfoNV;

	public const VkStructureType VK_STRUCTURE_TYPE_TEXTURE_LOD_GATHER_FORMAT_PROPERTIES_AMD = VkStructureType.TextureLodGatherFormatPropertiesAMD;

	public const VkStructureType VK_STRUCTURE_TYPE_RENDER_PASS_MULTIVIEW_CREATE_INFO_KHX = VkStructureType.RenderPassMultiviewCreateInfoKHX;

	public const VkStructureType VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MULTIVIEW_FEATURES_KHX = VkStructureType.PhysicalDeviceMultiviewFeaturesKHX;

	public const VkStructureType VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MULTIVIEW_PROPERTIES_KHX = VkStructureType.PhysicalDeviceMultiviewPropertiesKHX;

	public const VkStructureType VK_STRUCTURE_TYPE_EXTERNAL_MEMORY_IMAGE_CREATE_INFO_NV = VkStructureType.ExternalMemoryImageCreateInfoNV;

	public const VkStructureType VK_STRUCTURE_TYPE_EXPORT_MEMORY_ALLOCATE_INFO_NV = VkStructureType.ExportMemoryAllocateInfoNV;

	public const VkStructureType VK_STRUCTURE_TYPE_IMPORT_MEMORY_WIN32_HANDLE_INFO_NV = VkStructureType.ImportMemoryWin32HandleInfoNV;

	public const VkStructureType VK_STRUCTURE_TYPE_EXPORT_MEMORY_WIN32_HANDLE_INFO_NV = VkStructureType.ExportMemoryWin32HandleInfoNV;

	public const VkStructureType VK_STRUCTURE_TYPE_WIN32_KEYED_MUTEX_ACQUIRE_RELEASE_INFO_NV = VkStructureType.Win32KeyedMutexAcquireReleaseInfoNV;

	public const VkStructureType VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FEATURES_2_KHR = VkStructureType.PhysicalDeviceFeatures2KHR;

	public const VkStructureType VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PROPERTIES_2_KHR = VkStructureType.PhysicalDeviceProperties2KHR;

	public const VkStructureType VK_STRUCTURE_TYPE_FORMAT_PROPERTIES_2_KHR = VkStructureType.FormatProperties2KHR;

	public const VkStructureType VK_STRUCTURE_TYPE_IMAGE_FORMAT_PROPERTIES_2_KHR = VkStructureType.ImageFormatProperties2KHR;

	public const VkStructureType VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_IMAGE_FORMAT_INFO_2_KHR = VkStructureType.PhysicalDeviceImageFormatInfo2KHR;

	public const VkStructureType VK_STRUCTURE_TYPE_QUEUE_FAMILY_PROPERTIES_2_KHR = VkStructureType.QueueFamilyProperties2KHR;

	public const VkStructureType VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MEMORY_PROPERTIES_2_KHR = VkStructureType.PhysicalDeviceMemoryProperties2KHR;

	public const VkStructureType VK_STRUCTURE_TYPE_SPARSE_IMAGE_FORMAT_PROPERTIES_2_KHR = VkStructureType.SparseImageFormatProperties2KHR;

	public const VkStructureType VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SPARSE_IMAGE_FORMAT_INFO_2_KHR = VkStructureType.PhysicalDeviceSparseImageFormatInfo2KHR;

	public const VkStructureType VK_STRUCTURE_TYPE_MEMORY_ALLOCATE_FLAGS_INFO_KHX = VkStructureType.MemoryAllocateInfoKHX;

	public const VkStructureType VK_STRUCTURE_TYPE_DEVICE_GROUP_RENDER_PASS_BEGIN_INFO_KHX = VkStructureType.DeviceGroupRenderPassBeginInfoKHX;

	public const VkStructureType VK_STRUCTURE_TYPE_DEVICE_GROUP_COMMAND_BUFFER_BEGIN_INFO_KHX = VkStructureType.DeviceGroupCommandBufferBeginInfoKHX;

	public const VkStructureType VK_STRUCTURE_TYPE_DEVICE_GROUP_SUBMIT_INFO_KHX = VkStructureType.DeviceGroupSubmitInfoKHX;

	public const VkStructureType VK_STRUCTURE_TYPE_DEVICE_GROUP_BIND_SPARSE_INFO_KHX = VkStructureType.DeviceGroupBindSparseInfoKHX;

	public const VkStructureType VK_STRUCTURE_TYPE_ACQUIRE_NEXT_IMAGE_INFO_KHX = VkStructureType.AcquireNextImageInfoKHX;

	public const VkStructureType VK_STRUCTURE_TYPE_BIND_BUFFER_MEMORY_DEVICE_GROUP_INFO_KHX = VkStructureType.BindBufferMemoryDeviceGroupInfoKHX;

	public const VkStructureType VK_STRUCTURE_TYPE_BIND_IMAGE_MEMORY_DEVICE_GROUP_INFO_KHX = VkStructureType.BindImageMemoryDeviceGroupInfoKHX;

	public const VkStructureType VK_STRUCTURE_TYPE_DEVICE_GROUP_PRESENT_CAPABILITIES_KHX = VkStructureType.DeviceGroupPresentCapabilitiesKHX;

	public const VkStructureType VK_STRUCTURE_TYPE_IMAGE_SWAPCHAIN_CREATE_INFO_KHX = VkStructureType.ImageSwapchainCreateInfoKHX;

	public const VkStructureType VK_STRUCTURE_TYPE_BIND_IMAGE_MEMORY_SWAPCHAIN_INFO_KHX = VkStructureType.BindImageMemorySwapchainInfoKHX;

	public const VkStructureType VK_STRUCTURE_TYPE_DEVICE_GROUP_PRESENT_INFO_KHX = VkStructureType.DeviceGroupPresentInfoKHX;

	public const VkStructureType VK_STRUCTURE_TYPE_DEVICE_GROUP_SWAPCHAIN_CREATE_INFO_KHX = VkStructureType.DeviceGroupSwapchainCreateInfoKHX;

	public const VkStructureType VK_STRUCTURE_TYPE_VALIDATION_FLAGS_EXT = VkStructureType.ValidationEXT;

	public const VkStructureType VK_STRUCTURE_TYPE_VI_SURFACE_CREATE_INFO_NN = VkStructureType.ViSurfaceCreateInfoNn;

	public const VkStructureType VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_GROUP_PROPERTIES_KHX = VkStructureType.PhysicalDeviceGroupPropertiesKHX;

	public const VkStructureType VK_STRUCTURE_TYPE_DEVICE_GROUP_DEVICE_CREATE_INFO_KHX = VkStructureType.DeviceGroupDeviceCreateInfoKHX;

	public const VkStructureType VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_IMAGE_FORMAT_INFO_KHR = VkStructureType.PhysicalDeviceExternalImageFormatInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_EXTERNAL_IMAGE_FORMAT_PROPERTIES_KHR = VkStructureType.ExternalImageFormatPropertiesKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_BUFFER_INFO_KHR = VkStructureType.PhysicalDeviceExternalBufferInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_EXTERNAL_BUFFER_PROPERTIES_KHR = VkStructureType.ExternalBufferPropertiesKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_ID_PROPERTIES_KHR = VkStructureType.PhysicalDeviceIdPropertiesKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_EXTERNAL_MEMORY_BUFFER_CREATE_INFO_KHR = VkStructureType.ExternalMemoryBufferCreateInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_EXTERNAL_MEMORY_IMAGE_CREATE_INFO_KHR = VkStructureType.ExternalMemoryImageCreateInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_EXPORT_MEMORY_ALLOCATE_INFO_KHR = VkStructureType.ExportMemoryAllocateInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_IMPORT_MEMORY_WIN32_HANDLE_INFO_KHR = VkStructureType.ImportMemoryWin32HandleInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_EXPORT_MEMORY_WIN32_HANDLE_INFO_KHR = VkStructureType.ExportMemoryWin32HandleInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_MEMORY_WIN32_HANDLE_PROPERTIES_KHR = VkStructureType.MemoryWin32HandlePropertiesKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_MEMORY_GET_WIN32_HANDLE_INFO_KHR = VkStructureType.MemoryGetWin32HandleInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_IMPORT_MEMORY_FD_INFO_KHR = VkStructureType.ImportMemoryFdInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_MEMORY_FD_PROPERTIES_KHR = VkStructureType.MemoryFdPropertiesKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_MEMORY_GET_FD_INFO_KHR = VkStructureType.MemoryGetFdInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_WIN32_KEYED_MUTEX_ACQUIRE_RELEASE_INFO_KHR = VkStructureType.Win32KeyedMutexAcquireReleaseInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_SEMAPHORE_INFO_KHR = VkStructureType.PhysicalDeviceExternalSemaphoreInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_EXTERNAL_SEMAPHORE_PROPERTIES_KHR = VkStructureType.ExternalSemaphorePropertiesKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_EXPORT_SEMAPHORE_CREATE_INFO_KHR = VkStructureType.ExportSemaphoreCreateInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_IMPORT_SEMAPHORE_WIN32_HANDLE_INFO_KHR = VkStructureType.ImportSemaphoreWin32HandleInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_EXPORT_SEMAPHORE_WIN32_HANDLE_INFO_KHR = VkStructureType.ExportSemaphoreWin32HandleInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_D3D12_FENCE_SUBMIT_INFO_KHR = VkStructureType.D3d12FenceSubmitInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_SEMAPHORE_GET_WIN32_HANDLE_INFO_KHR = VkStructureType.SemaphoreGetWin32HandleInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_IMPORT_SEMAPHORE_FD_INFO_KHR = VkStructureType.ImportSemaphoreFdInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_SEMAPHORE_GET_FD_INFO_KHR = VkStructureType.SemaphoreGetFdInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PUSH_DESCRIPTOR_PROPERTIES_KHR = VkStructureType.PhysicalDevicePushDescriptorPropertiesKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_16BIT_STORAGE_FEATURES_KHR = VkStructureType.PhysicalDevice16bitStorageFeaturesKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_PRESENT_REGIONS_KHR = VkStructureType.PresentRegionsKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_DESCRIPTOR_UPDATE_TEMPLATE_CREATE_INFO_KHR = VkStructureType.DescriptorUpdateTemplateCreateInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_OBJECT_TABLE_CREATE_INFO_NVX = VkStructureType.ObjectTableCreateInfoNVX;

	public const VkStructureType VK_STRUCTURE_TYPE_INDIRECT_COMMANDS_LAYOUT_CREATE_INFO_NVX = VkStructureType.IndirectCommandsLayoutCreateInfoNVX;

	public const VkStructureType VK_STRUCTURE_TYPE_CMD_PROCESS_COMMANDS_INFO_NVX = VkStructureType.CmdProcessCommandsInfoNVX;

	public const VkStructureType VK_STRUCTURE_TYPE_CMD_RESERVE_SPACE_FOR_COMMANDS_INFO_NVX = VkStructureType.CmdReserveSpaceForCommandsInfoNVX;

	public const VkStructureType VK_STRUCTURE_TYPE_DEVICE_GENERATED_COMMANDS_LIMITS_NVX = VkStructureType.DeviceGeneratedCommandsLimitsNVX;

	public const VkStructureType VK_STRUCTURE_TYPE_DEVICE_GENERATED_COMMANDS_FEATURES_NVX = VkStructureType.DeviceGeneratedCommandsFeaturesNVX;

	public const VkStructureType VK_STRUCTURE_TYPE_PIPELINE_VIEWPORT_W_SCALING_STATE_CREATE_INFO_NV = VkStructureType.PipelineViewportWScalingStateCreateInfoNV;

	public const VkStructureType VK_STRUCTURE_TYPE_SURFACE_CAPABILITIES_2_EXT = VkStructureType.SurfaceCapabilities2EXT;

	public const VkStructureType VK_STRUCTURE_TYPE_DISPLAY_POWER_INFO_EXT = VkStructureType.DisplayPowerInfoEXT;

	public const VkStructureType VK_STRUCTURE_TYPE_DEVICE_EVENT_INFO_EXT = VkStructureType.DeviceEventInfoEXT;

	public const VkStructureType VK_STRUCTURE_TYPE_DISPLAY_EVENT_INFO_EXT = VkStructureType.DisplayEventInfoEXT;

	public const VkStructureType VK_STRUCTURE_TYPE_SWAPCHAIN_COUNTER_CREATE_INFO_EXT = VkStructureType.SwapchainCounterCreateInfoEXT;

	public const VkStructureType VK_STRUCTURE_TYPE_PRESENT_TIMES_INFO_GOOGLE = VkStructureType.PresentTimesInfoGoogle;

	public const VkStructureType VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MULTIVIEW_PER_VIEW_ATTRIBUTES_PROPERTIES_NVX = VkStructureType.PhysicalDeviceMultiviewPerViewAttributesPropertiesNVX;

	public const VkStructureType VK_STRUCTURE_TYPE_PIPELINE_VIEWPORT_SWIZZLE_STATE_CREATE_INFO_NV = VkStructureType.PipelineViewportSwizzleStateCreateInfoNV;

	public const VkStructureType VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DISCARD_RECTANGLE_PROPERTIES_EXT = VkStructureType.PhysicalDeviceDiscardRectanglePropertiesEXT;

	public const VkStructureType VK_STRUCTURE_TYPE_PIPELINE_DISCARD_RECTANGLE_STATE_CREATE_INFO_EXT = VkStructureType.PipelineDiscardRectangleStateCreateInfoEXT;

	public const VkStructureType VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_CONSERVATIVE_RASTERIZATION_PROPERTIES_EXT = VkStructureType.PhysicalDeviceConservativeRasterizationPropertiesEXT;

	public const VkStructureType VK_STRUCTURE_TYPE_PIPELINE_RASTERIZATION_CONSERVATIVE_STATE_CREATE_INFO_EXT = VkStructureType.PipelineRasterizationConservativeStateCreateInfoEXT;

	public const VkStructureType VK_STRUCTURE_TYPE_HDR_METADATA_EXT = VkStructureType.HdrMetadataEXT;

	public const VkStructureType VK_STRUCTURE_TYPE_SHARED_PRESENT_SURFACE_CAPABILITIES_KHR = VkStructureType.SharedPresentSurfaceCapabilitiesKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_FENCE_INFO_KHR = VkStructureType.PhysicalDeviceExternalFenceInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_EXTERNAL_FENCE_PROPERTIES_KHR = VkStructureType.ExternalFencePropertiesKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_EXPORT_FENCE_CREATE_INFO_KHR = VkStructureType.ExportFenceCreateInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_IMPORT_FENCE_WIN32_HANDLE_INFO_KHR = VkStructureType.ImportFenceWin32HandleInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_EXPORT_FENCE_WIN32_HANDLE_INFO_KHR = VkStructureType.ExportFenceWin32HandleInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_FENCE_GET_WIN32_HANDLE_INFO_KHR = VkStructureType.FenceGetWin32HandleInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_IMPORT_FENCE_FD_INFO_KHR = VkStructureType.ImportFenceFdInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_FENCE_GET_FD_INFO_KHR = VkStructureType.FenceGetFdInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_POINT_CLIPPING_PROPERTIES_KHR = VkStructureType.PhysicalDevicePointClippingPropertiesKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_RENDER_PASS_INPUT_ATTACHMENT_ASPECT_CREATE_INFO_KHR = VkStructureType.RenderPassInputAttachmentAspectCreateInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_IMAGE_VIEW_USAGE_CREATE_INFO_KHR = VkStructureType.ImageViewUsageCreateInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_PIPELINE_TESSELLATION_DOMAIN_ORIGIN_STATE_CREATE_INFO_KHR = VkStructureType.PipelineTessellationDomainOriginStateCreateInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SURFACE_INFO_2_KHR = VkStructureType.PhysicalDeviceSurfaceInfo2KHR;

	public const VkStructureType VK_STRUCTURE_TYPE_SURFACE_CAPABILITIES_2_KHR = VkStructureType.SurfaceCapabilities2KHR;

	public const VkStructureType VK_STRUCTURE_TYPE_SURFACE_FORMAT_2_KHR = VkStructureType.SurfaceFormat2KHR;

	public const VkStructureType VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VARIABLE_POINTER_FEATURES_KHR = VkStructureType.PhysicalDeviceVariablePointerFeaturesKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_IOS_SURFACE_CREATE_INFO_MVK = VkStructureType.IosSurfaceCreateInfoMvk;

	public const VkStructureType VK_STRUCTURE_TYPE_MACOS_SURFACE_CREATE_INFO_MVK = VkStructureType.MacosSurfaceCreateInfoMvk;

	public const VkStructureType VK_STRUCTURE_TYPE_MEMORY_DEDICATED_REQUIREMENTS_KHR = VkStructureType.MemoryDedicatedRequirementsKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_MEMORY_DEDICATED_ALLOCATE_INFO_KHR = VkStructureType.MemoryDedicatedAllocateInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SAMPLER_FILTER_MINMAX_PROPERTIES_EXT = VkStructureType.PhysicalDeviceSamplerFilterMinmaxPropertiesEXT;

	public const VkStructureType VK_STRUCTURE_TYPE_SAMPLER_REDUCTION_MODE_CREATE_INFO_EXT = VkStructureType.SamplerReductionModeCreateInfoEXT;

	public const VkStructureType VK_STRUCTURE_TYPE_SAMPLE_LOCATIONS_INFO_EXT = VkStructureType.SampleLocationsInfoEXT;

	public const VkStructureType VK_STRUCTURE_TYPE_RENDER_PASS_SAMPLE_LOCATIONS_BEGIN_INFO_EXT = VkStructureType.RenderPassSampleLocationsBeginInfoEXT;

	public const VkStructureType VK_STRUCTURE_TYPE_PIPELINE_SAMPLE_LOCATIONS_STATE_CREATE_INFO_EXT = VkStructureType.PipelineSampleLocationsStateCreateInfoEXT;

	public const VkStructureType VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SAMPLE_LOCATIONS_PROPERTIES_EXT = VkStructureType.PhysicalDeviceSampleLocationsPropertiesEXT;

	public const VkStructureType VK_STRUCTURE_TYPE_MULTISAMPLE_PROPERTIES_EXT = VkStructureType.MultisamplePropertiesEXT;

	public const VkStructureType VK_STRUCTURE_TYPE_BUFFER_MEMORY_REQUIREMENTS_INFO_2_KHR = VkStructureType.BufferMemoryRequirementsInfo2KHR;

	public const VkStructureType VK_STRUCTURE_TYPE_IMAGE_MEMORY_REQUIREMENTS_INFO_2_KHR = VkStructureType.ImageMemoryRequirementsInfo2KHR;

	public const VkStructureType VK_STRUCTURE_TYPE_IMAGE_SPARSE_MEMORY_REQUIREMENTS_INFO_2_KHR = VkStructureType.ImageSparseMemoryRequirementsInfo2KHR;

	public const VkStructureType VK_STRUCTURE_TYPE_MEMORY_REQUIREMENTS_2_KHR = VkStructureType.MemoryRequirements2KHR;

	public const VkStructureType VK_STRUCTURE_TYPE_SPARSE_IMAGE_MEMORY_REQUIREMENTS_2_KHR = VkStructureType.SparseImageMemoryRequirements2KHR;

	public const VkStructureType VK_STRUCTURE_TYPE_IMAGE_FORMAT_LIST_CREATE_INFO_KHR = VkStructureType.ImageFormatListCreateInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_BLEND_OPERATION_ADVANCED_FEATURES_EXT = VkStructureType.PhysicalDeviceBlendOperationAdvancedFeaturesEXT;

	public const VkStructureType VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_BLEND_OPERATION_ADVANCED_PROPERTIES_EXT = VkStructureType.PhysicalDeviceBlendOperationAdvancedPropertiesEXT;

	public const VkStructureType VK_STRUCTURE_TYPE_PIPELINE_COLOR_BLEND_ADVANCED_STATE_CREATE_INFO_EXT = VkStructureType.PipelineColorBlendAdvancedStateCreateInfoEXT;

	public const VkStructureType VK_STRUCTURE_TYPE_PIPELINE_COVERAGE_TO_COLOR_STATE_CREATE_INFO_NV = VkStructureType.PipelineCoverageToColorStateCreateInfoNV;

	public const VkStructureType VK_STRUCTURE_TYPE_PIPELINE_COVERAGE_MODULATION_STATE_CREATE_INFO_NV = VkStructureType.PipelineCoverageModulationStateCreateInfoNV;

	public const VkStructureType VK_STRUCTURE_TYPE_SAMPLER_YCBCR_CONVERSION_CREATE_INFO_KHR = VkStructureType.SamplerYcbcrConversionCreateInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_SAMPLER_YCBCR_CONVERSION_INFO_KHR = VkStructureType.SamplerYcbcrConversionInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_BIND_IMAGE_PLANE_MEMORY_INFO_KHR = VkStructureType.BindImagePlaneMemoryInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_IMAGE_PLANE_MEMORY_REQUIREMENTS_INFO_KHR = VkStructureType.ImagePlaneMemoryRequirementsInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SAMPLER_YCBCR_CONVERSION_FEATURES_KHR = VkStructureType.PhysicalDeviceSamplerYcbcrConversionFeaturesKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_SAMPLER_YCBCR_CONVERSION_IMAGE_FORMAT_PROPERTIES_KHR = VkStructureType.SamplerYcbcrConversionImageFormatPropertiesKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_BIND_BUFFER_MEMORY_INFO_KHR = VkStructureType.BindBufferMemoryInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_BIND_IMAGE_MEMORY_INFO_KHR = VkStructureType.BindImageMemoryInfoKHR;

	public const VkStructureType VK_STRUCTURE_TYPE_VALIDATION_CACHE_CREATE_INFO_EXT = VkStructureType.ValidationCacheCreateInfoEXT;

	public const VkStructureType VK_STRUCTURE_TYPE_SHADER_MODULE_VALIDATION_CACHE_CREATE_INFO_EXT = VkStructureType.ShaderModuleValidationCacheCreateInfoEXT;

	public const VkStructureType VK_STRUCTURE_TYPE_DEVICE_QUEUE_GLOBAL_PRIORITY_CREATE_INFO_EXT = VkStructureType.DeviceQueueGlobalPriorityCreateInfoEXT;

	public const VkStructureType VK_STRUCTURE_TYPE_IMPORT_MEMORY_HOST_POINTER_INFO_EXT = VkStructureType.ImportMemoryHostPointerInfoEXT;

	public const VkStructureType VK_STRUCTURE_TYPE_MEMORY_HOST_POINTER_PROPERTIES_EXT = VkStructureType.MemoryHostPointerPropertiesEXT;

	public const VkStructureType VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_MEMORY_HOST_PROPERTIES_EXT = VkStructureType.PhysicalDeviceExternalMemoryHostPropertiesEXT;

	public const VkSubpassContents VK_SUBPASS_CONTENTS_INLINE = VkSubpassContents.Inline;

	public const VkSubpassContents VK_SUBPASS_CONTENTS_SECONDARY_COMMAND_BUFFERS = VkSubpassContents.SecondaryCommandBuffers;

	public const VkResult VK_SUCCESS = VkResult.Success;

	public const VkResult VK_NOT_READY = VkResult.NotReady;

	public const VkResult VK_TIMEOUT = VkResult.Timeout;

	public const VkResult VK_EVENT_SET = VkResult.EventSet;

	public const VkResult VK_EVENT_RESET = VkResult.EventReset;

	public const VkResult VK_INCOMPLETE = VkResult.Incomplete;

	public const VkResult VK_ERROR_OUT_OF_HOST_MEMORY = VkResult.ErrorOutOfHostMemory;

	public const VkResult VK_ERROR_OUT_OF_DEVICE_MEMORY = VkResult.ErrorOutOfDeviceMemory;

	public const VkResult VK_ERROR_INITIALIZATION_FAILED = VkResult.ErrorInitializationFailed;

	public const VkResult VK_ERROR_DEVICE_LOST = VkResult.ErrorDeviceLost;

	public const VkResult VK_ERROR_MEMORY_MAP_FAILED = VkResult.ErrorMemoryMapFailed;

	public const VkResult VK_ERROR_LAYER_NOT_PRESENT = VkResult.ErrorLayerNotPresent;

	public const VkResult VK_ERROR_EXTENSION_NOT_PRESENT = VkResult.ErrorExtensionNotPresent;

	public const VkResult VK_ERROR_FEATURE_NOT_PRESENT = VkResult.ErrorFeatureNotPresent;

	public const VkResult VK_ERROR_INCOMPATIBLE_DRIVER = VkResult.ErrorIncompatibleDriver;

	public const VkResult VK_ERROR_TOO_MANY_OBJECTS = VkResult.ErrorTooManyObjects;

	public const VkResult VK_ERROR_FORMAT_NOT_SUPPORTED = VkResult.ErrorFormatNotSupported;

	public const VkResult VK_ERROR_FRAGMENTED_POOL = VkResult.ErrorFragmentedPool;

	public const VkResult VK_ERROR_SURFACE_LOST_KHR = VkResult.ErrorSurfaceLostKHR;

	public const VkResult VK_ERROR_NATIVE_WINDOW_IN_USE_KHR = VkResult.ErrorNativeWindowInUseKHR;

	public const VkResult VK_SUBOPTIMAL_KHR = VkResult.SuboptimalKHR;

	public const VkResult VK_ERROR_OUT_OF_DATE_KHR = VkResult.ErrorOutOfDateKHR;

	public const VkResult VK_ERROR_INCOMPATIBLE_DISPLAY_KHR = VkResult.ErrorIncompatibleDisplayKHR;

	public const VkResult VK_ERROR_VALIDATION_FAILED_EXT = VkResult.ErrorValidationFailedEXT;

	public const VkResult VK_ERROR_INVALID_SHADER_NV = VkResult.ErrorInvalidShaderNV;

	public const VkResult VK_ERROR_OUT_OF_POOL_MEMORY_KHR = VkResult.ErrorOutOfPoolMemoryKHR;

	public const VkResult VK_ERROR_INVALID_EXTERNAL_HANDLE_KHR = VkResult.ErrorInvalidExternalHandleKHR;

	public const VkResult VK_ERROR_NOT_PERMITTED_EXT = VkResult.ErrorNotPermittedEXT;

	public const VkDynamicState VK_DYNAMIC_STATE_VIEWPORT = VkDynamicState.Viewport;

	public const VkDynamicState VK_DYNAMIC_STATE_SCISSOR = VkDynamicState.Scissor;

	public const VkDynamicState VK_DYNAMIC_STATE_LINE_WIDTH = VkDynamicState.LineWidth;

	public const VkDynamicState VK_DYNAMIC_STATE_DEPTH_BIAS = VkDynamicState.DepthBias;

	public const VkDynamicState VK_DYNAMIC_STATE_BLEND_CONSTANTS = VkDynamicState.BlendConstants;

	public const VkDynamicState VK_DYNAMIC_STATE_DEPTH_BOUNDS = VkDynamicState.DepthBounds;

	public const VkDynamicState VK_DYNAMIC_STATE_STENCIL_COMPARE_MASK = VkDynamicState.StencilCompareMask;

	public const VkDynamicState VK_DYNAMIC_STATE_STENCIL_WRITE_MASK = VkDynamicState.StencilWriteMask;

	public const VkDynamicState VK_DYNAMIC_STATE_STENCIL_REFERENCE = VkDynamicState.StencilReference;

	public const VkDynamicState VK_DYNAMIC_STATE_VIEWPORT_W_SCALING_NV = VkDynamicState.ViewportWScalingNV;

	public const VkDynamicState VK_DYNAMIC_STATE_DISCARD_RECTANGLE_EXT = VkDynamicState.DiscardRectangleEXT;

	public const VkDynamicState VK_DYNAMIC_STATE_SAMPLE_LOCATIONS_EXT = VkDynamicState.SampleLocationsEXT;

	public const VkDescriptorUpdateTemplateTypeKHR VK_DESCRIPTOR_UPDATE_TEMPLATE_TYPE_DESCRIPTOR_SET_KHR = VkDescriptorUpdateTemplateTypeKHR.DescriptorSetKHR;

	public const VkDescriptorUpdateTemplateTypeKHR VK_DESCRIPTOR_UPDATE_TEMPLATE_TYPE_PUSH_DESCRIPTORS_KHR = VkDescriptorUpdateTemplateTypeKHR.PushDescriptorsKHR;

	public const VkObjectType VK_OBJECT_TYPE_UNKNOWN = VkObjectType.Unknown;

	public const VkObjectType VK_OBJECT_TYPE_INSTANCE = VkObjectType.Instance;

	public const VkObjectType VK_OBJECT_TYPE_PHYSICAL_DEVICE = VkObjectType.PhysicalDevice;

	public const VkObjectType VK_OBJECT_TYPE_DEVICE = VkObjectType.Device;

	public const VkObjectType VK_OBJECT_TYPE_QUEUE = VkObjectType.Queue;

	public const VkObjectType VK_OBJECT_TYPE_SEMAPHORE = VkObjectType.Semaphore;

	public const VkObjectType VK_OBJECT_TYPE_COMMAND_BUFFER = VkObjectType.CommandBuffer;

	public const VkObjectType VK_OBJECT_TYPE_FENCE = VkObjectType.Fence;

	public const VkObjectType VK_OBJECT_TYPE_DEVICE_MEMORY = VkObjectType.DeviceMemory;

	public const VkObjectType VK_OBJECT_TYPE_BUFFER = VkObjectType.Buffer;

	public const VkObjectType VK_OBJECT_TYPE_IMAGE = VkObjectType.Image;

	public const VkObjectType VK_OBJECT_TYPE_EVENT = VkObjectType.Event;

	public const VkObjectType VK_OBJECT_TYPE_QUERY_POOL = VkObjectType.QueryPool;

	public const VkObjectType VK_OBJECT_TYPE_BUFFER_VIEW = VkObjectType.BufferView;

	public const VkObjectType VK_OBJECT_TYPE_IMAGE_VIEW = VkObjectType.ImageView;

	public const VkObjectType VK_OBJECT_TYPE_SHADER_MODULE = VkObjectType.ShaderModule;

	public const VkObjectType VK_OBJECT_TYPE_PIPELINE_CACHE = VkObjectType.PipelineCache;

	public const VkObjectType VK_OBJECT_TYPE_PIPELINE_LAYOUT = VkObjectType.PipelineLayout;

	public const VkObjectType VK_OBJECT_TYPE_RENDER_PASS = VkObjectType.RenderPass;

	public const VkObjectType VK_OBJECT_TYPE_PIPELINE = VkObjectType.Pipeline;

	public const VkObjectType VK_OBJECT_TYPE_DESCRIPTOR_SET_LAYOUT = VkObjectType.DescriptorSetLayout;

	public const VkObjectType VK_OBJECT_TYPE_SAMPLER = VkObjectType.Sampler;

	public const VkObjectType VK_OBJECT_TYPE_DESCRIPTOR_POOL = VkObjectType.DescriptorPool;

	public const VkObjectType VK_OBJECT_TYPE_DESCRIPTOR_SET = VkObjectType.DescriptorSet;

	public const VkObjectType VK_OBJECT_TYPE_FRAMEBUFFER = VkObjectType.Framebuffer;

	public const VkObjectType VK_OBJECT_TYPE_COMMAND_POOL = VkObjectType.CommandPool;

	public const VkObjectType VK_OBJECT_TYPE_SURFACE_KHR = VkObjectType.SurfaceKHR;

	public const VkObjectType VK_OBJECT_TYPE_SWAPCHAIN_KHR = VkObjectType.SwapchainKHR;

	public const VkObjectType VK_OBJECT_TYPE_DISPLAY_KHR = VkObjectType.DisplayKHR;

	public const VkObjectType VK_OBJECT_TYPE_DISPLAY_MODE_KHR = VkObjectType.DisplayModeKHR;

	public const VkObjectType VK_OBJECT_TYPE_DEBUG_REPORT_CALLBACK_EXT = VkObjectType.DebugReportCallbackEXT;

	public const VkObjectType VK_OBJECT_TYPE_DESCRIPTOR_UPDATE_TEMPLATE_KHR = VkObjectType.DescriptorUpdateTemplateKHR;

	public const VkObjectType VK_OBJECT_TYPE_OBJECT_TABLE_NVX = VkObjectType.ObjectTableNVX;

	public const VkObjectType VK_OBJECT_TYPE_INDIRECT_COMMANDS_LAYOUT_NVX = VkObjectType.IndirectCommandsLayoutNVX;

	public const VkObjectType VK_OBJECT_TYPE_SAMPLER_YCBCR_CONVERSION_KHR = VkObjectType.SamplerYcbcrConversionKHR;

	public const VkObjectType VK_OBJECT_TYPE_VALIDATION_CACHE_EXT = VkObjectType.ValidationCacheEXT;

	public const VkQueueFlags VK_QUEUE_GRAPHICS_BIT = VkQueueFlags.Graphics;

	public const VkQueueFlags VK_QUEUE_COMPUTE_BIT = VkQueueFlags.Compute;

	public const VkQueueFlags VK_QUEUE_TRANSFER_BIT = VkQueueFlags.Transfer;

	public const VkQueueFlags VK_QUEUE_SPARSE_BINDING_BIT = VkQueueFlags.SparseBinding;

	public const VkMemoryPropertyFlags VK_MEMORY_PROPERTY_DEVICE_LOCAL_BIT = VkMemoryPropertyFlags.DeviceLocal;

	public const VkMemoryPropertyFlags VK_MEMORY_PROPERTY_HOST_VISIBLE_BIT = VkMemoryPropertyFlags.HostVisible;

	public const VkMemoryPropertyFlags VK_MEMORY_PROPERTY_HOST_COHERENT_BIT = VkMemoryPropertyFlags.HostCoherent;

	public const VkMemoryPropertyFlags VK_MEMORY_PROPERTY_HOST_CACHED_BIT = VkMemoryPropertyFlags.HostCached;

	public const VkMemoryPropertyFlags VK_MEMORY_PROPERTY_LAZILY_ALLOCATED_BIT = VkMemoryPropertyFlags.LazilyAllocated;

	public const VkMemoryHeapFlags VK_MEMORY_HEAP_DEVICE_LOCAL_BIT = VkMemoryHeapFlags.DeviceLocal;

	public const VkMemoryHeapFlags VK_MEMORY_HEAP_MULTI_INSTANCE_BIT_KHX = VkMemoryHeapFlags.MultiInstanceKHX;

	public const VkAccessFlags VK_ACCESS_INDIRECT_COMMAND_READ_BIT = VkAccessFlags.IndirectCommandRead;

	public const VkAccessFlags VK_ACCESS_INDEX_READ_BIT = VkAccessFlags.IndexRead;

	public const VkAccessFlags VK_ACCESS_VERTEX_ATTRIBUTE_READ_BIT = VkAccessFlags.VertexAttributeRead;

	public const VkAccessFlags VK_ACCESS_UNIFORM_READ_BIT = VkAccessFlags.UniformRead;

	public const VkAccessFlags VK_ACCESS_INPUT_ATTACHMENT_READ_BIT = VkAccessFlags.InputAttachmentRead;

	public const VkAccessFlags VK_ACCESS_SHADER_READ_BIT = VkAccessFlags.ShaderRead;

	public const VkAccessFlags VK_ACCESS_SHADER_WRITE_BIT = VkAccessFlags.ShaderWrite;

	public const VkAccessFlags VK_ACCESS_COLOR_ATTACHMENT_READ_BIT = VkAccessFlags.ColorAttachmentRead;

	public const VkAccessFlags VK_ACCESS_COLOR_ATTACHMENT_WRITE_BIT = VkAccessFlags.ColorAttachmentWrite;

	public const VkAccessFlags VK_ACCESS_DEPTH_STENCIL_ATTACHMENT_READ_BIT = VkAccessFlags.DepthStencilAttachmentRead;

	public const VkAccessFlags VK_ACCESS_DEPTH_STENCIL_ATTACHMENT_WRITE_BIT = VkAccessFlags.DepthStencilAttachmentWrite;

	public const VkAccessFlags VK_ACCESS_TRANSFER_READ_BIT = VkAccessFlags.TransferRead;

	public const VkAccessFlags VK_ACCESS_TRANSFER_WRITE_BIT = VkAccessFlags.TransferWrite;

	public const VkAccessFlags VK_ACCESS_HOST_READ_BIT = VkAccessFlags.HostRead;

	public const VkAccessFlags VK_ACCESS_HOST_WRITE_BIT = VkAccessFlags.HostWrite;

	public const VkAccessFlags VK_ACCESS_MEMORY_READ_BIT = VkAccessFlags.MemoryRead;

	public const VkAccessFlags VK_ACCESS_MEMORY_WRITE_BIT = VkAccessFlags.MemoryWrite;

	public const VkAccessFlags VK_ACCESS_COMMAND_PROCESS_READ_BIT_NVX = VkAccessFlags.CommandProcessReadNVX;

	public const VkAccessFlags VK_ACCESS_COMMAND_PROCESS_WRITE_BIT_NVX = VkAccessFlags.CommandProcessWriteNVX;

	public const VkAccessFlags VK_ACCESS_COLOR_ATTACHMENT_READ_NONCOHERENT_BIT_EXT = VkAccessFlags.ColorAttachmentReadNoncoherentEXT;

	public const VkBufferUsageFlags VK_BUFFER_USAGE_TRANSFER_SRC_BIT = VkBufferUsageFlags.TransferSrc;

	public const VkBufferUsageFlags VK_BUFFER_USAGE_TRANSFER_DST_BIT = VkBufferUsageFlags.TransferDst;

	public const VkBufferUsageFlags VK_BUFFER_USAGE_UNIFORM_TEXEL_BUFFER_BIT = VkBufferUsageFlags.UniformTexelBuffer;

	public const VkBufferUsageFlags VK_BUFFER_USAGE_STORAGE_TEXEL_BUFFER_BIT = VkBufferUsageFlags.StorageTexelBuffer;

	public const VkBufferUsageFlags VK_BUFFER_USAGE_UNIFORM_BUFFER_BIT = VkBufferUsageFlags.UniformBuffer;

	public const VkBufferUsageFlags VK_BUFFER_USAGE_STORAGE_BUFFER_BIT = VkBufferUsageFlags.StorageBuffer;

	public const VkBufferUsageFlags VK_BUFFER_USAGE_INDEX_BUFFER_BIT = VkBufferUsageFlags.IndexBuffer;

	public const VkBufferUsageFlags VK_BUFFER_USAGE_VERTEX_BUFFER_BIT = VkBufferUsageFlags.VertexBuffer;

	public const VkBufferUsageFlags VK_BUFFER_USAGE_INDIRECT_BUFFER_BIT = VkBufferUsageFlags.IndirectBuffer;

	public const VkBufferCreateFlags VK_BUFFER_CREATE_SPARSE_BINDING_BIT = VkBufferCreateFlags.SparseBinding;

	public const VkBufferCreateFlags VK_BUFFER_CREATE_SPARSE_RESIDENCY_BIT = VkBufferCreateFlags.SparseResidency;

	public const VkBufferCreateFlags VK_BUFFER_CREATE_SPARSE_ALIASED_BIT = VkBufferCreateFlags.SparseAliased;

	public const VkShaderStageFlags VK_SHADER_STAGE_VERTEX_BIT = VkShaderStageFlags.Vertex;

	public const VkShaderStageFlags VK_SHADER_STAGE_TESSELLATION_CONTROL_BIT = VkShaderStageFlags.TessellationControl;

	public const VkShaderStageFlags VK_SHADER_STAGE_TESSELLATION_EVALUATION_BIT = VkShaderStageFlags.TessellationEvaluation;

	public const VkShaderStageFlags VK_SHADER_STAGE_GEOMETRY_BIT = VkShaderStageFlags.Geometry;

	public const VkShaderStageFlags VK_SHADER_STAGE_FRAGMENT_BIT = VkShaderStageFlags.Fragment;

	public const VkShaderStageFlags VK_SHADER_STAGE_COMPUTE_BIT = VkShaderStageFlags.Compute;

	public const VkShaderStageFlags VK_SHADER_STAGE_ALL_GRAPHICS = VkShaderStageFlags.AllGraphics;

	public const VkShaderStageFlags VK_SHADER_STAGE_ALL = VkShaderStageFlags.All;

	public const VkImageUsageFlags VK_IMAGE_USAGE_TRANSFER_SRC_BIT = VkImageUsageFlags.TransferSrc;

	public const VkImageUsageFlags VK_IMAGE_USAGE_TRANSFER_DST_BIT = VkImageUsageFlags.TransferDst;

	public const VkImageUsageFlags VK_IMAGE_USAGE_SAMPLED_BIT = VkImageUsageFlags.Sampled;

	public const VkImageUsageFlags VK_IMAGE_USAGE_STORAGE_BIT = VkImageUsageFlags.Storage;

	public const VkImageUsageFlags VK_IMAGE_USAGE_COLOR_ATTACHMENT_BIT = VkImageUsageFlags.ColorAttachment;

	public const VkImageUsageFlags VK_IMAGE_USAGE_DEPTH_STENCIL_ATTACHMENT_BIT = VkImageUsageFlags.DepthStencilAttachment;

	public const VkImageUsageFlags VK_IMAGE_USAGE_TRANSIENT_ATTACHMENT_BIT = VkImageUsageFlags.TransientAttachment;

	public const VkImageUsageFlags VK_IMAGE_USAGE_INPUT_ATTACHMENT_BIT = VkImageUsageFlags.InputAttachment;

	public const VkImageCreateFlags VK_IMAGE_CREATE_SPARSE_BINDING_BIT = VkImageCreateFlags.SparseBinding;

	public const VkImageCreateFlags VK_IMAGE_CREATE_SPARSE_RESIDENCY_BIT = VkImageCreateFlags.SparseResidency;

	public const VkImageCreateFlags VK_IMAGE_CREATE_SPARSE_ALIASED_BIT = VkImageCreateFlags.SparseAliased;

	public const VkImageCreateFlags VK_IMAGE_CREATE_MUTABLE_FORMAT_BIT = VkImageCreateFlags.MutableFormat;

	public const VkImageCreateFlags VK_IMAGE_CREATE_CUBE_COMPATIBLE_BIT = VkImageCreateFlags.CubeCompatible;

	public const VkImageCreateFlags VK_IMAGE_CREATE_BIND_SFR_BIT_KHX = VkImageCreateFlags.BindSfrKHX;

	public const VkImageCreateFlags VK_IMAGE_CREATE_2D_ARRAY_COMPATIBLE_BIT_KHR = VkImageCreateFlags._2dArrayCompatibleKHR;

	public const VkImageCreateFlags VK_IMAGE_CREATE_BLOCK_TEXEL_VIEW_COMPATIBLE_BIT_KHR = VkImageCreateFlags.BlockTexelViewCompatibleKHR;

	public const VkImageCreateFlags VK_IMAGE_CREATE_EXTENDED_USAGE_BIT_KHR = VkImageCreateFlags.ExtendedUsageKHR;

	public const VkImageCreateFlags VK_IMAGE_CREATE_SAMPLE_LOCATIONS_COMPATIBLE_DEPTH_BIT_EXT = VkImageCreateFlags.SampleLocationsCompatibleDepthEXT;

	public const VkImageCreateFlags VK_IMAGE_CREATE_DISJOINT_BIT_KHR = VkImageCreateFlags.DisjointKHR;

	public const VkImageCreateFlags VK_IMAGE_CREATE_ALIAS_BIT_KHR = VkImageCreateFlags.AliasKHR;

	public const VkPipelineCreateFlags VK_PIPELINE_CREATE_DISABLE_OPTIMIZATION_BIT = VkPipelineCreateFlags.DisableOptimization;

	public const VkPipelineCreateFlags VK_PIPELINE_CREATE_ALLOW_DERIVATIVES_BIT = VkPipelineCreateFlags.AllowDerivatives;

	public const VkPipelineCreateFlags VK_PIPELINE_CREATE_DERIVATIVE_BIT = VkPipelineCreateFlags.Derivative;

	public const VkPipelineCreateFlags VK_PIPELINE_CREATE_VIEW_INDEX_FROM_DEVICE_INDEX_BIT_KHX = VkPipelineCreateFlags.ViewIndexFromDeviceIndexKHX;

	public const VkPipelineCreateFlags VK_PIPELINE_CREATE_DISPATCH_BASE_KHX = VkPipelineCreateFlags.DispatchBaseKHX;

	public const VkColorComponentFlags VK_COLOR_COMPONENT_R_BIT = VkColorComponentFlags.R;

	public const VkColorComponentFlags VK_COLOR_COMPONENT_G_BIT = VkColorComponentFlags.G;

	public const VkColorComponentFlags VK_COLOR_COMPONENT_B_BIT = VkColorComponentFlags.B;

	public const VkColorComponentFlags VK_COLOR_COMPONENT_A_BIT = VkColorComponentFlags.A;

	public const VkFenceCreateFlags VK_FENCE_CREATE_SIGNALED_BIT = VkFenceCreateFlags.Signaled;

	public const VkFormatFeatureFlags VK_FORMAT_FEATURE_SAMPLED_IMAGE_BIT = VkFormatFeatureFlags.SampledImage;

	public const VkFormatFeatureFlags VK_FORMAT_FEATURE_STORAGE_IMAGE_BIT = VkFormatFeatureFlags.StorageImage;

	public const VkFormatFeatureFlags VK_FORMAT_FEATURE_STORAGE_IMAGE_ATOMIC_BIT = VkFormatFeatureFlags.StorageImageAtomic;

	public const VkFormatFeatureFlags VK_FORMAT_FEATURE_UNIFORM_TEXEL_BUFFER_BIT = VkFormatFeatureFlags.UniformTexelBuffer;

	public const VkFormatFeatureFlags VK_FORMAT_FEATURE_STORAGE_TEXEL_BUFFER_BIT = VkFormatFeatureFlags.StorageTexelBuffer;

	public const VkFormatFeatureFlags VK_FORMAT_FEATURE_STORAGE_TEXEL_BUFFER_ATOMIC_BIT = VkFormatFeatureFlags.StorageTexelBufferAtomic;

	public const VkFormatFeatureFlags VK_FORMAT_FEATURE_VERTEX_BUFFER_BIT = VkFormatFeatureFlags.VertexBuffer;

	public const VkFormatFeatureFlags VK_FORMAT_FEATURE_COLOR_ATTACHMENT_BIT = VkFormatFeatureFlags.ColorAttachment;

	public const VkFormatFeatureFlags VK_FORMAT_FEATURE_COLOR_ATTACHMENT_BLEND_BIT = VkFormatFeatureFlags.ColorAttachmentBlend;

	public const VkFormatFeatureFlags VK_FORMAT_FEATURE_DEPTH_STENCIL_ATTACHMENT_BIT = VkFormatFeatureFlags.DepthStencilAttachment;

	public const VkFormatFeatureFlags VK_FORMAT_FEATURE_BLIT_SRC_BIT = VkFormatFeatureFlags.BlitSrc;

	public const VkFormatFeatureFlags VK_FORMAT_FEATURE_BLIT_DST_BIT = VkFormatFeatureFlags.BlitDst;

	public const VkFormatFeatureFlags VK_FORMAT_FEATURE_SAMPLED_IMAGE_FILTER_LINEAR_BIT = VkFormatFeatureFlags.SampledImageFilterLinear;

	public const VkFormatFeatureFlags VK_FORMAT_FEATURE_SAMPLED_IMAGE_FILTER_CUBIC_BIT_IMG = VkFormatFeatureFlags.SampledImageFilterCubicImg;

	public const VkFormatFeatureFlags VK_FORMAT_FEATURE_TRANSFER_SRC_BIT_KHR = VkFormatFeatureFlags.TransferSrcKHR;

	public const VkFormatFeatureFlags VK_FORMAT_FEATURE_TRANSFER_DST_BIT_KHR = VkFormatFeatureFlags.TransferDstKHR;

	public const VkFormatFeatureFlags VK_FORMAT_FEATURE_SAMPLED_IMAGE_FILTER_MINMAX_BIT_EXT = VkFormatFeatureFlags.SampledImageFilterMinmaxEXT;

	public const VkFormatFeatureFlags VK_FORMAT_FEATURE_MIDPOINT_CHROMA_SAMPLES_BIT_KHR = VkFormatFeatureFlags.MidpointChromaSamplesKHR;

	public const VkFormatFeatureFlags VK_FORMAT_FEATURE_SAMPLED_IMAGE_YCBCR_CONVERSION_LINEAR_FILTER_BIT_KHR = VkFormatFeatureFlags.SampledImageYcbcrConversionLinearFilterKHR;

	public const VkFormatFeatureFlags VK_FORMAT_FEATURE_SAMPLED_IMAGE_YCBCR_CONVERSION_SEPARATE_RECONSTRUCTION_FILTER_BIT_KHR = VkFormatFeatureFlags.SampledImageYcbcrConversionSeparateReconstructionFilterKHR;

	public const VkFormatFeatureFlags VK_FORMAT_FEATURE_SAMPLED_IMAGE_YCBCR_CONVERSION_CHROMA_RECONSTRUCTION_EXPLICIT_BIT_KHR = VkFormatFeatureFlags.SampledImageYcbcrConversionChromaReconstructionExplicitKHR;

	public const VkFormatFeatureFlags VK_FORMAT_FEATURE_SAMPLED_IMAGE_YCBCR_CONVERSION_CHROMA_RECONSTRUCTION_EXPLICIT_FORCEABLE_BIT_KHR = VkFormatFeatureFlags.SampledImageYcbcrConversionChromaReconstructionExplicitForceableKHR;

	public const VkFormatFeatureFlags VK_FORMAT_FEATURE_DISJOINT_BIT_KHR = VkFormatFeatureFlags.DisjointKHR;

	public const VkFormatFeatureFlags VK_FORMAT_FEATURE_COSITED_CHROMA_SAMPLES_BIT_KHR = VkFormatFeatureFlags.CositedChromaSamplesKHR;

	public const VkQueryControlFlags VK_QUERY_CONTROL_PRECISE_BIT = VkQueryControlFlags.Precise;

	public const VkQueryResultFlags VK_QUERY_RESULT_64_BIT = VkQueryResultFlags._64;

	public const VkQueryResultFlags VK_QUERY_RESULT_WAIT_BIT = VkQueryResultFlags.Wait;

	public const VkQueryResultFlags VK_QUERY_RESULT_WITH_AVAILABILITY_BIT = VkQueryResultFlags.WithAvailability;

	public const VkQueryResultFlags VK_QUERY_RESULT_PARTIAL_BIT = VkQueryResultFlags.Partial;

	public const VkCommandBufferUsageFlags VK_COMMAND_BUFFER_USAGE_ONE_TIME_SUBMIT_BIT = VkCommandBufferUsageFlags.OneTimeSubmit;

	public const VkCommandBufferUsageFlags VK_COMMAND_BUFFER_USAGE_RENDER_PASS_CONTINUE_BIT = VkCommandBufferUsageFlags.RenderPassContinue;

	public const VkCommandBufferUsageFlags VK_COMMAND_BUFFER_USAGE_SIMULTANEOUS_USE_BIT = VkCommandBufferUsageFlags.SimultaneousUse;

	public const VkQueryPipelineStatisticFlags VK_QUERY_PIPELINE_STATISTIC_INPUT_ASSEMBLY_VERTICES_BIT = VkQueryPipelineStatisticFlags.InputAssemblyVertices;

	public const VkQueryPipelineStatisticFlags VK_QUERY_PIPELINE_STATISTIC_INPUT_ASSEMBLY_PRIMITIVES_BIT = VkQueryPipelineStatisticFlags.InputAssemblyPrimitives;

	public const VkQueryPipelineStatisticFlags VK_QUERY_PIPELINE_STATISTIC_VERTEX_SHADER_INVOCATIONS_BIT = VkQueryPipelineStatisticFlags.VertexShaderInvocations;

	public const VkQueryPipelineStatisticFlags VK_QUERY_PIPELINE_STATISTIC_GEOMETRY_SHADER_INVOCATIONS_BIT = VkQueryPipelineStatisticFlags.GeometryShaderInvocations;

	public const VkQueryPipelineStatisticFlags VK_QUERY_PIPELINE_STATISTIC_GEOMETRY_SHADER_PRIMITIVES_BIT = VkQueryPipelineStatisticFlags.GeometryShaderPrimitives;

	public const VkQueryPipelineStatisticFlags VK_QUERY_PIPELINE_STATISTIC_CLIPPING_INVOCATIONS_BIT = VkQueryPipelineStatisticFlags.ClippingInvocations;

	public const VkQueryPipelineStatisticFlags VK_QUERY_PIPELINE_STATISTIC_CLIPPING_PRIMITIVES_BIT = VkQueryPipelineStatisticFlags.ClippingPrimitives;

	public const VkQueryPipelineStatisticFlags VK_QUERY_PIPELINE_STATISTIC_FRAGMENT_SHADER_INVOCATIONS_BIT = VkQueryPipelineStatisticFlags.FragmentShaderInvocations;

	public const VkQueryPipelineStatisticFlags VK_QUERY_PIPELINE_STATISTIC_TESSELLATION_CONTROL_SHADER_PATCHES_BIT = VkQueryPipelineStatisticFlags.TessellationControlShaderPatches;

	public const VkQueryPipelineStatisticFlags VK_QUERY_PIPELINE_STATISTIC_TESSELLATION_EVALUATION_SHADER_INVOCATIONS_BIT = VkQueryPipelineStatisticFlags.TessellationEvaluationShaderInvocations;

	public const VkQueryPipelineStatisticFlags VK_QUERY_PIPELINE_STATISTIC_COMPUTE_SHADER_INVOCATIONS_BIT = VkQueryPipelineStatisticFlags.ComputeShaderInvocations;

	public const VkImageAspectFlags VK_IMAGE_ASPECT_COLOR_BIT = VkImageAspectFlags.Color;

	public const VkImageAspectFlags VK_IMAGE_ASPECT_DEPTH_BIT = VkImageAspectFlags.Depth;

	public const VkImageAspectFlags VK_IMAGE_ASPECT_STENCIL_BIT = VkImageAspectFlags.Stencil;

	public const VkImageAspectFlags VK_IMAGE_ASPECT_METADATA_BIT = VkImageAspectFlags.Metadata;

	public const VkImageAspectFlags VK_IMAGE_ASPECT_PLANE_0_BIT_KHR = VkImageAspectFlags.Plane0KHR;

	public const VkImageAspectFlags VK_IMAGE_ASPECT_PLANE_1_BIT_KHR = VkImageAspectFlags.Plane1KHR;

	public const VkImageAspectFlags VK_IMAGE_ASPECT_PLANE_2_BIT_KHR = VkImageAspectFlags.Plane2KHR;

	public const VkSparseImageFormatFlags VK_SPARSE_IMAGE_FORMAT_SINGLE_MIPTAIL_BIT = VkSparseImageFormatFlags.SingleMiptail;

	public const VkSparseImageFormatFlags VK_SPARSE_IMAGE_FORMAT_ALIGNED_MIP_SIZE_BIT = VkSparseImageFormatFlags.AlignedMipSize;

	public const VkSparseImageFormatFlags VK_SPARSE_IMAGE_FORMAT_NONSTANDARD_BLOCK_SIZE_BIT = VkSparseImageFormatFlags.NonstandardBlockSize;

	public const VkSparseMemoryBindFlags VK_SPARSE_MEMORY_BIND_METADATA_BIT = VkSparseMemoryBindFlags.Metadata;

	public const VkPipelineStageFlags VK_PIPELINE_STAGE_TOP_OF_PIPE_BIT = VkPipelineStageFlags.TopOfPipe;

	public const VkPipelineStageFlags VK_PIPELINE_STAGE_DRAW_INDIRECT_BIT = VkPipelineStageFlags.DrawIndirect;

	public const VkPipelineStageFlags VK_PIPELINE_STAGE_VERTEX_INPUT_BIT = VkPipelineStageFlags.VertexInput;

	public const VkPipelineStageFlags VK_PIPELINE_STAGE_VERTEX_SHADER_BIT = VkPipelineStageFlags.VertexShader;

	public const VkPipelineStageFlags VK_PIPELINE_STAGE_TESSELLATION_CONTROL_SHADER_BIT = VkPipelineStageFlags.TessellationControlShader;

	public const VkPipelineStageFlags VK_PIPELINE_STAGE_TESSELLATION_EVALUATION_SHADER_BIT = VkPipelineStageFlags.TessellationEvaluationShader;

	public const VkPipelineStageFlags VK_PIPELINE_STAGE_GEOMETRY_SHADER_BIT = VkPipelineStageFlags.GeometryShader;

	public const VkPipelineStageFlags VK_PIPELINE_STAGE_FRAGMENT_SHADER_BIT = VkPipelineStageFlags.FragmentShader;

	public const VkPipelineStageFlags VK_PIPELINE_STAGE_EARLY_FRAGMENT_TESTS_BIT = VkPipelineStageFlags.EarlyFragmentTests;

	public const VkPipelineStageFlags VK_PIPELINE_STAGE_LATE_FRAGMENT_TESTS_BIT = VkPipelineStageFlags.LateFragmentTests;

	public const VkPipelineStageFlags VK_PIPELINE_STAGE_COLOR_ATTACHMENT_OUTPUT_BIT = VkPipelineStageFlags.ColorAttachmentOutput;

	public const VkPipelineStageFlags VK_PIPELINE_STAGE_COMPUTE_SHADER_BIT = VkPipelineStageFlags.ComputeShader;

	public const VkPipelineStageFlags VK_PIPELINE_STAGE_TRANSFER_BIT = VkPipelineStageFlags.Transfer;

	public const VkPipelineStageFlags VK_PIPELINE_STAGE_BOTTOM_OF_PIPE_BIT = VkPipelineStageFlags.BottomOfPipe;

	public const VkPipelineStageFlags VK_PIPELINE_STAGE_HOST_BIT = VkPipelineStageFlags.Host;

	public const VkPipelineStageFlags VK_PIPELINE_STAGE_ALL_GRAPHICS_BIT = VkPipelineStageFlags.AllGraphics;

	public const VkPipelineStageFlags VK_PIPELINE_STAGE_ALL_COMMANDS_BIT = VkPipelineStageFlags.AllCommands;

	public const VkPipelineStageFlags VK_PIPELINE_STAGE_COMMAND_PROCESS_BIT_NVX = VkPipelineStageFlags.CommandProcessNVX;

	public const VkCommandPoolCreateFlags VK_COMMAND_POOL_CREATE_TRANSIENT_BIT = VkCommandPoolCreateFlags.Transient;

	public const VkCommandPoolCreateFlags VK_COMMAND_POOL_CREATE_RESET_COMMAND_BUFFER_BIT = VkCommandPoolCreateFlags.ResetCommandBuffer;

	public const VkCommandPoolResetFlags VK_COMMAND_POOL_RESET_RELEASE_RESOURCES_BIT = VkCommandPoolResetFlags.ReleaseResources;

	public const VkCommandBufferResetFlags VK_COMMAND_BUFFER_RESET_RELEASE_RESOURCES_BIT = VkCommandBufferResetFlags.ReleaseResources;

	public const VkSampleCountFlags VK_SAMPLE_COUNT_1_BIT = VkSampleCountFlags.Count1;

	public const VkSampleCountFlags VK_SAMPLE_COUNT_2_BIT = VkSampleCountFlags.Count2;

	public const VkSampleCountFlags VK_SAMPLE_COUNT_4_BIT = VkSampleCountFlags.Count4;

	public const VkSampleCountFlags VK_SAMPLE_COUNT_8_BIT = VkSampleCountFlags.Count8;

	public const VkSampleCountFlags VK_SAMPLE_COUNT_16_BIT = VkSampleCountFlags.Count16;

	public const VkSampleCountFlags VK_SAMPLE_COUNT_32_BIT = VkSampleCountFlags.Count32;

	public const VkSampleCountFlags VK_SAMPLE_COUNT_64_BIT = VkSampleCountFlags.Count64;

	public const VkAttachmentDescriptionFlags VK_ATTACHMENT_DESCRIPTION_MAY_ALIAS_BIT = VkAttachmentDescriptionFlags.MayAlias;

	public const VkStencilFaceFlags VK_STENCIL_FACE_FRONT_BIT = VkStencilFaceFlags.Front;

	public const VkStencilFaceFlags VK_STENCIL_FACE_BACK_BIT = VkStencilFaceFlags.Back;

	public const VkStencilFaceFlags VK_STENCIL_FRONT_AND_BACK = VkStencilFaceFlags.FrontAndBack;

	public const VkDescriptorPoolCreateFlags VK_DESCRIPTOR_POOL_CREATE_FREE_DESCRIPTOR_SET_BIT = VkDescriptorPoolCreateFlags.FreeDescriptorSet;

	public const VkDependencyFlags VK_DEPENDENCY_BY_REGION_BIT = VkDependencyFlags.ByRegion;

	public const VkDependencyFlags VK_DEPENDENCY_VIEW_LOCAL_BIT_KHX = VkDependencyFlags.ViewLocalKHX;

	public const VkDependencyFlags VK_DEPENDENCY_DEVICE_GROUP_BIT_KHX = VkDependencyFlags.DeviceGroupKHX;

	public const VkPresentModeKHR VK_PRESENT_MODE_IMMEDIATE_KHR = VkPresentModeKHR.ImmediateKHR;

	public const VkPresentModeKHR VK_PRESENT_MODE_MAILBOX_KHR = VkPresentModeKHR.MailboxKHR;

	public const VkPresentModeKHR VK_PRESENT_MODE_FIFO_KHR = VkPresentModeKHR.FifoKHR;

	public const VkPresentModeKHR VK_PRESENT_MODE_FIFO_RELAXED_KHR = VkPresentModeKHR.FifoRelaxedKHR;

	public const VkPresentModeKHR VK_PRESENT_MODE_SHARED_DEMAND_REFRESH_KHR = VkPresentModeKHR.SharedDemandRefreshKHR;

	public const VkPresentModeKHR VK_PRESENT_MODE_SHARED_CONTINUOUS_REFRESH_KHR = VkPresentModeKHR.SharedContinuousRefreshKHR;

	public const VkColorSpaceKHR VK_COLOR_SPACE_SRGB_NONLINEAR_KHR = VkColorSpaceKHR.SrgbNonlinearKHR;

	public const VkColorSpaceKHR VK_COLOR_SPACE_DISPLAY_P3_NONLINEAR_EXT = VkColorSpaceKHR.DisplayP3NonlinearEXT;

	public const VkColorSpaceKHR VK_COLOR_SPACE_EXTENDED_SRGB_LINEAR_EXT = VkColorSpaceKHR.ExtendedSrgbLinearEXT;

	public const VkColorSpaceKHR VK_COLOR_SPACE_DCI_P3_LINEAR_EXT = VkColorSpaceKHR.DciP3LinearEXT;

	public const VkColorSpaceKHR VK_COLOR_SPACE_DCI_P3_NONLINEAR_EXT = VkColorSpaceKHR.DciP3NonlinearEXT;

	public const VkColorSpaceKHR VK_COLOR_SPACE_BT709_LINEAR_EXT = VkColorSpaceKHR.Bt709LinearEXT;

	public const VkColorSpaceKHR VK_COLOR_SPACE_BT709_NONLINEAR_EXT = VkColorSpaceKHR.Bt709NonlinearEXT;

	public const VkColorSpaceKHR VK_COLOR_SPACE_BT2020_LINEAR_EXT = VkColorSpaceKHR.Bt2020LinearEXT;

	public const VkColorSpaceKHR VK_COLOR_SPACE_HDR10_ST2084_EXT = VkColorSpaceKHR.Hdr10St2084EXT;

	public const VkColorSpaceKHR VK_COLOR_SPACE_DOLBYVISION_EXT = VkColorSpaceKHR.DolbyvisionEXT;

	public const VkColorSpaceKHR VK_COLOR_SPACE_HDR10_HLG_EXT = VkColorSpaceKHR.Hdr10HlgEXT;

	public const VkColorSpaceKHR VK_COLOR_SPACE_ADOBERGB_LINEAR_EXT = VkColorSpaceKHR.AdobergbLinearEXT;

	public const VkColorSpaceKHR VK_COLOR_SPACE_ADOBERGB_NONLINEAR_EXT = VkColorSpaceKHR.AdobergbNonlinearEXT;

	public const VkColorSpaceKHR VK_COLOR_SPACE_PASS_THROUGH_EXT = VkColorSpaceKHR.PassThroughEXT;

	public const VkColorSpaceKHR VK_COLOR_SPACE_EXTENDED_SRGB_NONLINEAR_EXT = VkColorSpaceKHR.ExtendedSrgbNonlinearEXT;

	public const VkDisplayPlaneAlphaFlagsKHR VK_DISPLAY_PLANE_ALPHA_OPAQUE_BIT_KHR = VkDisplayPlaneAlphaFlagsKHR.OpaqueKHR;

	public const VkDisplayPlaneAlphaFlagsKHR VK_DISPLAY_PLANE_ALPHA_GLOBAL_BIT_KHR = VkDisplayPlaneAlphaFlagsKHR.GlobalKHR;

	public const VkDisplayPlaneAlphaFlagsKHR VK_DISPLAY_PLANE_ALPHA_PER_PIXEL_BIT_KHR = VkDisplayPlaneAlphaFlagsKHR.PerPixelKHR;

	public const VkDisplayPlaneAlphaFlagsKHR VK_DISPLAY_PLANE_ALPHA_PER_PIXEL_PREMULTIPLIED_BIT_KHR = VkDisplayPlaneAlphaFlagsKHR.PerPixelPremultipliedKHR;

	public const VkCompositeAlphaFlagsKHR VK_COMPOSITE_ALPHA_OPAQUE_BIT_KHR = VkCompositeAlphaFlagsKHR.OpaqueKHR;

	public const VkCompositeAlphaFlagsKHR VK_COMPOSITE_ALPHA_PRE_MULTIPLIED_BIT_KHR = VkCompositeAlphaFlagsKHR.PreMultipliedKHR;

	public const VkCompositeAlphaFlagsKHR VK_COMPOSITE_ALPHA_POST_MULTIPLIED_BIT_KHR = VkCompositeAlphaFlagsKHR.PostMultipliedKHR;

	public const VkCompositeAlphaFlagsKHR VK_COMPOSITE_ALPHA_INHERIT_BIT_KHR = VkCompositeAlphaFlagsKHR.InheritKHR;

	public const VkSurfaceTransformFlagsKHR VK_SURFACE_TRANSFORM_IDENTITY_BIT_KHR = VkSurfaceTransformFlagsKHR.IdentityKHR;

	public const VkSurfaceTransformFlagsKHR VK_SURFACE_TRANSFORM_ROTATE_90_BIT_KHR = VkSurfaceTransformFlagsKHR.Rotate90KHR;

	public const VkSurfaceTransformFlagsKHR VK_SURFACE_TRANSFORM_ROTATE_180_BIT_KHR = VkSurfaceTransformFlagsKHR.Rotate180KHR;

	public const VkSurfaceTransformFlagsKHR VK_SURFACE_TRANSFORM_ROTATE_270_BIT_KHR = VkSurfaceTransformFlagsKHR.Rotate270KHR;

	public const VkSurfaceTransformFlagsKHR VK_SURFACE_TRANSFORM_HORIZONTAL_MIRROR_BIT_KHR = VkSurfaceTransformFlagsKHR.HorizontalMirrorKHR;

	public const VkSurfaceTransformFlagsKHR VK_SURFACE_TRANSFORM_HORIZONTAL_MIRROR_ROTATE_90_BIT_KHR = VkSurfaceTransformFlagsKHR.HorizontalMirrorRotate90KHR;

	public const VkSurfaceTransformFlagsKHR VK_SURFACE_TRANSFORM_HORIZONTAL_MIRROR_ROTATE_180_BIT_KHR = VkSurfaceTransformFlagsKHR.HorizontalMirrorRotate180KHR;

	public const VkSurfaceTransformFlagsKHR VK_SURFACE_TRANSFORM_HORIZONTAL_MIRROR_ROTATE_270_BIT_KHR = VkSurfaceTransformFlagsKHR.HorizontalMirrorRotate270KHR;

	public const VkSurfaceTransformFlagsKHR VK_SURFACE_TRANSFORM_INHERIT_BIT_KHR = VkSurfaceTransformFlagsKHR.InheritKHR;

	public const VkDebugReportFlagsEXT VK_DEBUG_REPORT_INFORMATION_BIT_EXT = VkDebugReportFlagsEXT.InformationEXT;

	public const VkDebugReportFlagsEXT VK_DEBUG_REPORT_WARNING_BIT_EXT = VkDebugReportFlagsEXT.WarningEXT;

	public const VkDebugReportFlagsEXT VK_DEBUG_REPORT_PERFORMANCE_WARNING_BIT_EXT = VkDebugReportFlagsEXT.PerformanceWarningEXT;

	public const VkDebugReportFlagsEXT VK_DEBUG_REPORT_ERROR_BIT_EXT = VkDebugReportFlagsEXT.ErrorEXT;

	public const VkDebugReportFlagsEXT VK_DEBUG_REPORT_DEBUG_BIT_EXT = VkDebugReportFlagsEXT.DebugEXT;

	public const VkDebugReportObjectTypeEXT VK_DEBUG_REPORT_OBJECT_TYPE_UNKNOWN_EXT = VkDebugReportObjectTypeEXT.UnknownEXT;

	public const VkDebugReportObjectTypeEXT VK_DEBUG_REPORT_OBJECT_TYPE_INSTANCE_EXT = VkDebugReportObjectTypeEXT.InstanceEXT;

	public const VkDebugReportObjectTypeEXT VK_DEBUG_REPORT_OBJECT_TYPE_PHYSICAL_DEVICE_EXT = VkDebugReportObjectTypeEXT.PhysicalDeviceEXT;

	public const VkDebugReportObjectTypeEXT VK_DEBUG_REPORT_OBJECT_TYPE_DEVICE_EXT = VkDebugReportObjectTypeEXT.DeviceEXT;

	public const VkDebugReportObjectTypeEXT VK_DEBUG_REPORT_OBJECT_TYPE_QUEUE_EXT = VkDebugReportObjectTypeEXT.QueueEXT;

	public const VkDebugReportObjectTypeEXT VK_DEBUG_REPORT_OBJECT_TYPE_SEMAPHORE_EXT = VkDebugReportObjectTypeEXT.SemaphoreEXT;

	public const VkDebugReportObjectTypeEXT VK_DEBUG_REPORT_OBJECT_TYPE_COMMAND_BUFFER_EXT = VkDebugReportObjectTypeEXT.CommandBufferEXT;

	public const VkDebugReportObjectTypeEXT VK_DEBUG_REPORT_OBJECT_TYPE_FENCE_EXT = VkDebugReportObjectTypeEXT.FenceEXT;

	public const VkDebugReportObjectTypeEXT VK_DEBUG_REPORT_OBJECT_TYPE_DEVICE_MEMORY_EXT = VkDebugReportObjectTypeEXT.DeviceMemoryEXT;

	public const VkDebugReportObjectTypeEXT VK_DEBUG_REPORT_OBJECT_TYPE_BUFFER_EXT = VkDebugReportObjectTypeEXT.BufferEXT;

	public const VkDebugReportObjectTypeEXT VK_DEBUG_REPORT_OBJECT_TYPE_IMAGE_EXT = VkDebugReportObjectTypeEXT.ImageEXT;

	public const VkDebugReportObjectTypeEXT VK_DEBUG_REPORT_OBJECT_TYPE_EVENT_EXT = VkDebugReportObjectTypeEXT.EventEXT;

	public const VkDebugReportObjectTypeEXT VK_DEBUG_REPORT_OBJECT_TYPE_QUERY_POOL_EXT = VkDebugReportObjectTypeEXT.QueryPoolEXT;

	public const VkDebugReportObjectTypeEXT VK_DEBUG_REPORT_OBJECT_TYPE_BUFFER_VIEW_EXT = VkDebugReportObjectTypeEXT.BufferViewEXT;

	public const VkDebugReportObjectTypeEXT VK_DEBUG_REPORT_OBJECT_TYPE_IMAGE_VIEW_EXT = VkDebugReportObjectTypeEXT.ImageViewEXT;

	public const VkDebugReportObjectTypeEXT VK_DEBUG_REPORT_OBJECT_TYPE_SHADER_MODULE_EXT = VkDebugReportObjectTypeEXT.ShaderModuleEXT;

	public const VkDebugReportObjectTypeEXT VK_DEBUG_REPORT_OBJECT_TYPE_PIPELINE_CACHE_EXT = VkDebugReportObjectTypeEXT.PipelineCacheEXT;

	public const VkDebugReportObjectTypeEXT VK_DEBUG_REPORT_OBJECT_TYPE_PIPELINE_LAYOUT_EXT = VkDebugReportObjectTypeEXT.PipelineLayoutEXT;

	public const VkDebugReportObjectTypeEXT VK_DEBUG_REPORT_OBJECT_TYPE_RENDER_PASS_EXT = VkDebugReportObjectTypeEXT.RenderPassEXT;

	public const VkDebugReportObjectTypeEXT VK_DEBUG_REPORT_OBJECT_TYPE_PIPELINE_EXT = VkDebugReportObjectTypeEXT.PipelineEXT;

	public const VkDebugReportObjectTypeEXT VK_DEBUG_REPORT_OBJECT_TYPE_DESCRIPTOR_SET_LAYOUT_EXT = VkDebugReportObjectTypeEXT.DescriptorSetLayoutEXT;

	public const VkDebugReportObjectTypeEXT VK_DEBUG_REPORT_OBJECT_TYPE_SAMPLER_EXT = VkDebugReportObjectTypeEXT.SamplerEXT;

	public const VkDebugReportObjectTypeEXT VK_DEBUG_REPORT_OBJECT_TYPE_DESCRIPTOR_POOL_EXT = VkDebugReportObjectTypeEXT.DescriptorPoolEXT;

	public const VkDebugReportObjectTypeEXT VK_DEBUG_REPORT_OBJECT_TYPE_DESCRIPTOR_SET_EXT = VkDebugReportObjectTypeEXT.DescriptorSetEXT;

	public const VkDebugReportObjectTypeEXT VK_DEBUG_REPORT_OBJECT_TYPE_FRAMEBUFFER_EXT = VkDebugReportObjectTypeEXT.FramebufferEXT;

	public const VkDebugReportObjectTypeEXT VK_DEBUG_REPORT_OBJECT_TYPE_COMMAND_POOL_EXT = VkDebugReportObjectTypeEXT.CommandPoolEXT;

	public const VkDebugReportObjectTypeEXT VK_DEBUG_REPORT_OBJECT_TYPE_SURFACE_KHR_EXT = VkDebugReportObjectTypeEXT.SurfaceKHREXT;

	public const VkDebugReportObjectTypeEXT VK_DEBUG_REPORT_OBJECT_TYPE_SWAPCHAIN_KHR_EXT = VkDebugReportObjectTypeEXT.SwapchainKHREXT;

	public const VkDebugReportObjectTypeEXT VK_DEBUG_REPORT_OBJECT_TYPE_DEBUG_REPORT_CALLBACK_EXT_EXT = VkDebugReportObjectTypeEXT.DebugReportCallbackEXTEXT;

	public const VkDebugReportObjectTypeEXT VK_DEBUG_REPORT_OBJECT_TYPE_DISPLAY_KHR_EXT = VkDebugReportObjectTypeEXT.DisplayKHREXT;

	public const VkDebugReportObjectTypeEXT VK_DEBUG_REPORT_OBJECT_TYPE_DISPLAY_MODE_KHR_EXT = VkDebugReportObjectTypeEXT.DisplayModeKHREXT;

	public const VkDebugReportObjectTypeEXT VK_DEBUG_REPORT_OBJECT_TYPE_OBJECT_TABLE_NVX_EXT = VkDebugReportObjectTypeEXT.ObjectTableNVXEXT;

	public const VkDebugReportObjectTypeEXT VK_DEBUG_REPORT_OBJECT_TYPE_INDIRECT_COMMANDS_LAYOUT_NVX_EXT = VkDebugReportObjectTypeEXT.IndirectCommandsLayoutNVXEXT;

	public const VkDebugReportObjectTypeEXT VK_DEBUG_REPORT_OBJECT_TYPE_VALIDATION_CACHE_EXT_EXT = VkDebugReportObjectTypeEXT.ValidationCacheEXTEXT;

	public const VkDebugReportObjectTypeEXT VK_DEBUG_REPORT_OBJECT_TYPE_DESCRIPTOR_UPDATE_TEMPLATE_KHR_EXT = VkDebugReportObjectTypeEXT.DescriptorUpdateTemplateKHREXT;

	public const VkDebugReportObjectTypeEXT VK_DEBUG_REPORT_OBJECT_TYPE_SAMPLER_YCBCR_CONVERSION_KHR_EXT = VkDebugReportObjectTypeEXT.SamplerYcbcrConversionKHREXT;

	public const VkRasterizationOrderAMD VK_RASTERIZATION_ORDER_STRICT_AMD = VkRasterizationOrderAMD.StrictAMD;

	public const VkRasterizationOrderAMD VK_RASTERIZATION_ORDER_RELAXED_AMD = VkRasterizationOrderAMD.RelaxedAMD;

	public const VkExternalMemoryHandleTypeFlagsNV VK_EXTERNAL_MEMORY_HANDLE_TYPE_OPAQUE_WIN32_BIT_NV = VkExternalMemoryHandleTypeFlagsNV.OpaqueWin32NV;

	public const VkExternalMemoryHandleTypeFlagsNV VK_EXTERNAL_MEMORY_HANDLE_TYPE_OPAQUE_WIN32_KMT_BIT_NV = VkExternalMemoryHandleTypeFlagsNV.OpaqueWin32KmtNV;

	public const VkExternalMemoryHandleTypeFlagsNV VK_EXTERNAL_MEMORY_HANDLE_TYPE_D3D11_IMAGE_BIT_NV = VkExternalMemoryHandleTypeFlagsNV.D3d11ImageNV;

	public const VkExternalMemoryHandleTypeFlagsNV VK_EXTERNAL_MEMORY_HANDLE_TYPE_D3D11_IMAGE_KMT_BIT_NV = VkExternalMemoryHandleTypeFlagsNV.D3d11ImageKmtNV;

	public const VkExternalMemoryFeatureFlagsNV VK_EXTERNAL_MEMORY_FEATURE_DEDICATED_ONLY_BIT_NV = VkExternalMemoryFeatureFlagsNV.DedicatedOnlyNV;

	public const VkExternalMemoryFeatureFlagsNV VK_EXTERNAL_MEMORY_FEATURE_EXPORTABLE_BIT_NV = VkExternalMemoryFeatureFlagsNV.ExportableNV;

	public const VkExternalMemoryFeatureFlagsNV VK_EXTERNAL_MEMORY_FEATURE_IMPORTABLE_BIT_NV = VkExternalMemoryFeatureFlagsNV.ImportableNV;

	public const VkValidationCheckEXT VK_VALIDATION_CHECK_ALL_EXT = VkValidationCheckEXT.AllEXT;

	public const VkValidationCheckEXT VK_VALIDATION_CHECK_SHADERS_EXT = VkValidationCheckEXT.ShadersEXT;

	public const VkIndirectCommandsLayoutUsageFlagsNVX VK_INDIRECT_COMMANDS_LAYOUT_USAGE_UNORDERED_SEQUENCES_BIT_NVX = VkIndirectCommandsLayoutUsageFlagsNVX.UnorderedSequencesNVX;

	public const VkIndirectCommandsLayoutUsageFlagsNVX VK_INDIRECT_COMMANDS_LAYOUT_USAGE_SPARSE_SEQUENCES_BIT_NVX = VkIndirectCommandsLayoutUsageFlagsNVX.SparseSequencesNVX;

	public const VkIndirectCommandsLayoutUsageFlagsNVX VK_INDIRECT_COMMANDS_LAYOUT_USAGE_EMPTY_EXECUTIONS_BIT_NVX = VkIndirectCommandsLayoutUsageFlagsNVX.EmptyExecutionsNVX;

	public const VkIndirectCommandsLayoutUsageFlagsNVX VK_INDIRECT_COMMANDS_LAYOUT_USAGE_INDEXED_SEQUENCES_BIT_NVX = VkIndirectCommandsLayoutUsageFlagsNVX.IndexedSequencesNVX;

	public const VkObjectEntryUsageFlagsNVX VK_OBJECT_ENTRY_USAGE_GRAPHICS_BIT_NVX = VkObjectEntryUsageFlagsNVX.GraphicsNVX;

	public const VkObjectEntryUsageFlagsNVX VK_OBJECT_ENTRY_USAGE_COMPUTE_BIT_NVX = VkObjectEntryUsageFlagsNVX.ComputeNVX;

	public const VkIndirectCommandsTokenTypeNVX VK_INDIRECT_COMMANDS_TOKEN_TYPE_PIPELINE_NVX = VkIndirectCommandsTokenTypeNVX.TypePipelineNVX;

	public const VkIndirectCommandsTokenTypeNVX VK_INDIRECT_COMMANDS_TOKEN_TYPE_DESCRIPTOR_SET_NVX = VkIndirectCommandsTokenTypeNVX.TypeDescriptorSetNVX;

	public const VkIndirectCommandsTokenTypeNVX VK_INDIRECT_COMMANDS_TOKEN_TYPE_INDEX_BUFFER_NVX = VkIndirectCommandsTokenTypeNVX.TypeIndexBufferNVX;

	public const VkIndirectCommandsTokenTypeNVX VK_INDIRECT_COMMANDS_TOKEN_TYPE_VERTEX_BUFFER_NVX = VkIndirectCommandsTokenTypeNVX.TypeVertexBufferNVX;

	public const VkIndirectCommandsTokenTypeNVX VK_INDIRECT_COMMANDS_TOKEN_TYPE_PUSH_CONSTANT_NVX = VkIndirectCommandsTokenTypeNVX.TypePushConstantNVX;

	public const VkIndirectCommandsTokenTypeNVX VK_INDIRECT_COMMANDS_TOKEN_TYPE_DRAW_INDEXED_NVX = VkIndirectCommandsTokenTypeNVX.TypeDrawIndexedNVX;

	public const VkIndirectCommandsTokenTypeNVX VK_INDIRECT_COMMANDS_TOKEN_TYPE_DRAW_NVX = VkIndirectCommandsTokenTypeNVX.TypeDrawNVX;

	public const VkIndirectCommandsTokenTypeNVX VK_INDIRECT_COMMANDS_TOKEN_TYPE_DISPATCH_NVX = VkIndirectCommandsTokenTypeNVX.TypeDispatchNVX;

	public const VkObjectEntryTypeNVX VK_OBJECT_ENTRY_TYPE_DESCRIPTOR_SET_NVX = VkObjectEntryTypeNVX.TypeDescriptorSetNVX;

	public const VkObjectEntryTypeNVX VK_OBJECT_ENTRY_TYPE_PIPELINE_NVX = VkObjectEntryTypeNVX.TypePipelineNVX;

	public const VkObjectEntryTypeNVX VK_OBJECT_ENTRY_TYPE_INDEX_BUFFER_NVX = VkObjectEntryTypeNVX.TypeIndexBufferNVX;

	public const VkObjectEntryTypeNVX VK_OBJECT_ENTRY_TYPE_VERTEX_BUFFER_NVX = VkObjectEntryTypeNVX.TypeVertexBufferNVX;

	public const VkObjectEntryTypeNVX VK_OBJECT_ENTRY_TYPE_PUSH_CONSTANT_NVX = VkObjectEntryTypeNVX.TypePushConstantNVX;

	public const VkDescriptorSetLayoutCreateFlags VK_DESCRIPTOR_SET_LAYOUT_CREATE_PUSH_DESCRIPTOR_BIT_KHR = VkDescriptorSetLayoutCreateFlags.PushDescriptorKHR;

	public const VkExternalMemoryHandleTypeFlagsKHR VK_EXTERNAL_MEMORY_HANDLE_TYPE_OPAQUE_FD_BIT_KHR = VkExternalMemoryHandleTypeFlagsKHR.OpaqueFdKHR;

	public const VkExternalMemoryHandleTypeFlagsKHR VK_EXTERNAL_MEMORY_HANDLE_TYPE_OPAQUE_WIN32_BIT_KHR = VkExternalMemoryHandleTypeFlagsKHR.OpaqueWin32KHR;

	public const VkExternalMemoryHandleTypeFlagsKHR VK_EXTERNAL_MEMORY_HANDLE_TYPE_OPAQUE_WIN32_KMT_BIT_KHR = VkExternalMemoryHandleTypeFlagsKHR.OpaqueWin32KmtKHR;

	public const VkExternalMemoryHandleTypeFlagsKHR VK_EXTERNAL_MEMORY_HANDLE_TYPE_D3D11_TEXTURE_BIT_KHR = VkExternalMemoryHandleTypeFlagsKHR.D3d11TextureKHR;

	public const VkExternalMemoryHandleTypeFlagsKHR VK_EXTERNAL_MEMORY_HANDLE_TYPE_D3D11_TEXTURE_KMT_BIT_KHR = VkExternalMemoryHandleTypeFlagsKHR.D3d11TextureKmtKHR;

	public const VkExternalMemoryHandleTypeFlagsKHR VK_EXTERNAL_MEMORY_HANDLE_TYPE_D3D12_HEAP_BIT_KHR = VkExternalMemoryHandleTypeFlagsKHR.D3d12HeapKHR;

	public const VkExternalMemoryHandleTypeFlagsKHR VK_EXTERNAL_MEMORY_HANDLE_TYPE_D3D12_RESOURCE_BIT_KHR = VkExternalMemoryHandleTypeFlagsKHR.D3d12ResourceKHR;

	public const VkExternalMemoryHandleTypeFlagsKHR VK_EXTERNAL_MEMORY_HANDLE_TYPE_DMA_BUF_BIT_EXT = VkExternalMemoryHandleTypeFlagsKHR.DmaBufEXT;

	public const VkExternalMemoryHandleTypeFlagsKHR VK_EXTERNAL_MEMORY_HANDLE_TYPE_HOST_ALLOCATION_BIT_EXT = VkExternalMemoryHandleTypeFlagsKHR.HostAllocationEXT;

	public const VkExternalMemoryHandleTypeFlagsKHR VK_EXTERNAL_MEMORY_HANDLE_TYPE_HOST_MAPPED_FOREIGN_MEMORY_BIT_EXT = VkExternalMemoryHandleTypeFlagsKHR.HostMappedForeignMemoryEXT;

	public const VkExternalMemoryFeatureFlagsKHR VK_EXTERNAL_MEMORY_FEATURE_DEDICATED_ONLY_BIT_KHR = VkExternalMemoryFeatureFlagsKHR.DedicatedOnlyKHR;

	public const VkExternalMemoryFeatureFlagsKHR VK_EXTERNAL_MEMORY_FEATURE_EXPORTABLE_BIT_KHR = VkExternalMemoryFeatureFlagsKHR.ExportableKHR;

	public const VkExternalMemoryFeatureFlagsKHR VK_EXTERNAL_MEMORY_FEATURE_IMPORTABLE_BIT_KHR = VkExternalMemoryFeatureFlagsKHR.ImportableKHR;

	public const VkExternalSemaphoreHandleTypeFlagsKHR VK_EXTERNAL_SEMAPHORE_HANDLE_TYPE_OPAQUE_FD_BIT_KHR = VkExternalSemaphoreHandleTypeFlagsKHR.OpaqueFdKHR;

	public const VkExternalSemaphoreHandleTypeFlagsKHR VK_EXTERNAL_SEMAPHORE_HANDLE_TYPE_OPAQUE_WIN32_BIT_KHR = VkExternalSemaphoreHandleTypeFlagsKHR.OpaqueWin32KHR;

	public const VkExternalSemaphoreHandleTypeFlagsKHR VK_EXTERNAL_SEMAPHORE_HANDLE_TYPE_OPAQUE_WIN32_KMT_BIT_KHR = VkExternalSemaphoreHandleTypeFlagsKHR.OpaqueWin32KmtKHR;

	public const VkExternalSemaphoreHandleTypeFlagsKHR VK_EXTERNAL_SEMAPHORE_HANDLE_TYPE_D3D12_FENCE_BIT_KHR = VkExternalSemaphoreHandleTypeFlagsKHR.D3d12FenceKHR;

	public const VkExternalSemaphoreHandleTypeFlagsKHR VK_EXTERNAL_SEMAPHORE_HANDLE_TYPE_SYNC_FD_BIT_KHR = VkExternalSemaphoreHandleTypeFlagsKHR.SyncFdKHR;

	public const VkExternalSemaphoreFeatureFlagsKHR VK_EXTERNAL_SEMAPHORE_FEATURE_EXPORTABLE_BIT_KHR = VkExternalSemaphoreFeatureFlagsKHR.ExportableKHR;

	public const VkExternalSemaphoreFeatureFlagsKHR VK_EXTERNAL_SEMAPHORE_FEATURE_IMPORTABLE_BIT_KHR = VkExternalSemaphoreFeatureFlagsKHR.ImportableKHR;

	public const VkSemaphoreImportFlagsKHR VK_SEMAPHORE_IMPORT_TEMPORARY_BIT_KHR = VkSemaphoreImportFlagsKHR.TemporaryKHR;

	public const VkExternalFenceHandleTypeFlagsKHR VK_EXTERNAL_FENCE_HANDLE_TYPE_OPAQUE_FD_BIT_KHR = VkExternalFenceHandleTypeFlagsKHR.OpaqueFdKHR;

	public const VkExternalFenceHandleTypeFlagsKHR VK_EXTERNAL_FENCE_HANDLE_TYPE_OPAQUE_WIN32_BIT_KHR = VkExternalFenceHandleTypeFlagsKHR.OpaqueWin32KHR;

	public const VkExternalFenceHandleTypeFlagsKHR VK_EXTERNAL_FENCE_HANDLE_TYPE_OPAQUE_WIN32_KMT_BIT_KHR = VkExternalFenceHandleTypeFlagsKHR.OpaqueWin32KmtKHR;

	public const VkExternalFenceHandleTypeFlagsKHR VK_EXTERNAL_FENCE_HANDLE_TYPE_SYNC_FD_BIT_KHR = VkExternalFenceHandleTypeFlagsKHR.SyncFdKHR;

	public const VkExternalFenceFeatureFlagsKHR VK_EXTERNAL_FENCE_FEATURE_EXPORTABLE_BIT_KHR = VkExternalFenceFeatureFlagsKHR.ExportableKHR;

	public const VkExternalFenceFeatureFlagsKHR VK_EXTERNAL_FENCE_FEATURE_IMPORTABLE_BIT_KHR = VkExternalFenceFeatureFlagsKHR.ImportableKHR;

	public const VkFenceImportFlagsKHR VK_FENCE_IMPORT_TEMPORARY_BIT_KHR = VkFenceImportFlagsKHR.TemporaryKHR;

	public const VkSurfaceCounterFlagsEXT VK_SURFACE_COUNTER_VBLANK_EXT = VkSurfaceCounterFlagsEXT.VblankEXT;

	public const VkDisplayPowerStateEXT VK_DISPLAY_POWER_STATE_OFF_EXT = VkDisplayPowerStateEXT.OffEXT;

	public const VkDisplayPowerStateEXT VK_DISPLAY_POWER_STATE_SUSPEND_EXT = VkDisplayPowerStateEXT.SuspendEXT;

	public const VkDisplayPowerStateEXT VK_DISPLAY_POWER_STATE_ON_EXT = VkDisplayPowerStateEXT.OnEXT;

	public const VkDeviceEventTypeEXT VK_DEVICE_EVENT_TYPE_DISPLAY_HOTPLUG_EXT = VkDeviceEventTypeEXT.DisplayHotplugEXT;

	public const VkDisplayEventTypeEXT VK_DISPLAY_EVENT_TYPE_FIRST_PIXEL_OUT_EXT = VkDisplayEventTypeEXT.FirstPixelOutEXT;

	public const VkPeerMemoryFeatureFlagsKHX VK_PEER_MEMORY_FEATURE_COPY_SRC_BIT_KHX = VkPeerMemoryFeatureFlagsKHX.CopySrcKHX;

	public const VkPeerMemoryFeatureFlagsKHX VK_PEER_MEMORY_FEATURE_COPY_DST_BIT_KHX = VkPeerMemoryFeatureFlagsKHX.CopyDstKHX;

	public const VkPeerMemoryFeatureFlagsKHX VK_PEER_MEMORY_FEATURE_GENERIC_SRC_BIT_KHX = VkPeerMemoryFeatureFlagsKHX.GenericSrcKHX;

	public const VkPeerMemoryFeatureFlagsKHX VK_PEER_MEMORY_FEATURE_GENERIC_DST_BIT_KHX = VkPeerMemoryFeatureFlagsKHX.GenericDstKHX;

	public const VkMemoryAllocateFlagsKHX VK_MEMORY_ALLOCATE_DEVICE_MASK_BIT_KHX = VkMemoryAllocateFlagsKHX.DeviceMaskKHX;

	public const VkDeviceGroupPresentModeFlagsKHX VK_DEVICE_GROUP_PRESENT_MODE_LOCAL_BIT_KHX = VkDeviceGroupPresentModeFlagsKHX.LocalKHX;

	public const VkDeviceGroupPresentModeFlagsKHX VK_DEVICE_GROUP_PRESENT_MODE_REMOTE_BIT_KHX = VkDeviceGroupPresentModeFlagsKHX.RemoteKHX;

	public const VkDeviceGroupPresentModeFlagsKHX VK_DEVICE_GROUP_PRESENT_MODE_SUM_BIT_KHX = VkDeviceGroupPresentModeFlagsKHX.SumKHX;

	public const VkDeviceGroupPresentModeFlagsKHX VK_DEVICE_GROUP_PRESENT_MODE_LOCAL_MULTI_DEVICE_BIT_KHX = VkDeviceGroupPresentModeFlagsKHX.LocalMultiDeviceKHX;

	public const VkSwapchainCreateFlagsKHR VK_SWAPCHAIN_CREATE_BIND_SFR_BIT_KHX = VkSwapchainCreateFlagsKHR.BindSfrKHX;

	public const VkViewportCoordinateSwizzleNV VK_VIEWPORT_COORDINATE_SWIZZLE_POSITIVE_X_NV = VkViewportCoordinateSwizzleNV.VK_VIEWPORT_COORDINATE_SWIZZLE_POSITIVE_X_NV;

	public const VkViewportCoordinateSwizzleNV VK_VIEWPORT_COORDINATE_SWIZZLE_NEGATIVE_X_NV = VkViewportCoordinateSwizzleNV.VK_VIEWPORT_COORDINATE_SWIZZLE_NEGATIVE_X_NV;

	public const VkViewportCoordinateSwizzleNV VK_VIEWPORT_COORDINATE_SWIZZLE_POSITIVE_Y_NV = VkViewportCoordinateSwizzleNV.VK_VIEWPORT_COORDINATE_SWIZZLE_POSITIVE_Y_NV;

	public const VkViewportCoordinateSwizzleNV VK_VIEWPORT_COORDINATE_SWIZZLE_NEGATIVE_Y_NV = VkViewportCoordinateSwizzleNV.VK_VIEWPORT_COORDINATE_SWIZZLE_NEGATIVE_Y_NV;

	public const VkViewportCoordinateSwizzleNV VK_VIEWPORT_COORDINATE_SWIZZLE_POSITIVE_Z_NV = VkViewportCoordinateSwizzleNV.VK_VIEWPORT_COORDINATE_SWIZZLE_POSITIVE_Z_NV;

	public const VkViewportCoordinateSwizzleNV VK_VIEWPORT_COORDINATE_SWIZZLE_NEGATIVE_Z_NV = VkViewportCoordinateSwizzleNV.VK_VIEWPORT_COORDINATE_SWIZZLE_NEGATIVE_Z_NV;

	public const VkViewportCoordinateSwizzleNV VK_VIEWPORT_COORDINATE_SWIZZLE_POSITIVE_W_NV = VkViewportCoordinateSwizzleNV.VK_VIEWPORT_COORDINATE_SWIZZLE_POSITIVE_W_NV;

	public const VkViewportCoordinateSwizzleNV VK_VIEWPORT_COORDINATE_SWIZZLE_NEGATIVE_W_NV = VkViewportCoordinateSwizzleNV.VK_VIEWPORT_COORDINATE_SWIZZLE_NEGATIVE_W_NV;

	public const VkDiscardRectangleModeEXT VK_DISCARD_RECTANGLE_MODE_INCLUSIVE_EXT = VkDiscardRectangleModeEXT.InclusiveEXT;

	public const VkDiscardRectangleModeEXT VK_DISCARD_RECTANGLE_MODE_EXCLUSIVE_EXT = VkDiscardRectangleModeEXT.ExclusiveEXT;

	public const VkSubpassDescriptionFlags VK_SUBPASS_DESCRIPTION_PER_VIEW_ATTRIBUTES_BIT_NVX = VkSubpassDescriptionFlags.PerViewAttributesNVX;

	public const VkSubpassDescriptionFlags VK_SUBPASS_DESCRIPTION_PER_VIEW_POSITION_X_ONLY_BIT_NVX = VkSubpassDescriptionFlags.PerViewPositionXOnlyNVX;

	public const VkPointClippingBehaviorKHR VK_POINT_CLIPPING_BEHAVIOR_ALL_CLIP_PLANES_KHR = VkPointClippingBehaviorKHR.AllClipPlanesKHR;

	public const VkPointClippingBehaviorKHR VK_POINT_CLIPPING_BEHAVIOR_USER_CLIP_PLANES_ONLY_KHR = VkPointClippingBehaviorKHR.UserClipPlanesOnlyKHR;

	public const VkSamplerReductionModeEXT VK_SAMPLER_REDUCTION_MODE_WEIGHTED_AVERAGE_EXT = VkSamplerReductionModeEXT.WeightedAverageEXT;

	public const VkSamplerReductionModeEXT VK_SAMPLER_REDUCTION_MODE_MIN_EXT = VkSamplerReductionModeEXT.MinEXT;

	public const VkSamplerReductionModeEXT VK_SAMPLER_REDUCTION_MODE_MAX_EXT = VkSamplerReductionModeEXT.MaxEXT;

	public const VkTessellationDomainOriginKHR VK_TESSELLATION_DOMAIN_ORIGIN_UPPER_LEFT_KHR = VkTessellationDomainOriginKHR.UpperLeftKHR;

	public const VkTessellationDomainOriginKHR VK_TESSELLATION_DOMAIN_ORIGIN_LOWER_LEFT_KHR = VkTessellationDomainOriginKHR.LowerLeftKHR;

	public const VkSamplerYcbcrModelConversionKHR VK_SAMPLER_YCBCR_MODEL_CONVERSION_RGB_IDENTITY_KHR = VkSamplerYcbcrModelConversionKHR.RgbIdentityKHR;

	public const VkSamplerYcbcrModelConversionKHR VK_SAMPLER_YCBCR_MODEL_CONVERSION_YCBCR_IDENTITY_KHR = VkSamplerYcbcrModelConversionKHR.YcbcrIdentityKHR;

	public const VkSamplerYcbcrModelConversionKHR VK_SAMPLER_YCBCR_MODEL_CONVERSION_YCBCR_709_KHR = VkSamplerYcbcrModelConversionKHR.Ycbcr709KHR;

	public const VkSamplerYcbcrModelConversionKHR VK_SAMPLER_YCBCR_MODEL_CONVERSION_YCBCR_601_KHR = VkSamplerYcbcrModelConversionKHR.Ycbcr601KHR;

	public const VkSamplerYcbcrModelConversionKHR VK_SAMPLER_YCBCR_MODEL_CONVERSION_YCBCR_2020_KHR = VkSamplerYcbcrModelConversionKHR.Ycbcr2020KHR;

	public const VkSamplerYcbcrRangeKHR VK_SAMPLER_YCBCR_RANGE_ITU_FULL_KHR = VkSamplerYcbcrRangeKHR.ItuFullKHR;

	public const VkSamplerYcbcrRangeKHR VK_SAMPLER_YCBCR_RANGE_ITU_NARROW_KHR = VkSamplerYcbcrRangeKHR.ItuNarrowKHR;

	public const VkChromaLocationKHR VK_CHROMA_LOCATION_COSITED_EVEN_KHR = VkChromaLocationKHR.CositedEvenKHR;

	public const VkChromaLocationKHR VK_CHROMA_LOCATION_MIDPOINT_KHR = VkChromaLocationKHR.MidpointKHR;

	public const VkBlendOverlapEXT VK_BLEND_OVERLAP_UNCORRELATED_EXT = VkBlendOverlapEXT.UncorrelatedEXT;

	public const VkBlendOverlapEXT VK_BLEND_OVERLAP_DISJOINT_EXT = VkBlendOverlapEXT.DisjointEXT;

	public const VkBlendOverlapEXT VK_BLEND_OVERLAP_CONJOINT_EXT = VkBlendOverlapEXT.ConjointEXT;

	public const VkCoverageModulationModeNV VK_COVERAGE_MODULATION_MODE_NONE_NV = VkCoverageModulationModeNV.VK_COVERAGE_MODULATION_MODE_NONE_NV;

	public const VkCoverageModulationModeNV VK_COVERAGE_MODULATION_MODE_RGB_NV = VkCoverageModulationModeNV.VK_COVERAGE_MODULATION_MODE_RGB_NV;

	public const VkCoverageModulationModeNV VK_COVERAGE_MODULATION_MODE_ALPHA_NV = VkCoverageModulationModeNV.VK_COVERAGE_MODULATION_MODE_ALPHA_NV;

	public const VkCoverageModulationModeNV VK_COVERAGE_MODULATION_MODE_RGBA_NV = VkCoverageModulationModeNV.VK_COVERAGE_MODULATION_MODE_RGBA_NV;

	public const VkValidationCacheHeaderVersionEXT VK_VALIDATION_CACHE_HEADER_VERSION_ONE_EXT = VkValidationCacheHeaderVersionEXT.OneEXT;

	public const VkShaderInfoTypeAMD VK_SHADER_INFO_TYPE_STATISTICS_AMD = VkShaderInfoTypeAMD.StatisticsAMD;

	public const VkShaderInfoTypeAMD VK_SHADER_INFO_TYPE_BINARY_AMD = VkShaderInfoTypeAMD.BinaryAMD;

	public const VkShaderInfoTypeAMD VK_SHADER_INFO_TYPE_DISASSEMBLY_AMD = VkShaderInfoTypeAMD.DisassemblyAMD;

	public const VkQueueGlobalPriorityEXT VK_QUEUE_GLOBAL_PRIORITY_LOW_EXT = VkQueueGlobalPriorityEXT.LowEXT;

	public const VkQueueGlobalPriorityEXT VK_QUEUE_GLOBAL_PRIORITY_MEDIUM_EXT = VkQueueGlobalPriorityEXT.MediumEXT;

	public const VkQueueGlobalPriorityEXT VK_QUEUE_GLOBAL_PRIORITY_HIGH_EXT = VkQueueGlobalPriorityEXT.HighEXT;

	public const VkQueueGlobalPriorityEXT VK_QUEUE_GLOBAL_PRIORITY_REALTIME_EXT = VkQueueGlobalPriorityEXT.RealtimeEXT;

	public const VkConservativeRasterizationModeEXT VK_CONSERVATIVE_RASTERIZATION_MODE_DISABLED_EXT = VkConservativeRasterizationModeEXT.DisabledEXT;

	public const VkConservativeRasterizationModeEXT VK_CONSERVATIVE_RASTERIZATION_MODE_OVERESTIMATE_EXT = VkConservativeRasterizationModeEXT.OverestimateEXT;

	public const VkConservativeRasterizationModeEXT VK_CONSERVATIVE_RASTERIZATION_MODE_UNDERESTIMATE_EXT = VkConservativeRasterizationModeEXT.UnderestimateEXT;
}
