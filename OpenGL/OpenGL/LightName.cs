using Khronos;

namespace OpenGL;

public enum LightName
{
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Light0 = 16384,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Light1 = 16385,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Light2 = 16386,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Light3 = 16387,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Light4 = 16388,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Light5 = 16389,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Light6 = 16390,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Light7 = 16391,
	[RequiredByFeature("GL_SGIX_fragment_lighting")]
	FragmentLight0Sgix = 33804,
	[RequiredByFeature("GL_SGIX_fragment_lighting")]
	FragmentLight1Sgix = 33805,
	[RequiredByFeature("GL_SGIX_fragment_lighting")]
	FragmentLight2Sgix = 33806,
	[RequiredByFeature("GL_SGIX_fragment_lighting")]
	FragmentLight3Sgix = 33807,
	[RequiredByFeature("GL_SGIX_fragment_lighting")]
	FragmentLight4Sgix = 33808,
	[RequiredByFeature("GL_SGIX_fragment_lighting")]
	FragmentLight5Sgix = 33809,
	[RequiredByFeature("GL_SGIX_fragment_lighting")]
	FragmentLight6Sgix = 33810,
	[RequiredByFeature("GL_SGIX_fragment_lighting")]
	FragmentLight7Sgix = 33811
}
