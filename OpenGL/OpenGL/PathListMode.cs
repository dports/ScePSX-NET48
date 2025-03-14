using Khronos;

namespace OpenGL;

public enum PathListMode
{
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	AccumAdjacentPairsNv = 37037,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	AdjacentPairsNv,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	FirstToRestNv
}
