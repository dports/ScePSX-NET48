using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Text.RegularExpressions;
using Khronos;

namespace OpenGL;

public class Egl : KhronosApi
{
	internal static class Delegates
	{
		[RequiredByFeature("EGL_ANDROID_blob_cache")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate void eglSetBlobCacheFuncsANDROID(nint dpy, SetBlobFuncDelegate set, GetBlobFuncDelegate get);

		[RequiredByFeature("EGL_ANDROID_create_native_client_buffer")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint eglCreateNativeClientBufferANDROID(int* attrib_list);

		[RequiredByFeature("EGL_ANDROID_native_fence_sync")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate int eglDupNativeFenceFDANDROID(nint dpy, nint sync);

		[RequiredByFeature("EGL_ANDROID_presentation_time")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool eglPresentationTimeANDROID(nint dpy, nint surface, long time);

		[RequiredByFeature("EGL_ANGLE_query_surface_pointer")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglQuerySurfacePointerANGLE(nint dpy, nint surface, int attribute, nint* value);

		[RequiredByFeature("EGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglChooseConfig(nint dpy, int* attrib_list, nint* configs, int config_size, int* num_config);

		[RequiredByFeature("EGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool eglCopyBuffers(nint dpy, nint surface, nint target);

		[RequiredByFeature("EGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint eglCreateContext(nint dpy, nint config, nint share_context, int* attrib_list);

		[RequiredByFeature("EGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint eglCreatePbufferSurface(nint dpy, nint config, int* attrib_list);

		[RequiredByFeature("EGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint eglCreatePixmapSurface(nint dpy, nint config, nint pixmap, int* attrib_list);

		[RequiredByFeature("EGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint eglCreateWindowSurface(nint dpy, nint config, nint win, int* attrib_list);

		[RequiredByFeature("EGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool eglDestroyContext(nint dpy, nint ctx);

		[RequiredByFeature("EGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool eglDestroySurface(nint dpy, nint surface);

		[RequiredByFeature("EGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglGetConfigAttrib(nint dpy, nint config, int attribute, int* value);

		[RequiredByFeature("EGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglGetConfigs(nint dpy, nint* configs, int config_size, int* num_config);

		[RequiredByFeature("EGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint eglGetCurrentDisplay();

		[RequiredByFeature("EGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint eglGetCurrentSurface(int readdraw);

		[RequiredByFeature("EGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint eglGetDisplay(nint display_id);

		[RequiredByFeature("EGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate int eglGetError();

		[RequiredByFeature("EGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint eglGetProcAddress(string procname);

		[RequiredByFeature("EGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglInitialize(nint dpy, int* major, int* minor);

		[RequiredByFeature("EGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool eglMakeCurrent(nint dpy, nint draw, nint read, nint ctx);

		[RequiredByFeature("EGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglQueryContext(nint dpy, nint ctx, int attribute, int* value);

		[RequiredByFeature("EGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint eglQueryString(nint dpy, int name);

		[RequiredByFeature("EGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglQuerySurface(nint dpy, nint surface, int attribute, int* value);

		[RequiredByFeature("EGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool eglSwapBuffers(nint dpy, nint surface);

		[RequiredByFeature("EGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool eglTerminate(nint dpy);

		[RequiredByFeature("EGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool eglWaitGL();

		[RequiredByFeature("EGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool eglWaitNative(int engine);

		[RequiredByFeature("EGL_VERSION_1_1")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool eglBindTexImage(nint dpy, nint surface, int buffer);

		[RequiredByFeature("EGL_VERSION_1_1")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool eglReleaseTexImage(nint dpy, nint surface, int buffer);

		[RequiredByFeature("EGL_VERSION_1_1")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool eglSurfaceAttrib(nint dpy, nint surface, int attribute, int value);

		[RequiredByFeature("EGL_VERSION_1_1")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool eglSwapInterval(nint dpy, int interval);

		[RequiredByFeature("EGL_VERSION_1_2")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool eglBindAPI(uint api);

		[RequiredByFeature("EGL_VERSION_1_2")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate uint eglQueryAPI();

		[RequiredByFeature("EGL_VERSION_1_2")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint eglCreatePbufferFromClientBuffer(nint dpy, uint buftype, nint buffer, nint config, int* attrib_list);

		[RequiredByFeature("EGL_VERSION_1_2")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool eglReleaseThread();

		[RequiredByFeature("EGL_VERSION_1_2")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool eglWaitClient();

		[RequiredByFeature("EGL_VERSION_1_4")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint eglGetCurrentContext();

		[RequiredByFeature("EGL_VERSION_1_5")]
		[RequiredByFeature("EGL_KHR_cl_event2")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint eglCreateSync(nint dpy, uint type, nint* attrib_list);

		[RequiredByFeature("EGL_VERSION_1_5")]
		[RequiredByFeature("EGL_KHR_fence_sync")]
		[RequiredByFeature("EGL_KHR_reusable_sync")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool eglDestroySync(nint dpy, nint sync);

		[RequiredByFeature("EGL_VERSION_1_5")]
		[RequiredByFeature("EGL_KHR_fence_sync")]
		[RequiredByFeature("EGL_KHR_reusable_sync")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate int eglClientWaitSync(nint dpy, nint sync, int flags, ulong timeout);

		[RequiredByFeature("EGL_VERSION_1_5")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglGetSyncAttrib(nint dpy, nint sync, int attribute, nint* value);

		[RequiredByFeature("EGL_VERSION_1_5")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint eglCreateImage(nint dpy, nint ctx, uint target, nint buffer, nint* attrib_list);

		[RequiredByFeature("EGL_VERSION_1_5")]
		[RequiredByFeature("EGL_KHR_image")]
		[RequiredByFeature("EGL_KHR_image_base")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool eglDestroyImage(nint dpy, nint image);

		[RequiredByFeature("EGL_VERSION_1_5")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint eglGetPlatformDisplay(uint platform, nint native_display, nint* attrib_list);

		[RequiredByFeature("EGL_VERSION_1_5")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint eglCreatePlatformWindowSurface(nint dpy, nint config, nint native_window, nint* attrib_list);

		[RequiredByFeature("EGL_VERSION_1_5")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint eglCreatePlatformPixmapSurface(nint dpy, nint config, nint native_pixmap, nint* attrib_list);

		[RequiredByFeature("EGL_VERSION_1_5")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool eglWaitSync(nint dpy, nint sync, int flags);

		[RequiredByFeature("EGL_EXT_device_base")]
		[RequiredByFeature("EGL_EXT_device_enumeration")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglQueryDevicesEXT(int max_devices, nint* devices, int* num_devices);

		[RequiredByFeature("EGL_EXT_device_base")]
		[RequiredByFeature("EGL_EXT_device_query")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglQueryDeviceAttribEXT(nint device, int attribute, nint* value);

		[RequiredByFeature("EGL_EXT_device_base")]
		[RequiredByFeature("EGL_EXT_device_query")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint eglQueryDeviceStringEXT(nint device, int name);

		[RequiredByFeature("EGL_EXT_device_base")]
		[RequiredByFeature("EGL_EXT_device_query")]
		[RequiredByFeature("EGL_NV_stream_metadata")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglQueryDisplayAttribEXT(nint dpy, int attribute, nint* value);

		[RequiredByFeature("EGL_EXT_image_dma_buf_import_modifiers")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglQueryDmaBufFormatsEXT(nint dpy, int max_formats, int* formats, int* num_formats);

		[RequiredByFeature("EGL_EXT_image_dma_buf_import_modifiers")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglQueryDmaBufModifiersEXT(nint dpy, int format, int max_modifiers, ulong* modifiers, bool* external_only, int* num_modifiers);

		[RequiredByFeature("EGL_EXT_output_base")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglGetOutputLayersEXT(nint dpy, nint* attrib_list, nint* layers, int max_layers, int* num_layers);

		[RequiredByFeature("EGL_EXT_output_base")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglGetOutputPortsEXT(nint dpy, nint* attrib_list, nint* ports, int max_ports, int* num_ports);

		[RequiredByFeature("EGL_EXT_output_base")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool eglOutputLayerAttribEXT(nint dpy, nint layer, int attribute, nint value);

		[RequiredByFeature("EGL_EXT_output_base")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglQueryOutputLayerAttribEXT(nint dpy, nint layer, int attribute, nint* value);

		[RequiredByFeature("EGL_EXT_output_base")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint eglQueryOutputLayerStringEXT(nint dpy, nint layer, int name);

		[RequiredByFeature("EGL_EXT_output_base")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool eglOutputPortAttribEXT(nint dpy, nint port, int attribute, nint value);

		[RequiredByFeature("EGL_EXT_output_base")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglQueryOutputPortAttribEXT(nint dpy, nint port, int attribute, nint* value);

		[RequiredByFeature("EGL_EXT_output_base")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint eglQueryOutputPortStringEXT(nint dpy, nint port, int name);

		[RequiredByFeature("EGL_EXT_platform_base")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint eglGetPlatformDisplayEXT(uint platform, nint native_display, int* attrib_list);

		[RequiredByFeature("EGL_EXT_platform_base")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint eglCreatePlatformWindowSurfaceEXT(nint dpy, nint config, nint native_window, int* attrib_list);

		[RequiredByFeature("EGL_EXT_platform_base")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint eglCreatePlatformPixmapSurfaceEXT(nint dpy, nint config, nint native_pixmap, int* attrib_list);

		[RequiredByFeature("EGL_EXT_stream_consumer_egloutput")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool eglStreamConsumerOutputEXT(nint dpy, nint stream, nint layer);

		[RequiredByFeature("EGL_EXT_swap_buffers_with_damage")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglSwapBuffersWithDamageEXT(nint dpy, nint surface, int* rects, int n_rects);

		[RequiredByFeature("EGL_HI_clientpixmap")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint eglCreatePixmapSurfaceHI(nint dpy, nint config, ClientPixmap* pixmap);

		[RequiredByFeature("EGL_KHR_debug")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate int eglDebugMessageControlKHR(DebugProcKHR callback, nint* attrib_list);

		[RequiredByFeature("EGL_KHR_debug")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglQueryDebugKHR(int attribute, nint* value);

		[RequiredByFeature("EGL_KHR_debug")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate int eglLabelObjectKHR(nint display, uint objectType, nint @object, nint label);

		[RequiredByFeature("EGL_KHR_image")]
		[RequiredByFeature("EGL_KHR_image_base")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint eglCreateImageKHR(nint dpy, nint ctx, uint target, nint buffer, int* attrib_list);

		[RequiredByFeature("EGL_KHR_lock_surface")]
		[RequiredByFeature("EGL_KHR_lock_surface3")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglLockSurfaceKHR(nint dpy, nint surface, int* attrib_list);

		[RequiredByFeature("EGL_KHR_lock_surface")]
		[RequiredByFeature("EGL_KHR_lock_surface3")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool eglUnlockSurfaceKHR(nint dpy, nint surface);

		[RequiredByFeature("EGL_KHR_lock_surface3")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglQuerySurface64KHR(nint dpy, nint surface, int attribute, nint* value);

		[RequiredByFeature("EGL_KHR_partial_update")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglSetDamageRegionKHR(nint dpy, nint surface, int* rects, int n_rects);

		[RequiredByFeature("EGL_KHR_fence_sync")]
		[RequiredByFeature("EGL_KHR_reusable_sync")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint eglCreateSyncKHR(nint dpy, uint type, int* attrib_list);

		[RequiredByFeature("EGL_KHR_reusable_sync")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool eglSignalSyncKHR(nint dpy, nint sync, uint mode);

		[RequiredByFeature("EGL_KHR_fence_sync")]
		[RequiredByFeature("EGL_KHR_reusable_sync")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglGetSyncAttribKHR(nint dpy, nint sync, int attribute, int* value);

		[RequiredByFeature("EGL_KHR_stream")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint eglCreateStreamKHR(nint dpy, int* attrib_list);

		[RequiredByFeature("EGL_KHR_stream")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool eglDestroyStreamKHR(nint dpy, nint stream);

		[RequiredByFeature("EGL_KHR_stream")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool eglStreamAttribKHR(nint dpy, nint stream, uint attribute, int value);

		[RequiredByFeature("EGL_KHR_stream")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglQueryStreamKHR(nint dpy, nint stream, uint attribute, int* value);

		[RequiredByFeature("EGL_KHR_stream")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglQueryStreamu64KHR(nint dpy, nint stream, uint attribute, ulong* value);

		[RequiredByFeature("EGL_KHR_stream_attrib")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint eglCreateStreamAttribKHR(nint dpy, nint* attrib_list);

		[RequiredByFeature("EGL_KHR_stream_attrib")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool eglSetStreamAttribKHR(nint dpy, nint stream, uint attribute, nint value);

		[RequiredByFeature("EGL_KHR_stream_attrib")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglQueryStreamAttribKHR(nint dpy, nint stream, uint attribute, nint* value);

		[RequiredByFeature("EGL_KHR_stream_attrib")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglStreamConsumerAcquireAttribKHR(nint dpy, nint stream, nint* attrib_list);

		[RequiredByFeature("EGL_KHR_stream_attrib")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglStreamConsumerReleaseAttribKHR(nint dpy, nint stream, nint* attrib_list);

		[RequiredByFeature("EGL_KHR_stream_consumer_gltexture")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool eglStreamConsumerGLTextureExternalKHR(nint dpy, nint stream);

		[RequiredByFeature("EGL_KHR_stream_consumer_gltexture")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool eglStreamConsumerAcquireKHR(nint dpy, nint stream);

		[RequiredByFeature("EGL_KHR_stream_consumer_gltexture")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool eglStreamConsumerReleaseKHR(nint dpy, nint stream);

		[RequiredByFeature("EGL_KHR_stream_cross_process_fd")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate int eglGetStreamFileDescriptorKHR(nint dpy, nint stream);

		[RequiredByFeature("EGL_KHR_stream_cross_process_fd")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint eglCreateStreamFromFileDescriptorKHR(nint dpy, int file_descriptor);

		[RequiredByFeature("EGL_KHR_stream_fifo")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglQueryStreamTimeKHR(nint dpy, nint stream, uint attribute, ulong* value);

		[RequiredByFeature("EGL_KHR_stream_producer_eglsurface")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint eglCreateStreamProducerSurfaceKHR(nint dpy, nint config, nint stream, int* attrib_list);

		[RequiredByFeature("EGL_KHR_swap_buffers_with_damage")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglSwapBuffersWithDamageKHR(nint dpy, nint surface, int* rects, int n_rects);

		[RequiredByFeature("EGL_KHR_wait_sync")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate int eglWaitSyncKHR(nint dpy, nint sync, int flags);

		[RequiredByFeature("EGL_MESA_drm_image")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint eglCreateDRMImageMESA(nint dpy, int* attrib_list);

		[RequiredByFeature("EGL_MESA_drm_image")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglExportDRMImageMESA(nint dpy, nint image, int* name, int* handle, int* stride);

		[RequiredByFeature("EGL_MESA_image_dma_buf_export")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglExportDMABUFImageQueryMESA(nint dpy, nint image, int* fourcc, int* num_planes, ulong* modifiers);

		[RequiredByFeature("EGL_MESA_image_dma_buf_export")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglExportDMABUFImageMESA(nint dpy, nint image, int* fds, int* strides, int* offsets);

		[RequiredByFeature("EGL_NOK_swap_region")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglSwapBuffersRegionNOK(nint dpy, nint surface, int numRects, int* rects);

		[RequiredByFeature("EGL_NOK_swap_region2")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglSwapBuffersRegion2NOK(nint dpy, nint surface, int numRects, int* rects);

		[RequiredByFeature("EGL_NV_native_query")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglQueryNativeDisplayNV(nint dpy, nint* display_id);

		[RequiredByFeature("EGL_NV_native_query")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglQueryNativeWindowNV(nint dpy, nint surf, nint* window);

		[RequiredByFeature("EGL_NV_native_query")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglQueryNativePixmapNV(nint dpy, nint surf, nint* pixmap);

		[RequiredByFeature("EGL_NV_post_sub_buffer")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool eglPostSubBufferNV(nint dpy, nint surface, int x, int y, int width, int height);

		[RequiredByFeature("EGL_NV_stream_consumer_gltexture_yuv")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglStreamConsumerGLTextureExternalAttribsNV(nint dpy, nint stream, nint* attrib_list);

		[RequiredByFeature("EGL_NV_stream_metadata")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool eglSetStreamMetadataNV(nint dpy, nint stream, int n, int offset, int size, nint data);

		[RequiredByFeature("EGL_NV_stream_metadata")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool eglQueryStreamMetadataNV(nint dpy, nint stream, uint name, int n, int offset, int size, nint data);

		[RequiredByFeature("EGL_NV_stream_reset")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool eglResetStreamNV(nint dpy, nint stream);

		[RequiredByFeature("EGL_NV_stream_sync")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint eglCreateStreamSyncNV(nint dpy, nint stream, uint type, int* attrib_list);

		[RequiredByFeature("EGL_NV_sync")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint eglCreateFenceSyncNV(nint dpy, uint condition, int* attrib_list);

		[RequiredByFeature("EGL_NV_sync")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool eglDestroySyncNV(nint sync);

		[RequiredByFeature("EGL_NV_sync")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool eglFenceNV(nint sync);

		[RequiredByFeature("EGL_NV_sync")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate int eglClientWaitSyncNV(nint sync, int flags, ulong timeout);

		[RequiredByFeature("EGL_NV_sync")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool eglSignalSyncNV(nint sync, uint mode);

		[RequiredByFeature("EGL_NV_sync")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool eglGetSyncAttribNV(nint sync, int attribute, int* value);

		[RequiredByFeature("EGL_NV_system_time")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate ulong eglGetSystemTimeFrequencyNV();

		[RequiredByFeature("EGL_NV_system_time")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate ulong eglGetSystemTimeNV();

		[RequiredByFeature("EGL_ANDROID_blob_cache")]
		internal static eglSetBlobCacheFuncsANDROID peglSetBlobCacheFuncsANDROID;

		[RequiredByFeature("EGL_ANDROID_create_native_client_buffer")]
		internal static eglCreateNativeClientBufferANDROID peglCreateNativeClientBufferANDROID;

		[RequiredByFeature("EGL_ANDROID_native_fence_sync")]
		internal static eglDupNativeFenceFDANDROID peglDupNativeFenceFDANDROID;

		[RequiredByFeature("EGL_ANDROID_presentation_time")]
		internal static eglPresentationTimeANDROID peglPresentationTimeANDROID;

		[RequiredByFeature("EGL_ANGLE_query_surface_pointer")]
		internal static eglQuerySurfacePointerANGLE peglQuerySurfacePointerANGLE;

		[RequiredByFeature("EGL_VERSION_1_0")]
		internal static eglChooseConfig peglChooseConfig;

		[RequiredByFeature("EGL_VERSION_1_0")]
		internal static eglCopyBuffers peglCopyBuffers;

		[RequiredByFeature("EGL_VERSION_1_0")]
		internal static eglCreateContext peglCreateContext;

		[RequiredByFeature("EGL_VERSION_1_0")]
		internal static eglCreatePbufferSurface peglCreatePbufferSurface;

		[RequiredByFeature("EGL_VERSION_1_0")]
		internal static eglCreatePixmapSurface peglCreatePixmapSurface;

		[RequiredByFeature("EGL_VERSION_1_0")]
		internal static eglCreateWindowSurface peglCreateWindowSurface;

		[RequiredByFeature("EGL_VERSION_1_0")]
		internal static eglDestroyContext peglDestroyContext;

		[RequiredByFeature("EGL_VERSION_1_0")]
		internal static eglDestroySurface peglDestroySurface;

		[RequiredByFeature("EGL_VERSION_1_0")]
		internal static eglGetConfigAttrib peglGetConfigAttrib;

		[RequiredByFeature("EGL_VERSION_1_0")]
		internal static eglGetConfigs peglGetConfigs;

		[RequiredByFeature("EGL_VERSION_1_0")]
		internal static eglGetCurrentDisplay peglGetCurrentDisplay;

		[RequiredByFeature("EGL_VERSION_1_0")]
		internal static eglGetCurrentSurface peglGetCurrentSurface;

		[RequiredByFeature("EGL_VERSION_1_0")]
		internal static eglGetDisplay peglGetDisplay;

		[RequiredByFeature("EGL_VERSION_1_0")]
		internal static eglGetError peglGetError;

		[RequiredByFeature("EGL_VERSION_1_0")]
		internal static eglGetProcAddress peglGetProcAddress;

		[RequiredByFeature("EGL_VERSION_1_0")]
		internal static eglInitialize peglInitialize;

		[RequiredByFeature("EGL_VERSION_1_0")]
		internal static eglMakeCurrent peglMakeCurrent;

		[RequiredByFeature("EGL_VERSION_1_0")]
		internal static eglQueryContext peglQueryContext;

		[RequiredByFeature("EGL_VERSION_1_0")]
		internal static eglQueryString peglQueryString;

		[RequiredByFeature("EGL_VERSION_1_0")]
		internal static eglQuerySurface peglQuerySurface;

		[RequiredByFeature("EGL_VERSION_1_0")]
		internal static eglSwapBuffers peglSwapBuffers;

		[RequiredByFeature("EGL_VERSION_1_0")]
		internal static eglTerminate peglTerminate;

		[RequiredByFeature("EGL_VERSION_1_0")]
		internal static eglWaitGL peglWaitGL;

		[RequiredByFeature("EGL_VERSION_1_0")]
		internal static eglWaitNative peglWaitNative;

		[RequiredByFeature("EGL_VERSION_1_1")]
		internal static eglBindTexImage peglBindTexImage;

		[RequiredByFeature("EGL_VERSION_1_1")]
		internal static eglReleaseTexImage peglReleaseTexImage;

		[RequiredByFeature("EGL_VERSION_1_1")]
		internal static eglSurfaceAttrib peglSurfaceAttrib;

		[RequiredByFeature("EGL_VERSION_1_1")]
		internal static eglSwapInterval peglSwapInterval;

		[RequiredByFeature("EGL_VERSION_1_2")]
		internal static eglBindAPI peglBindAPI;

		[RequiredByFeature("EGL_VERSION_1_2")]
		internal static eglQueryAPI peglQueryAPI;

		[RequiredByFeature("EGL_VERSION_1_2")]
		internal static eglCreatePbufferFromClientBuffer peglCreatePbufferFromClientBuffer;

		[RequiredByFeature("EGL_VERSION_1_2")]
		internal static eglReleaseThread peglReleaseThread;

		[RequiredByFeature("EGL_VERSION_1_2")]
		internal static eglWaitClient peglWaitClient;

		[RequiredByFeature("EGL_VERSION_1_4")]
		internal static eglGetCurrentContext peglGetCurrentContext;

		[RequiredByFeature("EGL_VERSION_1_5")]
		[RequiredByFeature("EGL_KHR_cl_event2", EntryPoint = "eglCreateSync64KHR")]
		internal static eglCreateSync peglCreateSync;

		[RequiredByFeature("EGL_VERSION_1_5")]
		[RequiredByFeature("EGL_KHR_fence_sync", EntryPoint = "eglDestroySyncKHR")]
		[RequiredByFeature("EGL_KHR_reusable_sync", EntryPoint = "eglDestroySyncKHR")]
		internal static eglDestroySync peglDestroySync;

		[RequiredByFeature("EGL_VERSION_1_5")]
		[RequiredByFeature("EGL_KHR_fence_sync", EntryPoint = "eglClientWaitSyncKHR")]
		[RequiredByFeature("EGL_KHR_reusable_sync", EntryPoint = "eglClientWaitSyncKHR")]
		internal static eglClientWaitSync peglClientWaitSync;

		[RequiredByFeature("EGL_VERSION_1_5")]
		internal static eglGetSyncAttrib peglGetSyncAttrib;

		[RequiredByFeature("EGL_VERSION_1_5")]
		internal static eglCreateImage peglCreateImage;

		[RequiredByFeature("EGL_VERSION_1_5")]
		[RequiredByFeature("EGL_KHR_image", EntryPoint = "eglDestroyImageKHR")]
		[RequiredByFeature("EGL_KHR_image_base", EntryPoint = "eglDestroyImageKHR")]
		internal static eglDestroyImage peglDestroyImage;

		[RequiredByFeature("EGL_VERSION_1_5")]
		internal static eglGetPlatformDisplay peglGetPlatformDisplay;

		[RequiredByFeature("EGL_VERSION_1_5")]
		internal static eglCreatePlatformWindowSurface peglCreatePlatformWindowSurface;

		[RequiredByFeature("EGL_VERSION_1_5")]
		internal static eglCreatePlatformPixmapSurface peglCreatePlatformPixmapSurface;

		[RequiredByFeature("EGL_VERSION_1_5")]
		internal static eglWaitSync peglWaitSync;

		[RequiredByFeature("EGL_EXT_device_base")]
		[RequiredByFeature("EGL_EXT_device_enumeration")]
		internal static eglQueryDevicesEXT peglQueryDevicesEXT;

		[RequiredByFeature("EGL_EXT_device_base")]
		[RequiredByFeature("EGL_EXT_device_query")]
		internal static eglQueryDeviceAttribEXT peglQueryDeviceAttribEXT;

		[RequiredByFeature("EGL_EXT_device_base")]
		[RequiredByFeature("EGL_EXT_device_query")]
		internal static eglQueryDeviceStringEXT peglQueryDeviceStringEXT;

		[RequiredByFeature("EGL_EXT_device_base")]
		[RequiredByFeature("EGL_EXT_device_query")]
		[RequiredByFeature("EGL_NV_stream_metadata", EntryPoint = "eglQueryDisplayAttribNV")]
		internal static eglQueryDisplayAttribEXT peglQueryDisplayAttribEXT;

		[RequiredByFeature("EGL_EXT_image_dma_buf_import_modifiers")]
		internal static eglQueryDmaBufFormatsEXT peglQueryDmaBufFormatsEXT;

		[RequiredByFeature("EGL_EXT_image_dma_buf_import_modifiers")]
		internal static eglQueryDmaBufModifiersEXT peglQueryDmaBufModifiersEXT;

		[RequiredByFeature("EGL_EXT_output_base")]
		internal static eglGetOutputLayersEXT peglGetOutputLayersEXT;

		[RequiredByFeature("EGL_EXT_output_base")]
		internal static eglGetOutputPortsEXT peglGetOutputPortsEXT;

		[RequiredByFeature("EGL_EXT_output_base")]
		internal static eglOutputLayerAttribEXT peglOutputLayerAttribEXT;

		[RequiredByFeature("EGL_EXT_output_base")]
		internal static eglQueryOutputLayerAttribEXT peglQueryOutputLayerAttribEXT;

		[RequiredByFeature("EGL_EXT_output_base")]
		internal static eglQueryOutputLayerStringEXT peglQueryOutputLayerStringEXT;

		[RequiredByFeature("EGL_EXT_output_base")]
		internal static eglOutputPortAttribEXT peglOutputPortAttribEXT;

		[RequiredByFeature("EGL_EXT_output_base")]
		internal static eglQueryOutputPortAttribEXT peglQueryOutputPortAttribEXT;

		[RequiredByFeature("EGL_EXT_output_base")]
		internal static eglQueryOutputPortStringEXT peglQueryOutputPortStringEXT;

		[RequiredByFeature("EGL_EXT_platform_base")]
		internal static eglGetPlatformDisplayEXT peglGetPlatformDisplayEXT;

		[RequiredByFeature("EGL_EXT_platform_base")]
		internal static eglCreatePlatformWindowSurfaceEXT peglCreatePlatformWindowSurfaceEXT;

		[RequiredByFeature("EGL_EXT_platform_base")]
		internal static eglCreatePlatformPixmapSurfaceEXT peglCreatePlatformPixmapSurfaceEXT;

		[RequiredByFeature("EGL_EXT_stream_consumer_egloutput")]
		internal static eglStreamConsumerOutputEXT peglStreamConsumerOutputEXT;

		[RequiredByFeature("EGL_EXT_swap_buffers_with_damage")]
		internal static eglSwapBuffersWithDamageEXT peglSwapBuffersWithDamageEXT;

		[RequiredByFeature("EGL_HI_clientpixmap")]
		internal static eglCreatePixmapSurfaceHI peglCreatePixmapSurfaceHI;

		[RequiredByFeature("EGL_KHR_debug")]
		internal static eglDebugMessageControlKHR peglDebugMessageControlKHR;

		[RequiredByFeature("EGL_KHR_debug")]
		internal static eglQueryDebugKHR peglQueryDebugKHR;

		[RequiredByFeature("EGL_KHR_debug")]
		internal static eglLabelObjectKHR peglLabelObjectKHR;

		[RequiredByFeature("EGL_KHR_image")]
		[RequiredByFeature("EGL_KHR_image_base")]
		internal static eglCreateImageKHR peglCreateImageKHR;

		[RequiredByFeature("EGL_KHR_lock_surface")]
		[RequiredByFeature("EGL_KHR_lock_surface3")]
		internal static eglLockSurfaceKHR peglLockSurfaceKHR;

		[RequiredByFeature("EGL_KHR_lock_surface")]
		[RequiredByFeature("EGL_KHR_lock_surface3")]
		internal static eglUnlockSurfaceKHR peglUnlockSurfaceKHR;

		[RequiredByFeature("EGL_KHR_lock_surface3")]
		internal static eglQuerySurface64KHR peglQuerySurface64KHR;

		[RequiredByFeature("EGL_KHR_partial_update")]
		internal static eglSetDamageRegionKHR peglSetDamageRegionKHR;

		[RequiredByFeature("EGL_KHR_fence_sync")]
		[RequiredByFeature("EGL_KHR_reusable_sync")]
		internal static eglCreateSyncKHR peglCreateSyncKHR;

		[RequiredByFeature("EGL_KHR_reusable_sync")]
		internal static eglSignalSyncKHR peglSignalSyncKHR;

		[RequiredByFeature("EGL_KHR_fence_sync")]
		[RequiredByFeature("EGL_KHR_reusable_sync")]
		internal static eglGetSyncAttribKHR peglGetSyncAttribKHR;

		[RequiredByFeature("EGL_KHR_stream")]
		internal static eglCreateStreamKHR peglCreateStreamKHR;

		[RequiredByFeature("EGL_KHR_stream")]
		internal static eglDestroyStreamKHR peglDestroyStreamKHR;

		[RequiredByFeature("EGL_KHR_stream")]
		internal static eglStreamAttribKHR peglStreamAttribKHR;

		[RequiredByFeature("EGL_KHR_stream")]
		internal static eglQueryStreamKHR peglQueryStreamKHR;

		[RequiredByFeature("EGL_KHR_stream")]
		internal static eglQueryStreamu64KHR peglQueryStreamu64KHR;

		[RequiredByFeature("EGL_KHR_stream_attrib")]
		internal static eglCreateStreamAttribKHR peglCreateStreamAttribKHR;

		[RequiredByFeature("EGL_KHR_stream_attrib")]
		internal static eglSetStreamAttribKHR peglSetStreamAttribKHR;

		[RequiredByFeature("EGL_KHR_stream_attrib")]
		internal static eglQueryStreamAttribKHR peglQueryStreamAttribKHR;

		[RequiredByFeature("EGL_KHR_stream_attrib")]
		internal static eglStreamConsumerAcquireAttribKHR peglStreamConsumerAcquireAttribKHR;

		[RequiredByFeature("EGL_KHR_stream_attrib")]
		internal static eglStreamConsumerReleaseAttribKHR peglStreamConsumerReleaseAttribKHR;

		[RequiredByFeature("EGL_KHR_stream_consumer_gltexture")]
		internal static eglStreamConsumerGLTextureExternalKHR peglStreamConsumerGLTextureExternalKHR;

		[RequiredByFeature("EGL_KHR_stream_consumer_gltexture")]
		internal static eglStreamConsumerAcquireKHR peglStreamConsumerAcquireKHR;

		[RequiredByFeature("EGL_KHR_stream_consumer_gltexture")]
		internal static eglStreamConsumerReleaseKHR peglStreamConsumerReleaseKHR;

		[RequiredByFeature("EGL_KHR_stream_cross_process_fd")]
		internal static eglGetStreamFileDescriptorKHR peglGetStreamFileDescriptorKHR;

		[RequiredByFeature("EGL_KHR_stream_cross_process_fd")]
		internal static eglCreateStreamFromFileDescriptorKHR peglCreateStreamFromFileDescriptorKHR;

		[RequiredByFeature("EGL_KHR_stream_fifo")]
		internal static eglQueryStreamTimeKHR peglQueryStreamTimeKHR;

		[RequiredByFeature("EGL_KHR_stream_producer_eglsurface")]
		internal static eglCreateStreamProducerSurfaceKHR peglCreateStreamProducerSurfaceKHR;

		[RequiredByFeature("EGL_KHR_swap_buffers_with_damage")]
		internal static eglSwapBuffersWithDamageKHR peglSwapBuffersWithDamageKHR;

		[RequiredByFeature("EGL_KHR_wait_sync")]
		internal static eglWaitSyncKHR peglWaitSyncKHR;

		[RequiredByFeature("EGL_MESA_drm_image")]
		internal static eglCreateDRMImageMESA peglCreateDRMImageMESA;

		[RequiredByFeature("EGL_MESA_drm_image")]
		internal static eglExportDRMImageMESA peglExportDRMImageMESA;

		[RequiredByFeature("EGL_MESA_image_dma_buf_export")]
		internal static eglExportDMABUFImageQueryMESA peglExportDMABUFImageQueryMESA;

		[RequiredByFeature("EGL_MESA_image_dma_buf_export")]
		internal static eglExportDMABUFImageMESA peglExportDMABUFImageMESA;

		[RequiredByFeature("EGL_NOK_swap_region")]
		internal static eglSwapBuffersRegionNOK peglSwapBuffersRegionNOK;

		[RequiredByFeature("EGL_NOK_swap_region2")]
		internal static eglSwapBuffersRegion2NOK peglSwapBuffersRegion2NOK;

		[RequiredByFeature("EGL_NV_native_query")]
		internal static eglQueryNativeDisplayNV peglQueryNativeDisplayNV;

		[RequiredByFeature("EGL_NV_native_query")]
		internal static eglQueryNativeWindowNV peglQueryNativeWindowNV;

		[RequiredByFeature("EGL_NV_native_query")]
		internal static eglQueryNativePixmapNV peglQueryNativePixmapNV;

		[RequiredByFeature("EGL_NV_post_sub_buffer")]
		internal static eglPostSubBufferNV peglPostSubBufferNV;

		[RequiredByFeature("EGL_NV_stream_consumer_gltexture_yuv")]
		internal static eglStreamConsumerGLTextureExternalAttribsNV peglStreamConsumerGLTextureExternalAttribsNV;

		[RequiredByFeature("EGL_NV_stream_metadata")]
		internal static eglSetStreamMetadataNV peglSetStreamMetadataNV;

		[RequiredByFeature("EGL_NV_stream_metadata")]
		internal static eglQueryStreamMetadataNV peglQueryStreamMetadataNV;

		[RequiredByFeature("EGL_NV_stream_reset")]
		internal static eglResetStreamNV peglResetStreamNV;

		[RequiredByFeature("EGL_NV_stream_sync")]
		internal static eglCreateStreamSyncNV peglCreateStreamSyncNV;

		[RequiredByFeature("EGL_NV_sync")]
		internal static eglCreateFenceSyncNV peglCreateFenceSyncNV;

		[RequiredByFeature("EGL_NV_sync")]
		internal static eglDestroySyncNV peglDestroySyncNV;

		[RequiredByFeature("EGL_NV_sync")]
		internal static eglFenceNV peglFenceNV;

		[RequiredByFeature("EGL_NV_sync")]
		internal static eglClientWaitSyncNV peglClientWaitSyncNV;

		[RequiredByFeature("EGL_NV_sync")]
		internal static eglSignalSyncNV peglSignalSyncNV;

		[RequiredByFeature("EGL_NV_sync")]
		internal static eglGetSyncAttribNV peglGetSyncAttribNV;

		[RequiredByFeature("EGL_NV_system_time")]
		internal static eglGetSystemTimeFrequencyNV peglGetSystemTimeFrequencyNV;

		[RequiredByFeature("EGL_NV_system_time")]
		internal static eglGetSystemTimeNV peglGetSystemTimeNV;
	}

	public struct ClientPixmap
	{
		public nint Data;

		public int Width;

		public int Height;

		public int Stride;
	}

	public delegate void SetBlobFuncDelegate(nint key, uint keySize, nint value, uint valueSize);

	public delegate void GetBlobFuncDelegate(nint key, uint keySize, [Out] nint value, uint valueSize);

	public delegate void DebugProcKHR(uint error, string command, int messageType, nint threadLabel, nint objectLabel, string message);

	public class Extensions : ExtensionsCollection
	{
		[Extension("EGL_KHR_gl_texture_cubemap_image")]
		public bool GlTextureCubemapImage_KHR;

		[Extension("EGL_KHR_wait_sync")]
		public bool WaitSync_KHR;

		[Extension("EGL_KHR_vg_parent_image")]
		public bool VgParentImage_KHR;

		[Extension("EGL_KHR_swap_buffers_with_damage")]
		public bool SwapBuffersWithDamage_KHR;

		[Extension("EGL_KHR_surfaceless_context")]
		public bool SurfacelessContext_KHR;

		[Extension("EGL_KHR_stream_producer_eglsurface")]
		public bool StreamProducerEglsurface_KHR;

		[Extension("EGL_KHR_stream_producer_aldatalocator")]
		public bool StreamProducerAldatalocator_KHR;

		[Extension("EGL_KHR_stream_fifo")]
		public bool StreamFifo_KHR;

		[Extension("EGL_KHR_stream_cross_process_fd")]
		public bool StreamCrossProcessFd_KHR;

		[Extension("EGL_KHR_stream_consumer_gltexture")]
		public bool StreamConsumerGltexture_KHR;

		[Extension("EGL_KHR_stream_attrib")]
		public bool StreamAttrib_KHR;

		[Extension("EGL_KHR_stream")]
		public bool Stream_KHR;

		[Extension("EGL_KHR_reusable_sync")]
		public bool ReusableSync_KHR;

		[Extension("EGL_KHR_platform_x11")]
		public bool PlatformX11_KHR;

		[Extension("EGL_KHR_platform_wayland")]
		public bool PlatformWayland_KHR;

		[Extension("EGL_KHR_platform_gbm")]
		public bool PlatformGbm_KHR;

		[Extension("EGL_KHR_platform_android")]
		public bool PlatformAndroid_KHR;

		[Extension("EGL_KHR_partial_update")]
		public bool PartialUpdate_KHR;

		[Extension("EGL_KHR_no_config_context")]
		public bool NoConfigContext_KHR;

		[Extension("EGL_KHR_mutable_render_buffer")]
		public bool MutableRenderBuffer_KHR;

		[Extension("EGL_KHR_lock_surface3")]
		public bool LockSurface3_KHR;

		[Extension("EGL_KHR_lock_surface2")]
		public bool LockSurface2_KHR;

		[Extension("EGL_KHR_lock_surface")]
		public bool LockSurface_KHR;

		[Extension("EGL_KHR_image_pixmap")]
		public bool ImagePixmap_KHR;

		[Extension("EGL_KHR_image_base")]
		public bool ImageBase_KHR;

		[Extension("EGL_KHR_image")]
		public bool Image_KHR;

		[Extension("EGL_KHR_gl_texture_3D_image")]
		public bool GlTexture3DImage_KHR;

		[Extension("EGL_KHR_gl_texture_2D_image")]
		public bool GlTexture2DImage_KHR;

		[Extension("EGL_KHR_gl_renderbuffer_image")]
		public bool GlRenderbufferImage_KHR;

		[Extension("EGL_KHR_gl_colorspace")]
		public bool GlColorspace_KHR;

		[Extension("EGL_KHR_get_all_proc_addresses")]
		public bool GetAllProcAddresses_KHR;

		[Extension("EGL_KHR_fence_sync")]
		public bool FenceSync_KHR;

		[Extension("EGL_KHR_debug")]
		public bool Debug_KHR;

		[Extension("EGL_KHR_create_context_no_error")]
		public bool CreateContextNoError_KHR;

		[Extension("EGL_KHR_create_context")]
		public bool CreateContext_KHR;

		[Extension("EGL_KHR_context_flush_control")]
		public bool ContextFlushControl_KHR;

		[Extension("EGL_KHR_client_get_all_proc_addresses")]
		public bool ClientGetAllProcAddresses_KHR;

		[Extension("EGL_KHR_config_attribs")]
		public bool ConfigAttribs_KHR;

		[Extension("EGL_KHR_cl_event2")]
		public bool ClEvent2_KHR;

		[Extension("EGL_KHR_cl_event")]
		public bool ClEvent_KHR;

		[Extension("EGL_ANDROID_blob_cache")]
		public bool BlobCache_ANDROID;

		[Extension("EGL_TIZEN_image_native_surface")]
		public bool ImageNativeSurface_TIZEN;

		[Extension("EGL_ANDROID_create_native_client_buffer")]
		public bool CreateNativeClientBuffer_ANDROID;

		[Extension("EGL_NV_system_time")]
		public bool SystemTime_NV;

		[Extension("EGL_NV_sync")]
		public bool Sync_NV;

		[Extension("EGL_NV_stream_sync")]
		public bool StreamSync_NV;

		[Extension("EGL_NV_stream_socket_unix")]
		public bool StreamSocketUnix_NV;

		[Extension("EGL_NV_stream_socket_inet")]
		public bool StreamSocketInet_NV;

		[Extension("EGL_NV_stream_socket")]
		public bool StreamSocket_NV;

		[Extension("EGL_NV_stream_remote")]
		public bool StreamRemote_NV;

		[Extension("EGL_NV_stream_reset")]
		public bool StreamReset_NV;

		[Extension("EGL_NV_stream_metadata")]
		public bool StreamMetadata_NV;

		[Extension("EGL_NV_stream_frame_limits")]
		public bool StreamFrameLimits_NV;

		[Extension("EGL_NV_stream_fifo_synchronous")]
		public bool StreamFifoSynchronous_NV;

		[Extension("EGL_NV_stream_fifo_next")]
		public bool StreamFifoNext_NV;

		[Extension("EGL_NV_stream_cross_system")]
		public bool StreamCrossSystem_NV;

		[Extension("EGL_NV_stream_cross_process")]
		public bool StreamCrossProcess_NV;

		[Extension("EGL_NV_stream_cross_partition")]
		public bool StreamCrossPartition_NV;

		[Extension("EGL_NV_stream_cross_display")]
		public bool StreamCrossDisplay_NV;

		[Extension("EGL_NV_stream_cross_object")]
		public bool StreamCrossObject_NV;

		[Extension("EGL_NV_stream_consumer_gltexture_yuv")]
		public bool StreamConsumerGltextureYuv_NV;

		[Extension("EGL_NV_robustness_video_memory_purge")]
		public bool RobustnessVideoMemoryPurge_NV;

		[Extension("EGL_NV_post_sub_buffer")]
		public bool PostSubBuffer_NV;

		[Extension("EGL_NV_post_convert_rounding")]
		public bool PostConvertRounding_NV;

		[Extension("EGL_NV_native_query")]
		public bool NativeQuery_NV;

		[Extension("EGL_NV_device_cuda")]
		public bool DeviceCuda_NV;

		[Extension("EGL_NV_depth_nonlinear")]
		public bool DepthNonlinear_NV;

		[Extension("EGL_NV_cuda_event")]
		public bool CudaEvent_NV;

		[Extension("EGL_NV_coverage_sample_resolve")]
		public bool CoverageSampleResolve_NV;

		[Extension("EGL_NV_coverage_sample")]
		public bool CoverageSample_NV;

		[Extension("EGL_NV_3dvision_surface")]
		public bool _3dvisionSurface_NV;

		[Extension("EGL_NOK_texture_from_pixmap")]
		public bool TextureFromPixmap_NOK;

		[Extension("EGL_NOK_swap_region2")]
		public bool SwapRegion2_NOK;

		[Extension("EGL_NOK_swap_region")]
		public bool SwapRegion_NOK;

		[Extension("EGL_MESA_platform_surfaceless")]
		public bool PlatformSurfaceless_MESA;

		[Extension("EGL_MESA_platform_gbm")]
		public bool PlatformGbm_MESA;

		[Extension("EGL_MESA_image_dma_buf_export")]
		public bool ImageDmaBufExport_MESA;

		[Extension("EGL_MESA_drm_image")]
		public bool DrmImage_MESA;

		[Extension("EGL_TIZEN_image_native_buffer")]
		public bool ImageNativeBuffer_TIZEN;

		[Extension("EGL_IMG_image_plane_attribs")]
		public bool ImagePlaneAttribs_IMG;

		[Extension("EGL_IMG_context_priority")]
		public bool ContextPriority_IMG;

		[Extension("EGL_HI_colorformats")]
		public bool Colorformats_HI;

		[Extension("EGL_HI_clientpixmap")]
		public bool Clientpixmap_HI;

		[Extension("EGL_ANDROID_framebuffer_target")]
		public bool FramebufferTarget_ANDROID;

		[Extension("EGL_ANDROID_front_buffer_auto_refresh")]
		public bool FrontBufferAutoRefresh_ANDROID;

		[Extension("EGL_ANDROID_image_native_buffer")]
		public bool ImageNativeBuffer_ANDROID;

		[Extension("EGL_ANDROID_native_fence_sync")]
		public bool NativeFenceSync_ANDROID;

		[Extension("EGL_ANDROID_presentation_time")]
		public bool PresentationTime_ANDROID;

		[Extension("EGL_ANDROID_recordable")]
		public bool Recordable_ANDROID;

		[Extension("EGL_ANGLE_d3d_share_handle_client_buffer")]
		public bool D3dShareHandleClientBuffer_ANGLE;

		[Extension("EGL_ANGLE_device_d3d")]
		public bool DeviceD3d_ANGLE;

		[Extension("EGL_ANGLE_query_surface_pointer")]
		public bool QuerySurfacePointer_ANGLE;

		[Extension("EGL_ANGLE_surface_d3d_texture_2d_share_handle")]
		public bool SurfaceD3dTexture2dShareHandle_ANGLE;

		[Extension("EGL_ANGLE_window_fixed_size")]
		public bool WindowFixedSize_ANGLE;

		[Extension("EGL_ARM_implicit_external_sync")]
		public bool ImplicitExternalSync_ARM;

		[Extension("EGL_ARM_pixmap_multisample_discard")]
		public bool PixmapMultisampleDiscard_ARM;

		[Extension("EGL_EXT_output_base")]
		public bool OutputBase_EXT;

		[Extension("EGL_EXT_multiview_window")]
		public bool MultiviewWindow_EXT;

		[Extension("EGL_EXT_yuv_surface")]
		public bool YuvSurface_EXT;

		[Extension("EGL_EXT_image_dma_buf_import")]
		public bool ImageDmaBufImport_EXT;

		[Extension("EGL_EXT_gl_colorspace_scrgb_linear")]
		public bool GlColorspaceScrgbLinear_EXT;

		[Extension("EGL_EXT_gl_colorspace_bt2020_pq")]
		public bool GlColorspaceBt2020Pq_EXT;

		[Extension("EGL_EXT_gl_colorspace_bt2020_linear")]
		public bool GlColorspaceBt2020Linear_EXT;

		[Extension("EGL_EXT_device_query")]
		public bool DeviceQuery_EXT;

		[Extension("EGL_EXT_device_openwf")]
		public bool DeviceOpenwf_EXT;

		[Extension("EGL_EXT_device_enumeration")]
		public bool DeviceEnumeration_EXT;

		[Extension("EGL_EXT_device_drm")]
		public bool DeviceDrm_EXT;

		[Extension("EGL_EXT_device_base")]
		public bool DeviceBase_EXT;

		[Extension("EGL_EXT_create_context_robustness")]
		public bool CreateContextRobustness_EXT;

		[Extension("EGL_EXT_client_extensions")]
		public bool ClientExtensions_EXT;

		[Extension("EGL_EXT_buffer_age")]
		public bool BufferAge_EXT;

		[Extension("EGL_EXT_image_dma_buf_import_modifiers")]
		public bool ImageDmaBufImportModifiers_EXT;

		[Extension("EGL_EXT_output_drm")]
		public bool OutputDrm_EXT;

		[Extension("EGL_EXT_output_openwf")]
		public bool OutputOpenwf_EXT;

		[Extension("EGL_EXT_pixel_format_float")]
		public bool PixelFormatFloat_EXT;

		[Extension("EGL_EXT_platform_base")]
		public bool PlatformBase_EXT;

		[Extension("EGL_EXT_platform_device")]
		public bool PlatformDevice_EXT;

		[Extension("EGL_EXT_platform_wayland")]
		public bool PlatformWayland_EXT;

		[Extension("EGL_EXT_platform_x11")]
		public bool PlatformX11_EXT;

		[Extension("EGL_EXT_protected_content")]
		public bool ProtectedContent_EXT;

		[Extension("EGL_EXT_protected_surface")]
		public bool ProtectedSurface_EXT;

		[Extension("EGL_EXT_stream_consumer_egloutput")]
		public bool StreamConsumerEgloutput_EXT;

		[Extension("EGL_EXT_surface_SMPTE2086_metadata")]
		public bool SurfaceSMPTE2086Metadata_EXT;

		[Extension("EGL_EXT_swap_buffers_with_damage")]
		public bool SwapBuffersWithDamage_EXT;

		internal void Query(nint eglDisplay, KhronosVersion eglVersion)
		{
			Khronos.KhronosApi.LogComment("Query EGL extensions.");
			string text = QueryString(eglDisplay, 12373);
			Query(eglVersion, text ?? string.Empty);
		}

		public Extensions Clone()
		{
			return (Extensions)MemberwiseClone();
		}
	}

	[RequiredByFeature("EGL_ANDROID_create_native_client_buffer")]
	public const int NATIVE_BUFFER_USAGE_ANDROID = 12611;

	[RequiredByFeature("EGL_ANDROID_create_native_client_buffer")]
	[Log(BitmaskName = "EGLNativeBufferUsageFlags")]
	public const uint NATIVE_BUFFER_USAGE_PROTECTED_BIT_ANDROID = 1u;

	[RequiredByFeature("EGL_ANDROID_create_native_client_buffer")]
	[Log(BitmaskName = "EGLNativeBufferUsageFlags")]
	public const uint NATIVE_BUFFER_USAGE_RENDERBUFFER_BIT_ANDROID = 2u;

	[RequiredByFeature("EGL_ANDROID_create_native_client_buffer")]
	[Log(BitmaskName = "EGLNativeBufferUsageFlags")]
	public const uint NATIVE_BUFFER_USAGE_TEXTURE_BIT_ANDROID = 4u;

	[RequiredByFeature("EGL_ANDROID_framebuffer_target")]
	public const int FRAMEBUFFER_TARGET_ANDROID = 12615;

	[RequiredByFeature("EGL_ANDROID_front_buffer_auto_refresh")]
	public const int FRONT_BUFFER_AUTO_REFRESH_ANDROID = 12620;

	[RequiredByFeature("EGL_ANDROID_image_native_buffer")]
	public const int NATIVE_BUFFER_ANDROID = 12608;

	[RequiredByFeature("EGL_ANDROID_native_fence_sync")]
	public const int SYNC_NATIVE_FENCE_ANDROID = 12612;

	[RequiredByFeature("EGL_ANDROID_native_fence_sync")]
	public const int SYNC_NATIVE_FENCE_FD_ANDROID = 12613;

	[RequiredByFeature("EGL_ANDROID_native_fence_sync")]
	public const int SYNC_NATIVE_FENCE_SIGNALED_ANDROID = 12614;

	[RequiredByFeature("EGL_ANDROID_native_fence_sync")]
	public const int NO_NATIVE_FENCE_FD_ANDROID = -1;

	[RequiredByFeature("EGL_ANDROID_recordable")]
	public const int RECORDABLE_ANDROID = 12610;

	[RequiredByFeature("EGL_ANGLE_d3d_share_handle_client_buffer")]
	[RequiredByFeature("EGL_ANGLE_surface_d3d_texture_2d_share_handle")]
	public const int D3D_TEXTURE_2D_SHARE_HANDLE_ANGLE = 12800;

	[RequiredByFeature("EGL_ANGLE_device_d3d")]
	public const int D3D9_DEVICE_ANGLE = 13216;

	[RequiredByFeature("EGL_ANGLE_device_d3d")]
	public const int D3D11_DEVICE_ANGLE = 13217;

	[RequiredByFeature("EGL_ANGLE_window_fixed_size")]
	public const int FIXED_SIZE_ANGLE = 12801;

	[RequiredByFeature("EGL_ARM_implicit_external_sync")]
	public const int SYNC_PRIOR_COMMANDS_IMPLICIT_EXTERNAL_ARM = 12938;

	[RequiredByFeature("EGL_ARM_pixmap_multisample_discard")]
	public const int DISCARD_SAMPLES_ARM = 12934;

	private static bool _Initialized;

	internal static string[] AvailableApis;

	private static bool _IsRequired;

	private static bool _IsInitializing;

	private static GetAddressDelegate _GetAddressDelegate;

	internal const string Library = "libEGL.dll";

	private static KhronosLogContext _LogContext;

	public static readonly KhronosVersion Version_100;

	public static readonly KhronosVersion Version_110;

	public static readonly KhronosVersion Version_120;

	public static readonly KhronosVersion Version_130;

	public static readonly KhronosVersion Version_140;

	public static readonly KhronosVersion Version_150;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int ALPHA_SIZE = 12321;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int BAD_ACCESS = 12290;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int BAD_ALLOC = 12291;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int BAD_ATTRIBUTE = 12292;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int BAD_CONFIG = 12293;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int BAD_CONTEXT = 12294;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int BAD_CURRENT_SURFACE = 12295;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int BAD_DISPLAY = 12296;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int BAD_MATCH = 12297;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int BAD_NATIVE_PIXMAP = 12298;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int BAD_NATIVE_WINDOW = 12299;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int BAD_PARAMETER = 12300;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int BAD_SURFACE = 12301;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int BLUE_SIZE = 12322;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int BUFFER_SIZE = 12320;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int CONFIG_CAVEAT = 12327;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int CONFIG_ID = 12328;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int CORE_NATIVE_ENGINE = 12379;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int DEPTH_SIZE = 12325;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int DONT_CARE = -1;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int DRAW = 12377;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int EXTENSIONS = 12373;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int FALSE = 0;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int GREEN_SIZE = 12323;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int HEIGHT = 12374;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int LARGEST_PBUFFER = 12376;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int LEVEL = 12329;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int MAX_PBUFFER_HEIGHT = 12330;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int MAX_PBUFFER_PIXELS = 12331;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int MAX_PBUFFER_WIDTH = 12332;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int NATIVE_RENDERABLE = 12333;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int NATIVE_VISUAL_ID = 12334;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int NATIVE_VISUAL_TYPE = 12335;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int NONE = 12344;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int NON_CONFORMANT_CONFIG = 12369;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int NOT_INITIALIZED = 12289;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int NO_CONTEXT = 0;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int NO_DISPLAY = 0;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int NO_SURFACE = 0;

	[RequiredByFeature("EGL_VERSION_1_0")]
	[Log(BitmaskName = "EGLSurfaceTypeMask")]
	public const int PBUFFER_BIT = 1;

	[RequiredByFeature("EGL_VERSION_1_0")]
	[Log(BitmaskName = "EGLSurfaceTypeMask")]
	public const int PIXMAP_BIT = 2;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int READ = 12378;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int RED_SIZE = 12324;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int SAMPLES = 12337;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int SAMPLE_BUFFERS = 12338;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int SLOW_CONFIG = 12368;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int STENCIL_SIZE = 12326;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int SUCCESS = 12288;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int SURFACE_TYPE = 12339;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int TRANSPARENT_BLUE_VALUE = 12341;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int TRANSPARENT_GREEN_VALUE = 12342;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int TRANSPARENT_RED_VALUE = 12343;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int TRANSPARENT_RGB = 12370;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int TRANSPARENT_TYPE = 12340;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int TRUE = 1;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int VENDOR = 12371;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int VERSION = 12372;

	[RequiredByFeature("EGL_VERSION_1_0")]
	public const int WIDTH = 12375;

	[RequiredByFeature("EGL_VERSION_1_0")]
	[Log(BitmaskName = "EGLSurfaceTypeMask")]
	public const int WINDOW_BIT = 4;

	[RequiredByFeature("EGL_VERSION_1_1")]
	public const int BACK_BUFFER = 12420;

	[RequiredByFeature("EGL_VERSION_1_1")]
	public const int BIND_TO_TEXTURE_RGB = 12345;

	[RequiredByFeature("EGL_VERSION_1_1")]
	public const int BIND_TO_TEXTURE_RGBA = 12346;

	[RequiredByFeature("EGL_VERSION_1_1")]
	public const int CONTEXT_LOST = 12302;

	[RequiredByFeature("EGL_VERSION_1_1")]
	public const int MIN_SWAP_INTERVAL = 12347;

	[RequiredByFeature("EGL_VERSION_1_1")]
	public const int MAX_SWAP_INTERVAL = 12348;

	[RequiredByFeature("EGL_VERSION_1_1")]
	public const int MIPMAP_TEXTURE = 12418;

	[RequiredByFeature("EGL_VERSION_1_1")]
	public const int MIPMAP_LEVEL = 12419;

	[RequiredByFeature("EGL_VERSION_1_1")]
	public const int NO_TEXTURE = 12380;

	[RequiredByFeature("EGL_VERSION_1_1")]
	public const int TEXTURE_2D = 12383;

	[RequiredByFeature("EGL_VERSION_1_1")]
	public const int TEXTURE_FORMAT = 12416;

	[RequiredByFeature("EGL_VERSION_1_1")]
	public const int TEXTURE_RGB = 12381;

	[RequiredByFeature("EGL_VERSION_1_1")]
	public const int TEXTURE_RGBA = 12382;

	[RequiredByFeature("EGL_VERSION_1_1")]
	public const int TEXTURE_TARGET = 12417;

	[RequiredByFeature("EGL_VERSION_1_2")]
	public const int ALPHA_MASK_SIZE = 12350;

	[RequiredByFeature("EGL_VERSION_1_2")]
	public const int BUFFER_PRESERVED = 12436;

	[RequiredByFeature("EGL_VERSION_1_2")]
	public const int BUFFER_DESTROYED = 12437;

	[RequiredByFeature("EGL_VERSION_1_2")]
	public const int CLIENT_APIS = 12429;

	[RequiredByFeature("EGL_VERSION_1_2")]
	public const int COLORSPACE_sRGB = 12425;

	[RequiredByFeature("EGL_VERSION_1_2")]
	public const int COLORSPACE_LINEAR = 12426;

	[RequiredByFeature("EGL_VERSION_1_2")]
	public const int COLOR_BUFFER_TYPE = 12351;

	[RequiredByFeature("EGL_VERSION_1_2")]
	public const int CONTEXT_CLIENT_TYPE = 12439;

	[RequiredByFeature("EGL_VERSION_1_2")]
	public const int DISPLAY_SCALING = 10000;

	[RequiredByFeature("EGL_VERSION_1_2")]
	public const int HORIZONTAL_RESOLUTION = 12432;

	[RequiredByFeature("EGL_VERSION_1_2")]
	public const int LUMINANCE_BUFFER = 12431;

	[RequiredByFeature("EGL_VERSION_1_2")]
	public const int LUMINANCE_SIZE = 12349;

	[RequiredByFeature("EGL_VERSION_1_2")]
	[Log(BitmaskName = "EGLRenderableTypeMask")]
	public const int OPENGL_ES_BIT = 1;

	[RequiredByFeature("EGL_VERSION_1_2")]
	[Log(BitmaskName = "EGLRenderableTypeMask")]
	public const int OPENVG_BIT = 2;

	[RequiredByFeature("EGL_VERSION_1_2")]
	public const int OPENGL_ES_API = 12448;

	[RequiredByFeature("EGL_VERSION_1_2")]
	public const int OPENVG_API = 12449;

	[RequiredByFeature("EGL_VERSION_1_2")]
	public const int OPENVG_IMAGE = 12438;

	[RequiredByFeature("EGL_VERSION_1_2")]
	public const int PIXEL_ASPECT_RATIO = 12434;

	[RequiredByFeature("EGL_VERSION_1_2")]
	public const int RENDERABLE_TYPE = 12352;

	[RequiredByFeature("EGL_VERSION_1_2")]
	public const int RENDER_BUFFER = 12422;

	[RequiredByFeature("EGL_VERSION_1_2")]
	public const int RGB_BUFFER = 12430;

	[RequiredByFeature("EGL_VERSION_1_2")]
	public const int SINGLE_BUFFER = 12421;

	[RequiredByFeature("EGL_VERSION_1_2")]
	public const int SWAP_BEHAVIOR = 12435;

	[RequiredByFeature("EGL_VERSION_1_2")]
	public const int UNKNOWN = -1;

	[RequiredByFeature("EGL_VERSION_1_2")]
	public const int VERTICAL_RESOLUTION = 12433;

	[RequiredByFeature("EGL_VERSION_1_3")]
	[RequiredByFeature("EGL_KHR_config_attribs")]
	public const int CONFORMANT = 12354;

	[RequiredByFeature("EGL_VERSION_1_3")]
	public const int CONTEXT_CLIENT_VERSION = 12440;

	[RequiredByFeature("EGL_VERSION_1_3")]
	public const int MATCH_NATIVE_PIXMAP = 12353;

	[RequiredByFeature("EGL_VERSION_1_3")]
	[Log(BitmaskName = "EGLRenderableTypeMask")]
	public const int OPENGL_ES2_BIT = 4;

	[RequiredByFeature("EGL_VERSION_1_3")]
	public const int VG_ALPHA_FORMAT = 12424;

	[RequiredByFeature("EGL_VERSION_1_3")]
	public const int VG_ALPHA_FORMAT_NONPRE = 12427;

	[RequiredByFeature("EGL_VERSION_1_3")]
	public const int VG_ALPHA_FORMAT_PRE = 12428;

	[RequiredByFeature("EGL_VERSION_1_3")]
	[RequiredByFeature("EGL_KHR_config_attribs")]
	[Log(BitmaskName = "EGLSurfaceTypeMask")]
	public const int VG_ALPHA_FORMAT_PRE_BIT = 64;

	[RequiredByFeature("EGL_VERSION_1_3")]
	public const int VG_COLORSPACE = 12423;

	[RequiredByFeature("EGL_VERSION_1_3")]
	[RequiredByFeature("EGL_KHR_config_attribs")]
	[Log(BitmaskName = "EGLSurfaceTypeMask")]
	public const int VG_COLORSPACE_LINEAR_BIT = 32;

	[RequiredByFeature("EGL_VERSION_1_4")]
	public const int DEFAULT_DISPLAY = 0;

	[RequiredByFeature("EGL_VERSION_1_4")]
	[Log(BitmaskName = "EGLSurfaceTypeMask")]
	public const int MULTISAMPLE_RESOLVE_BOX_BIT = 512;

	[RequiredByFeature("EGL_VERSION_1_4")]
	public const int MULTISAMPLE_RESOLVE = 12441;

	[RequiredByFeature("EGL_VERSION_1_4")]
	public const int MULTISAMPLE_RESOLVE_DEFAULT = 12442;

	[RequiredByFeature("EGL_VERSION_1_4")]
	public const int MULTISAMPLE_RESOLVE_BOX = 12443;

	[RequiredByFeature("EGL_VERSION_1_4")]
	public const int OPENGL_API = 12450;

	[RequiredByFeature("EGL_VERSION_1_4")]
	[Log(BitmaskName = "EGLRenderableTypeMask")]
	public const int OPENGL_BIT = 8;

	[RequiredByFeature("EGL_VERSION_1_4")]
	[Log(BitmaskName = "EGLSurfaceTypeMask")]
	public const int SWAP_BEHAVIOR_PRESERVED_BIT = 1024;

	[RequiredByFeature("EGL_VERSION_1_5")]
	public const int CONTEXT_MINOR_VERSION = 12539;

	[RequiredByFeature("EGL_VERSION_1_5")]
	public const int CONTEXT_OPENGL_PROFILE_MASK = 12541;

	[RequiredByFeature("EGL_VERSION_1_5")]
	public const int CONTEXT_OPENGL_RESET_NOTIFICATION_STRATEGY = 12733;

	[RequiredByFeature("EGL_VERSION_1_5")]
	public const int NO_RESET_NOTIFICATION = 12734;

	[RequiredByFeature("EGL_VERSION_1_5")]
	public const int LOSE_CONTEXT_ON_RESET = 12735;

	[RequiredByFeature("EGL_VERSION_1_5")]
	[Log(BitmaskName = "EGLContextProfileMask")]
	public const uint CONTEXT_OPENGL_CORE_PROFILE_BIT = 1u;

	[RequiredByFeature("EGL_VERSION_1_5")]
	[Log(BitmaskName = "EGLContextProfileMask")]
	public const uint CONTEXT_OPENGL_COMPATIBILITY_PROFILE_BIT = 2u;

	[RequiredByFeature("EGL_VERSION_1_5")]
	public const int CONTEXT_OPENGL_DEBUG = 12720;

	[RequiredByFeature("EGL_VERSION_1_5")]
	public const int CONTEXT_OPENGL_FORWARD_COMPATIBLE = 12721;

	[RequiredByFeature("EGL_VERSION_1_5")]
	public const int CONTEXT_OPENGL_ROBUST_ACCESS = 12722;

	[RequiredByFeature("EGL_VERSION_1_5")]
	[RequiredByFeature("EGL_KHR_create_context")]
	[Log(BitmaskName = "EGLRenderableTypeMask")]
	public const uint OPENGL_ES3_BIT = 64u;

	[RequiredByFeature("EGL_VERSION_1_5")]
	public const int CL_EVENT_HANDLE = 12444;

	[RequiredByFeature("EGL_VERSION_1_5")]
	public const int SYNC_CL_EVENT = 12542;

	[RequiredByFeature("EGL_VERSION_1_5")]
	public const int SYNC_CL_EVENT_COMPLETE = 12543;

	[RequiredByFeature("EGL_VERSION_1_5")]
	public const int SYNC_PRIOR_COMMANDS_COMPLETE = 12528;

	[RequiredByFeature("EGL_VERSION_1_5")]
	public const int SYNC_TYPE = 12535;

	[RequiredByFeature("EGL_VERSION_1_5")]
	public const int SYNC_STATUS = 12529;

	[RequiredByFeature("EGL_VERSION_1_5")]
	public const int SYNC_CONDITION = 12536;

	[RequiredByFeature("EGL_VERSION_1_5")]
	public const int SIGNALED = 12530;

	[RequiredByFeature("EGL_VERSION_1_5")]
	public const int UNSIGNALED = 12531;

	[RequiredByFeature("EGL_VERSION_1_5")]
	[Log(BitmaskName = "EGLSyncFlagsKHR")]
	public const int SYNC_FLUSH_COMMANDS_BIT = 1;

	[RequiredByFeature("EGL_VERSION_1_5")]
	public const ulong FOREVER = 4503599627370495uL;

	[RequiredByFeature("EGL_VERSION_1_5")]
	public const int TIMEOUT_EXPIRED = 12533;

	[RequiredByFeature("EGL_VERSION_1_5")]
	public const int CONDITION_SATISFIED = 12534;

	[RequiredByFeature("EGL_VERSION_1_5")]
	public const int NO_SYNC = 0;

	[RequiredByFeature("EGL_VERSION_1_5")]
	public const int SYNC_FENCE = 12537;

	[RequiredByFeature("EGL_VERSION_1_5")]
	public const int GL_COLORSPACE = 12445;

	[RequiredByFeature("EGL_VERSION_1_5")]
	public const int GL_RENDERBUFFER = 12473;

	[RequiredByFeature("EGL_VERSION_1_5")]
	public const int GL_TEXTURE_2D = 12465;

	[RequiredByFeature("EGL_VERSION_1_5")]
	public const int GL_TEXTURE_LEVEL = 12476;

	[RequiredByFeature("EGL_VERSION_1_5")]
	public const int GL_TEXTURE_3D = 12466;

	[RequiredByFeature("EGL_VERSION_1_5")]
	public const int GL_TEXTURE_ZOFFSET = 12477;

	[RequiredByFeature("EGL_VERSION_1_5")]
	public const int GL_TEXTURE_CUBE_MAP_POSITIVE_X = 12467;

	[RequiredByFeature("EGL_VERSION_1_5")]
	public const int GL_TEXTURE_CUBE_MAP_NEGATIVE_X = 12468;

	[RequiredByFeature("EGL_VERSION_1_5")]
	public const int GL_TEXTURE_CUBE_MAP_POSITIVE_Y = 12469;

	[RequiredByFeature("EGL_VERSION_1_5")]
	public const int GL_TEXTURE_CUBE_MAP_NEGATIVE_Y = 12470;

	[RequiredByFeature("EGL_VERSION_1_5")]
	public const int GL_TEXTURE_CUBE_MAP_POSITIVE_Z = 12471;

	[RequiredByFeature("EGL_VERSION_1_5")]
	public const int GL_TEXTURE_CUBE_MAP_NEGATIVE_Z = 12472;

	[RequiredByFeature("EGL_VERSION_1_5")]
	[RequiredByFeature("EGL_KHR_image_base")]
	public const int IMAGE_PRESERVED = 12498;

	[RequiredByFeature("EGL_VERSION_1_5")]
	public const int NO_IMAGE = 0;

	[RequiredByFeature("EGL_EXT_create_context_robustness")]
	public const int CONTEXT_OPENGL_ROBUST_ACCESS_EXT = 12479;

	[RequiredByFeature("EGL_EXT_create_context_robustness")]
	public const int CONTEXT_OPENGL_RESET_NOTIFICATION_STRATEGY_EXT = 12600;

	[RequiredByFeature("EGL_EXT_device_drm")]
	public const int DRM_DEVICE_FILE_EXT = 12851;

	[RequiredByFeature("EGL_EXT_device_openwf")]
	public const int OPENWF_DEVICE_ID_EXT = 12855;

	[RequiredByFeature("EGL_EXT_device_base")]
	[RequiredByFeature("EGL_EXT_device_query")]
	public const int NO_DEVICE_EXT = 0;

	[RequiredByFeature("EGL_EXT_device_base")]
	[RequiredByFeature("EGL_EXT_device_query")]
	public const int BAD_DEVICE_EXT = 12843;

	[RequiredByFeature("EGL_EXT_device_base")]
	[RequiredByFeature("EGL_EXT_device_query")]
	public const int DEVICE_EXT = 12844;

	[RequiredByFeature("EGL_EXT_gl_colorspace_bt2020_linear")]
	public const int GL_COLORSPACE_BT2020_LINEAR_EXT = 13119;

	[RequiredByFeature("EGL_EXT_gl_colorspace_bt2020_pq")]
	public const int GL_COLORSPACE_BT2020_PQ_EXT = 13120;

	[RequiredByFeature("EGL_EXT_gl_colorspace_scrgb_linear")]
	public const int GL_COLORSPACE_SCRGB_LINEAR_EXT = 13136;

	[RequiredByFeature("EGL_EXT_image_dma_buf_import")]
	public const int LINUX_DMA_BUF_EXT = 12912;

	[RequiredByFeature("EGL_EXT_image_dma_buf_import")]
	public const int LINUX_DRM_FOURCC_EXT = 12913;

	[RequiredByFeature("EGL_EXT_image_dma_buf_import")]
	public const int DMA_BUF_PLANE0_FD_EXT = 12914;

	[RequiredByFeature("EGL_EXT_image_dma_buf_import")]
	public const int DMA_BUF_PLANE0_OFFSET_EXT = 12915;

	[RequiredByFeature("EGL_EXT_image_dma_buf_import")]
	public const int DMA_BUF_PLANE0_PITCH_EXT = 12916;

	[RequiredByFeature("EGL_EXT_image_dma_buf_import")]
	public const int DMA_BUF_PLANE1_FD_EXT = 12917;

	[RequiredByFeature("EGL_EXT_image_dma_buf_import")]
	public const int DMA_BUF_PLANE1_OFFSET_EXT = 12918;

	[RequiredByFeature("EGL_EXT_image_dma_buf_import")]
	public const int DMA_BUF_PLANE1_PITCH_EXT = 12919;

	[RequiredByFeature("EGL_EXT_image_dma_buf_import")]
	public const int DMA_BUF_PLANE2_FD_EXT = 12920;

	[RequiredByFeature("EGL_EXT_image_dma_buf_import")]
	public const int DMA_BUF_PLANE2_OFFSET_EXT = 12921;

	[RequiredByFeature("EGL_EXT_image_dma_buf_import")]
	public const int DMA_BUF_PLANE2_PITCH_EXT = 12922;

	[RequiredByFeature("EGL_EXT_image_dma_buf_import")]
	public const int YUV_COLOR_SPACE_HINT_EXT = 12923;

	[RequiredByFeature("EGL_EXT_image_dma_buf_import")]
	public const int SAMPLE_RANGE_HINT_EXT = 12924;

	[RequiredByFeature("EGL_EXT_image_dma_buf_import")]
	public const int YUV_CHROMA_HORIZONTAL_SITING_HINT_EXT = 12925;

	[RequiredByFeature("EGL_EXT_image_dma_buf_import")]
	public const int YUV_CHROMA_VERTICAL_SITING_HINT_EXT = 12926;

	[RequiredByFeature("EGL_EXT_image_dma_buf_import")]
	public const int ITU_REC601_EXT = 12927;

	[RequiredByFeature("EGL_EXT_image_dma_buf_import")]
	public const int ITU_REC709_EXT = 12928;

	[RequiredByFeature("EGL_EXT_image_dma_buf_import")]
	public const int ITU_REC2020_EXT = 12929;

	[RequiredByFeature("EGL_EXT_image_dma_buf_import")]
	public const int YUV_FULL_RANGE_EXT = 12930;

	[RequiredByFeature("EGL_EXT_image_dma_buf_import")]
	public const int YUV_NARROW_RANGE_EXT = 12931;

	[RequiredByFeature("EGL_EXT_image_dma_buf_import")]
	public const int YUV_CHROMA_SITING_0_EXT = 12932;

	[RequiredByFeature("EGL_EXT_image_dma_buf_import")]
	public const int YUV_CHROMA_SITING_0_5_EXT = 12933;

	[RequiredByFeature("EGL_EXT_image_dma_buf_import_modifiers")]
	public const int DMA_BUF_PLANE3_FD_EXT = 13376;

	[RequiredByFeature("EGL_EXT_image_dma_buf_import_modifiers")]
	public const int DMA_BUF_PLANE3_OFFSET_EXT = 13377;

	[RequiredByFeature("EGL_EXT_image_dma_buf_import_modifiers")]
	public const int DMA_BUF_PLANE3_PITCH_EXT = 13378;

	[RequiredByFeature("EGL_EXT_image_dma_buf_import_modifiers")]
	public const int DMA_BUF_PLANE0_MODIFIER_LO_EXT = 13379;

	[RequiredByFeature("EGL_EXT_image_dma_buf_import_modifiers")]
	public const int DMA_BUF_PLANE0_MODIFIER_HI_EXT = 13380;

	[RequiredByFeature("EGL_EXT_image_dma_buf_import_modifiers")]
	public const int DMA_BUF_PLANE1_MODIFIER_LO_EXT = 13381;

	[RequiredByFeature("EGL_EXT_image_dma_buf_import_modifiers")]
	public const int DMA_BUF_PLANE1_MODIFIER_HI_EXT = 13382;

	[RequiredByFeature("EGL_EXT_image_dma_buf_import_modifiers")]
	public const int DMA_BUF_PLANE2_MODIFIER_LO_EXT = 13383;

	[RequiredByFeature("EGL_EXT_image_dma_buf_import_modifiers")]
	public const int DMA_BUF_PLANE2_MODIFIER_HI_EXT = 13384;

	[RequiredByFeature("EGL_EXT_image_dma_buf_import_modifiers")]
	public const int DMA_BUF_PLANE3_MODIFIER_LO_EXT = 13385;

	[RequiredByFeature("EGL_EXT_image_dma_buf_import_modifiers")]
	public const int DMA_BUF_PLANE3_MODIFIER_HI_EXT = 13386;

	[RequiredByFeature("EGL_EXT_multiview_window")]
	public const int MULTIVIEW_VIEW_COUNT_EXT = 12596;

	[RequiredByFeature("EGL_EXT_output_base")]
	public const int NO_OUTPUT_LAYER_EXT = 0;

	[RequiredByFeature("EGL_EXT_output_base")]
	public const int NO_OUTPUT_PORT_EXT = 0;

	[RequiredByFeature("EGL_EXT_output_base")]
	public const int BAD_OUTPUT_LAYER_EXT = 12845;

	[RequiredByFeature("EGL_EXT_output_base")]
	public const int BAD_OUTPUT_PORT_EXT = 12846;

	[RequiredByFeature("EGL_EXT_output_base")]
	public const int SWAP_INTERVAL_EXT = 12847;

	[RequiredByFeature("EGL_EXT_output_drm")]
	public const int DRM_CRTC_EXT = 12852;

	[RequiredByFeature("EGL_EXT_output_drm")]
	public const int DRM_PLANE_EXT = 12853;

	[RequiredByFeature("EGL_EXT_output_drm")]
	public const int DRM_CONNECTOR_EXT = 12854;

	[RequiredByFeature("EGL_EXT_output_openwf")]
	public const int OPENWF_PIPELINE_ID_EXT = 12856;

	[RequiredByFeature("EGL_EXT_output_openwf")]
	public const int OPENWF_PORT_ID_EXT = 12857;

	[RequiredByFeature("EGL_EXT_pixel_format_float")]
	public const int COLOR_COMPONENT_TYPE_EXT = 13113;

	[RequiredByFeature("EGL_EXT_pixel_format_float")]
	public const int COLOR_COMPONENT_TYPE_FIXED_EXT = 13114;

	[RequiredByFeature("EGL_EXT_pixel_format_float")]
	public const int COLOR_COMPONENT_TYPE_FLOAT_EXT = 13115;

	[RequiredByFeature("EGL_EXT_platform_device")]
	public const int PLATFORM_DEVICE_EXT = 12607;

	[RequiredByFeature("EGL_EXT_protected_content")]
	[RequiredByFeature("EGL_EXT_protected_surface")]
	public const int PROTECTED_CONTENT_EXT = 12992;

	[RequiredByFeature("EGL_EXT_surface_SMPTE2086_metadata")]
	public const int SMPTE2086_DISPLAY_PRIMARY_RX_EXT = 13121;

	[RequiredByFeature("EGL_EXT_surface_SMPTE2086_metadata")]
	public const int SMPTE2086_DISPLAY_PRIMARY_RY_EXT = 13122;

	[RequiredByFeature("EGL_EXT_surface_SMPTE2086_metadata")]
	public const int SMPTE2086_DISPLAY_PRIMARY_GX_EXT = 13123;

	[RequiredByFeature("EGL_EXT_surface_SMPTE2086_metadata")]
	public const int SMPTE2086_DISPLAY_PRIMARY_GY_EXT = 13124;

	[RequiredByFeature("EGL_EXT_surface_SMPTE2086_metadata")]
	public const int SMPTE2086_DISPLAY_PRIMARY_BX_EXT = 13125;

	[RequiredByFeature("EGL_EXT_surface_SMPTE2086_metadata")]
	public const int SMPTE2086_DISPLAY_PRIMARY_BY_EXT = 13126;

	[RequiredByFeature("EGL_EXT_surface_SMPTE2086_metadata")]
	public const int SMPTE2086_WHITE_POINT_X_EXT = 13127;

	[RequiredByFeature("EGL_EXT_surface_SMPTE2086_metadata")]
	public const int SMPTE2086_WHITE_POINT_Y_EXT = 13128;

	[RequiredByFeature("EGL_EXT_surface_SMPTE2086_metadata")]
	public const int SMPTE2086_MAX_LUMINANCE_EXT = 13129;

	[RequiredByFeature("EGL_EXT_surface_SMPTE2086_metadata")]
	public const int SMPTE2086_MIN_LUMINANCE_EXT = 13130;

	[RequiredByFeature("EGL_EXT_yuv_surface")]
	public const int YUV_ORDER_EXT = 13057;

	[RequiredByFeature("EGL_EXT_yuv_surface")]
	[RequiredByFeature("EGL_NV_stream_consumer_gltexture_yuv")]
	public const int YUV_NUMBER_OF_PLANES_EXT = 13073;

	[RequiredByFeature("EGL_EXT_yuv_surface")]
	public const int YUV_SUBSAMPLE_EXT = 13074;

	[RequiredByFeature("EGL_EXT_yuv_surface")]
	public const int YUV_DEPTH_RANGE_EXT = 13079;

	[RequiredByFeature("EGL_EXT_yuv_surface")]
	public const int YUV_CSC_STANDARD_EXT = 13066;

	[RequiredByFeature("EGL_EXT_yuv_surface")]
	public const int YUV_PLANE_BPP_EXT = 13082;

	[RequiredByFeature("EGL_EXT_yuv_surface")]
	[RequiredByFeature("EGL_NV_stream_consumer_gltexture_yuv")]
	public const int YUV_BUFFER_EXT = 13056;

	[RequiredByFeature("EGL_EXT_yuv_surface")]
	public const int YUV_ORDER_YUV_EXT = 13058;

	[RequiredByFeature("EGL_EXT_yuv_surface")]
	public const int YUV_ORDER_YVU_EXT = 13059;

	[RequiredByFeature("EGL_EXT_yuv_surface")]
	public const int YUV_ORDER_YUYV_EXT = 13060;

	[RequiredByFeature("EGL_EXT_yuv_surface")]
	public const int YUV_ORDER_UYVY_EXT = 13061;

	[RequiredByFeature("EGL_EXT_yuv_surface")]
	public const int YUV_ORDER_YVYU_EXT = 13062;

	[RequiredByFeature("EGL_EXT_yuv_surface")]
	public const int YUV_ORDER_VYUY_EXT = 13063;

	[RequiredByFeature("EGL_EXT_yuv_surface")]
	public const int YUV_ORDER_AYUV_EXT = 13064;

	[RequiredByFeature("EGL_EXT_yuv_surface")]
	public const int YUV_SUBSAMPLE_4_2_0_EXT = 13075;

	[RequiredByFeature("EGL_EXT_yuv_surface")]
	public const int YUV_SUBSAMPLE_4_2_2_EXT = 13076;

	[RequiredByFeature("EGL_EXT_yuv_surface")]
	public const int YUV_SUBSAMPLE_4_4_4_EXT = 13077;

	[RequiredByFeature("EGL_EXT_yuv_surface")]
	public const int YUV_DEPTH_RANGE_LIMITED_EXT = 13080;

	[RequiredByFeature("EGL_EXT_yuv_surface")]
	public const int YUV_DEPTH_RANGE_FULL_EXT = 13081;

	[RequiredByFeature("EGL_EXT_yuv_surface")]
	public const int YUV_CSC_STANDARD_601_EXT = 13067;

	[RequiredByFeature("EGL_EXT_yuv_surface")]
	public const int YUV_CSC_STANDARD_709_EXT = 13068;

	[RequiredByFeature("EGL_EXT_yuv_surface")]
	public const int YUV_CSC_STANDARD_2020_EXT = 13069;

	[RequiredByFeature("EGL_EXT_yuv_surface")]
	public const int YUV_PLANE_BPP_0_EXT = 13083;

	[RequiredByFeature("EGL_EXT_yuv_surface")]
	public const int YUV_PLANE_BPP_8_EXT = 13084;

	[RequiredByFeature("EGL_EXT_yuv_surface")]
	public const int YUV_PLANE_BPP_10_EXT = 13085;

	[RequiredByFeature("EGL_HI_clientpixmap")]
	public const int CLIENT_PIXMAP_POINTER_HI = 36724;

	[RequiredByFeature("EGL_HI_colorformats")]
	public const int COLOR_FORMAT_HI = 36720;

	[RequiredByFeature("EGL_HI_colorformats")]
	public const int COLOR_RGB_HI = 36721;

	[RequiredByFeature("EGL_HI_colorformats")]
	public const int COLOR_RGBA_HI = 36722;

	[RequiredByFeature("EGL_HI_colorformats")]
	public const int COLOR_ARGB_HI = 36723;

	[RequiredByFeature("EGL_IMG_context_priority")]
	public const int CONTEXT_PRIORITY_LEVEL_IMG = 12544;

	[RequiredByFeature("EGL_IMG_context_priority")]
	public const int CONTEXT_PRIORITY_HIGH_IMG = 12545;

	[RequiredByFeature("EGL_IMG_context_priority")]
	public const int CONTEXT_PRIORITY_MEDIUM_IMG = 12546;

	[RequiredByFeature("EGL_IMG_context_priority")]
	public const int CONTEXT_PRIORITY_LOW_IMG = 12547;

	[RequiredByFeature("EGL_IMG_image_plane_attribs")]
	public const int NATIVE_BUFFER_MULTIPLANE_SEPARATE_IMG = 12549;

	[RequiredByFeature("EGL_IMG_image_plane_attribs")]
	public const int NATIVE_BUFFER_PLANE_OFFSET_IMG = 12550;

	[RequiredByFeature("EGL_KHR_context_flush_control")]
	public const int CONTEXT_RELEASE_BEHAVIOR_NONE_KHR = 0;

	[RequiredByFeature("EGL_KHR_context_flush_control")]
	public const int CONTEXT_RELEASE_BEHAVIOR_KHR = 8343;

	[RequiredByFeature("EGL_KHR_context_flush_control")]
	public const int CONTEXT_RELEASE_BEHAVIOR_FLUSH_KHR = 8344;

	[RequiredByFeature("EGL_KHR_create_context")]
	public const int CONTEXT_FLAGS_KHR = 12540;

	[RequiredByFeature("EGL_KHR_create_context")]
	[Log(BitmaskName = "EGLContextFlagMask")]
	public const uint CONTEXT_OPENGL_DEBUG_BIT_KHR = 1u;

	[RequiredByFeature("EGL_KHR_create_context")]
	[Log(BitmaskName = "EGLContextFlagMask")]
	public const uint CONTEXT_OPENGL_FORWARD_COMPATIBLE_BIT_KHR = 2u;

	[RequiredByFeature("EGL_KHR_create_context")]
	[Log(BitmaskName = "EGLContextFlagMask")]
	public const uint CONTEXT_OPENGL_ROBUST_ACCESS_BIT_KHR = 4u;

	[RequiredByFeature("EGL_KHR_create_context_no_error")]
	public const int CONTEXT_OPENGL_NO_ERROR_KHR = 12723;

	[RequiredByFeature("EGL_KHR_debug")]
	public const int OBJECT_THREAD_KHR = 13232;

	[RequiredByFeature("EGL_KHR_debug")]
	public const int OBJECT_DISPLAY_KHR = 13233;

	[RequiredByFeature("EGL_KHR_debug")]
	public const int OBJECT_CONTEXT_KHR = 13234;

	[RequiredByFeature("EGL_KHR_debug")]
	public const int OBJECT_SURFACE_KHR = 13235;

	[RequiredByFeature("EGL_KHR_debug")]
	public const int OBJECT_IMAGE_KHR = 13236;

	[RequiredByFeature("EGL_KHR_debug")]
	public const int OBJECT_SYNC_KHR = 13237;

	[RequiredByFeature("EGL_KHR_debug")]
	public const int OBJECT_STREAM_KHR = 13238;

	[RequiredByFeature("EGL_KHR_debug")]
	public const int DEBUG_MSG_CRITICAL_KHR = 13241;

	[RequiredByFeature("EGL_KHR_debug")]
	public const int DEBUG_MSG_ERROR_KHR = 13242;

	[RequiredByFeature("EGL_KHR_debug")]
	public const int DEBUG_MSG_WARN_KHR = 13243;

	[RequiredByFeature("EGL_KHR_debug")]
	public const int DEBUG_MSG_INFO_KHR = 13244;

	[RequiredByFeature("EGL_KHR_debug")]
	public const int DEBUG_CALLBACK_KHR = 13240;

	[RequiredByFeature("EGL_KHR_image")]
	[RequiredByFeature("EGL_KHR_image_base")]
	public const int NO_IMAGE_KHR = 0;

	[RequiredByFeature("EGL_KHR_image")]
	[RequiredByFeature("EGL_KHR_image_pixmap")]
	public const int NATIVE_PIXMAP_KHR = 12464;

	[RequiredByFeature("EGL_KHR_lock_surface")]
	[RequiredByFeature("EGL_KHR_lock_surface3")]
	[Log(BitmaskName = "EGLLockUsageHintKHRMask")]
	public const int READ_SURFACE_BIT_KHR = 1;

	[RequiredByFeature("EGL_KHR_lock_surface")]
	[RequiredByFeature("EGL_KHR_lock_surface3")]
	[Log(BitmaskName = "EGLLockUsageHintKHRMask")]
	public const int WRITE_SURFACE_BIT_KHR = 2;

	[RequiredByFeature("EGL_KHR_lock_surface")]
	[RequiredByFeature("EGL_KHR_lock_surface3")]
	[Log(BitmaskName = "EGLSurfaceTypeMask")]
	public const int LOCK_SURFACE_BIT_KHR = 128;

	[RequiredByFeature("EGL_KHR_lock_surface")]
	[RequiredByFeature("EGL_KHR_lock_surface3")]
	[Log(BitmaskName = "EGLSurfaceTypeMask")]
	public const int OPTIMAL_FORMAT_BIT_KHR = 256;

	[RequiredByFeature("EGL_KHR_lock_surface")]
	[RequiredByFeature("EGL_KHR_lock_surface3")]
	public const int MATCH_FORMAT_KHR = 12355;

	[RequiredByFeature("EGL_KHR_lock_surface")]
	[RequiredByFeature("EGL_KHR_lock_surface3")]
	public const int FORMAT_RGB_565_EXACT_KHR = 12480;

	[RequiredByFeature("EGL_KHR_lock_surface")]
	[RequiredByFeature("EGL_KHR_lock_surface3")]
	public const int FORMAT_RGB_565_KHR = 12481;

	[RequiredByFeature("EGL_KHR_lock_surface")]
	[RequiredByFeature("EGL_KHR_lock_surface3")]
	public const int FORMAT_RGBA_8888_EXACT_KHR = 12482;

	[RequiredByFeature("EGL_KHR_lock_surface")]
	[RequiredByFeature("EGL_KHR_lock_surface3")]
	public const int FORMAT_RGBA_8888_KHR = 12483;

	[RequiredByFeature("EGL_KHR_lock_surface")]
	[RequiredByFeature("EGL_KHR_lock_surface3")]
	public const int MAP_PRESERVE_PIXELS_KHR = 12484;

	[RequiredByFeature("EGL_KHR_lock_surface")]
	[RequiredByFeature("EGL_KHR_lock_surface3")]
	public const int LOCK_USAGE_HINT_KHR = 12485;

	[RequiredByFeature("EGL_KHR_lock_surface")]
	[RequiredByFeature("EGL_KHR_lock_surface3")]
	public const int BITMAP_PITCH_KHR = 12487;

	[RequiredByFeature("EGL_KHR_lock_surface")]
	[RequiredByFeature("EGL_KHR_lock_surface3")]
	public const int BITMAP_ORIGIN_KHR = 12488;

	[RequiredByFeature("EGL_KHR_lock_surface")]
	[RequiredByFeature("EGL_KHR_lock_surface3")]
	public const int BITMAP_PIXEL_RED_OFFSET_KHR = 12489;

	[RequiredByFeature("EGL_KHR_lock_surface")]
	[RequiredByFeature("EGL_KHR_lock_surface3")]
	public const int BITMAP_PIXEL_GREEN_OFFSET_KHR = 12490;

	[RequiredByFeature("EGL_KHR_lock_surface")]
	[RequiredByFeature("EGL_KHR_lock_surface3")]
	public const int BITMAP_PIXEL_BLUE_OFFSET_KHR = 12491;

	[RequiredByFeature("EGL_KHR_lock_surface")]
	[RequiredByFeature("EGL_KHR_lock_surface3")]
	public const int BITMAP_PIXEL_ALPHA_OFFSET_KHR = 12492;

	[RequiredByFeature("EGL_KHR_lock_surface")]
	[RequiredByFeature("EGL_KHR_lock_surface3")]
	public const int BITMAP_PIXEL_LUMINANCE_OFFSET_KHR = 12493;

	[RequiredByFeature("EGL_KHR_lock_surface2")]
	[RequiredByFeature("EGL_KHR_lock_surface3")]
	public const int BITMAP_PIXEL_SIZE_KHR = 12560;

	[RequiredByFeature("EGL_KHR_lock_surface")]
	[RequiredByFeature("EGL_KHR_lock_surface3")]
	public const int BITMAP_POINTER_KHR = 12486;

	[RequiredByFeature("EGL_KHR_lock_surface")]
	[RequiredByFeature("EGL_KHR_lock_surface3")]
	public const int LOWER_LEFT_KHR = 12494;

	[RequiredByFeature("EGL_KHR_lock_surface")]
	[RequiredByFeature("EGL_KHR_lock_surface3")]
	public const int UPPER_LEFT_KHR = 12495;

	[RequiredByFeature("EGL_KHR_mutable_render_buffer")]
	[Log(BitmaskName = "EGLSurfaceTypeMask")]
	public const int MUTABLE_RENDER_BUFFER_BIT_KHR = 4096;

	[RequiredByFeature("EGL_KHR_no_config_context")]
	public const int NO_CONFIG_KHR = 0;

	[RequiredByFeature("EGL_KHR_platform_android")]
	public const int PLATFORM_ANDROID_KHR = 12609;

	[RequiredByFeature("EGL_KHR_platform_gbm")]
	public const int PLATFORM_GBM_KHR = 12759;

	[RequiredByFeature("EGL_KHR_reusable_sync")]
	public const int SYNC_REUSABLE_KHR = 12538;

	[RequiredByFeature("EGL_KHR_stream")]
	public const int NO_STREAM_KHR = 0;

	[RequiredByFeature("EGL_KHR_stream")]
	public const int PRODUCER_FRAME_KHR = 12818;

	[RequiredByFeature("EGL_KHR_stream")]
	public const int CONSUMER_FRAME_KHR = 12819;

	[RequiredByFeature("EGL_KHR_stream")]
	public const int STREAM_STATE_EMPTY_KHR = 12823;

	[RequiredByFeature("EGL_KHR_stream")]
	public const int STREAM_STATE_NEW_FRAME_AVAILABLE_KHR = 12824;

	[RequiredByFeature("EGL_KHR_stream")]
	public const int STREAM_STATE_OLD_FRAME_AVAILABLE_KHR = 12825;

	[RequiredByFeature("EGL_KHR_stream")]
	public const int STREAM_STATE_DISCONNECTED_KHR = 12826;

	[RequiredByFeature("EGL_KHR_stream")]
	public const int BAD_STREAM_KHR = 12827;

	[RequiredByFeature("EGL_KHR_stream")]
	public const int BAD_STATE_KHR = 12828;

	[RequiredByFeature("EGL_KHR_stream")]
	[RequiredByFeature("EGL_KHR_stream_attrib")]
	public const int CONSUMER_LATENCY_USEC_KHR = 12816;

	[RequiredByFeature("EGL_KHR_stream")]
	[RequiredByFeature("EGL_KHR_stream_attrib")]
	public const int STREAM_STATE_KHR = 12820;

	[RequiredByFeature("EGL_KHR_stream")]
	[RequiredByFeature("EGL_KHR_stream_attrib")]
	public const int STREAM_STATE_CREATED_KHR = 12821;

	[RequiredByFeature("EGL_KHR_stream")]
	[RequiredByFeature("EGL_KHR_stream_attrib")]
	public const int STREAM_STATE_CONNECTING_KHR = 12822;

	[RequiredByFeature("EGL_KHR_stream_consumer_gltexture")]
	public const int CONSUMER_ACQUIRE_TIMEOUT_USEC_KHR = 12830;

	[RequiredByFeature("EGL_KHR_stream_cross_process_fd")]
	public const int NO_FILE_DESCRIPTOR_KHR = -1;

	[RequiredByFeature("EGL_KHR_stream_fifo")]
	public const int STREAM_FIFO_LENGTH_KHR = 12796;

	[RequiredByFeature("EGL_KHR_stream_fifo")]
	public const int STREAM_TIME_NOW_KHR = 12797;

	[RequiredByFeature("EGL_KHR_stream_fifo")]
	public const int STREAM_TIME_CONSUMER_KHR = 12798;

	[RequiredByFeature("EGL_KHR_stream_fifo")]
	public const int STREAM_TIME_PRODUCER_KHR = 12799;

	[RequiredByFeature("EGL_KHR_stream_producer_eglsurface")]
	[Log(BitmaskName = "EGLSurfaceTypeMask")]
	public const int STREAM_BIT_KHR = 2048;

	[RequiredByFeature("EGL_KHR_vg_parent_image")]
	public const int VG_PARENT_IMAGE_KHR = 12474;

	[RequiredByFeature("EGL_MESA_drm_image")]
	public const int DRM_BUFFER_FORMAT_MESA = 12752;

	[RequiredByFeature("EGL_MESA_drm_image")]
	public const int DRM_BUFFER_USE_MESA = 12753;

	[RequiredByFeature("EGL_MESA_drm_image")]
	public const int DRM_BUFFER_FORMAT_ARGB32_MESA = 12754;

	[RequiredByFeature("EGL_MESA_drm_image")]
	public const int DRM_BUFFER_MESA = 12755;

	[RequiredByFeature("EGL_MESA_drm_image")]
	public const int DRM_BUFFER_STRIDE_MESA = 12756;

	[RequiredByFeature("EGL_MESA_drm_image")]
	[Log(BitmaskName = "EGLDRMBufferUseMESAMask")]
	public const int DRM_BUFFER_USE_SCANOUT_MESA = 1;

	[RequiredByFeature("EGL_MESA_drm_image")]
	[Log(BitmaskName = "EGLDRMBufferUseMESAMask")]
	public const int DRM_BUFFER_USE_SHARE_MESA = 2;

	[RequiredByFeature("EGL_MESA_platform_surfaceless")]
	public const int PLATFORM_SURFACELESS_MESA = 12765;

	[RequiredByFeature("EGL_NOK_texture_from_pixmap")]
	public const int Y_INVERTED_NOK = 12415;

	[RequiredByFeature("EGL_NV_3dvision_surface")]
	public const int AUTO_STEREO_NV = 12598;

	[RequiredByFeature("EGL_NV_coverage_sample")]
	public const int COVERAGE_BUFFERS_NV = 12512;

	[RequiredByFeature("EGL_NV_coverage_sample")]
	public const int COVERAGE_SAMPLES_NV = 12513;

	[RequiredByFeature("EGL_NV_coverage_sample_resolve")]
	public const int COVERAGE_SAMPLE_RESOLVE_NV = 12593;

	[RequiredByFeature("EGL_NV_coverage_sample_resolve")]
	public const int COVERAGE_SAMPLE_RESOLVE_DEFAULT_NV = 12594;

	[RequiredByFeature("EGL_NV_coverage_sample_resolve")]
	public const int COVERAGE_SAMPLE_RESOLVE_NONE_NV = 12595;

	[RequiredByFeature("EGL_NV_cuda_event")]
	public const int CUDA_EVENT_HANDLE_NV = 12859;

	[RequiredByFeature("EGL_NV_cuda_event")]
	public const int SYNC_CUDA_EVENT_NV = 12860;

	[RequiredByFeature("EGL_NV_cuda_event")]
	public const int SYNC_CUDA_EVENT_COMPLETE_NV = 12861;

	[RequiredByFeature("EGL_NV_depth_nonlinear")]
	public const int DEPTH_ENCODING_NV = 12514;

	[RequiredByFeature("EGL_NV_depth_nonlinear")]
	public const int DEPTH_ENCODING_NONE_NV = 0;

	[RequiredByFeature("EGL_NV_depth_nonlinear")]
	public const int DEPTH_ENCODING_NONLINEAR_NV = 12515;

	[RequiredByFeature("EGL_NV_device_cuda")]
	public const int CUDA_DEVICE_NV = 12858;

	[RequiredByFeature("EGL_NV_post_sub_buffer")]
	public const int POST_SUB_BUFFER_SUPPORTED_NV = 12478;

	[RequiredByFeature("EGL_NV_robustness_video_memory_purge")]
	public const int GENERATE_RESET_ON_VIDEO_MEMORY_PURGE_NV = 13132;

	[RequiredByFeature("EGL_NV_stream_consumer_gltexture_yuv")]
	public const int YUV_PLANE0_TEXTURE_UNIT_NV = 13100;

	[RequiredByFeature("EGL_NV_stream_consumer_gltexture_yuv")]
	public const int YUV_PLANE1_TEXTURE_UNIT_NV = 13101;

	[RequiredByFeature("EGL_NV_stream_consumer_gltexture_yuv")]
	public const int YUV_PLANE2_TEXTURE_UNIT_NV = 13102;

	[RequiredByFeature("EGL_NV_stream_cross_display")]
	public const int STREAM_CROSS_DISPLAY_NV = 13134;

	[RequiredByFeature("EGL_NV_stream_cross_object")]
	public const int STREAM_CROSS_OBJECT_NV = 13133;

	[RequiredByFeature("EGL_NV_stream_cross_partition")]
	public const int STREAM_CROSS_PARTITION_NV = 12863;

	[RequiredByFeature("EGL_NV_stream_cross_process")]
	public const int STREAM_CROSS_PROCESS_NV = 12869;

	[RequiredByFeature("EGL_NV_stream_cross_system")]
	public const int STREAM_CROSS_SYSTEM_NV = 13135;

	[RequiredByFeature("EGL_NV_stream_fifo_next")]
	public const int PENDING_FRAME_NV = 13097;

	[RequiredByFeature("EGL_NV_stream_fifo_next")]
	public const int STREAM_TIME_PENDING_NV = 13098;

	[RequiredByFeature("EGL_NV_stream_fifo_synchronous")]
	public const int STREAM_FIFO_SYNCHRONOUS_NV = 13110;

	[RequiredByFeature("EGL_NV_stream_frame_limits")]
	public const int PRODUCER_MAX_FRAME_HINT_NV = 13111;

	[RequiredByFeature("EGL_NV_stream_frame_limits")]
	public const int CONSUMER_MAX_FRAME_HINT_NV = 13112;

	[RequiredByFeature("EGL_NV_stream_metadata")]
	public const int MAX_STREAM_METADATA_BLOCKS_NV = 12880;

	[RequiredByFeature("EGL_NV_stream_metadata")]
	public const int MAX_STREAM_METADATA_BLOCK_SIZE_NV = 12881;

	[RequiredByFeature("EGL_NV_stream_metadata")]
	public const int MAX_STREAM_METADATA_TOTAL_SIZE_NV = 12882;

	[RequiredByFeature("EGL_NV_stream_metadata")]
	public const int PRODUCER_METADATA_NV = 12883;

	[RequiredByFeature("EGL_NV_stream_metadata")]
	public const int CONSUMER_METADATA_NV = 12884;

	[RequiredByFeature("EGL_NV_stream_metadata")]
	public const int PENDING_METADATA_NV = 13096;

	[RequiredByFeature("EGL_NV_stream_metadata")]
	public const int METADATA0_SIZE_NV = 12885;

	[RequiredByFeature("EGL_NV_stream_metadata")]
	public const int METADATA1_SIZE_NV = 12886;

	[RequiredByFeature("EGL_NV_stream_metadata")]
	public const int METADATA2_SIZE_NV = 12887;

	[RequiredByFeature("EGL_NV_stream_metadata")]
	public const int METADATA3_SIZE_NV = 12888;

	[RequiredByFeature("EGL_NV_stream_metadata")]
	public const int METADATA0_TYPE_NV = 12889;

	[RequiredByFeature("EGL_NV_stream_metadata")]
	public const int METADATA1_TYPE_NV = 12890;

	[RequiredByFeature("EGL_NV_stream_metadata")]
	public const int METADATA2_TYPE_NV = 12891;

	[RequiredByFeature("EGL_NV_stream_metadata")]
	public const int METADATA3_TYPE_NV = 12892;

	[RequiredByFeature("EGL_NV_stream_remote")]
	public const int STREAM_STATE_INITIALIZING_NV = 12864;

	[RequiredByFeature("EGL_NV_stream_remote")]
	public const int STREAM_TYPE_NV = 12865;

	[RequiredByFeature("EGL_NV_stream_remote")]
	public const int STREAM_PROTOCOL_NV = 12866;

	[RequiredByFeature("EGL_NV_stream_remote")]
	public const int STREAM_ENDPOINT_NV = 12867;

	[RequiredByFeature("EGL_NV_stream_remote")]
	public const int STREAM_LOCAL_NV = 12868;

	[RequiredByFeature("EGL_NV_stream_remote")]
	public const int STREAM_PRODUCER_NV = 12871;

	[RequiredByFeature("EGL_NV_stream_remote")]
	public const int STREAM_CONSUMER_NV = 12872;

	[RequiredByFeature("EGL_NV_stream_remote")]
	public const int STREAM_PROTOCOL_FD_NV = 12870;

	[RequiredByFeature("EGL_NV_stream_reset")]
	public const int SUPPORT_RESET_NV = 13108;

	[RequiredByFeature("EGL_NV_stream_reset")]
	public const int SUPPORT_REUSE_NV = 13109;

	[RequiredByFeature("EGL_NV_stream_socket")]
	public const int STREAM_PROTOCOL_SOCKET_NV = 12875;

	[RequiredByFeature("EGL_NV_stream_socket")]
	public const int SOCKET_HANDLE_NV = 12876;

	[RequiredByFeature("EGL_NV_stream_socket")]
	public const int SOCKET_TYPE_NV = 12877;

	[RequiredByFeature("EGL_NV_stream_socket_inet")]
	public const int SOCKET_TYPE_INET_NV = 12879;

	[RequiredByFeature("EGL_NV_stream_socket_unix")]
	public const int SOCKET_TYPE_UNIX_NV = 12878;

	[RequiredByFeature("EGL_NV_stream_sync")]
	public const int SYNC_NEW_FRAME_NV = 12831;

	[RequiredByFeature("EGL_NV_sync")]
	public const int SYNC_PRIOR_COMMANDS_COMPLETE_NV = 12518;

	[RequiredByFeature("EGL_NV_sync")]
	public const int SYNC_STATUS_NV = 12519;

	[RequiredByFeature("EGL_NV_sync")]
	public const int SIGNALED_NV = 12520;

	[RequiredByFeature("EGL_NV_sync")]
	public const int UNSIGNALED_NV = 12521;

	[RequiredByFeature("EGL_NV_sync")]
	public const int ALREADY_SIGNALED_NV = 12522;

	[RequiredByFeature("EGL_NV_sync")]
	public const int TIMEOUT_EXPIRED_NV = 12523;

	[RequiredByFeature("EGL_NV_sync")]
	public const int CONDITION_SATISFIED_NV = 12524;

	[RequiredByFeature("EGL_NV_sync")]
	public const int SYNC_TYPE_NV = 12525;

	[RequiredByFeature("EGL_NV_sync")]
	public const int SYNC_CONDITION_NV = 12526;

	[RequiredByFeature("EGL_NV_sync")]
	public const int SYNC_FENCE_NV = 12527;

	[RequiredByFeature("EGL_TIZEN_image_native_buffer")]
	public const int NATIVE_BUFFER_TIZEN = 12960;

	[RequiredByFeature("EGL_TIZEN_image_native_surface")]
	public const int NATIVE_SURFACE_TIZEN = 12961;

	public static KhronosVersion CurrentVersion { get; private set; }

	public static string CurrentVendor { get; private set; }

	public static Extensions CurrentExtensions { get; internal set; }

	public static bool IsAvailable => Delegates.peglInitialize != null;

	public static bool IsRequired
	{
		get
		{
			if (Platform.CurrentPlatformId == Platform.Id.Android)
			{
				return true;
			}
			if (!_IsRequired || !IsAvailable)
			{
				return _IsInitializing;
			}
			return true;
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

	[RequiredByFeature("EGL_ANDROID_blob_cache")]
	public static void SetBlobCacheFuncsANDROID(nint dpy, SetBlobFuncDelegate set, GetBlobFuncDelegate get)
	{
		Delegates.peglSetBlobCacheFuncsANDROID(dpy, set, get);
	}

	[RequiredByFeature("EGL_ANDROID_create_native_client_buffer")]
	public unsafe static nint CreateNativeClientBufferANDROID(int[] attrib_list)
	{
		nint result;
		fixed (int* attrib_list2 = attrib_list)
		{
			result = Delegates.peglCreateNativeClientBufferANDROID(attrib_list2);
		}
		return result;
	}

	[RequiredByFeature("EGL_ANDROID_native_fence_sync")]
	public static int DupNativeFenceANDROID(nint dpy, nint sync)
	{
		return Delegates.peglDupNativeFenceFDANDROID(dpy, sync);
	}

	[RequiredByFeature("EGL_ANDROID_presentation_time")]
	public static bool PresentationTimeANDROID(nint dpy, nint surface, long time)
	{
		return Delegates.peglPresentationTimeANDROID(dpy, surface, time);
	}

	[RequiredByFeature("EGL_ANGLE_query_surface_pointer")]
	public unsafe static bool QuerySurfacePointerANGLE(nint dpy, nint surface, int attribute, nint[] value)
	{
		bool result;
		fixed (nint* value2 = value)
		{
			result = Delegates.peglQuerySurfacePointerANGLE(dpy, surface, attribute, value2);
		}
		return result;
	}

	static Egl()
	{
		_GetAddressDelegate = Khronos.KhronosApi.GetProcAddressOS;
		Version_100 = new KhronosVersion(1, 0, "egl");
		Version_110 = new KhronosVersion(1, 1, "egl");
		Version_120 = new KhronosVersion(1, 2, "egl");
		Version_130 = new KhronosVersion(1, 3, "egl");
		Version_140 = new KhronosVersion(1, 4, "egl");
		Version_150 = new KhronosVersion(1, 5, "egl");
		string environmentVariable = Environment.GetEnvironmentVariable("OPENGL_NET_EGL_STATIC_INIT");
		if (environmentVariable == null || !(environmentVariable == "NO"))
		{
			Initialize();
		}
	}

	public static void Initialize()
	{
		if (_Initialized)
		{
			return;
		}
		_Initialized = true;
		string assemblyLocation = Khronos.KhronosApi.GetAssemblyLocation();
		string text = null;
		switch (Platform.CurrentPlatformId)
		{
		case Platform.Id.WindowsNT:
			if (assemblyLocation != null)
			{
				text = Path.Combine(assemblyLocation, (IntPtr.Size == 8) ? "ANGLE\\winrt10\\x64" : "ANGLE\\winrt10\\x86");
			}
			break;
		case Platform.Id.Linux:
			GetProcAddressLinux.GetLibraryHandle("libGLESv2.so", throws: false);
			break;
		}
		if (text != null && Directory.Exists(text))
		{
			Khronos.GetProcAddressOS.AddLibraryDirectory(Path.Combine(assemblyLocation, text));
		}
		BindAPI();
		if (!IsAvailable)
		{
			return;
		}
		EglEventArgs eglEventArgs = new EglEventArgs();
		KhronosApi.RaiseEglInitializing(eglEventArgs);
		nint display = GetDisplay(eglEventArgs.Display);
		try
		{
			_IsInitializing = true;
			if (!Initialize(display, null, null))
			{
				throw new InvalidOperationException("unable to initialize EGL");
			}
			CurrentVersion = KhronosVersion.Parse(QueryString(display, 12372), "egl");
			CurrentVendor = QueryString(display, 12371);
			List<string> list = new List<string>();
			if (CurrentVersion >= Version_120)
			{
				string[] array = Regex.Split(QueryString(display, 12429), " ");
				foreach (string text2 in array)
				{
					switch (text2)
					{
					case "OpenGL":
						list.Add("gl");
						break;
					case "OpenGL_ES":
						list.Add("gles2");
						break;
					case "OpenVG":
						list.Add("vg");
						break;
					default:
						list.Add(text2);
						break;
					}
				}
			}
			AvailableApis = list.ToArray();
			CurrentExtensions = new Extensions();
			CurrentExtensions.Query(display, CurrentVersion);
		}
		finally
		{
			Terminate(display);
			_IsInitializing = false;
		}
	}

	private static void BindAPI()
	{
		string platformLibrary = GetPlatformLibrary();
		try
		{
			Khronos.KhronosApi.LogComment("Querying EGL from " + platformLibrary);
			Khronos.KhronosApi.BindAPI<Egl>(platformLibrary, _GetAddressDelegate, CurrentVersion);
			Khronos.KhronosApi.LogComment($"EGL availability: {IsAvailable}");
		}
		catch (Exception value)
		{
			Khronos.KhronosApi.LogComment($"EGL not available:\n{value}");
		}
	}

	private static string GetPlatformLibrary()
	{
		if (Platform.CurrentPlatformId != Platform.Id.Linux)
		{
			return "libEGL.dll";
		}
		return "libEGL.so";
	}

	[Conditional("GL_DEBUG")]
	private static void DebugCheckErrors(object returnValue)
	{
		int error = GetError();
		if (error != 12288)
		{
			throw new EglException(error);
		}
	}

	[Conditional("GL_DEBUG")]
	protected new static void LogCommand(string name, object returnValue, params object[] args)
	{
		if (_LogContext == null)
		{
			_LogContext = new KhronosLogContext(typeof(Egl));
		}
		Khronos.KhronosApi.RaiseLog(new KhronosLogEventArgs(_LogContext, name, args, returnValue));
	}

	[RequiredByFeature("EGL_VERSION_1_0")]
	public unsafe static bool ChooseConfig(nint dpy, int[] attrib_list, nint[] configs, int config_size, int[] num_config)
	{
		bool result;
		fixed (int* attrib_list2 = attrib_list)
		{
			fixed (nint* configs2 = configs)
			{
				fixed (int* num_config2 = num_config)
				{
					result = Delegates.peglChooseConfig(dpy, attrib_list2, configs2, config_size, num_config2);
				}
			}
		}
		return result;
	}

	[RequiredByFeature("EGL_VERSION_1_0")]
	public static bool CopyBuffers(nint dpy, nint surface, nint target)
	{
		return Delegates.peglCopyBuffers(dpy, surface, target);
	}

	[RequiredByFeature("EGL_VERSION_1_0")]
	public unsafe static nint CreateContext(nint dpy, nint config, nint share_context, int[] attrib_list)
	{
		nint result;
		fixed (int* attrib_list2 = attrib_list)
		{
			result = Delegates.peglCreateContext(dpy, config, share_context, attrib_list2);
		}
		return result;
	}

	[RequiredByFeature("EGL_VERSION_1_0")]
	public unsafe static nint CreatePbufferSurface(nint dpy, nint config, int[] attrib_list)
	{
		nint result;
		fixed (int* attrib_list2 = attrib_list)
		{
			result = Delegates.peglCreatePbufferSurface(dpy, config, attrib_list2);
		}
		return result;
	}

	[RequiredByFeature("EGL_VERSION_1_0")]
	public unsafe static nint CreatePixmapSurface(nint dpy, nint config, nint pixmap, int[] attrib_list)
	{
		nint result;
		fixed (int* attrib_list2 = attrib_list)
		{
			result = Delegates.peglCreatePixmapSurface(dpy, config, pixmap, attrib_list2);
		}
		return result;
	}

	[RequiredByFeature("EGL_VERSION_1_0")]
	public unsafe static nint CreateWindowSurface(nint dpy, nint config, nint win, int[] attrib_list)
	{
		nint result;
		fixed (int* attrib_list2 = attrib_list)
		{
			result = Delegates.peglCreateWindowSurface(dpy, config, win, attrib_list2);
		}
		return result;
	}

	[RequiredByFeature("EGL_VERSION_1_0")]
	public static bool DestroyContext(nint dpy, nint ctx)
	{
		return Delegates.peglDestroyContext(dpy, ctx);
	}

	[RequiredByFeature("EGL_VERSION_1_0")]
	public static bool DestroySurface(nint dpy, nint surface)
	{
		return Delegates.peglDestroySurface(dpy, surface);
	}

	[RequiredByFeature("EGL_VERSION_1_0")]
	public unsafe static bool GetConfigAttrib(nint dpy, nint config, int attribute, [Out] int[] value)
	{
		bool result;
		fixed (int* value2 = value)
		{
			result = Delegates.peglGetConfigAttrib(dpy, config, attribute, value2);
		}
		return result;
	}

	[RequiredByFeature("EGL_VERSION_1_0")]
	public unsafe static bool GetConfigAttrib(nint dpy, nint config, int attribute, out int value)
	{
		bool result;
		fixed (int* value2 = &value)
		{
			result = Delegates.peglGetConfigAttrib(dpy, config, attribute, value2);
		}
		return result;
	}

	[RequiredByFeature("EGL_VERSION_1_0")]
	public unsafe static bool GetConfigs(nint dpy, [Out] nint[] configs, int config_size, [Out] int[] num_config)
	{
		bool result;
		fixed (nint* configs2 = configs)
		{
			fixed (int* num_config2 = num_config)
			{
				result = Delegates.peglGetConfigs(dpy, configs2, config_size, num_config2);
			}
		}
		return result;
	}

	[RequiredByFeature("EGL_VERSION_1_0")]
	public unsafe static bool GetConfigs(nint dpy, [Out] nint[] configs, int config_size, out int num_config)
	{
		bool result;
		fixed (nint* configs2 = configs)
		{
			fixed (int* num_config2 = &num_config)
			{
				result = Delegates.peglGetConfigs(dpy, configs2, config_size, num_config2);
			}
		}
		return result;
	}

	[RequiredByFeature("EGL_VERSION_1_0")]
	public static nint GetCurrentDisplay()
	{
		return Delegates.peglGetCurrentDisplay();
	}

	[RequiredByFeature("EGL_VERSION_1_0")]
	public static nint GetCurrentSurface(int readdraw)
	{
		return Delegates.peglGetCurrentSurface(readdraw);
	}

	[RequiredByFeature("EGL_VERSION_1_0")]
	public static nint GetDisplay(nint display_id)
	{
		return Delegates.peglGetDisplay(display_id);
	}

	[RequiredByFeature("EGL_VERSION_1_0")]
	public static int GetError()
	{
		return Delegates.peglGetError();
	}

	[RequiredByFeature("EGL_VERSION_1_0")]
	public static nint GetProcAddress(string procname)
	{
		return Delegates.peglGetProcAddress(procname);
	}

	[RequiredByFeature("EGL_VERSION_1_0")]
	public unsafe static bool Initialize(nint dpy, int[] major, int[] minor)
	{
		bool result;
		fixed (int* major2 = major)
		{
			fixed (int* minor2 = minor)
			{
				result = Delegates.peglInitialize(dpy, major2, minor2);
			}
		}
		return result;
	}

	[RequiredByFeature("EGL_VERSION_1_0")]
	public static bool MakeCurrent(nint dpy, nint draw, nint read, nint ctx)
	{
		return Delegates.peglMakeCurrent(dpy, draw, read, ctx);
	}

	[RequiredByFeature("EGL_VERSION_1_0")]
	public unsafe static bool QueryContext(nint dpy, nint ctx, int attribute, int[] value)
	{
		bool result;
		fixed (int* value2 = value)
		{
			result = Delegates.peglQueryContext(dpy, ctx, attribute, value2);
		}
		return result;
	}

	[RequiredByFeature("EGL_VERSION_1_0")]
	public static string QueryString(nint dpy, int name)
	{
		return Khronos.KhronosApi.PtrToString(Delegates.peglQueryString(dpy, name));
	}

	[RequiredByFeature("EGL_VERSION_1_0")]
	public unsafe static bool QuerySurface(nint dpy, nint surface, int attribute, int[] value)
	{
		bool result;
		fixed (int* value2 = value)
		{
			result = Delegates.peglQuerySurface(dpy, surface, attribute, value2);
		}
		return result;
	}

	[RequiredByFeature("EGL_VERSION_1_0")]
	public static bool SwapBuffers(nint dpy, nint surface)
	{
		return Delegates.peglSwapBuffers(dpy, surface);
	}

	[RequiredByFeature("EGL_VERSION_1_0")]
	public static bool Terminate(nint dpy)
	{
		return Delegates.peglTerminate(dpy);
	}

	[RequiredByFeature("EGL_VERSION_1_0")]
	public static bool WaitGL()
	{
		return Delegates.peglWaitGL();
	}

	[RequiredByFeature("EGL_VERSION_1_0")]
	public static bool WaitNative(int engine)
	{
		return Delegates.peglWaitNative(engine);
	}

	[RequiredByFeature("EGL_VERSION_1_1")]
	public static bool BindTexImage(nint dpy, nint surface, int buffer)
	{
		return Delegates.peglBindTexImage(dpy, surface, buffer);
	}

	[RequiredByFeature("EGL_VERSION_1_1")]
	public static bool ReleaseTexImage(nint dpy, nint surface, int buffer)
	{
		return Delegates.peglReleaseTexImage(dpy, surface, buffer);
	}

	[RequiredByFeature("EGL_VERSION_1_1")]
	public static bool SurfaceAttrib(nint dpy, nint surface, int attribute, int value)
	{
		return Delegates.peglSurfaceAttrib(dpy, surface, attribute, value);
	}

	[RequiredByFeature("EGL_VERSION_1_1")]
	public static bool SwapInterval(nint dpy, int interval)
	{
		return Delegates.peglSwapInterval(dpy, interval);
	}

	[RequiredByFeature("EGL_VERSION_1_2")]
	public static bool BindAPI(uint api)
	{
		return Delegates.peglBindAPI(api);
	}

	[RequiredByFeature("EGL_VERSION_1_2")]
	public static uint QueryAPI()
	{
		return Delegates.peglQueryAPI();
	}

	[RequiredByFeature("EGL_VERSION_1_2")]
	public unsafe static nint CreatePbufferFromClientBuffer(nint dpy, uint buftype, nint buffer, nint config, int[] attrib_list)
	{
		nint result;
		fixed (int* attrib_list2 = attrib_list)
		{
			result = Delegates.peglCreatePbufferFromClientBuffer(dpy, buftype, buffer, config, attrib_list2);
		}
		return result;
	}

	[RequiredByFeature("EGL_VERSION_1_2")]
	public static bool ReleaseThread()
	{
		return Delegates.peglReleaseThread();
	}

	[RequiredByFeature("EGL_VERSION_1_2")]
	public static bool WaitClient()
	{
		return Delegates.peglWaitClient();
	}

	[RequiredByFeature("EGL_VERSION_1_4")]
	public static nint GetCurrentContext()
	{
		return Delegates.peglGetCurrentContext();
	}

	[RequiredByFeature("EGL_VERSION_1_5")]
	[RequiredByFeature("EGL_KHR_cl_event2")]
	public unsafe static nint CreateSync(nint dpy, uint type, nint[] attrib_list)
	{
		nint result;
		fixed (nint* attrib_list2 = attrib_list)
		{
			result = Delegates.peglCreateSync(dpy, type, attrib_list2);
		}
		return result;
	}

	[RequiredByFeature("EGL_VERSION_1_5")]
	[RequiredByFeature("EGL_KHR_fence_sync")]
	[RequiredByFeature("EGL_KHR_reusable_sync")]
	public static bool DestroySync(nint dpy, nint sync)
	{
		return Delegates.peglDestroySync(dpy, sync);
	}

	[RequiredByFeature("EGL_VERSION_1_5")]
	[RequiredByFeature("EGL_KHR_fence_sync")]
	[RequiredByFeature("EGL_KHR_reusable_sync")]
	public static int ClientWaitSync(nint dpy, nint sync, int flags, ulong timeout)
	{
		return Delegates.peglClientWaitSync(dpy, sync, flags, timeout);
	}

	[RequiredByFeature("EGL_VERSION_1_5")]
	public unsafe static bool GetSyncAttrib(nint dpy, nint sync, int attribute, [Out] nint[] value)
	{
		bool result;
		fixed (nint* value2 = value)
		{
			result = Delegates.peglGetSyncAttrib(dpy, sync, attribute, value2);
		}
		return result;
	}

	[RequiredByFeature("EGL_VERSION_1_5")]
	public unsafe static nint CreateImage(nint dpy, nint ctx, uint target, nint buffer, nint[] attrib_list)
	{
		nint result;
		fixed (nint* attrib_list2 = attrib_list)
		{
			result = Delegates.peglCreateImage(dpy, ctx, target, buffer, attrib_list2);
		}
		return result;
	}

	[RequiredByFeature("EGL_VERSION_1_5")]
	[RequiredByFeature("EGL_KHR_image")]
	[RequiredByFeature("EGL_KHR_image_base")]
	public static bool DestroyImage(nint dpy, nint image)
	{
		return Delegates.peglDestroyImage(dpy, image);
	}

	[RequiredByFeature("EGL_VERSION_1_5")]
	public unsafe static nint GetPlatformDisplay(uint platform, nint native_display, nint[] attrib_list)
	{
		nint result;
		fixed (nint* attrib_list2 = attrib_list)
		{
			result = Delegates.peglGetPlatformDisplay(platform, native_display, attrib_list2);
		}
		return result;
	}

	[RequiredByFeature("EGL_VERSION_1_5")]
	public unsafe static nint CreatePlatformWindowSurface(nint dpy, nint config, nint native_window, nint[] attrib_list)
	{
		nint result;
		fixed (nint* attrib_list2 = attrib_list)
		{
			result = Delegates.peglCreatePlatformWindowSurface(dpy, config, native_window, attrib_list2);
		}
		return result;
	}

	[RequiredByFeature("EGL_VERSION_1_5")]
	public unsafe static nint CreatePlatformPixmapSurface(nint dpy, nint config, nint native_pixmap, nint[] attrib_list)
	{
		nint result;
		fixed (nint* attrib_list2 = attrib_list)
		{
			result = Delegates.peglCreatePlatformPixmapSurface(dpy, config, native_pixmap, attrib_list2);
		}
		return result;
	}

	[RequiredByFeature("EGL_VERSION_1_5")]
	public static bool WaitSync(nint dpy, nint sync, int flags)
	{
		return Delegates.peglWaitSync(dpy, sync, flags);
	}

	[RequiredByFeature("EGL_EXT_device_base")]
	[RequiredByFeature("EGL_EXT_device_enumeration")]
	public unsafe static bool QueryDevicesEXT(int max_devices, nint[] devices, int[] num_devices)
	{
		bool result;
		fixed (nint* devices2 = devices)
		{
			fixed (int* num_devices2 = num_devices)
			{
				result = Delegates.peglQueryDevicesEXT(max_devices, devices2, num_devices2);
			}
		}
		return result;
	}

	[RequiredByFeature("EGL_EXT_device_base")]
	[RequiredByFeature("EGL_EXT_device_query")]
	public unsafe static bool QueryDeviceAttribEXT(nint device, int attribute, nint[] value)
	{
		bool result;
		fixed (nint* value2 = value)
		{
			result = Delegates.peglQueryDeviceAttribEXT(device, attribute, value2);
		}
		return result;
	}

	[RequiredByFeature("EGL_EXT_device_base")]
	[RequiredByFeature("EGL_EXT_device_query")]
	public static string QueryDeviceStringEXT(nint device, int name)
	{
		return Khronos.KhronosApi.PtrToString(Delegates.peglQueryDeviceStringEXT(device, name));
	}

	[RequiredByFeature("EGL_EXT_device_base")]
	[RequiredByFeature("EGL_EXT_device_query")]
	[RequiredByFeature("EGL_NV_stream_metadata")]
	public unsafe static bool QueryDisplayAttribEXT(nint dpy, int attribute, nint[] value)
	{
		bool result;
		fixed (nint* value2 = value)
		{
			result = Delegates.peglQueryDisplayAttribEXT(dpy, attribute, value2);
		}
		return result;
	}

	[RequiredByFeature("EGL_EXT_image_dma_buf_import_modifiers")]
	public unsafe static bool QueryDmaBufFormatsEXT(nint dpy, int max_formats, int[] formats, int[] num_formats)
	{
		bool result;
		fixed (int* formats2 = formats)
		{
			fixed (int* num_formats2 = num_formats)
			{
				result = Delegates.peglQueryDmaBufFormatsEXT(dpy, max_formats, formats2, num_formats2);
			}
		}
		return result;
	}

	[RequiredByFeature("EGL_EXT_image_dma_buf_import_modifiers")]
	public unsafe static bool QueryDmaBufModifiersEXT(nint dpy, int format, int max_modifiers, ulong[] modifiers, bool[] external_only, int[] num_modifiers)
	{
		bool result;
		fixed (ulong* modifiers2 = modifiers)
		{
			fixed (bool* external_only2 = external_only)
			{
				fixed (int* num_modifiers2 = num_modifiers)
				{
					result = Delegates.peglQueryDmaBufModifiersEXT(dpy, format, max_modifiers, modifiers2, external_only2, num_modifiers2);
				}
			}
		}
		return result;
	}

	[RequiredByFeature("EGL_EXT_output_base")]
	public unsafe static bool GetOutputLayersEXT(nint dpy, nint[] attrib_list, [Out] nint[] layers, int max_layers, [Out] int[] num_layers)
	{
		bool result;
		fixed (nint* attrib_list2 = attrib_list)
		{
			fixed (nint* layers2 = layers)
			{
				fixed (int* num_layers2 = num_layers)
				{
					result = Delegates.peglGetOutputLayersEXT(dpy, attrib_list2, layers2, max_layers, num_layers2);
				}
			}
		}
		return result;
	}

	[RequiredByFeature("EGL_EXT_output_base")]
	public unsafe static bool GetOutputPortsEXT(nint dpy, nint[] attrib_list, [Out] nint[] ports, int max_ports, [Out] int[] num_ports)
	{
		bool result;
		fixed (nint* attrib_list2 = attrib_list)
		{
			fixed (nint* ports2 = ports)
			{
				fixed (int* num_ports2 = num_ports)
				{
					result = Delegates.peglGetOutputPortsEXT(dpy, attrib_list2, ports2, max_ports, num_ports2);
				}
			}
		}
		return result;
	}

	[RequiredByFeature("EGL_EXT_output_base")]
	public static bool OutputLayerAttribEXT(nint dpy, nint layer, int attribute, nint value)
	{
		return Delegates.peglOutputLayerAttribEXT(dpy, layer, attribute, value);
	}

	[RequiredByFeature("EGL_EXT_output_base")]
	public unsafe static bool QueryOutputLayerAttribEXT(nint dpy, nint layer, int attribute, nint[] value)
	{
		bool result;
		fixed (nint* value2 = value)
		{
			result = Delegates.peglQueryOutputLayerAttribEXT(dpy, layer, attribute, value2);
		}
		return result;
	}

	[RequiredByFeature("EGL_EXT_output_base")]
	public static string QueryOutputLayerStringEXT(nint dpy, nint layer, int name)
	{
		return Khronos.KhronosApi.PtrToString(Delegates.peglQueryOutputLayerStringEXT(dpy, layer, name));
	}

	[RequiredByFeature("EGL_EXT_output_base")]
	public static bool OutputPortAttribEXT(nint dpy, nint port, int attribute, nint value)
	{
		return Delegates.peglOutputPortAttribEXT(dpy, port, attribute, value);
	}

	[RequiredByFeature("EGL_EXT_output_base")]
	public unsafe static bool QueryOutputPortAttribEXT(nint dpy, nint port, int attribute, nint[] value)
	{
		bool result;
		fixed (nint* value2 = value)
		{
			result = Delegates.peglQueryOutputPortAttribEXT(dpy, port, attribute, value2);
		}
		return result;
	}

	[RequiredByFeature("EGL_EXT_output_base")]
	public static string QueryOutputPortStringEXT(nint dpy, nint port, int name)
	{
		return Khronos.KhronosApi.PtrToString(Delegates.peglQueryOutputPortStringEXT(dpy, port, name));
	}

	[RequiredByFeature("EGL_EXT_platform_base")]
	public unsafe static nint GetPlatformDisplayEXT(uint platform, nint native_display, int[] attrib_list)
	{
		nint result;
		fixed (int* attrib_list2 = attrib_list)
		{
			result = Delegates.peglGetPlatformDisplayEXT(platform, native_display, attrib_list2);
		}
		return result;
	}

	[RequiredByFeature("EGL_EXT_platform_base")]
	public unsafe static nint CreatePlatformWindowSurfaceEXT(nint dpy, nint config, nint native_window, int[] attrib_list)
	{
		nint result;
		fixed (int* attrib_list2 = attrib_list)
		{
			result = Delegates.peglCreatePlatformWindowSurfaceEXT(dpy, config, native_window, attrib_list2);
		}
		return result;
	}

	[RequiredByFeature("EGL_EXT_platform_base")]
	public unsafe static nint CreatePlatformPixmapSurfaceEXT(nint dpy, nint config, nint native_pixmap, int[] attrib_list)
	{
		nint result;
		fixed (int* attrib_list2 = attrib_list)
		{
			result = Delegates.peglCreatePlatformPixmapSurfaceEXT(dpy, config, native_pixmap, attrib_list2);
		}
		return result;
	}

	[RequiredByFeature("EGL_EXT_stream_consumer_egloutput")]
	public static bool StreamConsumerOutputEXT(nint dpy, nint stream, nint layer)
	{
		return Delegates.peglStreamConsumerOutputEXT(dpy, stream, layer);
	}

	[RequiredByFeature("EGL_EXT_swap_buffers_with_damage")]
	public unsafe static bool SwapBuffersWithDamageEXT(nint dpy, nint surface, int[] rects, int n_rects)
	{
		bool result;
		fixed (int* rects2 = rects)
		{
			result = Delegates.peglSwapBuffersWithDamageEXT(dpy, surface, rects2, n_rects);
		}
		return result;
	}

	[RequiredByFeature("EGL_HI_clientpixmap")]
	public unsafe static nint CreatePixmapSurfaceHI(nint dpy, nint config, ClientPixmap[] pixmap)
	{
		nint result;
		fixed (ClientPixmap* pixmap2 = pixmap)
		{
			result = Delegates.peglCreatePixmapSurfaceHI(dpy, config, pixmap2);
		}
		return result;
	}

	[RequiredByFeature("EGL_KHR_debug")]
	public unsafe static int KHR(DebugProcKHR callback, nint[] attrib_list)
	{
		int result;
		fixed (nint* attrib_list2 = attrib_list)
		{
			result = Delegates.peglDebugMessageControlKHR(callback, attrib_list2);
		}
		return result;
	}

	[RequiredByFeature("EGL_KHR_debug")]
	public unsafe static bool QueryKHR(int attribute, nint[] value)
	{
		bool result;
		fixed (nint* value2 = value)
		{
			result = Delegates.peglQueryDebugKHR(attribute, value2);
		}
		return result;
	}

	[RequiredByFeature("EGL_KHR_debug")]
	public static int KHR(nint display, uint objectType, nint @object, nint label)
	{
		return Delegates.peglLabelObjectKHR(display, objectType, @object, label);
	}

	[RequiredByFeature("EGL_KHR_image")]
	[RequiredByFeature("EGL_KHR_image_base")]
	public unsafe static nint CreateImageKHR(nint dpy, nint ctx, uint target, nint buffer, int[] attrib_list)
	{
		nint result;
		fixed (int* attrib_list2 = attrib_list)
		{
			result = Delegates.peglCreateImageKHR(dpy, ctx, target, buffer, attrib_list2);
		}
		return result;
	}

	[RequiredByFeature("EGL_KHR_lock_surface")]
	[RequiredByFeature("EGL_KHR_lock_surface3")]
	public unsafe static bool LockSurfaceKHR(nint dpy, nint surface, int[] attrib_list)
	{
		bool result;
		fixed (int* attrib_list2 = attrib_list)
		{
			result = Delegates.peglLockSurfaceKHR(dpy, surface, attrib_list2);
		}
		return result;
	}

	[RequiredByFeature("EGL_KHR_lock_surface")]
	[RequiredByFeature("EGL_KHR_lock_surface3")]
	public static bool UnlockSurfaceKHR(nint dpy, nint surface)
	{
		return Delegates.peglUnlockSurfaceKHR(dpy, surface);
	}

	[RequiredByFeature("EGL_KHR_lock_surface3")]
	public unsafe static bool QuerySurfaceKHR(nint dpy, nint surface, int attribute, nint[] value)
	{
		bool result;
		fixed (nint* value2 = value)
		{
			result = Delegates.peglQuerySurface64KHR(dpy, surface, attribute, value2);
		}
		return result;
	}

	[RequiredByFeature("EGL_KHR_partial_update")]
	public unsafe static bool SetDamageRegionKHR(nint dpy, nint surface, int[] rects, int n_rects)
	{
		bool result;
		fixed (int* rects2 = rects)
		{
			result = Delegates.peglSetDamageRegionKHR(dpy, surface, rects2, n_rects);
		}
		return result;
	}

	[RequiredByFeature("EGL_KHR_fence_sync")]
	[RequiredByFeature("EGL_KHR_reusable_sync")]
	public unsafe static nint CreateSyncKHR(nint dpy, uint type, int[] attrib_list)
	{
		nint result;
		fixed (int* attrib_list2 = attrib_list)
		{
			result = Delegates.peglCreateSyncKHR(dpy, type, attrib_list2);
		}
		return result;
	}

	[RequiredByFeature("EGL_KHR_reusable_sync")]
	public static bool SignalSyncKHR(nint dpy, nint sync, uint mode)
	{
		return Delegates.peglSignalSyncKHR(dpy, sync, mode);
	}

	[RequiredByFeature("EGL_KHR_fence_sync")]
	[RequiredByFeature("EGL_KHR_reusable_sync")]
	public unsafe static bool GetSyncAttribKHR(nint dpy, nint sync, int attribute, [Out] int[] value)
	{
		bool result;
		fixed (int* value2 = value)
		{
			result = Delegates.peglGetSyncAttribKHR(dpy, sync, attribute, value2);
		}
		return result;
	}

	[RequiredByFeature("EGL_KHR_stream")]
	public unsafe static nint CreateStreamKHR(nint dpy, int[] attrib_list)
	{
		nint result;
		fixed (int* attrib_list2 = attrib_list)
		{
			result = Delegates.peglCreateStreamKHR(dpy, attrib_list2);
		}
		return result;
	}

	[RequiredByFeature("EGL_KHR_stream")]
	public static bool DestroyStreamKHR(nint dpy, nint stream)
	{
		return Delegates.peglDestroyStreamKHR(dpy, stream);
	}

	[RequiredByFeature("EGL_KHR_stream")]
	public static bool StreamAttribKHR(nint dpy, nint stream, uint attribute, int value)
	{
		return Delegates.peglStreamAttribKHR(dpy, stream, attribute, value);
	}

	[RequiredByFeature("EGL_KHR_stream")]
	public unsafe static bool QueryStreamKHR(nint dpy, nint stream, uint attribute, int[] value)
	{
		bool result;
		fixed (int* value2 = value)
		{
			result = Delegates.peglQueryStreamKHR(dpy, stream, attribute, value2);
		}
		return result;
	}

	[RequiredByFeature("EGL_KHR_stream")]
	public unsafe static bool QueryStreamKHR(nint dpy, nint stream, uint attribute, ulong[] value)
	{
		bool result;
		fixed (ulong* value2 = value)
		{
			result = Delegates.peglQueryStreamu64KHR(dpy, stream, attribute, value2);
		}
		return result;
	}

	[RequiredByFeature("EGL_KHR_stream_attrib")]
	public unsafe static nint CreateStreamAttribKHR(nint dpy, nint[] attrib_list)
	{
		nint result;
		fixed (nint* attrib_list2 = attrib_list)
		{
			result = Delegates.peglCreateStreamAttribKHR(dpy, attrib_list2);
		}
		return result;
	}

	[RequiredByFeature("EGL_KHR_stream_attrib")]
	public static bool SetStreamAttribKHR(nint dpy, nint stream, uint attribute, nint value)
	{
		return Delegates.peglSetStreamAttribKHR(dpy, stream, attribute, value);
	}

	[RequiredByFeature("EGL_KHR_stream_attrib")]
	public unsafe static bool QueryStreamAttribKHR(nint dpy, nint stream, uint attribute, nint[] value)
	{
		bool result;
		fixed (nint* value2 = value)
		{
			result = Delegates.peglQueryStreamAttribKHR(dpy, stream, attribute, value2);
		}
		return result;
	}

	[RequiredByFeature("EGL_KHR_stream_attrib")]
	public unsafe static bool StreamConsumerAcquireAttribKHR(nint dpy, nint stream, nint[] attrib_list)
	{
		bool result;
		fixed (nint* attrib_list2 = attrib_list)
		{
			result = Delegates.peglStreamConsumerAcquireAttribKHR(dpy, stream, attrib_list2);
		}
		return result;
	}

	[RequiredByFeature("EGL_KHR_stream_attrib")]
	public unsafe static bool StreamConsumerReleaseAttribKHR(nint dpy, nint stream, nint[] attrib_list)
	{
		bool result;
		fixed (nint* attrib_list2 = attrib_list)
		{
			result = Delegates.peglStreamConsumerReleaseAttribKHR(dpy, stream, attrib_list2);
		}
		return result;
	}

	[RequiredByFeature("EGL_KHR_stream_consumer_gltexture")]
	public static bool StreamConsumerGLTextureExternalKHR(nint dpy, nint stream)
	{
		return Delegates.peglStreamConsumerGLTextureExternalKHR(dpy, stream);
	}

	[RequiredByFeature("EGL_KHR_stream_consumer_gltexture")]
	public static bool StreamConsumerAcquireKHR(nint dpy, nint stream)
	{
		return Delegates.peglStreamConsumerAcquireKHR(dpy, stream);
	}

	[RequiredByFeature("EGL_KHR_stream_consumer_gltexture")]
	public static bool StreamConsumerReleaseKHR(nint dpy, nint stream)
	{
		return Delegates.peglStreamConsumerReleaseKHR(dpy, stream);
	}

	[RequiredByFeature("EGL_KHR_stream_cross_process_fd")]
	public static int GetStreamFileDescriptorKHR(nint dpy, nint stream)
	{
		return Delegates.peglGetStreamFileDescriptorKHR(dpy, stream);
	}

	[RequiredByFeature("EGL_KHR_stream_cross_process_fd")]
	public static nint CreateStreamFromFileDescriptorKHR(nint dpy, int file_descriptor)
	{
		return Delegates.peglCreateStreamFromFileDescriptorKHR(dpy, file_descriptor);
	}

	[RequiredByFeature("EGL_KHR_stream_fifo")]
	public unsafe static bool QueryStreamTimeKHR(nint dpy, nint stream, uint attribute, ulong[] value)
	{
		bool result;
		fixed (ulong* value2 = value)
		{
			result = Delegates.peglQueryStreamTimeKHR(dpy, stream, attribute, value2);
		}
		return result;
	}

	[RequiredByFeature("EGL_KHR_stream_producer_eglsurface")]
	public unsafe static nint CreateStreamProducerSurfaceKHR(nint dpy, nint config, nint stream, int[] attrib_list)
	{
		nint result;
		fixed (int* attrib_list2 = attrib_list)
		{
			result = Delegates.peglCreateStreamProducerSurfaceKHR(dpy, config, stream, attrib_list2);
		}
		return result;
	}

	[RequiredByFeature("EGL_KHR_swap_buffers_with_damage")]
	public unsafe static bool SwapBuffersWithDamageKHR(nint dpy, nint surface, int[] rects, int n_rects)
	{
		bool result;
		fixed (int* rects2 = rects)
		{
			result = Delegates.peglSwapBuffersWithDamageKHR(dpy, surface, rects2, n_rects);
		}
		return result;
	}

	[RequiredByFeature("EGL_KHR_wait_sync")]
	public static int WaitSyncKHR(nint dpy, nint sync, int flags)
	{
		return Delegates.peglWaitSyncKHR(dpy, sync, flags);
	}

	[RequiredByFeature("EGL_MESA_drm_image")]
	public unsafe static nint CreateDRMImageMESA(nint dpy, int[] attrib_list)
	{
		nint result;
		fixed (int* attrib_list2 = attrib_list)
		{
			result = Delegates.peglCreateDRMImageMESA(dpy, attrib_list2);
		}
		return result;
	}

	[RequiredByFeature("EGL_MESA_drm_image")]
	public unsafe static bool ExportDRMImageMESA(nint dpy, nint image, int[] name, int[] handle, int[] stride)
	{
		bool result;
		fixed (int* name2 = name)
		{
			fixed (int* handle2 = handle)
			{
				fixed (int* stride2 = stride)
				{
					result = Delegates.peglExportDRMImageMESA(dpy, image, name2, handle2, stride2);
				}
			}
		}
		return result;
	}

	[RequiredByFeature("EGL_MESA_image_dma_buf_export")]
	public unsafe static bool ExportDMABUFImageQueryMESA(nint dpy, nint image, int[] fourcc, int[] num_planes, ulong[] modifiers)
	{
		bool result;
		fixed (int* fourcc2 = fourcc)
		{
			fixed (int* num_planes2 = num_planes)
			{
				fixed (ulong* modifiers2 = modifiers)
				{
					result = Delegates.peglExportDMABUFImageQueryMESA(dpy, image, fourcc2, num_planes2, modifiers2);
				}
			}
		}
		return result;
	}

	[RequiredByFeature("EGL_MESA_image_dma_buf_export")]
	public unsafe static bool ExportDMABUFImageMESA(nint dpy, nint image, int[] fds, int[] strides, int[] offsets)
	{
		bool result;
		fixed (int* fds2 = fds)
		{
			fixed (int* strides2 = strides)
			{
				fixed (int* offsets2 = offsets)
				{
					result = Delegates.peglExportDMABUFImageMESA(dpy, image, fds2, strides2, offsets2);
				}
			}
		}
		return result;
	}

	[RequiredByFeature("EGL_NOK_swap_region")]
	public unsafe static bool SwapBuffersRegionNOK(nint dpy, nint surface, int numRects, int[] rects)
	{
		bool result;
		fixed (int* rects2 = rects)
		{
			result = Delegates.peglSwapBuffersRegionNOK(dpy, surface, numRects, rects2);
		}
		return result;
	}

	[RequiredByFeature("EGL_NOK_swap_region2")]
	public unsafe static bool SwapBuffersRegion2NOK(nint dpy, nint surface, int numRects, int[] rects)
	{
		bool result;
		fixed (int* rects2 = rects)
		{
			result = Delegates.peglSwapBuffersRegion2NOK(dpy, surface, numRects, rects2);
		}
		return result;
	}

	[RequiredByFeature("EGL_NV_native_query")]
	public unsafe static bool QueryNativeDisplayNV(nint dpy, nint[] display_id)
	{
		bool result;
		fixed (nint* display_id2 = display_id)
		{
			result = Delegates.peglQueryNativeDisplayNV(dpy, display_id2);
		}
		return result;
	}

	[RequiredByFeature("EGL_NV_native_query")]
	public unsafe static bool QueryNativeWindowNV(nint dpy, nint surf, nint[] window)
	{
		bool result;
		fixed (nint* window2 = window)
		{
			result = Delegates.peglQueryNativeWindowNV(dpy, surf, window2);
		}
		return result;
	}

	[RequiredByFeature("EGL_NV_native_query")]
	public unsafe static bool QueryNativePixmapNV(nint dpy, nint surf, nint[] pixmap)
	{
		bool result;
		fixed (nint* pixmap2 = pixmap)
		{
			result = Delegates.peglQueryNativePixmapNV(dpy, surf, pixmap2);
		}
		return result;
	}

	[RequiredByFeature("EGL_NV_post_sub_buffer")]
	public static bool PostSubBufferNV(nint dpy, nint surface, int x, int y, int width, int height)
	{
		return Delegates.peglPostSubBufferNV(dpy, surface, x, y, width, height);
	}

	[RequiredByFeature("EGL_NV_stream_consumer_gltexture_yuv")]
	public unsafe static bool StreamConsumerGLTextureExternalAttribsNV(nint dpy, nint stream, nint[] attrib_list)
	{
		bool result;
		fixed (nint* attrib_list2 = attrib_list)
		{
			result = Delegates.peglStreamConsumerGLTextureExternalAttribsNV(dpy, stream, attrib_list2);
		}
		return result;
	}

	[RequiredByFeature("EGL_NV_stream_metadata")]
	public static bool SetStreamNV(nint dpy, nint stream, int n, int offset, int size, nint data)
	{
		return Delegates.peglSetStreamMetadataNV(dpy, stream, n, offset, size, data);
	}

	[RequiredByFeature("EGL_NV_stream_metadata")]
	public static bool QueryStreamNV(nint dpy, nint stream, uint name, int n, int offset, int size, nint data)
	{
		return Delegates.peglQueryStreamMetadataNV(dpy, stream, name, n, offset, size, data);
	}

	[RequiredByFeature("EGL_NV_stream_reset")]
	public static bool ResetStreamNV(nint dpy, nint stream)
	{
		return Delegates.peglResetStreamNV(dpy, stream);
	}

	[RequiredByFeature("EGL_NV_stream_sync")]
	public unsafe static nint CreateStreamSyncNV(nint dpy, nint stream, uint type, int[] attrib_list)
	{
		nint result;
		fixed (int* attrib_list2 = attrib_list)
		{
			result = Delegates.peglCreateStreamSyncNV(dpy, stream, type, attrib_list2);
		}
		return result;
	}

	[RequiredByFeature("EGL_NV_sync")]
	public unsafe static nint CreateFenceSyncNV(nint dpy, uint condition, int[] attrib_list)
	{
		nint result;
		fixed (int* attrib_list2 = attrib_list)
		{
			result = Delegates.peglCreateFenceSyncNV(dpy, condition, attrib_list2);
		}
		return result;
	}

	[RequiredByFeature("EGL_NV_sync")]
	public static bool DestroySyncNV(nint sync)
	{
		return Delegates.peglDestroySyncNV(sync);
	}

	[RequiredByFeature("EGL_NV_sync")]
	public static bool FenceNV(nint sync)
	{
		return Delegates.peglFenceNV(sync);
	}

	[RequiredByFeature("EGL_NV_sync")]
	public static int ClientWaitSyncNV(nint sync, int flags, ulong timeout)
	{
		return Delegates.peglClientWaitSyncNV(sync, flags, timeout);
	}

	[RequiredByFeature("EGL_NV_sync")]
	public static bool SignalSyncNV(nint sync, uint mode)
	{
		return Delegates.peglSignalSyncNV(sync, mode);
	}

	[RequiredByFeature("EGL_NV_sync")]
	public unsafe static bool GetSyncAttribNV(nint sync, int attribute, [Out] int[] value)
	{
		bool result;
		fixed (int* value2 = value)
		{
			result = Delegates.peglGetSyncAttribNV(sync, attribute, value2);
		}
		return result;
	}

	[RequiredByFeature("EGL_NV_system_time")]
	public static ulong GetSystemTimeFrequencyNV()
	{
		return Delegates.peglGetSystemTimeFrequencyNV();
	}

	[RequiredByFeature("EGL_NV_system_time")]
	public static ulong GetSystemTimeNV()
	{
		return Delegates.peglGetSystemTimeNV();
	}
}
