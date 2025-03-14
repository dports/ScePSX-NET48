using Khronos;

namespace OpenGL;

public enum PrimitiveType
{
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	Points,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	Lines,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	LineLoop,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	LineStrip,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
	[RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
	Triangles,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	TriangleStrip,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	TriangleFan,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
	[RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Quads,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	QuadStrip,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Polygon,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_geometry_shader4", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_geometry_shader", Api = "gles2")]
	[RequiredByFeature("GL_EXT_geometry_shader4")]
	[RequiredByFeature("GL_NV_geometry_program4")]
	[RequiredByFeature("GL_OES_geometry_shader", Api = "gles2")]
	LinesAdjacency,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_geometry_shader4", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_geometry_shader", Api = "gles2")]
	[RequiredByFeature("GL_EXT_geometry_shader4")]
	[RequiredByFeature("GL_NV_geometry_program4")]
	[RequiredByFeature("GL_OES_geometry_shader", Api = "gles2")]
	LineStripAdjacency,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_geometry_shader4", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_geometry_shader", Api = "gles2")]
	[RequiredByFeature("GL_EXT_geometry_shader4")]
	[RequiredByFeature("GL_NV_geometry_program4")]
	[RequiredByFeature("GL_OES_geometry_shader", Api = "gles2")]
	TrianglesAdjacency,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_geometry_shader4", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_geometry_shader", Api = "gles2")]
	[RequiredByFeature("GL_EXT_geometry_shader4")]
	[RequiredByFeature("GL_NV_geometry_program4")]
	[RequiredByFeature("GL_OES_geometry_shader", Api = "gles2")]
	TriangleStripAdjacency,
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
	[RequiredByFeature("GL_NV_gpu_shader5", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
	[RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
	Patches
}
