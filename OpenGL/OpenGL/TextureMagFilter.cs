using System;
using Khronos;

namespace OpenGL;

[Flags]
public enum TextureMagFilter : uint
{
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	Nearest = 0x2600u,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	Linear = 0x2601u,
	[RequiredByFeature("GL_SGIS_detail_texture")]
	LinearDetailSgis = 0x8097u,
	[RequiredByFeature("GL_SGIS_detail_texture")]
	LinearDetailAlphaSgis = 0x8098u,
	[RequiredByFeature("GL_SGIS_detail_texture")]
	LinearDetailColorSgis = 0x8099u,
	[RequiredByFeature("GL_SGIS_sharpen_texture")]
	LinearSharpenSgis = 0x80ADu,
	[RequiredByFeature("GL_SGIS_sharpen_texture")]
	LinearSharpenAlphaSgis = 0x80AEu,
	[RequiredByFeature("GL_SGIS_sharpen_texture")]
	LinearSharpenColorSgis = 0x80AFu,
	[RequiredByFeature("GL_SGIS_texture_filter4")]
	Filter4Sgis = 0x8146u
}
