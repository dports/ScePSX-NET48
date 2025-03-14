using Khronos;

namespace OpenGL;

public enum InternalFormatPName
{
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
	[RequiredByFeature("GL_VERSION_1_4")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_SGIS_generate_mipmap")]
	[RemovedByFeature("GL_VERSION_3_2")]
	GenerateMipmap = 33169,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	InternalformatSupported = 33391,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	InternalformatPreferred = 33392,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	InternalformatRedSize = 33393,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	InternalformatGreenSize = 33394,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	InternalformatBlueSize = 33395,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	InternalformatAlphaSize = 33396,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	InternalformatDepthSize = 33397,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	InternalformatStencilSize = 33398,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	InternalformatSharedSize = 33399,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	InternalformatRedType = 33400,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	InternalformatGreenType = 33401,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	InternalformatBlueType = 33402,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	InternalformatAlphaType = 33403,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	InternalformatDepthType = 33404,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	InternalformatStencilType = 33405,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	MaxWidth = 33406,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	MaxHeight = 33407,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	MaxDepth = 33408,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	MaxLayers = 33409,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	ColorComponents = 33411,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	ColorRenderable = 33414,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	DepthRenderable = 33415,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	StencilRenderable = 33416,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	FramebufferRenderable = 33417,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	FramebufferRenderableLayered = 33418,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	FramebufferBlend = 33419,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	ReadPixels = 33420,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	ReadPixelsFormat = 33421,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	ReadPixelsType = 33422,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	TextureImageFormat = 33423,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	TextureImageType = 33424,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	GetTextureImageFormat = 33425,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	GetTextureImageType = 33426,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	Mipmap = 33427,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	AutoGenerateMipmap = 33429,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	ColorEncoding = 33430,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	SrgbRead = 33431,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	SrgbWrite = 33432,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	Filter = 33434,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	VertexTexture = 33435,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	TessControlTexture = 33436,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	TessEvaluationTexture = 33437,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	GeometryTexture = 33438,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	FragmentTexture = 33439,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	ComputeTexture = 33440,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	TextureShadow = 33441,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	TextureGather = 33442,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	TextureGatherShadow = 33443,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	ShaderImageLoad = 33444,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	ShaderImageStore = 33445,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	ShaderImageAtomic = 33446,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	ImageTexelSize = 33447,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	ImageCompatibilityClass = 33448,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	ImagePixelFormat = 33449,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	ImagePixelType = 33450,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	SimultaneousTextureAndDepthTest = 33452,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	SimultaneousTextureAndStencilTest = 33453,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	SimultaneousTextureAndDepthWrite = 33454,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	SimultaneousTextureAndStencilWrite = 33455,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	TextureCompressedBlockWidth = 33457,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	TextureCompressedBlockHeight = 33458,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	TextureCompressedBlockSize = 33459,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	ClearBuffer = 33460,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	TextureView = 33461,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	ViewCompatibilityClass = 33462,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_texture_compression")]
	TextureCompressed = 34465,
	[RequiredByFeature("GL_EXT_texture_storage_compression", Api = "gles2")]
	NumSurfaceCompressionFixedRatesExt = 36718,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	ImageFormatCompatibilityType = 37063,
	[RequiredByFeature("GL_VERSION_4_4")]
	[RequiredByFeature("GL_ARB_clear_texture", Api = "gl|glcore")]
	ClearTexture = 37733,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_internalformat_query", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	NumSampleCounts = 37760
}
