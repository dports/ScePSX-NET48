using Khronos;

namespace OpenGL;

public enum LightModelParameter
{
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	LightModelLocalViewer = 2897,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	LightModelTwoSide = 2898,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	LightModelAmbient = 2899,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_EXT_separate_specular_color")]
	[RemovedByFeature("GL_VERSION_3_2")]
	LightModelColorControl = 33272
}
