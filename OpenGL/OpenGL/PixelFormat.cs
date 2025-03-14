using Khronos;

namespace OpenGL;

public enum PixelFormat
{
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ANGLE_depth_texture", Api = "gles2")]
	[RequiredByFeature("GL_OES_depth_texture", Api = "gles2")]
	UnsignedShort = 5123,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ANGLE_depth_texture", Api = "gles2")]
	[RequiredByFeature("GL_OES_depth_texture", Api = "gles2")]
	[RequiredByFeature("GL_OES_element_index_uint", Api = "gles1|gles2")]
	UnsignedInt = 5125,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ColorIndex = 6400,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_4_4")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_stencil8", Api = "gl|glcore")]
	[RequiredByFeature("GL_OES_texture_stencil8", Api = "gles2")]
	StencilIndex = 6401,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_ANGLE_depth_texture", Api = "gles2")]
	[RequiredByFeature("GL_OES_depth_texture", Api = "gles2")]
	DepthComponent = 6402,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_AMD_interleaved_elements")]
	[RequiredByFeature("GL_EXT_texture_rg", Api = "gles2")]
	[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
	Red = 6403,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_AMD_interleaved_elements")]
	[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
	Green = 6404,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_AMD_interleaved_elements")]
	[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
	Blue = 6405,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_AMD_interleaved_elements")]
	Alpha = 6406,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	Rgb = 6407,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	Rgba = 6408,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Luminance = 6409,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RemovedByFeature("GL_VERSION_3_2")]
	LuminanceAlpha = 6410,
	[RequiredByFeature("GL_EXT_abgr")]
	AbgrExt = 32768,
	[RequiredByFeature("GL_EXT_cmyka")]
	CmykExt = 32780,
	[RequiredByFeature("GL_EXT_cmyka")]
	CmykaExt = 32781,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_EXT_bgra")]
	[RequiredByFeature("GL_MESA_bgra", Api = "gles2")]
	Bgr = 32992,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_ARB_vertex_array_bgra", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_vertex_array_bgra")]
	[RequiredByFeature("GL_APPLE_texture_format_BGRA8888", Api = "gles1|gles2")]
	[RequiredByFeature("GL_EXT_bgra")]
	[RequiredByFeature("GL_EXT_read_format_bgra", Api = "gles1|gles2")]
	[RequiredByFeature("GL_EXT_texture_format_BGRA8888", Api = "gles1|gles2")]
	[RequiredByFeature("GL_MESA_bgra", Api = "gles2")]
	[RequiredByFeature("GL_IMG_read_format", Api = "gles1|gles2")]
	Bgra = 32993,
	[RequiredByFeature("GL_SGIX_ycrcb")]
	Ycrcb422Sgix = 33211,
	[RequiredByFeature("GL_SGIX_ycrcb")]
	Ycrcb444Sgix = 33212,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_texture_rg", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_texture_rg", Api = "gles2")]
	Rg = 33319,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_rg", Api = "gl|glcore")]
	RgInteger = 33320,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_packed_depth_stencil")]
	[RequiredByFeature("GL_NV_packed_depth_stencil")]
	[RequiredByFeature("GL_ANGLE_depth_texture", Api = "gles2")]
	[RequiredByFeature("GL_OES_packed_depth_stencil", Api = "gles1|gles2")]
	DepthStencil = 34041,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_integer")]
	RedInteger = 36244,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_EXT_texture_integer")]
	GreenInteger = 36245,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_EXT_texture_integer")]
	BlueInteger = 36246,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_integer")]
	RgbInteger = 36248,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_integer")]
	RgbaInteger = 36249,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_EXT_texture_integer")]
	BgrInteger = 36250,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_EXT_texture_integer")]
	BgraInteger = 36251
}
