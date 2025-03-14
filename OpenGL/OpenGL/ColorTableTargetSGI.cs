using Khronos;

namespace OpenGL;

public enum ColorTableTargetSGI
{
	[RequiredByFeature("GL_SGI_texture_color_table")]
	TextureColorTableSgi = 32956,
	[RequiredByFeature("GL_SGI_texture_color_table")]
	ProxyTextureColorTableSgi = 32957,
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
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_SGI_color_table")]
	ProxyColorTable = 32979,
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_SGI_color_table")]
	ProxyPostConvolutionColorTable = 32980,
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_SGI_color_table")]
	ProxyPostColorMatrixColorTable = 32981
}
