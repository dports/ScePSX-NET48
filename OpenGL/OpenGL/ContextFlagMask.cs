using System;
using Khronos;

namespace OpenGL;

[Flags]
public enum ContextFlagMask : uint
{
	[RequiredByFeature("GL_VERSION_3_0")]
	ContextFlagForwardCompatibleBit = 1u,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	ContextFlagDebugBit = 2u,
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_robustness", Api = "gl|glcore")]
	ContextFlagRobustAccessBit = 4u,
	[RequiredByFeature("GL_VERSION_4_6")]
	ContextFlagNoErrorBit = 8u,
	[RequiredByFeature("GL_EXT_protected_textures", Api = "gles2")]
	ContextFlagProtectedContentBitExt = 0x10u
}
