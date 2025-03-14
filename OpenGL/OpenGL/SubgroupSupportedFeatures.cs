using System;
using Khronos;

namespace OpenGL;

[Flags]
public enum SubgroupSupportedFeatures : uint
{
	[RequiredByFeature("GL_KHR_shader_subgroup", Api = "gl|glcore|gles2")]
	SubgroupFeatureBasicBitKhr = 1u,
	[RequiredByFeature("GL_KHR_shader_subgroup", Api = "gl|glcore|gles2")]
	SubgroupFeatureVoteBitKhr = 2u,
	[RequiredByFeature("GL_KHR_shader_subgroup", Api = "gl|glcore|gles2")]
	SubgroupFeatureArithmeticBitKhr = 4u,
	[RequiredByFeature("GL_KHR_shader_subgroup", Api = "gl|glcore|gles2")]
	SubgroupFeatureBallotBitKhr = 8u,
	[RequiredByFeature("GL_KHR_shader_subgroup", Api = "gl|glcore|gles2")]
	SubgroupFeatureShuffleBitKhr = 0x10u,
	[RequiredByFeature("GL_KHR_shader_subgroup", Api = "gl|glcore|gles2")]
	SubgroupFeatureShuffleRelativeBitKhr = 0x20u,
	[RequiredByFeature("GL_KHR_shader_subgroup", Api = "gl|glcore|gles2")]
	SubgroupFeatureClusteredBitKhr = 0x40u,
	[RequiredByFeature("GL_KHR_shader_subgroup", Api = "gl|glcore|gles2")]
	SubgroupFeatureQuadBitKhr = 0x80u,
	[RequiredByFeature("GL_NV_shader_subgroup_partitioned", Api = "gl|glcore|gles2")]
	SubgroupFeaturePartitionedBitNv = 0x100u
}
