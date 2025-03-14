using Khronos;

namespace OpenGL;

public enum TriangleListSUN
{
	[RequiredByFeature("GL_SUN_triangle_list")]
	RestartSun = 1,
	[RequiredByFeature("GL_SUN_triangle_list")]
	ReplaceMiddleSun,
	[RequiredByFeature("GL_SUN_triangle_list")]
	ReplaceOldestSun
}
