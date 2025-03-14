using System;
using Khronos;

namespace OpenGL;

[Flags]
public enum UseProgramStageMask : uint
{
	[RequiredByFeature("GL_VERSION_4_1")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_separate_shader_objects", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_separate_shader_objects", Api = "gl|glcore|gles2")]
	VertexShaderBit = 1u,
	[RequiredByFeature("GL_VERSION_4_1")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_separate_shader_objects", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_separate_shader_objects", Api = "gl|glcore|gles2")]
	FragmentShaderBit = 2u,
	[RequiredByFeature("GL_VERSION_4_1")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_separate_shader_objects", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_geometry_shader", Api = "gles2")]
	[RequiredByFeature("GL_OES_geometry_shader", Api = "gles2")]
	GeometryShaderBit = 4u,
	[RequiredByFeature("GL_VERSION_4_1")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_separate_shader_objects", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
	[RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
	TessControlShaderBit = 8u,
	[RequiredByFeature("GL_VERSION_4_1")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_separate_shader_objects", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
	[RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
	TessEvaluationShaderBit = 0x10u,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_compute_shader", Api = "gl|glcore")]
	ComputeShaderBit = 0x20u,
	[RequiredByFeature("GL_NV_mesh_shader", Api = "gl|glcore|gles2")]
	MeshShaderBitNv = 0x40u,
	[RequiredByFeature("GL_NV_mesh_shader", Api = "gl|glcore|gles2")]
	TaskShaderBitNv = 0x80u,
	[RequiredByFeature("GL_VERSION_4_1")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_separate_shader_objects", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_separate_shader_objects", Api = "gl|glcore|gles2")]
	AllShaderBits = uint.MaxValue
}
