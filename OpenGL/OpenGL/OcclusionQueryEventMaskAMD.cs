using System;
using Khronos;

namespace OpenGL;

[Flags]
public enum OcclusionQueryEventMaskAMD : uint
{
	[RequiredByFeature("GL_AMD_occlusion_query_event")]
	QueryDepthPassEventBitAmd = 1u,
	[RequiredByFeature("GL_AMD_occlusion_query_event")]
	QueryDepthFailEventBitAmd = 2u,
	[RequiredByFeature("GL_AMD_occlusion_query_event")]
	QueryStencilFailEventBitAmd = 4u,
	[RequiredByFeature("GL_AMD_occlusion_query_event")]
	QueryDepthBoundsFailEventBitAmd = 8u,
	[RequiredByFeature("GL_AMD_occlusion_query_event")]
	QueryAllEventBitsAmd = uint.MaxValue
}
