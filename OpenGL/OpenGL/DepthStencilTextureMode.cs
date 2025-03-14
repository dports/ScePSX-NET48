using Khronos;

namespace OpenGL;

public enum DepthStencilTextureMode
{
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_4_4")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_stencil8", Api = "gl|glcore")]
	[RequiredByFeature("GL_OES_texture_stencil8", Api = "gles2")]
	StencilIndex = 6401,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_ANGLE_depth_texture", Api = "gles2")]
	[RequiredByFeature("GL_OES_depth_texture", Api = "gles2")]
	DepthComponent
}
