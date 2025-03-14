using Khronos;

namespace OpenGL;

public enum TextureCoordName
{
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	S = 8192,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	T = 8193,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	R = 8194,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Q = 8195,
	[RequiredByFeature("GL_OES_texture_cube_map", Api = "gles1")]
	TextureGenStrOes = 36192
}
