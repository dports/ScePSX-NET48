using System;
using Khronos;

namespace OpenGL;

[Flags]
public enum PathMetricMask : uint
{
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	GlyphWidthBitNv = 1u,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	GlyphHeightBitNv = 2u,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	GlyphHorizontalBearingXBitNv = 4u,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	GlyphHorizontalBearingYBitNv = 8u,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	GlyphHorizontalBearingAdvanceBitNv = 0x10u,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	GlyphVerticalBearingXBitNv = 0x20u,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	GlyphVerticalBearingYBitNv = 0x40u,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	GlyphVerticalBearingAdvanceBitNv = 0x80u,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	GlyphHasKerningBitNv = 0x100u,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	FontXMinBoundsBitNv = 0x10000u,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	FontYMinBoundsBitNv = 0x20000u,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	FontXMaxBoundsBitNv = 0x40000u,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	FontYMaxBoundsBitNv = 0x80000u,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	FontUnitsPerEmBitNv = 0x100000u,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	FontAscenderBitNv = 0x200000u,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	FontDescenderBitNv = 0x400000u,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	FontHeightBitNv = 0x800000u,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	FontMaxAdvanceWidthBitNv = 0x1000000u,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	FontMaxAdvanceHeightBitNv = 0x2000000u,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	FontUnderlinePositionBitNv = 0x4000000u,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	FontUnderlineThicknessBitNv = 0x8000000u,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	FontHasKerningBitNv = 0x10000000u,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	FontNumGlyphIndicesBitNv = 0x20000000u
}
