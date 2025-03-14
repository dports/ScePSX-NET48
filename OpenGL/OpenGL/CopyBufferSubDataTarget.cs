using Khronos;

namespace OpenGL;

public enum CopyBufferSubDataTarget
{
	[RequiredByFeature("GL_VERSION_1_5")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_vertex_buffer_object")]
	ArrayBuffer = 34962,
	[RequiredByFeature("GL_VERSION_1_5")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_vertex_buffer_object")]
	ElementArrayBuffer = 34963,
	[RequiredByFeature("GL_VERSION_2_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_pixel_buffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_pixel_buffer_object")]
	[RequiredByFeature("GL_NV_pixel_buffer_object", Api = "gles2")]
	PixelPackBuffer = 35051,
	[RequiredByFeature("GL_VERSION_2_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_pixel_buffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_pixel_buffer_object")]
	[RequiredByFeature("GL_NV_pixel_buffer_object", Api = "gles2")]
	PixelUnpackBuffer = 35052,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
	UniformBuffer = 35345,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_texture_buffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_texture_buffer", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_buffer_object")]
	[RequiredByFeature("GL_OES_texture_buffer", Api = "gles2")]
	TextureBuffer = 35882,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_VERSION_4_4")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_enhanced_layouts", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_transform_feedback")]
	[RequiredByFeature("GL_NV_transform_feedback")]
	TransformFeedbackBuffer = 35982,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_copy_buffer", Api = "gl|glcore")]
	[RequiredByFeature("GL_NV_copy_buffer", Api = "gles2")]
	CopyReadBuffer = 36662,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_copy_buffer", Api = "gl|glcore")]
	[RequiredByFeature("GL_NV_copy_buffer", Api = "gles2")]
	CopyWriteBuffer = 36663,
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_draw_indirect", Api = "gl|glcore")]
	DrawIndirectBuffer = 36671,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_storage_buffer_object", Api = "gl|glcore")]
	ShaderStorageBuffer = 37074,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_compute_shader", Api = "gl|glcore")]
	DispatchIndirectBuffer = 37102,
	[RequiredByFeature("GL_VERSION_4_4")]
	[RequiredByFeature("GL_ARB_query_buffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_AMD_query_buffer_object")]
	QueryBuffer = 37266,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_shader_atomic_counters", Api = "gl|glcore")]
	AtomicCounterBuffer = 37568
}
