using Khronos;

namespace OpenGL;

public enum SamplerParameterF
{
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_border_clamp", Api = "gles2")]
	[RequiredByFeature("GL_NV_texture_border_clamp", Api = "gles2")]
	[RequiredByFeature("GL_OES_texture_border_clamp", Api = "gles2")]
	TextureBorderColor = 4100,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_SGIS_texture_lod")]
	TextureMinLod = 33082,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_SGIS_texture_lod")]
	TextureMaxLod = 33083,
	[RequiredByFeature("GL_VERSION_4_6")]
	[RequiredByFeature("GL_ARB_texture_filter_anisotropic", Api = "gl|glcore")]
	TextureMaxAnisotropy = 34046,
	[RequiredByFeature("GL_VERSION_1_4")]
	[RequiredByFeature("GL_EXT_texture_lod_bias", Api = "gl|gles1")]
	TextureLodBias = 34049,
	[RequiredByFeature("GL_ARM_texture_unnormalized_coordinates", Api = "gles2")]
	TextureUnnormalizedCoordinatesArm = 36714
}
