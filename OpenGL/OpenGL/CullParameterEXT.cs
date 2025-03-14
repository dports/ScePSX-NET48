using Khronos;

namespace OpenGL;

public enum CullParameterEXT
{
	[RequiredByFeature("GL_EXT_cull_vertex")]
	CullVertexEyePositionExt = 33195,
	[RequiredByFeature("GL_EXT_cull_vertex")]
	CullVertexObjectPositionExt
}
