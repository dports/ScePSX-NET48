using System;
using Khronos;

namespace OpenGL;

[Flags]
public enum ClientAttribMask : uint
{
	[RequiredByFeature("GL_VERSION_1_1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ClientPixelStoreBit = 1u,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ClientVertexArrayBit = 2u,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ClientAllAttribBits = uint.MaxValue
}
