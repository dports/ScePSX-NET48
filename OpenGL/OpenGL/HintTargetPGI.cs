using Khronos;

namespace OpenGL;

public enum HintTargetPGI
{
	[RequiredByFeature("GL_PGI_vertex_hints")]
	VertexDataHintPgi = 107050,
	[RequiredByFeature("GL_PGI_vertex_hints")]
	VertexConsistentHintPgi,
	[RequiredByFeature("GL_PGI_vertex_hints")]
	MaterialSideHintPgi,
	[RequiredByFeature("GL_PGI_vertex_hints")]
	MaxVertexHintPgi
}
