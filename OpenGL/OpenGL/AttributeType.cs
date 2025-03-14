using Khronos;

namespace OpenGL;

public enum AttributeType
{
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	Int = 5124,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ANGLE_depth_texture", Api = "gles2")]
	[RequiredByFeature("GL_OES_depth_texture", Api = "gles2")]
	[RequiredByFeature("GL_OES_element_index_uint", Api = "gles1|gles2")]
	UnsignedInt = 5125,
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
	Double = 5130,
	[RequiredByFeature("GL_ARB_gpu_shader_int64", Api = "gl|glcore")]
	[RequiredByFeature("GL_AMD_gpu_shader_int64")]
	[RequiredByFeature("GL_NV_gpu_shader5", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_NV_vertex_attrib_integer_64bit", Api = "gl|glcore")]
	Int64Arb = 5134,
	[RequiredByFeature("GL_ARB_bindless_texture", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_gpu_shader_int64", Api = "gl|glcore")]
	[RequiredByFeature("GL_AMD_gpu_shader_int64")]
	[RequiredByFeature("GL_NV_gpu_shader5", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_NV_vertex_attrib_integer_64bit", Api = "gl|glcore")]
	UnsignedInt64Arb = 5135,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_objects")]
	[RequiredByFeature("GL_ARB_vertex_shader")]
	FloatVec2 = 35664,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_objects")]
	[RequiredByFeature("GL_ARB_vertex_shader")]
	FloatVec3 = 35665,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_objects")]
	[RequiredByFeature("GL_ARB_vertex_shader")]
	FloatVec4 = 35666,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_objects")]
	IntVec2 = 35667,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_objects")]
	IntVec3 = 35668,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_objects")]
	IntVec4 = 35669,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_objects")]
	Bool = 35670,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_objects")]
	BoolVec2 = 35671,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_objects")]
	BoolVec3 = 35672,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_objects")]
	BoolVec4 = 35673,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_objects")]
	[RequiredByFeature("GL_ARB_vertex_shader")]
	FloatMat2 = 35674,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_objects")]
	[RequiredByFeature("GL_ARB_vertex_shader")]
	FloatMat3 = 35675,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_objects")]
	[RequiredByFeature("GL_ARB_vertex_shader")]
	FloatMat4 = 35676,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ARB_shader_objects")]
	Sampler1d = 35677,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_shader_objects")]
	Sampler2d = 35678,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_objects")]
	[RequiredByFeature("GL_OES_texture_3D", Api = "gles2")]
	Sampler3d = 35679,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_objects")]
	SamplerCube = 35680,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ARB_shader_objects")]
	Sampler1dShadow = 35681,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_objects")]
	[RequiredByFeature("GL_EXT_shadow_samplers", Api = "gles2")]
	Sampler2dShadow = 35682,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ARB_shader_objects")]
	Sampler2dRect = 35683,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ARB_shader_objects")]
	Sampler2dRectShadow = 35684,
	[RequiredByFeature("GL_VERSION_2_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2")]
	FloatMat2x3 = 35685,
	[RequiredByFeature("GL_VERSION_2_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2")]
	FloatMat2x4 = 35686,
	[RequiredByFeature("GL_VERSION_2_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2")]
	FloatMat3x2 = 35687,
	[RequiredByFeature("GL_VERSION_2_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2")]
	FloatMat3x4 = 35688,
	[RequiredByFeature("GL_VERSION_2_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2")]
	FloatMat4x2 = 35689,
	[RequiredByFeature("GL_VERSION_2_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2")]
	FloatMat4x3 = 35690,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_EXT_gpu_shader4")]
	[RequiredByFeature("GL_EXT_texture_buffer", Api = "gles2")]
	[RequiredByFeature("GL_OES_texture_buffer", Api = "gles2")]
	SamplerBuffer = 36290,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_EXT_gpu_shader4")]
	Sampler1dArrayShadow = 36291,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_gpu_shader4")]
	[RequiredByFeature("GL_NV_shadow_samplers_array", Api = "gles2")]
	Sampler2dArrayShadow = 36292,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_gpu_shader4")]
	[RequiredByFeature("GL_NV_shadow_samplers_cube", Api = "gles2")]
	SamplerCubeShadow = 36293,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_gpu_shader4")]
	UnsignedIntVec2 = 36294,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_gpu_shader4")]
	UnsignedIntVec3 = 36295,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_gpu_shader4")]
	UnsignedIntVec4 = 36296,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_EXT_gpu_shader4")]
	IntSampler1d = 36297,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_gpu_shader4")]
	IntSampler2d = 36298,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_gpu_shader4")]
	IntSampler3d = 36299,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_gpu_shader4")]
	IntSamplerCube = 36300,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_EXT_gpu_shader4")]
	IntSampler2dRect = 36301,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_EXT_gpu_shader4")]
	IntSampler1dArray = 36302,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_gpu_shader4")]
	IntSampler2dArray = 36303,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_EXT_gpu_shader4")]
	[RequiredByFeature("GL_EXT_texture_buffer", Api = "gles2")]
	[RequiredByFeature("GL_OES_texture_buffer", Api = "gles2")]
	IntSamplerBuffer = 36304,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_EXT_gpu_shader4")]
	UnsignedIntSampler1d = 36305,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_gpu_shader4")]
	UnsignedIntSampler2d = 36306,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_gpu_shader4")]
	UnsignedIntSampler3d = 36307,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_gpu_shader4")]
	UnsignedIntSamplerCube = 36308,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_EXT_gpu_shader4")]
	UnsignedIntSampler2dRect = 36309,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_EXT_gpu_shader4")]
	UnsignedIntSampler1dArray = 36310,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_gpu_shader4")]
	UnsignedIntSampler2dArray = 36311,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_EXT_gpu_shader4")]
	[RequiredByFeature("GL_EXT_texture_buffer", Api = "gles2")]
	[RequiredByFeature("GL_OES_texture_buffer", Api = "gles2")]
	UnsignedIntSamplerBuffer = 36312,
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_vertex_attrib_64bit", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_vertex_attrib_64bit")]
	DoubleMat2 = 36678,
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_vertex_attrib_64bit", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_vertex_attrib_64bit")]
	DoubleMat3 = 36679,
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_vertex_attrib_64bit", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_vertex_attrib_64bit")]
	DoubleMat4 = 36680,
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_vertex_attrib_64bit", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_vertex_attrib_64bit")]
	DoubleMat2x3 = 36681,
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_vertex_attrib_64bit", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_vertex_attrib_64bit")]
	DoubleMat2x4 = 36682,
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_vertex_attrib_64bit", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_vertex_attrib_64bit")]
	DoubleMat3x2 = 36683,
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_vertex_attrib_64bit", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_vertex_attrib_64bit")]
	DoubleMat3x4 = 36684,
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_vertex_attrib_64bit", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_vertex_attrib_64bit")]
	DoubleMat4x2 = 36685,
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_vertex_attrib_64bit", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_vertex_attrib_64bit")]
	DoubleMat4x3 = 36686,
	[RequiredByFeature("GL_ARB_gpu_shader_int64", Api = "gl|glcore")]
	[RequiredByFeature("GL_AMD_gpu_shader_int64")]
	[RequiredByFeature("GL_NV_gpu_shader5", Api = "gl|glcore|gles2")]
	Int64Vec2Arb = 36841,
	[RequiredByFeature("GL_ARB_gpu_shader_int64", Api = "gl|glcore")]
	[RequiredByFeature("GL_AMD_gpu_shader_int64")]
	[RequiredByFeature("GL_NV_gpu_shader5", Api = "gl|glcore|gles2")]
	Int64Vec3Arb = 36842,
	[RequiredByFeature("GL_ARB_gpu_shader_int64", Api = "gl|glcore")]
	[RequiredByFeature("GL_AMD_gpu_shader_int64")]
	[RequiredByFeature("GL_NV_gpu_shader5", Api = "gl|glcore|gles2")]
	Int64Vec4Arb = 36843,
	[RequiredByFeature("GL_ARB_gpu_shader_int64", Api = "gl|glcore")]
	[RequiredByFeature("GL_AMD_gpu_shader_int64")]
	[RequiredByFeature("GL_NV_gpu_shader5", Api = "gl|glcore|gles2")]
	UnsignedInt64Vec2Arb = 36853,
	[RequiredByFeature("GL_ARB_gpu_shader_int64", Api = "gl|glcore")]
	[RequiredByFeature("GL_AMD_gpu_shader_int64")]
	[RequiredByFeature("GL_NV_gpu_shader5", Api = "gl|glcore|gles2")]
	UnsignedInt64Vec3Arb = 36854,
	[RequiredByFeature("GL_ARB_gpu_shader_int64", Api = "gl|glcore")]
	[RequiredByFeature("GL_AMD_gpu_shader_int64")]
	[RequiredByFeature("GL_NV_gpu_shader5", Api = "gl|glcore|gles2")]
	UnsignedInt64Vec4Arb = 36855,
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_vertex_attrib_64bit", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_vertex_attrib_64bit")]
	DoubleVec2 = 36860,
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_vertex_attrib_64bit", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_vertex_attrib_64bit")]
	DoubleVec3 = 36861,
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_vertex_attrib_64bit", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_vertex_attrib_64bit")]
	DoubleVec4 = 36862,
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_cube_map_array", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_texture_cube_map_array", Api = "gles2")]
	[RequiredByFeature("GL_OES_texture_cube_map_array", Api = "gles2")]
	SamplerCubeMapArray = 36876,
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_cube_map_array", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_texture_cube_map_array", Api = "gles2")]
	[RequiredByFeature("GL_OES_texture_cube_map_array", Api = "gles2")]
	SamplerCubeMapArrayShadow = 36877,
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_cube_map_array", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_texture_cube_map_array", Api = "gles2")]
	[RequiredByFeature("GL_OES_texture_cube_map_array", Api = "gles2")]
	IntSamplerCubeMapArray = 36878,
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_cube_map_array", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_texture_cube_map_array", Api = "gles2")]
	[RequiredByFeature("GL_OES_texture_cube_map_array", Api = "gles2")]
	UnsignedIntSamplerCubeMapArray = 36879,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	Image1d = 36940,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	Image2d = 36941,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	Image3d = 36942,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	Image2dRect = 36943,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	ImageCube = 36944,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	[RequiredByFeature("GL_EXT_texture_buffer", Api = "gles2")]
	[RequiredByFeature("GL_OES_texture_buffer", Api = "gles2")]
	ImageBuffer = 36945,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	Image1dArray = 36946,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	Image2dArray = 36947,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	[RequiredByFeature("GL_EXT_texture_cube_map_array", Api = "gles2")]
	[RequiredByFeature("GL_OES_texture_cube_map_array", Api = "gles2")]
	ImageCubeMapArray = 36948,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	Image2dMultisample = 36949,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	Image2dMultisampleArray = 36950,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	IntImage1d = 36951,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	IntImage2d = 36952,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	IntImage3d = 36953,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	IntImage2dRect = 36954,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	IntImageCube = 36955,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	[RequiredByFeature("GL_EXT_texture_buffer", Api = "gles2")]
	[RequiredByFeature("GL_OES_texture_buffer", Api = "gles2")]
	IntImageBuffer = 36956,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	IntImage1dArray = 36957,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	IntImage2dArray = 36958,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	[RequiredByFeature("GL_EXT_texture_cube_map_array", Api = "gles2")]
	[RequiredByFeature("GL_OES_texture_cube_map_array", Api = "gles2")]
	IntImageCubeMapArray = 36959,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	IntImage2dMultisample = 36960,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	IntImage2dMultisampleArray = 36961,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	UnsignedIntImage1d = 36962,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	UnsignedIntImage2d = 36963,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	UnsignedIntImage3d = 36964,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	UnsignedIntImage2dRect = 36965,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	UnsignedIntImageCube = 36966,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	[RequiredByFeature("GL_EXT_texture_buffer", Api = "gles2")]
	[RequiredByFeature("GL_OES_texture_buffer", Api = "gles2")]
	UnsignedIntImageBuffer = 36967,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	UnsignedIntImage1dArray = 36968,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	UnsignedIntImage2dArray = 36969,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	[RequiredByFeature("GL_EXT_texture_cube_map_array", Api = "gles2")]
	[RequiredByFeature("GL_OES_texture_cube_map_array", Api = "gles2")]
	UnsignedIntImageCubeMapArray = 36970,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	UnsignedIntImage2dMultisample = 36971,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ARB_shader_image_load_store", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_shader_image_load_store")]
	UnsignedIntImage2dMultisampleArray = 36972,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_multisample", Api = "gl|glcore")]
	Sampler2dMultisample = 37128,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_multisample", Api = "gl|glcore")]
	IntSampler2dMultisample = 37129,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_multisample", Api = "gl|glcore")]
	UnsignedIntSampler2dMultisample = 37130,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_multisample", Api = "gl|glcore")]
	[RequiredByFeature("GL_OES_texture_storage_multisample_2d_array", Api = "gles2")]
	Sampler2dMultisampleArray = 37131,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_multisample", Api = "gl|glcore")]
	[RequiredByFeature("GL_OES_texture_storage_multisample_2d_array", Api = "gles2")]
	IntSampler2dMultisampleArray = 37132,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_texture_multisample", Api = "gl|glcore")]
	[RequiredByFeature("GL_OES_texture_storage_multisample_2d_array", Api = "gles2")]
	UnsignedIntSampler2dMultisampleArray = 37133
}
