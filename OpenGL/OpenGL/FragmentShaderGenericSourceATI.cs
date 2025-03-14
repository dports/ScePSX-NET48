using Khronos;

namespace OpenGL;

public enum FragmentShaderGenericSourceATI
{
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_EXT_draw_buffers_indexed", Api = "gles2")]
	[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_NV_register_combiners")]
	[RequiredByFeature("GL_OES_draw_buffers_indexed", Api = "gles2")]
	Zero = 0,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_EXT_draw_buffers_indexed", Api = "gles2")]
	[RequiredByFeature("GL_OES_draw_buffers_indexed", Api = "gles2")]
	One = 1,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_ARB_texture_env_combine")]
	[RequiredByFeature("GL_EXT_texture_env_combine")]
	[RemovedByFeature("GL_VERSION_3_2")]
	PrimaryColor = 34167,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Reg0Ati = 35105,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Reg1Ati = 35106,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Reg2Ati = 35107,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Reg3Ati = 35108,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Reg4Ati = 35109,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Reg5Ati = 35110,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Reg6Ati = 35111,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Reg7Ati = 35112,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Reg8Ati = 35113,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Reg9Ati = 35114,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Reg10Ati = 35115,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Reg11Ati = 35116,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Reg12Ati = 35117,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Reg13Ati = 35118,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Reg14Ati = 35119,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Reg15Ati = 35120,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Reg16Ati = 35121,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Reg17Ati = 35122,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Reg18Ati = 35123,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Reg19Ati = 35124,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Reg20Ati = 35125,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Reg21Ati = 35126,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Reg22Ati = 35127,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Reg23Ati = 35128,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Reg24Ati = 35129,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Reg25Ati = 35130,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Reg26Ati = 35131,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Reg27Ati = 35132,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Reg28Ati = 35133,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Reg29Ati = 35134,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Reg30Ati = 35135,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Reg31Ati = 35136,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Con0Ati = 35137,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Con1Ati = 35138,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Con2Ati = 35139,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Con3Ati = 35140,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Con4Ati = 35141,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Con5Ati = 35142,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Con6Ati = 35143,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Con7Ati = 35144,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Con8Ati = 35145,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Con9Ati = 35146,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Con10Ati = 35147,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Con11Ati = 35148,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Con12Ati = 35149,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Con13Ati = 35150,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Con14Ati = 35151,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Con15Ati = 35152,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Con16Ati = 35153,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Con17Ati = 35154,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Con18Ati = 35155,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Con19Ati = 35156,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Con20Ati = 35157,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Con21Ati = 35158,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Con22Ati = 35159,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Con23Ati = 35160,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Con24Ati = 35161,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Con25Ati = 35162,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Con26Ati = 35163,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Con27Ati = 35164,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Con28Ati = 35165,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Con29Ati = 35166,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Con30Ati = 35167,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Con31Ati = 35168,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	SecondaryInterpolatorAti = 35181
}
