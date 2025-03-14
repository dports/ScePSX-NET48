using System;
using Khronos;

namespace OpenGL;

[Flags]
public enum PixelType : uint
{
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_EXT_render_snorm", Api = "gles2")]
	[RequiredByFeature("GL_OES_byte_coordinates", Api = "gl|gles1")]
	Byte = 0x1400u,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	UnsignedByte = 0x1401u,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_EXT_render_snorm", Api = "gles2")]
	Short = 0x1402u,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ANGLE_depth_texture", Api = "gles2")]
	[RequiredByFeature("GL_OES_depth_texture", Api = "gles2")]
	UnsignedShort = 0x1403u,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	Int = 0x1404u,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ANGLE_depth_texture", Api = "gles2")]
	[RequiredByFeature("GL_OES_depth_texture", Api = "gles2")]
	[RequiredByFeature("GL_OES_element_index_uint", Api = "gles1|gles2")]
	UnsignedInt = 0x1405u,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_vertex_shader")]
	[RequiredByFeature("GL_OES_texture_float", Api = "gles2")]
	Float = 0x1406u,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_half_float_vertex", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_half_float_pixel")]
	[RequiredByFeature("GL_NV_half_float")]
	HalfFloat = 0x140Bu,
	[RequiredByFeature("GL_APPLE_float_pixels")]
	HalfApple = 0x140Bu,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Bitmap = 0x1A00u,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_EXT_packed_pixels")]
	UnsignedByte332 = 0x8032u,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_EXT_packed_pixels")]
	UnsignedShort4444 = 0x8033u,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_EXT_packed_pixels")]
	UnsignedShort5551 = 0x8034u,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_EXT_packed_pixels")]
	UnsignedInt8888 = 0x8035u,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_EXT_packed_pixels")]
	UnsignedInt1010102 = 0x8036u,
	[RequiredByFeature("GL_VERSION_1_2")]
	UnsignedByte233Rev = 0x8362u,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	UnsignedShort565 = 0x8363u,
	[RequiredByFeature("GL_VERSION_1_2")]
	UnsignedShort565Rev = 0x8364u,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_EXT_read_format_bgra", Api = "gles1|gles2")]
	[RequiredByFeature("GL_IMG_read_format", Api = "gles1|gles2")]
	UnsignedShort4444Rev = 0x8365u,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_EXT_read_format_bgra", Api = "gles1|gles2")]
	UnsignedShort1555Rev = 0x8366u,
	[RequiredByFeature("GL_VERSION_1_2")]
	UnsignedInt8888Rev = 0x8367u,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_vertex_type_2_10_10_10_rev", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_texture_type_2_10_10_10_REV", Api = "gles2")]
	UnsignedInt2101010Rev = 0x8368u,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_packed_depth_stencil")]
	[RequiredByFeature("GL_NV_packed_depth_stencil")]
	[RequiredByFeature("GL_ANGLE_depth_texture", Api = "gles2")]
	[RequiredByFeature("GL_OES_packed_depth_stencil", Api = "gles1|gles2")]
	UnsignedInt248 = 0x84FAu,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_VERSION_4_4")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_vertex_type_10f_11f_11f_rev", Api = "gl|glcore")]
	[RequiredByFeature("GL_APPLE_texture_packed_float", Api = "gles2")]
	[RequiredByFeature("GL_EXT_packed_float")]
	UnsignedInt10f11f11fRev = 0x8C3Bu,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_APPLE_texture_packed_float", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_shared_exponent")]
	UnsignedInt5999Rev = 0x8C3Eu,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_depth_buffer_float", Api = "gl|glcore")]
	[RequiredByFeature("GL_NV_depth_buffer_float", Api = "gl|glcore")]
	Float32UnsignedInt248Rev = 0x8DADu,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_vertex_attrib_64bit")]
	Double = 0x140Au
}
