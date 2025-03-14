using Khronos;

namespace OpenGL;

public enum BufferPNameARB
{
	[RequiredByFeature("GL_VERSION_4_4")]
	[RequiredByFeature("GL_ARB_buffer_storage", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_buffer_storage", Api = "gles2")]
	BufferImmutableStorage = 33311,
	[RequiredByFeature("GL_VERSION_4_4")]
	[RequiredByFeature("GL_ARB_buffer_storage", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_buffer_storage", Api = "gles2")]
	BufferStorageFlags = 33312,
	[RequiredByFeature("GL_VERSION_1_5")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_vertex_buffer_object")]
	BufferSize = 34660,
	[RequiredByFeature("GL_VERSION_1_5")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_vertex_buffer_object")]
	BufferUsage = 34661,
	[RequiredByFeature("GL_VERSION_1_5")]
	[RequiredByFeature("GL_ARB_vertex_buffer_object")]
	[RequiredByFeature("GL_OES_mapbuffer", Api = "gles1|gles2")]
	BufferAccess = 35003,
	[RequiredByFeature("GL_VERSION_1_5")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_vertex_buffer_object")]
	[RequiredByFeature("GL_OES_mapbuffer", Api = "gles1|gles2")]
	BufferMapped = 35004,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	BufferAccessFlags = 37151,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	BufferMapLength = 37152,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	BufferMapOffset = 37153
}
