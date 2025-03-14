using Khronos;

namespace OpenGL;

public enum TextureParameterName
{
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	TextureWidth = 4096,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	TextureHeight = 4097,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	TextureInternalFormat = 4099,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	TextureComponents = 4099,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_border_clamp", Api = "gles2")]
	[RequiredByFeature("GL_NV_texture_border_clamp", Api = "gles2")]
	[RequiredByFeature("GL_OES_texture_border_clamp", Api = "gles2")]
	TextureBorderColor = 4100,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	TextureBorder = 4101,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	TextureMagFilter = 10240,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	TextureMinFilter = 10241,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	TextureWrapS = 10242,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	TextureWrapT = 10243,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture")]
	TextureRedSize = 32860,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture")]
	TextureGreenSize = 32861,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture")]
	TextureBlueSize = 32862,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture")]
	TextureAlphaSize = 32863,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_EXT_texture")]
	[RemovedByFeature("GL_VERSION_3_2")]
	TextureLuminanceSize = 32864,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_EXT_texture")]
	[RemovedByFeature("GL_VERSION_3_2")]
	TextureIntensitySize = 32865,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_EXT_texture_object")]
	[RemovedByFeature("GL_VERSION_3_2")]
	TexturePriority = 32870,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_EXT_texture_object")]
	[RemovedByFeature("GL_VERSION_3_2")]
	TextureResident = 32871,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture3D")]
	TextureDepth = 32881,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture3D")]
	[RequiredByFeature("GL_OES_texture_3D", Api = "gles2")]
	TextureWrapR = 32882,
	[RequiredByFeature("GL_SGIS_detail_texture")]
	DetailTextureLevelSgis = 32922,
	[RequiredByFeature("GL_SGIS_detail_texture")]
	DetailTextureModeSgis = 32923,
	[RequiredByFeature("GL_SGIS_detail_texture")]
	DetailTextureFuncPointsSgis = 32924,
	[RequiredByFeature("GL_SGIS_sharpen_texture")]
	SharpenTextureFuncPointsSgis = 32944,
	[RequiredByFeature("GL_SGIX_shadow_ambient")]
	ShadowAmbientSgix = 32959,
	[RequiredByFeature("GL_SGIS_texture_select")]
	DualTextureSelectSgis = 33060,
	[RequiredByFeature("GL_SGIS_texture_select")]
	QuadTextureSelectSgis = 33061,
	[RequiredByFeature("GL_SGIS_texture4D")]
	Texture4dsizeSgis = 33078,
	[RequiredByFeature("GL_SGIS_texture4D")]
	TextureWrapQSgis = 33079,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_SGIS_texture_lod")]
	TextureMinLod = 33082,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_SGIS_texture_lod")]
	TextureMaxLod = 33083,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_SGIS_texture_lod")]
	TextureBaseLevel = 33084,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_APPLE_texture_max_level", Api = "gles1|gles2")]
	[RequiredByFeature("GL_SGIS_texture_lod")]
	TextureMaxLevel = 33085,
	[RequiredByFeature("GL_SGIS_texture_filter4")]
	TextureFilter4SizeSgis = 33095,
	[RequiredByFeature("GL_SGIX_clipmap")]
	TextureClipmapCenterSgix = 33137,
	[RequiredByFeature("GL_SGIX_clipmap")]
	TextureClipmapFrameSgix = 33138,
	[RequiredByFeature("GL_SGIX_clipmap")]
	TextureClipmapOffsetSgix = 33139,
	[RequiredByFeature("GL_SGIX_clipmap")]
	TextureClipmapVirtualDepthSgix = 33140,
	[RequiredByFeature("GL_SGIX_clipmap")]
	TextureClipmapLodOffsetSgix = 33141,
	[RequiredByFeature("GL_SGIX_clipmap")]
	TextureClipmapDepthSgix = 33142,
	[RequiredByFeature("GL_SGIX_texture_scale_bias")]
	PostTextureFilterBiasSgix = 33145,
	[RequiredByFeature("GL_SGIX_texture_scale_bias")]
	PostTextureFilterScaleSgix = 33146,
	[RequiredByFeature("GL_SGIX_texture_lod_bias")]
	TextureLodBiasSSgix = 33166,
	[RequiredByFeature("GL_SGIX_texture_lod_bias")]
	TextureLodBiasTSgix = 33167,
	[RequiredByFeature("GL_SGIX_texture_lod_bias")]
	TextureLodBiasRSgix = 33168,
	[RequiredByFeature("GL_VERSION_1_4")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_SGIS_generate_mipmap")]
	[RemovedByFeature("GL_VERSION_3_2")]
	GenerateMipmap = 33169,
	[RequiredByFeature("GL_SGIX_shadow")]
	TextureCompareSgix = 33178,
	[RequiredByFeature("GL_SGIX_shadow")]
	TextureCompareOperatorSgix = 33179,
	[RequiredByFeature("GL_SGIX_shadow")]
	TextureLequalRSgix = 33180,
	[RequiredByFeature("GL_SGIX_shadow")]
	TextureGequalRSgix = 33181,
	[RequiredByFeature("GL_SGIX_texture_coordinate_clamp")]
	TextureMaxClampSSgix = 33641,
	[RequiredByFeature("GL_SGIX_texture_coordinate_clamp")]
	TextureMaxClampTSgix = 33642,
	[RequiredByFeature("GL_SGIX_texture_coordinate_clamp")]
	TextureMaxClampRSgix = 33643,
	[RequiredByFeature("GL_INTEL_map_texture")]
	TextureMemoryLayoutIntel = 33791,
	[RequiredByFeature("GL_VERSION_4_6")]
	[RequiredByFeature("GL_ARB_texture_filter_anisotropic", Api = "gl|glcore")]
	TextureMaxAnisotropy = 34046,
	[RequiredByFeature("GL_VERSION_1_4")]
	[RequiredByFeature("GL_EXT_texture_lod_bias", Api = "gl|gles1")]
	TextureLodBias = 34049,
	[RequiredByFeature("GL_VERSION_1_4")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shadow")]
	[RequiredByFeature("GL_EXT_shadow_samplers", Api = "gles2")]
	TextureCompareMode = 34892,
	[RequiredByFeature("GL_VERSION_1_4")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shadow")]
	[RequiredByFeature("GL_EXT_shadow_samplers", Api = "gles2")]
	TextureCompareFunc = 34893,
	[RequiredByFeature("GL_VERSION_3_3")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_swizzle", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_texture_swizzle")]
	TextureSwizzleR = 36418,
	[RequiredByFeature("GL_VERSION_3_3")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_swizzle", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_texture_swizzle")]
	TextureSwizzleG = 36419,
	[RequiredByFeature("GL_VERSION_3_3")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_swizzle", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_texture_swizzle")]
	TextureSwizzleB = 36420,
	[RequiredByFeature("GL_VERSION_3_3")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_swizzle", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_texture_swizzle")]
	TextureSwizzleA = 36421,
	[RequiredByFeature("GL_VERSION_3_3")]
	[RequiredByFeature("GL_ARB_texture_swizzle", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_texture_swizzle")]
	TextureSwizzleRgba = 36422,
	[RequiredByFeature("GL_ARM_texture_unnormalized_coordinates", Api = "gles2")]
	TextureUnnormalizedCoordinatesArm = 36714,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_stencil_texturing", Api = "gl|glcore")]
	DepthStencilTextureMode = 37098,
	[RequiredByFeature("GL_EXT_memory_object", Api = "gl|gles2")]
	TextureTilingExt = 38272,
	[RequiredByFeature("GL_QCOM_texture_foveated2", Api = "gles2")]
	TextureFoveatedCutoffDensityQcom = 38560
}
