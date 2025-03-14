using Khronos;

namespace OpenGL;

public enum ShadingRate
{
	[RequiredByFeature("GL_EXT_fragment_shading_rate", Api = "gles2")]
	[RequiredByFeature("GL_QCOM_shading_rate", Api = "gles2")]
	ShadingRate1x1PixelsExt = 38566,
	[RequiredByFeature("GL_EXT_fragment_shading_rate", Api = "gles2")]
	[RequiredByFeature("GL_QCOM_shading_rate", Api = "gles2")]
	ShadingRate1x2PixelsExt,
	[RequiredByFeature("GL_EXT_fragment_shading_rate", Api = "gles2")]
	[RequiredByFeature("GL_QCOM_shading_rate", Api = "gles2")]
	ShadingRate2x1PixelsExt,
	[RequiredByFeature("GL_EXT_fragment_shading_rate", Api = "gles2")]
	[RequiredByFeature("GL_QCOM_shading_rate", Api = "gles2")]
	ShadingRate2x2PixelsExt,
	[RequiredByFeature("GL_EXT_fragment_shading_rate", Api = "gles2")]
	ShadingRate1x4PixelsExt,
	[RequiredByFeature("GL_EXT_fragment_shading_rate", Api = "gles2")]
	ShadingRate4x1PixelsExt,
	[RequiredByFeature("GL_EXT_fragment_shading_rate", Api = "gles2")]
	[RequiredByFeature("GL_QCOM_shading_rate", Api = "gles2")]
	ShadingRate4x2PixelsExt,
	[RequiredByFeature("GL_EXT_fragment_shading_rate", Api = "gles2")]
	ShadingRate2x4PixelsExt,
	[RequiredByFeature("GL_EXT_fragment_shading_rate", Api = "gles2")]
	[RequiredByFeature("GL_QCOM_shading_rate", Api = "gles2")]
	ShadingRate4x4PixelsExt
}
