using Khronos;

namespace OpenGL;

public enum DataTypeEXT
{
	[RequiredByFeature("GL_EXT_vertex_shader")]
	ScalarExt = 34750,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	VectorExt,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	MatrixExt
}
