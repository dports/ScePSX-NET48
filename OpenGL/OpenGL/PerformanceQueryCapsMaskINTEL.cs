using System;
using Khronos;

namespace OpenGL;

[Flags]
public enum PerformanceQueryCapsMaskINTEL : uint
{
	[RequiredByFeature("GL_INTEL_performance_query", Api = "gl|glcore|gles2")]
	PerfquerySingleContextIntel = 0u,
	[RequiredByFeature("GL_INTEL_performance_query", Api = "gl|glcore|gles2")]
	PerfqueryGlobalContextIntel = 1u
}
