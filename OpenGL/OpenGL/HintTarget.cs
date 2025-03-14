using System;
using Khronos;

namespace OpenGL;

[Flags]
public enum HintTarget : uint
{
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	PerspectiveCorrectionHint = 0xC50u,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	PointSmoothHint = 0xC51u,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	LineSmoothHint = 0xC52u,
	[RequiredByFeature("GL_VERSION_1_0")]
	PolygonSmoothHint = 0xC53u,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	FogHint = 0xC54u,
	[RequiredByFeature("GL_EXT_cmyka")]
	PackCmykHintExt = 0x800Eu,
	[RequiredByFeature("GL_EXT_cmyka")]
	UnpackCmykHintExt = 0x800Fu,
	[RequiredByFeature("GL_WIN_phong_shading")]
	PhongHintWin = 0x80EBu,
	[RequiredByFeature("GL_EXT_clip_volume_hint")]
	ClipVolumeClippingHintExt = 0x80F0u,
	[RequiredByFeature("GL_SGIX_texture_multi_buffer")]
	TextureMultiBufferHintSgix = 0x812Eu,
	[RequiredByFeature("GL_VERSION_1_4")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_SGIS_generate_mipmap")]
	[RemovedByFeature("GL_VERSION_3_2")]
	GenerateMipmapHint = 0x8192u,
	[RequiredByFeature("GL_VERSION_4_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_get_program_binary", Api = "gl|glcore")]
	ProgramBinaryRetrievableHint = 0x8257u,
	[RequiredByFeature("GL_SGIX_convolution_accuracy")]
	ConvolutionHintSgix = 0x8316u,
	[RequiredByFeature("GL_SGIX_scalebias_hint")]
	ScalebiasHintSgix = 0x8322u,
	[RequiredByFeature("GL_SGIX_vertex_preclip")]
	VertexPreclipSgix = 0x83EEu,
	[RequiredByFeature("GL_SGIX_vertex_preclip")]
	VertexPreclipHintSgix = 0x83EFu,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_ARB_texture_compression")]
	TextureCompressionHint = 0x84EFu,
	[RequiredByFeature("GL_APPLE_vertex_array_range")]
	VertexArrayStorageHintApple = 0x851Fu,
	[RequiredByFeature("GL_NV_multisample_filter_hint")]
	MultisampleFilterHintNv = 0x8534u,
	[RequiredByFeature("GL_APPLE_transform_hint")]
	TransformHintApple = 0x85B1u,
	[RequiredByFeature("GL_APPLE_texture_range")]
	TextureStorageHintApple = 0x85BCu,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_fragment_shader")]
	[RequiredByFeature("GL_OES_standard_derivatives", Api = "gles2|glsc2")]
	FragmentShaderDerivativeHint = 0x8B8Bu,
	[RequiredByFeature("GL_QCOM_binning_control", Api = "gles2")]
	BinningControlHintQcom = 0x8FB0u,
	[RequiredByFeature("GL_PGI_misc_hints")]
	PreferDoublebufferHintPgi = 0x1A1F8u,
	[RequiredByFeature("GL_PGI_misc_hints")]
	ConserveMemoryHintPgi = 0x1A1FDu,
	[RequiredByFeature("GL_PGI_misc_hints")]
	ReclaimMemoryHintPgi = 0x1A1FEu,
	[RequiredByFeature("GL_PGI_misc_hints")]
	NativeGraphicsBeginHintPgi = 0x1A203u,
	[RequiredByFeature("GL_PGI_misc_hints")]
	NativeGraphicsEndHintPgi = 0x1A204u,
	[RequiredByFeature("GL_PGI_misc_hints")]
	AlwaysFastHintPgi = 0x1A20Cu,
	[RequiredByFeature("GL_PGI_misc_hints")]
	AlwaysSoftHintPgi = 0x1A20Du,
	[RequiredByFeature("GL_PGI_misc_hints")]
	AllowDrawObjHintPgi = 0x1A20Eu,
	[RequiredByFeature("GL_PGI_misc_hints")]
	AllowDrawWinHintPgi = 0x1A20Fu,
	[RequiredByFeature("GL_PGI_misc_hints")]
	AllowDrawFrgHintPgi = 0x1A210u,
	[RequiredByFeature("GL_PGI_misc_hints")]
	AllowDrawMemHintPgi = 0x1A211u,
	[RequiredByFeature("GL_PGI_misc_hints")]
	StrictDepthfuncHintPgi = 0x1A216u,
	[RequiredByFeature("GL_PGI_misc_hints")]
	StrictLightingHintPgi = 0x1A217u,
	[RequiredByFeature("GL_PGI_misc_hints")]
	StrictScissorHintPgi = 0x1A218u,
	[RequiredByFeature("GL_PGI_misc_hints")]
	FullStippleHintPgi = 0x1A219u,
	[RequiredByFeature("GL_PGI_misc_hints")]
	ClipNearHintPgi = 0x1A220u,
	[RequiredByFeature("GL_PGI_misc_hints")]
	ClipFarHintPgi = 0x1A221u,
	[RequiredByFeature("GL_PGI_misc_hints")]
	WideLineHintPgi = 0x1A222u,
	[RequiredByFeature("GL_PGI_misc_hints")]
	BackNormalsHintPgi = 0x1A223u,
	[RequiredByFeature("GL_PGI_vertex_hints")]
	VertexDataHintPgi = 0x1A22Au,
	[RequiredByFeature("GL_PGI_vertex_hints")]
	VertexConsistentHintPgi = 0x1A22Bu,
	[RequiredByFeature("GL_PGI_vertex_hints")]
	MaterialSideHintPgi = 0x1A22Cu,
	[RequiredByFeature("GL_PGI_vertex_hints")]
	MaxVertexHintPgi = 0x1A22Du
}
