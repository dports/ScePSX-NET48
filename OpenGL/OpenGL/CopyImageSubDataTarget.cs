using Khronos;

namespace OpenGL;

public enum CopyImageSubDataTarget
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
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_sparse_texture", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture3D")]
	[RequiredByFeature("GL_OES_texture_3D", Api = "gles2")]
	Texture3d = 32879,
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
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_texture_array")]
	Texture1dArray = 35864,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_sparse_texture", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_array")]
	Texture2dArray = 35866,
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
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_texture_multisample", Api = "gl|glcore")]
	[RequiredByFeature("GL_NV_internalformat_sample_query", Api = "gl|glcore|gles2")]
	Texture2dMultisample = 37120,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_texture_multisample", Api = "gl|glcore")]
	[RequiredByFeature("GL_NV_internalformat_sample_query", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_OES_texture_storage_multisample_2d_array", Api = "gles2")]
	Texture2dMultisampleArray = 37122
}
