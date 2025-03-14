using Khronos;

namespace OpenGL;

public enum ContainerType
{
	[RequiredByFeature("GL_ARB_shader_objects")]
	[RequiredByFeature("GL_EXT_debug_label", Api = "gl|glcore|gles2")]
	ProgramObjectArb = 35648
}
