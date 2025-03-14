using System;
using Khronos;

namespace OpenGL;

[Flags]
public enum TextureMinFilter : uint
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
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	NearestMipmapNearest = 0x2700u,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	LinearMipmapNearest = 0x2701u,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	NearestMipmapLinear = 0x2702u,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	LinearMipmapLinear = 0x2703u,
	[RequiredByFeature("GL_SGIS_texture_filter4")]
	Filter4Sgis = 0x8146u,
	[RequiredByFeature("GL_SGIX_clipmap")]
	LinearClipmapLinearSgix = 0x8170u,
	[RequiredByFeature("GL_SGIX_clipmap")]
	NearestClipmapNearestSgix = 0x844Du,
	[RequiredByFeature("GL_SGIX_clipmap")]
	NearestClipmapLinearSgix = 0x844Eu,
	[RequiredByFeature("GL_SGIX_clipmap")]
	LinearClipmapNearestSgix = 0x844Fu
}
