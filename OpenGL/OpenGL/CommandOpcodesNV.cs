using Khronos;

namespace OpenGL;

public enum CommandOpcodesNV
{
	[RequiredByFeature("GL_NV_command_list", Api = "gl|glcore")]
	TerminateSequenceCommandNv,
	[RequiredByFeature("GL_NV_command_list", Api = "gl|glcore")]
	NopCommandNv,
	[RequiredByFeature("GL_NV_command_list", Api = "gl|glcore")]
	DrawElementsCommandNv,
	[RequiredByFeature("GL_NV_command_list", Api = "gl|glcore")]
	DrawArraysCommandNv,
	[RequiredByFeature("GL_NV_command_list", Api = "gl|glcore")]
	DrawElementsStripCommandNv,
	[RequiredByFeature("GL_NV_command_list", Api = "gl|glcore")]
	DrawArraysStripCommandNv,
	[RequiredByFeature("GL_NV_command_list", Api = "gl|glcore")]
	DrawElementsInstancedCommandNv,
	[RequiredByFeature("GL_NV_command_list", Api = "gl|glcore")]
	DrawArraysInstancedCommandNv,
	[RequiredByFeature("GL_NV_command_list", Api = "gl|glcore")]
	ElementAddressCommandNv,
	[RequiredByFeature("GL_NV_command_list", Api = "gl|glcore")]
	AttributeAddressCommandNv,
	[RequiredByFeature("GL_NV_command_list", Api = "gl|glcore")]
	UniformAddressCommandNv,
	[RequiredByFeature("GL_NV_command_list", Api = "gl|glcore")]
	BlendColorCommandNv,
	[RequiredByFeature("GL_NV_command_list", Api = "gl|glcore")]
	StencilRefCommandNv,
	[RequiredByFeature("GL_NV_command_list", Api = "gl|glcore")]
	LineWidthCommandNv,
	[RequiredByFeature("GL_NV_command_list", Api = "gl|glcore")]
	PolygonOffsetCommandNv,
	[RequiredByFeature("GL_NV_command_list", Api = "gl|glcore")]
	AlphaRefCommandNv,
	[RequiredByFeature("GL_NV_command_list", Api = "gl|glcore")]
	ViewportCommandNv,
	[RequiredByFeature("GL_NV_command_list", Api = "gl|glcore")]
	ScissorCommandNv,
	[RequiredByFeature("GL_NV_command_list", Api = "gl|glcore")]
	FrontFaceCommandNv
}
