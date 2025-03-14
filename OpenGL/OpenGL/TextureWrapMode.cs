using Khronos;

namespace OpenGL;

public enum TextureWrapMode
{
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	LinearMipmapLinear = 9987,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Clamp = 10496,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	Repeat = 10497,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_border_clamp", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_texture_border_clamp", Api = "gles2")]
	[RequiredByFeature("GL_NV_texture_border_clamp", Api = "gles2")]
	[RequiredByFeature("GL_SGIS_texture_border_clamp")]
	[RequiredByFeature("GL_OES_texture_border_clamp", Api = "gles2")]
	ClampToBorder = 33069,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_SGIS_texture_edge_clamp")]
	ClampToEdge = 33071,
	[RequiredByFeature("GL_VERSION_1_4")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_texture_mirrored_repeat", Api = "gl|glcore")]
	[RequiredByFeature("GL_IBM_texture_mirrored_repeat")]
	[RequiredByFeature("GL_OES_texture_mirrored_repeat", Api = "gles1")]
	MirroredRepeat = 33648
}
