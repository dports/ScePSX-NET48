using Khronos;

namespace OpenGL;

public enum ProgramResourceProperty
{
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
	NumCompatibleSubroutines = 36426,
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
	CompatibleSubroutines = 36427,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	Uniform = 37601,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
	[RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
	IsPerPatch = 37607,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	NameLength = 37625,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	Type = 37626,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	ArraySize = 37627,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	Offset = 37628,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	BlockIndex = 37629,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	ArrayStride = 37630,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	MatrixStride = 37631,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	IsRowMajor = 37632,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	AtomicCounterBufferIndex = 37633,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	BufferBinding = 37634,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	BufferDataSize = 37635,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	NumActiveVariables = 37636,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	ActiveVariables = 37637,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	ReferencedByVertexShader = 37638,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
	[RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
	ReferencedByTessControlShader = 37639,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
	[RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
	ReferencedByTessEvaluationShader = 37640,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_geometry_shader", Api = "gles2")]
	[RequiredByFeature("GL_OES_geometry_shader", Api = "gles2")]
	ReferencedByGeometryShader = 37641,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	ReferencedByFragmentShader = 37642,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	ReferencedByComputeShader = 37643,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	TopLevelArraySize = 37644,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	TopLevelArrayStride = 37645,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	Location = 37646,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_blend_func_extended", Api = "gles2")]
	LocationIndex = 37647,
	[RequiredByFeature("GL_VERSION_4_4")]
	[RequiredByFeature("GL_ARB_enhanced_layouts", Api = "gl|glcore")]
	LocationComponent = 37706,
	[RequiredByFeature("GL_VERSION_4_4")]
	[RequiredByFeature("GL_ARB_enhanced_layouts", Api = "gl|glcore")]
	TransformFeedbackBufferIndex = 37707,
	[RequiredByFeature("GL_VERSION_4_4")]
	[RequiredByFeature("GL_ARB_enhanced_layouts", Api = "gl|glcore")]
	TransformFeedbackBufferStride = 37708
}
