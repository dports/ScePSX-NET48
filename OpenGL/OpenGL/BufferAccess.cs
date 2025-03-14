using Khronos;

namespace OpenGL;

public enum BufferAccess
{
	[RequiredByFeature("GL_VERSION_1_5")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_vertex_buffer_object")]
	ReadOnly = 35000,
	[RequiredByFeature("GL_VERSION_1_5")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_NV_shader_buffer_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_vertex_buffer_object")]
	[RequiredByFeature("GL_OES_mapbuffer", Api = "gles1|gles2")]
	WriteOnly,
	[RequiredByFeature("GL_VERSION_1_5")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_NV_shader_buffer_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_vertex_buffer_object")]
	ReadWrite
}
