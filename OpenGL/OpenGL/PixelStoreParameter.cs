using Khronos;

namespace OpenGL;

public enum PixelStoreParameter
{
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
	[RequiredByFeature("GL_SGIS_texture4D")]
	PackSkipVolumesSgis = 33072,
	[RequiredByFeature("GL_SGIS_texture4D")]
	PackImageDepthSgis = 33073,
	[RequiredByFeature("GL_SGIS_texture4D")]
	UnpackSkipVolumesSgis = 33074,
	[RequiredByFeature("GL_SGIS_texture4D")]
	UnpackImageDepthSgis = 33075,
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
	[RequiredByFeature("GL_SGIX_resample")]
	PackResampleSgix = 33838,
	[RequiredByFeature("GL_SGIX_resample")]
	UnpackResampleSgix = 33839,
	[RequiredByFeature("GL_SGIX_subsample")]
	PackSubsampleRateSgix = 34208,
	[RequiredByFeature("GL_SGIX_subsample")]
	UnpackSubsampleRateSgix = 34209,
	[RequiredByFeature("GL_OML_resample")]
	PackResampleOml = 35204,
	[RequiredByFeature("GL_OML_resample")]
	UnpackResampleOml = 35205
}
