using Khronos;

namespace OpenGL;

public enum GetVariantValueEXT
{
	[RequiredByFeature("GL_EXT_vertex_shader")]
	VariantValueExt = 34788,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	VariantDatatypeExt,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	VariantArrayStrideExt,
	[RequiredByFeature("GL_EXT_vertex_shader")]
	VariantArrayTypeExt
}
