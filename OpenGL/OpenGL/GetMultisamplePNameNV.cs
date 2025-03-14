using Khronos;

namespace OpenGL;

public enum GetMultisamplePNameNV
{
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_multisample", Api = "gl|glcore")]
	[RequiredByFeature("GL_NV_explicit_multisample")]
	SamplePosition = 36432,
	[RequiredByFeature("GL_ARB_sample_locations", Api = "gl|glcore")]
	[RequiredByFeature("GL_NV_sample_locations", Api = "gl|glcore|gles2")]
	ProgrammableSampleLocationArb = 37697
}
