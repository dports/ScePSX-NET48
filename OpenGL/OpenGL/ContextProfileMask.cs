using System;
using Khronos;

namespace OpenGL;

[Flags]
public enum ContextProfileMask : uint
{
	[RequiredByFeature("GL_VERSION_3_2")]
	ContextCoreProfileBit = 1u,
	[RequiredByFeature("GL_VERSION_3_2")]
	ContextCompatibilityProfileBit = 2u
}
