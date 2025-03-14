using Khronos;

namespace OpenGL;

public enum VertexShaderCoordOutEXT
{
	[RequiredByFeature("GL_EXT_vertex_shader")]
	XExt = 34773,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	YExt,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	ZExt,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	WExt,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	NegativeXExt,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	NegativeYExt,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	NegativeZExt,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	NegativeWExt,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	ZeroExt,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	OneExt,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	NegativeOneExt
}
