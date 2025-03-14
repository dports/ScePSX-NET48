using System;
using Khronos;

namespace OpenGL;

[Flags]
public enum SizedInternalFormat : uint
{
	[RequiredByFeature("GL_VERSION_1_1")]
	R3G3B2 = 0x2A10u,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_EXT_texture")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Alpha4 = 0x803Bu,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_EXT_texture")]
	[RequiredByFeature("GL_EXT_texture_storage", Api = "gles1|gles2|gl|glcore")]
	[RequiredByFeature("GL_OES_required_internalformat", Api = "gles1|gles2")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Alpha8 = 0x803Cu,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_EXT_texture")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Alpha12 = 0x803Du,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_EXT_texture")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Alpha16 = 0x803Eu,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_EXT_texture")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Luminance4 = 0x803Fu,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_EXT_texture")]
	[RequiredByFeature("GL_EXT_texture_storage", Api = "gles1|gles2|gl|glcore")]
	[RequiredByFeature("GL_OES_required_internalformat", Api = "gles1|gles2")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Luminance8 = 0x8040u,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_EXT_texture")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Luminance12 = 0x8041u,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_EXT_texture")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Luminance16 = 0x8042u,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_EXT_texture")]
	[RequiredByFeature("GL_OES_required_internalformat", Api = "gles1|gles2")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Luminance4Alpha4 = 0x8043u,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_EXT_texture")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Luminance6Alpha2 = 0x8044u,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_EXT_texture")]
	[RequiredByFeature("GL_EXT_texture_storage", Api = "gles1|gles2|gl|glcore")]
	[RequiredByFeature("GL_OES_required_internalformat", Api = "gles1|gles2")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Luminance8Alpha8 = 0x8045u,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_EXT_texture")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Luminance12Alpha4 = 0x8046u,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_EXT_texture")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Luminance12Alpha12 = 0x8047u,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_EXT_texture")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Luminance16Alpha16 = 0x8048u,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_EXT_texture")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Intensity4 = 0x804Au,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_EXT_texture")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Intensity8 = 0x804Bu,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_EXT_texture")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Intensity12 = 0x804Cu,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_EXT_texture")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Intensity16 = 0x804Du,
	[RequiredByFeature("GL_EXT_texture")]
	Rgb2Ext = 0x804Eu,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_EXT_texture")]
	Rgb4 = 0x804Fu,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_EXT_texture")]
	Rgb5 = 0x8050u,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_EXT_texture")]
	[RequiredByFeature("GL_OES_required_internalformat", Api = "gles1|gles2")]
	[RequiredByFeature("GL_OES_rgb8_rgba8", Api = "gles1|gles2|glsc2")]
	Rgb8 = 0x8051u,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_EXT_texture")]
	[RequiredByFeature("GL_EXT_texture_storage", Api = "gles1|gles2|gl|glcore")]
	[RequiredByFeature("GL_OES_required_internalformat", Api = "gles1|gles2")]
	Rgb10 = 0x8052u,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_EXT_texture")]
	Rgb12 = 0x8053u,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_EXT_texture")]
	[RequiredByFeature("GL_EXT_texture_norm16", Api = "gles2")]
	Rgb16 = 0x8054u,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_EXT_texture")]
	Rgba2 = 0x8055u,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_EXT_texture")]
	[RequiredByFeature("GL_OES_framebuffer_object", Api = "gles1")]
	[RequiredByFeature("GL_OES_required_internalformat", Api = "gles1|gles2")]
	Rgba4 = 0x8056u,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_EXT_texture")]
	[RequiredByFeature("GL_OES_framebuffer_object", Api = "gles1")]
	[RequiredByFeature("GL_OES_required_internalformat", Api = "gles1|gles2")]
	Rgb5A1 = 0x8057u,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_EXT_texture")]
	[RequiredByFeature("GL_OES_required_internalformat", Api = "gles1|gles2")]
	[RequiredByFeature("GL_OES_rgb8_rgba8", Api = "gles1|gles2|glsc2")]
	Rgba8 = 0x8058u,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture")]
	[RequiredByFeature("GL_EXT_texture_storage", Api = "gles1|gles2|gl|glcore")]
	[RequiredByFeature("GL_OES_required_internalformat", Api = "gles1|gles2")]
	Rgb10A2 = 0x8059u,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_EXT_texture")]
	Rgba12 = 0x805Au,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_EXT_texture")]
	[RequiredByFeature("GL_EXT_texture_norm16", Api = "gles2")]
	Rgba16 = 0x805Bu,
	[RequiredByFeature("GL_VERSION_1_4")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ANGLE_depth_texture", Api = "gles2")]
	[RequiredByFeature("GL_ARB_depth_texture")]
	[RequiredByFeature("GL_OES_framebuffer_object", Api = "gles1")]
	[RequiredByFeature("GL_OES_required_internalformat", Api = "gles1|gles2")]
	[RequiredByFeature("GL_SGIX_depth_texture")]
	DepthComponent16 = 0x81A5u,
	[RequiredByFeature("GL_VERSION_1_4")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_depth_texture")]
	[RequiredByFeature("GL_OES_depth24", Api = "gles1|gles2|glsc2")]
	[RequiredByFeature("GL_OES_required_internalformat", Api = "gles1|gles2")]
	[RequiredByFeature("GL_SGIX_depth_texture")]
	DepthComponent24 = 0x81A6u,
	[RequiredByFeature("GL_VERSION_1_4")]
	[RequiredByFeature("GL_ARB_depth_texture")]
	[RequiredByFeature("GL_ANGLE_depth_texture", Api = "gles2")]
	[RequiredByFeature("GL_OES_depth32", Api = "gles1|gles2|glsc2")]
	[RequiredByFeature("GL_OES_required_internalformat", Api = "gles1|gles2")]
	[RequiredByFeature("GL_SGIX_depth_texture")]
	DepthComponent32 = 0x81A7u,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_texture_rg", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_texture_rg", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_storage", Api = "gles1|gles2|gl|glcore")]
	R8 = 0x8229u,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ARB_texture_rg", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_texture_norm16", Api = "gles2")]
	R16 = 0x822Au,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_texture_rg", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_texture_rg", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_storage", Api = "gles1|gles2|gl|glcore")]
	Rg8 = 0x822Bu,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ARB_texture_rg", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_texture_norm16", Api = "gles2")]
	Rg16 = 0x822Cu,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_rg", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_color_buffer_half_float", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_storage", Api = "gles1|gles2|gl|glcore")]
	R16f = 0x822Du,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_rg", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_texture_storage", Api = "gles1|gles2|gl|glcore")]
	R32f = 0x822Eu,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_rg", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_color_buffer_half_float", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_storage", Api = "gles1|gles2|gl|glcore")]
	Rg16f = 0x822Fu,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_rg", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_texture_storage", Api = "gles1|gles2|gl|glcore")]
	Rg32f = 0x8230u,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_rg", Api = "gl|glcore")]
	R8i = 0x8231u,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_rg", Api = "gl|glcore")]
	R8ui = 0x8232u,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_rg", Api = "gl|glcore")]
	R16i = 0x8233u,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_rg", Api = "gl|glcore")]
	R16ui = 0x8234u,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_rg", Api = "gl|glcore")]
	R32i = 0x8235u,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_rg", Api = "gl|glcore")]
	R32ui = 0x8236u,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_rg", Api = "gl|glcore")]
	Rg8i = 0x8237u,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_AMD_interleaved_elements")]
	[RequiredByFeature("GL_ARB_texture_rg", Api = "gl|glcore")]
	Rg8ui = 0x8238u,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_rg", Api = "gl|glcore")]
	Rg16i = 0x8239u,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_AMD_interleaved_elements")]
	[RequiredByFeature("GL_ARB_texture_rg", Api = "gl|glcore")]
	Rg16ui = 0x823Au,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_rg", Api = "gl|glcore")]
	Rg32i = 0x823Bu,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_rg", Api = "gl|glcore")]
	Rg32ui = 0x823Cu,
	[RequiredByFeature("GL_EXT_texture_compression_dxt1", Api = "gles1|gles2")]
	[RequiredByFeature("GL_EXT_texture_compression_s3tc", Api = "gl|glcore|gles2|glsc2")]
	CompressedRgbS3tcDxt1Ext = 0x83F0u,
	[RequiredByFeature("GL_EXT_texture_compression_dxt1", Api = "gles1|gles2")]
	[RequiredByFeature("GL_EXT_texture_compression_s3tc", Api = "gl|glcore|gles2|glsc2")]
	CompressedRgbaS3tcDxt1Ext = 0x83F1u,
	[RequiredByFeature("GL_EXT_texture_compression_s3tc", Api = "gl|glcore|gles2|glsc2")]
	[RequiredByFeature("GL_ANGLE_texture_compression_dxt3", Api = "gles2")]
	CompressedRgbaS3tcDxt3Ext = 0x83F2u,
	[RequiredByFeature("GL_EXT_texture_compression_s3tc", Api = "gl|glcore|gles2|glsc2")]
	[RequiredByFeature("GL_ANGLE_texture_compression_dxt5", Api = "gles2")]
	CompressedRgbaS3tcDxt5Ext = 0x83F3u,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_float")]
	[RequiredByFeature("GL_EXT_texture_storage", Api = "gles1|gles2|gl|glcore")]
	Rgba32f = 0x8814u,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_buffer_object_rgb32", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_texture_float")]
	[RequiredByFeature("GL_EXT_texture_storage", Api = "gles1|gles2|gl|glcore")]
	Rgb32f = 0x8815u,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_float")]
	[RequiredByFeature("GL_EXT_color_buffer_half_float", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_storage", Api = "gles1|gles2|gl|glcore")]
	Rgba16f = 0x881Au,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_float")]
	[RequiredByFeature("GL_EXT_color_buffer_half_float", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_storage", Api = "gles1|gles2|gl|glcore")]
	Rgb16f = 0x881Bu,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_packed_depth_stencil")]
	[RequiredByFeature("GL_ANGLE_depth_texture", Api = "gles2")]
	[RequiredByFeature("GL_OES_packed_depth_stencil", Api = "gles1|gles2")]
	[RequiredByFeature("GL_OES_required_internalformat", Api = "gles1|gles2")]
	Depth24Stencil8 = 0x88F0u,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_APPLE_texture_packed_float", Api = "gles2")]
	[RequiredByFeature("GL_EXT_packed_float")]
	R11fG11fB10f = 0x8C3Au,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_APPLE_texture_packed_float", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_shared_exponent")]
	Rgb9E5 = 0x8C3Du,
	[RequiredByFeature("GL_VERSION_2_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_sRGB")]
	[RequiredByFeature("GL_NV_sRGB_formats", Api = "gles2")]
	Srgb8 = 0x8C41u,
	[RequiredByFeature("GL_VERSION_2_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_sRGB", Api = "gles1|gles2")]
	[RequiredByFeature("GL_EXT_texture_sRGB")]
	Srgb8Alpha8 = 0x8C43u,
	[RequiredByFeature("GL_EXT_texture_compression_s3tc_srgb", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_sRGB")]
	[RequiredByFeature("GL_NV_sRGB_formats", Api = "gles2")]
	CompressedSrgbS3tcDxt1Ext = 0x8C4Cu,
	[RequiredByFeature("GL_EXT_texture_compression_s3tc_srgb", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_sRGB")]
	[RequiredByFeature("GL_NV_sRGB_formats", Api = "gles2")]
	CompressedSrgbAlphaS3tcDxt1Ext = 0x8C4Du,
	[RequiredByFeature("GL_EXT_texture_compression_s3tc_srgb", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_sRGB")]
	[RequiredByFeature("GL_NV_sRGB_formats", Api = "gles2")]
	CompressedSrgbAlphaS3tcDxt3Ext = 0x8C4Eu,
	[RequiredByFeature("GL_EXT_texture_compression_s3tc_srgb", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_sRGB")]
	[RequiredByFeature("GL_NV_sRGB_formats", Api = "gles2")]
	CompressedSrgbAlphaS3tcDxt5Ext = 0x8C4Fu,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_depth_buffer_float", Api = "gl|glcore")]
	DepthComponent32f = 0x8CACu,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_depth_buffer_float", Api = "gl|glcore")]
	Depth32fStencil8 = 0x8CADu,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	[RequiredByFeature("GL_OES_stencil1", Api = "gles1|gles2")]
	StencilIndex1 = 0x8D46u,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	[RequiredByFeature("GL_OES_stencil4", Api = "gles1|gles2")]
	StencilIndex4 = 0x8D47u,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_VERSION_4_4")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_texture_stencil8", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	[RequiredByFeature("GL_OES_stencil8", Api = "gles1")]
	[RequiredByFeature("GL_OES_texture_stencil8", Api = "gles2")]
	StencilIndex8 = 0x8D48u,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	StencilIndex16 = 0x8D49u,
	[RequiredByFeature("GL_VERSION_4_1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_ES2_compatibility", Api = "gl|glcore")]
	[RequiredByFeature("GL_OES_framebuffer_object", Api = "gles1")]
	[RequiredByFeature("GL_OES_required_internalformat", Api = "gles1|gles2")]
	Rgb565 = 0x8D62u,
	[RequiredByFeature("GL_OES_compressed_ETC1_RGB8_texture", Api = "gles1|gles2")]
	Etc1Rgb8Oes = 0x8D64u,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_integer")]
	Rgba32ui = 0x8D70u,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_buffer_object_rgb32", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_texture_integer")]
	Rgb32ui = 0x8D71u,
	[RequiredByFeature("GL_EXT_texture_integer")]
	Alpha32uiExt = 0x8D72u,
	[RequiredByFeature("GL_EXT_texture_integer")]
	Intensity32uiExt = 0x8D73u,
	[RequiredByFeature("GL_EXT_texture_integer")]
	Luminance32uiExt = 0x8D74u,
	[RequiredByFeature("GL_EXT_texture_integer")]
	LuminanceAlpha32uiExt = 0x8D75u,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_integer")]
	Rgba16ui = 0x8D76u,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_integer")]
	Rgb16ui = 0x8D77u,
	[RequiredByFeature("GL_EXT_texture_integer")]
	Alpha16uiExt = 0x8D78u,
	[RequiredByFeature("GL_EXT_texture_integer")]
	Intensity16uiExt = 0x8D79u,
	[RequiredByFeature("GL_EXT_texture_integer")]
	Luminance16uiExt = 0x8D7Au,
	[RequiredByFeature("GL_EXT_texture_integer")]
	LuminanceAlpha16uiExt = 0x8D7Bu,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_AMD_interleaved_elements")]
	[RequiredByFeature("GL_EXT_texture_integer")]
	Rgba8ui = 0x8D7Cu,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_integer")]
	Rgb8ui = 0x8D7Du,
	[RequiredByFeature("GL_EXT_texture_integer")]
	Alpha8uiExt = 0x8D7Eu,
	[RequiredByFeature("GL_EXT_texture_integer")]
	Intensity8uiExt = 0x8D7Fu,
	[RequiredByFeature("GL_EXT_texture_integer")]
	Luminance8uiExt = 0x8D80u,
	[RequiredByFeature("GL_EXT_texture_integer")]
	LuminanceAlpha8uiExt = 0x8D81u,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_integer")]
	Rgba32i = 0x8D82u,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_buffer_object_rgb32", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_vertex_attrib_64bit", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_texture_integer")]
	Rgb32i = 0x8D83u,
	[RequiredByFeature("GL_EXT_texture_integer")]
	Alpha32iExt = 0x8D84u,
	[RequiredByFeature("GL_EXT_texture_integer")]
	Intensity32iExt = 0x8D85u,
	[RequiredByFeature("GL_EXT_texture_integer")]
	Luminance32iExt = 0x8D86u,
	[RequiredByFeature("GL_EXT_texture_integer")]
	LuminanceAlpha32iExt = 0x8D87u,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_integer")]
	Rgba16i = 0x8D88u,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_integer")]
	Rgb16i = 0x8D89u,
	[RequiredByFeature("GL_EXT_texture_integer")]
	Alpha16iExt = 0x8D8Au,
	[RequiredByFeature("GL_EXT_texture_integer")]
	Intensity16iExt = 0x8D8Bu,
	[RequiredByFeature("GL_EXT_texture_integer")]
	Luminance16iExt = 0x8D8Cu,
	[RequiredByFeature("GL_EXT_texture_integer")]
	LuminanceAlpha16iExt = 0x8D8Du,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_integer")]
	Rgba8i = 0x8D8Eu,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_integer")]
	Rgb8i = 0x8D8Fu,
	[RequiredByFeature("GL_EXT_texture_integer")]
	Alpha8iExt = 0x8D90u,
	[RequiredByFeature("GL_EXT_texture_integer")]
	Intensity8iExt = 0x8D91u,
	[RequiredByFeature("GL_EXT_texture_integer")]
	Luminance8iExt = 0x8D92u,
	[RequiredByFeature("GL_EXT_texture_integer")]
	LuminanceAlpha8iExt = 0x8D93u,
	[RequiredByFeature("GL_NV_depth_buffer_float", Api = "gl|glcore")]
	DepthComponent32fNv = 0x8DABu,
	[RequiredByFeature("GL_NV_depth_buffer_float", Api = "gl|glcore")]
	Depth32fStencil8Nv = 0x8DACu,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ARB_texture_compression_rgtc", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_texture_compression_rgtc", Api = "gl|gles2")]
	CompressedRedRgtc1 = 0x8DBBu,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ARB_texture_compression_rgtc", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_texture_compression_rgtc", Api = "gl|gles2")]
	CompressedSignedRedRgtc1 = 0x8DBCu,
	[RequiredByFeature("GL_EXT_texture_compression_rgtc", Api = "gl|gles2")]
	CompressedRedGreenRgtc2Ext = 0x8DBDu,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ARB_texture_compression_rgtc", Api = "gl|glcore")]
	CompressedRgRgtc2 = 0x8DBDu,
	[RequiredByFeature("GL_EXT_texture_compression_rgtc", Api = "gl|gles2")]
	CompressedSignedRedGreenRgtc2Ext = 0x8DBEu,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ARB_texture_compression_rgtc", Api = "gl|glcore")]
	CompressedSignedRgRgtc2 = 0x8DBEu,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ARB_texture_compression_bptc", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_texture_compression_bptc", Api = "gles2")]
	CompressedRgbaBptcUnorm = 0x8E8Cu,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ARB_texture_compression_bptc", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_texture_compression_bptc", Api = "gles2")]
	CompressedSrgbAlphaBptcUnorm = 0x8E8Du,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ARB_texture_compression_bptc", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_texture_compression_bptc", Api = "gles2")]
	CompressedRgbBptcSignedFloat = 0x8E8Eu,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ARB_texture_compression_bptc", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_texture_compression_bptc", Api = "gles2")]
	CompressedRgbBptcUnsignedFloat = 0x8E8Fu,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_render_snorm", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_snorm")]
	R8Snorm = 0x8F94u,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_render_snorm", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_snorm")]
	Rg8Snorm = 0x8F95u,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_snorm")]
	Rgb8Snorm = 0x8F96u,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_render_snorm", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_snorm")]
	Rgba8Snorm = 0x8F97u,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_EXT_texture_snorm")]
	[RequiredByFeature("GL_EXT_render_snorm", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_norm16", Api = "gles2")]
	R16Snorm = 0x8F98u,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_EXT_texture_snorm")]
	[RequiredByFeature("GL_EXT_render_snorm", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_norm16", Api = "gles2")]
	Rg16Snorm = 0x8F99u,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_EXT_texture_snorm")]
	[RequiredByFeature("GL_EXT_texture_norm16", Api = "gles2")]
	Rgb16Snorm = 0x8F9Au,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_EXT_texture_snorm")]
	[RequiredByFeature("GL_EXT_render_snorm", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_norm16", Api = "gles2")]
	Rgba16Snorm = 0x8F9Bu,
	[RequiredByFeature("GL_VERSION_3_3")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_rgb10_a2ui", Api = "gl|glcore")]
	Rgb10A2ui = 0x906Fu,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_ES3_compatibility", Api = "gl|glcore")]
	CompressedR11Eac = 0x9270u,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_ES3_compatibility", Api = "gl|glcore")]
	CompressedSignedR11Eac = 0x9271u,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_ES3_compatibility", Api = "gl|glcore")]
	CompressedRg11Eac = 0x9272u,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_ES3_compatibility", Api = "gl|glcore")]
	CompressedSignedRg11Eac = 0x9273u,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_ES3_compatibility", Api = "gl|glcore")]
	CompressedRgb8Etc2 = 0x9274u,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_ES3_compatibility", Api = "gl|glcore")]
	CompressedSrgb8Etc2 = 0x9275u,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_ES3_compatibility", Api = "gl|glcore")]
	CompressedRgb8PunchthroughAlpha1Etc2 = 0x9276u,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_ES3_compatibility", Api = "gl|glcore")]
	CompressedSrgb8PunchthroughAlpha1Etc2 = 0x9277u,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_ES3_compatibility", Api = "gl|glcore")]
	CompressedRgba8Etc2Eac = 0x9278u,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_ES3_compatibility", Api = "gl|glcore")]
	CompressedSrgb8Alpha8Etc2Eac = 0x9279u,
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_hdr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_ldr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedRgbaAstc4x4 = 0x93B0u,
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_hdr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_ldr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedRgbaAstc5x4 = 0x93B1u,
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_hdr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_ldr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedRgbaAstc5x5 = 0x93B2u,
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_hdr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_ldr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedRgbaAstc6x5 = 0x93B3u,
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_hdr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_ldr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedRgbaAstc6x6 = 0x93B4u,
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_hdr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_ldr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedRgbaAstc8x5 = 0x93B5u,
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_hdr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_ldr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedRgbaAstc8x6 = 0x93B6u,
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_hdr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_ldr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedRgbaAstc8x8 = 0x93B7u,
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_hdr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_ldr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedRgbaAstc10x5 = 0x93B8u,
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_hdr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_ldr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedRgbaAstc10x6 = 0x93B9u,
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_hdr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_ldr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedRgbaAstc10x8 = 0x93BAu,
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_hdr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_ldr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedRgbaAstc10x10 = 0x93BBu,
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_hdr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_ldr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedRgbaAstc12x10 = 0x93BCu,
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_hdr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_ldr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedRgbaAstc12x12 = 0x93BDu,
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedRgbaAstc3x3x3Oes = 0x93C0u,
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedRgbaAstc4x3x3Oes = 0x93C1u,
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedRgbaAstc4x4x3Oes = 0x93C2u,
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedRgbaAstc4x4x4Oes = 0x93C3u,
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedRgbaAstc5x4x4Oes = 0x93C4u,
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedRgbaAstc5x5x4Oes = 0x93C5u,
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedRgbaAstc5x5x5Oes = 0x93C6u,
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedRgbaAstc6x5x5Oes = 0x93C7u,
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedRgbaAstc6x6x5Oes = 0x93C8u,
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedRgbaAstc6x6x6Oes = 0x93C9u,
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_hdr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_ldr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedSrgb8Alpha8Astc4x4 = 0x93D0u,
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_hdr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_ldr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedSrgb8Alpha8Astc5x4 = 0x93D1u,
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_hdr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_ldr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedSrgb8Alpha8Astc5x5 = 0x93D2u,
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_hdr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_ldr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedSrgb8Alpha8Astc6x5 = 0x93D3u,
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_hdr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_ldr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedSrgb8Alpha8Astc6x6 = 0x93D4u,
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_hdr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_ldr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedSrgb8Alpha8Astc8x5 = 0x93D5u,
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_hdr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_ldr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedSrgb8Alpha8Astc8x6 = 0x93D6u,
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_hdr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_ldr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedSrgb8Alpha8Astc8x8 = 0x93D7u,
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_hdr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_ldr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedSrgb8Alpha8Astc10x5 = 0x93D8u,
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_hdr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_ldr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedSrgb8Alpha8Astc10x6 = 0x93D9u,
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_hdr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_ldr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedSrgb8Alpha8Astc10x8 = 0x93DAu,
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_hdr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_ldr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedSrgb8Alpha8Astc10x10 = 0x93DBu,
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_hdr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_ldr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedSrgb8Alpha8Astc12x10 = 0x93DCu,
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_hdr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_KHR_texture_compression_astc_ldr", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedSrgb8Alpha8Astc12x12 = 0x93DDu,
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedSrgb8Alpha8Astc3x3x3Oes = 0x93E0u,
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedSrgb8Alpha8Astc4x3x3Oes = 0x93E1u,
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedSrgb8Alpha8Astc4x4x3Oes = 0x93E2u,
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedSrgb8Alpha8Astc4x4x4Oes = 0x93E3u,
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedSrgb8Alpha8Astc5x4x4Oes = 0x93E4u,
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedSrgb8Alpha8Astc5x5x4Oes = 0x93E5u,
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedSrgb8Alpha8Astc5x5x5Oes = 0x93E6u,
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedSrgb8Alpha8Astc6x5x5Oes = 0x93E7u,
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedSrgb8Alpha8Astc6x6x5Oes = 0x93E8u,
	[RequiredByFeature("GL_OES_texture_compression_astc", Api = "gles2")]
	CompressedSrgb8Alpha8Astc6x6x6Oes = 0x93E9u
}
