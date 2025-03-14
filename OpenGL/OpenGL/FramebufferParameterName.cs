using Khronos;

namespace OpenGL;

public enum FramebufferParameterName
{
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_no_attachments", Api = "gl|glcore")]
	FramebufferDefaultWidth = 37648,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_no_attachments", Api = "gl|glcore")]
	FramebufferDefaultHeight,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_no_attachments", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_geometry_shader", Api = "gles2")]
	[RequiredByFeature("GL_OES_geometry_shader", Api = "gles2")]
	FramebufferDefaultLayers,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_no_attachments", Api = "gl|glcore")]
	FramebufferDefaultSamples,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_no_attachments", Api = "gl|glcore")]
	FramebufferDefaultFixedSampleLocations
}
