using Khronos;

namespace OpenGL;

public enum FenceParameterNameNV
{
	[RequiredByFeature("GL_NV_fence", Api = "gl|gles1|gles2")]
	FenceStatusNv = 34035,
	[RequiredByFeature("GL_NV_fence", Api = "gl|gles1|gles2")]
	FenceConditionNv
}
