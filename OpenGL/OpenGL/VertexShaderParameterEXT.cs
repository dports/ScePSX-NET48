using Khronos;

namespace OpenGL;

public enum VertexShaderParameterEXT
{
	[RequiredByFeature("GL_EXT_vertex_shader")]
	CurrentVertexExt = 34786,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	MvpMatrixExt
}
