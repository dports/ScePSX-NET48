using Khronos;

namespace OpenGL;

public enum VertexProvokingMode
{
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_provoking_vertex", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_viewport_array", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_geometry_shader", Api = "gles2")]
	[RequiredByFeature("GL_EXT_provoking_vertex")]
	[RequiredByFeature("GL_OES_geometry_shader", Api = "gles2")]
	FirstVertexConvention = 36429,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_provoking_vertex", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_viewport_array", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_geometry_shader", Api = "gles2")]
	[RequiredByFeature("GL_EXT_provoking_vertex")]
	[RequiredByFeature("GL_OES_geometry_shader", Api = "gles2")]
	LastVertexConvention
}
