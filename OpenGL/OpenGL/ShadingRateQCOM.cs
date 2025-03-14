using System;
using Khronos;

namespace OpenGL;

[Flags]
public enum ShadingRateQCOM : uint
{
	[RequiredByFeature("GL_EXT_fragment_shading_rate", Api = "gles2")]
	[RequiredByFeature("GL_QCOM_shading_rate", Api = "gles2")]
	ShadingRate1x1PixelsExt = 0x96A6u,
	[RequiredByFeature("GL_EXT_fragment_shading_rate", Api = "gles2")]
	[RequiredByFeature("GL_QCOM_shading_rate", Api = "gles2")]
	ShadingRate1x2PixelsExt = 0x96A7u,
	[RequiredByFeature("GL_EXT_fragment_shading_rate", Api = "gles2")]
	[RequiredByFeature("GL_QCOM_shading_rate", Api = "gles2")]
	ShadingRate2x1PixelsExt = 0x96A8u,
	[RequiredByFeature("GL_EXT_fragment_shading_rate", Api = "gles2")]
	[RequiredByFeature("GL_QCOM_shading_rate", Api = "gles2")]
	ShadingRate2x2PixelsExt = 0x96A9u,
	[RequiredByFeature("GL_EXT_fragment_shading_rate", Api = "gles2")]
	[RequiredByFeature("GL_QCOM_shading_rate", Api = "gles2")]
	ShadingRate4x2PixelsExt = 0x96ACu,
	[RequiredByFeature("GL_EXT_fragment_shading_rate", Api = "gles2")]
	[RequiredByFeature("GL_QCOM_shading_rate", Api = "gles2")]
	ShadingRate4x4PixelsExt = 0x96AEu
}
