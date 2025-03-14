using Khronos;

namespace OpenGL;

public enum PathTransformType
{
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_VERSION_4_6")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_KHR_context_flush_control", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_NV_register_combiners")]
	[RequiredByFeature("GL_OES_framebuffer_object", Api = "gles1")]
	None = 0,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	TranslateXNv = 37006,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	TranslateYNv = 37007,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	Translate2dNv = 37008,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	Translate3dNv = 37009,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	Affine2dNv = 37010,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	Affine3dNv = 37012,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	TransposeAffine2dNv = 37014,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	TransposeAffine3dNv = 37016
}
