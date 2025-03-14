using Khronos;

namespace OpenGL;

public enum MemoryObjectParameterName
{
	[RequiredByFeature("GL_EXT_memory_object", Api = "gl|gles2")]
	DedicatedMemoryObjectExt = 38273,
	[RequiredByFeature("GL_EXT_memory_object", Api = "gl|gles2")]
	ProtectedMemoryObjectExt = 38299
}
