using Khronos;

namespace OpenGL;

public enum VertexShaderOpEXT
{
	[RequiredByFeature("GL_EXT_vertex_shader")]
	OpIndexExt = 34690,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	OpNegateExt,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	OpDot3Ext,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	OpDot4Ext,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	OpMulExt,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	OpAddExt,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	OpMaddExt,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	OpFracExt,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	OpMaxExt,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	OpMinExt,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	OpSetGeExt,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	OpSetLtExt,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	OpClampExt,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	OpFloorExt,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	OpRoundExt,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	OpExpBase2Ext,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	OpLogBase2Ext,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	OpPowerExt,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	OpRecipExt,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	OpRecipSqrtExt,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	OpSubExt,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	OpCrossProductExt,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	OpMultiplyMatrixExt,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	OpMovExt
}
