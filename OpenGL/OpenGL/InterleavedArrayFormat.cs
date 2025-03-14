using Khronos;

namespace OpenGL;

public enum InterleavedArrayFormat
{
	[RequiredByFeature("GL_VERSION_1_1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	V2f = 10784,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	V3f,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	C4ubV2f,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	C4ubV3f,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	C3fV3f,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	N3fV3f,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	C4fN3fV3f,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	T2fV3f,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	T4fV4f,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	T2fC4ubV3f,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	T2fC3fV3f,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	T2fN3fV3f,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	T2fC4fN3fV3f,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	T4fC4fN3fV4f
}
