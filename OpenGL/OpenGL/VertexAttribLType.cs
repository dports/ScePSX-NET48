using Khronos;

namespace OpenGL;

public enum VertexAttribLType
{
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_vertex_attrib_64bit")]
	Double = 5130
}
