using Khronos;

namespace OpenGL;

public enum TexStorageAttribs
{
	[RequiredByFeature("GL_EXT_EGL_image_storage_compression", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_storage_compression", Api = "gles2")]
	SurfaceCompressionExt = 38592,
	[RequiredByFeature("GL_EXT_EGL_image_storage_compression", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_storage_compression", Api = "gles2")]
	SurfaceCompressionFixedRateNoneExt = 38593,
	[RequiredByFeature("GL_EXT_EGL_image_storage_compression", Api = "gles2")]
	[RequiredByFeature("GL_EXT_texture_storage_compression", Api = "gles2")]
	SurfaceCompressionFixedRateDefaultExt = 38594,
	[RequiredByFeature("GL_EXT_texture_storage_compression", Api = "gles2")]
	SurfaceCompressionFixedRate1bpcExt = 38596,
	[RequiredByFeature("GL_EXT_texture_storage_compression", Api = "gles2")]
	SurfaceCompressionFixedRate2bpcExt = 38597,
	[RequiredByFeature("GL_EXT_texture_storage_compression", Api = "gles2")]
	SurfaceCompressionFixedRate3bpcExt = 38598,
	[RequiredByFeature("GL_EXT_texture_storage_compression", Api = "gles2")]
	SurfaceCompressionFixedRate4bpcExt = 38599,
	[RequiredByFeature("GL_EXT_texture_storage_compression", Api = "gles2")]
	SurfaceCompressionFixedRate5bpcExt = 38600,
	[RequiredByFeature("GL_EXT_texture_storage_compression", Api = "gles2")]
	SurfaceCompressionFixedRate6bpcExt = 38601,
	[RequiredByFeature("GL_EXT_texture_storage_compression", Api = "gles2")]
	SurfaceCompressionFixedRate7bpcExt = 38602,
	[RequiredByFeature("GL_EXT_texture_storage_compression", Api = "gles2")]
	SurfaceCompressionFixedRate8bpcExt = 38603,
	[RequiredByFeature("GL_EXT_texture_storage_compression", Api = "gles2")]
	SurfaceCompressionFixedRate9bpcExt = 38604,
	[RequiredByFeature("GL_EXT_texture_storage_compression", Api = "gles2")]
	SurfaceCompressionFixedRate10bpcExt = 38605,
	[RequiredByFeature("GL_EXT_texture_storage_compression", Api = "gles2")]
	SurfaceCompressionFixedRate11bpcExt = 38606,
	[RequiredByFeature("GL_EXT_texture_storage_compression", Api = "gles2")]
	SurfaceCompressionFixedRate12bpcExt = 38607
}
