using System;
using Khronos;

namespace OpenGL;

[Flags]
public enum BufferBitQCOM : uint
{
	[RequiredByFeature("GL_QCOM_tiled_rendering", Api = "gles1|gles2")]
	ColorBufferBit0Qcom = 1u,
	[RequiredByFeature("GL_QCOM_tiled_rendering", Api = "gles1|gles2")]
	ColorBufferBit1Qcom = 2u,
	[RequiredByFeature("GL_QCOM_tiled_rendering", Api = "gles1|gles2")]
	ColorBufferBit2Qcom = 4u,
	[RequiredByFeature("GL_QCOM_tiled_rendering", Api = "gles1|gles2")]
	ColorBufferBit3Qcom = 8u,
	[RequiredByFeature("GL_QCOM_tiled_rendering", Api = "gles1|gles2")]
	ColorBufferBit4Qcom = 0x10u,
	[RequiredByFeature("GL_QCOM_tiled_rendering", Api = "gles1|gles2")]
	ColorBufferBit5Qcom = 0x20u,
	[RequiredByFeature("GL_QCOM_tiled_rendering", Api = "gles1|gles2")]
	ColorBufferBit6Qcom = 0x40u,
	[RequiredByFeature("GL_QCOM_tiled_rendering", Api = "gles1|gles2")]
	ColorBufferBit7Qcom = 0x80u,
	[RequiredByFeature("GL_QCOM_tiled_rendering", Api = "gles1|gles2")]
	DepthBufferBit0Qcom = 0x100u,
	[RequiredByFeature("GL_QCOM_tiled_rendering", Api = "gles1|gles2")]
	DepthBufferBit1Qcom = 0x200u,
	[RequiredByFeature("GL_QCOM_tiled_rendering", Api = "gles1|gles2")]
	DepthBufferBit2Qcom = 0x400u,
	[RequiredByFeature("GL_QCOM_tiled_rendering", Api = "gles1|gles2")]
	DepthBufferBit3Qcom = 0x800u,
	[RequiredByFeature("GL_QCOM_tiled_rendering", Api = "gles1|gles2")]
	DepthBufferBit4Qcom = 0x1000u,
	[RequiredByFeature("GL_QCOM_tiled_rendering", Api = "gles1|gles2")]
	DepthBufferBit5Qcom = 0x2000u,
	[RequiredByFeature("GL_QCOM_tiled_rendering", Api = "gles1|gles2")]
	DepthBufferBit6Qcom = 0x4000u,
	[RequiredByFeature("GL_QCOM_tiled_rendering", Api = "gles1|gles2")]
	DepthBufferBit7Qcom = 0x8000u,
	[RequiredByFeature("GL_QCOM_tiled_rendering", Api = "gles1|gles2")]
	StencilBufferBit0Qcom = 0x10000u,
	[RequiredByFeature("GL_QCOM_tiled_rendering", Api = "gles1|gles2")]
	StencilBufferBit1Qcom = 0x20000u,
	[RequiredByFeature("GL_QCOM_tiled_rendering", Api = "gles1|gles2")]
	StencilBufferBit2Qcom = 0x40000u,
	[RequiredByFeature("GL_QCOM_tiled_rendering", Api = "gles1|gles2")]
	StencilBufferBit3Qcom = 0x80000u,
	[RequiredByFeature("GL_QCOM_tiled_rendering", Api = "gles1|gles2")]
	StencilBufferBit4Qcom = 0x100000u,
	[RequiredByFeature("GL_QCOM_tiled_rendering", Api = "gles1|gles2")]
	StencilBufferBit5Qcom = 0x200000u,
	[RequiredByFeature("GL_QCOM_tiled_rendering", Api = "gles1|gles2")]
	StencilBufferBit6Qcom = 0x400000u,
	[RequiredByFeature("GL_QCOM_tiled_rendering", Api = "gles1|gles2")]
	StencilBufferBit7Qcom = 0x800000u,
	[RequiredByFeature("GL_QCOM_tiled_rendering", Api = "gles1|gles2")]
	MultisampleBufferBit0Qcom = 0x1000000u,
	[RequiredByFeature("GL_QCOM_tiled_rendering", Api = "gles1|gles2")]
	MultisampleBufferBit1Qcom = 0x2000000u,
	[RequiredByFeature("GL_QCOM_tiled_rendering", Api = "gles1|gles2")]
	MultisampleBufferBit2Qcom = 0x4000000u,
	[RequiredByFeature("GL_QCOM_tiled_rendering", Api = "gles1|gles2")]
	MultisampleBufferBit3Qcom = 0x8000000u,
	[RequiredByFeature("GL_QCOM_tiled_rendering", Api = "gles1|gles2")]
	MultisampleBufferBit4Qcom = 0x10000000u,
	[RequiredByFeature("GL_QCOM_tiled_rendering", Api = "gles1|gles2")]
	MultisampleBufferBit5Qcom = 0x20000000u,
	[RequiredByFeature("GL_QCOM_tiled_rendering", Api = "gles1|gles2")]
	MultisampleBufferBit6Qcom = 0x40000000u,
	[RequiredByFeature("GL_QCOM_tiled_rendering", Api = "gles1|gles2")]
	MultisampleBufferBit7Qcom = 0x80000000u
}
