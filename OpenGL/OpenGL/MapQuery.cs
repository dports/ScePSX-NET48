using Khronos;

namespace OpenGL;

public enum MapQuery
{
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Coeff = 2560,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Order,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Domain
}
