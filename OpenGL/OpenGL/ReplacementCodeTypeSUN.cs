using Khronos;

namespace OpenGL;

public enum ReplacementCodeTypeSUN
{
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	UnsignedByte = 5121,
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
	[RequiredByFeature("GL_ANGLE_depth_texture", Api = "gles2")]
	[RequiredByFeature("GL_OES_depth_texture", Api = "gles2")]
	[RequiredByFeature("GL_OES_element_index_uint", Api = "gles1|gles2")]
	UnsignedInt = 5125
}
