using Khronos;

namespace OpenGL;

public enum TextureEnvMode
{
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Add = 260,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_EXT_draw_buffers_indexed", Api = "gles2")]
	[RequiredByFeature("GL_OES_draw_buffers_indexed", Api = "gles2")]
	Blend = 3042,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Modulate = 8448,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Decal = 8449,
	[RequiredByFeature("GL_EXT_texture")]
	ReplaceExt = 32866,
	[RequiredByFeature("GL_SGIX_texture_add_env")]
	TextureEnvBiasSgix = 32958
}
