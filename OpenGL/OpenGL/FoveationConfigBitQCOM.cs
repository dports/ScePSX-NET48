using System;
using Khronos;

namespace OpenGL;

[Flags]
public enum FoveationConfigBitQCOM : uint
{
	[RequiredByFeature("GL_QCOM_framebuffer_foveated", Api = "gles2")]
	[RequiredByFeature("GL_QCOM_texture_foveated", Api = "gles2")]
	FoveationEnableBitQcom = 1u,
	[RequiredByFeature("GL_QCOM_framebuffer_foveated", Api = "gles2")]
	[RequiredByFeature("GL_QCOM_motion_estimation", Api = "gles2")]
	[RequiredByFeature("GL_QCOM_texture_foveated", Api = "gles2")]
	FoveationScaledBinMethodBitQcom = 2u,
	[RequiredByFeature("GL_QCOM_texture_foveated_subsampled_layout", Api = "gles2")]
	FoveationSubsampledLayoutMethodBitQcom = 4u
}
