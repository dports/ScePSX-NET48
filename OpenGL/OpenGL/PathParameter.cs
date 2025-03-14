using Khronos;

namespace OpenGL;

public enum PathParameter
{
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	PathStrokeWidthNv = 36981,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	PathEndCapsNv = 36982,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	PathInitialEndCapNv = 36983,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	PathTerminalEndCapNv = 36984,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	PathJoinStyleNv = 36985,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	PathMiterLimitNv = 36986,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	PathDashCapsNv = 36987,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	PathInitialDashCapNv = 36988,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	PathTerminalDashCapNv = 36989,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	PathDashOffsetNv = 36990,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	PathClientLengthNv = 36991,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	PathFillModeNv = 36992,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	PathFillMaskNv = 36993,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	PathFillCoverModeNv = 36994,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	PathStrokeCoverModeNv = 36995,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	PathStrokeMaskNv = 36996,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	PathObjectBoundingBoxNv = 37002,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	PathCommandCountNv = 37021,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	PathCoordCountNv = 37022,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	PathDashArrayCountNv = 37023,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	PathComputedLengthNv = 37024,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	PathFillBoundingBoxNv = 37025,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	PathStrokeBoundingBoxNv = 37026,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	PathDashOffsetResetNv = 37044
}
