using System;
using Khronos;

namespace OpenGL;

[Flags]
public enum VertexHintsMaskPGI : uint
{
	[RequiredByFeature("GL_PGI_vertex_hints")]
	Vertex23BitPgi = 4u,
	[RequiredByFeature("GL_PGI_vertex_hints")]
	Vertex4BitPgi = 8u,
	[RequiredByFeature("GL_PGI_vertex_hints")]
	Color3BitPgi = 0x10000u,
	[RequiredByFeature("GL_PGI_vertex_hints")]
	Color4BitPgi = 0x20000u,
	[RequiredByFeature("GL_PGI_vertex_hints")]
	EdgeflagBitPgi = 0x40000u,
	[RequiredByFeature("GL_PGI_vertex_hints")]
	IndexBitPgi = 0x80000u,
	[RequiredByFeature("GL_PGI_vertex_hints")]
	MatAmbientBitPgi = 0x100000u,
	[RequiredByFeature("GL_PGI_vertex_hints")]
	MatAmbientAndDiffuseBitPgi = 0x200000u,
	[RequiredByFeature("GL_PGI_vertex_hints")]
	MatDiffuseBitPgi = 0x400000u,
	[RequiredByFeature("GL_PGI_vertex_hints")]
	MatEmissionBitPgi = 0x800000u,
	[RequiredByFeature("GL_PGI_vertex_hints")]
	MatColorIndexesBitPgi = 0x1000000u,
	[RequiredByFeature("GL_PGI_vertex_hints")]
	MatShininessBitPgi = 0x2000000u,
	[RequiredByFeature("GL_PGI_vertex_hints")]
	MatSpecularBitPgi = 0x4000000u,
	[RequiredByFeature("GL_PGI_vertex_hints")]
	NormalBitPgi = 0x8000000u,
	[RequiredByFeature("GL_PGI_vertex_hints")]
	Texcoord1BitPgi = 0x10000000u,
	[RequiredByFeature("GL_PGI_vertex_hints")]
	Texcoord2BitPgi = 0x20000000u,
	[RequiredByFeature("GL_PGI_vertex_hints")]
	Texcoord3BitPgi = 0x40000000u,
	[RequiredByFeature("GL_PGI_vertex_hints")]
	Texcoord4BitPgi = 0x80000000u
}
