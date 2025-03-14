using Khronos;

namespace OpenGL;

public enum VertexAttribPropertyARB
{
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_vertex_attrib_binding", Api = "gl|glcore")]
	VertexAttribBinding = 33492,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_vertex_attrib_binding", Api = "gl|glcore")]
	VertexAttribRelativeOffset = 33493,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_vertex_program")]
	[RequiredByFeature("GL_ARB_vertex_shader")]
	VertexAttribArrayEnabled = 34338,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_vertex_program")]
	[RequiredByFeature("GL_ARB_vertex_shader")]
	VertexAttribArraySize = 34339,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_vertex_program")]
	[RequiredByFeature("GL_ARB_vertex_shader")]
	VertexAttribArrayStride = 34340,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_vertex_program")]
	[RequiredByFeature("GL_ARB_vertex_shader")]
	VertexAttribArrayType = 34341,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_vertex_program")]
	[RequiredByFeature("GL_ARB_vertex_shader")]
	CurrentVertexAttrib = 34342,
	[RequiredByFeature("GL_VERSION_4_3")]
	VertexAttribArrayLong = 34638,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_vertex_program")]
	[RequiredByFeature("GL_ARB_vertex_shader")]
	VertexAttribArrayNormalized = 34922,
	[RequiredByFeature("GL_VERSION_1_5")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_vertex_buffer_object")]
	VertexAttribArrayBufferBinding = 34975,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_gpu_shader4")]
	[RequiredByFeature("GL_NV_vertex_program4")]
	VertexAttribArrayInteger = 35069,
	[RequiredByFeature("GL_VERSION_3_3")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ANGLE_instanced_arrays", Api = "gles2")]
	[RequiredByFeature("GL_ARB_instanced_arrays", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_instanced_arrays", Api = "gles2")]
	[RequiredByFeature("GL_NV_instanced_arrays", Api = "gles2")]
	VertexAttribArrayDivisor = 35070
}
