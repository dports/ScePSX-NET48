using Khronos;

namespace OpenGL;

public enum VertexAttribType
{
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_EXT_render_snorm", Api = "gles2")]
	[RequiredByFeature("GL_OES_byte_coordinates", Api = "gl|gles1")]
	Byte = 5120,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	UnsignedByte = 5121,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_EXT_render_snorm", Api = "gles2")]
	Short = 5122,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ANGLE_depth_texture", Api = "gles2")]
	[RequiredByFeature("GL_OES_depth_texture", Api = "gles2")]
	UnsignedShort = 5123,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	Int = 5124,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ANGLE_depth_texture", Api = "gles2")]
	[RequiredByFeature("GL_OES_depth_texture", Api = "gles2")]
	[RequiredByFeature("GL_OES_element_index_uint", Api = "gles1|gles2")]
	UnsignedInt = 5125,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_vertex_shader")]
	[RequiredByFeature("GL_OES_texture_float", Api = "gles2")]
	Float = 5126,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_vertex_attrib_64bit")]
	Double = 5130,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_half_float_vertex", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_half_float_pixel")]
	[RequiredByFeature("GL_NV_half_float")]
	HalfFloat = 5131,
	[RequiredByFeature("GL_VERSION_4_1")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_ES2_compatibility", Api = "gl|glcore")]
	[RequiredByFeature("GL_OES_fixed_point", Api = "gl|gles1")]
	Fixed = 5132,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_vertex_type_2_10_10_10_rev", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_texture_type_2_10_10_10_REV", Api = "gles2")]
	UnsignedInt2101010Rev = 33640,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_VERSION_4_4")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_vertex_type_10f_11f_11f_rev", Api = "gl|glcore")]
	[RequiredByFeature("GL_APPLE_texture_packed_float", Api = "gles2")]
	[RequiredByFeature("GL_EXT_packed_float")]
	UnsignedInt10f11f11fRev = 35899,
	[RequiredByFeature("GL_VERSION_3_3")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_vertex_type_2_10_10_10_rev", Api = "gl|glcore")]
	Int2101010Rev = 36255
}
