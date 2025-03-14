using System;
using Khronos;

namespace OpenGL;

[Flags]
public enum BufferStorageMask : uint
{
	[RequiredByFeature("GL_VERSION_4_4")]
	[RequiredByFeature("GL_ARB_buffer_storage", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_buffer_storage", Api = "gles2")]
	DynamicStorageBit = 0x100u,
	[RequiredByFeature("GL_VERSION_4_4")]
	[RequiredByFeature("GL_ARB_buffer_storage", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_buffer_storage", Api = "gles2")]
	ClientStorageBit = 0x200u,
	[RequiredByFeature("GL_ARB_sparse_buffer", Api = "gl|glcore")]
	SparseStorageBitArb = 0x400u,
	[RequiredByFeature("GL_NVX_linked_gpu_multicast")]
	LgpuSeparateStorageBitNvx = 0x800u,
	[RequiredByFeature("GL_NV_gpu_multicast")]
	PerGpuStorageBitNv = 0x800u,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_VERSION_4_4")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_buffer_storage", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_map_buffer_range", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_buffer_storage", Api = "gles2")]
	[RequiredByFeature("GL_EXT_map_buffer_range", Api = "gles1|gles2")]
	MapReadBit = 1u,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_VERSION_4_4")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_buffer_storage", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_map_buffer_range", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_buffer_storage", Api = "gles2")]
	[RequiredByFeature("GL_EXT_map_buffer_range", Api = "gles1|gles2")]
	MapWriteBit = 2u,
	[RequiredByFeature("GL_VERSION_4_4")]
	[RequiredByFeature("GL_ARB_buffer_storage", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_buffer_storage", Api = "gles2")]
	MapPersistentBit = 0x40u,
	[RequiredByFeature("GL_VERSION_4_4")]
	[RequiredByFeature("GL_ARB_buffer_storage", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_buffer_storage", Api = "gles2")]
	MapCoherentBit = 0x80u
}
