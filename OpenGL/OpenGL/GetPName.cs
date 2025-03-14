using Khronos;

namespace OpenGL;

public enum GetPName
{
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	CurrentColor = 2816,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	CurrentIndex = 2817,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	CurrentNormal = 2818,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	CurrentTextureCoords = 2819,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	CurrentRasterColor = 2820,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	CurrentRasterIndex = 2821,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	CurrentRasterTextureCoords = 2822,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	CurrentRasterPosition = 2823,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	CurrentRasterPositionValid = 2824,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	CurrentRasterDistance = 2825,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	PointSmooth = 2832,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	PointSize = 2833,
	[RequiredByFeature("GL_VERSION_1_0")]
	PointSizeRange = 2834,
	[RequiredByFeature("GL_VERSION_1_0")]
	PointSizeGranularity = 2835,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	LineSmooth = 2848,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	LineWidth = 2849,
	[RequiredByFeature("GL_VERSION_1_0")]
	LineWidthRange = 2850,
	[RequiredByFeature("GL_VERSION_1_0")]
	LineWidthGranularity = 2851,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	LineStipple = 2852,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	LineStipplePattern = 2853,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	LineStippleRepeat = 2854,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ListMode = 2864,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	MaxListNesting = 2865,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ListBase = 2866,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ListIndex = 2867,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_NV_polygon_mode", Api = "gles2")]
	PolygonMode = 2880,
	[RequiredByFeature("GL_VERSION_1_0")]
	PolygonSmooth = 2881,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	PolygonStipple = 2882,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	EdgeFlag = 2883,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	CullFace = 2884,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	CullFaceMode = 2885,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	FrontFace = 2886,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Lighting = 2896,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	LightModelLocalViewer = 2897,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	LightModelTwoSide = 2898,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	LightModelAmbient = 2899,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ShadeModel = 2900,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ColorMaterialFace = 2901,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ColorMaterialParameter = 2902,
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
	[RemovedByFeature("GL_VERSION_3_2")]
	FogIndex = 2913,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	FogDensity = 2914,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	FogStart = 2915,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	FogEnd = 2916,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	FogMode = 2917,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	FogColor = 2918,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_viewport_array", Api = "gl|glcore")]
	[RequiredByFeature("GL_NV_viewport_array", Api = "gles2")]
	[RequiredByFeature("GL_OES_viewport_array", Api = "gles2")]
	DepthRange = 2928,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	DepthTest = 2929,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	DepthWritemask = 2930,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	DepthClearValue = 2931,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	DepthFunc = 2932,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	AccumClearValue = 2944,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	StencilTest = 2960,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	StencilClearValue = 2961,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	StencilFunc = 2962,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	StencilValueMask = 2963,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	StencilFail = 2964,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	StencilPassDepthFail = 2965,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	StencilPassDepthPass = 2966,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	StencilRef = 2967,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	StencilWritemask = 2968,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	MatrixMode = 2976,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Normalize = 2977,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_viewport_array", Api = "gl|glcore")]
	[RequiredByFeature("GL_NV_viewport_array", Api = "gles2")]
	[RequiredByFeature("GL_OES_viewport_array", Api = "gles2")]
	Viewport = 2978,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ModelviewStackDepth = 2979,
	[RequiredByFeature("GL_EXT_vertex_weighting")]
	Modelview0StackDepthExt = 2979,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ProjectionStackDepth = 2980,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	TextureStackDepth = 2981,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ModelviewMatrix = 2982,
	[RequiredByFeature("GL_EXT_vertex_weighting")]
	Modelview0MatrixExt = 2982,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ProjectionMatrix = 2983,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	TextureMatrix = 2984,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	AttribStackDepth = 2992,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ClientAttribStackDepth = 2993,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_QCOM_alpha_test", Api = "gles2")]
	[RemovedByFeature("GL_VERSION_3_2")]
	AlphaTest = 3008,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_QCOM_alpha_test", Api = "gles2")]
	[RemovedByFeature("GL_VERSION_3_2")]
	AlphaTestFunc = 3009,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_QCOM_alpha_test", Api = "gles2")]
	[RemovedByFeature("GL_VERSION_3_2")]
	AlphaTestRef = 3010,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	Dither = 3024,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	BlendDst = 3040,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	BlendSrc = 3041,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_EXT_draw_buffers_indexed", Api = "gles2")]
	[RequiredByFeature("GL_OES_draw_buffers_indexed", Api = "gles2")]
	Blend = 3042,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	LogicOpMode = 3056,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	IndexLogicOp = 3057,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	LogicOp = 3057,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	ColorLogicOp = 3058,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	AuxBuffers = 3072,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_EXT_multiview_draw_buffers", Api = "gles2")]
	DrawBuffer = 3073,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_multiview_draw_buffers", Api = "gles2")]
	[RequiredByFeature("GL_NV_read_buffer", Api = "gles2")]
	ReadBuffer = 3074,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_viewport_array", Api = "gl|glcore")]
	[RequiredByFeature("GL_NV_viewport_array", Api = "gles2")]
	[RequiredByFeature("GL_OES_viewport_array", Api = "gles2")]
	ScissorBox = 3088,
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
	IndexClearValue = 3104,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	IndexWritemask = 3105,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	ColorClearValue = 3106,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_EXT_draw_buffers_indexed", Api = "gles2")]
	[RequiredByFeature("GL_OES_draw_buffers_indexed", Api = "gles2")]
	ColorWritemask = 3107,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	IndexMode = 3120,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	RgbaMode = 3121,
	[RequiredByFeature("GL_VERSION_1_0")]
	Doublebuffer = 3122,
	[RequiredByFeature("GL_VERSION_1_0")]
	Stereo = 3123,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	RenderMode = 3136,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	PerspectiveCorrectionHint = 3152,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	PointSmoothHint = 3153,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	LineSmoothHint = 3154,
	[RequiredByFeature("GL_VERSION_1_0")]
	PolygonSmoothHint = 3155,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	FogHint = 3156,
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
	PixelMapIToISize = 3248,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	PixelMapSToSSize = 3249,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	PixelMapIToRSize = 3250,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	PixelMapIToGSize = 3251,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	PixelMapIToBSize = 3252,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	PixelMapIToASize = 3253,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	PixelMapRToRSize = 3254,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	PixelMapGToGSize = 3255,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	PixelMapBToBSize = 3256,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	PixelMapAToASize = 3257,
	[RequiredByFeature("GL_VERSION_1_0")]
	UnpackSwapBytes = 3312,
	[RequiredByFeature("GL_VERSION_1_0")]
	UnpackLsbFirst = 3313,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_unpack_subimage", Api = "gles2")]
	UnpackRowLength = 3314,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_unpack_subimage", Api = "gles2")]
	UnpackSkipRows = 3315,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_unpack_subimage", Api = "gles2")]
	UnpackSkipPixels = 3316,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	UnpackAlignment = 3317,
	[RequiredByFeature("GL_VERSION_1_0")]
	PackSwapBytes = 3328,
	[RequiredByFeature("GL_VERSION_1_0")]
	PackLsbFirst = 3329,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	PackRowLength = 3330,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	PackSkipRows = 3331,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	PackSkipPixels = 3332,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	PackAlignment = 3333,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	MapColor = 3344,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	MapStencil = 3345,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	IndexShift = 3346,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	IndexOffset = 3347,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	RedScale = 3348,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	RedBias = 3349,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ZoomX = 3350,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ZoomY = 3351,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	GreenScale = 3352,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	GreenBias = 3353,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	BlueScale = 3354,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	BlueBias = 3355,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	AlphaScale = 3356,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	AlphaBias = 3357,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	DepthScale = 3358,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	DepthBias = 3359,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	MaxEvalOrder = 3376,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	MaxLights = 3377,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_IMG_user_clip_plane", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	MaxClipPlanes = 3378,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	MaxTextureSize = 3379,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	MaxPixelMapTable = 3380,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	MaxAttribStackDepth = 3381,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	MaxModelviewStackDepth = 3382,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	MaxNameStackDepth = 3383,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	MaxProjectionStackDepth = 3384,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	MaxTextureStackDepth = 3385,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	MaxViewportDims = 3386,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	MaxClientAttribStackDepth = 3387,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	SubpixelBits = 3408,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	IndexBits = 3409,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RemovedByFeature("GL_VERSION_3_2")]
	RedBits = 3410,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RemovedByFeature("GL_VERSION_3_2")]
	GreenBits = 3411,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RemovedByFeature("GL_VERSION_3_2")]
	BlueBits = 3412,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RemovedByFeature("GL_VERSION_3_2")]
	AlphaBits = 3413,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RemovedByFeature("GL_VERSION_3_2")]
	DepthBits = 3414,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RemovedByFeature("GL_VERSION_3_2")]
	StencilBits = 3415,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	AccumRedBits = 3416,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	AccumGreenBits = 3417,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	AccumBlueBits = 3418,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	AccumAlphaBits = 3419,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	NameStackDepth = 3440,
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
	[RemovedByFeature("GL_VERSION_3_2")]
	Map1GridDomain = 3536,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Map1GridSegments = 3537,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Map2GridDomain = 3538,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Map2GridSegments = 3539,
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
	[RemovedByFeature("GL_VERSION_3_2")]
	FeedbackBufferSize = 3569,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	FeedbackBufferType = 3570,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	SelectionBufferSize = 3572,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	PolygonOffsetUnits = 10752,
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
	[RequiredByFeature("GL_VERSION_1_4")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_blend_color")]
	BlendColor = 32773,
	[RequiredByFeature("GL_VERSION_1_4")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_blend_minmax", Api = "gl|gles1|gles2")]
	[RequiredByFeature("GL_OES_blend_subtract", Api = "gles1")]
	BlendEquation = 32777,
	[RequiredByFeature("GL_EXT_cmyka")]
	PackCmykHintExt = 32782,
	[RequiredByFeature("GL_EXT_cmyka")]
	UnpackCmykHintExt = 32783,
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
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_convolution")]
	PostConvolutionRedScale = 32796,
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_convolution")]
	PostConvolutionGreenScale = 32797,
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_convolution")]
	PostConvolutionBlueScale = 32798,
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_convolution")]
	PostConvolutionAlphaScale = 32799,
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_convolution")]
	PostConvolutionRedBias = 32800,
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_convolution")]
	PostConvolutionGreenBias = 32801,
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_convolution")]
	PostConvolutionBlueBias = 32802,
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_convolution")]
	PostConvolutionAlphaBias = 32803,
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
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_EXT_polygon_offset")]
	PolygonOffsetFactor = 32824,
	[RequiredByFeature("GL_EXT_polygon_offset")]
	PolygonOffsetBiasExt = 32825,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_EXT_rescale_normal")]
	[RemovedByFeature("GL_VERSION_3_2")]
	RescaleNormal = 32826,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ARB_direct_state_access", Api = "gl|glcore")]
	TextureBinding1d = 32872,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_direct_state_access", Api = "gl|glcore")]
	TextureBinding2d = 32873,
	[RequiredByFeature("GL_EXT_texture_object")]
	Texture3dBindingExt = 32874,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_direct_state_access", Api = "gl|glcore")]
	[RequiredByFeature("GL_OES_texture_3D", Api = "gles2")]
	TextureBinding3d = 32874,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_EXT_texture3D")]
	PackSkipImages = 32875,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_EXT_texture3D")]
	PackImageHeight = 32876,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture3D")]
	UnpackSkipImages = 32877,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture3D")]
	UnpackImageHeight = 32878,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_sparse_texture", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture3D")]
	[RequiredByFeature("GL_OES_texture_3D", Api = "gles2")]
	Texture3d = 32879,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture3D")]
	[RequiredByFeature("GL_OES_texture_3D", Api = "gles2")]
	Max3dTextureSize = 32883,
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
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_EXT_vertex_array")]
	[RemovedByFeature("GL_VERSION_3_2")]
	VertexArraySize = 32890,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_EXT_vertex_array")]
	[RemovedByFeature("GL_VERSION_3_2")]
	VertexArrayType = 32891,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_EXT_vertex_array")]
	[RemovedByFeature("GL_VERSION_3_2")]
	VertexArrayStride = 32892,
	[RequiredByFeature("GL_EXT_vertex_array")]
	VertexArrayCountExt = 32893,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_EXT_vertex_array")]
	[RemovedByFeature("GL_VERSION_3_2")]
	NormalArrayType = 32894,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_EXT_vertex_array")]
	[RemovedByFeature("GL_VERSION_3_2")]
	NormalArrayStride = 32895,
	[RequiredByFeature("GL_EXT_vertex_array")]
	NormalArrayCountExt = 32896,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_EXT_vertex_array")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ColorArraySize = 32897,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_EXT_vertex_array")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ColorArrayType = 32898,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_EXT_vertex_array")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ColorArrayStride = 32899,
	[RequiredByFeature("GL_EXT_vertex_array")]
	ColorArrayCountExt = 32900,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_EXT_vertex_array")]
	[RemovedByFeature("GL_VERSION_3_2")]
	IndexArrayType = 32901,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_EXT_vertex_array")]
	[RemovedByFeature("GL_VERSION_3_2")]
	IndexArrayStride = 32902,
	[RequiredByFeature("GL_EXT_vertex_array")]
	IndexArrayCountExt = 32903,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_EXT_vertex_array")]
	[RemovedByFeature("GL_VERSION_3_2")]
	TextureCoordArraySize = 32904,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_EXT_vertex_array")]
	[RemovedByFeature("GL_VERSION_3_2")]
	TextureCoordArrayType = 32905,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_EXT_vertex_array")]
	[RemovedByFeature("GL_VERSION_3_2")]
	TextureCoordArrayStride = 32906,
	[RequiredByFeature("GL_EXT_vertex_array")]
	TextureCoordArrayCountExt = 32907,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_EXT_vertex_array")]
	[RemovedByFeature("GL_VERSION_3_2")]
	EdgeFlagArrayStride = 32908,
	[RequiredByFeature("GL_EXT_vertex_array")]
	EdgeFlagArrayCountExt = 32909,
	[RequiredByFeature("GL_SGIX_interlace")]
	InterlaceSgix = 32916,
	[RequiredByFeature("GL_SGIS_detail_texture")]
	DetailTexture2dBindingSgis = 32918,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ARB_multisample")]
	[RequiredByFeature("GL_EXT_multisample")]
	[RequiredByFeature("GL_EXT_multisampled_compatibility", Api = "gles2")]
	[RequiredByFeature("GL_SGIS_multisample")]
	Multisample = 32925,
	[RequiredByFeature("GL_EXT_multisample")]
	[RequiredByFeature("GL_SGIS_multisample")]
	SampleAlphaToMaskExt = 32926,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ARB_multisample")]
	[RequiredByFeature("GL_EXT_multisample")]
	[RequiredByFeature("GL_EXT_multisampled_compatibility", Api = "gles2")]
	[RequiredByFeature("GL_SGIS_multisample")]
	SampleAlphaToOne = 32927,
	[RequiredByFeature("GL_SGIS_multisample")]
	SampleMaskSgis = 32928,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_multisample")]
	[RequiredByFeature("GL_EXT_multisample")]
	[RequiredByFeature("GL_SGIS_multisample")]
	SampleBuffers = 32936,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_multisample")]
	[RequiredByFeature("GL_NV_multisample_coverage")]
	[RequiredByFeature("GL_EXT_multisample")]
	[RequiredByFeature("GL_SGIS_multisample")]
	Samples = 32937,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_multisample")]
	SampleCoverageValue = 32938,
	[RequiredByFeature("GL_SGIS_multisample")]
	SampleMaskValueSgis = 32938,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_multisample")]
	SampleCoverageInvert = 32939,
	[RequiredByFeature("GL_EXT_multisample")]
	[RequiredByFeature("GL_SGIS_multisample")]
	SamplePatternExt = 32940,
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_SGI_color_matrix")]
	ColorMatrix = 32945,
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_SGI_color_matrix")]
	ColorMatrixStackDepth = 32946,
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_SGI_color_matrix")]
	MaxColorMatrixStackDepth = 32947,
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_SGI_color_matrix")]
	PostColorMatrixRedScale = 32948,
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_SGI_color_matrix")]
	PostColorMatrixGreenScale = 32949,
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_SGI_color_matrix")]
	PostColorMatrixBlueScale = 32950,
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_SGI_color_matrix")]
	PostColorMatrixAlphaScale = 32951,
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_SGI_color_matrix")]
	PostColorMatrixRedBias = 32952,
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_SGI_color_matrix")]
	PostColorMatrixGreenBias = 32953,
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_SGI_color_matrix")]
	PostColorMatrixBlueBias = 32954,
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_SGI_color_matrix")]
	PostColorMatrixAlphaBias = 32955,
	[RequiredByFeature("GL_SGI_texture_color_table")]
	TextureColorTableSgi = 32956,
	[RequiredByFeature("GL_VERSION_1_4")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_EXT_draw_buffers_indexed", Api = "gles2")]
	[RequiredByFeature("GL_OES_draw_buffers_indexed", Api = "gles2")]
	[RequiredByFeature("GL_EXT_blend_func_separate")]
	[RequiredByFeature("GL_OES_blend_func_separate", Api = "gles1")]
	BlendDstRgb = 32968,
	[RequiredByFeature("GL_VERSION_1_4")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_EXT_draw_buffers_indexed", Api = "gles2")]
	[RequiredByFeature("GL_OES_draw_buffers_indexed", Api = "gles2")]
	[RequiredByFeature("GL_EXT_blend_func_separate")]
	[RequiredByFeature("GL_OES_blend_func_separate", Api = "gles1")]
	BlendSrcRgb = 32969,
	[RequiredByFeature("GL_VERSION_1_4")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_EXT_draw_buffers_indexed", Api = "gles2")]
	[RequiredByFeature("GL_OES_draw_buffers_indexed", Api = "gles2")]
	[RequiredByFeature("GL_EXT_blend_func_separate")]
	[RequiredByFeature("GL_OES_blend_func_separate", Api = "gles1")]
	BlendDstAlpha = 32970,
	[RequiredByFeature("GL_VERSION_1_4")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_EXT_draw_buffers_indexed", Api = "gles2")]
	[RequiredByFeature("GL_OES_draw_buffers_indexed", Api = "gles2")]
	[RequiredByFeature("GL_EXT_blend_func_separate")]
	[RequiredByFeature("GL_OES_blend_func_separate", Api = "gles1")]
	BlendSrcAlpha = 32971,
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
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_draw_range_elements")]
	MaxElementsVertices = 33000,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_draw_range_elements")]
	MaxElementsIndices = 33001,
	[RequiredByFeature("GL_VERSION_1_4")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ARB_point_parameters")]
	[RequiredByFeature("GL_EXT_point_parameters")]
	[RequiredByFeature("GL_SGIS_point_parameters")]
	[RemovedByFeature("GL_VERSION_3_2")]
	PointSizeMin = 33062,
	[RequiredByFeature("GL_VERSION_1_4")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ARB_point_parameters")]
	[RequiredByFeature("GL_EXT_point_parameters")]
	[RequiredByFeature("GL_SGIS_point_parameters")]
	[RemovedByFeature("GL_VERSION_3_2")]
	PointSizeMax = 33063,
	[RequiredByFeature("GL_VERSION_1_4")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ARB_point_parameters")]
	[RequiredByFeature("GL_EXT_point_parameters")]
	[RequiredByFeature("GL_SGIS_point_parameters")]
	PointFadeThresholdSize = 33064,
	[RequiredByFeature("GL_EXT_point_parameters")]
	[RequiredByFeature("GL_SGIS_point_parameters")]
	DistanceAttenuationExt = 33065,
	[RequiredByFeature("GL_VERSION_1_4")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ARB_point_parameters")]
	[RemovedByFeature("GL_VERSION_3_2")]
	PointDistanceAttenuation = 33065,
	[RequiredByFeature("GL_SGIS_fog_function")]
	FogFuncPointsSgis = 33067,
	[RequiredByFeature("GL_SGIS_fog_function")]
	MaxFogFuncPointsSgis = 33068,
	[RequiredByFeature("GL_SGIS_texture4D")]
	PackSkipVolumesSgis = 33072,
	[RequiredByFeature("GL_SGIS_texture4D")]
	PackImageDepthSgis = 33073,
	[RequiredByFeature("GL_SGIS_texture4D")]
	UnpackSkipVolumesSgis = 33074,
	[RequiredByFeature("GL_SGIS_texture4D")]
	UnpackImageDepthSgis = 33075,
	[RequiredByFeature("GL_SGIS_texture4D")]
	Texture4dSgis = 33076,
	[RequiredByFeature("GL_SGIS_texture4D")]
	Max4dTextureSizeSgis = 33080,
	[RequiredByFeature("GL_SGIX_pixel_texture")]
	PixelTexGenSgix = 33081,
	[RequiredByFeature("GL_SGIX_pixel_tiles")]
	PixelTileBestAlignmentSgix = 33086,
	[RequiredByFeature("GL_SGIX_pixel_tiles")]
	PixelTileCacheIncrementSgix = 33087,
	[RequiredByFeature("GL_SGIX_pixel_tiles")]
	PixelTileWidthSgix = 33088,
	[RequiredByFeature("GL_SGIX_pixel_tiles")]
	PixelTileHeightSgix = 33089,
	[RequiredByFeature("GL_SGIX_pixel_tiles")]
	PixelTileGridWidthSgix = 33090,
	[RequiredByFeature("GL_SGIX_pixel_tiles")]
	PixelTileGridHeightSgix = 33091,
	[RequiredByFeature("GL_SGIX_pixel_tiles")]
	PixelTileGridDepthSgix = 33092,
	[RequiredByFeature("GL_SGIX_pixel_tiles")]
	PixelTileCacheSizeSgix = 33093,
	[RequiredByFeature("GL_SGIX_sprite")]
	SpriteSgix = 33096,
	[RequiredByFeature("GL_SGIX_sprite")]
	SpriteModeSgix = 33097,
	[RequiredByFeature("GL_SGIX_sprite")]
	SpriteAxisSgix = 33098,
	[RequiredByFeature("GL_SGIX_sprite")]
	SpriteTranslationSgix = 33099,
	[RequiredByFeature("GL_SGIS_texture4D")]
	Texture4dBindingSgis = 33103,
	[RequiredByFeature("GL_SGIX_clipmap")]
	MaxClipmapDepthSgix = 33143,
	[RequiredByFeature("GL_SGIX_clipmap")]
	MaxClipmapVirtualDepthSgix = 33144,
	[RequiredByFeature("GL_SGIX_texture_scale_bias")]
	PostTextureFilterBiasRangeSgix = 33147,
	[RequiredByFeature("GL_SGIX_texture_scale_bias")]
	PostTextureFilterScaleRangeSgix = 33148,
	[RequiredByFeature("GL_SGIX_reference_plane")]
	ReferencePlaneSgix = 33149,
	[RequiredByFeature("GL_SGIX_reference_plane")]
	ReferencePlaneEquationSgix = 33150,
	[RequiredByFeature("GL_SGIX_ir_instrument1")]
	IrInstrument1Sgix = 33151,
	[RequiredByFeature("GL_SGIX_instruments")]
	InstrumentMeasurementsSgix = 33153,
	[RequiredByFeature("GL_SGIX_calligraphic_fragment")]
	CalligraphicFragmentSgix = 33155,
	[RequiredByFeature("GL_SGIX_framezoom")]
	FramezoomSgix = 33163,
	[RequiredByFeature("GL_SGIX_framezoom")]
	FramezoomFactorSgix = 33164,
	[RequiredByFeature("GL_SGIX_framezoom")]
	MaxFramezoomFactorSgix = 33165,
	[RequiredByFeature("GL_VERSION_1_4")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_SGIS_generate_mipmap")]
	[RemovedByFeature("GL_VERSION_3_2")]
	GenerateMipmapHint = 33170,
	[RequiredByFeature("GL_SGIX_polynomial_ffd")]
	DeformationsMaskSgix = 33174,
	[RequiredByFeature("GL_SGIX_fog_offset")]
	FogOffsetSgix = 33176,
	[RequiredByFeature("GL_SGIX_fog_offset")]
	FogOffsetValueSgix = 33177,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_EXT_separate_specular_color")]
	[RemovedByFeature("GL_VERSION_3_2")]
	LightModelColorControl = 33272,
	[RequiredByFeature("GL_EXT_shared_texture_palette")]
	SharedTexturePaletteExt = 33275,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	MajorVersion = 33307,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	MinorVersion = 33308,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	NumExtensions = 33309,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	ContextFlags = 33310,
	[RequiredByFeature("GL_VERSION_4_1")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_separate_shader_objects", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_separate_shader_objects", Api = "gl|glcore|gles2")]
	ProgramPipelineBinding = 33370,
	[RequiredByFeature("GL_VERSION_4_1")]
	[RequiredByFeature("GL_ARB_viewport_array", Api = "gl|glcore")]
	[RequiredByFeature("GL_NV_viewport_array", Api = "gles2")]
	[RequiredByFeature("GL_OES_viewport_array", Api = "gles2")]
	MaxViewports = 33371,
	[RequiredByFeature("GL_VERSION_4_1")]
	[RequiredByFeature("GL_ARB_viewport_array", Api = "gl|glcore")]
	[RequiredByFeature("GL_NV_viewport_array", Api = "gles2")]
	[RequiredByFeature("GL_OES_viewport_array", Api = "gles2")]
	ViewportSubpixelBits = 33372,
	[RequiredByFeature("GL_VERSION_4_1")]
	[RequiredByFeature("GL_ARB_viewport_array", Api = "gl|glcore")]
	[RequiredByFeature("GL_NV_viewport_array", Api = "gles2")]
	[RequiredByFeature("GL_OES_viewport_array", Api = "gles2")]
	ViewportBoundsRange = 33373,
	[RequiredByFeature("GL_VERSION_4_1")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_viewport_array", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_geometry_shader", Api = "gles2")]
	[RequiredByFeature("GL_OES_geometry_shader", Api = "gles2")]
	LayerProvokingVertex = 33374,
	[RequiredByFeature("GL_VERSION_4_1")]
	[RequiredByFeature("GL_ARB_viewport_array", Api = "gl|glcore")]
	[RequiredByFeature("GL_NV_viewport_array", Api = "gles2")]
	[RequiredByFeature("GL_OES_viewport_array", Api = "gles2")]
	ViewportIndexProvokingVertex = 33375,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_compute_shader", Api = "gl|glcore")]
	MaxComputeUniformComponents = 33379,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_compute_shader", Api = "gl|glcore")]
	MaxComputeAtomicCounterBuffers = 33380,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_compute_shader", Api = "gl|glcore")]
	MaxComputeAtomicCounters = 33381,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_compute_shader", Api = "gl|glcore")]
	MaxCombinedComputeUniformComponents = 33382,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	MaxDebugGroupStackDepth = 33388,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	DebugGroupStackDepth = 33389,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_explicit_uniform_location", Api = "gl|glcore")]
	MaxUniformLocations = 33390,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_vertex_attrib_binding", Api = "gl|glcore")]
	VertexBindingDivisor = 33494,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_vertex_attrib_binding", Api = "gl|glcore")]
	VertexBindingOffset = 33495,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_vertex_attrib_binding", Api = "gl|glcore")]
	VertexBindingStride = 33496,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_vertex_attrib_binding", Api = "gl|glcore")]
	MaxVertexAttribRelativeOffset = 33497,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_vertex_attrib_binding", Api = "gl|glcore")]
	MaxVertexAttribBindings = 33498,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	MaxLabelLength = 33512,
	[RequiredByFeature("GL_SGIX_convolution_accuracy")]
	ConvolutionHintSgix = 33558,
	[RequiredByFeature("GL_SGIX_async")]
	AsyncMarkerSgix = 33577,
	[RequiredByFeature("GL_SGIX_pixel_texture")]
	PixelTexGenModeSgix = 33579,
	[RequiredByFeature("GL_SGIX_async_histogram")]
	AsyncHistogramSgix = 33580,
	[RequiredByFeature("GL_SGIX_async_histogram")]
	MaxAsyncHistogramSgix = 33581,
	[RequiredByFeature("GL_SGIS_pixel_texture")]
	PixelTextureSgis = 33619,
	[RequiredByFeature("GL_SGIX_async_pixel")]
	AsyncTexImageSgix = 33628,
	[RequiredByFeature("GL_SGIX_async_pixel")]
	AsyncDrawPixelsSgix = 33629,
	[RequiredByFeature("GL_SGIX_async_pixel")]
	AsyncReadPixelsSgix = 33630,
	[RequiredByFeature("GL_SGIX_async_pixel")]
	MaxAsyncTexImageSgix = 33631,
	[RequiredByFeature("GL_SGIX_async_pixel")]
	MaxAsyncDrawPixelsSgix = 33632,
	[RequiredByFeature("GL_SGIX_async_pixel")]
	MaxAsyncReadPixelsSgix = 33633,
	[RequiredByFeature("GL_SGIX_vertex_preclip")]
	VertexPreclipSgix = 33774,
	[RequiredByFeature("GL_SGIX_vertex_preclip")]
	VertexPreclipHintSgix = 33775,
	[RequiredByFeature("GL_SGIX_fragment_lighting")]
	FragmentLightingSgix = 33792,
	[RequiredByFeature("GL_SGIX_fragment_lighting")]
	FragmentColorMaterialSgix = 33793,
	[RequiredByFeature("GL_SGIX_fragment_lighting")]
	FragmentColorMaterialFaceSgix = 33794,
	[RequiredByFeature("GL_SGIX_fragment_lighting")]
	FragmentColorMaterialParameterSgix = 33795,
	[RequiredByFeature("GL_SGIX_fragment_lighting")]
	MaxFragmentLightsSgix = 33796,
	[RequiredByFeature("GL_SGIX_fragment_lighting")]
	MaxActiveLightsSgix = 33797,
	[RequiredByFeature("GL_SGIX_fragment_lighting")]
	LightEnvModeSgix = 33799,
	[RequiredByFeature("GL_SGIX_fragment_lighting")]
	FragmentLightModelLocalViewerSgix = 33800,
	[RequiredByFeature("GL_SGIX_fragment_lighting")]
	FragmentLightModelTwoSideSgix = 33801,
	[RequiredByFeature("GL_SGIX_fragment_lighting")]
	FragmentLightModelAmbientSgix = 33802,
	[RequiredByFeature("GL_SGIX_fragment_lighting")]
	FragmentLightModelNormalInterpolationSgix = 33803,
	[RequiredByFeature("GL_SGIX_fragment_lighting")]
	FragmentLight0Sgix = 33804,
	[RequiredByFeature("GL_SGIX_resample")]
	PackResampleSgix = 33838,
	[RequiredByFeature("GL_SGIX_resample")]
	UnpackResampleSgix = 33839,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RemovedByFeature("GL_VERSION_3_2")]
	AliasedPointSizeRange = 33901,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	AliasedLineWidthRange = 33902,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_multitexture")]
	ActiveTexture = 34016,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	[RequiredByFeature("GL_OES_framebuffer_object", Api = "gles1")]
	MaxRenderbufferSize = 34024,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_ARB_texture_compression")]
	TextureCompressionHint = 34031,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ARB_direct_state_access", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_texture_rectangle")]
	[RequiredByFeature("GL_NV_texture_rectangle")]
	TextureBindingRectangle = 34038,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ARB_texture_rectangle")]
	[RequiredByFeature("GL_NV_texture_rectangle")]
	MaxRectangleTextureSize = 34040,
	[RequiredByFeature("GL_VERSION_1_4")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_lod_bias", Api = "gl|gles1")]
	MaxTextureLodBias = 34045,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_direct_state_access", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_texture_cube_map")]
	[RequiredByFeature("GL_EXT_texture_cube_map")]
	[RequiredByFeature("GL_OES_texture_cube_map", Api = "gles1")]
	TextureBindingCubeMap = 34068,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_cube_map")]
	[RequiredByFeature("GL_EXT_texture_cube_map")]
	[RequiredByFeature("GL_OES_texture_cube_map", Api = "gles1")]
	MaxCubeMapTextureSize = 34076,
	[RequiredByFeature("GL_SGIX_subsample")]
	PackSubsampleRateSgix = 34208,
	[RequiredByFeature("GL_SGIX_subsample")]
	UnpackSubsampleRateSgix = 34209,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_vertex_array_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_APPLE_vertex_array_object")]
	[RequiredByFeature("GL_OES_vertex_array_object", Api = "gles1|gles2")]
	VertexArrayBinding = 34229,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ARB_vertex_program")]
	[RequiredByFeature("GL_ARB_vertex_shader")]
	[RequiredByFeature("GL_NV_vertex_program")]
	VertexProgramPointSize = 34370,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_texture_compression")]
	NumCompressedTextureFormats = 34466,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_texture_compression")]
	CompressedTextureFormats = 34467,
	[RequiredByFeature("GL_VERSION_4_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_get_program_binary", Api = "gl|glcore")]
	[RequiredByFeature("GL_OES_get_program_binary", Api = "gles2")]
	NumProgramBinaryFormats = 34814,
	[RequiredByFeature("GL_VERSION_4_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_get_program_binary", Api = "gl|glcore")]
	[RequiredByFeature("GL_OES_get_program_binary", Api = "gles2")]
	ProgramBinaryFormats = 34815,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ATI_separate_stencil")]
	StencilBackFunc = 34816,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ATI_separate_stencil")]
	StencilBackFail = 34817,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ATI_separate_stencil")]
	StencilBackPassDepthFail = 34818,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ATI_separate_stencil")]
	StencilBackPassDepthPass = 34819,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_draw_buffers")]
	[RequiredByFeature("GL_ATI_draw_buffers")]
	[RequiredByFeature("GL_EXT_draw_buffers", Api = "gles2")]
	[RequiredByFeature("GL_NV_draw_buffers", Api = "gles2")]
	MaxDrawBuffers = 34852,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_EXT_draw_buffers_indexed", Api = "gles2")]
	[RequiredByFeature("GL_OES_draw_buffers_indexed", Api = "gles2")]
	[RequiredByFeature("GL_EXT_blend_equation_separate")]
	[RequiredByFeature("GL_OES_blend_equation_separate", Api = "gles1")]
	BlendEquationAlpha = 34877,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_vertex_program")]
	[RequiredByFeature("GL_ARB_vertex_shader")]
	MaxVertexAttribs = 34921,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_fragment_program")]
	[RequiredByFeature("GL_ARB_vertex_shader")]
	[RequiredByFeature("GL_NV_fragment_program")]
	MaxTextureImageUnits = 34930,
	[RequiredByFeature("GL_VERSION_1_5")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_vertex_buffer_object")]
	ArrayBufferBinding = 34964,
	[RequiredByFeature("GL_VERSION_1_5")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_vertex_buffer_object")]
	ElementArrayBufferBinding = 34965,
	[RequiredByFeature("GL_VERSION_2_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_pixel_buffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_pixel_buffer_object")]
	[RequiredByFeature("GL_NV_pixel_buffer_object", Api = "gles2")]
	PixelPackBufferBinding = 35053,
	[RequiredByFeature("GL_VERSION_2_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_pixel_buffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_pixel_buffer_object")]
	[RequiredByFeature("GL_NV_pixel_buffer_object", Api = "gles2")]
	PixelUnpackBufferBinding = 35055,
	[RequiredByFeature("GL_VERSION_3_3")]
	[RequiredByFeature("GL_ARB_blend_func_extended", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_blend_func_extended", Api = "gles2")]
	MaxDualSourceDrawBuffers = 35068,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_array")]
	MaxArrayTextureLayers = 35071,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_gpu_shader4")]
	[RequiredByFeature("GL_NV_gpu_program4")]
	MinProgramTexelOffset = 35076,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_gpu_shader4")]
	[RequiredByFeature("GL_NV_gpu_program4")]
	MaxProgramTexelOffset = 35077,
	[RequiredByFeature("GL_VERSION_3_3")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_sampler_objects", Api = "gl|glcore")]
	SamplerBinding = 35097,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	FragmentShaderAti = 35104,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
	UniformBufferBinding = 35368,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
	UniformBufferStart = 35369,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
	UniformBufferSize = 35370,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
	MaxVertexUniformBlocks = 35371,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_geometry_shader", Api = "gles2")]
	[RequiredByFeature("GL_OES_geometry_shader", Api = "gles2")]
	MaxGeometryUniformBlocks = 35372,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
	MaxFragmentUniformBlocks = 35373,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
	MaxCombinedUniformBlocks = 35374,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
	MaxUniformBufferBindings = 35375,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
	MaxUniformBlockSize = 35376,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
	MaxCombinedVertexUniformComponents = 35377,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_geometry_shader", Api = "gles2")]
	[RequiredByFeature("GL_OES_geometry_shader", Api = "gles2")]
	MaxCombinedGeometryUniformComponents = 35378,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
	MaxCombinedFragmentUniformComponents = 35379,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
	UniformBufferOffsetAlignment = 35380,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_fragment_shader")]
	MaxFragmentUniformComponents = 35657,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_vertex_shader")]
	MaxVertexUniformComponents = 35658,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ARB_vertex_shader")]
	MaxVaryingFloats = 35659,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_vertex_shader")]
	[RequiredByFeature("GL_NV_vertex_program3")]
	MaxVertexTextureImageUnits = 35660,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_vertex_shader")]
	MaxCombinedTextureImageUnits = 35661,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_fragment_shader")]
	[RequiredByFeature("GL_OES_standard_derivatives", Api = "gles2|glsc2")]
	FragmentShaderDerivativeHint = 35723,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	CurrentProgram = 35725,
	[RequiredByFeature("GL_VERSION_4_1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_ES2_compatibility", Api = "gl|glcore")]
	[RequiredByFeature("GL_OES_read_format", Api = "gl|gles1")]
	ImplementationColorReadType = 35738,
	[RequiredByFeature("GL_VERSION_4_1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_ES2_compatibility", Api = "gl|glcore")]
	[RequiredByFeature("GL_OES_read_format", Api = "gl|gles1")]
	ImplementationColorReadFormat = 35739,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ARB_direct_state_access", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_texture_array")]
	TextureBinding1dArray = 35868,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_direct_state_access", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_texture_array")]
	TextureBinding2dArray = 35869,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_geometry_shader4", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_geometry_shader", Api = "gles2")]
	[RequiredByFeature("GL_EXT_geometry_shader4")]
	[RequiredByFeature("GL_NV_geometry_program4")]
	[RequiredByFeature("GL_OES_geometry_shader", Api = "gles2")]
	MaxGeometryTextureImageUnits = 35881,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_buffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_texture_buffer", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_buffer_object")]
	[RequiredByFeature("GL_OES_texture_buffer", Api = "gles2")]
	MaxTextureBufferSize = 35883,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_direct_state_access", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_texture_buffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_texture_buffer", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_buffer_object")]
	[RequiredByFeature("GL_OES_texture_buffer", Api = "gles2")]
	TextureBindingBuffer = 35884,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_transform_feedback")]
	[RequiredByFeature("GL_NV_transform_feedback")]
	TransformFeedbackBufferStart = 35972,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_transform_feedback")]
	[RequiredByFeature("GL_NV_transform_feedback")]
	TransformFeedbackBufferSize = 35973,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_transform_feedback")]
	[RequiredByFeature("GL_NV_transform_feedback")]
	TransformFeedbackBufferBinding = 35983,
	[RequiredByFeature("GL_QCOM_motion_estimation", Api = "gles2")]
	MotionEstimationSearchBlockXQcom = 35984,
	[RequiredByFeature("GL_QCOM_motion_estimation", Api = "gles2")]
	MotionEstimationSearchBlockYQcom = 35985,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	StencilBackRef = 36003,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	StencilBackValueMask = 36004,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	StencilBackWritemask = 36005,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_ANGLE_framebuffer_blit", Api = "gles2")]
	[RequiredByFeature("GL_APPLE_framebuffer_multisample", Api = "gles1|gles2")]
	[RequiredByFeature("GL_EXT_framebuffer_blit")]
	[RequiredByFeature("GL_NV_framebuffer_blit", Api = "gles2")]
	DrawFramebufferBinding = 36006,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	[RequiredByFeature("GL_OES_framebuffer_object", Api = "gles1")]
	RenderbufferBinding = 36007,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_ANGLE_framebuffer_blit", Api = "gles2")]
	[RequiredByFeature("GL_APPLE_framebuffer_multisample", Api = "gles1|gles2")]
	[RequiredByFeature("GL_EXT_framebuffer_blit")]
	[RequiredByFeature("GL_NV_framebuffer_blit", Api = "gles2")]
	ReadFramebufferBinding = 36010,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_draw_buffers", Api = "gles2")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	[RequiredByFeature("GL_NV_fbo_color_attachments", Api = "gles2")]
	MaxColorAttachments = 36063,
	[RequiredByFeature("GL_OES_texture_cube_map", Api = "gles1")]
	TextureGenStrOes = 36192,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_ES3_compatibility", Api = "gl|glcore")]
	MaxElementIndex = 36203,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_geometry_shader4", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_geometry_shader", Api = "gles2")]
	[RequiredByFeature("GL_EXT_geometry_shader4")]
	[RequiredByFeature("GL_OES_geometry_shader", Api = "gles2")]
	MaxGeometryUniformComponents = 36319,
	[RequiredByFeature("GL_VERSION_4_1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_ES2_compatibility", Api = "gl|glcore")]
	ShaderBinaryFormats = 36344,
	[RequiredByFeature("GL_VERSION_4_1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_ES2_compatibility", Api = "gl|glcore")]
	NumShaderBinaryFormats = 36345,
	[RequiredByFeature("GL_VERSION_4_1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_ES2_compatibility", Api = "gl|glcore")]
	ShaderCompiler = 36346,
	[RequiredByFeature("GL_VERSION_4_1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_ES2_compatibility", Api = "gl|glcore")]
	MaxVertexUniformVectors = 36347,
	[RequiredByFeature("GL_VERSION_4_1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_ES2_compatibility", Api = "gl|glcore")]
	MaxVaryingVectors = 36348,
	[RequiredByFeature("GL_VERSION_4_1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_ES2_compatibility", Api = "gl|glcore")]
	MaxFragmentUniformVectors = 36349,
	[RequiredByFeature("GL_VERSION_3_3")]
	[RequiredByFeature("GL_ARB_timer_query", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_disjoint_timer_query", Api = "gles2")]
	Timestamp = 36392,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ARB_provoking_vertex", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_viewport_array", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_provoking_vertex")]
	ProvokingVertex = 36431,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_multisample", Api = "gl|glcore")]
	[RequiredByFeature("GL_NV_explicit_multisample")]
	MaxSampleMaskWords = 36441,
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
	[RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
	MaxTessControlUniformBlocks = 36489,
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
	[RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
	MaxTessEvaluationUniformBlocks = 36490,
	[RequiredByFeature("GL_ARM_shader_framebuffer_fetch", Api = "gles2")]
	FetchPerSampleArm = 36709,
	[RequiredByFeature("GL_ARM_shader_framebuffer_fetch", Api = "gles2")]
	FragmentShaderFramebufferFetchMrtArm = 36710,
	[RequiredByFeature("GL_EXT_fragment_shading_rate", Api = "gles2")]
	FragmentShadingRateNonTrivialCombinersSupportedExt = 36719,
	[RequiredByFeature("GL_VERSION_3_1")]
	PrimitiveRestartIndex = 36766,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ARB_map_buffer_alignment", Api = "gl|glcore")]
	MinMapBufferAlignment = 37052,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_storage_buffer_object", Api = "gl|glcore")]
	ShaderStorageBufferBinding = 37075,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_storage_buffer_object", Api = "gl|glcore")]
	ShaderStorageBufferStart = 37076,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_storage_buffer_object", Api = "gl|glcore")]
	ShaderStorageBufferSize = 37077,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_storage_buffer_object", Api = "gl|glcore")]
	MaxVertexShaderStorageBlocks = 37078,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_storage_buffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_geometry_shader", Api = "gles2")]
	[RequiredByFeature("GL_OES_geometry_shader", Api = "gles2")]
	MaxGeometryShaderStorageBlocks = 37079,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_storage_buffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
	[RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
	MaxTessControlShaderStorageBlocks = 37080,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_storage_buffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
	[RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
	MaxTessEvaluationShaderStorageBlocks = 37081,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_storage_buffer_object", Api = "gl|glcore")]
	MaxFragmentShaderStorageBlocks = 37082,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_storage_buffer_object", Api = "gl|glcore")]
	MaxComputeShaderStorageBlocks = 37083,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_storage_buffer_object", Api = "gl|glcore")]
	MaxCombinedShaderStorageBlocks = 37084,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_storage_buffer_object", Api = "gl|glcore")]
	MaxShaderStorageBufferBindings = 37085,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_storage_buffer_object", Api = "gl|glcore")]
	ShaderStorageBufferOffsetAlignment = 37087,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_compute_shader", Api = "gl|glcore")]
	MaxComputeWorkGroupInvocations = 37099,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_compute_shader", Api = "gl|glcore")]
	DispatchIndirectBufferBinding = 37103,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_direct_state_access", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_texture_multisample", Api = "gl|glcore")]
	TextureBinding2dMultisample = 37124,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_direct_state_access", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_texture_multisample", Api = "gl|glcore")]
	[RequiredByFeature("GL_OES_texture_storage_multisample_2d_array", Api = "gles2")]
	TextureBinding2dMultisampleArray = 37125,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_multisample", Api = "gl|glcore")]
	MaxColorTextureSamples = 37134,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_multisample", Api = "gl|glcore")]
	MaxDepthTextureSamples = 37135,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_multisample", Api = "gl|glcore")]
	MaxIntegerSamples = 37136,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_sync", Api = "gl|glcore")]
	[RequiredByFeature("GL_APPLE_sync", Api = "gles1|gles2")]
	MaxServerWaitTimeout = 37137,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	MaxVertexOutputComponents = 37154,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_EXT_geometry_shader", Api = "gles2")]
	[RequiredByFeature("GL_OES_geometry_shader", Api = "gles2")]
	MaxGeometryInputComponents = 37155,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_EXT_geometry_shader", Api = "gles2")]
	[RequiredByFeature("GL_OES_geometry_shader", Api = "gles2")]
	MaxGeometryOutputComponents = 37156,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	MaxFragmentInputComponents = 37157,
	[RequiredByFeature("GL_VERSION_3_2")]
	ContextProfileMask = 37158,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_buffer_range", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_texture_buffer", Api = "gles2")]
	[RequiredByFeature("GL_OES_texture_buffer", Api = "gles2")]
	TextureBufferOffsetAlignment = 37279,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_compute_shader", Api = "gl|glcore")]
	MaxComputeUniformBlocks = 37307,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_compute_shader", Api = "gl|glcore")]
	MaxComputeTextureImageUnits = 37308,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_compute_shader", Api = "gl|glcore")]
	MaxComputeWorkGroupCount = 37310,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_compute_shader", Api = "gl|glcore")]
	MaxComputeWorkGroupSize = 37311,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_atomic_counters", Api = "gl|glcore")]
	MaxVertexAtomicCounters = 37586,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_atomic_counters", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
	[RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
	MaxTessControlAtomicCounters = 37587,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_atomic_counters", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
	[RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
	MaxTessEvaluationAtomicCounters = 37588,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_atomic_counters", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_geometry_shader", Api = "gles2")]
	[RequiredByFeature("GL_OES_geometry_shader", Api = "gles2")]
	MaxGeometryAtomicCounters = 37589,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_atomic_counters", Api = "gl|glcore")]
	MaxFragmentAtomicCounters = 37590,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_atomic_counters", Api = "gl|glcore")]
	MaxCombinedAtomicCounters = 37591,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_no_attachments", Api = "gl|glcore")]
	MaxFramebufferWidth = 37653,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_no_attachments", Api = "gl|glcore")]
	MaxFramebufferHeight = 37654,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_no_attachments", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_geometry_shader", Api = "gles2")]
	[RequiredByFeature("GL_OES_geometry_shader", Api = "gles2")]
	MaxFramebufferLayers = 37655,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_no_attachments", Api = "gl|glcore")]
	MaxFramebufferSamples = 37656,
	[RequiredByFeature("GL_EXT_memory_object", Api = "gl|gles2")]
	[RequiredByFeature("GL_EXT_semaphore", Api = "gl|gles2")]
	NumDeviceUuidsExt = 38294,
	[RequiredByFeature("GL_EXT_memory_object", Api = "gl|gles2")]
	[RequiredByFeature("GL_EXT_semaphore", Api = "gl|gles2")]
	DeviceUuidExt = 38295,
	[RequiredByFeature("GL_EXT_memory_object", Api = "gl|gles2")]
	[RequiredByFeature("GL_EXT_semaphore", Api = "gl|gles2")]
	DriverUuidExt = 38296,
	[RequiredByFeature("GL_EXT_memory_object_win32", Api = "gl|gles2")]
	[RequiredByFeature("GL_EXT_semaphore_win32", Api = "gl|gles2")]
	DeviceLuidExt = 38297,
	[RequiredByFeature("GL_EXT_memory_object_win32", Api = "gl|gles2")]
	[RequiredByFeature("GL_EXT_semaphore_win32", Api = "gl|gles2")]
	DeviceNodeMaskExt = 38298,
	[RequiredByFeature("GL_NV_primitive_shading_rate", Api = "gl|glcore|gles2")]
	ShadingRateImagePerPrimitiveNv = 38321,
	[RequiredByFeature("GL_NV_primitive_shading_rate", Api = "gl|glcore|gles2")]
	ShadingRateImagePaletteCountNv = 38322,
	[RequiredByFeature("GL_NV_timeline_semaphore", Api = "gl|gles2")]
	MaxTimelineSemaphoreValueDifferenceNv = 38326,
	[RequiredByFeature("GL_QCOM_shader_framebuffer_fetch_noncoherent", Api = "gles2")]
	FramebufferFetchNoncoherentQcom = 38562,
	[RequiredByFeature("GL_QCOM_shading_rate", Api = "gles2")]
	ShadingRateQcom = 38564,
	[RequiredByFeature("GL_EXT_fragment_shading_rate", Api = "gles2")]
	ShadingRateExt = 38608,
	[RequiredByFeature("GL_EXT_fragment_shading_rate", Api = "gles2")]
	MinFragmentShadingRateAttachmentTexelWidthExt = 38615,
	[RequiredByFeature("GL_EXT_fragment_shading_rate", Api = "gles2")]
	MaxFragmentShadingRateAttachmentTexelWidthExt = 38616,
	[RequiredByFeature("GL_EXT_fragment_shading_rate", Api = "gles2")]
	MinFragmentShadingRateAttachmentTexelHeightExt = 38617,
	[RequiredByFeature("GL_EXT_fragment_shading_rate", Api = "gles2")]
	MaxFragmentShadingRateAttachmentTexelHeightExt = 38618,
	[RequiredByFeature("GL_EXT_fragment_shading_rate", Api = "gles2")]
	MaxFragmentShadingRateAttachmentTexelAspectRatioExt = 38619,
	[RequiredByFeature("GL_EXT_fragment_shading_rate", Api = "gles2")]
	MaxFragmentShadingRateAttachmentLayersExt = 38620,
	[RequiredByFeature("GL_EXT_fragment_shading_rate", Api = "gles2")]
	FragmentShadingRateWithShaderDepthStencilWritesSupportedExt = 38621,
	[RequiredByFeature("GL_EXT_fragment_shading_rate", Api = "gles2")]
	FragmentShadingRateWithSampleMaskSupportedExt = 38622,
	[RequiredByFeature("GL_EXT_fragment_shading_rate", Api = "gles2")]
	FragmentShadingRateAttachmentWithDefaultFramebufferSupportedExt = 38623,
	[RequiredByFeature("GL_VERSION_4_3")]
	NumShadingLanguageVersions = 33513
}
