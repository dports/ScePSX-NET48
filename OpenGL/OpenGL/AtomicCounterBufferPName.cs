using Khronos;

namespace OpenGL;

public enum AtomicCounterBufferPName
{
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_compute_shader", Api = "gl|glcore")]
	AtomicCounterBufferReferencedByComputeShader = 37101,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_atomic_counters", Api = "gl|glcore")]
	AtomicCounterBufferBinding = 37569,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ARB_shader_atomic_counters", Api = "gl|glcore")]
	AtomicCounterBufferDataSize = 37572,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ARB_shader_atomic_counters", Api = "gl|glcore")]
	AtomicCounterBufferActiveAtomicCounters = 37573,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ARB_shader_atomic_counters", Api = "gl|glcore")]
	AtomicCounterBufferActiveAtomicCounterIndices = 37574,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ARB_shader_atomic_counters", Api = "gl|glcore")]
	AtomicCounterBufferReferencedByVertexShader = 37575,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ARB_shader_atomic_counters", Api = "gl|glcore")]
	AtomicCounterBufferReferencedByTessControlShader = 37576,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ARB_shader_atomic_counters", Api = "gl|glcore")]
	AtomicCounterBufferReferencedByTessEvaluationShader = 37577,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ARB_shader_atomic_counters", Api = "gl|glcore")]
	AtomicCounterBufferReferencedByGeometryShader = 37578,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ARB_shader_atomic_counters", Api = "gl|glcore")]
	AtomicCounterBufferReferencedByFragmentShader = 37579
}
