using System;
using Khronos;

namespace OpenGL;

[Flags]
public enum FragmentShaderDestMaskATI : uint
{
	[RequiredByFeature("GL_ATI_fragment_shader")]
	RedBitAti = 1u,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	GreenBitAti = 2u,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	BlueBitAti = 4u,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_VERSION_4_6")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_KHR_context_flush_control", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_NV_register_combiners")]
	[RequiredByFeature("GL_OES_framebuffer_object", Api = "gles1")]
	None = 0u
}
