using System;
using Khronos;

namespace OpenGL;

[Flags]
public enum TextureStorageMaskAMD : uint
{
	[RequiredByFeature("GL_AMD_sparse_texture")]
	TextureStorageSparseBitAmd = 1u
}
