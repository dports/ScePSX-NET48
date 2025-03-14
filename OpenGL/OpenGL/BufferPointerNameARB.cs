using Khronos;

namespace OpenGL;

public enum BufferPointerNameARB
{
	[RequiredByFeature("GL_VERSION_1_5")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_vertex_buffer_object")]
	[RequiredByFeature("GL_OES_mapbuffer", Api = "gles1|gles2")]
	BufferMapPointer = 35005
}
