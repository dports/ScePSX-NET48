using System;
using Khronos;

namespace OpenGL;

[Flags]
public enum MemoryBarrierMask : uint
{
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	VertexAttribArrayBarrierBit = 1u,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	ElementArrayBarrierBit = 2u,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	UniformBarrierBit = 4u,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	TextureFetchBarrierBit = 8u,
	[RequiredByFeature("GL_NV_shader_buffer_store", Api = "gl|glcore")]
	ShaderGlobalAccessBarrierBitNv = 0x10u,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	ShaderImageAccessBarrierBit = 0x20u,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	CommandBarrierBit = 0x40u,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	PixelBufferBarrierBit = 0x80u,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	TextureUpdateBarrierBit = 0x100u,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	BufferUpdateBarrierBit = 0x200u,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	FramebufferBarrierBit = 0x400u,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	TransformFeedbackBarrierBit = 0x800u,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	AtomicCounterBarrierBit = 0x1000u,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_storage_buffer_object", Api = "gl|glcore")]
	ShaderStorageBarrierBit = 0x2000u,
	[RequiredByFeature("GL_VERSION_4_4")]
	[RequiredByFeature("GL_ARB_buffer_storage", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_buffer_storage", Api = "gles2")]
	ClientMappedBufferBarrierBit = 0x4000u,
	[RequiredByFeature("GL_VERSION_4_4")]
	[RequiredByFeature("GL_ARB_query_buffer_object", Api = "gl|glcore")]
	QueryBufferBarrierBit = 0x8000u,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	AllBarrierBits = uint.MaxValue
}
