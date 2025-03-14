using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using Khronos;

namespace OpenGL;

public class Glx : KhronosApi
{
	internal static class Delegates
	{
		[RequiredByFeature("GLX_AMD_gpu_association")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate uint glXGetGPUIDsAMD(uint maxCount, uint* ids);

		[RequiredByFeature("GLX_AMD_gpu_association")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate int glXGetGPUInfoAMD(uint id, int property, int dataType, uint size, nint data);

		[RequiredByFeature("GLX_AMD_gpu_association")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate uint glXGetContextGPUIDAMD(nint ctx);

		[RequiredByFeature("GLX_AMD_gpu_association")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint glXCreateAssociatedContextAMD(uint id, nint share_list);

		[RequiredByFeature("GLX_AMD_gpu_association")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint glXCreateAssociatedContextAttribsAMD(uint id, nint share_context, int* attribList);

		[RequiredByFeature("GLX_AMD_gpu_association")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool glXDeleteAssociatedContextAMD(nint ctx);

		[RequiredByFeature("GLX_AMD_gpu_association")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool glXMakeAssociatedContextCurrentAMD(nint ctx);

		[RequiredByFeature("GLX_AMD_gpu_association")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint glXGetCurrentAssociatedContextAMD();

		[RequiredByFeature("GLX_AMD_gpu_association")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate void glXBlitContextFramebufferAMD(nint dstCtx, int srcX0, int srcY0, int srcX1, int srcY1, int dstX0, int dstY0, int dstX1, int dstY1, uint mask, int filter);

		[RequiredByFeature("GLX_ARB_create_context")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint glXCreateContextAttribsARB(nint dpy, nint config, nint share_context, bool direct, int* attrib_list);

		[RequiredByFeature("GLX_ARB_get_proc_address")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint glXGetProcAddressARB(byte* procName);

		[RequiredByFeature("GLX_EXT_import_context")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint glXGetCurrentDisplayEXT();

		[RequiredByFeature("GLX_EXT_import_context")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate int glXQueryContextInfoEXT(nint dpy, nint context, int attribute, int* value);

		[RequiredByFeature("GLX_EXT_import_context")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint glXGetContextIDEXT(nint context);

		[RequiredByFeature("GLX_EXT_import_context")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint glXImportContextEXT(nint dpy, nint contextID);

		[RequiredByFeature("GLX_EXT_import_context")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate void glXFreeContextEXT(nint dpy, nint context);

		[RequiredByFeature("GLX_EXT_swap_control")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate void glXSwapIntervalEXT(nint dpy, nint drawable, int interval);

		[RequiredByFeature("GLX_EXT_texture_from_pixmap")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate void glXBindTexImageEXT(nint dpy, nint drawable, int buffer, int* attrib_list);

		[RequiredByFeature("GLX_EXT_texture_from_pixmap")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate void glXReleaseTexImageEXT(nint dpy, nint drawable, int buffer);

		[RequiredByFeature("GLX_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint glXChooseVisual(nint dpy, int screen, int* attribList);

		[RequiredByFeature("GLX_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint glXCreateContext(nint dpy, nint vis, nint shareList, bool direct);

		[RequiredByFeature("GLX_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate void glXDestroyContext(nint dpy, nint ctx);

		[RequiredByFeature("GLX_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool glXMakeCurrent(nint dpy, nint drawable, nint ctx);

		[RequiredByFeature("GLX_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate void glXCopyContext(nint dpy, nint src, nint dst, uint mask);

		[RequiredByFeature("GLX_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate void glXSwapBuffers(nint dpy, nint drawable);

		[RequiredByFeature("GLX_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint glXCreateGLXPixmap(nint dpy, nint visual, nint pixmap);

		[RequiredByFeature("GLX_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate void glXDestroyGLXPixmap(nint dpy, nint pixmap);

		[RequiredByFeature("GLX_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool glXQueryExtension(nint dpy, int* errorb, int* @event);

		[RequiredByFeature("GLX_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool glXQueryVersion(nint dpy, int* maj, int* min);

		[RequiredByFeature("GLX_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool glXIsDirect(nint dpy, nint ctx);

		[RequiredByFeature("GLX_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate int glXGetConfig(nint dpy, nint visual, int attrib, int* value);

		[RequiredByFeature("GLX_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint glXGetCurrentContext();

		[RequiredByFeature("GLX_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint glXGetCurrentDrawable();

		[RequiredByFeature("GLX_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate void glXWaitGL();

		[RequiredByFeature("GLX_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate void glXWaitX();

		[RequiredByFeature("GLX_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate void glXUseXFont(int font, int first, int count, int list);

		[RequiredByFeature("GLX_VERSION_1_1")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint glXQueryExtensionsString(nint dpy, int screen);

		[RequiredByFeature("GLX_VERSION_1_1")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint glXQueryServerString(nint dpy, int screen, int name);

		[RequiredByFeature("GLX_VERSION_1_1")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint glXGetClientString(nint dpy, int name);

		[RequiredByFeature("GLX_VERSION_1_2")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint glXGetCurrentDisplay();

		[RequiredByFeature("GLX_VERSION_1_3")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint* glXGetFBConfigs(nint dpy, int screen, int* nelements);

		[RequiredByFeature("GLX_VERSION_1_3")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint* glXChooseFBConfig(nint dpy, int screen, int* attrib_list, int* nelements);

		[RequiredByFeature("GLX_VERSION_1_3")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate int glXGetFBConfigAttrib(nint dpy, nint config, int attribute, int* value);

		[RequiredByFeature("GLX_VERSION_1_3")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint glXGetVisualFromFBConfig(nint dpy, nint config);

		[RequiredByFeature("GLX_VERSION_1_3")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint glXCreateWindow(nint dpy, nint config, nint win, int* attrib_list);

		[RequiredByFeature("GLX_VERSION_1_3")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate void glXDestroyWindow(nint dpy, nint win);

		[RequiredByFeature("GLX_VERSION_1_3")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint glXCreatePixmap(nint dpy, nint config, nint pixmap, int* attrib_list);

		[RequiredByFeature("GLX_VERSION_1_3")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate void glXDestroyPixmap(nint dpy, nint pixmap);

		[RequiredByFeature("GLX_VERSION_1_3")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint glXCreatePbuffer(nint dpy, nint config, int* attrib_list);

		[RequiredByFeature("GLX_VERSION_1_3")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate void glXDestroyPbuffer(nint dpy, nint pbuf);

		[RequiredByFeature("GLX_VERSION_1_3")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate void glXQueryDrawable(nint dpy, nint draw, int attribute, uint* value);

		[RequiredByFeature("GLX_VERSION_1_3")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint glXCreateNewContext(nint dpy, nint config, int render_type, nint share_list, bool direct);

		[RequiredByFeature("GLX_VERSION_1_3")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool glXMakeContextCurrent(nint dpy, nint draw, nint read, nint ctx);

		[RequiredByFeature("GLX_VERSION_1_3")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint glXGetCurrentReadDrawable();

		[RequiredByFeature("GLX_VERSION_1_3")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate int glXQueryContext(nint dpy, nint ctx, int attribute, int* value);

		[RequiredByFeature("GLX_VERSION_1_3")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate void glXSelectEvent(nint dpy, nint draw, uint event_mask);

		[RequiredByFeature("GLX_VERSION_1_3")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate void glXGetSelectedEvent(nint dpy, nint draw, uint* event_mask);

		[RequiredByFeature("GLX_VERSION_1_4")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint glXGetProcAddress(byte* procName);

		[RequiredByFeature("GLX_MESA_agp_offset")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate uint glXGetAGPOffsetMESA(nint pointer);

		[RequiredByFeature("GLX_MESA_copy_sub_buffer")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate void glXCopySubBufferMESA(nint dpy, nint drawable, int x, int y, int width, int height);

		[RequiredByFeature("GLX_MESA_pixmap_colormap")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint glXCreateGLXPixmapMESA(nint dpy, nint visual, nint pixmap, nint cmap);

		[RequiredByFeature("GLX_MESA_query_renderer")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool glXQueryCurrentRendererIntegerMESA(int attribute, uint* value);

		[RequiredByFeature("GLX_MESA_query_renderer")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint glXQueryCurrentRendererStringMESA(int attribute);

		[RequiredByFeature("GLX_MESA_query_renderer")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool glXQueryRendererIntegerMESA(nint dpy, int screen, int renderer, int attribute, uint* value);

		[RequiredByFeature("GLX_MESA_query_renderer")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint glXQueryRendererStringMESA(nint dpy, int screen, int renderer, int attribute);

		[RequiredByFeature("GLX_MESA_release_buffers")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool glXReleaseBuffersMESA(nint dpy, nint drawable);

		[RequiredByFeature("GLX_MESA_set_3dfx_mode")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool glXSet3DfxModeMESA(int mode);

		[RequiredByFeature("GLX_MESA_swap_control")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate int glXGetSwapIntervalMESA();

		[RequiredByFeature("GLX_MESA_swap_control")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate int glXSwapIntervalMESA(uint interval);

		[RequiredByFeature("GLX_NV_copy_buffer")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate void glXCopyBufferSubDataNV(nint dpy, nint readCtx, nint writeCtx, int readTarget, int writeTarget, nint readOffset, nint writeOffset, uint size);

		[RequiredByFeature("GLX_NV_copy_buffer")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate void glXNamedCopyBufferSubDataNV(nint dpy, nint readCtx, nint writeCtx, uint readBuffer, uint writeBuffer, nint readOffset, nint writeOffset, uint size);

		[RequiredByFeature("GLX_NV_copy_image")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate void glXCopyImageSubDataNV(nint dpy, nint srcCtx, uint srcName, int srcTarget, int srcLevel, int srcX, int srcY, int srcZ, nint dstCtx, uint dstName, int dstTarget, int dstLevel, int dstX, int dstY, int dstZ, int width, int height, int depth);

		[RequiredByFeature("GLX_NV_delay_before_swap")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool glXDelayBeforeSwapNV(nint dpy, nint drawable, float seconds);

		[RequiredByFeature("GLX_NV_present_video")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate uint* glXEnumerateVideoDevicesNV(nint dpy, int screen, int* nelements);

		[RequiredByFeature("GLX_NV_present_video")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate int glXBindVideoDeviceNV(nint dpy, uint video_slot, uint video_device, int* attrib_list);

		[RequiredByFeature("GLX_NV_swap_group")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool glXJoinSwapGroupNV(nint dpy, nint drawable, uint group);

		[RequiredByFeature("GLX_NV_swap_group")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool glXBindSwapBarrierNV(nint dpy, uint group, uint barrier);

		[RequiredByFeature("GLX_NV_swap_group")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool glXQuerySwapGroupNV(nint dpy, nint drawable, uint* group, uint* barrier);

		[RequiredByFeature("GLX_NV_swap_group")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool glXQueryMaxSwapGroupsNV(nint dpy, int screen, uint* maxGroups, uint* maxBarriers);

		[RequiredByFeature("GLX_NV_swap_group")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool glXQueryFrameCountNV(nint dpy, int screen, uint* count);

		[RequiredByFeature("GLX_NV_swap_group")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool glXResetFrameCountNV(nint dpy, int screen);

		[RequiredByFeature("GLX_NV_video_capture")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate int glXBindVideoCaptureDeviceNV(nint dpy, uint video_capture_slot, nint device);

		[RequiredByFeature("GLX_NV_video_capture")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint glXEnumerateVideoCaptureDevicesNV(nint dpy, int screen, int* nelements);

		[RequiredByFeature("GLX_NV_video_capture")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate void glXLockVideoCaptureDeviceNV(nint dpy, nint device);

		[RequiredByFeature("GLX_NV_video_capture")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate int glXQueryVideoCaptureDeviceNV(nint dpy, nint device, int attribute, int* value);

		[RequiredByFeature("GLX_NV_video_capture")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate void glXReleaseVideoCaptureDeviceNV(nint dpy, nint device);

		[RequiredByFeature("GLX_NV_video_out")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate int glXGetVideoDeviceNV(nint dpy, int screen, int numVideoDevices, nint pVideoDevice);

		[RequiredByFeature("GLX_NV_video_out")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate int glXReleaseVideoDeviceNV(nint dpy, int screen, nint VideoDevice);

		[RequiredByFeature("GLX_NV_video_out")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate int glXBindVideoImageNV(nint dpy, nint VideoDevice, nint pbuf, int iVideoBuffer);

		[RequiredByFeature("GLX_NV_video_out")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate int glXReleaseVideoImageNV(nint dpy, nint pbuf);

		[RequiredByFeature("GLX_NV_video_out")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate int glXSendPbufferToVideoNV(nint dpy, nint pbuf, int iBufferType, uint* pulCounterPbuffer, [MarshalAs(UnmanagedType.I1)] bool bBlock);

		[RequiredByFeature("GLX_NV_video_out")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate int glXGetVideoInfoNV(nint dpy, int screen, nint VideoDevice, uint* pulCounterOutputPbuffer, uint* pulCounterOutputVideo);

		[RequiredByFeature("GLX_OML_sync_control")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool glXGetSyncValuesOML(nint dpy, nint drawable, long* ust, long* msc, long* sbc);

		[RequiredByFeature("GLX_OML_sync_control")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool glXGetMscRateOML(nint dpy, nint drawable, int* numerator, int* denominator);

		[RequiredByFeature("GLX_OML_sync_control")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate long glXSwapBuffersMscOML(nint dpy, nint drawable, long target_msc, long divisor, long remainder);

		[RequiredByFeature("GLX_OML_sync_control")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool glXWaitForMscOML(nint dpy, nint drawable, long target_msc, long divisor, long remainder, long* ust, long* msc, long* sbc);

		[RequiredByFeature("GLX_OML_sync_control")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool glXWaitForSbcOML(nint dpy, nint drawable, long target_sbc, long* ust, long* msc, long* sbc);

		[RequiredByFeature("GLX_SGIX_dmbuffer")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool glXAssociateDMPbufferSGIX(nint dpy, nint pbuffer, nint* @params, nint dmbuffer);

		[RequiredByFeature("GLX_SGIX_fbconfig")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate int glXGetFBConfigAttribSGIX(nint dpy, nint config, int attribute, int* value);

		[RequiredByFeature("GLX_SGIX_fbconfig")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint* glXChooseFBConfigSGIX(nint dpy, int screen, int* attrib_list, int* nelements);

		[RequiredByFeature("GLX_SGIX_fbconfig")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint glXCreateGLXPixmapWithConfigSGIX(nint dpy, nint config, nint pixmap);

		[RequiredByFeature("GLX_SGIX_fbconfig")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint glXCreateContextWithConfigSGIX(nint dpy, nint config, int render_type, nint share_list, bool direct);

		[RequiredByFeature("GLX_SGIX_fbconfig")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint glXGetVisualFromFBConfigSGIX(nint dpy, nint config);

		[RequiredByFeature("GLX_SGIX_fbconfig")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint glXGetFBConfigFromVisualSGIX(nint dpy, nint vis);

		[RequiredByFeature("GLX_SGIX_hyperpipe")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint* glXQueryHyperpipeNetworkSGIX(nint dpy, int* npipes);

		[RequiredByFeature("GLX_SGIX_hyperpipe")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate int glXHyperpipeConfigSGIX(nint dpy, int networkId, int npipes, nint cfg, int* hpId);

		[RequiredByFeature("GLX_SGIX_hyperpipe")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint glXQueryHyperpipeConfigSGIX(nint dpy, int hpId, int* npipes);

		[RequiredByFeature("GLX_SGIX_hyperpipe")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate int glXDestroyHyperpipeConfigSGIX(nint dpy, int hpId);

		[RequiredByFeature("GLX_SGIX_hyperpipe")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate int glXBindHyperpipeSGIX(nint dpy, int hpId);

		[RequiredByFeature("GLX_SGIX_hyperpipe")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate int glXQueryHyperpipeBestAttribSGIX(nint dpy, int timeSlice, int attrib, int size, nint attribList, nint returnAttribList);

		[RequiredByFeature("GLX_SGIX_hyperpipe")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate int glXHyperpipeAttribSGIX(nint dpy, int timeSlice, int attrib, int size, nint attribList);

		[RequiredByFeature("GLX_SGIX_hyperpipe")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate int glXQueryHyperpipeAttribSGIX(nint dpy, int timeSlice, int attrib, int size, nint returnAttribList);

		[RequiredByFeature("GLX_SGIX_pbuffer")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint glXCreateGLXPbufferSGIX(nint dpy, nint config, uint width, uint height, int* attrib_list);

		[RequiredByFeature("GLX_SGIX_pbuffer")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate void glXDestroyGLXPbufferSGIX(nint dpy, nint pbuf);

		[RequiredByFeature("GLX_SGIX_pbuffer")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate int glXQueryGLXPbufferSGIX(nint dpy, nint pbuf, int attribute, uint* value);

		[RequiredByFeature("GLX_SGIX_pbuffer")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate void glXSelectEventSGIX(nint dpy, nint drawable, uint mask);

		[RequiredByFeature("GLX_SGIX_pbuffer")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate void glXGetSelectedEventSGIX(nint dpy, nint drawable, uint* mask);

		[RequiredByFeature("GLX_SGIX_swap_barrier")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate void glXBindSwapBarrierSGIX(nint dpy, nint drawable, int barrier);

		[RequiredByFeature("GLX_SGIX_swap_barrier")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool glXQueryMaxSwapBarriersSGIX(nint dpy, int screen, int* max);

		[RequiredByFeature("GLX_SGIX_swap_group")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate void glXJoinSwapGroupSGIX(nint dpy, nint drawable, nint member);

		[RequiredByFeature("GLX_SGIX_video_resize")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate int glXBindChannelToWindowSGIX(nint display, int screen, int channel, nint window);

		[RequiredByFeature("GLX_SGIX_video_resize")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate int glXChannelRectSGIX(nint display, int screen, int channel, int x, int y, int w, int h);

		[RequiredByFeature("GLX_SGIX_video_resize")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate int glXQueryChannelRectSGIX(nint display, int screen, int channel, int* dx, int* dy, int* dw, int* dh);

		[RequiredByFeature("GLX_SGIX_video_resize")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate int glXQueryChannelDeltasSGIX(nint display, int screen, int channel, int* x, int* y, int* w, int* h);

		[RequiredByFeature("GLX_SGIX_video_resize")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate int glXChannelRectSyncSGIX(nint display, int screen, int channel, int synctype);

		[RequiredByFeature("GLX_SGIX_video_source")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint glXCreateGLXVideoSourceSGIX(nint display, int screen, nint server, nint path, int nodeClass, nint drainNode);

		[RequiredByFeature("GLX_SGIX_video_source")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate void glXDestroyGLXVideoSourceSGIX(nint dpy, nint glxvideosource);

		[RequiredByFeature("GLX_SGI_cushion")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate void glXCushionSGI(nint dpy, nint window, float cushion);

		[RequiredByFeature("GLX_SGI_make_current_read")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool glXMakeCurrentReadSGI(nint dpy, nint draw, nint read, nint ctx);

		[RequiredByFeature("GLX_SGI_make_current_read")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint glXGetCurrentReadDrawableSGI();

		[RequiredByFeature("GLX_SGI_swap_control")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate int glXSwapIntervalSGI(int interval);

		[RequiredByFeature("GLX_SGI_video_sync")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate int glXGetVideoSyncSGI(uint* count);

		[RequiredByFeature("GLX_SGI_video_sync")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate int glXWaitVideoSyncSGI(int divisor, int remainder, uint* count);

		[RequiredByFeature("GLX_SUN_get_transparent_index")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate int glXGetTransparentIndexSUN(nint dpy, nint overlay, nint underlay, long* pTransparentIndex);

		[RequiredByFeature("GLX_AMD_gpu_association")]
		internal static glXGetGPUIDsAMD pglXGetGPUIDsAMD;

		[RequiredByFeature("GLX_AMD_gpu_association")]
		internal static glXGetGPUInfoAMD pglXGetGPUInfoAMD;

		[RequiredByFeature("GLX_AMD_gpu_association")]
		internal static glXGetContextGPUIDAMD pglXGetContextGPUIDAMD;

		[RequiredByFeature("GLX_AMD_gpu_association")]
		internal static glXCreateAssociatedContextAMD pglXCreateAssociatedContextAMD;

		[RequiredByFeature("GLX_AMD_gpu_association")]
		internal static glXCreateAssociatedContextAttribsAMD pglXCreateAssociatedContextAttribsAMD;

		[RequiredByFeature("GLX_AMD_gpu_association")]
		internal static glXDeleteAssociatedContextAMD pglXDeleteAssociatedContextAMD;

		[RequiredByFeature("GLX_AMD_gpu_association")]
		internal static glXMakeAssociatedContextCurrentAMD pglXMakeAssociatedContextCurrentAMD;

		[RequiredByFeature("GLX_AMD_gpu_association")]
		internal static glXGetCurrentAssociatedContextAMD pglXGetCurrentAssociatedContextAMD;

		[RequiredByFeature("GLX_AMD_gpu_association")]
		internal static glXBlitContextFramebufferAMD pglXBlitContextFramebufferAMD;

		[RequiredByFeature("GLX_ARB_create_context")]
		internal static glXCreateContextAttribsARB pglXCreateContextAttribsARB;

		[RequiredByFeature("GLX_ARB_get_proc_address")]
		internal static glXGetProcAddressARB pglXGetProcAddressARB;

		[RequiredByFeature("GLX_EXT_import_context")]
		internal static glXGetCurrentDisplayEXT pglXGetCurrentDisplayEXT;

		[RequiredByFeature("GLX_EXT_import_context")]
		internal static glXQueryContextInfoEXT pglXQueryContextInfoEXT;

		[RequiredByFeature("GLX_EXT_import_context")]
		internal static glXGetContextIDEXT pglXGetContextIDEXT;

		[RequiredByFeature("GLX_EXT_import_context")]
		internal static glXImportContextEXT pglXImportContextEXT;

		[RequiredByFeature("GLX_EXT_import_context")]
		internal static glXFreeContextEXT pglXFreeContextEXT;

		[RequiredByFeature("GLX_EXT_swap_control")]
		internal static glXSwapIntervalEXT pglXSwapIntervalEXT;

		[RequiredByFeature("GLX_EXT_texture_from_pixmap")]
		internal static glXBindTexImageEXT pglXBindTexImageEXT;

		[RequiredByFeature("GLX_EXT_texture_from_pixmap")]
		internal static glXReleaseTexImageEXT pglXReleaseTexImageEXT;

		[RequiredByFeature("GLX_VERSION_1_0")]
		internal static glXChooseVisual pglXChooseVisual;

		[RequiredByFeature("GLX_VERSION_1_0")]
		internal static glXCreateContext pglXCreateContext;

		[RequiredByFeature("GLX_VERSION_1_0")]
		internal static glXDestroyContext pglXDestroyContext;

		[RequiredByFeature("GLX_VERSION_1_0")]
		internal static glXMakeCurrent pglXMakeCurrent;

		[RequiredByFeature("GLX_VERSION_1_0")]
		internal static glXCopyContext pglXCopyContext;

		[RequiredByFeature("GLX_VERSION_1_0")]
		internal static glXSwapBuffers pglXSwapBuffers;

		[RequiredByFeature("GLX_VERSION_1_0")]
		internal static glXCreateGLXPixmap pglXCreateGLXPixmap;

		[RequiredByFeature("GLX_VERSION_1_0")]
		internal static glXDestroyGLXPixmap pglXDestroyGLXPixmap;

		[RequiredByFeature("GLX_VERSION_1_0")]
		internal static glXQueryExtension pglXQueryExtension;

		[RequiredByFeature("GLX_VERSION_1_0")]
		internal static glXQueryVersion pglXQueryVersion;

		[RequiredByFeature("GLX_VERSION_1_0")]
		internal static glXIsDirect pglXIsDirect;

		[RequiredByFeature("GLX_VERSION_1_0")]
		internal static glXGetConfig pglXGetConfig;

		[RequiredByFeature("GLX_VERSION_1_0")]
		internal static glXGetCurrentContext pglXGetCurrentContext;

		[RequiredByFeature("GLX_VERSION_1_0")]
		internal static glXGetCurrentDrawable pglXGetCurrentDrawable;

		[RequiredByFeature("GLX_VERSION_1_0")]
		internal static glXWaitGL pglXWaitGL;

		[RequiredByFeature("GLX_VERSION_1_0")]
		internal static glXWaitX pglXWaitX;

		[RequiredByFeature("GLX_VERSION_1_0")]
		internal static glXUseXFont pglXUseXFont;

		[RequiredByFeature("GLX_VERSION_1_1")]
		internal static glXQueryExtensionsString pglXQueryExtensionsString;

		[RequiredByFeature("GLX_VERSION_1_1")]
		internal static glXQueryServerString pglXQueryServerString;

		[RequiredByFeature("GLX_VERSION_1_1")]
		internal static glXGetClientString pglXGetClientString;

		[RequiredByFeature("GLX_VERSION_1_2")]
		internal static glXGetCurrentDisplay pglXGetCurrentDisplay;

		[RequiredByFeature("GLX_VERSION_1_3")]
		internal static glXGetFBConfigs pglXGetFBConfigs;

		[RequiredByFeature("GLX_VERSION_1_3")]
		internal static glXChooseFBConfig pglXChooseFBConfig;

		[RequiredByFeature("GLX_VERSION_1_3")]
		internal static glXGetFBConfigAttrib pglXGetFBConfigAttrib;

		[RequiredByFeature("GLX_VERSION_1_3")]
		internal static glXGetVisualFromFBConfig pglXGetVisualFromFBConfig;

		[RequiredByFeature("GLX_VERSION_1_3")]
		internal static glXCreateWindow pglXCreateWindow;

		[RequiredByFeature("GLX_VERSION_1_3")]
		internal static glXDestroyWindow pglXDestroyWindow;

		[RequiredByFeature("GLX_VERSION_1_3")]
		internal static glXCreatePixmap pglXCreatePixmap;

		[RequiredByFeature("GLX_VERSION_1_3")]
		internal static glXDestroyPixmap pglXDestroyPixmap;

		[RequiredByFeature("GLX_VERSION_1_3")]
		internal static glXCreatePbuffer pglXCreatePbuffer;

		[RequiredByFeature("GLX_VERSION_1_3")]
		internal static glXDestroyPbuffer pglXDestroyPbuffer;

		[RequiredByFeature("GLX_VERSION_1_3")]
		internal static glXQueryDrawable pglXQueryDrawable;

		[RequiredByFeature("GLX_VERSION_1_3")]
		internal static glXCreateNewContext pglXCreateNewContext;

		[RequiredByFeature("GLX_VERSION_1_3")]
		internal static glXMakeContextCurrent pglXMakeContextCurrent;

		[RequiredByFeature("GLX_VERSION_1_3")]
		internal static glXGetCurrentReadDrawable pglXGetCurrentReadDrawable;

		[RequiredByFeature("GLX_VERSION_1_3")]
		internal static glXQueryContext pglXQueryContext;

		[RequiredByFeature("GLX_VERSION_1_3")]
		internal static glXSelectEvent pglXSelectEvent;

		[RequiredByFeature("GLX_VERSION_1_3")]
		internal static glXGetSelectedEvent pglXGetSelectedEvent;

		[RequiredByFeature("GLX_VERSION_1_4")]
		internal static glXGetProcAddress pglXGetProcAddress;

		[RequiredByFeature("GLX_MESA_agp_offset")]
		internal static glXGetAGPOffsetMESA pglXGetAGPOffsetMESA;

		[RequiredByFeature("GLX_MESA_copy_sub_buffer")]
		internal static glXCopySubBufferMESA pglXCopySubBufferMESA;

		[RequiredByFeature("GLX_MESA_pixmap_colormap")]
		internal static glXCreateGLXPixmapMESA pglXCreateGLXPixmapMESA;

		[RequiredByFeature("GLX_MESA_query_renderer")]
		internal static glXQueryCurrentRendererIntegerMESA pglXQueryCurrentRendererIntegerMESA;

		[RequiredByFeature("GLX_MESA_query_renderer")]
		internal static glXQueryCurrentRendererStringMESA pglXQueryCurrentRendererStringMESA;

		[RequiredByFeature("GLX_MESA_query_renderer")]
		internal static glXQueryRendererIntegerMESA pglXQueryRendererIntegerMESA;

		[RequiredByFeature("GLX_MESA_query_renderer")]
		internal static glXQueryRendererStringMESA pglXQueryRendererStringMESA;

		[RequiredByFeature("GLX_MESA_release_buffers")]
		internal static glXReleaseBuffersMESA pglXReleaseBuffersMESA;

		[RequiredByFeature("GLX_MESA_set_3dfx_mode")]
		internal static glXSet3DfxModeMESA pglXSet3DfxModeMESA;

		[RequiredByFeature("GLX_MESA_swap_control")]
		internal static glXGetSwapIntervalMESA pglXGetSwapIntervalMESA;

		[RequiredByFeature("GLX_MESA_swap_control")]
		internal static glXSwapIntervalMESA pglXSwapIntervalMESA;

		[RequiredByFeature("GLX_NV_copy_buffer")]
		internal static glXCopyBufferSubDataNV pglXCopyBufferSubDataNV;

		[RequiredByFeature("GLX_NV_copy_buffer")]
		internal static glXNamedCopyBufferSubDataNV pglXNamedCopyBufferSubDataNV;

		[RequiredByFeature("GLX_NV_copy_image")]
		internal static glXCopyImageSubDataNV pglXCopyImageSubDataNV;

		[RequiredByFeature("GLX_NV_delay_before_swap")]
		internal static glXDelayBeforeSwapNV pglXDelayBeforeSwapNV;

		[RequiredByFeature("GLX_NV_present_video")]
		internal static glXEnumerateVideoDevicesNV pglXEnumerateVideoDevicesNV;

		[RequiredByFeature("GLX_NV_present_video")]
		internal static glXBindVideoDeviceNV pglXBindVideoDeviceNV;

		[RequiredByFeature("GLX_NV_swap_group")]
		internal static glXJoinSwapGroupNV pglXJoinSwapGroupNV;

		[RequiredByFeature("GLX_NV_swap_group")]
		internal static glXBindSwapBarrierNV pglXBindSwapBarrierNV;

		[RequiredByFeature("GLX_NV_swap_group")]
		internal static glXQuerySwapGroupNV pglXQuerySwapGroupNV;

		[RequiredByFeature("GLX_NV_swap_group")]
		internal static glXQueryMaxSwapGroupsNV pglXQueryMaxSwapGroupsNV;

		[RequiredByFeature("GLX_NV_swap_group")]
		internal static glXQueryFrameCountNV pglXQueryFrameCountNV;

		[RequiredByFeature("GLX_NV_swap_group")]
		internal static glXResetFrameCountNV pglXResetFrameCountNV;

		[RequiredByFeature("GLX_NV_video_capture")]
		internal static glXBindVideoCaptureDeviceNV pglXBindVideoCaptureDeviceNV;

		[RequiredByFeature("GLX_NV_video_capture")]
		internal static glXEnumerateVideoCaptureDevicesNV pglXEnumerateVideoCaptureDevicesNV;

		[RequiredByFeature("GLX_NV_video_capture")]
		internal static glXLockVideoCaptureDeviceNV pglXLockVideoCaptureDeviceNV;

		[RequiredByFeature("GLX_NV_video_capture")]
		internal static glXQueryVideoCaptureDeviceNV pglXQueryVideoCaptureDeviceNV;

		[RequiredByFeature("GLX_NV_video_capture")]
		internal static glXReleaseVideoCaptureDeviceNV pglXReleaseVideoCaptureDeviceNV;

		[RequiredByFeature("GLX_NV_video_out")]
		internal static glXGetVideoDeviceNV pglXGetVideoDeviceNV;

		[RequiredByFeature("GLX_NV_video_out")]
		internal static glXReleaseVideoDeviceNV pglXReleaseVideoDeviceNV;

		[RequiredByFeature("GLX_NV_video_out")]
		internal static glXBindVideoImageNV pglXBindVideoImageNV;

		[RequiredByFeature("GLX_NV_video_out")]
		internal static glXReleaseVideoImageNV pglXReleaseVideoImageNV;

		[RequiredByFeature("GLX_NV_video_out")]
		internal static glXSendPbufferToVideoNV pglXSendPbufferToVideoNV;

		[RequiredByFeature("GLX_NV_video_out")]
		internal static glXGetVideoInfoNV pglXGetVideoInfoNV;

		[RequiredByFeature("GLX_OML_sync_control")]
		internal static glXGetSyncValuesOML pglXGetSyncValuesOML;

		[RequiredByFeature("GLX_OML_sync_control")]
		internal static glXGetMscRateOML pglXGetMscRateOML;

		[RequiredByFeature("GLX_OML_sync_control")]
		internal static glXSwapBuffersMscOML pglXSwapBuffersMscOML;

		[RequiredByFeature("GLX_OML_sync_control")]
		internal static glXWaitForMscOML pglXWaitForMscOML;

		[RequiredByFeature("GLX_OML_sync_control")]
		internal static glXWaitForSbcOML pglXWaitForSbcOML;

		[RequiredByFeature("GLX_SGIX_dmbuffer")]
		internal static glXAssociateDMPbufferSGIX pglXAssociateDMPbufferSGIX;

		[RequiredByFeature("GLX_SGIX_fbconfig")]
		internal static glXGetFBConfigAttribSGIX pglXGetFBConfigAttribSGIX;

		[RequiredByFeature("GLX_SGIX_fbconfig")]
		internal static glXChooseFBConfigSGIX pglXChooseFBConfigSGIX;

		[RequiredByFeature("GLX_SGIX_fbconfig")]
		internal static glXCreateGLXPixmapWithConfigSGIX pglXCreateGLXPixmapWithConfigSGIX;

		[RequiredByFeature("GLX_SGIX_fbconfig")]
		internal static glXCreateContextWithConfigSGIX pglXCreateContextWithConfigSGIX;

		[RequiredByFeature("GLX_SGIX_fbconfig")]
		internal static glXGetVisualFromFBConfigSGIX pglXGetVisualFromFBConfigSGIX;

		[RequiredByFeature("GLX_SGIX_fbconfig")]
		internal static glXGetFBConfigFromVisualSGIX pglXGetFBConfigFromVisualSGIX;

		[RequiredByFeature("GLX_SGIX_hyperpipe")]
		internal static glXQueryHyperpipeNetworkSGIX pglXQueryHyperpipeNetworkSGIX;

		[RequiredByFeature("GLX_SGIX_hyperpipe")]
		internal static glXHyperpipeConfigSGIX pglXHyperpipeConfigSGIX;

		[RequiredByFeature("GLX_SGIX_hyperpipe")]
		internal static glXQueryHyperpipeConfigSGIX pglXQueryHyperpipeConfigSGIX;

		[RequiredByFeature("GLX_SGIX_hyperpipe")]
		internal static glXDestroyHyperpipeConfigSGIX pglXDestroyHyperpipeConfigSGIX;

		[RequiredByFeature("GLX_SGIX_hyperpipe")]
		internal static glXBindHyperpipeSGIX pglXBindHyperpipeSGIX;

		[RequiredByFeature("GLX_SGIX_hyperpipe")]
		internal static glXQueryHyperpipeBestAttribSGIX pglXQueryHyperpipeBestAttribSGIX;

		[RequiredByFeature("GLX_SGIX_hyperpipe")]
		internal static glXHyperpipeAttribSGIX pglXHyperpipeAttribSGIX;

		[RequiredByFeature("GLX_SGIX_hyperpipe")]
		internal static glXQueryHyperpipeAttribSGIX pglXQueryHyperpipeAttribSGIX;

		[RequiredByFeature("GLX_SGIX_pbuffer")]
		internal static glXCreateGLXPbufferSGIX pglXCreateGLXPbufferSGIX;

		[RequiredByFeature("GLX_SGIX_pbuffer")]
		internal static glXDestroyGLXPbufferSGIX pglXDestroyGLXPbufferSGIX;

		[RequiredByFeature("GLX_SGIX_pbuffer")]
		internal static glXQueryGLXPbufferSGIX pglXQueryGLXPbufferSGIX;

		[RequiredByFeature("GLX_SGIX_pbuffer")]
		internal static glXSelectEventSGIX pglXSelectEventSGIX;

		[RequiredByFeature("GLX_SGIX_pbuffer")]
		internal static glXGetSelectedEventSGIX pglXGetSelectedEventSGIX;

		[RequiredByFeature("GLX_SGIX_swap_barrier")]
		internal static glXBindSwapBarrierSGIX pglXBindSwapBarrierSGIX;

		[RequiredByFeature("GLX_SGIX_swap_barrier")]
		internal static glXQueryMaxSwapBarriersSGIX pglXQueryMaxSwapBarriersSGIX;

		[RequiredByFeature("GLX_SGIX_swap_group")]
		internal static glXJoinSwapGroupSGIX pglXJoinSwapGroupSGIX;

		[RequiredByFeature("GLX_SGIX_video_resize")]
		internal static glXBindChannelToWindowSGIX pglXBindChannelToWindowSGIX;

		[RequiredByFeature("GLX_SGIX_video_resize")]
		internal static glXChannelRectSGIX pglXChannelRectSGIX;

		[RequiredByFeature("GLX_SGIX_video_resize")]
		internal static glXQueryChannelRectSGIX pglXQueryChannelRectSGIX;

		[RequiredByFeature("GLX_SGIX_video_resize")]
		internal static glXQueryChannelDeltasSGIX pglXQueryChannelDeltasSGIX;

		[RequiredByFeature("GLX_SGIX_video_resize")]
		internal static glXChannelRectSyncSGIX pglXChannelRectSyncSGIX;

		[RequiredByFeature("GLX_SGIX_video_source")]
		internal static glXCreateGLXVideoSourceSGIX pglXCreateGLXVideoSourceSGIX;

		[RequiredByFeature("GLX_SGIX_video_source")]
		internal static glXDestroyGLXVideoSourceSGIX pglXDestroyGLXVideoSourceSGIX;

		[RequiredByFeature("GLX_SGI_cushion")]
		internal static glXCushionSGI pglXCushionSGI;

		[RequiredByFeature("GLX_SGI_make_current_read")]
		internal static glXMakeCurrentReadSGI pglXMakeCurrentReadSGI;

		[RequiredByFeature("GLX_SGI_make_current_read")]
		internal static glXGetCurrentReadDrawableSGI pglXGetCurrentReadDrawableSGI;

		[RequiredByFeature("GLX_SGI_swap_control")]
		internal static glXSwapIntervalSGI pglXSwapIntervalSGI;

		[RequiredByFeature("GLX_SGI_video_sync")]
		internal static glXGetVideoSyncSGI pglXGetVideoSyncSGI;

		[RequiredByFeature("GLX_SGI_video_sync")]
		internal static glXWaitVideoSyncSGI pglXWaitVideoSyncSGI;

		[RequiredByFeature("GLX_SUN_get_transparent_index")]
		internal static glXGetTransparentIndexSUN pglXGetTransparentIndexSUN;
	}

	internal struct XAnyEvent
	{
		public XEventName type;

		public nint serial;

		public bool send_event;

		public nint display;

		public nint window;
	}

	internal struct XKeyEvent
	{
		public XEventName type;

		public nint serial;

		public bool send_event;

		public nint display;

		public nint window;

		public nint root;

		public nint subwindow;

		public nint time;

		public int x;

		public int y;

		public int x_root;

		public int y_root;

		public int state;

		public int keycode;

		public bool same_screen;
	}

	internal struct XButtonEvent
	{
		public XEventName type;

		public nint serial;

		public bool send_event;

		public nint display;

		public nint window;

		public nint root;

		public nint subwindow;

		public nint time;

		public int x;

		public int y;

		public int x_root;

		public int y_root;

		public int state;

		public int button;

		public bool same_screen;
	}

	internal struct XMotionEvent
	{
		public XEventName type;

		public nint serial;

		public bool send_event;

		public nint display;

		public nint window;

		public nint root;

		public nint subwindow;

		public nint time;

		public int x;

		public int y;

		public int x_root;

		public int y_root;

		public int state;

		public byte is_hint;

		public bool same_screen;
	}

	internal struct XCrossingEvent
	{
		public XEventName type;

		public nint serial;

		public bool send_event;

		public nint display;

		public nint window;

		public nint root;

		public nint subwindow;

		public nint time;

		public int x;

		public int y;

		public int x_root;

		public int y_root;

		public NotifyMode mode;

		public NotifyDetail detail;

		public bool same_screen;

		public bool focus;

		public int state;
	}

	internal struct XFocusChangeEvent
	{
		public XEventName type;

		public nint serial;

		public bool send_event;

		public nint display;

		public nint window;

		public int mode;

		public NotifyDetail detail;
	}

	internal struct XKeymapEvent
	{
		public XEventName type;

		public nint serial;

		public bool send_event;

		public nint display;

		public nint window;

		public byte key_vector0;

		public byte key_vector1;

		public byte key_vector2;

		public byte key_vector3;

		public byte key_vector4;

		public byte key_vector5;

		public byte key_vector6;

		public byte key_vector7;

		public byte key_vector8;

		public byte key_vector9;

		public byte key_vector10;

		public byte key_vector11;

		public byte key_vector12;

		public byte key_vector13;

		public byte key_vector14;

		public byte key_vector15;

		public byte key_vector16;

		public byte key_vector17;

		public byte key_vector18;

		public byte key_vector19;

		public byte key_vector20;

		public byte key_vector21;

		public byte key_vector22;

		public byte key_vector23;

		public byte key_vector24;

		public byte key_vector25;

		public byte key_vector26;

		public byte key_vector27;

		public byte key_vector28;

		public byte key_vector29;

		public byte key_vector30;

		public byte key_vector31;
	}

	internal struct XExposeEvent
	{
		public XEventName type;

		public nint serial;

		public bool send_event;

		public nint display;

		public nint window;

		public int x;

		public int y;

		public int width;

		public int height;

		public int count;
	}

	internal struct XGraphicsExposeEvent
	{
		public XEventName type;

		public nint serial;

		public bool send_event;

		public nint display;

		public nint drawable;

		public int x;

		public int y;

		public int width;

		public int height;

		public int count;

		public int major_code;

		public int minor_code;
	}

	internal struct XNoExposeEvent
	{
		public XEventName type;

		public nint serial;

		public bool send_event;

		public nint display;

		public nint drawable;

		public int major_code;

		public int minor_code;
	}

	internal struct XVisibilityEvent
	{
		public XEventName type;

		public nint serial;

		public bool send_event;

		public nint display;

		public nint window;

		public int state;
	}

	internal struct XCreateWindowEvent
	{
		public XEventName type;

		public nint serial;

		public bool send_event;

		public nint display;

		public nint parent;

		public nint window;

		public int x;

		public int y;

		public int width;

		public int height;

		public int border_width;

		public bool override_redirect;
	}

	internal struct XDestroyWindowEvent
	{
		public XEventName type;

		public nint serial;

		public bool send_event;

		public nint display;

		public nint xevent;

		public nint window;
	}

	internal struct XUnmapEvent
	{
		public XEventName type;

		public nint serial;

		public bool send_event;

		public nint display;

		public nint xevent;

		public nint window;

		public bool from_configure;
	}

	internal struct XMapEvent
	{
		public XEventName type;

		public nint serial;

		public bool send_event;

		public nint display;

		public nint xevent;

		public nint window;

		public bool override_redirect;
	}

	internal struct XMapRequestEvent
	{
		public XEventName type;

		public nint serial;

		public bool send_event;

		public nint display;

		public nint parent;

		public nint window;
	}

	internal struct XReparentEvent
	{
		public XEventName type;

		public nint serial;

		public bool send_event;

		public nint display;

		public nint xevent;

		public nint window;

		public nint parent;

		public int x;

		public int y;

		public bool override_redirect;
	}

	internal struct XConfigureEvent
	{
		public XEventName type;

		public nint serial;

		public bool send_event;

		public nint display;

		public nint xevent;

		public nint window;

		public int x;

		public int y;

		public int width;

		public int height;

		public int border_width;

		public nint above;

		public bool override_redirect;
	}

	internal struct XGravityEvent
	{
		public XEventName type;

		public nint serial;

		public bool send_event;

		public nint display;

		public nint xevent;

		public nint window;

		public int x;

		public int y;
	}

	internal struct XResizeRequestEvent
	{
		public XEventName type;

		public nint serial;

		public bool send_event;

		public nint display;

		public nint window;

		public int width;

		public int height;
	}

	internal struct XConfigureRequestEvent
	{
		public XEventName type;

		public nint serial;

		public bool send_event;

		public nint display;

		public nint parent;

		public nint window;

		public int x;

		public int y;

		public int width;

		public int height;

		public int border_width;

		public nint above;

		public int detail;

		public nint value_mask;
	}

	internal struct XCirculateEvent
	{
		public XEventName type;

		public nint serial;

		public bool send_event;

		public nint display;

		public nint xevent;

		public nint window;

		public int place;
	}

	internal struct XCirculateRequestEvent
	{
		public XEventName type;

		public nint serial;

		public bool send_event;

		public nint display;

		public nint parent;

		public nint window;

		public int place;
	}

	internal struct XPropertyEvent
	{
		public XEventName type;

		public nint serial;

		public bool send_event;

		public nint display;

		public nint window;

		public nint atom;

		public nint time;

		public int state;
	}

	internal struct XSelectionClearEvent
	{
		public XEventName type;

		public nint serial;

		public bool send_event;

		public nint display;

		public nint window;

		public nint selection;

		public nint time;
	}

	internal struct XSelectionRequestEvent
	{
		public XEventName type;

		public nint serial;

		public bool send_event;

		public nint display;

		public nint owner;

		public nint requestor;

		public nint selection;

		public nint target;

		public nint property;

		public nint time;
	}

	internal struct XSelectionEvent
	{
		public XEventName type;

		public nint serial;

		public bool send_event;

		public nint display;

		public nint requestor;

		public nint selection;

		public nint target;

		public nint property;

		public nint time;
	}

	internal struct XColormapEvent
	{
		public XEventName type;

		public nint serial;

		public bool send_event;

		public nint display;

		public nint window;

		public nint colormap;

		public bool c_new;

		public int state;
	}

	internal struct XClientMessageEvent
	{
		public XEventName type;

		public nint serial;

		public bool send_event;

		public nint display;

		public nint window;

		public nint message_type;

		public int format;

		public nint ptr1;

		public nint ptr2;

		public nint ptr3;

		public nint ptr4;

		public nint ptr5;
	}

	internal struct XMappingEvent
	{
		public XEventName type;

		public nint serial;

		public bool send_event;

		public nint display;

		public nint window;

		public int request;

		public int first_keycode;

		public int count;
	}

	public struct XErrorEvent
	{
		public XEventName type;

		public nint display;

		public nint resourceid;

		public nint serial;

		public byte error_code;

		public XRequest request_code;

		public byte minor_code;
	}

	internal struct XEventPad
	{
		public nint pad0;

		public nint pad1;

		public nint pad2;

		public nint pad3;

		public nint pad4;

		public nint pad5;

		public nint pad6;

		public nint pad7;

		public nint pad8;

		public nint pad9;

		public nint pad10;

		public nint pad11;

		public nint pad12;

		public nint pad13;

		public nint pad14;

		public nint pad15;

		public nint pad16;

		public nint pad17;

		public nint pad18;

		public nint pad19;

		public nint pad20;

		public nint pad21;

		public nint pad22;

		public nint pad23;
	}

	[StructLayout(LayoutKind.Explicit)]
	internal struct XEvent
	{
		[FieldOffset(0)]
		public XEventName type;

		[FieldOffset(0)]
		public XAnyEvent AnyEvent;

		[FieldOffset(0)]
		public XKeyEvent KeyEvent;

		[FieldOffset(0)]
		public XButtonEvent ButtonEvent;

		[FieldOffset(0)]
		public XMotionEvent MotionEvent;

		[FieldOffset(0)]
		public XCrossingEvent CrossingEvent;

		[FieldOffset(0)]
		public XFocusChangeEvent FocusChangeEvent;

		[FieldOffset(0)]
		public XExposeEvent ExposeEvent;

		[FieldOffset(0)]
		public XGraphicsExposeEvent GraphicsExposeEvent;

		[FieldOffset(0)]
		public XNoExposeEvent NoExposeEvent;

		[FieldOffset(0)]
		public XVisibilityEvent VisibilityEvent;

		[FieldOffset(0)]
		public XCreateWindowEvent CreateWindowEvent;

		[FieldOffset(0)]
		public XDestroyWindowEvent DestroyWindowEvent;

		[FieldOffset(0)]
		public XUnmapEvent UnmapEvent;

		[FieldOffset(0)]
		public XMapEvent MapEvent;

		[FieldOffset(0)]
		public XMapRequestEvent MapRequestEvent;

		[FieldOffset(0)]
		public XReparentEvent ReparentEvent;

		[FieldOffset(0)]
		public XConfigureEvent ConfigureEvent;

		[FieldOffset(0)]
		public XGravityEvent GravityEvent;

		[FieldOffset(0)]
		public XResizeRequestEvent ResizeRequestEvent;

		[FieldOffset(0)]
		public XConfigureRequestEvent ConfigureRequestEvent;

		[FieldOffset(0)]
		public XCirculateEvent CirculateEvent;

		[FieldOffset(0)]
		public XCirculateRequestEvent CirculateRequestEvent;

		[FieldOffset(0)]
		public XPropertyEvent PropertyEvent;

		[FieldOffset(0)]
		public XSelectionClearEvent SelectionClearEvent;

		[FieldOffset(0)]
		public XSelectionRequestEvent SelectionRequestEvent;

		[FieldOffset(0)]
		public XSelectionEvent SelectionEvent;

		[FieldOffset(0)]
		public XColormapEvent ColormapEvent;

		[FieldOffset(0)]
		public XClientMessageEvent ClientMessageEvent;

		[FieldOffset(0)]
		public XMappingEvent MappingEvent;

		[FieldOffset(0)]
		public XErrorEvent ErrorEvent;

		[FieldOffset(0)]
		public XKeymapEvent KeymapEvent;

		[FieldOffset(0)]
		public XEventPad Pad;

		public override string ToString()
		{
			return type switch
			{
				XEventName.PropertyNotify => ToString(PropertyEvent), 
				XEventName.ResizeRequest => ToString(ResizeRequestEvent), 
				XEventName.ConfigureNotify => ToString(ConfigureEvent), 
				_ => type.ToString(), 
			};
		}

		public static string ToString(object ev)
		{
			string text = string.Empty;
			Type type = ev.GetType();
			FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (FieldInfo fieldInfo in fields)
			{
				if (text != string.Empty)
				{
					text += ", ";
				}
				object value = fieldInfo.GetValue(ev);
				text = text + fieldInfo.Name + "=" + (value?.ToString() ?? "<null>");
			}
			return type.Name + " (" + text + ")";
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public class XVisualInfo
	{
		public nint visual;

		public nint visualid;

		public int screen;

		public int depth;

		public XVisualClass @class;

		public long redMask;

		public long greenMask;

		public long blueMask;

		public int colormap_size;

		public int bits_per_rgb;

		public override string ToString()
		{
			return string.Format("XVisualInfo {{ visual=0x{0} id=0x{1}, screen={2}, depth={3}, class={4} colormap_size={5} bits_per_rgb={6} }}", ((IntPtr)visual).ToString("X"), ((IntPtr)visualid).ToString("X"), screen, depth, @class, colormap_size, bits_per_rgb);
		}
	}

	public enum XVisualClass
	{
		StaticGray,
		GrayScale,
		StaticColor,
		PseudoColor,
		TrueColor,
		DirectColor
	}

	public struct XSetWindowAttributes
	{
		public nint background_pixmap;

		public nint background_pixel;

		public nint border_pixmap;

		public nint border_pixel;

		public Gravity bit_gravity;

		public Gravity win_gravity;

		public int backing_store;

		public nint backing_planes;

		public nint backing_pixel;

		public bool save_under;

		public nint event_mask;

		public nint do_not_propagate_mask;

		public bool override_redirect;

		public nint colormap;

		public nint cursor;

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("XSetWindowAttributes {");
			if (background_pixmap != IntPtr.Zero)
			{
				stringBuilder.Append(" background_pixmap=0x" + ((IntPtr)background_pixmap).ToString("X"));
			}
			if (background_pixel != IntPtr.Zero)
			{
				stringBuilder.Append(" background_pixel=0x" + ((IntPtr)background_pixel).ToString("X"));
			}
			if (border_pixmap != IntPtr.Zero)
			{
				stringBuilder.Append(" border_pixmap=0x" + ((IntPtr)border_pixmap).ToString("X"));
			}
			if (backing_store != 0)
			{
				stringBuilder.Append(" backing_store=" + backing_store);
			}
			if (backing_planes != IntPtr.Zero)
			{
				stringBuilder.Append(" backing_planes=0x" + ((IntPtr)backing_planes).ToString("X"));
			}
			if (backing_pixel != IntPtr.Zero)
			{
				stringBuilder.Append(" backing_pixel=0x" + ((IntPtr)backing_pixel).ToString("X"));
			}
			if (save_under)
			{
				stringBuilder.Append(" save_under=true");
			}
			if (event_mask != IntPtr.Zero)
			{
				stringBuilder.Append(" event_mask=0x" + ((IntPtr)event_mask).ToString("X"));
			}
			if (do_not_propagate_mask != IntPtr.Zero)
			{
				stringBuilder.Append(" do_not_propagate_mask=0x" + ((IntPtr)do_not_propagate_mask).ToString("X"));
			}
			if (override_redirect)
			{
				stringBuilder.Append(" override_redirect=true");
			}
			if (colormap != IntPtr.Zero)
			{
				stringBuilder.Append(" colormap=0x" + ((IntPtr)colormap).ToString("X"));
			}
			if (cursor != IntPtr.Zero)
			{
				stringBuilder.Append(" cursor=0x" + ((IntPtr)cursor).ToString("X"));
			}
			stringBuilder.Append("}");
			return stringBuilder.ToString();
		}
	}

	internal struct XWindowAttributes
	{
		public int x;

		public int y;

		public int width;

		public int height;

		public int border_width;

		public int depth;

		public nint visual;

		public nint root;

		public int c_class;

		public Gravity bit_gravity;

		public Gravity win_gravity;

		public int backing_store;

		public nint backing_planes;

		public nint backing_pixel;

		public bool save_under;

		public nint colormap;

		public bool map_installed;

		public MapState map_state;

		public nint all_event_masks;

		public nint your_event_mask;

		public nint do_not_propagate_mask;

		public bool override_direct;

		public nint screen;

		public override string ToString()
		{
			return XEvent.ToString(this);
		}
	}

	internal struct XTextProperty
	{
		public string value;

		public nint encoding;

		public int format;

		public nint nitems;
	}

	internal enum XWindowClass
	{
		InputOutput = 1,
		InputOnly
	}

	public enum XEventName
	{
		KeyPress = 2,
		KeyRelease,
		ButtonPress,
		ButtonRelease,
		MotionNotify,
		EnterNotify,
		LeaveNotify,
		FocusIn,
		FocusOut,
		KeymapNotify,
		Expose,
		GraphicsExpose,
		NoExpose,
		VisibilityNotify,
		CreateNotify,
		DestroyNotify,
		UnmapNotify,
		MapNotify,
		MapRequest,
		ReparentNotify,
		ConfigureNotify,
		ConfigureRequest,
		GravityNotify,
		ResizeRequest,
		CirculateNotify,
		CirculateRequest,
		PropertyNotify,
		SelectionClear,
		SelectionRequest,
		SelectionNotify,
		ColormapNotify,
		ClientMessage,
		MappingNotify,
		LASTEvent
	}

	[Flags]
	internal enum SetWindowValuemask
	{
		Nothing = 0,
		BackPixmap = 1,
		BackPixel = 2,
		BorderPixmap = 4,
		BorderPixel = 8,
		BitGravity = 0x10,
		WinGravity = 0x20,
		BackingStore = 0x40,
		BackingPlanes = 0x80,
		BackingPixel = 0x100,
		OverrideRedirect = 0x200,
		SaveUnder = 0x400,
		EventMask = 0x800,
		DontPropagate = 0x1000,
		ColorMap = 0x2000,
		Cursor = 0x4000
	}

	internal enum CreateWindowArgs
	{
		CopyFromParent = 0,
		ParentRelative = 1,
		InputOutput = 1,
		InputOnly = 2
	}

	public enum Gravity
	{
		ForgetGravity,
		NorthWestGravity,
		NorthGravity,
		NorthEastGravity,
		WestGravity,
		CenterGravity,
		EastGravity,
		SouthWestGravity,
		SouthGravity,
		SouthEastGravity,
		StaticGravity
	}

	internal enum XKeySym : uint
	{
		XK_BackSpace = 65288u,
		XK_Tab = 65289u,
		XK_Clear = 65291u,
		XK_Return = 65293u,
		XK_Home = 65360u,
		XK_Left = 65361u,
		XK_Up = 65362u,
		XK_Right = 65363u,
		XK_Down = 65364u,
		XK_Page_Up = 65365u,
		XK_Page_Down = 65366u,
		XK_End = 65367u,
		XK_Begin = 65368u,
		XK_Menu = 65383u,
		XK_Shift_L = 65505u,
		XK_Shift_R = 65506u,
		XK_Control_L = 65507u,
		XK_Control_R = 65508u,
		XK_Caps_Lock = 65509u,
		XK_Shift_Lock = 65510u,
		XK_Meta_L = 65511u,
		XK_Meta_R = 65512u,
		XK_Alt_L = 65513u,
		XK_Alt_R = 65514u,
		XK_Super_L = 65515u,
		XK_Super_R = 65516u,
		XK_Hyper_L = 65517u,
		XK_Hyper_R = 65518u
	}

	[Flags]
	internal enum EventMask
	{
		NoEventMask = 0,
		KeyPressMask = 1,
		KeyReleaseMask = 2,
		ButtonPressMask = 4,
		ButtonReleaseMask = 8,
		EnterWindowMask = 0x10,
		LeaveWindowMask = 0x20,
		PointerMotionMask = 0x40,
		PointerMotionHintMask = 0x80,
		Button1MotionMask = 0x100,
		Button2MotionMask = 0x200,
		Button3MotionMask = 0x400,
		Button4MotionMask = 0x800,
		Button5MotionMask = 0x1000,
		ButtonMotionMask = 0x2000,
		KeymapStateMask = 0x4000,
		ExposureMask = 0x8000,
		VisibilityChangeMask = 0x10000,
		StructureNotifyMask = 0x20000,
		ResizeRedirectMask = 0x40000,
		SubstructureNotifyMask = 0x80000,
		SubstructureRedirectMask = 0x100000,
		FocusChangeMask = 0x200000,
		PropertyChangeMask = 0x400000,
		ColormapChangeMask = 0x800000,
		OwnerGrabButtonMask = 0x1000000
	}

	internal enum GrabMode
	{
		GrabModeSync,
		GrabModeAsync
	}

	internal struct XStandardColormap
	{
		public nint colormap;

		public nint red_max;

		public nint red_mult;

		public nint green_max;

		public nint green_mult;

		public nint blue_max;

		public nint blue_mult;

		public nint base_pixel;

		public nint visualid;

		public nint killid;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 2)]
	internal struct XColor
	{
		public nint pixel;

		public ushort red;

		public ushort green;

		public ushort blue;

		public byte flags;

		public byte pad;
	}

	internal enum Atom
	{
		AnyPropertyType = 0,
		XA_PRIMARY = 1,
		XA_SECONDARY = 2,
		XA_ARC = 3,
		XA_ATOM = 4,
		XA_BITMAP = 5,
		XA_CARDINAL = 6,
		XA_COLORMAP = 7,
		XA_CURSOR = 8,
		XA_CUT_BUFFER0 = 9,
		XA_CUT_BUFFER1 = 10,
		XA_CUT_BUFFER2 = 11,
		XA_CUT_BUFFER3 = 12,
		XA_CUT_BUFFER4 = 13,
		XA_CUT_BUFFER5 = 14,
		XA_CUT_BUFFER6 = 15,
		XA_CUT_BUFFER7 = 16,
		XA_DRAWABLE = 17,
		XA_FONT = 18,
		XA_INTEGER = 19,
		XA_PIXMAP = 20,
		XA_POINT = 21,
		XA_RECTANGLE = 22,
		XA_RESOURCE_MANAGER = 23,
		XA_RGB_COLOR_MAP = 24,
		XA_RGB_BEST_MAP = 25,
		XA_RGB_BLUE_MAP = 26,
		XA_RGB_DEFAULT_MAP = 27,
		XA_RGB_GRAY_MAP = 28,
		XA_RGB_GREEN_MAP = 29,
		XA_RGB_RED_MAP = 30,
		XA_STRING = 31,
		XA_VISUALID = 32,
		XA_WINDOW = 33,
		XA_WM_COMMAND = 34,
		XA_WM_HINTS = 35,
		XA_WM_CLIENT_MACHINE = 36,
		XA_WM_ICON_NAME = 37,
		XA_WM_ICON_SIZE = 38,
		XA_WM_NAME = 39,
		XA_WM_NORMAL_HINTS = 40,
		XA_WM_SIZE_HINTS = 41,
		XA_WM_ZOOM_HINTS = 42,
		XA_MIN_SPACE = 43,
		XA_NORM_SPACE = 44,
		XA_MAX_SPACE = 45,
		XA_END_SPACE = 46,
		XA_SUPERSCRIPT_X = 47,
		XA_SUPERSCRIPT_Y = 48,
		XA_SUBSCRIPT_X = 49,
		XA_SUBSCRIPT_Y = 50,
		XA_UNDERLINE_POSITION = 51,
		XA_UNDERLINE_THICKNESS = 52,
		XA_STRIKEOUT_ASCENT = 53,
		XA_STRIKEOUT_DESCENT = 54,
		XA_ITALIC_ANGLE = 55,
		XA_X_HEIGHT = 56,
		XA_QUAD_WIDTH = 57,
		XA_WEIGHT = 58,
		XA_POINT_SIZE = 59,
		XA_RESOLUTION = 60,
		XA_COPYRIGHT = 61,
		XA_NOTICE = 62,
		XA_FONT_NAME = 63,
		XA_FAMILY_NAME = 64,
		XA_FULL_NAME = 65,
		XA_CAP_HEIGHT = 66,
		XA_WM_CLASS = 67,
		XA_WM_TRANSIENT_FOR = 68,
		XA_LAST_PREDEFINED = 68
	}

	internal struct XScreen
	{
		public nint ext_data;

		public nint display;

		public nint root;

		public int width;

		public int height;

		public int mwidth;

		public int mheight;

		public int ndepths;

		public nint depths;

		public int root_depth;

		public nint root_visual;

		public nint default_gc;

		public nint cmap;

		public nint white_pixel;

		public nint black_pixel;

		public int max_maps;

		public int min_maps;

		public int backing_store;

		public bool save_unders;

		public nint root_input_mask;
	}

	[Flags]
	internal enum ChangeWindowFlags
	{
		CWX = 1,
		CWY = 2,
		CWWidth = 4,
		CWHeight = 8,
		CWBorderWidth = 0x10,
		CWSibling = 0x20,
		CWStackMode = 0x40
	}

	internal enum StackMode
	{
		Above,
		Below,
		TopIf,
		BottomIf,
		Opposite
	}

	internal struct XWindowChanges
	{
		public int x;

		public int y;

		public int width;

		public int height;

		public int border_width;

		public nint sibling;

		public StackMode stack_mode;
	}

	[Flags]
	internal enum ColorFlags
	{
		DoRed = 1,
		DoGreen = 2,
		DoBlue = 4
	}

	internal enum NotifyMode
	{
		NotifyNormal,
		NotifyGrab,
		NotifyUngrab
	}

	internal enum NotifyDetail
	{
		NotifyAncestor,
		NotifyVirtual,
		NotifyInferior,
		NotifyNonlinear,
		NotifyNonlinearVirtual,
		NotifyPointer,
		NotifyPointerRoot,
		NotifyDetailNone
	}

	internal struct MotifWmHints
	{
		public nint flags;

		public nint functions;

		public nint decorations;

		public nint input_mode;

		public nint status;

		public override string ToString()
		{
			return $"MotifWmHints <flags={(MotifFlags)((IntPtr)flags).ToInt32()}, functions={(MotifFunctions)((IntPtr)functions).ToInt32()}, decorations={(MotifDecorations)((IntPtr)decorations).ToInt32()}, input_mode={(MotifInputMode)((IntPtr)input_mode).ToInt32()}, status={((IntPtr)status).ToInt32()}";
		}
	}

	[Flags]
	internal enum MotifFlags
	{
		Functions = 1,
		Decorations = 2,
		InputMode = 4,
		Status = 8
	}

	[Flags]
	internal enum MotifFunctions
	{
		All = 1,
		Resize = 2,
		Move = 4,
		Minimize = 8,
		Maximize = 0x10,
		Close = 0x20
	}

	[Flags]
	internal enum MotifDecorations
	{
		All = 1,
		Border = 2,
		ResizeH = 4,
		Title = 8,
		Menu = 0x10,
		Minimize = 0x20,
		Maximize = 0x40
	}

	[Flags]
	internal enum MotifInputMode
	{
		Modeless = 0,
		ApplicationModal = 1,
		SystemModal = 2,
		FullApplicationModal = 3
	}

	[Flags]
	internal enum KeyMasks
	{
		ShiftMask = 1,
		LockMask = 2,
		ControlMask = 4,
		Mod1Mask = 8,
		Mod2Mask = 0x10,
		Mod3Mask = 0x20,
		Mod4Mask = 0x40,
		Mod5Mask = 0x80,
		ModMasks = 0xF8
	}

	internal struct XModifierKeymap
	{
		public int max_keypermod;

		public nint modifiermap;
	}

	internal enum PropertyMode
	{
		Replace,
		Prepend,
		Append
	}

	internal struct XKeyBoardState
	{
		[StructLayout(LayoutKind.Explicit)]
		public struct AutoRepeats
		{
			[FieldOffset(0)]
			public byte first;

			[FieldOffset(31)]
			public byte last;
		}

		public int key_click_percent;

		public int bell_percent;

		public uint bell_pitch;

		public uint bell_duration;

		public nint led_mask;

		public int global_auto_repeat;

		public AutoRepeats auto_repeats;
	}

	[Flags]
	internal enum GCFunction
	{
		GCFunction = 1,
		GCPlaneMask = 2,
		GCForeground = 4,
		GCBackground = 8,
		GCLineWidth = 0x10,
		GCLineStyle = 0x20,
		GCCapStyle = 0x40,
		GCJoinStyle = 0x80,
		GCFillStyle = 0x100,
		GCFillRule = 0x200,
		GCTile = 0x400,
		GCStipple = 0x800,
		GCTileStipXOrigin = 0x1000,
		GCTileStipYOrigin = 0x2000,
		GCFont = 0x4000,
		GCSubwindowMode = 0x8000,
		GCGraphicsExposures = 0x10000,
		GCClipXOrigin = 0x20000,
		GCClipYOrigin = 0x40000,
		GCClipMask = 0x80000,
		GCDashOffset = 0x100000,
		GCDashList = 0x200000,
		GCArcMode = 0x400000
	}

	internal enum GCJoinStyle
	{
		JoinMiter,
		JoinRound,
		JoinBevel
	}

	internal enum GCLineStyle
	{
		LineSolid,
		LineOnOffDash,
		LineDoubleDash
	}

	internal enum GCCapStyle
	{
		CapNotLast,
		CapButt,
		CapRound,
		CapProjecting
	}

	internal enum GCFillStyle
	{
		FillSolid,
		FillTiled,
		FillStippled,
		FillOpaqueStppled
	}

	internal enum GCFillRule
	{
		EvenOddRule,
		WindingRule
	}

	internal enum GCArcMode
	{
		ArcChord,
		ArcPieSlice
	}

	internal enum GCSubwindowMode
	{
		ClipByChildren,
		IncludeInferiors
	}

	internal struct XGCValues
	{
		public GXFunction function;

		public nint plane_mask;

		public nint foreground;

		public nint background;

		public int line_width;

		public GCLineStyle line_style;

		public GCCapStyle cap_style;

		public GCJoinStyle join_style;

		public GCFillStyle fill_style;

		public GCFillRule fill_rule;

		public GCArcMode arc_mode;

		public nint tile;

		public nint stipple;

		public int ts_x_origin;

		public int ts_y_origin;

		public nint font;

		public GCSubwindowMode subwindow_mode;

		public bool graphics_exposures;

		public int clip_x_origin;

		public int clib_y_origin;

		public nint clip_mask;

		public int dash_offset;

		public byte dashes;
	}

	internal enum GXFunction
	{
		GXclear,
		GXand,
		GXandReverse,
		GXcopy,
		GXandInverted,
		GXnoop,
		GXxor,
		GXor,
		GXnor,
		GXequiv,
		GXinvert,
		GXorReverse,
		GXcopyInverted,
		GXorInverted,
		GXnand,
		GXset
	}

	internal enum NetWindowManagerState
	{
		Remove,
		Add,
		Toggle
	}

	internal enum RevertTo
	{
		None,
		PointerRoot,
		Parent
	}

	internal enum MapState
	{
		IsUnmapped,
		IsUnviewable,
		IsViewable
	}

	internal enum CursorFontShape
	{
		XC_X_cursor = 0,
		XC_arrow = 2,
		XC_based_arrow_down = 4,
		XC_based_arrow_up = 6,
		XC_boat = 8,
		XC_bogosity = 10,
		XC_bottom_left_corner = 12,
		XC_bottom_right_corner = 14,
		XC_bottom_side = 16,
		XC_bottom_tee = 18,
		XC_box_spiral = 20,
		XC_center_ptr = 22,
		XC_circle = 24,
		XC_clock = 26,
		XC_coffee_mug = 28,
		XC_cross = 30,
		XC_cross_reverse = 32,
		XC_crosshair = 34,
		XC_diamond_cross = 36,
		XC_dot = 38,
		XC_dotbox = 40,
		XC_double_arrow = 42,
		XC_draft_large = 44,
		XC_draft_small = 46,
		XC_draped_box = 48,
		XC_exchange = 50,
		XC_fleur = 52,
		XC_gobbler = 54,
		XC_gumby = 56,
		XC_hand1 = 58,
		XC_hand2 = 60,
		XC_heart = 62,
		XC_icon = 64,
		XC_iron_cross = 66,
		XC_left_ptr = 68,
		XC_left_side = 70,
		XC_left_tee = 72,
		XC_left_button = 74,
		XC_ll_angle = 76,
		XC_lr_angle = 78,
		XC_man = 80,
		XC_middlebutton = 82,
		XC_mouse = 84,
		XC_pencil = 86,
		XC_pirate = 88,
		XC_plus = 90,
		XC_question_arrow = 92,
		XC_right_ptr = 94,
		XC_right_side = 96,
		XC_right_tee = 98,
		XC_rightbutton = 100,
		XC_rtl_logo = 102,
		XC_sailboat = 104,
		XC_sb_down_arrow = 106,
		XC_sb_h_double_arrow = 108,
		XC_sb_left_arrow = 110,
		XC_sb_right_arrow = 112,
		XC_sb_up_arrow = 114,
		XC_sb_v_double_arrow = 116,
		XC_sb_shuttle = 118,
		XC_sizing = 120,
		XC_spider = 122,
		XC_spraycan = 124,
		XC_star = 126,
		XC_target = 128,
		XC_tcross = 130,
		XC_top_left_arrow = 132,
		XC_top_left_corner = 134,
		XC_top_right_corner = 136,
		XC_top_side = 138,
		XC_top_tee = 140,
		XC_trek = 142,
		XC_ul_angle = 144,
		XC_umbrella = 146,
		XC_ur_angle = 148,
		XC_watch = 150,
		XC_xterm = 152,
		XC_num_glyphs = 154
	}

	internal enum SystrayRequest
	{
		SYSTEM_TRAY_REQUEST_DOCK,
		SYSTEM_TRAY_BEGIN_MESSAGE,
		SYSTEM_TRAY_CANCEL_MESSAGE
	}

	[Flags]
	internal enum XSizeHintsFlags
	{
		USPosition = 1,
		USSize = 2,
		PPosition = 4,
		PSize = 8,
		PMinSize = 0x10,
		PMaxSize = 0x20,
		PResizeInc = 0x40,
		PAspect = 0x80,
		PAllHints = 0xFC,
		PBaseSize = 0x100,
		PWinGravity = 0x200
	}

	internal struct XSizeHints
	{
		public nint flags;

		public int x;

		public int y;

		public int width;

		public int height;

		public int min_width;

		public int min_height;

		public int max_width;

		public int max_height;

		public int width_inc;

		public int height_inc;

		public int min_aspect_x;

		public int min_aspect_y;

		public int max_aspect_x;

		public int max_aspect_y;

		public int base_width;

		public int base_height;

		public int win_gravity;
	}

	[Flags]
	internal enum XWMHintsFlags
	{
		InputHint = 1,
		StateHint = 2,
		IconPixmapHint = 4,
		IconWindowHint = 8,
		IconPositionHint = 0x10,
		IconMaskHint = 0x20,
		WindowGroupHint = 0x40,
		AllHints = 0x7F
	}

	internal enum XInitialState
	{
		DontCareState,
		NormalState,
		ZoomState,
		IconicState,
		InactiveState
	}

	internal struct XWMHints
	{
		public nint flags;

		public bool input;

		public XInitialState initial_state;

		public nint icon_pixmap;

		public nint icon_window;

		public int icon_x;

		public int icon_y;

		public nint icon_mask;

		public nint window_group;
	}

	internal struct XIconSize
	{
		public int min_width;

		public int min_height;

		public int max_width;

		public int max_height;

		public int width_inc;

		public int height_inc;
	}

	internal delegate int XErrorHandler(nint DisplayHandle, ref XErrorEvent error_event);

	public enum XRequest : byte
	{
		X_CreateWindow = 1,
		X_ChangeWindowAttributes = 2,
		X_GetWindowAttributes = 3,
		X_DestroyWindow = 4,
		X_DestroySubwindows = 5,
		X_ChangeSaveSet = 6,
		X_ReparentWindow = 7,
		X_MapWindow = 8,
		X_MapSubwindows = 9,
		X_UnmapWindow = 10,
		X_UnmapSubwindows = 11,
		X_ConfigureWindow = 12,
		X_CirculateWindow = 13,
		X_GetGeometry = 14,
		X_QueryTree = 15,
		X_InternAtom = 16,
		X_GetAtomName = 17,
		X_ChangeProperty = 18,
		X_DeleteProperty = 19,
		X_GetProperty = 20,
		X_ListProperties = 21,
		X_SetSelectionOwner = 22,
		X_GetSelectionOwner = 23,
		X_ConvertSelection = 24,
		X_SendEvent = 25,
		X_GrabPointer = 26,
		X_UngrabPointer = 27,
		X_GrabButton = 28,
		X_UngrabButton = 29,
		X_ChangeActivePointerGrab = 30,
		X_GrabKeyboard = 31,
		X_UngrabKeyboard = 32,
		X_GrabKey = 33,
		X_UngrabKey = 34,
		X_AllowEvents = 35,
		X_GrabServer = 36,
		X_UngrabServer = 37,
		X_QueryPointer = 38,
		X_GetMotionEvents = 39,
		X_TranslateCoords = 40,
		X_WarpPointer = 41,
		X_SetInputFocus = 42,
		X_GetInputFocus = 43,
		X_QueryKeymap = 44,
		X_OpenFont = 45,
		X_CloseFont = 46,
		X_QueryFont = 47,
		X_QueryTextExtents = 48,
		X_ListFonts = 49,
		X_ListFontsWithInfo = 50,
		X_SetFontPath = 51,
		X_GetFontPath = 52,
		X_CreatePixmap = 53,
		X_FreePixmap = 54,
		X_CreateGC = 55,
		X_ChangeGC = 56,
		X_CopyGC = 57,
		X_SetDashes = 58,
		X_SetClipRectangles = 59,
		X_FreeGC = 60,
		X_ClearArea = 61,
		X_CopyArea = 62,
		X_CopyPlane = 63,
		X_PolyPoint = 64,
		X_PolyLine = 65,
		X_PolySegment = 66,
		X_PolyRectangle = 67,
		X_PolyArc = 68,
		X_FillPoly = 69,
		X_PolyFillRectangle = 70,
		X_PolyFillArc = 71,
		X_PutImage = 72,
		X_GetImage = 73,
		X_PolyText8 = 74,
		X_PolyText16 = 75,
		X_ImageText8 = 76,
		X_ImageText16 = 77,
		X_CreateColormap = 78,
		X_FreeColormap = 79,
		X_CopyColormapAndFree = 80,
		X_InstallColormap = 81,
		X_UninstallColormap = 82,
		X_ListInstalledColormaps = 83,
		X_AllocColor = 84,
		X_AllocNamedColor = 85,
		X_AllocColorCells = 86,
		X_AllocColorPlanes = 87,
		X_FreeColors = 88,
		X_StoreColors = 89,
		X_StoreNamedColor = 90,
		X_QueryColors = 91,
		X_LookupColor = 92,
		X_CreateCursor = 93,
		X_CreateGlyphCursor = 94,
		X_FreeCursor = 95,
		X_RecolorCursor = 96,
		X_QueryBestSize = 97,
		X_QueryExtension = 98,
		X_ListExtensions = 99,
		X_ChangeKeyboardMapping = 100,
		X_GetKeyboardMapping = 101,
		X_ChangeKeyboardControl = 102,
		X_GetKeyboardControl = 103,
		X_Bell = 104,
		X_ChangePointerControl = 105,
		X_GetPointerControl = 106,
		X_SetScreenSaver = 107,
		X_GetScreenSaver = 108,
		X_ChangeHosts = 109,
		X_ListHosts = 110,
		X_SetAccessControl = 111,
		X_SetCloseDownMode = 112,
		X_KillClient = 113,
		X_RotateProperties = 114,
		X_ForceScreenSaver = 115,
		X_SetPointerMapping = 116,
		X_GetPointerMapping = 117,
		X_SetModifierMapping = 118,
		X_GetModifierMapping = 119,
		X_NoOperation = 127
	}

	[Flags]
	internal enum XIMProperties
	{
		XIMPreeditArea = 1,
		XIMPreeditCallbacks = 2,
		XIMPreeditPosition = 4,
		XIMPreeditNothing = 8,
		XIMPreeditNone = 0x10,
		XIMStatusArea = 0x100,
		XIMStatusCallbacks = 0x200,
		XIMStatusNothing = 0x400,
		XIMStatusNone = 0x800
	}

	[Flags]
	internal enum WindowType
	{
		Client = 1,
		Whole = 2,
		Both = 3
	}

	internal enum XEmbedMessage
	{
		EmbeddedNotify = 0,
		WindowActivate = 1,
		WindowDeactivate = 2,
		RequestFocus = 3,
		FocusIn = 4,
		FocusOut = 5,
		FocusNext = 6,
		FocusPrev = 7,
		ModalityOn = 10,
		ModalityOff = 11,
		RegisterAccelerator = 12,
		UnregisterAccelerator = 13,
		ActivateAccelerator = 14
	}

	internal struct XLock : IDisposable
	{
		private readonly nint _LockedDisplay;

		public XLock(nint display)
		{
			if (display == IntPtr.Zero)
			{
				throw new ArgumentException("invalid", "display");
			}
			_LockedDisplay = display;
			if (DeviceContextGLX.IsMultithreadingInitialized)
			{
				UnsafeNativeMethods.XLockDisplay(_LockedDisplay);
			}
		}

		public void Dispose()
		{
			if (DeviceContextGLX.IsMultithreadingInitialized)
			{
				UnsafeNativeMethods.XUnlockDisplay(_LockedDisplay);
			}
		}
	}

	internal static class UnsafeNativeMethods
	{
		[DllImport("libX11")]
		public static extern nint XOpenDisplay(nint display);

		[DllImport("libX11")]
		public static extern int XCloseDisplay(nint display);

		[DllImport("libX11")]
		public static extern nint XSynchronize(nint display, bool onoff);

		[DllImport("libX11")]
		public static extern int XInitThreads();

		[DllImport("libX11")]
		public static extern void XLockDisplay(nint display);

		[DllImport("libX11")]
		public static extern void XUnlockDisplay(nint display);

		[DllImport("libX11")]
		public static extern nint XCreateWindow(nint display, nint parent, int x, int y, int width, int height, int border_width, int depth, int xclass, nint visual, nuint valuemask, ref XSetWindowAttributes attributes);

		[DllImport("libX11")]
		public static extern nint XCreateSimpleWindow(nint display, nint parent, int x, int y, int width, int height, int border_width, nuint border, nuint background);

		[DllImport("libX11")]
		public static extern int XMapWindow(nint display, nint window);

		[DllImport("libX11")]
		public static extern int XUnmapWindow(nint display, nint window);

		[DllImport("libX11", EntryPoint = "XMapSubwindows")]
		public static extern int XMapSubindows(nint display, nint window);

		[DllImport("libX11")]
		public static extern int XUnmapSubwindows(nint display, nint window);

		[DllImport("libX11")]
		public static extern nint XRootWindow(nint display, int screen_number);

		[DllImport("libX11")]
		public static extern nint XNextEvent(nint display, ref XEvent xevent);

		[DllImport("libX11")]
		public static extern int XConnectionNumber(nint diplay);

		[DllImport("libX11")]
		public static extern int XPending(nint diplay);

		[DllImport("libX11")]
		public static extern nint XSelectInput(nint display, nint window, nint mask);

		[DllImport("libX11")]
		public static extern int XDestroyWindow(nint display, nint window);

		[DllImport("libX11")]
		public static extern int XReparentWindow(nint display, nint window, nint parent, int x, int y);

		[DllImport("libX11")]
		public static extern int XMoveResizeWindow(nint display, nint window, int x, int y, int width, int height);

		[DllImport("libX11")]
		public static extern int XResizeWindow(nint display, nint window, int width, int height);

		[DllImport("libX11")]
		public static extern int XGetWindowAttributes(nint display, nint window, ref XWindowAttributes attributes);

		[DllImport("libX11")]
		public static extern int XFlush(nint display);

		[DllImport("libX11")]
		public static extern int XSetWMName(nint display, nint window, ref XTextProperty text_prop);

		[DllImport("libX11")]
		public static extern int XStoreName(nint display, nint window, string window_name);

		[DllImport("libX11")]
		public static extern int XFetchName(nint display, nint window, ref nint window_name);

		[DllImport("libX11")]
		public static extern int XSendEvent(nint display, nint window, bool propagate, nint event_mask, ref XEvent send_event);

		[DllImport("libX11")]
		public static extern int XQueryTree(nint display, nint window, out nint root_return, out nint parent_return, out nint children_return, out int nchildren_return);

		[DllImport("libX11")]
		public static extern int XFree(nint data);

		[DllImport("libX11")]
		public static extern int XRaiseWindow(nint display, nint window);

		[DllImport("libX11")]
		public static extern uint XLowerWindow(nint display, nint window);

		[DllImport("libX11")]
		public static extern uint XConfigureWindow(nint display, nint window, ChangeWindowFlags value_mask, ref XWindowChanges values);

		[DllImport("libX11")]
		public static extern nint XInternAtom(nint display, string atom_name, bool only_if_exists);

		[DllImport("libX11")]
		public static extern int XInternAtoms(nint display, string[] atom_names, int atom_count, bool only_if_exists, nint[] atoms);

		[DllImport("libX11")]
		public static extern int XSetWMProtocols(nint display, nint window, nint[] protocols, int count);

		[DllImport("libX11")]
		public static extern int XGrabPointer(nint display, nint window, bool owner_events, EventMask event_mask, GrabMode pointer_mode, GrabMode keyboard_mode, nint confine_to, nint cursor, nint timestamp);

		[DllImport("libX11")]
		public static extern int XUngrabPointer(nint display, nint timestamp);

		[DllImport("libX11")]
		public static extern bool XQueryPointer(nint display, nint window, out nint root, out nint child, out int root_x, out int root_y, out int win_x, out int win_y, out int keys_buttons);

		[DllImport("libX11")]
		public static extern bool XTranslateCoordinates(nint display, nint src_w, nint dest_w, int src_x, int src_y, out int intdest_x_return, out int dest_y_return, out nint child_return);

		[DllImport("libX11")]
		public static extern bool XGetGeometry(nint display, nint window, out nint root, out int x, out int y, out int width, out int height, out int border_width, out int depth);

		[DllImport("libX11")]
		public static extern bool XGetGeometry(nint display, nint window, nint root, out int x, out int y, out int width, out int height, nint border_width, nint depth);

		[DllImport("libX11")]
		public static extern bool XGetGeometry(nint display, nint window, nint root, out int x, out int y, nint width, nint height, nint border_width, nint depth);

		[DllImport("libX11")]
		public static extern bool XGetGeometry(nint display, nint window, nint root, nint x, nint y, out int width, out int height, nint border_width, nint depth);

		[DllImport("libX11")]
		public static extern uint XWarpPointer(nint display, nint src_w, nint dest_w, int src_x, int src_y, uint src_width, uint src_height, int dest_x, int dest_y);

		[DllImport("libX11")]
		public static extern int XClearWindow(nint display, nint window);

		[DllImport("libX11")]
		public static extern int XClearArea(nint display, nint window, int x, int y, int width, int height, bool exposures);

		[DllImport("libX11")]
		public static extern nint XDefaultScreenOfDisplay(nint display);

		[DllImport("libX11")]
		public static extern int XScreenNumberOfScreen(nint display, nint Screen);

		[DllImport("libX11")]
		public static extern nint XDefaultVisual(nint display, int screen_number);

		[DllImport("libX11")]
		public static extern uint XDefaultDepth(nint display, int screen_number);

		[DllImport("libX11")]
		public static extern int XDefaultScreen(nint display);

		[DllImport("libX11")]
		public static extern nint XDefaultColormap(nint display, int screen_number);

		[DllImport("libX11")]
		public static extern nint XCreateColormap(nint display, nint w, nint visual, int alloc);

		[DllImport("libX11")]
		public static extern int XLookupColor(nint display, nint Colormap, string Coloranem, ref XColor exact_def_color, ref XColor screen_def_color);

		[DllImport("libX11")]
		public static extern int XAllocColor(nint display, nint Colormap, ref XColor colorcell_def);

		[DllImport("libX11")]
		public static extern int XSetTransientForHint(nint display, nint window, nint prop_window);

		[DllImport("libX11")]
		public static extern int XChangeProperty(nint display, nint window, nint property, nint type, int format, PropertyMode mode, ref MotifWmHints data, int nelements);

		[DllImport("libX11")]
		public static extern int XChangeProperty(nint display, nint window, nint property, nint type, int format, PropertyMode mode, ref uint value, int nelements);

		[DllImport("libX11")]
		public static extern int XChangeProperty(nint display, nint window, nint property, nint type, int format, PropertyMode mode, ref nint value, int nelements);

		[DllImport("libX11")]
		public static extern int XChangeProperty(nint display, nint window, nint property, nint type, int format, PropertyMode mode, uint[] data, int nelements);

		[DllImport("libX11")]
		public static extern int XChangeProperty(nint display, nint window, nint property, nint type, int format, PropertyMode mode, int[] data, int nelements);

		[DllImport("libX11")]
		public static extern int XChangeProperty(nint display, nint window, nint property, nint type, int format, PropertyMode mode, nint[] data, int nelements);

		[DllImport("libX11")]
		public static extern int XChangeProperty(nint display, nint window, nint property, nint type, int format, PropertyMode mode, nint atoms, int nelements);

		[DllImport("libX11", CharSet = CharSet.Ansi)]
		public static extern int XChangeProperty(nint display, nint window, nint property, nint type, int format, PropertyMode mode, string text, int text_length);

		[DllImport("libX11")]
		public static extern int XDeleteProperty(nint display, nint window, nint property);

		[DllImport("libX11")]
		public static extern nint XCreateGC(nint display, nint window, nint valuemask, ref XGCValues values);

		[DllImport("libX11")]
		public static extern int XFreeGC(nint display, nint gc);

		[DllImport("libX11")]
		public static extern int XSetFunction(nint display, nint gc, GXFunction function);

		[DllImport("libX11")]
		public static extern int XSetLineAttributes(nint display, nint gc, int line_width, GCLineStyle line_style, GCCapStyle cap_style, GCJoinStyle join_style);

		[DllImport("libX11")]
		public static extern int XDrawLine(nint display, nint drawable, nint gc, int x1, int y1, int x2, int y2);

		[DllImport("libX11")]
		public static extern int XDrawRectangle(nint display, nint drawable, nint gc, int x1, int y1, int width, int height);

		[DllImport("libX11")]
		public static extern int XFillRectangle(nint display, nint drawable, nint gc, int x1, int y1, int width, int height);

		[DllImport("libX11")]
		public static extern int XSetWindowBackground(nint display, nint window, nint background);

		[DllImport("libX11")]
		public static extern int XCopyArea(nint display, nint src, nint dest, nint gc, int src_x, int src_y, int width, int height, int dest_x, int dest_y);

		[DllImport("libX11")]
		public static extern int XGetWindowProperty(nint display, nint window, nint atom, nint long_offset, nint long_length, bool delete, nint req_type, out nint actual_type, out int actual_format, out nint nitems, out nint bytes_after, ref nint prop);

		[DllImport("libX11")]
		public static extern int XSetInputFocus(nint display, nint window, RevertTo revert_to, nint time);

		[DllImport("libX11")]
		public static extern int XIconifyWindow(nint display, nint window, int screen_number);

		[DllImport("libX11")]
		public static extern int XDefineCursor(nint display, nint window, nint cursor);

		[DllImport("libX11")]
		public static extern int XUndefineCursor(nint display, nint window);

		[DllImport("libX11")]
		public static extern int XFreeCursor(nint display, nint cursor);

		[DllImport("libX11")]
		public static extern nint XCreateFontCursor(nint display, CursorFontShape shape);

		[DllImport("libX11")]
		public static extern nint XCreatePixmapCursor(nint display, nint source, nint mask, ref XColor foreground_color, ref XColor background_color, int x_hot, int y_hot);

		[DllImport("libX11")]
		public static extern nint XCreatePixmapFromBitmapData(nint display, nint drawable, byte[] data, int width, int height, nint fg, nint bg, int depth);

		[DllImport("libX11")]
		public static extern nint XCreatePixmap(nint display, nint d, int width, int height, int depth);

		[DllImport("libX11")]
		public static extern nint XFreePixmap(nint display, nint pixmap);

		[DllImport("libX11")]
		public static extern int XQueryBestCursor(nint display, nint drawable, int width, int height, out int best_width, out int best_height);

		[DllImport("libX11")]
		public static extern int XQueryExtension(nint display, string extension_name, ref int major, ref int first_event, ref int first_error);

		[DllImport("libX11")]
		public static extern nint XWhitePixel(nint display, int screen_no);

		[DllImport("libX11")]
		public static extern nint XBlackPixel(nint display, int screen_no);

		[DllImport("libX11")]
		public static extern void XGrabServer(nint display);

		[DllImport("libX11")]
		public static extern void XUngrabServer(nint display);

		[DllImport("libX11")]
		public static extern void XGetWMNormalHints(nint display, nint window, ref XSizeHints hints, out nint supplied_return);

		[DllImport("libX11")]
		public static extern void XSetWMNormalHints(nint display, nint window, ref XSizeHints hints);

		[DllImport("libX11")]
		public static extern void XSetZoomHints(nint display, nint window, ref XSizeHints hints);

		[DllImport("libX11")]
		public static extern void XSetWMHints(nint display, nint window, ref XWMHints wmhints);

		[DllImport("libX11")]
		public static extern int XGetIconSizes(nint display, nint window, out nint size_list, out int count);

		[DllImport("libX11")]
		public static extern nint XSetErrorHandler(XErrorHandler error_handler);

		[DllImport("libX11")]
		public static extern nint XGetErrorText(nint display, byte code, StringBuilder buffer, int length);

		[DllImport("libX11")]
		public static extern int XConvertSelection(nint display, nint selection, nint target, nint property, nint requestor, nint time);

		[DllImport("libX11")]
		public static extern nint XGetSelectionOwner(nint display, nint selection);

		[DllImport("libX11")]
		public static extern int XSetSelectionOwner(nint display, nint selection, nint owner, nint time);

		[DllImport("libX11")]
		public static extern int XSetPlaneMask(nint display, nint gc, nint mask);

		[DllImport("libX11")]
		public static extern int XSetForeground(nint display, nint gc, nuint foreground);

		[DllImport("libX11")]
		public static extern int XSetBackground(nint display, nint gc, nuint background);

		[DllImport("libX11")]
		public static extern int XBell(nint display, int percent);

		[DllImport("libX11")]
		public static extern int XChangeActivePointerGrab(nint display, EventMask event_mask, nint cursor, nint time);

		[DllImport("libX11")]
		public static extern bool XFilterEvent(ref XEvent xevent, nint window);

		[DllImport("libX11")]
		public static extern void XkbSetDetectableAutoRepeat(nint display, bool detectable, nint supported);

		[DllImport("libX11")]
		public static extern void XPeekEvent(nint display, ref XEvent xevent);
	}

	public class Extensions : ExtensionsCollection
	{
		[Extension("GLX_ARB_get_proc_address")]
		public bool GetProcAddress_ARB;

		[Extension("GLX_ARB_multisample")]
		public bool Multisample_ARB;

		[Extension("GLX_ARB_vertex_buffer_object")]
		public bool VertexBufferObject_ARB;

		[Extension("GLX_ARB_fbconfig_float")]
		public bool FbconfigFloat_ARB;

		[Extension("GLX_ARB_framebuffer_sRGB")]
		public bool FramebufferSRGB_ARB;

		[Extension("GLX_ARB_create_context")]
		public bool CreateContext_ARB;

		[Extension("GLX_ARB_create_context_profile")]
		public bool CreateContextProfile_ARB;

		[Extension("GLX_ARB_create_context_robustness")]
		public bool CreateContextRobustness_ARB;

		[Extension("GLX_ARB_robustness_application_isolation")]
		[Extension("GLX_ARB_robustness_share_group_isolation")]
		public bool RobustnessApplicationIsolation_ARB;

		[Extension("GLX_ARB_context_flush_control")]
		public bool ContextFlushControl_ARB;

		[Extension("GLX_ARB_create_context_no_error")]
		public bool CreateContextNoError_ARB;

		[Extension("GLX_SGIS_multisample")]
		public bool Multisample_SGIS;

		[Extension("GLX_EXT_visual_info")]
		public bool VisualInfo_EXT;

		[Extension("GLX_SGI_swap_control")]
		public bool SwapControl_SGI;

		[Extension("GLX_SGI_video_sync")]
		public bool VideoSync_SGI;

		[Extension("GLX_SGI_make_current_read")]
		public bool MakeCurrentRead_SGI;

		[Extension("GLX_SGIX_video_source")]
		public bool VideoSource_SGIX;

		[Extension("GLX_EXT_visual_rating")]
		public bool VisualRating_EXT;

		[Extension("GLX_EXT_import_context")]
		public bool ImportContext_EXT;

		[Extension("GLX_SGIX_fbconfig")]
		public bool Fbconfig_SGIX;

		[Extension("GLX_SGIX_pbuffer")]
		public bool Pbuffer_SGIX;

		[Extension("GLX_SGI_cushion")]
		public bool Cushion_SGI;

		[Extension("GLX_SGIX_video_resize")]
		public bool VideoResize_SGIX;

		[Extension("GLX_SGIX_swap_group")]
		public bool SwapGroup_SGIX;

		[Extension("GLX_SGIX_swap_barrier")]
		public bool SwapBarrier_SGIX;

		[Extension("GLX_SGIS_blended_overlay")]
		public bool BlendedOverlay_SGIS;

		[Extension("GLX_SUN_get_transparent_index")]
		public bool GetTransparentIndex_SUN;

		[Extension("GLX_MESA_copy_sub_buffer")]
		public bool CopySubBuffer_MESA;

		[Extension("GLX_MESA_pixmap_colormap")]
		public bool PixmapColormap_MESA;

		[Extension("GLX_MESA_release_buffers")]
		public bool ReleaseBuffers_MESA;

		[Extension("GLX_MESA_set_3dfx_mode")]
		public bool Set3dfxMode_MESA;

		[Extension("GLX_SGIX_visual_select_group")]
		public bool VisualSelectGroup_SGIX;

		[Extension("GLX_OML_swap_method")]
		public bool SwapMethod_OML;

		[Extension("GLX_OML_sync_control")]
		public bool SyncControl_OML;

		[Extension("GLX_SGIX_hyperpipe")]
		public bool Hyperpipe_SGIX;

		[Extension("GLX_MESA_agp_offset")]
		public bool AgpOffset_MESA;

		[Extension("GLX_EXT_fbconfig_packed_float")]
		public bool FbconfigPackedFloat_EXT;

		[Extension("GLX_EXT_framebuffer_sRGB")]
		public bool FramebufferSRGB_EXT;

		[Extension("GLX_EXT_texture_from_pixmap")]
		public bool TextureFromPixmap_EXT;

		[Extension("GLX_NV_present_video")]
		public bool PresentVideo_NV;

		[Extension("GLX_NV_video_out")]
		public bool VideoOut_NV;

		[Extension("GLX_NV_swap_group")]
		public bool SwapGroup_NV;

		[Extension("GLX_NV_video_capture")]
		public bool VideoCapture_NV;

		[Extension("GLX_NV_copy_image")]
		public bool CopyImage_NV;

		[Extension("GLX_INTEL_swap_event")]
		public bool SwapEvent_INTEL;

		[Extension("GLX_AMD_gpu_association")]
		public bool GpuAssociation_AMD;

		[Extension("GLX_EXT_create_context_es_profile")]
		[Extension("GLX_EXT_create_context_es2_profile")]
		public bool CreateContextEsProfile_EXT;

		[Extension("GLX_EXT_swap_control_tear")]
		public bool SwapControlTear_EXT;

		[Extension("GLX_EXT_buffer_age")]
		public bool BufferAge_EXT;

		[Extension("GLX_NV_delay_before_swap")]
		public bool DelayBeforeSwap_NV;

		[Extension("GLX_MESA_query_renderer")]
		public bool QueryRenderer_MESA;

		[Extension("GLX_NV_copy_buffer")]
		public bool CopyBuffer_NV;

		[Extension("GLX_3DFX_multisample")]
		public bool Multisample_3DFX;

		[Extension("GLX_MESA_swap_control")]
		public bool SwapControl_MESA;

		[Extension("GLX_NV_float_buffer")]
		public bool FloatBuffer_NV;

		[Extension("GLX_NV_multisample_coverage")]
		public bool MultisampleCoverage_NV;

		[Extension("GLX_NV_robustness_video_memory_purge")]
		public bool RobustnessVideoMemoryPurge_NV;

		[Extension("GLX_SGIS_shared_multisample")]
		public bool SharedMultisample_SGIS;

		[Extension("GLX_SGIX_dmbuffer")]
		public bool Dmbuffer_SGIX;

		[Extension("GLX_EXT_swap_control")]
		public bool SwapControl_EXT;

		[Extension("GLX_EXT_stereo_tree")]
		public bool StereoTree_EXT;

		[Extension("GLX_EXT_no_config_context")]
		public bool NoConfigContext_EXT;

		[Extension("GLX_EXT_libglvnd")]
		public bool Libglvnd_EXT;

		internal void Query(DeviceContextGLX deviceContext)
		{
			if (deviceContext == null)
			{
				throw new ArgumentNullException("deviceContext");
			}
			Khronos.KhronosApi.LogComment("Query GLX extensions.");
			string text = null;
			int[] array = new int[1];
			int[] array2 = new int[1];
			using (new XLock(deviceContext.Display))
			{
				QueryVersion(deviceContext.Display, array, array2);
				if (array[0] >= 1 && array2[0] >= 1)
				{
					text = QueryExtensionsString(deviceContext.Display, 0);
				}
			}
			Query(new KhronosVersion(array[0], array2[0], "glx"), text ?? string.Empty);
		}

		public Extensions Clone()
		{
			return (Extensions)MemberwiseClone();
		}
	}

	[RequiredByFeature("GLX_3DFX_multisample")]
	public const int SAMPLE_BUFFERS_3DFX = 32848;

	[RequiredByFeature("GLX_3DFX_multisample")]
	public const int SAMPLES_3DFX = 32849;

	[RequiredByFeature("GLX_AMD_gpu_association")]
	public const int GPU_VENDOR_AMD = 7936;

	[RequiredByFeature("GLX_AMD_gpu_association")]
	public const int GPU_RENDERER_STRING_AMD = 7937;

	[RequiredByFeature("GLX_AMD_gpu_association")]
	public const int GPU_OPENGL_VERSION_STRING_AMD = 7938;

	[RequiredByFeature("GLX_AMD_gpu_association")]
	public const int GPU_FASTEST_TARGET_GPUS_AMD = 8610;

	[RequiredByFeature("GLX_AMD_gpu_association")]
	public const int GPU_RAM_AMD = 8611;

	[RequiredByFeature("GLX_AMD_gpu_association")]
	public const int GPU_CLOCK_AMD = 8612;

	[RequiredByFeature("GLX_AMD_gpu_association")]
	public const int GPU_NUM_PIPES_AMD = 8613;

	[RequiredByFeature("GLX_AMD_gpu_association")]
	public const int GPU_NUM_SIMD_AMD = 8614;

	[RequiredByFeature("GLX_AMD_gpu_association")]
	public const int GPU_NUM_RB_AMD = 8615;

	[RequiredByFeature("GLX_AMD_gpu_association")]
	public const int GPU_NUM_SPI_AMD = 8616;

	[RequiredByFeature("GLX_ARB_context_flush_control")]
	public const int CONTEXT_RELEASE_BEHAVIOR_ARB = 8343;

	[RequiredByFeature("GLX_ARB_context_flush_control")]
	public const int CONTEXT_RELEASE_BEHAVIOR_NONE_ARB = 0;

	[RequiredByFeature("GLX_ARB_context_flush_control")]
	public const int CONTEXT_RELEASE_BEHAVIOR_FLUSH_ARB = 8344;

	[RequiredByFeature("GLX_ARB_create_context")]
	[Log(BitmaskName = "GLXContextFlags")]
	public const uint CONTEXT_DEBUG_BIT_ARB = 1u;

	[RequiredByFeature("GLX_ARB_create_context")]
	[Log(BitmaskName = "GLXContextFlags")]
	public const uint CONTEXT_FORWARD_COMPATIBLE_BIT_ARB = 2u;

	[RequiredByFeature("GLX_ARB_create_context")]
	public const int CONTEXT_MAJOR_VERSION_ARB = 8337;

	[RequiredByFeature("GLX_ARB_create_context")]
	public const int CONTEXT_MINOR_VERSION_ARB = 8338;

	[RequiredByFeature("GLX_ARB_create_context")]
	public const int CONTEXT_FLAGS_ARB = 8340;

	[RequiredByFeature("GLX_ARB_create_context_no_error")]
	public const int CONTEXT_OPENGL_NO_ERROR_ARB = 12723;

	[RequiredByFeature("GLX_ARB_create_context_profile")]
	[Log(BitmaskName = "GLXContextProfileMask")]
	public const uint CONTEXT_CORE_PROFILE_BIT_ARB = 1u;

	[RequiredByFeature("GLX_ARB_create_context_profile")]
	[Log(BitmaskName = "GLXContextProfileMask")]
	public const uint CONTEXT_COMPATIBILITY_PROFILE_BIT_ARB = 2u;

	[RequiredByFeature("GLX_ARB_create_context_profile")]
	public const int CONTEXT_PROFILE_MASK_ARB = 37158;

	[RequiredByFeature("GLX_ARB_create_context_robustness")]
	[Log(BitmaskName = "GLXContextFlags")]
	public const uint CONTEXT_ROBUST_ACCESS_BIT_ARB = 4u;

	[RequiredByFeature("GLX_ARB_create_context_robustness")]
	public const int LOSE_CONTEXT_ON_RESET_ARB = 33362;

	[RequiredByFeature("GLX_ARB_create_context_robustness")]
	public const int CONTEXT_RESET_NOTIFICATION_STRATEGY_ARB = 33366;

	[RequiredByFeature("GLX_ARB_create_context_robustness")]
	public const int NO_RESET_NOTIFICATION_ARB = 33377;

	[RequiredByFeature("GLX_ARB_fbconfig_float")]
	public const int RGBA_FLOAT_TYPE_ARB = 8377;

	[RequiredByFeature("GLX_ARB_fbconfig_float")]
	[Log(BitmaskName = "GLXRenderTypeMask")]
	public const uint RGBA_FLOAT_BIT_ARB = 4u;

	[RequiredByFeature("GLX_ARB_framebuffer_sRGB")]
	[RequiredByFeature("GLX_EXT_framebuffer_sRGB")]
	public const int FRAMEBUFFER_SRGB_CAPABLE_ARB = 8370;

	[RequiredByFeature("GLX_ARB_robustness_application_isolation")]
	[RequiredByFeature("GLX_ARB_robustness_share_group_isolation")]
	[Log(BitmaskName = "GLXContextFlags")]
	public const uint CONTEXT_RESET_ISOLATION_BIT_ARB = 8u;

	[RequiredByFeature("GLX_ARB_vertex_buffer_object")]
	public const int CONTEXT_ALLOW_BUFFER_BYTE_ORDER_MISMATCH_ARB = 8341;

	[RequiredByFeature("GLX_EXT_buffer_age")]
	public const int BACK_BUFFER_AGE_EXT = 8436;

	[RequiredByFeature("GLX_EXT_create_context_es_profile")]
	[Log(BitmaskName = "GLXContextProfileMask")]
	public const uint CONTEXT_ES_PROFILE_BIT_EXT = 4u;

	[RequiredByFeature("GLX_EXT_fbconfig_packed_float")]
	public const int RGBA_UNSIGNED_FLOAT_TYPE_EXT = 8369;

	[RequiredByFeature("GLX_EXT_fbconfig_packed_float")]
	[Log(BitmaskName = "GLXRenderTypeMask")]
	public const uint RGBA_UNSIGNED_FLOAT_BIT_EXT = 8u;

	[RequiredByFeature("GLX_EXT_import_context")]
	public const int SHARE_CONTEXT_EXT = 32778;

	[RequiredByFeature("GLX_EXT_libglvnd")]
	public const int VENDOR_NAMES_EXT = 8438;

	[RequiredByFeature("GLX_EXT_stereo_tree")]
	public const int STEREO_TREE_EXT = 8437;

	[RequiredByFeature("GLX_EXT_stereo_tree")]
	[Log(BitmaskName = "GLXEventMask")]
	public const uint STEREO_NOTIFY_MASK_EXT = 1u;

	[RequiredByFeature("GLX_EXT_stereo_tree")]
	public const int STEREO_NOTIFY_EXT = 0;

	[RequiredByFeature("GLX_EXT_swap_control")]
	public const int SWAP_INTERVAL_EXT = 8433;

	[RequiredByFeature("GLX_EXT_swap_control")]
	public const int MAX_SWAP_INTERVAL_EXT = 8434;

	[RequiredByFeature("GLX_EXT_swap_control_tear")]
	public const int LATE_SWAPS_TEAR_EXT = 8435;

	[RequiredByFeature("GLX_EXT_texture_from_pixmap")]
	[Log(BitmaskName = "GLXBindToTextureTargetMask")]
	public const uint TEXTURE_1D_BIT_EXT = 1u;

	[RequiredByFeature("GLX_EXT_texture_from_pixmap")]
	[Log(BitmaskName = "GLXBindToTextureTargetMask")]
	public const uint TEXTURE_2D_BIT_EXT = 2u;

	[RequiredByFeature("GLX_EXT_texture_from_pixmap")]
	[Log(BitmaskName = "GLXBindToTextureTargetMask")]
	public const uint TEXTURE_RECTANGLE_BIT_EXT = 4u;

	[RequiredByFeature("GLX_EXT_texture_from_pixmap")]
	public const int BIND_TO_TEXTURE_RGB_EXT = 8400;

	[RequiredByFeature("GLX_EXT_texture_from_pixmap")]
	public const int BIND_TO_TEXTURE_RGBA_EXT = 8401;

	[RequiredByFeature("GLX_EXT_texture_from_pixmap")]
	public const int BIND_TO_MIPMAP_TEXTURE_EXT = 8402;

	[RequiredByFeature("GLX_EXT_texture_from_pixmap")]
	public const int BIND_TO_TEXTURE_TARGETS_EXT = 8403;

	[RequiredByFeature("GLX_EXT_texture_from_pixmap")]
	public const int Y_INVERTED_EXT = 8404;

	[RequiredByFeature("GLX_EXT_texture_from_pixmap")]
	public const int TEXTURE_FORMAT_EXT = 8405;

	[RequiredByFeature("GLX_EXT_texture_from_pixmap")]
	public const int TEXTURE_TARGET_EXT = 8406;

	[RequiredByFeature("GLX_EXT_texture_from_pixmap")]
	public const int MIPMAP_TEXTURE_EXT = 8407;

	[RequiredByFeature("GLX_EXT_texture_from_pixmap")]
	public const int TEXTURE_FORMAT_NONE_EXT = 8408;

	[RequiredByFeature("GLX_EXT_texture_from_pixmap")]
	public const int TEXTURE_FORMAT_RGB_EXT = 8409;

	[RequiredByFeature("GLX_EXT_texture_from_pixmap")]
	public const int TEXTURE_FORMAT_RGBA_EXT = 8410;

	[RequiredByFeature("GLX_EXT_texture_from_pixmap")]
	public const int TEXTURE_1D_EXT = 8411;

	[RequiredByFeature("GLX_EXT_texture_from_pixmap")]
	public const int TEXTURE_2D_EXT = 8412;

	[RequiredByFeature("GLX_EXT_texture_from_pixmap")]
	public const int TEXTURE_RECTANGLE_EXT = 8413;

	[RequiredByFeature("GLX_EXT_texture_from_pixmap")]
	public const int FRONT_LEFT_EXT = 8414;

	[RequiredByFeature("GLX_EXT_texture_from_pixmap")]
	public const int FRONT_RIGHT_EXT = 8415;

	[RequiredByFeature("GLX_EXT_texture_from_pixmap")]
	public const int BACK_LEFT_EXT = 8416;

	[RequiredByFeature("GLX_EXT_texture_from_pixmap")]
	public const int BACK_RIGHT_EXT = 8417;

	[RequiredByFeature("GLX_EXT_texture_from_pixmap")]
	public const int AUX0_EXT = 8418;

	[RequiredByFeature("GLX_EXT_texture_from_pixmap")]
	public const int AUX1_EXT = 8419;

	[RequiredByFeature("GLX_EXT_texture_from_pixmap")]
	public const int AUX2_EXT = 8420;

	[RequiredByFeature("GLX_EXT_texture_from_pixmap")]
	public const int AUX3_EXT = 8421;

	[RequiredByFeature("GLX_EXT_texture_from_pixmap")]
	public const int AUX4_EXT = 8422;

	[RequiredByFeature("GLX_EXT_texture_from_pixmap")]
	public const int AUX5_EXT = 8423;

	[RequiredByFeature("GLX_EXT_texture_from_pixmap")]
	public const int AUX6_EXT = 8424;

	[RequiredByFeature("GLX_EXT_texture_from_pixmap")]
	public const int AUX7_EXT = 8425;

	[RequiredByFeature("GLX_EXT_texture_from_pixmap")]
	public const int AUX8_EXT = 8426;

	[RequiredByFeature("GLX_EXT_texture_from_pixmap")]
	public const int AUX9_EXT = 8427;

	[RequiredByFeature("GLX_EXT_visual_rating")]
	public const int VISUAL_CAVEAT_EXT = 32;

	[RequiredByFeature("GLX_EXT_visual_rating")]
	public const int SLOW_VISUAL_EXT = 32769;

	[RequiredByFeature("GLX_EXT_visual_rating")]
	public const int NON_CONFORMANT_VISUAL_EXT = 32781;

	internal static Extensions _CurrentExtensions;

	private static bool _IsRequired;

	private static GetAddressDelegate _GetAddressDelegate;

	private const string Library = "libGL.so.1";

	private static KhronosLogContext _LogContext;

	public static readonly KhronosVersion Version_100;

	public static readonly KhronosVersion Version_110;

	public static readonly KhronosVersion Version_120;

	public static readonly KhronosVersion Version_130;

	public static readonly KhronosVersion Version_140;

	[RequiredByFeature("GLX_VERSION_1_0")]
	public const string EXTENSION_NAME = "GLX";

	[RequiredByFeature("GLX_VERSION_1_0")]
	public const int PbufferClobber = 0;

	[RequiredByFeature("GLX_VERSION_1_0")]
	public const int BufferSwapComplete = 1;

	[RequiredByFeature("GLX_VERSION_1_0")]
	public const int __GLX_NUMBER_EVENTS = 17;

	[RequiredByFeature("GLX_VERSION_1_0")]
	public const int BAD_SCREEN = 1;

	[RequiredByFeature("GLX_VERSION_1_0")]
	public const int BAD_ATTRIBUTE = 2;

	[RequiredByFeature("GLX_VERSION_1_0")]
	public const int NO_EXTENSION = 3;

	[RequiredByFeature("GLX_VERSION_1_0")]
	public const int BAD_VISUAL = 4;

	[RequiredByFeature("GLX_VERSION_1_0")]
	public const int BAD_CONTEXT = 5;

	[RequiredByFeature("GLX_VERSION_1_0")]
	public const int BAD_VALUE = 6;

	[RequiredByFeature("GLX_VERSION_1_0")]
	public const int BAD_ENUM = 7;

	[RequiredByFeature("GLX_VERSION_1_0")]
	public const int USE_GL = 1;

	[RequiredByFeature("GLX_VERSION_1_0")]
	public const int BUFFER_SIZE = 2;

	[RequiredByFeature("GLX_VERSION_1_0")]
	public const int LEVEL = 3;

	[RequiredByFeature("GLX_VERSION_1_0")]
	public const int RGBA = 4;

	[RequiredByFeature("GLX_VERSION_1_0")]
	public const int DOUBLEBUFFER = 5;

	[RequiredByFeature("GLX_VERSION_1_0")]
	public const int STEREO = 6;

	[RequiredByFeature("GLX_VERSION_1_0")]
	public const int AUX_BUFFERS = 7;

	[RequiredByFeature("GLX_VERSION_1_0")]
	public const int RED_SIZE = 8;

	[RequiredByFeature("GLX_VERSION_1_0")]
	public const int GREEN_SIZE = 9;

	[RequiredByFeature("GLX_VERSION_1_0")]
	public const int BLUE_SIZE = 10;

	[RequiredByFeature("GLX_VERSION_1_0")]
	public const int ALPHA_SIZE = 11;

	[RequiredByFeature("GLX_VERSION_1_0")]
	public const int DEPTH_SIZE = 12;

	[RequiredByFeature("GLX_VERSION_1_0")]
	public const int STENCIL_SIZE = 13;

	[RequiredByFeature("GLX_VERSION_1_0")]
	public const int ACCUM_RED_SIZE = 14;

	[RequiredByFeature("GLX_VERSION_1_0")]
	public const int ACCUM_GREEN_SIZE = 15;

	[RequiredByFeature("GLX_VERSION_1_0")]
	public const int ACCUM_BLUE_SIZE = 16;

	[RequiredByFeature("GLX_VERSION_1_0")]
	public const int ACCUM_ALPHA_SIZE = 17;

	[RequiredByFeature("GLX_VERSION_1_1")]
	public const int VENDOR = 1;

	[RequiredByFeature("GLX_VERSION_1_1")]
	public const int VERSION = 2;

	[RequiredByFeature("GLX_VERSION_1_1")]
	public const int EXTENSIONS = 3;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_SGIX_fbconfig")]
	[Log(BitmaskName = "GLXDrawableTypeMask")]
	public const uint WINDOW_BIT = 1u;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_SGIX_fbconfig")]
	[Log(BitmaskName = "GLXDrawableTypeMask")]
	public const uint PIXMAP_BIT = 2u;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_SGIX_pbuffer")]
	[Log(BitmaskName = "GLXDrawableTypeMask")]
	public const uint PBUFFER_BIT = 4u;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_SGIX_fbconfig")]
	[Log(BitmaskName = "GLXRenderTypeMask")]
	public const uint RGBA_BIT = 1u;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_SGIX_fbconfig")]
	[Log(BitmaskName = "GLXRenderTypeMask")]
	public const uint COLOR_INDEX_BIT = 2u;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[Log(BitmaskName = "GLXEventMask")]
	public const uint PBUFFER_CLOBBER_MASK = 134217728u;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_SGIX_pbuffer")]
	[Log(BitmaskName = "GLXPbufferClobberMask")]
	public const uint FRONT_LEFT_BUFFER_BIT = 1u;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_SGIX_pbuffer")]
	[Log(BitmaskName = "GLXPbufferClobberMask")]
	public const uint FRONT_RIGHT_BUFFER_BIT = 2u;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_SGIX_pbuffer")]
	[Log(BitmaskName = "GLXPbufferClobberMask")]
	public const uint BACK_LEFT_BUFFER_BIT = 4u;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_SGIX_pbuffer")]
	[Log(BitmaskName = "GLXPbufferClobberMask")]
	public const uint BACK_RIGHT_BUFFER_BIT = 8u;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_SGIX_pbuffer")]
	[Log(BitmaskName = "GLXPbufferClobberMask")]
	public const uint AUX_BUFFERS_BIT = 16u;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_SGIX_pbuffer")]
	[Log(BitmaskName = "GLXPbufferClobberMask")]
	public const uint DEPTH_BUFFER_BIT = 32u;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_SGIX_pbuffer")]
	[Log(BitmaskName = "GLXPbufferClobberMask")]
	public const uint STENCIL_BUFFER_BIT = 64u;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_SGIX_pbuffer")]
	[Log(BitmaskName = "GLXPbufferClobberMask")]
	public const uint ACCUM_BUFFER_BIT = 128u;

	[RequiredByFeature("GLX_VERSION_1_3")]
	public const int CONFIG_CAVEAT = 32;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_EXT_visual_info")]
	public const int X_VISUAL_TYPE = 34;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_EXT_visual_info")]
	public const int TRANSPARENT_TYPE = 35;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_EXT_visual_info")]
	public const int TRANSPARENT_INDEX_VALUE = 36;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_EXT_visual_info")]
	public const int TRANSPARENT_RED_VALUE = 37;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_EXT_visual_info")]
	public const int TRANSPARENT_GREEN_VALUE = 38;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_EXT_visual_info")]
	public const int TRANSPARENT_BLUE_VALUE = 39;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_EXT_visual_info")]
	public const int TRANSPARENT_ALPHA_VALUE = 40;

	[RequiredByFeature("GLX_VERSION_1_3")]
	public const uint DONT_CARE = uint.MaxValue;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_EXT_visual_info")]
	[RequiredByFeature("GLX_EXT_visual_rating")]
	public const int NONE = 32768;

	[RequiredByFeature("GLX_VERSION_1_3")]
	public const int SLOW_CONFIG = 32769;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_EXT_visual_info")]
	public const int TRUE_COLOR = 32770;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_EXT_visual_info")]
	public const int DIRECT_COLOR = 32771;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_EXT_visual_info")]
	public const int PSEUDO_COLOR = 32772;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_EXT_visual_info")]
	public const int STATIC_COLOR = 32773;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_EXT_visual_info")]
	public const int GRAY_SCALE = 32774;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_EXT_visual_info")]
	public const int STATIC_GRAY = 32775;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_EXT_visual_info")]
	public const int TRANSPARENT_RGB = 32776;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_EXT_visual_info")]
	public const int TRANSPARENT_INDEX = 32777;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_EXT_import_context")]
	public const int VISUAL_ID = 32779;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_EXT_import_context")]
	[RequiredByFeature("GLX_SGIX_fbconfig")]
	public const int SCREEN = 32780;

	[RequiredByFeature("GLX_VERSION_1_3")]
	public const int NON_CONFORMANT_CONFIG = 32781;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_SGIX_fbconfig")]
	public const int DRAWABLE_TYPE = 32784;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_SGIX_fbconfig")]
	public const int RENDER_TYPE = 32785;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_SGIX_fbconfig")]
	public const int X_RENDERABLE = 32786;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_SGIX_fbconfig")]
	public const int FBCONFIG_ID = 32787;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_SGIX_fbconfig")]
	public const int RGBA_TYPE = 32788;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_SGIX_fbconfig")]
	public const int COLOR_INDEX_TYPE = 32789;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_SGIX_pbuffer")]
	public const int MAX_PBUFFER_WIDTH = 32790;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_SGIX_pbuffer")]
	public const int MAX_PBUFFER_HEIGHT = 32791;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_SGIX_pbuffer")]
	public const int MAX_PBUFFER_PIXELS = 32792;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_SGIX_pbuffer")]
	public const int PRESERVED_CONTENTS = 32795;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_SGIX_pbuffer")]
	public const int LARGEST_PBUFFER = 32796;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_SGIX_pbuffer")]
	public const int WIDTH = 32797;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_SGIX_pbuffer")]
	public const int HEIGHT = 32798;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_SGIX_pbuffer")]
	public const int EVENT_MASK = 32799;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_SGIX_pbuffer")]
	public const int DAMAGED = 32800;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_SGIX_pbuffer")]
	public const int SAVED = 32801;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_SGIX_pbuffer")]
	public const int WINDOW = 32802;

	[RequiredByFeature("GLX_VERSION_1_3")]
	[RequiredByFeature("GLX_SGIX_pbuffer")]
	public const int PBUFFER = 32803;

	[RequiredByFeature("GLX_VERSION_1_3")]
	public const int PBUFFER_HEIGHT = 32832;

	[RequiredByFeature("GLX_VERSION_1_3")]
	public const int PBUFFER_WIDTH = 32833;

	[RequiredByFeature("GLX_VERSION_1_4")]
	[RequiredByFeature("GLX_ARB_multisample")]
	[RequiredByFeature("GLX_SGIS_multisample")]
	public const int SAMPLE_BUFFERS = 100000;

	[RequiredByFeature("GLX_VERSION_1_4")]
	[RequiredByFeature("GLX_ARB_multisample")]
	[RequiredByFeature("GLX_SGIS_multisample")]
	public const int SAMPLES = 100001;

	[RequiredByFeature("GLX_INTEL_swap_event")]
	[Log(BitmaskName = "GLXEventMask")]
	public const uint BUFFER_SWAP_COMPLETE_INTEL_MASK = 67108864u;

	[RequiredByFeature("GLX_INTEL_swap_event")]
	public const int EXCHANGE_COMPLETE_INTEL = 33152;

	[RequiredByFeature("GLX_INTEL_swap_event")]
	public const int COPY_COMPLETE_INTEL = 33153;

	[RequiredByFeature("GLX_INTEL_swap_event")]
	public const int FLIP_COMPLETE_INTEL = 33154;

	[RequiredByFeature("GLX_MESA_query_renderer")]
	public const int RENDERER_VENDOR_ID_MESA = 33155;

	[RequiredByFeature("GLX_MESA_query_renderer")]
	public const int RENDERER_DEVICE_ID_MESA = 33156;

	[RequiredByFeature("GLX_MESA_query_renderer")]
	public const int RENDERER_VERSION_MESA = 33157;

	[RequiredByFeature("GLX_MESA_query_renderer")]
	public const int RENDERER_ACCELERATED_MESA = 33158;

	[RequiredByFeature("GLX_MESA_query_renderer")]
	public const int RENDERER_VIDEO_MEMORY_MESA = 33159;

	[RequiredByFeature("GLX_MESA_query_renderer")]
	public const int RENDERER_UNIFIED_MEMORY_ARCHITECTURE_MESA = 33160;

	[RequiredByFeature("GLX_MESA_query_renderer")]
	public const int RENDERER_PREFERRED_PROFILE_MESA = 33161;

	[RequiredByFeature("GLX_MESA_query_renderer")]
	public const int RENDERER_OPENGL_CORE_PROFILE_VERSION_MESA = 33162;

	[RequiredByFeature("GLX_MESA_query_renderer")]
	public const int RENDERER_OPENGL_COMPATIBILITY_PROFILE_VERSION_MESA = 33163;

	[RequiredByFeature("GLX_MESA_query_renderer")]
	public const int RENDERER_OPENGL_ES_PROFILE_VERSION_MESA = 33164;

	[RequiredByFeature("GLX_MESA_query_renderer")]
	public const int RENDERER_OPENGL_ES2_PROFILE_VERSION_MESA = 33165;

	[RequiredByFeature("GLX_MESA_query_renderer")]
	public const int RENDERER_ID_MESA = 33166;

	[RequiredByFeature("GLX_MESA_set_3dfx_mode")]
	public const int _3DFX_WINDOW_MODE_MESA = 1;

	[RequiredByFeature("GLX_MESA_set_3dfx_mode")]
	public const int _3DFX_FULLSCREEN_MODE_MESA = 2;

	[RequiredByFeature("GLX_NV_float_buffer")]
	public const int FLOAT_COMPONENTS_NV = 8368;

	[RequiredByFeature("GLX_NV_multisample_coverage")]
	public const int COVERAGE_SAMPLES_NV = 100001;

	[RequiredByFeature("GLX_NV_multisample_coverage")]
	public const int COLOR_SAMPLES_NV = 8371;

	[RequiredByFeature("GLX_NV_present_video")]
	public const int NUM_VIDEO_SLOTS_NV = 8432;

	[RequiredByFeature("GLX_NV_robustness_video_memory_purge")]
	public const int GENERATE_RESET_ON_VIDEO_MEMORY_PURGE_NV = 8439;

	[RequiredByFeature("GLX_NV_video_capture")]
	public const int DEVICE_ID_NV = 8397;

	[RequiredByFeature("GLX_NV_video_capture")]
	public const int UNIQUE_ID_NV = 8398;

	[RequiredByFeature("GLX_NV_video_capture")]
	public const int NUM_VIDEO_CAPTURE_SLOTS_NV = 8399;

	[RequiredByFeature("GLX_NV_video_out")]
	public const int VIDEO_OUT_COLOR_NV = 8387;

	[RequiredByFeature("GLX_NV_video_out")]
	public const int VIDEO_OUT_ALPHA_NV = 8388;

	[RequiredByFeature("GLX_NV_video_out")]
	public const int VIDEO_OUT_DEPTH_NV = 8389;

	[RequiredByFeature("GLX_NV_video_out")]
	public const int VIDEO_OUT_COLOR_AND_ALPHA_NV = 8390;

	[RequiredByFeature("GLX_NV_video_out")]
	public const int VIDEO_OUT_COLOR_AND_DEPTH_NV = 8391;

	[RequiredByFeature("GLX_NV_video_out")]
	public const int VIDEO_OUT_FRAME_NV = 8392;

	[RequiredByFeature("GLX_NV_video_out")]
	public const int VIDEO_OUT_FIELD_1_NV = 8393;

	[RequiredByFeature("GLX_NV_video_out")]
	public const int VIDEO_OUT_FIELD_2_NV = 8394;

	[RequiredByFeature("GLX_NV_video_out")]
	public const int VIDEO_OUT_STACKED_FIELDS_1_2_NV = 8395;

	[RequiredByFeature("GLX_NV_video_out")]
	public const int VIDEO_OUT_STACKED_FIELDS_2_1_NV = 8396;

	[RequiredByFeature("GLX_OML_swap_method")]
	public const int SWAP_METHOD_OML = 32864;

	[RequiredByFeature("GLX_OML_swap_method")]
	public const int SWAP_EXCHANGE_OML = 32865;

	[RequiredByFeature("GLX_OML_swap_method")]
	public const int SWAP_COPY_OML = 32866;

	[RequiredByFeature("GLX_OML_swap_method")]
	public const int SWAP_UNDEFINED_OML = 32867;

	[RequiredByFeature("GLX_SGIS_blended_overlay")]
	public const int BLENDED_RGBA_SGIS = 32805;

	[RequiredByFeature("GLX_SGIS_shared_multisample")]
	public const int MULTISAMPLE_SUB_RECT_WIDTH_SGIS = 32806;

	[RequiredByFeature("GLX_SGIS_shared_multisample")]
	public const int MULTISAMPLE_SUB_RECT_HEIGHT_SGIS = 32807;

	[RequiredByFeature("GLX_SGIX_dmbuffer")]
	public const int DIGITAL_MEDIA_PBUFFER_SGIX = 32804;

	[RequiredByFeature("GLX_SGIX_hyperpipe")]
	public const int HYPERPIPE_PIPE_NAME_LENGTH_SGIX = 80;

	[RequiredByFeature("GLX_SGIX_hyperpipe")]
	public const int BAD_HYPERPIPE_CONFIG_SGIX = 91;

	[RequiredByFeature("GLX_SGIX_hyperpipe")]
	public const int BAD_HYPERPIPE_SGIX = 92;

	[RequiredByFeature("GLX_SGIX_hyperpipe")]
	[Log(BitmaskName = "GLXHyperpipeTypeMask")]
	public const int HYPERPIPE_DISPLAY_PIPE_SGIX = 1;

	[RequiredByFeature("GLX_SGIX_hyperpipe")]
	[Log(BitmaskName = "GLXHyperpipeTypeMask")]
	public const int HYPERPIPE_RENDER_PIPE_SGIX = 2;

	[RequiredByFeature("GLX_SGIX_hyperpipe")]
	[Log(BitmaskName = "GLXHyperpipeAttribSGIX")]
	public const int PIPE_RECT_SGIX = 1;

	[RequiredByFeature("GLX_SGIX_hyperpipe")]
	[Log(BitmaskName = "GLXHyperpipeAttribSGIX")]
	public const int PIPE_RECT_LIMITS_SGIX = 2;

	[RequiredByFeature("GLX_SGIX_hyperpipe")]
	[Log(BitmaskName = "GLXHyperpipeAttribSGIX")]
	public const int HYPERPIPE_STEREO_SGIX = 3;

	[RequiredByFeature("GLX_SGIX_hyperpipe")]
	[Log(BitmaskName = "GLXHyperpipeAttribSGIX")]
	public const int HYPERPIPE_PIXEL_AVERAGE_SGIX = 4;

	[RequiredByFeature("GLX_SGIX_hyperpipe")]
	public const int HYPERPIPE_ID_SGIX = 32816;

	[RequiredByFeature("GLX_SGIX_pbuffer")]
	[Log(BitmaskName = "GLXEventMask")]
	public const uint BUFFER_CLOBBER_MASK_SGIX = 134217728u;

	[RequiredByFeature("GLX_SGIX_pbuffer")]
	[Log(BitmaskName = "GLXPbufferClobberMask")]
	public const uint SAMPLE_BUFFERS_BIT_SGIX = 256u;

	[RequiredByFeature("GLX_SGIX_pbuffer")]
	public const int OPTIMAL_PBUFFER_WIDTH_SGIX = 32793;

	[RequiredByFeature("GLX_SGIX_pbuffer")]
	public const int OPTIMAL_PBUFFER_HEIGHT_SGIX = 32794;

	[RequiredByFeature("GLX_SGIX_video_resize")]
	[Log(BitmaskName = "GLXSyncType")]
	public const int SYNC_FRAME_SGIX = 0;

	[RequiredByFeature("GLX_SGIX_video_resize")]
	[Log(BitmaskName = "GLXSyncType")]
	public const int SYNC_SWAP_SGIX = 1;

	[RequiredByFeature("GLX_SGIX_visual_select_group")]
	public const int VISUAL_SELECT_GROUP_SGIX = 32808;

	public static Extensions CurrentExtensions => _CurrentExtensions;

	public static bool IsAvailable => Delegates.pglXCreateContext != null;

	public static bool IsRequired
	{
		get
		{
			if (_IsRequired)
			{
				return IsAvailable;
			}
			return false;
		}
		set
		{
			_IsRequired = value;
		}
	}

	public GetAddressDelegate GetFunctionPointerDelegate
	{
		get
		{
			return _GetAddressDelegate;
		}
		set
		{
			_GetAddressDelegate = value ?? new GetAddressDelegate(KhronosApi.GetProcAddressGLOS);
		}
	}

	[RequiredByFeature("GLX_AMD_gpu_association")]
	public unsafe static uint GetAMD(uint maxCount, [Out] uint[] ids)
	{
		uint result;
		fixed (uint* ids2 = ids)
		{
			result = Delegates.pglXGetGPUIDsAMD(maxCount, ids2);
		}
		return result;
	}

	[RequiredByFeature("GLX_AMD_gpu_association")]
	public static int GetGPUInfoAMD(uint id, int property, int dataType, uint size, nint data)
	{
		return Delegates.pglXGetGPUInfoAMD(id, property, dataType, size, data);
	}

	[RequiredByFeature("GLX_AMD_gpu_association")]
	public static uint GetContextAMD(nint ctx)
	{
		return Delegates.pglXGetContextGPUIDAMD(ctx);
	}

	[RequiredByFeature("GLX_AMD_gpu_association")]
	public static nint CreateAssociatedContextAMD(uint id, nint share_list)
	{
		return Delegates.pglXCreateAssociatedContextAMD(id, share_list);
	}

	[RequiredByFeature("GLX_AMD_gpu_association")]
	public unsafe static nint CreateAssociatedContextAttribsAMD(uint id, nint share_context, int[] attribList)
	{
		nint result;
		fixed (int* attribList2 = attribList)
		{
			result = Delegates.pglXCreateAssociatedContextAttribsAMD(id, share_context, attribList2);
		}
		return result;
	}

	[RequiredByFeature("GLX_AMD_gpu_association")]
	public static bool DeleteAssociatedContextAMD(nint ctx)
	{
		return Delegates.pglXDeleteAssociatedContextAMD(ctx);
	}

	[RequiredByFeature("GLX_AMD_gpu_association")]
	public static bool MakeAssociatedContextCurrentAMD(nint ctx)
	{
		return Delegates.pglXMakeAssociatedContextCurrentAMD(ctx);
	}

	[RequiredByFeature("GLX_AMD_gpu_association")]
	public static nint GetCurrentAssociatedContextAMD()
	{
		return Delegates.pglXGetCurrentAssociatedContextAMD();
	}

	[RequiredByFeature("GLX_AMD_gpu_association")]
	public static void BlitContextFramebufferAMD(nint dstCtx, int srcX0, int srcY0, int srcX1, int srcY1, int dstX0, int dstY0, int dstX1, int dstY1, uint mask, int filter)
	{
		Delegates.pglXBlitContextFramebufferAMD(dstCtx, srcX0, srcY0, srcX1, srcY1, dstX0, dstY0, dstX1, dstY1, mask, filter);
	}

	[RequiredByFeature("GLX_ARB_create_context")]
	public unsafe static nint CreateContextAttribsARB(nint dpy, nint config, nint share_context, bool direct, int[] attrib_list)
	{
		nint result;
		fixed (int* attrib_list2 = attrib_list)
		{
			result = Delegates.pglXCreateContextAttribsARB(dpy, config, share_context, direct, attrib_list2);
		}
		return result;
	}

	[RequiredByFeature("GLX_ARB_get_proc_address")]
	public unsafe static nint GetProcAddressARB(byte[] procName)
	{
		nint result;
		fixed (byte* procName2 = procName)
		{
			result = Delegates.pglXGetProcAddressARB(procName2);
		}
		return result;
	}

	[RequiredByFeature("GLX_EXT_import_context")]
	public static nint GetCurrentDisplayEXT()
	{
		return Delegates.pglXGetCurrentDisplayEXT();
	}

	[RequiredByFeature("GLX_EXT_import_context")]
	public unsafe static int QueryContextInfoEXT(nint dpy, nint context, int attribute, int[] value)
	{
		int result;
		fixed (int* value2 = value)
		{
			result = Delegates.pglXQueryContextInfoEXT(dpy, context, attribute, value2);
		}
		return result;
	}

	[RequiredByFeature("GLX_EXT_import_context")]
	public static nint GetContextIDEXT(nint context)
	{
		return Delegates.pglXGetContextIDEXT(context);
	}

	[RequiredByFeature("GLX_EXT_import_context")]
	public static nint ImportContextEXT(nint dpy, nint contextID)
	{
		return Delegates.pglXImportContextEXT(dpy, contextID);
	}

	[RequiredByFeature("GLX_EXT_import_context")]
	public static void FreeContextEXT(nint dpy, nint context)
	{
		Delegates.pglXFreeContextEXT(dpy, context);
	}

	[RequiredByFeature("GLX_EXT_swap_control")]
	public static void SwapIntervalEXT(nint dpy, nint drawable, int interval)
	{
		Delegates.pglXSwapIntervalEXT(dpy, drawable, interval);
	}

	[RequiredByFeature("GLX_EXT_texture_from_pixmap")]
	public unsafe static void BindTexImageEXT(nint dpy, nint drawable, int buffer, int[] attrib_list)
	{
		fixed (int* attrib_list2 = attrib_list)
		{
			Delegates.pglXBindTexImageEXT(dpy, drawable, buffer, attrib_list2);
		}
	}

	[RequiredByFeature("GLX_EXT_texture_from_pixmap")]
	public static void ReleaseTexImageEXT(nint dpy, nint drawable, int buffer)
	{
		Delegates.pglXReleaseTexImageEXT(dpy, drawable, buffer);
	}

	static Glx()
	{
		_GetAddressDelegate = Khronos.KhronosApi.GetProcAddressOS;
		Version_100 = new KhronosVersion(1, 0, "glx");
		Version_110 = new KhronosVersion(1, 1, "glx");
		Version_120 = new KhronosVersion(1, 2, "glx");
		Version_130 = new KhronosVersion(1, 3, "glx");
		Version_140 = new KhronosVersion(1, 4, "glx");
		BindAPI();
	}

	private static void BindAPI()
	{
		try
		{
			Khronos.KhronosApi.BindAPI<Glx>("libGL.so.1", _GetAddressDelegate, null);
		}
		catch (Exception)
		{
		}
	}

	[Conditional("GL_DEBUG")]
	private static void DebugCheckErrors(object returnValue)
	{
		nint key = Delegates.pglXGetCurrentDisplay();
		lock (DeviceContextGLX._DisplayErrorsLock)
		{
			if (DeviceContextGLX._DisplayErrors.TryGetValue(key, out var value))
			{
				throw value;
			}
		}
	}

	[Conditional("GL_DEBUG")]
	protected new static void LogCommand(string name, object returnValue, params object[] args)
	{
		if (_LogContext == null)
		{
			_LogContext = new KhronosLogContext(typeof(Glx));
		}
		Khronos.KhronosApi.RaiseLog(new KhronosLogEventArgs(_LogContext, name, args, returnValue));
	}

	public static nint XOpenDisplay(nint display)
	{
		return UnsafeNativeMethods.XOpenDisplay(display);
	}

	public static int XDefaultScreen(nint display)
	{
		return UnsafeNativeMethods.XDefaultScreen(display);
	}

	public static int XFree(nint data)
	{
		return UnsafeNativeMethods.XFree(data);
	}

	public static nint XCreateColormap(nint display, nint w, nint visual, int alloc)
	{
		return UnsafeNativeMethods.XCreateColormap(display, w, visual, alloc);
	}

	public static nint XCreateWindow(nint display, nint parent, int x, int y, int width, int height, int border_width, int depth, int xclass, nint visual, nuint valuemask, ref XSetWindowAttributes attributes)
	{
		return UnsafeNativeMethods.XCreateWindow(display, parent, x, y, width, height, border_width, depth, xclass, visual, valuemask, ref attributes);
	}

	public static nint XRootWindow(nint display, int screen_number)
	{
		return UnsafeNativeMethods.XRootWindow(display, screen_number);
	}

	[RequiredByFeature("GLX_VERSION_1_0")]
	public static XVisualInfo ChooseVisual(nint dpy, int screen, int[] attribList)
	{
		nint num = ChooseVisualCore(dpy, screen, attribList);
		if (num != IntPtr.Zero)
		{
			return (XVisualInfo)Marshal.PtrToStructure(num, typeof(XVisualInfo));
		}
		return new XVisualInfo();
	}

	[RequiredByFeature("GLX_VERSION_1_0")]
	public static nint CreateContext(nint dpy, XVisualInfo vis, nint shareList, bool direct)
	{
		using MemoryLock memoryLock = new MemoryLock(vis);
		return CreateContext(dpy, memoryLock.Address, shareList, direct);
	}

	[RequiredByFeature("GLX_VERSION_1_0")]
	public static nint CreateGLXPixmap(nint dpy, XVisualInfo visual, nint pixmap)
	{
		using MemoryLock memoryLock = new MemoryLock(visual);
		return CreateGLXPixmap(dpy, memoryLock.Address, pixmap);
	}

	[RequiredByFeature("GLX_VERSION_1_0")]
	public static int GetConfig(nint dpy, XVisualInfo visual, int attrib, [Out] int[] value)
	{
		using MemoryLock memoryLock = new MemoryLock(visual);
		return GetConfig(dpy, memoryLock.Address, attrib, value);
	}

	[RequiredByFeature("GLX_VERSION_1_3")]
	public static XVisualInfo GetVisualFromFBConfig(nint dpy, nint config)
	{
		nint visualFromFBConfigCore = GetVisualFromFBConfigCore(dpy, config);
		XVisualInfo result = new XVisualInfo();
		if (visualFromFBConfigCore != IntPtr.Zero)
		{
			result = (XVisualInfo)Marshal.PtrToStructure(visualFromFBConfigCore, typeof(XVisualInfo));
			XFree(visualFromFBConfigCore);
		}
		return result;
	}

	[RequiredByFeature("GLX_VERSION_1_0")]
	private unsafe static nint ChooseVisualCore(nint dpy, int screen, int[] attribList)
	{
		nint result;
		fixed (int* attribList2 = attribList)
		{
			result = Delegates.pglXChooseVisual(dpy, screen, attribList2);
		}
		return result;
	}

	[RequiredByFeature("GLX_VERSION_1_0")]
	private static nint CreateContext(nint dpy, nint vis, nint shareList, bool direct)
	{
		return Delegates.pglXCreateContext(dpy, vis, shareList, direct);
	}

	[RequiredByFeature("GLX_VERSION_1_0")]
	public static void DestroyContext(nint dpy, nint ctx)
	{
		Delegates.pglXDestroyContext(dpy, ctx);
	}

	[RequiredByFeature("GLX_VERSION_1_0")]
	public static bool MakeCurrent(nint dpy, nint drawable, nint ctx)
	{
		return Delegates.pglXMakeCurrent(dpy, drawable, ctx);
	}

	[RequiredByFeature("GLX_VERSION_1_0")]
	public static void CopyContext(nint dpy, nint src, nint dst, uint mask)
	{
		Delegates.pglXCopyContext(dpy, src, dst, mask);
	}

	[RequiredByFeature("GLX_VERSION_1_0")]
	public static void SwapBuffers(nint dpy, nint drawable)
	{
		Delegates.pglXSwapBuffers(dpy, drawable);
	}

	[RequiredByFeature("GLX_VERSION_1_0")]
	private static nint CreateGLXPixmap(nint dpy, nint visual, nint pixmap)
	{
		return Delegates.pglXCreateGLXPixmap(dpy, visual, pixmap);
	}

	[RequiredByFeature("GLX_VERSION_1_0")]
	public static void DestroyGLXPixmap(nint dpy, nint pixmap)
	{
		Delegates.pglXDestroyGLXPixmap(dpy, pixmap);
	}

	[RequiredByFeature("GLX_VERSION_1_0")]
	public unsafe static bool Query(nint dpy, int[] errorb, int[] @event)
	{
		bool result;
		fixed (int* errorb2 = errorb)
		{
			fixed (int* event2 = @event)
			{
				result = Delegates.pglXQueryExtension(dpy, errorb2, event2);
			}
		}
		return result;
	}

	[RequiredByFeature("GLX_VERSION_1_0")]
	public unsafe static bool QueryVersion(nint dpy, int[] maj, int[] min)
	{
		bool result;
		fixed (int* maj2 = maj)
		{
			fixed (int* min2 = min)
			{
				result = Delegates.pglXQueryVersion(dpy, maj2, min2);
			}
		}
		return result;
	}

	[RequiredByFeature("GLX_VERSION_1_0")]
	public static bool IsDirect(nint dpy, nint ctx)
	{
		return Delegates.pglXIsDirect(dpy, ctx);
	}

	[RequiredByFeature("GLX_VERSION_1_0")]
	private unsafe static int GetConfig(nint dpy, nint visual, int attrib, [Out] int[] value)
	{
		int result;
		fixed (int* value2 = value)
		{
			result = Delegates.pglXGetConfig(dpy, visual, attrib, value2);
		}
		return result;
	}

	[RequiredByFeature("GLX_VERSION_1_0")]
	public static nint GetCurrentContext()
	{
		return Delegates.pglXGetCurrentContext();
	}

	[RequiredByFeature("GLX_VERSION_1_0")]
	public static nint GetCurrentDrawable()
	{
		return Delegates.pglXGetCurrentDrawable();
	}

	[RequiredByFeature("GLX_VERSION_1_0")]
	public static void WaitGL()
	{
		Delegates.pglXWaitGL();
	}

	[RequiredByFeature("GLX_VERSION_1_0")]
	public static void WaitX()
	{
		Delegates.pglXWaitX();
	}

	[RequiredByFeature("GLX_VERSION_1_0")]
	public static void UseXFont(int font, int first, int count, int list)
	{
		Delegates.pglXUseXFont(font, first, count, list);
	}

	[RequiredByFeature("GLX_VERSION_1_1")]
	public static string QueryExtensionsString(nint dpy, int screen)
	{
		return Khronos.KhronosApi.PtrToString(Delegates.pglXQueryExtensionsString(dpy, screen));
	}

	[RequiredByFeature("GLX_VERSION_1_1")]
	public static string QueryServerString(nint dpy, int screen, int name)
	{
		return Khronos.KhronosApi.PtrToString(Delegates.pglXQueryServerString(dpy, screen, name));
	}

	[RequiredByFeature("GLX_VERSION_1_1")]
	public static string GetClientString(nint dpy, int name)
	{
		return Khronos.KhronosApi.PtrToString(Delegates.pglXGetClientString(dpy, name));
	}

	[RequiredByFeature("GLX_VERSION_1_2")]
	public static nint GetCurrentDisplay()
	{
		return Delegates.pglXGetCurrentDisplay();
	}

	[RequiredByFeature("GLX_VERSION_1_3")]
	public unsafe static nint* GetFBConfigs(nint dpy, int screen, [Out] int[] nelements)
	{
		nint* result;
		fixed (int* nelements2 = nelements)
		{
			result = Delegates.pglXGetFBConfigs(dpy, screen, nelements2);
		}
		return result;
	}

	[RequiredByFeature("GLX_VERSION_1_3")]
	public unsafe static nint* GetFBConfigs(nint dpy, int screen, out int nelements)
	{
		nint* result;
		fixed (int* nelements2 = &nelements)
		{
			result = Delegates.pglXGetFBConfigs(dpy, screen, nelements2);
		}
		return result;
	}

	[RequiredByFeature("GLX_VERSION_1_3")]
	public unsafe static nint* ChooseFBConfig(nint dpy, int screen, int[] attrib_list, int[] nelements)
	{
		nint* result;
		fixed (int* attrib_list2 = attrib_list)
		{
			fixed (int* nelements2 = nelements)
			{
				result = Delegates.pglXChooseFBConfig(dpy, screen, attrib_list2, nelements2);
			}
		}
		return result;
	}

	[RequiredByFeature("GLX_VERSION_1_3")]
	public unsafe static int GetFBConfigAttrib(nint dpy, nint config, int attribute, [Out] int[] value)
	{
		int result;
		fixed (int* value2 = value)
		{
			result = Delegates.pglXGetFBConfigAttrib(dpy, config, attribute, value2);
		}
		return result;
	}

	[RequiredByFeature("GLX_VERSION_1_3")]
	public unsafe static int GetFBConfigAttrib(nint dpy, nint config, int attribute, out int value)
	{
		int result;
		fixed (int* value2 = &value)
		{
			result = Delegates.pglXGetFBConfigAttrib(dpy, config, attribute, value2);
		}
		return result;
	}

	[RequiredByFeature("GLX_VERSION_1_3")]
	private static nint GetVisualFromFBConfigCore(nint dpy, nint config)
	{
		return Delegates.pglXGetVisualFromFBConfig(dpy, config);
	}

	[RequiredByFeature("GLX_VERSION_1_3")]
	public unsafe static nint CreateWindow(nint dpy, nint config, nint win, int[] attrib_list)
	{
		nint result;
		fixed (int* attrib_list2 = attrib_list)
		{
			result = Delegates.pglXCreateWindow(dpy, config, win, attrib_list2);
		}
		return result;
	}

	[RequiredByFeature("GLX_VERSION_1_3")]
	public static void DestroyWindow(nint dpy, nint win)
	{
		Delegates.pglXDestroyWindow(dpy, win);
	}

	[RequiredByFeature("GLX_VERSION_1_3")]
	public unsafe static nint CreatePixmap(nint dpy, nint config, nint pixmap, int[] attrib_list)
	{
		nint result;
		fixed (int* attrib_list2 = attrib_list)
		{
			result = Delegates.pglXCreatePixmap(dpy, config, pixmap, attrib_list2);
		}
		return result;
	}

	[RequiredByFeature("GLX_VERSION_1_3")]
	public static void DestroyPixmap(nint dpy, nint pixmap)
	{
		Delegates.pglXDestroyPixmap(dpy, pixmap);
	}

	[RequiredByFeature("GLX_VERSION_1_3")]
	public unsafe static nint CreatePbuffer(nint dpy, nint config, int[] attrib_list)
	{
		nint result;
		fixed (int* attrib_list2 = attrib_list)
		{
			result = Delegates.pglXCreatePbuffer(dpy, config, attrib_list2);
		}
		return result;
	}

	[RequiredByFeature("GLX_VERSION_1_3")]
	public static void DestroyPbuffer(nint dpy, nint pbuf)
	{
		Delegates.pglXDestroyPbuffer(dpy, pbuf);
	}

	[RequiredByFeature("GLX_VERSION_1_3")]
	public unsafe static void QueryDrawable(nint dpy, nint draw, int attribute, uint[] value)
	{
		fixed (uint* value2 = value)
		{
			Delegates.pglXQueryDrawable(dpy, draw, attribute, value2);
		}
	}

	[RequiredByFeature("GLX_VERSION_1_3")]
	public static nint CreateNewContext(nint dpy, nint config, int render_type, nint share_list, bool direct)
	{
		return Delegates.pglXCreateNewContext(dpy, config, render_type, share_list, direct);
	}

	[RequiredByFeature("GLX_VERSION_1_3")]
	public static bool MakeContextCurrent(nint dpy, nint draw, nint read, nint ctx)
	{
		return Delegates.pglXMakeContextCurrent(dpy, draw, read, ctx);
	}

	[RequiredByFeature("GLX_VERSION_1_3")]
	public static nint GetCurrentReadDrawable()
	{
		return Delegates.pglXGetCurrentReadDrawable();
	}

	[RequiredByFeature("GLX_VERSION_1_3")]
	public unsafe static int QueryContext(nint dpy, nint ctx, int attribute, int[] value)
	{
		int result;
		fixed (int* value2 = value)
		{
			result = Delegates.pglXQueryContext(dpy, ctx, attribute, value2);
		}
		return result;
	}

	[RequiredByFeature("GLX_VERSION_1_3")]
	public static void SelectEvent(nint dpy, nint draw, uint event_mask)
	{
		Delegates.pglXSelectEvent(dpy, draw, event_mask);
	}

	[RequiredByFeature("GLX_VERSION_1_3")]
	public unsafe static void GetSelectedEvent(nint dpy, nint draw, [Out] uint[] event_mask)
	{
		fixed (uint* event_mask2 = event_mask)
		{
			Delegates.pglXGetSelectedEvent(dpy, draw, event_mask2);
		}
	}

	[RequiredByFeature("GLX_VERSION_1_4")]
	public unsafe static nint GetProcAddress(byte[] procName)
	{
		nint result;
		fixed (byte* procName2 = procName)
		{
			result = Delegates.pglXGetProcAddress(procName2);
		}
		return result;
	}

	[RequiredByFeature("GLX_MESA_agp_offset")]
	public static uint GetAGPOffsetMESA(nint pointer)
	{
		return Delegates.pglXGetAGPOffsetMESA(pointer);
	}

	[RequiredByFeature("GLX_MESA_copy_sub_buffer")]
	public static void CopySubBufferMESA(nint dpy, nint drawable, int x, int y, int width, int height)
	{
		Delegates.pglXCopySubBufferMESA(dpy, drawable, x, y, width, height);
	}

	[RequiredByFeature("GLX_MESA_pixmap_colormap")]
	private static nint CreateGLXPixmapMESA(nint dpy, nint visual, nint pixmap, nint cmap)
	{
		return Delegates.pglXCreateGLXPixmapMESA(dpy, visual, pixmap, cmap);
	}

	[RequiredByFeature("GLX_MESA_query_renderer")]
	public unsafe static bool QueryCurrentRenderMESA(int attribute, uint[] value)
	{
		bool result;
		fixed (uint* value2 = value)
		{
			result = Delegates.pglXQueryCurrentRendererIntegerMESA(attribute, value2);
		}
		return result;
	}

	[RequiredByFeature("GLX_MESA_query_renderer")]
	public static string QueryCurrentRendererStringMESA(int attribute)
	{
		return Khronos.KhronosApi.PtrToString(Delegates.pglXQueryCurrentRendererStringMESA(attribute));
	}

	[RequiredByFeature("GLX_MESA_query_renderer")]
	public unsafe static bool QueryRenderMESA(nint dpy, int screen, int renderer, int attribute, uint[] value)
	{
		bool result;
		fixed (uint* value2 = value)
		{
			result = Delegates.pglXQueryRendererIntegerMESA(dpy, screen, renderer, attribute, value2);
		}
		return result;
	}

	[RequiredByFeature("GLX_MESA_query_renderer")]
	public static string QueryRendererStringMESA(nint dpy, int screen, int renderer, int attribute)
	{
		return Khronos.KhronosApi.PtrToString(Delegates.pglXQueryRendererStringMESA(dpy, screen, renderer, attribute));
	}

	[RequiredByFeature("GLX_MESA_release_buffers")]
	public static bool ReleaseBuffersMESA(nint dpy, nint drawable)
	{
		return Delegates.pglXReleaseBuffersMESA(dpy, drawable);
	}

	[RequiredByFeature("GLX_MESA_set_3dfx_mode")]
	public static bool Set3DfxModeMESA(int mode)
	{
		return Delegates.pglXSet3DfxModeMESA(mode);
	}

	[RequiredByFeature("GLX_MESA_swap_control")]
	public static int GetSwapIntervalMESA()
	{
		return Delegates.pglXGetSwapIntervalMESA();
	}

	[RequiredByFeature("GLX_MESA_swap_control")]
	public static int SwapIntervalMESA(uint interval)
	{
		return Delegates.pglXSwapIntervalMESA(interval);
	}

	[RequiredByFeature("GLX_NV_copy_buffer")]
	public static void CopyBufferSubDataNV(nint dpy, nint readCtx, nint writeCtx, int readTarget, int writeTarget, nint readOffset, nint writeOffset, uint size)
	{
		Delegates.pglXCopyBufferSubDataNV(dpy, readCtx, writeCtx, readTarget, writeTarget, readOffset, writeOffset, size);
	}

	[RequiredByFeature("GLX_NV_copy_buffer")]
	public static void NamedCopyBufferSubDataNV(nint dpy, nint readCtx, nint writeCtx, uint readBuffer, uint writeBuffer, nint readOffset, nint writeOffset, uint size)
	{
		Delegates.pglXNamedCopyBufferSubDataNV(dpy, readCtx, writeCtx, readBuffer, writeBuffer, readOffset, writeOffset, size);
	}

	[RequiredByFeature("GLX_NV_copy_image")]
	public static void CopyImageSubDataNV(nint dpy, nint srcCtx, uint srcName, int srcTarget, int srcLevel, int srcX, int srcY, int srcZ, nint dstCtx, uint dstName, int dstTarget, int dstLevel, int dstX, int dstY, int dstZ, int width, int height, int depth)
	{
		Delegates.pglXCopyImageSubDataNV(dpy, srcCtx, srcName, srcTarget, srcLevel, srcX, srcY, srcZ, dstCtx, dstName, dstTarget, dstLevel, dstX, dstY, dstZ, width, height, depth);
	}

	[RequiredByFeature("GLX_NV_delay_before_swap")]
	public static bool DelayBeforeSwapNV(nint dpy, nint drawable, float seconds)
	{
		return Delegates.pglXDelayBeforeSwapNV(dpy, drawable, seconds);
	}

	[RequiredByFeature("GLX_NV_present_video")]
	public unsafe static uint* EnumerateVideoDevicesNV(nint dpy, int screen, int[] nelements)
	{
		uint* result;
		fixed (int* nelements2 = nelements)
		{
			result = Delegates.pglXEnumerateVideoDevicesNV(dpy, screen, nelements2);
		}
		return result;
	}

	[RequiredByFeature("GLX_NV_present_video")]
	public unsafe static int BindVideoDeviceNV(nint dpy, uint video_slot, uint video_device, int[] attrib_list)
	{
		int result;
		fixed (int* attrib_list2 = attrib_list)
		{
			result = Delegates.pglXBindVideoDeviceNV(dpy, video_slot, video_device, attrib_list2);
		}
		return result;
	}

	[RequiredByFeature("GLX_NV_swap_group")]
	public static bool JoinSwapGroupNV(nint dpy, nint drawable, uint group)
	{
		return Delegates.pglXJoinSwapGroupNV(dpy, drawable, group);
	}

	[RequiredByFeature("GLX_NV_swap_group")]
	public static bool BindSwapBarrierNV(nint dpy, uint group, uint barrier)
	{
		return Delegates.pglXBindSwapBarrierNV(dpy, group, barrier);
	}

	[RequiredByFeature("GLX_NV_swap_group")]
	public unsafe static bool QuerySwapGroupNV(nint dpy, nint drawable, uint[] group, uint[] barrier)
	{
		bool result;
		fixed (uint* group2 = group)
		{
			fixed (uint* barrier2 = barrier)
			{
				result = Delegates.pglXQuerySwapGroupNV(dpy, drawable, group2, barrier2);
			}
		}
		return result;
	}

	[RequiredByFeature("GLX_NV_swap_group")]
	public unsafe static bool QueryMaxSwapGroupsNV(nint dpy, int screen, uint[] maxGroups, uint[] maxBarriers)
	{
		bool result;
		fixed (uint* maxGroups2 = maxGroups)
		{
			fixed (uint* maxBarriers2 = maxBarriers)
			{
				result = Delegates.pglXQueryMaxSwapGroupsNV(dpy, screen, maxGroups2, maxBarriers2);
			}
		}
		return result;
	}

	[RequiredByFeature("GLX_NV_swap_group")]
	public unsafe static bool QueryFrameCountNV(nint dpy, int screen, uint[] count)
	{
		bool result;
		fixed (uint* count2 = count)
		{
			result = Delegates.pglXQueryFrameCountNV(dpy, screen, count2);
		}
		return result;
	}

	[RequiredByFeature("GLX_NV_swap_group")]
	public static bool ResetFrameCountNV(nint dpy, int screen)
	{
		return Delegates.pglXResetFrameCountNV(dpy, screen);
	}

	[RequiredByFeature("GLX_NV_video_capture")]
	public static int BindVideoCaptureDeviceNV(nint dpy, uint video_capture_slot, nint device)
	{
		return Delegates.pglXBindVideoCaptureDeviceNV(dpy, video_capture_slot, device);
	}

	[RequiredByFeature("GLX_NV_video_capture")]
	public unsafe static nint EnumerateVideoCaptureDevicesNV(nint dpy, int screen, int[] nelements)
	{
		nint result;
		fixed (int* nelements2 = nelements)
		{
			result = Delegates.pglXEnumerateVideoCaptureDevicesNV(dpy, screen, nelements2);
		}
		return result;
	}

	[RequiredByFeature("GLX_NV_video_capture")]
	public static void LockVideoCaptureDeviceNV(nint dpy, nint device)
	{
		Delegates.pglXLockVideoCaptureDeviceNV(dpy, device);
	}

	[RequiredByFeature("GLX_NV_video_capture")]
	public unsafe static int QueryVideoCaptureDeviceNV(nint dpy, nint device, int attribute, int[] value)
	{
		int result;
		fixed (int* value2 = value)
		{
			result = Delegates.pglXQueryVideoCaptureDeviceNV(dpy, device, attribute, value2);
		}
		return result;
	}

	[RequiredByFeature("GLX_NV_video_capture")]
	public static void ReleaseVideoCaptureDeviceNV(nint dpy, nint device)
	{
		Delegates.pglXReleaseVideoCaptureDeviceNV(dpy, device);
	}

	[RequiredByFeature("GLX_NV_video_out")]
	public static int GetVideoDeviceNV(nint dpy, int screen, int numVideoDevices, nint pVideoDevice)
	{
		return Delegates.pglXGetVideoDeviceNV(dpy, screen, numVideoDevices, pVideoDevice);
	}

	[RequiredByFeature("GLX_NV_video_out")]
	public static int ReleaseVideoDeviceNV(nint dpy, int screen, nint VideoDevice)
	{
		return Delegates.pglXReleaseVideoDeviceNV(dpy, screen, VideoDevice);
	}

	[RequiredByFeature("GLX_NV_video_out")]
	public static int BindVideoImageNV(nint dpy, nint VideoDevice, nint pbuf, int iVideoBuffer)
	{
		return Delegates.pglXBindVideoImageNV(dpy, VideoDevice, pbuf, iVideoBuffer);
	}

	[RequiredByFeature("GLX_NV_video_out")]
	public static int ReleaseVideoImageNV(nint dpy, nint pbuf)
	{
		return Delegates.pglXReleaseVideoImageNV(dpy, pbuf);
	}

	[RequiredByFeature("GLX_NV_video_out")]
	public unsafe static int SendPbufferToVideoNV(nint dpy, nint pbuf, int iBufferType, uint[] pulCounterPbuffer, bool bBlock)
	{
		int result;
		fixed (uint* pulCounterPbuffer2 = pulCounterPbuffer)
		{
			result = Delegates.pglXSendPbufferToVideoNV(dpy, pbuf, iBufferType, pulCounterPbuffer2, bBlock);
		}
		return result;
	}

	[RequiredByFeature("GLX_NV_video_out")]
	public unsafe static int GetVideoInfoNV(nint dpy, int screen, nint VideoDevice, [Out] uint[] pulCounterOutputPbuffer, [Out] uint[] pulCounterOutputVideo)
	{
		int result;
		fixed (uint* pulCounterOutputPbuffer2 = pulCounterOutputPbuffer)
		{
			fixed (uint* pulCounterOutputVideo2 = pulCounterOutputVideo)
			{
				result = Delegates.pglXGetVideoInfoNV(dpy, screen, VideoDevice, pulCounterOutputPbuffer2, pulCounterOutputVideo2);
			}
		}
		return result;
	}

	[RequiredByFeature("GLX_OML_sync_control")]
	public unsafe static bool GetSyncValuesOML(nint dpy, nint drawable, [Out] long[] ust, [Out] long[] msc, [Out] long[] sbc)
	{
		bool result;
		fixed (long* ust2 = ust)
		{
			fixed (long* msc2 = msc)
			{
				fixed (long* sbc2 = sbc)
				{
					result = Delegates.pglXGetSyncValuesOML(dpy, drawable, ust2, msc2, sbc2);
				}
			}
		}
		return result;
	}

	[RequiredByFeature("GLX_OML_sync_control")]
	public unsafe static bool GetMscRateOML(nint dpy, nint drawable, [Out] int[] numerator, [Out] int[] denominator)
	{
		bool result;
		fixed (int* numerator2 = numerator)
		{
			fixed (int* denominator2 = denominator)
			{
				result = Delegates.pglXGetMscRateOML(dpy, drawable, numerator2, denominator2);
			}
		}
		return result;
	}

	[RequiredByFeature("GLX_OML_sync_control")]
	public static long SwapBuffersMscOML(nint dpy, nint drawable, long target_msc, long divisor, long remainder)
	{
		return Delegates.pglXSwapBuffersMscOML(dpy, drawable, target_msc, divisor, remainder);
	}

	[RequiredByFeature("GLX_OML_sync_control")]
	public unsafe static bool WaitForMscOML(nint dpy, nint drawable, long target_msc, long divisor, long remainder, long[] ust, long[] msc, long[] sbc)
	{
		bool result;
		fixed (long* ust2 = ust)
		{
			fixed (long* msc2 = msc)
			{
				fixed (long* sbc2 = sbc)
				{
					result = Delegates.pglXWaitForMscOML(dpy, drawable, target_msc, divisor, remainder, ust2, msc2, sbc2);
				}
			}
		}
		return result;
	}

	[RequiredByFeature("GLX_OML_sync_control")]
	public unsafe static bool WaitForSbcOML(nint dpy, nint drawable, long target_sbc, long[] ust, long[] msc, long[] sbc)
	{
		bool result;
		fixed (long* ust2 = ust)
		{
			fixed (long* msc2 = msc)
			{
				fixed (long* sbc2 = sbc)
				{
					result = Delegates.pglXWaitForSbcOML(dpy, drawable, target_sbc, ust2, msc2, sbc2);
				}
			}
		}
		return result;
	}

	[RequiredByFeature("GLX_SGIX_dmbuffer")]
	public unsafe static bool AssociateDMPbufferSGIX(nint dpy, nint pbuffer, nint[] @params, nint dmbuffer)
	{
		bool result;
		fixed (nint* params2 = @params)
		{
			result = Delegates.pglXAssociateDMPbufferSGIX(dpy, pbuffer, params2, dmbuffer);
		}
		return result;
	}

	[RequiredByFeature("GLX_SGIX_fbconfig")]
	public unsafe static int GetFBConfigAttribSGIX(nint dpy, nint config, int attribute, [Out] int[] value)
	{
		int result;
		fixed (int* value2 = value)
		{
			result = Delegates.pglXGetFBConfigAttribSGIX(dpy, config, attribute, value2);
		}
		return result;
	}

	[RequiredByFeature("GLX_SGIX_fbconfig")]
	public unsafe static nint* ChooseFBConfigSGIX(nint dpy, int screen, int[] attrib_list, int[] nelements)
	{
		nint* result;
		fixed (int* attrib_list2 = attrib_list)
		{
			fixed (int* nelements2 = nelements)
			{
				result = Delegates.pglXChooseFBConfigSGIX(dpy, screen, attrib_list2, nelements2);
			}
		}
		return result;
	}

	[RequiredByFeature("GLX_SGIX_fbconfig")]
	public static nint CreateGLXPixmapWithConfigSGIX(nint dpy, nint config, nint pixmap)
	{
		return Delegates.pglXCreateGLXPixmapWithConfigSGIX(dpy, config, pixmap);
	}

	[RequiredByFeature("GLX_SGIX_fbconfig")]
	public static nint CreateContextWithConfigSGIX(nint dpy, nint config, int render_type, nint share_list, bool direct)
	{
		return Delegates.pglXCreateContextWithConfigSGIX(dpy, config, render_type, share_list, direct);
	}

	[RequiredByFeature("GLX_SGIX_fbconfig")]
	private static nint GetVisualFromFBConfigSGIXCore(nint dpy, nint config)
	{
		return Delegates.pglXGetVisualFromFBConfigSGIX(dpy, config);
	}

	[RequiredByFeature("GLX_SGIX_fbconfig")]
	private static nint GetFBConfigFromVisualSGIXCore(nint dpy, nint vis)
	{
		return Delegates.pglXGetFBConfigFromVisualSGIX(dpy, vis);
	}

	[RequiredByFeature("GLX_SGIX_hyperpipe")]
	public unsafe static nint* QueryHyperpipeNetworkSGIX(nint dpy, int[] npipes)
	{
		nint* result;
		fixed (int* npipes2 = npipes)
		{
			result = Delegates.pglXQueryHyperpipeNetworkSGIX(dpy, npipes2);
		}
		return result;
	}

	[RequiredByFeature("GLX_SGIX_hyperpipe")]
	public unsafe static int HyperpipeConfigSGIX(nint dpy, int networkId, int npipes, nint cfg, int[] hpId)
	{
		int result;
		fixed (int* hpId2 = hpId)
		{
			result = Delegates.pglXHyperpipeConfigSGIX(dpy, networkId, npipes, cfg, hpId2);
		}
		return result;
	}

	[RequiredByFeature("GLX_SGIX_hyperpipe")]
	public unsafe static nint QueryHyperpipeConfigSGIX(nint dpy, int hpId, int[] npipes)
	{
		nint result;
		fixed (int* npipes2 = npipes)
		{
			result = Delegates.pglXQueryHyperpipeConfigSGIX(dpy, hpId, npipes2);
		}
		return result;
	}

	[RequiredByFeature("GLX_SGIX_hyperpipe")]
	public static int DestroyHyperpipeConfigSGIX(nint dpy, int hpId)
	{
		return Delegates.pglXDestroyHyperpipeConfigSGIX(dpy, hpId);
	}

	[RequiredByFeature("GLX_SGIX_hyperpipe")]
	public static int BindHyperpipeSGIX(nint dpy, int hpId)
	{
		return Delegates.pglXBindHyperpipeSGIX(dpy, hpId);
	}

	[RequiredByFeature("GLX_SGIX_hyperpipe")]
	public static int QueryHyperpipeBestAttribSGIX(nint dpy, int timeSlice, int attrib, int size, nint attribList, nint returnAttribList)
	{
		return Delegates.pglXQueryHyperpipeBestAttribSGIX(dpy, timeSlice, attrib, size, attribList, returnAttribList);
	}

	[RequiredByFeature("GLX_SGIX_hyperpipe")]
	public static int HyperpipeAttribSGIX(nint dpy, int timeSlice, int attrib, int size, nint attribList)
	{
		return Delegates.pglXHyperpipeAttribSGIX(dpy, timeSlice, attrib, size, attribList);
	}

	[RequiredByFeature("GLX_SGIX_hyperpipe")]
	public static int QueryHyperpipeAttribSGIX(nint dpy, int timeSlice, int attrib, int size, nint returnAttribList)
	{
		return Delegates.pglXQueryHyperpipeAttribSGIX(dpy, timeSlice, attrib, size, returnAttribList);
	}

	[RequiredByFeature("GLX_SGIX_pbuffer")]
	public unsafe static nint CreateGLXPbufferSGIX(nint dpy, nint config, uint width, uint height, int[] attrib_list)
	{
		nint result;
		fixed (int* attrib_list2 = attrib_list)
		{
			result = Delegates.pglXCreateGLXPbufferSGIX(dpy, config, width, height, attrib_list2);
		}
		return result;
	}

	[RequiredByFeature("GLX_SGIX_pbuffer")]
	public static void DestroyGLXPbufferSGIX(nint dpy, nint pbuf)
	{
		Delegates.pglXDestroyGLXPbufferSGIX(dpy, pbuf);
	}

	[RequiredByFeature("GLX_SGIX_pbuffer")]
	public unsafe static int QueryGLXPbufferSGIX(nint dpy, nint pbuf, int attribute, uint[] value)
	{
		int result;
		fixed (uint* value2 = value)
		{
			result = Delegates.pglXQueryGLXPbufferSGIX(dpy, pbuf, attribute, value2);
		}
		return result;
	}

	[RequiredByFeature("GLX_SGIX_pbuffer")]
	public static void SelectEventSGIX(nint dpy, nint drawable, uint mask)
	{
		Delegates.pglXSelectEventSGIX(dpy, drawable, mask);
	}

	[RequiredByFeature("GLX_SGIX_pbuffer")]
	public unsafe static void GetSelectedEventSGIX(nint dpy, nint drawable, [Out] uint[] mask)
	{
		fixed (uint* mask2 = mask)
		{
			Delegates.pglXGetSelectedEventSGIX(dpy, drawable, mask2);
		}
	}

	[RequiredByFeature("GLX_SGIX_swap_barrier")]
	public static void BindSwapBarrierSGIX(nint dpy, nint drawable, int barrier)
	{
		Delegates.pglXBindSwapBarrierSGIX(dpy, drawable, barrier);
	}

	[RequiredByFeature("GLX_SGIX_swap_barrier")]
	public unsafe static bool QueryMaxSwapBarriersSGIX(nint dpy, int screen, int[] max)
	{
		bool result;
		fixed (int* max2 = max)
		{
			result = Delegates.pglXQueryMaxSwapBarriersSGIX(dpy, screen, max2);
		}
		return result;
	}

	[RequiredByFeature("GLX_SGIX_swap_group")]
	public static void JoinSwapGroupSGIX(nint dpy, nint drawable, nint member)
	{
		Delegates.pglXJoinSwapGroupSGIX(dpy, drawable, member);
	}

	[RequiredByFeature("GLX_SGIX_video_resize")]
	public static int BindChannelToWindowSGIX(nint display, int screen, int channel, nint window)
	{
		return Delegates.pglXBindChannelToWindowSGIX(display, screen, channel, window);
	}

	[RequiredByFeature("GLX_SGIX_video_resize")]
	public static int ChannelRectSGIX(nint display, int screen, int channel, int x, int y, int w, int h)
	{
		return Delegates.pglXChannelRectSGIX(display, screen, channel, x, y, w, h);
	}

	[RequiredByFeature("GLX_SGIX_video_resize")]
	public unsafe static int QueryChannelRectSGIX(nint display, int screen, int channel, int[] dx, int[] dy, int[] dw, int[] dh)
	{
		int result;
		fixed (int* dx2 = dx)
		{
			fixed (int* dy2 = dy)
			{
				fixed (int* dw2 = dw)
				{
					fixed (int* dh2 = dh)
					{
						result = Delegates.pglXQueryChannelRectSGIX(display, screen, channel, dx2, dy2, dw2, dh2);
					}
				}
			}
		}
		return result;
	}

	[RequiredByFeature("GLX_SGIX_video_resize")]
	public unsafe static int QueryChannelDeltasSGIX(nint display, int screen, int channel, int[] x, int[] y, int[] w, int[] h)
	{
		int result;
		fixed (int* x2 = x)
		{
			fixed (int* y2 = y)
			{
				fixed (int* w2 = w)
				{
					fixed (int* h2 = h)
					{
						result = Delegates.pglXQueryChannelDeltasSGIX(display, screen, channel, x2, y2, w2, h2);
					}
				}
			}
		}
		return result;
	}

	[RequiredByFeature("GLX_SGIX_video_resize")]
	public static int ChannelRectSyncSGIX(nint display, int screen, int channel, int synctype)
	{
		return Delegates.pglXChannelRectSyncSGIX(display, screen, channel, synctype);
	}

	[RequiredByFeature("GLX_SGIX_video_source")]
	public static nint CreateGLXVideoSourceSGIX(nint display, int screen, nint server, nint path, int nodeClass, nint drainNode)
	{
		return Delegates.pglXCreateGLXVideoSourceSGIX(display, screen, server, path, nodeClass, drainNode);
	}

	[RequiredByFeature("GLX_SGIX_video_source")]
	public static void DestroyGLXVideoSourceSGIX(nint dpy, nint glxvideosource)
	{
		Delegates.pglXDestroyGLXVideoSourceSGIX(dpy, glxvideosource);
	}

	[RequiredByFeature("GLX_SGI_cushion")]
	public static void CushionSGI(nint dpy, nint window, float cushion)
	{
		Delegates.pglXCushionSGI(dpy, window, cushion);
	}

	[RequiredByFeature("GLX_SGI_make_current_read")]
	public static bool MakeCurrentReadSGI(nint dpy, nint draw, nint read, nint ctx)
	{
		return Delegates.pglXMakeCurrentReadSGI(dpy, draw, read, ctx);
	}

	[RequiredByFeature("GLX_SGI_make_current_read")]
	public static nint GetCurrentReadDrawableSGI()
	{
		return Delegates.pglXGetCurrentReadDrawableSGI();
	}

	[RequiredByFeature("GLX_SGI_swap_control")]
	public static int SwapIntervalSGI(int interval)
	{
		return Delegates.pglXSwapIntervalSGI(interval);
	}

	[RequiredByFeature("GLX_SGI_video_sync")]
	public unsafe static int GetVideoSyncSGI([Out] uint[] count)
	{
		int result;
		fixed (uint* count2 = count)
		{
			result = Delegates.pglXGetVideoSyncSGI(count2);
		}
		return result;
	}

	[RequiredByFeature("GLX_SGI_video_sync")]
	public unsafe static int WaitVideoSyncSGI(int divisor, int remainder, uint[] count)
	{
		int result;
		fixed (uint* count2 = count)
		{
			result = Delegates.pglXWaitVideoSyncSGI(divisor, remainder, count2);
		}
		return result;
	}

	[RequiredByFeature("GLX_SUN_get_transparent_index")]
	public unsafe static int GetTransparentIndexSUN(nint dpy, nint overlay, nint underlay, [Out] long[] pTransparentIndex)
	{
		int result;
		fixed (long* pTransparentIndex2 = pTransparentIndex)
		{
			result = Delegates.pglXGetTransparentIndexSUN(dpy, overlay, underlay, pTransparentIndex2);
		}
		return result;
	}
}
