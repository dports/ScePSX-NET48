using Khronos;

namespace OpenGL;

public enum TextureTarget
{
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
	[RequiredByFeature("GL_EXT_texture")]
	ProxyTexture1d = 32867,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_EXT_texture")]
	ProxyTexture2d = 32868,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_sparse_texture", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture3D")]
	[RequiredByFeature("GL_OES_texture_3D", Api = "gles2")]
	Texture3d = 32879,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_EXT_texture3D")]
	ProxyTexture3d = 32880,
	[RequiredByFeature("GL_SGIS_detail_texture")]
	DetailTexture2dSgis = 32917,
	[RequiredByFeature("GL_SGIS_texture4D")]
	Texture4dSgis = 33076,
	[RequiredByFeature("GL_SGIS_texture4D")]
	ProxyTexture4dSgis = 33077,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_texture_rectangle")]
	[RequiredByFeature("GL_NV_texture_rectangle")]
	TextureRectangle = 34037,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ARB_texture_rectangle")]
	[RequiredByFeature("GL_NV_texture_rectangle")]
	ProxyTextureRectangle = 34039,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_sparse_texture", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_cube_map")]
	[RequiredByFeature("GL_EXT_texture_cube_map")]
	[RequiredByFeature("GL_OES_texture_cube_map", Api = "gles1")]
	TextureCubeMap = 34067,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_cube_map")]
	[RequiredByFeature("GL_EXT_texture_cube_map")]
	[RequiredByFeature("GL_OES_texture_cube_map", Api = "gles1")]
	TextureCubeMapPositiveX = 34069,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_cube_map")]
	[RequiredByFeature("GL_EXT_texture_cube_map")]
	[RequiredByFeature("GL_OES_texture_cube_map", Api = "gles1")]
	TextureCubeMapNegativeX = 34070,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_cube_map")]
	[RequiredByFeature("GL_EXT_texture_cube_map")]
	[RequiredByFeature("GL_OES_texture_cube_map", Api = "gles1")]
	TextureCubeMapPositiveY = 34071,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_cube_map")]
	[RequiredByFeature("GL_EXT_texture_cube_map")]
	[RequiredByFeature("GL_OES_texture_cube_map", Api = "gles1")]
	TextureCubeMapNegativeY = 34072,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_cube_map")]
	[RequiredByFeature("GL_EXT_texture_cube_map")]
	[RequiredByFeature("GL_OES_texture_cube_map", Api = "gles1")]
	TextureCubeMapPositiveZ = 34073,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_cube_map")]
	[RequiredByFeature("GL_EXT_texture_cube_map")]
	[RequiredByFeature("GL_OES_texture_cube_map", Api = "gles1")]
	TextureCubeMapNegativeZ = 34074,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_ARB_texture_cube_map")]
	[RequiredByFeature("GL_EXT_texture_cube_map")]
	ProxyTextureCubeMap = 34075,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_texture_array")]
	Texture1dArray = 35864,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_EXT_texture_array")]
	ProxyTexture1dArray = 35865,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_sparse_texture", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_array")]
	Texture2dArray = 35866,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_EXT_texture_array")]
	ProxyTexture2dArray = 35867,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_texture_buffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_texture_buffer", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_buffer_object")]
	[RequiredByFeature("GL_OES_texture_buffer", Api = "gles2")]
	TextureBuffer = 35882,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	[RequiredByFeature("GL_NV_internalformat_sample_query", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	[RequiredByFeature("GL_OES_framebuffer_object", Api = "gles1")]
	Renderbuffer = 36161,
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_texture_cube_map_array", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_texture_cube_map_array", Api = "gles2")]
	[RequiredByFeature("GL_EXT_sparse_texture", Api = "gles2")]
	[RequiredByFeature("GL_OES_texture_cube_map_array", Api = "gles2")]
	TextureCubeMapArray = 36873,
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ARB_texture_cube_map_array", Api = "gl|glcore")]
	ProxyTextureCubeMapArray = 36875,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_texture_multisample", Api = "gl|glcore")]
	[RequiredByFeature("GL_NV_internalformat_sample_query", Api = "gl|glcore|gles2")]
	Texture2dMultisample = 37120,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ARB_texture_multisample", Api = "gl|glcore")]
	ProxyTexture2dMultisample = 37121,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_texture_multisample", Api = "gl|glcore")]
	[RequiredByFeature("GL_NV_internalformat_sample_query", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_OES_texture_storage_multisample_2d_array", Api = "gles2")]
	Texture2dMultisampleArray = 37122,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ARB_texture_multisample", Api = "gl|glcore")]
	ProxyTexture2dMultisampleArray = 37123
}
