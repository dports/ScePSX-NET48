using Khronos;

namespace OpenGL;

public enum VertexShaderStorageTypeEXT
{
	[RequiredByFeature("GL_EXT_vertex_shader")]
	VariantExt = 34753,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	InvariantExt,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	LocalConstantExt,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	LocalExt
}
