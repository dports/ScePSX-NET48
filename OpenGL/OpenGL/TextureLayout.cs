using Khronos;

namespace OpenGL;

public enum TextureLayout
{
	[RequiredByFeature("GL_EXT_semaphore", Api = "gl|gles2")]
	LayoutDepthReadOnlyStencilAttachmentExt = 38192,
	[RequiredByFeature("GL_EXT_semaphore", Api = "gl|gles2")]
	LayoutDepthAttachmentStencilReadOnlyExt = 38193,
	[RequiredByFeature("GL_EXT_semaphore", Api = "gl|gles2")]
	LayoutGeneralExt = 38285,
	[RequiredByFeature("GL_EXT_semaphore", Api = "gl|gles2")]
	LayoutColorAttachmentExt = 38286,
	[RequiredByFeature("GL_EXT_semaphore", Api = "gl|gles2")]
	LayoutDepthStencilAttachmentExt = 38287,
	[RequiredByFeature("GL_EXT_semaphore", Api = "gl|gles2")]
	LayoutDepthStencilReadOnlyExt = 38288,
	[RequiredByFeature("GL_EXT_semaphore", Api = "gl|gles2")]
	LayoutShaderReadOnlyExt = 38289,
	[RequiredByFeature("GL_EXT_semaphore", Api = "gl|gles2")]
	LayoutTransferSrcExt = 38290,
	[RequiredByFeature("GL_EXT_semaphore", Api = "gl|gles2")]
	LayoutTransferDstExt = 38291
}
