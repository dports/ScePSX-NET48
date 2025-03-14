using Khronos;

namespace OpenGL;

public enum VertexAttribPointerPropertyARB
{
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_vertex_program")]
	[RequiredByFeature("GL_ARB_vertex_shader")]
	VertexAttribArrayPointer = 34373
}
