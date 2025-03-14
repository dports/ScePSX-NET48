using Khronos;

namespace OpenGL;

public enum ConditionalRenderMode
{
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_NV_conditional_render", Api = "gl|glcore|gles2")]
	QueryWait = 36371,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_NV_conditional_render", Api = "gl|glcore|gles2")]
	QueryNoWait,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_NV_conditional_render", Api = "gl|glcore|gles2")]
	QueryByRegionWait,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_NV_conditional_render", Api = "gl|glcore|gles2")]
	QueryByRegionNoWait,
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ARB_conditional_render_inverted", Api = "gl|glcore")]
	QueryWaitInverted,
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ARB_conditional_render_inverted", Api = "gl|glcore")]
	QueryNoWaitInverted,
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ARB_conditional_render_inverted", Api = "gl|glcore")]
	QueryByRegionWaitInverted,
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ARB_conditional_render_inverted", Api = "gl|glcore")]
	QueryByRegionNoWaitInverted
}
