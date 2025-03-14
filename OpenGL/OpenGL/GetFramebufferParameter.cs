using Khronos;

namespace OpenGL;

public enum GetFramebufferParameter
{
	[RequiredByFeature("GL_VERSION_1_0")]
	Doublebuffer = 3122,
	[RequiredByFeature("GL_VERSION_1_0")]
	Stereo = 3123,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_multisample")]
	[RequiredByFeature("GL_EXT_multisample")]
	[RequiredByFeature("GL_SGIS_multisample")]
	SampleBuffers = 32936,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_multisample")]
	[RequiredByFeature("GL_NV_multisample_coverage")]
	[RequiredByFeature("GL_EXT_multisample")]
	[RequiredByFeature("GL_SGIS_multisample")]
	Samples = 32937,
	[RequiredByFeature("GL_VERSION_4_1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_ES2_compatibility", Api = "gl|glcore")]
	[RequiredByFeature("GL_OES_read_format", Api = "gl|gles1")]
	ImplementationColorReadType = 35738,
	[RequiredByFeature("GL_VERSION_4_1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_ES2_compatibility", Api = "gl|glcore")]
	[RequiredByFeature("GL_OES_read_format", Api = "gl|gles1")]
	ImplementationColorReadFormat = 35739,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_no_attachments", Api = "gl|glcore")]
	FramebufferDefaultWidth = 37648,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_no_attachments", Api = "gl|glcore")]
	FramebufferDefaultHeight = 37649,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_no_attachments", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_geometry_shader", Api = "gles2")]
	[RequiredByFeature("GL_OES_geometry_shader", Api = "gles2")]
	FramebufferDefaultLayers = 37650,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_no_attachments", Api = "gl|glcore")]
	FramebufferDefaultSamples = 37651,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_no_attachments", Api = "gl|glcore")]
	FramebufferDefaultFixedSampleLocations = 37652
}
