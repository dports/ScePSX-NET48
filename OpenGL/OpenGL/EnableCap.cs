using Khronos;

namespace OpenGL;

public enum EnableCap
{
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	PointSmooth = 2832,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	LineSmooth = 2848,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	LineStipple = 2852,
	[RequiredByFeature("GL_VERSION_1_0")]
	PolygonSmooth = 2881,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	PolygonStipple = 2882,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	CullFace = 2884,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Lighting = 2896,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ColorMaterial = 2903,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_NV_register_combiners")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Fog = 2912,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	DepthTest = 2929,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	StencilTest = 2960,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Normalize = 2977,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_QCOM_alpha_test", Api = "gles2")]
	[RemovedByFeature("GL_VERSION_3_2")]
	AlphaTest = 3008,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	Dither = 3024,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_EXT_draw_buffers_indexed", Api = "gles2")]
	[RequiredByFeature("GL_OES_draw_buffers_indexed", Api = "gles2")]
	Blend = 3042,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	IndexLogicOp = 3057,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	ColorLogicOp = 3058,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_viewport_array", Api = "gl|glcore")]
	[RequiredByFeature("GL_NV_viewport_array", Api = "gles2")]
	[RequiredByFeature("GL_OES_viewport_array", Api = "gles2")]
	ScissorTest = 3089,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	TextureGenS = 3168,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	TextureGenT = 3169,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	TextureGenR = 3170,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	TextureGenQ = 3171,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	AutoNormal = 3456,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Map1Color4 = 3472,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Map1Index = 3473,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Map1Normal = 3474,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Map1TextureCoord1 = 3475,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Map1TextureCoord2 = 3476,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Map1TextureCoord3 = 3477,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Map1TextureCoord4 = 3478,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Map1Vertex3 = 3479,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Map1Vertex4 = 3480,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Map2Color4 = 3504,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Map2Index = 3505,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Map2Normal = 3506,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Map2TextureCoord1 = 3507,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Map2TextureCoord2 = 3508,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Map2TextureCoord3 = 3509,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Map2TextureCoord4 = 3510,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Map2Vertex3 = 3511,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Map2Vertex4 = 3512,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	Texture1d = 3552,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_sparse_texture", Api = "gles2")]
	Texture2d = 3553,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_NV_polygon_mode", Api = "gles2")]
	PolygonOffsetPoint = 10753,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_NV_polygon_mode", Api = "gles2")]
	PolygonOffsetLine = 10754,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_IMG_user_clip_plane", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ClipPlane0 = 12288,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_IMG_user_clip_plane", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ClipPlane1 = 12289,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_IMG_user_clip_plane", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ClipPlane2 = 12290,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_IMG_user_clip_plane", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ClipPlane3 = 12291,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_IMG_user_clip_plane", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ClipPlane4 = 12292,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_IMG_user_clip_plane", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ClipPlane5 = 12293,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_APPLE_clip_distance", Api = "gles2")]
	ClipDistance6 = 12294,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_APPLE_clip_distance", Api = "gles2")]
	ClipDistance7 = 12295,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Light0 = 16384,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Light1 = 16385,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Light2 = 16386,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Light3 = 16387,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Light4 = 16388,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Light5 = 16389,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Light6 = 16390,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Light7 = 16391,
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_convolution")]
	Convolution1d = 32784,
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_convolution")]
	Convolution2d = 32785,
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_convolution")]
	Separable2d = 32786,
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_histogram")]
	Histogram = 32804,
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_histogram")]
	Minmax = 32814,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	PolygonOffsetFill = 32823,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_EXT_rescale_normal")]
	[RemovedByFeature("GL_VERSION_3_2")]
	RescaleNormal = 32826,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_sparse_texture", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture3D")]
	[RequiredByFeature("GL_OES_texture_3D", Api = "gles2")]
	Texture3d = 32879,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	[RequiredByFeature("GL_EXT_vertex_array")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	[RemovedByFeature("GL_VERSION_3_2")]
	VertexArray = 32884,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_EXT_vertex_array")]
	[RemovedByFeature("GL_VERSION_3_2")]
	NormalArray = 32885,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_EXT_vertex_array")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ColorArray = 32886,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_EXT_vertex_array")]
	[RemovedByFeature("GL_VERSION_3_2")]
	IndexArray = 32887,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_EXT_vertex_array")]
	[RemovedByFeature("GL_VERSION_3_2")]
	TextureCoordArray = 32888,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_EXT_vertex_array")]
	[RemovedByFeature("GL_VERSION_3_2")]
	EdgeFlagArray = 32889,
	[RequiredByFeature("GL_SGIX_interlace")]
	InterlaceSgix = 32916,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ARB_multisample")]
	[RequiredByFeature("GL_EXT_multisample")]
	[RequiredByFeature("GL_EXT_multisampled_compatibility", Api = "gles2")]
	[RequiredByFeature("GL_SGIS_multisample")]
	Multisample = 32925,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_multisample")]
	SampleAlphaToCoverage = 32926,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ARB_multisample")]
	[RequiredByFeature("GL_EXT_multisample")]
	[RequiredByFeature("GL_EXT_multisampled_compatibility", Api = "gles2")]
	[RequiredByFeature("GL_SGIS_multisample")]
	SampleAlphaToOne = 32927,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_multisample")]
	SampleCoverage = 32928,
	[RequiredByFeature("GL_SGIS_multisample")]
	SampleMaskSgis = 32928,
	[RequiredByFeature("GL_SGI_texture_color_table")]
	TextureColorTableSgi = 32956,
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_SGI_color_table")]
	ColorTable = 32976,
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_SGI_color_table")]
	PostConvolutionColorTable = 32977,
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_SGI_color_table")]
	PostColorMatrixColorTable = 32978,
	[RequiredByFeature("GL_SGIS_texture4D")]
	Texture4dSgis = 33076,
	[RequiredByFeature("GL_SGIX_pixel_texture")]
	PixelTexGenSgix = 33081,
	[RequiredByFeature("GL_SGIX_sprite")]
	SpriteSgix = 33096,
	[RequiredByFeature("GL_SGIX_reference_plane")]
	ReferencePlaneSgix = 33149,
	[RequiredByFeature("GL_SGIX_ir_instrument1")]
	IrInstrument1Sgix = 33151,
	[RequiredByFeature("GL_SGIX_calligraphic_fragment")]
	CalligraphicFragmentSgix = 33155,
	[RequiredByFeature("GL_SGIX_framezoom")]
	FramezoomSgix = 33163,
	[RequiredByFeature("GL_SGIX_fog_offset")]
	FogOffsetSgix = 33176,
	[RequiredByFeature("GL_EXT_shared_texture_palette")]
	SharedTexturePaletteExt = 33275,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	[RequiredByFeature("GL_ARB_debug_output", Api = "gl|glcore")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	DebugOutputSynchronous = 33346,
	[RequiredByFeature("GL_SGIX_async_histogram")]
	AsyncHistogramSgix = 33580,
	[RequiredByFeature("GL_SGIS_pixel_texture")]
	PixelTextureSgis = 33619,
	[RequiredByFeature("GL_SGIX_async_pixel")]
	AsyncTexImageSgix = 33628,
	[RequiredByFeature("GL_SGIX_async_pixel")]
	AsyncDrawPixelsSgix = 33629,
	[RequiredByFeature("GL_SGIX_async_pixel")]
	AsyncReadPixelsSgix = 33630,
	[RequiredByFeature("GL_SGIX_fragment_lighting")]
	FragmentLightingSgix = 33792,
	[RequiredByFeature("GL_SGIX_fragment_lighting")]
	FragmentColorMaterialSgix = 33793,
	[RequiredByFeature("GL_SGIX_fragment_lighting")]
	FragmentLight0Sgix = 33804,
	[RequiredByFeature("GL_SGIX_fragment_lighting")]
	FragmentLight1Sgix = 33805,
	[RequiredByFeature("GL_SGIX_fragment_lighting")]
	FragmentLight2Sgix = 33806,
	[RequiredByFeature("GL_SGIX_fragment_lighting")]
	FragmentLight3Sgix = 33807,
	[RequiredByFeature("GL_SGIX_fragment_lighting")]
	FragmentLight4Sgix = 33808,
	[RequiredByFeature("GL_SGIX_fragment_lighting")]
	FragmentLight5Sgix = 33809,
	[RequiredByFeature("GL_SGIX_fragment_lighting")]
	FragmentLight6Sgix = 33810,
	[RequiredByFeature("GL_SGIX_fragment_lighting")]
	FragmentLight7Sgix = 33811,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_texture_rectangle")]
	[RequiredByFeature("GL_NV_texture_rectangle")]
	TextureRectangle = 34037,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_sparse_texture", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_cube_map")]
	[RequiredByFeature("GL_EXT_texture_cube_map")]
	[RequiredByFeature("GL_OES_texture_cube_map", Api = "gles1")]
	TextureCubeMap = 34067,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ARB_vertex_program")]
	[RequiredByFeature("GL_ARB_vertex_shader")]
	[RequiredByFeature("GL_NV_vertex_program")]
	VertexProgramPointSize = 34370,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ARB_depth_clamp", Api = "gl|glcore")]
	[RequiredByFeature("GL_NV_depth_clamp")]
	[RequiredByFeature("GL_EXT_depth_clamp", Api = "gles2")]
	DepthClamp = 34383,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_AMD_seamless_cubemap_per_texture")]
	[RequiredByFeature("GL_ARB_seamless_cube_map", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_seamless_cubemap_per_texture", Api = "gl|glcore")]
	TextureCubeMapSeamless = 34895,
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_sample_shading", Api = "gl|glcore")]
	[RequiredByFeature("GL_OES_sample_shading", Api = "gles2")]
	SampleShading = 35894,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_transform_feedback")]
	[RequiredByFeature("GL_NV_transform_feedback")]
	RasterizerDiscard = 35977,
	[RequiredByFeature("GL_OES_texture_cube_map", Api = "gles1")]
	TextureGenStrOes = 36192,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_ES3_compatibility", Api = "gl|glcore")]
	PrimitiveRestartFixedIndex = 36201,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ARB_framebuffer_sRGB", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_framebuffer_sRGB")]
	[RequiredByFeature("GL_EXT_sRGB_write_control", Api = "gles2")]
	FramebufferSrgb = 36281,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_multisample", Api = "gl|glcore")]
	[RequiredByFeature("GL_NV_explicit_multisample")]
	SampleMask = 36433,
	[RequiredByFeature("GL_ARM_shader_framebuffer_fetch", Api = "gles2")]
	FetchPerSampleArm = 36709,
	[RequiredByFeature("GL_VERSION_3_1")]
	PrimitiveRestart = 36765,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	DebugOutput = 37600,
	[RequiredByFeature("GL_NV_primitive_shading_rate", Api = "gl|glcore|gles2")]
	ShadingRateImagePerPrimitiveNv = 38321,
	[RequiredByFeature("GL_QCOM_shader_framebuffer_fetch_noncoherent", Api = "gles2")]
	FramebufferFetchNoncoherentQcom = 38562,
	[RequiredByFeature("GL_QCOM_shading_rate", Api = "gles2")]
	ShadingRatePreserveAspectRatioQcom = 38565,
	[RequiredByFeature("GL_NV_primitive_restart")]
	PrimitiveRestartNv = 34136
}
