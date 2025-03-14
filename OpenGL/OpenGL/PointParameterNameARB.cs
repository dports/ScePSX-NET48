using Khronos;

namespace OpenGL;

public enum PointParameterNameARB
{
	[RequiredByFeature("GL_VERSION_1_4")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ARB_point_parameters")]
	[RequiredByFeature("GL_EXT_point_parameters")]
	[RequiredByFeature("GL_SGIS_point_parameters")]
	[RemovedByFeature("GL_VERSION_3_2")]
	PointSizeMin = 33062,
	[RequiredByFeature("GL_VERSION_1_4")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ARB_point_parameters")]
	[RequiredByFeature("GL_EXT_point_parameters")]
	[RequiredByFeature("GL_SGIS_point_parameters")]
	[RemovedByFeature("GL_VERSION_3_2")]
	PointSizeMax = 33063,
	[RequiredByFeature("GL_VERSION_1_4")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ARB_point_parameters")]
	[RequiredByFeature("GL_EXT_point_parameters")]
	[RequiredByFeature("GL_SGIS_point_parameters")]
	PointFadeThresholdSize = 33064,
	[RequiredByFeature("GL_EXT_point_parameters")]
	[RequiredByFeature("GL_SGIS_point_parameters")]
	DistanceAttenuationExt = 33065,
	[RequiredByFeature("GL_VERSION_1_4")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ARB_point_parameters")]
	[RemovedByFeature("GL_VERSION_3_2")]
	PointDistanceAttenuation = 33065
}
