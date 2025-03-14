using Khronos;

namespace OpenGL;

public enum VertexAttribIType
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
	UnsignedByte,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_EXT_render_snorm", Api = "gles2")]
	Short,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ANGLE_depth_texture", Api = "gles2")]
	[RequiredByFeature("GL_OES_depth_texture", Api = "gles2")]
	UnsignedShort,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	Int,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ANGLE_depth_texture", Api = "gles2")]
	[RequiredByFeature("GL_OES_depth_texture", Api = "gles2")]
	[RequiredByFeature("GL_OES_element_index_uint", Api = "gles1|gles2")]
	UnsignedInt
}
