using Khronos;

namespace OpenGL;

public enum BufferUsage
{
	[RequiredByFeature("GL_VERSION_1_5")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_vertex_buffer_object")]
	StreamDraw = 35040,
	[RequiredByFeature("GL_VERSION_1_5")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_vertex_buffer_object")]
	StreamRead = 35041,
	[RequiredByFeature("GL_VERSION_1_5")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_vertex_buffer_object")]
	StreamCopy = 35042,
	[RequiredByFeature("GL_VERSION_1_5")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_vertex_buffer_object")]
	StaticDraw = 35044,
	[RequiredByFeature("GL_VERSION_1_5")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_vertex_buffer_object")]
	StaticRead = 35045,
	[RequiredByFeature("GL_VERSION_1_5")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_vertex_buffer_object")]
	StaticCopy = 35046,
	[RequiredByFeature("GL_VERSION_1_5")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_vertex_buffer_object")]
	DynamicDraw = 35048,
	[RequiredByFeature("GL_VERSION_1_5")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_vertex_buffer_object")]
	DynamicRead = 35049,
	[RequiredByFeature("GL_VERSION_1_5")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_vertex_buffer_object")]
	DynamicCopy = 35050
}
