using Khronos;

namespace OpenGL;

public enum UniformBlockPName
{
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
	UniformBlockReferencedByTessControlShader = 34032,
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
	UniformBlockReferencedByTessEvaluationShader = 34033,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
	UniformBlockBinding = 35391,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
	UniformBlockDataSize = 35392,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
	UniformBlockNameLength = 35393,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
	UniformBlockActiveUniforms = 35394,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
	UniformBlockActiveUniformIndices = 35395,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
	UniformBlockReferencedByVertexShader = 35396,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
	UniformBlockReferencedByGeometryShader = 35397,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
	UniformBlockReferencedByFragmentShader = 35398,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_compute_shader", Api = "gl|glcore")]
	UniformBlockReferencedByComputeShader = 37100
}
