using Khronos;

namespace OpenGL;

public enum FogPointerTypeIBM
{
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_vertex_shader")]
	[RequiredByFeature("GL_OES_texture_float", Api = "gles2")]
	Float = 5126,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_vertex_attrib_64bit")]
	Double = 5130
}
