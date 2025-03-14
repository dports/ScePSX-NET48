using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using Khronos;

namespace OpenGL;

public class Wgl : KhronosApi
{
	internal static class Delegates
	{
		[RequiredByFeature("WGL_3DL_stereo_control")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglSetStereoEmitterState3DL(nint hDC, uint uState);

		[RequiredByFeature("WGL_AMD_gpu_association")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate uint wglGetGPUIDsAMD(uint maxCount, uint* ids);

		[RequiredByFeature("WGL_AMD_gpu_association")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate int wglGetGPUInfoAMD(uint id, int property, int dataType, uint size, nint data);

		[RequiredByFeature("WGL_AMD_gpu_association")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate uint wglGetContextGPUIDAMD(nint hglrc);

		[RequiredByFeature("WGL_AMD_gpu_association")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint wglCreateAssociatedContextAMD(uint id);

		[RequiredByFeature("WGL_AMD_gpu_association")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint wglCreateAssociatedContextAttribsAMD(uint id, nint hShareContext, int* attribList);

		[RequiredByFeature("WGL_AMD_gpu_association")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglDeleteAssociatedContextAMD(nint hglrc);

		[RequiredByFeature("WGL_AMD_gpu_association")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglMakeAssociatedContextCurrentAMD(nint hglrc);

		[RequiredByFeature("WGL_AMD_gpu_association")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint wglGetCurrentAssociatedContextAMD();

		[RequiredByFeature("WGL_AMD_gpu_association")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate void wglBlitContextFramebufferAMD(nint dstCtx, int srcX0, int srcY0, int srcX1, int srcY1, int dstX0, int dstY0, int dstX1, int dstY1, uint mask, int filter);

		[RequiredByFeature("WGL_ARB_buffer_region")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint wglCreateBufferRegionARB(nint hDC, int iLayerPlane, uint uType);

		[RequiredByFeature("WGL_ARB_buffer_region")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate void wglDeleteBufferRegionARB(nint hRegion);

		[RequiredByFeature("WGL_ARB_buffer_region")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglSaveBufferRegionARB(nint hRegion, int x, int y, int width, int height);

		[RequiredByFeature("WGL_ARB_buffer_region")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglRestoreBufferRegionARB(nint hRegion, int x, int y, int width, int height, int xSrc, int ySrc);

		[RequiredByFeature("WGL_ARB_create_context")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint wglCreateContextAttribsARB(nint hDC, nint hShareContext, int* attribList);

		[RequiredByFeature("WGL_ARB_extensions_string")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint wglGetExtensionsStringARB(nint hdc);

		[RequiredByFeature("WGL_ARB_make_current_read")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglMakeContextCurrentARB(nint hDrawDC, nint hReadDC, nint hglrc);

		[RequiredByFeature("WGL_ARB_make_current_read")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint wglGetCurrentReadDCARB();

		[RequiredByFeature("WGL_ARB_pbuffer")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint wglCreatePbufferARB(nint hDC, int iPixelFormat, int iWidth, int iHeight, int* piAttribList);

		[RequiredByFeature("WGL_ARB_pbuffer")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint wglGetPbufferDCARB(nint hPbuffer);

		[RequiredByFeature("WGL_ARB_pbuffer")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate int wglReleasePbufferDCARB(nint hPbuffer, nint hDC);

		[RequiredByFeature("WGL_ARB_pbuffer")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglDestroyPbufferARB(nint hPbuffer);

		[RequiredByFeature("WGL_ARB_pbuffer")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglQueryPbufferARB(nint hPbuffer, int iAttribute, int* piValue);

		[RequiredByFeature("WGL_ARB_pixel_format")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglGetPixelFormatAttribivARB(nint hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, int* piAttributes, int* piValues);

		[RequiredByFeature("WGL_ARB_pixel_format")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglGetPixelFormatAttribfvARB(nint hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, int* piAttributes, float* pfValues);

		[RequiredByFeature("WGL_ARB_pixel_format")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglChoosePixelFormatARB(nint hdc, int* piAttribIList, float* pfAttribFList, uint nMaxFormats, int* piFormats, uint* nNumFormats);

		[RequiredByFeature("WGL_ARB_render_texture")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglBindTexImageARB(nint hPbuffer, int iBuffer);

		[RequiredByFeature("WGL_ARB_render_texture")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglReleaseTexImageARB(nint hPbuffer, int iBuffer);

		[RequiredByFeature("WGL_ARB_render_texture")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglSetPbufferAttribARB(nint hPbuffer, int* piAttribList);

		[RequiredByFeature("WGL_EXT_display_color_table")]
		[SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		internal delegate bool wglCreateDisplayColorTableEXT(ushort id);

		[RequiredByFeature("WGL_EXT_display_color_table")]
		[SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		internal unsafe delegate bool wglLoadDisplayColorTableEXT(ushort* table, uint length);

		[RequiredByFeature("WGL_EXT_display_color_table")]
		[SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		internal delegate bool wglBindDisplayColorTableEXT(ushort id);

		[RequiredByFeature("WGL_EXT_display_color_table")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate void wglDestroyDisplayColorTableEXT(ushort id);

		[RequiredByFeature("WGL_EXT_extensions_string")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint wglGetExtensionsStringEXT();

		[RequiredByFeature("WGL_EXT_make_current_read")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglMakeContextCurrentEXT(nint hDrawDC, nint hReadDC, nint hglrc);

		[RequiredByFeature("WGL_EXT_make_current_read")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint wglGetCurrentReadDCEXT();

		[RequiredByFeature("WGL_EXT_pbuffer")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint wglCreatePbufferEXT(nint hDC, int iPixelFormat, int iWidth, int iHeight, int* piAttribList);

		[RequiredByFeature("WGL_EXT_pbuffer")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint wglGetPbufferDCEXT(nint hPbuffer);

		[RequiredByFeature("WGL_EXT_pbuffer")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate int wglReleasePbufferDCEXT(nint hPbuffer, nint hDC);

		[RequiredByFeature("WGL_EXT_pbuffer")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglDestroyPbufferEXT(nint hPbuffer);

		[RequiredByFeature("WGL_EXT_pbuffer")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglQueryPbufferEXT(nint hPbuffer, int iAttribute, int* piValue);

		[RequiredByFeature("WGL_EXT_pixel_format")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglGetPixelFormatAttribivEXT(nint hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, int* piAttributes, int* piValues);

		[RequiredByFeature("WGL_EXT_pixel_format")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglGetPixelFormatAttribfvEXT(nint hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, int* piAttributes, float* pfValues);

		[RequiredByFeature("WGL_EXT_pixel_format")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglChoosePixelFormatEXT(nint hdc, int* piAttribIList, float* pfAttribFList, uint nMaxFormats, int* piFormats, uint* nNumFormats);

		[RequiredByFeature("WGL_EXT_swap_control")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglSwapIntervalEXT(int interval);

		[RequiredByFeature("WGL_EXT_swap_control")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate int wglGetSwapIntervalEXT();

		[RequiredByFeature("WGL_I3D_digital_video_control")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglGetDigitalVideoParametersI3D(nint hDC, int iAttribute, int* piValue);

		[RequiredByFeature("WGL_I3D_digital_video_control")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglSetDigitalVideoParametersI3D(nint hDC, int iAttribute, int* piValue);

		[RequiredByFeature("WGL_I3D_gamma")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglGetGammaTableParametersI3D(nint hDC, int iAttribute, int* piValue);

		[RequiredByFeature("WGL_I3D_gamma")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglSetGammaTableParametersI3D(nint hDC, int iAttribute, int* piValue);

		[RequiredByFeature("WGL_I3D_gamma")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglGetGammaTableI3D(nint hDC, int iEntries, ushort* puRed, ushort* puGreen, ushort* puBlue);

		[RequiredByFeature("WGL_I3D_gamma")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglSetGammaTableI3D(nint hDC, int iEntries, ushort* puRed, ushort* puGreen, ushort* puBlue);

		[RequiredByFeature("WGL_I3D_genlock")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglEnableGenlockI3D(nint hDC);

		[RequiredByFeature("WGL_I3D_genlock")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglDisableGenlockI3D(nint hDC);

		[RequiredByFeature("WGL_I3D_genlock")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglIsEnabledGenlockI3D(nint hDC, bool* pFlag);

		[RequiredByFeature("WGL_I3D_genlock")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglGenlockSourceI3D(nint hDC, uint uSource);

		[RequiredByFeature("WGL_I3D_genlock")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglGetGenlockSourceI3D(nint hDC, uint* uSource);

		[RequiredByFeature("WGL_I3D_genlock")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglGenlockSourceEdgeI3D(nint hDC, uint uEdge);

		[RequiredByFeature("WGL_I3D_genlock")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglGetGenlockSourceEdgeI3D(nint hDC, uint* uEdge);

		[RequiredByFeature("WGL_I3D_genlock")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglGenlockSampleRateI3D(nint hDC, uint uRate);

		[RequiredByFeature("WGL_I3D_genlock")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglGetGenlockSampleRateI3D(nint hDC, uint* uRate);

		[RequiredByFeature("WGL_I3D_genlock")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglGenlockSourceDelayI3D(nint hDC, uint uDelay);

		[RequiredByFeature("WGL_I3D_genlock")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglGetGenlockSourceDelayI3D(nint hDC, uint* uDelay);

		[RequiredByFeature("WGL_I3D_genlock")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglQueryGenlockMaxSourceDelayI3D(nint hDC, uint* uMaxLineDelay, uint* uMaxPixelDelay);

		[RequiredByFeature("WGL_I3D_image_buffer")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint wglCreateImageBufferI3D(nint hDC, int dwSize, uint uFlags);

		[RequiredByFeature("WGL_I3D_image_buffer")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglDestroyImageBufferI3D(nint hDC, nint pAddress);

		[RequiredByFeature("WGL_I3D_image_buffer")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglAssociateImageBufferEventsI3D(nint hDC, nint* pEvent, nint* pAddress, int* pSize, uint count);

		[RequiredByFeature("WGL_I3D_image_buffer")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglReleaseImageBufferEventsI3D(nint hDC, nint* pAddress, uint count);

		[RequiredByFeature("WGL_I3D_swap_frame_lock")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglEnableFrameLockI3D();

		[RequiredByFeature("WGL_I3D_swap_frame_lock")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglDisableFrameLockI3D();

		[RequiredByFeature("WGL_I3D_swap_frame_lock")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglIsEnabledFrameLockI3D(bool* pFlag);

		[RequiredByFeature("WGL_I3D_swap_frame_lock")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglQueryFrameLockMasterI3D(bool* pFlag);

		[RequiredByFeature("WGL_I3D_swap_frame_usage")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglGetFrameUsageI3D(float* pUsage);

		[RequiredByFeature("WGL_I3D_swap_frame_usage")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglBeginFrameTrackingI3D();

		[RequiredByFeature("WGL_I3D_swap_frame_usage")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglEndFrameTrackingI3D();

		[RequiredByFeature("WGL_I3D_swap_frame_usage")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglQueryFrameTrackingI3D(int* pFrameCount, int* pMissedFrames, float* pLastMissedUsage);

		[RequiredByFeature("WGL_NV_copy_image")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglCopyImageSubDataNV(nint hSrcRC, uint srcName, int srcTarget, int srcLevel, int srcX, int srcY, int srcZ, nint hDstRC, uint dstName, int dstTarget, int dstLevel, int dstX, int dstY, int dstZ, int width, int height, int depth);

		[RequiredByFeature("WGL_NV_delay_before_swap")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglDelayBeforeSwapNV(nint hDC, float seconds);

		[RequiredByFeature("WGL_NV_DX_interop")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglDXSetResourceShareHandleNV(nint dxObject, nint shareHandle);

		[RequiredByFeature("WGL_NV_DX_interop")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint wglDXOpenDeviceNV(nint dxDevice);

		[RequiredByFeature("WGL_NV_DX_interop")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglDXCloseDeviceNV(nint hDevice);

		[RequiredByFeature("WGL_NV_DX_interop")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint wglDXRegisterObjectNV(nint hDevice, nint dxObject, uint name, int type, int access);

		[RequiredByFeature("WGL_NV_DX_interop")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglDXUnregisterObjectNV(nint hDevice, nint hObject);

		[RequiredByFeature("WGL_NV_DX_interop")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglDXObjectAccessNV(nint hObject, int access);

		[RequiredByFeature("WGL_NV_DX_interop")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglDXLockObjectsNV(nint hDevice, int count, nint* hObjects);

		[RequiredByFeature("WGL_NV_DX_interop")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglDXUnlockObjectsNV(nint hDevice, int count, nint* hObjects);

		[RequiredByFeature("WGL_NV_gpu_affinity")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglEnumGpusNV(uint iGpuIndex, nint* phGpu);

		[RequiredByFeature("WGL_NV_gpu_affinity")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglEnumGpuDevicesNV(nint hGpu, uint iDeviceIndex, nint lpGpuDevice);

		[RequiredByFeature("WGL_NV_gpu_affinity")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate nint wglCreateAffinityDCNV(nint* phGpuList);

		[RequiredByFeature("WGL_NV_gpu_affinity")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglEnumGpusFromAffinityDCNV(nint hAffinityDC, uint iGpuIndex, nint* hGpu);

		[RequiredByFeature("WGL_NV_gpu_affinity")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglDeleteDCNV(nint hdc);

		[RequiredByFeature("WGL_NV_present_video")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate int wglEnumerateVideoDevicesNV(nint hDC, nint* phDeviceList);

		[RequiredByFeature("WGL_NV_present_video")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglBindVideoDeviceNV(nint hDC, uint uVideoSlot, nint hVideoDevice, int* piAttribList);

		[RequiredByFeature("WGL_NV_present_video")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglQueryCurrentContextNV(int iAttribute, int* piValue);

		[RequiredByFeature("WGL_NV_swap_group")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglJoinSwapGroupNV(nint hDC, uint group);

		[RequiredByFeature("WGL_NV_swap_group")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglBindSwapBarrierNV(uint group, uint barrier);

		[RequiredByFeature("WGL_NV_swap_group")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglQuerySwapGroupNV(nint hDC, uint* group, uint* barrier);

		[RequiredByFeature("WGL_NV_swap_group")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglQueryMaxSwapGroupsNV(nint hDC, uint* maxGroups, uint* maxBarriers);

		[RequiredByFeature("WGL_NV_swap_group")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglQueryFrameCountNV(nint hDC, uint* count);

		[RequiredByFeature("WGL_NV_swap_group")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglResetFrameCountNV(nint hDC);

		[RequiredByFeature("WGL_NV_vertex_array_range")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint wglAllocateMemoryNV(int size, float readfreq, float writefreq, float priority);

		[RequiredByFeature("WGL_NV_vertex_array_range")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate void wglFreeMemoryNV(nint pointer);

		[RequiredByFeature("WGL_NV_video_capture")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglBindVideoCaptureDeviceNV(uint uVideoSlot, nint hDevice);

		[RequiredByFeature("WGL_NV_video_capture")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate uint wglEnumerateVideoCaptureDevicesNV(nint hDc, nint* phDeviceList);

		[RequiredByFeature("WGL_NV_video_capture")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglLockVideoCaptureDeviceNV(nint hDc, nint hDevice);

		[RequiredByFeature("WGL_NV_video_capture")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglQueryVideoCaptureDeviceNV(nint hDc, nint hDevice, int iAttribute, int* piValue);

		[RequiredByFeature("WGL_NV_video_capture")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglReleaseVideoCaptureDeviceNV(nint hDc, nint hDevice);

		[RequiredByFeature("WGL_NV_video_output")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglGetVideoDeviceNV(nint hDC, int numDevices, nint* hVideoDevice);

		[RequiredByFeature("WGL_NV_video_output")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglReleaseVideoDeviceNV(nint hVideoDevice);

		[RequiredByFeature("WGL_NV_video_output")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglBindVideoImageNV(nint hVideoDevice, nint hPbuffer, int iVideoBuffer);

		[RequiredByFeature("WGL_NV_video_output")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglReleaseVideoImageNV(nint hPbuffer, int iVideoBuffer);

		[RequiredByFeature("WGL_NV_video_output")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglSendPbufferToVideoNV(nint hPbuffer, int iBufferType, uint* pulCounterPbuffer, bool bBlock);

		[RequiredByFeature("WGL_NV_video_output")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglGetVideoInfoNV(nint hpVideoDevice, uint* pulCounterOutputPbuffer, uint* pulCounterOutputVideo);

		[RequiredByFeature("WGL_OML_sync_control")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglGetSyncValuesOML(nint hdc, long* ust, long* msc, long* sbc);

		[RequiredByFeature("WGL_OML_sync_control")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglGetMscRateOML(nint hdc, int* numerator, int* denominator);

		[RequiredByFeature("WGL_OML_sync_control")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate long wglSwapBuffersMscOML(nint hdc, long target_msc, long divisor, long remainder);

		[RequiredByFeature("WGL_OML_sync_control")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate long wglSwapLayerBuffersMscOML(nint hdc, int fuPlanes, long target_msc, long divisor, long remainder);

		[RequiredByFeature("WGL_OML_sync_control")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglWaitForMscOML(nint hdc, long target_msc, long divisor, long remainder, long* ust, long* msc, long* sbc);

		[RequiredByFeature("WGL_OML_sync_control")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglWaitForSbcOML(nint hdc, long target_sbc, long* ust, long* msc, long* sbc);

		[RequiredByFeature("WGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglCopyContext(nint hglrcSrc, nint hglrcDst, uint mask);

		[RequiredByFeature("WGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint wglCreateContext(nint hDc);

		[RequiredByFeature("WGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint wglCreateLayerContext(nint hDc, int level);

		[RequiredByFeature("WGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglDeleteContext(nint oldContext);

		[RequiredByFeature("WGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe delegate bool wglDescribeLayerPlane(nint hDc, int pixelFormat, int layerPlane, uint nBytes, nint* plpd);

		[RequiredByFeature("WGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint wglGetCurrentContext();

		[RequiredByFeature("WGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint wglGetCurrentDC();

		[RequiredByFeature("WGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate int wglGetLayerPaletteEntries(nint hdc, int iLayerPlane, int iStart, int cEntries, nint pcr);

		[RequiredByFeature("WGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint wglGetProcAddress(string lpszProc);

		[RequiredByFeature("WGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglMakeCurrent(nint hDc, nint newContext);

		[RequiredByFeature("WGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglRealizeLayerPalette(nint hdc, int iLayerPlane, bool bRealize);

		[RequiredByFeature("WGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate int wglSetLayerPaletteEntries(nint hdc, int iLayerPlane, int iStart, int cEntries, nint pcr);

		[RequiredByFeature("WGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglShareLists(nint hrcSrvShare, nint hrcSrvSource);

		[RequiredByFeature("WGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglSwapLayerBuffers(nint hdc, uint fuFlags);

		[RequiredByFeature("WGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglUseFontBitmaps(nint hDC, int first, int count, int listBase);

		[RequiredByFeature("WGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglUseFontBitmapsA(nint hDC, int first, int count, int listBase);

		[RequiredByFeature("WGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglUseFontBitmapsW(nint hDC, int first, int count, int listBase);

		[RequiredByFeature("WGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglUseFontOutlines(nint hDC, int first, int count, int listBase, float deviation, float extrusion, int format, nint lpgmf);

		[RequiredByFeature("WGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglUseFontOutlinesA(nint hDC, int first, int count, int listBase, float deviation, float extrusion, int format, nint lpgmf);

		[RequiredByFeature("WGL_VERSION_1_0")]
		[SuppressUnmanagedCodeSecurity]
		internal delegate bool wglUseFontOutlinesW(nint hDC, int first, int count, int listBase, float deviation, float extrusion, int format, nint lpgmf);

		[RequiredByFeature("WGL_3DL_stereo_control")]
		internal static wglSetStereoEmitterState3DL pwglSetStereoEmitterState3DL;

		[RequiredByFeature("WGL_AMD_gpu_association")]
		internal static wglGetGPUIDsAMD pwglGetGPUIDsAMD;

		[RequiredByFeature("WGL_AMD_gpu_association")]
		internal static wglGetGPUInfoAMD pwglGetGPUInfoAMD;

		[RequiredByFeature("WGL_AMD_gpu_association")]
		internal static wglGetContextGPUIDAMD pwglGetContextGPUIDAMD;

		[RequiredByFeature("WGL_AMD_gpu_association")]
		internal static wglCreateAssociatedContextAMD pwglCreateAssociatedContextAMD;

		[RequiredByFeature("WGL_AMD_gpu_association")]
		internal static wglCreateAssociatedContextAttribsAMD pwglCreateAssociatedContextAttribsAMD;

		[RequiredByFeature("WGL_AMD_gpu_association")]
		internal static wglDeleteAssociatedContextAMD pwglDeleteAssociatedContextAMD;

		[RequiredByFeature("WGL_AMD_gpu_association")]
		internal static wglMakeAssociatedContextCurrentAMD pwglMakeAssociatedContextCurrentAMD;

		[RequiredByFeature("WGL_AMD_gpu_association")]
		internal static wglGetCurrentAssociatedContextAMD pwglGetCurrentAssociatedContextAMD;

		[RequiredByFeature("WGL_AMD_gpu_association")]
		internal static wglBlitContextFramebufferAMD pwglBlitContextFramebufferAMD;

		[RequiredByFeature("WGL_ARB_buffer_region")]
		internal static wglCreateBufferRegionARB pwglCreateBufferRegionARB;

		[RequiredByFeature("WGL_ARB_buffer_region")]
		internal static wglDeleteBufferRegionARB pwglDeleteBufferRegionARB;

		[RequiredByFeature("WGL_ARB_buffer_region")]
		internal static wglSaveBufferRegionARB pwglSaveBufferRegionARB;

		[RequiredByFeature("WGL_ARB_buffer_region")]
		internal static wglRestoreBufferRegionARB pwglRestoreBufferRegionARB;

		[RequiredByFeature("WGL_ARB_create_context")]
		internal static wglCreateContextAttribsARB pwglCreateContextAttribsARB;

		[RequiredByFeature("WGL_ARB_extensions_string")]
		internal static wglGetExtensionsStringARB pwglGetExtensionsStringARB;

		[RequiredByFeature("WGL_ARB_make_current_read")]
		internal static wglMakeContextCurrentARB pwglMakeContextCurrentARB;

		[RequiredByFeature("WGL_ARB_make_current_read")]
		internal static wglGetCurrentReadDCARB pwglGetCurrentReadDCARB;

		[RequiredByFeature("WGL_ARB_pbuffer")]
		internal static wglCreatePbufferARB pwglCreatePbufferARB;

		[RequiredByFeature("WGL_ARB_pbuffer")]
		internal static wglGetPbufferDCARB pwglGetPbufferDCARB;

		[RequiredByFeature("WGL_ARB_pbuffer")]
		internal static wglReleasePbufferDCARB pwglReleasePbufferDCARB;

		[RequiredByFeature("WGL_ARB_pbuffer")]
		internal static wglDestroyPbufferARB pwglDestroyPbufferARB;

		[RequiredByFeature("WGL_ARB_pbuffer")]
		internal static wglQueryPbufferARB pwglQueryPbufferARB;

		[RequiredByFeature("WGL_ARB_pixel_format")]
		internal static wglGetPixelFormatAttribivARB pwglGetPixelFormatAttribivARB;

		[RequiredByFeature("WGL_ARB_pixel_format")]
		internal static wglGetPixelFormatAttribfvARB pwglGetPixelFormatAttribfvARB;

		[RequiredByFeature("WGL_ARB_pixel_format")]
		internal static wglChoosePixelFormatARB pwglChoosePixelFormatARB;

		[RequiredByFeature("WGL_ARB_render_texture")]
		internal static wglBindTexImageARB pwglBindTexImageARB;

		[RequiredByFeature("WGL_ARB_render_texture")]
		internal static wglReleaseTexImageARB pwglReleaseTexImageARB;

		[RequiredByFeature("WGL_ARB_render_texture")]
		internal static wglSetPbufferAttribARB pwglSetPbufferAttribARB;

		[RequiredByFeature("WGL_EXT_display_color_table")]
		internal static wglCreateDisplayColorTableEXT pwglCreateDisplayColorTableEXT;

		[RequiredByFeature("WGL_EXT_display_color_table")]
		internal static wglLoadDisplayColorTableEXT pwglLoadDisplayColorTableEXT;

		[RequiredByFeature("WGL_EXT_display_color_table")]
		internal static wglBindDisplayColorTableEXT pwglBindDisplayColorTableEXT;

		[RequiredByFeature("WGL_EXT_display_color_table")]
		internal static wglDestroyDisplayColorTableEXT pwglDestroyDisplayColorTableEXT;

		[RequiredByFeature("WGL_EXT_extensions_string")]
		internal static wglGetExtensionsStringEXT pwglGetExtensionsStringEXT;

		[RequiredByFeature("WGL_EXT_make_current_read")]
		internal static wglMakeContextCurrentEXT pwglMakeContextCurrentEXT;

		[RequiredByFeature("WGL_EXT_make_current_read")]
		internal static wglGetCurrentReadDCEXT pwglGetCurrentReadDCEXT;

		[RequiredByFeature("WGL_EXT_pbuffer")]
		internal static wglCreatePbufferEXT pwglCreatePbufferEXT;

		[RequiredByFeature("WGL_EXT_pbuffer")]
		internal static wglGetPbufferDCEXT pwglGetPbufferDCEXT;

		[RequiredByFeature("WGL_EXT_pbuffer")]
		internal static wglReleasePbufferDCEXT pwglReleasePbufferDCEXT;

		[RequiredByFeature("WGL_EXT_pbuffer")]
		internal static wglDestroyPbufferEXT pwglDestroyPbufferEXT;

		[RequiredByFeature("WGL_EXT_pbuffer")]
		internal static wglQueryPbufferEXT pwglQueryPbufferEXT;

		[RequiredByFeature("WGL_EXT_pixel_format")]
		internal static wglGetPixelFormatAttribivEXT pwglGetPixelFormatAttribivEXT;

		[RequiredByFeature("WGL_EXT_pixel_format")]
		internal static wglGetPixelFormatAttribfvEXT pwglGetPixelFormatAttribfvEXT;

		[RequiredByFeature("WGL_EXT_pixel_format")]
		internal static wglChoosePixelFormatEXT pwglChoosePixelFormatEXT;

		[RequiredByFeature("WGL_EXT_swap_control")]
		internal static wglSwapIntervalEXT pwglSwapIntervalEXT;

		[RequiredByFeature("WGL_EXT_swap_control")]
		internal static wglGetSwapIntervalEXT pwglGetSwapIntervalEXT;

		[RequiredByFeature("WGL_I3D_digital_video_control")]
		internal static wglGetDigitalVideoParametersI3D pwglGetDigitalVideoParametersI3D;

		[RequiredByFeature("WGL_I3D_digital_video_control")]
		internal static wglSetDigitalVideoParametersI3D pwglSetDigitalVideoParametersI3D;

		[RequiredByFeature("WGL_I3D_gamma")]
		internal static wglGetGammaTableParametersI3D pwglGetGammaTableParametersI3D;

		[RequiredByFeature("WGL_I3D_gamma")]
		internal static wglSetGammaTableParametersI3D pwglSetGammaTableParametersI3D;

		[RequiredByFeature("WGL_I3D_gamma")]
		internal static wglGetGammaTableI3D pwglGetGammaTableI3D;

		[RequiredByFeature("WGL_I3D_gamma")]
		internal static wglSetGammaTableI3D pwglSetGammaTableI3D;

		[RequiredByFeature("WGL_I3D_genlock")]
		internal static wglEnableGenlockI3D pwglEnableGenlockI3D;

		[RequiredByFeature("WGL_I3D_genlock")]
		internal static wglDisableGenlockI3D pwglDisableGenlockI3D;

		[RequiredByFeature("WGL_I3D_genlock")]
		internal static wglIsEnabledGenlockI3D pwglIsEnabledGenlockI3D;

		[RequiredByFeature("WGL_I3D_genlock")]
		internal static wglGenlockSourceI3D pwglGenlockSourceI3D;

		[RequiredByFeature("WGL_I3D_genlock")]
		internal static wglGetGenlockSourceI3D pwglGetGenlockSourceI3D;

		[RequiredByFeature("WGL_I3D_genlock")]
		internal static wglGenlockSourceEdgeI3D pwglGenlockSourceEdgeI3D;

		[RequiredByFeature("WGL_I3D_genlock")]
		internal static wglGetGenlockSourceEdgeI3D pwglGetGenlockSourceEdgeI3D;

		[RequiredByFeature("WGL_I3D_genlock")]
		internal static wglGenlockSampleRateI3D pwglGenlockSampleRateI3D;

		[RequiredByFeature("WGL_I3D_genlock")]
		internal static wglGetGenlockSampleRateI3D pwglGetGenlockSampleRateI3D;

		[RequiredByFeature("WGL_I3D_genlock")]
		internal static wglGenlockSourceDelayI3D pwglGenlockSourceDelayI3D;

		[RequiredByFeature("WGL_I3D_genlock")]
		internal static wglGetGenlockSourceDelayI3D pwglGetGenlockSourceDelayI3D;

		[RequiredByFeature("WGL_I3D_genlock")]
		internal static wglQueryGenlockMaxSourceDelayI3D pwglQueryGenlockMaxSourceDelayI3D;

		[RequiredByFeature("WGL_I3D_image_buffer")]
		internal static wglCreateImageBufferI3D pwglCreateImageBufferI3D;

		[RequiredByFeature("WGL_I3D_image_buffer")]
		internal static wglDestroyImageBufferI3D pwglDestroyImageBufferI3D;

		[RequiredByFeature("WGL_I3D_image_buffer")]
		internal static wglAssociateImageBufferEventsI3D pwglAssociateImageBufferEventsI3D;

		[RequiredByFeature("WGL_I3D_image_buffer")]
		internal static wglReleaseImageBufferEventsI3D pwglReleaseImageBufferEventsI3D;

		[RequiredByFeature("WGL_I3D_swap_frame_lock")]
		internal static wglEnableFrameLockI3D pwglEnableFrameLockI3D;

		[RequiredByFeature("WGL_I3D_swap_frame_lock")]
		internal static wglDisableFrameLockI3D pwglDisableFrameLockI3D;

		[RequiredByFeature("WGL_I3D_swap_frame_lock")]
		internal static wglIsEnabledFrameLockI3D pwglIsEnabledFrameLockI3D;

		[RequiredByFeature("WGL_I3D_swap_frame_lock")]
		internal static wglQueryFrameLockMasterI3D pwglQueryFrameLockMasterI3D;

		[RequiredByFeature("WGL_I3D_swap_frame_usage")]
		internal static wglGetFrameUsageI3D pwglGetFrameUsageI3D;

		[RequiredByFeature("WGL_I3D_swap_frame_usage")]
		internal static wglBeginFrameTrackingI3D pwglBeginFrameTrackingI3D;

		[RequiredByFeature("WGL_I3D_swap_frame_usage")]
		internal static wglEndFrameTrackingI3D pwglEndFrameTrackingI3D;

		[RequiredByFeature("WGL_I3D_swap_frame_usage")]
		internal static wglQueryFrameTrackingI3D pwglQueryFrameTrackingI3D;

		[RequiredByFeature("WGL_NV_copy_image")]
		internal static wglCopyImageSubDataNV pwglCopyImageSubDataNV;

		[RequiredByFeature("WGL_NV_delay_before_swap")]
		internal static wglDelayBeforeSwapNV pwglDelayBeforeSwapNV;

		[RequiredByFeature("WGL_NV_DX_interop")]
		internal static wglDXSetResourceShareHandleNV pwglDXSetResourceShareHandleNV;

		[RequiredByFeature("WGL_NV_DX_interop")]
		internal static wglDXOpenDeviceNV pwglDXOpenDeviceNV;

		[RequiredByFeature("WGL_NV_DX_interop")]
		internal static wglDXCloseDeviceNV pwglDXCloseDeviceNV;

		[RequiredByFeature("WGL_NV_DX_interop")]
		internal static wglDXRegisterObjectNV pwglDXRegisterObjectNV;

		[RequiredByFeature("WGL_NV_DX_interop")]
		internal static wglDXUnregisterObjectNV pwglDXUnregisterObjectNV;

		[RequiredByFeature("WGL_NV_DX_interop")]
		internal static wglDXObjectAccessNV pwglDXObjectAccessNV;

		[RequiredByFeature("WGL_NV_DX_interop")]
		internal static wglDXLockObjectsNV pwglDXLockObjectsNV;

		[RequiredByFeature("WGL_NV_DX_interop")]
		internal static wglDXUnlockObjectsNV pwglDXUnlockObjectsNV;

		[RequiredByFeature("WGL_NV_gpu_affinity")]
		internal static wglEnumGpusNV pwglEnumGpusNV;

		[RequiredByFeature("WGL_NV_gpu_affinity")]
		internal static wglEnumGpuDevicesNV pwglEnumGpuDevicesNV;

		[RequiredByFeature("WGL_NV_gpu_affinity")]
		internal static wglCreateAffinityDCNV pwglCreateAffinityDCNV;

		[RequiredByFeature("WGL_NV_gpu_affinity")]
		internal static wglEnumGpusFromAffinityDCNV pwglEnumGpusFromAffinityDCNV;

		[RequiredByFeature("WGL_NV_gpu_affinity")]
		internal static wglDeleteDCNV pwglDeleteDCNV;

		[RequiredByFeature("WGL_NV_present_video")]
		internal static wglEnumerateVideoDevicesNV pwglEnumerateVideoDevicesNV;

		[RequiredByFeature("WGL_NV_present_video")]
		internal static wglBindVideoDeviceNV pwglBindVideoDeviceNV;

		[RequiredByFeature("WGL_NV_present_video")]
		internal static wglQueryCurrentContextNV pwglQueryCurrentContextNV;

		[RequiredByFeature("WGL_NV_swap_group")]
		internal static wglJoinSwapGroupNV pwglJoinSwapGroupNV;

		[RequiredByFeature("WGL_NV_swap_group")]
		internal static wglBindSwapBarrierNV pwglBindSwapBarrierNV;

		[RequiredByFeature("WGL_NV_swap_group")]
		internal static wglQuerySwapGroupNV pwglQuerySwapGroupNV;

		[RequiredByFeature("WGL_NV_swap_group")]
		internal static wglQueryMaxSwapGroupsNV pwglQueryMaxSwapGroupsNV;

		[RequiredByFeature("WGL_NV_swap_group")]
		internal static wglQueryFrameCountNV pwglQueryFrameCountNV;

		[RequiredByFeature("WGL_NV_swap_group")]
		internal static wglResetFrameCountNV pwglResetFrameCountNV;

		[RequiredByFeature("WGL_NV_vertex_array_range")]
		internal static wglAllocateMemoryNV pwglAllocateMemoryNV;

		[RequiredByFeature("WGL_NV_vertex_array_range")]
		internal static wglFreeMemoryNV pwglFreeMemoryNV;

		[RequiredByFeature("WGL_NV_video_capture")]
		internal static wglBindVideoCaptureDeviceNV pwglBindVideoCaptureDeviceNV;

		[RequiredByFeature("WGL_NV_video_capture")]
		internal static wglEnumerateVideoCaptureDevicesNV pwglEnumerateVideoCaptureDevicesNV;

		[RequiredByFeature("WGL_NV_video_capture")]
		internal static wglLockVideoCaptureDeviceNV pwglLockVideoCaptureDeviceNV;

		[RequiredByFeature("WGL_NV_video_capture")]
		internal static wglQueryVideoCaptureDeviceNV pwglQueryVideoCaptureDeviceNV;

		[RequiredByFeature("WGL_NV_video_capture")]
		internal static wglReleaseVideoCaptureDeviceNV pwglReleaseVideoCaptureDeviceNV;

		[RequiredByFeature("WGL_NV_video_output")]
		internal static wglGetVideoDeviceNV pwglGetVideoDeviceNV;

		[RequiredByFeature("WGL_NV_video_output")]
		internal static wglReleaseVideoDeviceNV pwglReleaseVideoDeviceNV;

		[RequiredByFeature("WGL_NV_video_output")]
		internal static wglBindVideoImageNV pwglBindVideoImageNV;

		[RequiredByFeature("WGL_NV_video_output")]
		internal static wglReleaseVideoImageNV pwglReleaseVideoImageNV;

		[RequiredByFeature("WGL_NV_video_output")]
		internal static wglSendPbufferToVideoNV pwglSendPbufferToVideoNV;

		[RequiredByFeature("WGL_NV_video_output")]
		internal static wglGetVideoInfoNV pwglGetVideoInfoNV;

		[RequiredByFeature("WGL_OML_sync_control")]
		internal static wglGetSyncValuesOML pwglGetSyncValuesOML;

		[RequiredByFeature("WGL_OML_sync_control")]
		internal static wglGetMscRateOML pwglGetMscRateOML;

		[RequiredByFeature("WGL_OML_sync_control")]
		internal static wglSwapBuffersMscOML pwglSwapBuffersMscOML;

		[RequiredByFeature("WGL_OML_sync_control")]
		internal static wglSwapLayerBuffersMscOML pwglSwapLayerBuffersMscOML;

		[RequiredByFeature("WGL_OML_sync_control")]
		internal static wglWaitForMscOML pwglWaitForMscOML;

		[RequiredByFeature("WGL_OML_sync_control")]
		internal static wglWaitForSbcOML pwglWaitForSbcOML;

		[RequiredByFeature("WGL_VERSION_1_0")]
		internal static wglCopyContext pwglCopyContext;

		[RequiredByFeature("WGL_VERSION_1_0")]
		internal static wglCreateContext pwglCreateContext;

		[RequiredByFeature("WGL_VERSION_1_0")]
		internal static wglCreateLayerContext pwglCreateLayerContext;

		[RequiredByFeature("WGL_VERSION_1_0")]
		internal static wglDeleteContext pwglDeleteContext;

		[RequiredByFeature("WGL_VERSION_1_0")]
		internal static wglDescribeLayerPlane pwglDescribeLayerPlane;

		[RequiredByFeature("WGL_VERSION_1_0")]
		internal static wglGetCurrentContext pwglGetCurrentContext;

		[RequiredByFeature("WGL_VERSION_1_0")]
		internal static wglGetCurrentDC pwglGetCurrentDC;

		[RequiredByFeature("WGL_VERSION_1_0")]
		internal static wglGetLayerPaletteEntries pwglGetLayerPaletteEntries;

		[RequiredByFeature("WGL_VERSION_1_0")]
		internal static wglGetProcAddress pwglGetProcAddress;

		[RequiredByFeature("WGL_VERSION_1_0")]
		internal static wglMakeCurrent pwglMakeCurrent;

		[RequiredByFeature("WGL_VERSION_1_0")]
		internal static wglRealizeLayerPalette pwglRealizeLayerPalette;

		[RequiredByFeature("WGL_VERSION_1_0")]
		internal static wglSetLayerPaletteEntries pwglSetLayerPaletteEntries;

		[RequiredByFeature("WGL_VERSION_1_0")]
		internal static wglShareLists pwglShareLists;

		[RequiredByFeature("WGL_VERSION_1_0")]
		internal static wglSwapLayerBuffers pwglSwapLayerBuffers;

		[RequiredByFeature("WGL_VERSION_1_0")]
		internal static wglUseFontBitmaps pwglUseFontBitmaps;

		[RequiredByFeature("WGL_VERSION_1_0")]
		internal static wglUseFontBitmapsA pwglUseFontBitmapsA;

		[RequiredByFeature("WGL_VERSION_1_0")]
		internal static wglUseFontBitmapsW pwglUseFontBitmapsW;

		[RequiredByFeature("WGL_VERSION_1_0")]
		internal static wglUseFontOutlines pwglUseFontOutlines;

		[RequiredByFeature("WGL_VERSION_1_0")]
		internal static wglUseFontOutlinesA pwglUseFontOutlinesA;

		[RequiredByFeature("WGL_VERSION_1_0")]
		internal static wglUseFontOutlinesW pwglUseFontOutlinesW;
	}

	public enum ErrorHandlingMode
	{
		Normal,
		LogOnly,
		Ignore
	}

	public static class UnsafeNativeMethods
	{
		[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern int ChoosePixelFormat(nint deviceContext, [In] ref PIXELFORMATDESCRIPTOR pixelFormatDescriptor);

		[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern int DescribePixelFormat(nint hdc, int iPixelFormat, uint nBytes, [In][Out] ref PIXELFORMATDESCRIPTOR ppfd);

		[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern bool SetPixelFormat(nint deviceContext, int pixelFormat, ref PIXELFORMATDESCRIPTOR pixelFormatDescriptor);

		[DllImport("gdi32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "SwapBuffers")]
		public static extern int GdiSwapBuffersFast([In] nint deviceContext);

		[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
		public static extern nint GetDC(nint windowHandle);

		[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
		public static extern bool ReleaseDC(nint windowHandle, nint deviceContext);
	}

	public struct DISPLAY_DEVICE
	{
		[MarshalAs(UnmanagedType.U4)]
		public int cb;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string DeviceName;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public string DeviceString;

		[MarshalAs(UnmanagedType.U4)]
		public DisplayDeviceStateFlags StateFlags;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public string DeviceID;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public string DeviceKey;
	}

	[Flags]
	public enum DisplayDeviceStateFlags
	{
		AttachedToDesktop = 1,
		MultiDriver = 2,
		PrimaryDevice = 4,
		MirroringDriver = 8,
		VGACompatible = 0x16,
		Removable = 0x20,
		ModesPruned = 0x8000000,
		Remote = 0x4000000,
		Disconnect = 0x2000000
	}

	public enum PixelFormatDescriptorLayerType : byte
	{
		Main = 0,
		Overlay = 1,
		Underlay = byte.MaxValue
	}

	[Flags]
	public enum PixelFormatDescriptorFlags
	{
		None = 0,
		Doublebuffer = 1,
		Stereo = 2,
		DrawToWindow = 4,
		DrawToBitmap = 8,
		SupportGdi = 0x10,
		SupportOpenGL = 0x20,
		GenericFormat = 0x40,
		NeedPalette = 0x80,
		NeedSystemPalette = 0x100,
		SwapExchange = 0x200,
		SwapCopy = 0x400,
		SwapLayerBuffers = 0x800,
		GenericAccelerated = 0x1000,
		SupportDirectDraw = 0x2000,
		Direct3dAccelerated = 0x4000,
		SupportComposition = 0x8000,
		DepthDontCare = 0x20000000,
		DoublebufferDontCare = 0x40000000,
		StereoDontCare = int.MinValue
	}

	public enum PixelFormatDescriptorPixelType : byte
	{
		Rgba,
		ColorIndexed
	}

	public struct PIXELFORMATDESCRIPTOR
	{
		public short nSize;

		public short nVersion;

		public PixelFormatDescriptorFlags dwFlags;

		public PixelFormatDescriptorPixelType iPixelType;

		public byte cColorBits;

		public byte cRedBits;

		public byte cRedShift;

		public byte cGreenBits;

		public byte cGreenShift;

		public byte cBlueBits;

		public byte cBlueShift;

		public byte cAlphaBits;

		public byte cAlphaShift;

		public byte cAccumBits;

		public byte cAccumRedBits;

		public byte cAccumGreenBits;

		public byte cAccumBlueBits;

		public byte cAccumAlphaBits;

		public byte cDepthBits;

		public byte cStencilBits;

		public byte cAuxBuffers;

		public PixelFormatDescriptorLayerType iLayerType;

		public byte bReserved;

		public int dwLayerMask;

		public int dwVisibleMask;

		public int dwDamageMask;

		public PIXELFORMATDESCRIPTOR(byte colorBits)
		{
			nVersion = 1;
			nSize = (short)Marshal.SizeOf(typeof(PIXELFORMATDESCRIPTOR));
			iLayerType = PixelFormatDescriptorLayerType.Main;
			dwFlags = PixelFormatDescriptorFlags.Doublebuffer | PixelFormatDescriptorFlags.DrawToWindow | PixelFormatDescriptorFlags.SupportOpenGL;
			iPixelType = PixelFormatDescriptorPixelType.Rgba;
			dwLayerMask = 0;
			dwVisibleMask = 0;
			dwDamageMask = 0;
			cAuxBuffers = 0;
			bReserved = 0;
			cColorBits = colorBits;
			cRedBits = 0;
			cRedShift = 0;
			cGreenBits = 0;
			cGreenShift = 0;
			cBlueBits = 0;
			cBlueShift = 0;
			cAlphaBits = 0;
			cAlphaShift = 0;
			cDepthBits = 0;
			cStencilBits = 0;
			cAccumBits = 0;
			cAccumRedBits = 0;
			cAccumGreenBits = 0;
			cAccumBlueBits = 0;
			cAccumAlphaBits = 0;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("PIXELFORMATDESCRIPTOR={");
			stringBuilder.AppendFormat("PixelType={0},", iPixelType);
			if (cColorBits != 0)
			{
				stringBuilder.AppendFormat("ColorBits={0},", cColorBits);
			}
			if (cDepthBits != 0)
			{
				stringBuilder.AppendFormat("DepthBits={0},", cDepthBits);
			}
			if (cStencilBits != 0)
			{
				stringBuilder.AppendFormat("StencilBits={0},", cStencilBits);
			}
			stringBuilder.AppendFormat("Flags={0},", dwFlags);
			stringBuilder.Remove(stringBuilder.Length - 1, 1);
			stringBuilder.Append("}");
			return stringBuilder.ToString();
		}
	}

	public class Extensions : ExtensionsCollection
	{
		[Extension("WGL_ARB_buffer_region")]
		public bool BufferRegion_ARB;

		[Extension("WGL_ARB_multisample")]
		public bool Multisample_ARB;

		[Extension("WGL_ARB_extensions_string")]
		public bool ExtensionsString_ARB;

		[Extension("WGL_ARB_pixel_format")]
		public bool PixelFormat_ARB;

		[Extension("WGL_ARB_make_current_read")]
		public bool MakeCurrentRead_ARB;

		[Extension("WGL_ARB_pbuffer")]
		public bool Pbuffer_ARB;

		[Extension("WGL_ARB_render_texture")]
		public bool RenderTexture_ARB;

		[Extension("WGL_ARB_pixel_format_float")]
		public bool PixelFormatFloat_ARB;

		[Extension("WGL_ARB_framebuffer_sRGB")]
		public bool FramebufferSRGB_ARB;

		[Extension("WGL_ARB_create_context")]
		public bool CreateContext_ARB;

		[Extension("WGL_ARB_create_context_profile")]
		public bool CreateContextProfile_ARB;

		[Extension("WGL_ARB_create_context_robustness")]
		public bool CreateContextRobustness_ARB;

		[Extension("WGL_ARB_robustness_application_isolation")]
		[Extension("WGL_ARB_robustness_share_group_isolation")]
		public bool RobustnessApplicationIsolation_ARB;

		[Extension("WGL_ARB_context_flush_control")]
		public bool ContextFlushControl_ARB;

		[Extension("WGL_ARB_create_context_no_error")]
		public bool CreateContextNoError_ARB;

		[Extension("WGL_EXT_display_color_table")]
		public bool DisplayColorTable_EXT;

		[Extension("WGL_EXT_extensions_string")]
		public bool ExtensionsString_EXT;

		[Extension("WGL_EXT_make_current_read")]
		public bool MakeCurrentRead_EXT;

		[Extension("WGL_EXT_pixel_format")]
		public bool PixelFormat_EXT;

		[Extension("WGL_EXT_pbuffer")]
		public bool Pbuffer_EXT;

		[Extension("WGL_EXT_swap_control")]
		public bool SwapControl_EXT;

		[Extension("WGL_EXT_depth_float")]
		public bool DepthFloat_EXT;

		[Extension("WGL_EXT_multisample")]
		public bool Multisample_EXT;

		[Extension("WGL_OML_sync_control")]
		public bool SyncControl_OML;

		[Extension("WGL_I3D_digital_video_control")]
		public bool DigitalVideoControl_I3D;

		[Extension("WGL_I3D_gamma")]
		public bool Gamma_I3D;

		[Extension("WGL_I3D_genlock")]
		public bool Genlock_I3D;

		[Extension("WGL_I3D_image_buffer")]
		public bool ImageBuffer_I3D;

		[Extension("WGL_I3D_swap_frame_lock")]
		public bool SwapFrameLock_I3D;

		[Extension("WGL_I3D_swap_frame_usage")]
		public bool SwapFrameUsage_I3D;

		[Extension("WGL_NV_render_depth_texture")]
		public bool RenderDepthTexture_NV;

		[Extension("WGL_NV_render_texture_rectangle")]
		public bool RenderTextureRectangle_NV;

		[Extension("WGL_ATI_pixel_format_float")]
		public bool PixelFormatFloat_ATI;

		[Extension("WGL_NV_float_buffer")]
		public bool FloatBuffer_NV;

		[Extension("WGL_3DL_stereo_control")]
		public bool StereoControl_3DL;

		[Extension("WGL_EXT_pixel_format_packed_float")]
		public bool PixelFormatPackedFloat_EXT;

		[Extension("WGL_EXT_framebuffer_sRGB")]
		public bool FramebufferSRGB_EXT;

		[Extension("WGL_NV_present_video")]
		public bool PresentVideo_NV;

		[Extension("WGL_NV_video_output")]
		public bool VideoOutput_NV;

		[Extension("WGL_NV_swap_group")]
		public bool SwapGroup_NV;

		[Extension("WGL_NV_gpu_affinity")]
		public bool GpuAffinity_NV;

		[Extension("WGL_AMD_gpu_association")]
		public bool GpuAssociation_AMD;

		[Extension("WGL_NV_video_capture")]
		public bool VideoCapture_NV;

		[Extension("WGL_NV_copy_image")]
		public bool CopyImage_NV;

		[Extension("WGL_EXT_create_context_es_profile")]
		[Extension("WGL_EXT_create_context_es2_profile")]
		public bool CreateContextEsProfile_EXT;

		[Extension("WGL_NV_DX_interop")]
		public bool DXInterop_NV;

		[Extension("WGL_NV_DX_interop2")]
		public bool DXInterop2_NV;

		[Extension("WGL_EXT_swap_control_tear")]
		public bool SwapControlTear_EXT;

		[Extension("WGL_NV_delay_before_swap")]
		public bool DelayBeforeSwap_NV;

		[Extension("WGL_3DFX_multisample")]
		public bool Multisample_3DFX;

		[Extension("WGL_NV_multisample_coverage")]
		public bool MultisampleCoverage_NV;

		[Extension("WGL_ATI_render_texture_rectangle")]
		public bool RenderTextureRectangle_ATI;

		[Extension("WGL_NV_vertex_array_range")]
		public bool VertexArrayRange_NV;

		[Extension("WGL_EXT_colorspace")]
		public bool Colorspace_EXT;

		internal void Query(DeviceContextWGL deviceContext)
		{
			if (deviceContext == null)
			{
				throw new ArgumentNullException("deviceContext");
			}
			Khronos.KhronosApi.LogComment("Query WGL extensions.");
			string text = null;
			Khronos.KhronosApi.BindAPIFunction<Wgl>("opengl32.dll", "wglGetExtensionsStringARB", KhronosApi.GetProcAddressGL, null, null);
			Khronos.KhronosApi.BindAPIFunction<Wgl>("opengl32.dll", "wglGetExtensionsStringEXT", KhronosApi.GetProcAddressGL, null, null);
			if (Delegates.pwglGetExtensionsStringARB != null)
			{
				text = GetExtensionsStringARB(deviceContext.DeviceContext);
			}
			else if (Delegates.pwglGetExtensionsStringEXT != null)
			{
				text = GetExtensionsStringEXT();
			}
			Query(Version_100, text ?? string.Empty);
		}

		public Extensions Clone()
		{
			return (Extensions)MemberwiseClone();
		}
	}

	[RequiredByFeature("WGL_3DFX_multisample")]
	public const int SAMPLE_BUFFERS_3DFX = 8288;

	[RequiredByFeature("WGL_3DFX_multisample")]
	public const int SAMPLES_3DFX = 8289;

	[RequiredByFeature("WGL_3DL_stereo_control")]
	public const int STEREO_EMITTER_ENABLE_3DL = 8277;

	[RequiredByFeature("WGL_3DL_stereo_control")]
	public const int STEREO_EMITTER_DISABLE_3DL = 8278;

	[RequiredByFeature("WGL_3DL_stereo_control")]
	public const int STEREO_POLARITY_NORMAL_3DL = 8279;

	[RequiredByFeature("WGL_3DL_stereo_control")]
	public const int STEREO_POLARITY_INVERT_3DL = 8280;

	[RequiredByFeature("WGL_AMD_gpu_association")]
	public const int GPU_VENDOR_AMD = 7936;

	[RequiredByFeature("WGL_AMD_gpu_association")]
	public const int GPU_RENDERER_STRING_AMD = 7937;

	[RequiredByFeature("WGL_AMD_gpu_association")]
	public const int GPU_OPENGL_VERSION_STRING_AMD = 7938;

	[RequiredByFeature("WGL_AMD_gpu_association")]
	public const int GPU_FASTEST_TARGET_GPUS_AMD = 8610;

	[RequiredByFeature("WGL_AMD_gpu_association")]
	public const int GPU_RAM_AMD = 8611;

	[RequiredByFeature("WGL_AMD_gpu_association")]
	public const int GPU_CLOCK_AMD = 8612;

	[RequiredByFeature("WGL_AMD_gpu_association")]
	public const int GPU_NUM_PIPES_AMD = 8613;

	[RequiredByFeature("WGL_AMD_gpu_association")]
	public const int GPU_NUM_SIMD_AMD = 8614;

	[RequiredByFeature("WGL_AMD_gpu_association")]
	public const int GPU_NUM_RB_AMD = 8615;

	[RequiredByFeature("WGL_AMD_gpu_association")]
	public const int GPU_NUM_SPI_AMD = 8616;

	[RequiredByFeature("WGL_ARB_buffer_region")]
	[Log(BitmaskName = "WGLColorBufferMask")]
	public const uint FRONT_COLOR_BUFFER_BIT_ARB = 1u;

	[RequiredByFeature("WGL_ARB_buffer_region")]
	[Log(BitmaskName = "WGLColorBufferMask")]
	public const uint BACK_COLOR_BUFFER_BIT_ARB = 2u;

	[RequiredByFeature("WGL_ARB_buffer_region")]
	[Log(BitmaskName = "WGLColorBufferMask")]
	public const uint DEPTH_BUFFER_BIT_ARB = 4u;

	[RequiredByFeature("WGL_ARB_buffer_region")]
	[Log(BitmaskName = "WGLColorBufferMask")]
	public const uint STENCIL_BUFFER_BIT_ARB = 8u;

	[RequiredByFeature("WGL_ARB_context_flush_control")]
	public const int CONTEXT_RELEASE_BEHAVIOR_ARB = 8343;

	[RequiredByFeature("WGL_ARB_context_flush_control")]
	public const int CONTEXT_RELEASE_BEHAVIOR_NONE_ARB = 0;

	[RequiredByFeature("WGL_ARB_context_flush_control")]
	public const int CONTEXT_RELEASE_BEHAVIOR_FLUSH_ARB = 8344;

	[RequiredByFeature("WGL_ARB_create_context")]
	[Log(BitmaskName = "WGLContextFlagsMask")]
	public const uint CONTEXT_DEBUG_BIT_ARB = 1u;

	[RequiredByFeature("WGL_ARB_create_context")]
	[Log(BitmaskName = "WGLContextFlagsMask")]
	public const uint CONTEXT_FORWARD_COMPATIBLE_BIT_ARB = 2u;

	[RequiredByFeature("WGL_ARB_create_context")]
	public const int CONTEXT_MAJOR_VERSION_ARB = 8337;

	[RequiredByFeature("WGL_ARB_create_context")]
	public const int CONTEXT_MINOR_VERSION_ARB = 8338;

	[RequiredByFeature("WGL_ARB_create_context")]
	public const int CONTEXT_LAYER_PLANE_ARB = 8339;

	[RequiredByFeature("WGL_ARB_create_context")]
	public const int CONTEXT_FLAGS_ARB = 8340;

	[RequiredByFeature("WGL_ARB_create_context")]
	public const int ERROR_INVALID_VERSION_ARB = 8341;

	[RequiredByFeature("WGL_ARB_create_context_no_error")]
	public const int CONTEXT_OPENGL_NO_ERROR_ARB = 12723;

	[RequiredByFeature("WGL_ARB_create_context_profile")]
	public const int CONTEXT_PROFILE_MASK_ARB = 37158;

	[RequiredByFeature("WGL_ARB_create_context_profile")]
	[Log(BitmaskName = "WGLContextProfileMask")]
	public const uint CONTEXT_CORE_PROFILE_BIT_ARB = 1u;

	[RequiredByFeature("WGL_ARB_create_context_profile")]
	[Log(BitmaskName = "WGLContextProfileMask")]
	public const uint CONTEXT_COMPATIBILITY_PROFILE_BIT_ARB = 2u;

	[RequiredByFeature("WGL_ARB_create_context_profile")]
	public const int ERROR_INVALID_PROFILE_ARB = 8342;

	[RequiredByFeature("WGL_ARB_create_context_robustness")]
	[Log(BitmaskName = "WGLContextFlagsMask")]
	public const uint CONTEXT_ROBUST_ACCESS_BIT_ARB = 4u;

	[RequiredByFeature("WGL_ARB_create_context_robustness")]
	public const int LOSE_CONTEXT_ON_RESET_ARB = 33362;

	[RequiredByFeature("WGL_ARB_create_context_robustness")]
	public const int CONTEXT_RESET_NOTIFICATION_STRATEGY_ARB = 33366;

	[RequiredByFeature("WGL_ARB_create_context_robustness")]
	public const int NO_RESET_NOTIFICATION_ARB = 33377;

	[RequiredByFeature("WGL_ARB_framebuffer_sRGB")]
	[RequiredByFeature("WGL_EXT_framebuffer_sRGB")]
	public const int FRAMEBUFFER_SRGB_CAPABLE_ARB = 8361;

	[RequiredByFeature("WGL_ARB_make_current_read")]
	[RequiredByFeature("WGL_EXT_make_current_read")]
	public const int ERROR_INVALID_PIXEL_TYPE_ARB = 8259;

	[RequiredByFeature("WGL_ARB_make_current_read")]
	public const int ERROR_INCOMPATIBLE_DEVICE_CONTEXTS_ARB = 8276;

	[RequiredByFeature("WGL_ARB_multisample")]
	[RequiredByFeature("WGL_EXT_multisample")]
	public const int SAMPLE_BUFFERS_ARB = 8257;

	[RequiredByFeature("WGL_ARB_multisample")]
	[RequiredByFeature("WGL_EXT_multisample")]
	public const int SAMPLES_ARB = 8258;

	[RequiredByFeature("WGL_ARB_pbuffer")]
	[RequiredByFeature("WGL_EXT_pbuffer")]
	public const int DRAW_TO_PBUFFER_ARB = 8237;

	[RequiredByFeature("WGL_ARB_pbuffer")]
	[RequiredByFeature("WGL_EXT_pbuffer")]
	public const int MAX_PBUFFER_PIXELS_ARB = 8238;

	[RequiredByFeature("WGL_ARB_pbuffer")]
	[RequiredByFeature("WGL_EXT_pbuffer")]
	public const int MAX_PBUFFER_WIDTH_ARB = 8239;

	[RequiredByFeature("WGL_ARB_pbuffer")]
	[RequiredByFeature("WGL_EXT_pbuffer")]
	public const int MAX_PBUFFER_HEIGHT_ARB = 8240;

	[RequiredByFeature("WGL_ARB_pbuffer")]
	[RequiredByFeature("WGL_EXT_pbuffer")]
	public const int PBUFFER_LARGEST_ARB = 8243;

	[RequiredByFeature("WGL_ARB_pbuffer")]
	[RequiredByFeature("WGL_EXT_pbuffer")]
	public const int PBUFFER_WIDTH_ARB = 8244;

	[RequiredByFeature("WGL_ARB_pbuffer")]
	[RequiredByFeature("WGL_EXT_pbuffer")]
	public const int PBUFFER_HEIGHT_ARB = 8245;

	[RequiredByFeature("WGL_ARB_pbuffer")]
	public const int PBUFFER_LOST_ARB = 8246;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int NUMBER_PIXEL_FORMATS_ARB = 8192;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int DRAW_TO_WINDOW_ARB = 8193;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int DRAW_TO_BITMAP_ARB = 8194;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int ACCELERATION_ARB = 8195;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int NEED_PALETTE_ARB = 8196;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int NEED_SYSTEM_PALETTE_ARB = 8197;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int SWAP_LAYER_BUFFERS_ARB = 8198;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int SWAP_METHOD_ARB = 8199;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int NUMBER_OVERLAYS_ARB = 8200;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int NUMBER_UNDERLAYS_ARB = 8201;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int TRANSPARENT_ARB = 8202;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	public const int TRANSPARENT_RED_VALUE_ARB = 8247;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	public const int TRANSPARENT_GREEN_VALUE_ARB = 8248;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	public const int TRANSPARENT_BLUE_VALUE_ARB = 8249;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	public const int TRANSPARENT_ALPHA_VALUE_ARB = 8250;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	public const int TRANSPARENT_INDEX_VALUE_ARB = 8251;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int SHARE_DEPTH_ARB = 8204;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int SHARE_STENCIL_ARB = 8205;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int SHARE_ACCUM_ARB = 8206;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int SUPPORT_GDI_ARB = 8207;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int SUPPORT_OPENGL_ARB = 8208;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int DOUBLE_BUFFER_ARB = 8209;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int STEREO_ARB = 8210;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int PIXEL_TYPE_ARB = 8211;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int COLOR_BITS_ARB = 8212;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int RED_BITS_ARB = 8213;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int RED_SHIFT_ARB = 8214;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int GREEN_BITS_ARB = 8215;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int GREEN_SHIFT_ARB = 8216;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int BLUE_BITS_ARB = 8217;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int BLUE_SHIFT_ARB = 8218;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int ALPHA_BITS_ARB = 8219;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int ALPHA_SHIFT_ARB = 8220;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int ACCUM_BITS_ARB = 8221;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int ACCUM_RED_BITS_ARB = 8222;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int ACCUM_GREEN_BITS_ARB = 8223;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int ACCUM_BLUE_BITS_ARB = 8224;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int ACCUM_ALPHA_BITS_ARB = 8225;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int DEPTH_BITS_ARB = 8226;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int STENCIL_BITS_ARB = 8227;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int AUX_BUFFERS_ARB = 8228;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int NO_ACCELERATION_ARB = 8229;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int GENERIC_ACCELERATION_ARB = 8230;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int FULL_ACCELERATION_ARB = 8231;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int SWAP_EXCHANGE_ARB = 8232;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int SWAP_COPY_ARB = 8233;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int SWAP_UNDEFINED_ARB = 8234;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int TYPE_RGBA_ARB = 8235;

	[RequiredByFeature("WGL_ARB_pixel_format")]
	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int TYPE_COLORINDEX_ARB = 8236;

	[RequiredByFeature("WGL_ARB_pixel_format_float")]
	[RequiredByFeature("WGL_ATI_pixel_format_float")]
	public const int TYPE_RGBA_FLOAT_ARB = 8608;

	[RequiredByFeature("WGL_ARB_render_texture")]
	public const int BIND_TO_TEXTURE_RGB_ARB = 8304;

	[RequiredByFeature("WGL_ARB_render_texture")]
	public const int BIND_TO_TEXTURE_RGBA_ARB = 8305;

	[RequiredByFeature("WGL_ARB_render_texture")]
	public const int TEXTURE_FORMAT_ARB = 8306;

	[RequiredByFeature("WGL_ARB_render_texture")]
	public const int TEXTURE_TARGET_ARB = 8307;

	[RequiredByFeature("WGL_ARB_render_texture")]
	public const int MIPMAP_TEXTURE_ARB = 8308;

	[RequiredByFeature("WGL_ARB_render_texture")]
	public const int TEXTURE_RGB_ARB = 8309;

	[RequiredByFeature("WGL_ARB_render_texture")]
	public const int TEXTURE_RGBA_ARB = 8310;

	[RequiredByFeature("WGL_ARB_render_texture")]
	public const int NO_TEXTURE_ARB = 8311;

	[RequiredByFeature("WGL_ARB_render_texture")]
	public const int TEXTURE_CUBE_MAP_ARB = 8312;

	[RequiredByFeature("WGL_ARB_render_texture")]
	public const int TEXTURE_1D_ARB = 8313;

	[RequiredByFeature("WGL_ARB_render_texture")]
	public const int TEXTURE_2D_ARB = 8314;

	[RequiredByFeature("WGL_ARB_render_texture")]
	public const int MIPMAP_LEVEL_ARB = 8315;

	[RequiredByFeature("WGL_ARB_render_texture")]
	public const int CUBE_MAP_FACE_ARB = 8316;

	[RequiredByFeature("WGL_ARB_render_texture")]
	public const int TEXTURE_CUBE_MAP_POSITIVE_X_ARB = 8317;

	[RequiredByFeature("WGL_ARB_render_texture")]
	public const int TEXTURE_CUBE_MAP_NEGATIVE_X_ARB = 8318;

	[RequiredByFeature("WGL_ARB_render_texture")]
	public const int TEXTURE_CUBE_MAP_POSITIVE_Y_ARB = 8319;

	[RequiredByFeature("WGL_ARB_render_texture")]
	public const int TEXTURE_CUBE_MAP_NEGATIVE_Y_ARB = 8320;

	[RequiredByFeature("WGL_ARB_render_texture")]
	public const int TEXTURE_CUBE_MAP_POSITIVE_Z_ARB = 8321;

	[RequiredByFeature("WGL_ARB_render_texture")]
	public const int TEXTURE_CUBE_MAP_NEGATIVE_Z_ARB = 8322;

	[RequiredByFeature("WGL_ARB_render_texture")]
	public const int FRONT_LEFT_ARB = 8323;

	[RequiredByFeature("WGL_ARB_render_texture")]
	public const int FRONT_RIGHT_ARB = 8324;

	[RequiredByFeature("WGL_ARB_render_texture")]
	public const int BACK_LEFT_ARB = 8325;

	[RequiredByFeature("WGL_ARB_render_texture")]
	public const int BACK_RIGHT_ARB = 8326;

	[RequiredByFeature("WGL_ARB_render_texture")]
	public const int AUX0_ARB = 8327;

	[RequiredByFeature("WGL_ARB_render_texture")]
	public const int AUX1_ARB = 8328;

	[RequiredByFeature("WGL_ARB_render_texture")]
	public const int AUX2_ARB = 8329;

	[RequiredByFeature("WGL_ARB_render_texture")]
	public const int AUX3_ARB = 8330;

	[RequiredByFeature("WGL_ARB_render_texture")]
	public const int AUX4_ARB = 8331;

	[RequiredByFeature("WGL_ARB_render_texture")]
	public const int AUX5_ARB = 8332;

	[RequiredByFeature("WGL_ARB_render_texture")]
	public const int AUX6_ARB = 8333;

	[RequiredByFeature("WGL_ARB_render_texture")]
	public const int AUX7_ARB = 8334;

	[RequiredByFeature("WGL_ARB_render_texture")]
	public const int AUX8_ARB = 8335;

	[RequiredByFeature("WGL_ARB_render_texture")]
	public const int AUX9_ARB = 8336;

	[RequiredByFeature("WGL_ARB_robustness_application_isolation")]
	[RequiredByFeature("WGL_ARB_robustness_share_group_isolation")]
	[Log(BitmaskName = "WGLContextFlagsMask")]
	public const uint CONTEXT_RESET_ISOLATION_BIT_ARB = 8u;

	[RequiredByFeature("WGL_ATI_render_texture_rectangle")]
	public const int TEXTURE_RECTANGLE_ATI = 8613;

	[RequiredByFeature("WGL_EXT_colorspace")]
	public const int COLORSPACE_EXT = 12445;

	[RequiredByFeature("WGL_EXT_colorspace")]
	public const int COLORSPACE_SRGB_EXT = 12425;

	[RequiredByFeature("WGL_EXT_colorspace")]
	public const int COLORSPACE_LINEAR_EXT = 12426;

	[RequiredByFeature("WGL_EXT_create_context_es_profile")]
	[Log(BitmaskName = "WGLContextProfileMask")]
	public const uint CONTEXT_ES_PROFILE_BIT_EXT = 4u;

	[RequiredByFeature("WGL_EXT_depth_float")]
	public const int DEPTH_FLOAT_EXT = 8256;

	[RequiredByFeature("WGL_EXT_pbuffer")]
	public const int OPTIMAL_PBUFFER_WIDTH_EXT = 8241;

	[RequiredByFeature("WGL_EXT_pbuffer")]
	public const int OPTIMAL_PBUFFER_HEIGHT_EXT = 8242;

	[RequiredByFeature("WGL_EXT_pixel_format")]
	public const int TRANSPARENT_VALUE_EXT = 8203;

	[RequiredByFeature("WGL_EXT_pixel_format_packed_float")]
	public const int TYPE_RGBA_UNSIGNED_FLOAT_EXT = 8360;

	[RequiredByFeature("WGL_I3D_digital_video_control")]
	public const int DIGITAL_VIDEO_CURSOR_ALPHA_FRAMEBUFFER_I3D = 8272;

	[RequiredByFeature("WGL_I3D_digital_video_control")]
	public const int DIGITAL_VIDEO_CURSOR_ALPHA_VALUE_I3D = 8273;

	[RequiredByFeature("WGL_I3D_digital_video_control")]
	public const int DIGITAL_VIDEO_CURSOR_INCLUDED_I3D = 8274;

	[RequiredByFeature("WGL_I3D_digital_video_control")]
	public const int DIGITAL_VIDEO_GAMMA_CORRECTED_I3D = 8275;

	[RequiredByFeature("WGL_I3D_gamma")]
	public const int GAMMA_TABLE_SIZE_I3D = 8270;

	[RequiredByFeature("WGL_I3D_gamma")]
	public const int GAMMA_EXCLUDE_DESKTOP_I3D = 8271;

	[RequiredByFeature("WGL_I3D_genlock")]
	public const int GENLOCK_SOURCE_MULTIVIEW_I3D = 8260;

	[RequiredByFeature("WGL_I3D_genlock")]
	public const int GENLOCK_SOURCE_EXTERNAL_SYNC_I3D = 8261;

	[RequiredByFeature("WGL_I3D_genlock")]
	public const int GENLOCK_SOURCE_EXTERNAL_FIELD_I3D = 8262;

	[RequiredByFeature("WGL_I3D_genlock")]
	public const int GENLOCK_SOURCE_EXTERNAL_TTL_I3D = 8263;

	[RequiredByFeature("WGL_I3D_genlock")]
	public const int GENLOCK_SOURCE_DIGITAL_SYNC_I3D = 8264;

	[RequiredByFeature("WGL_I3D_genlock")]
	public const int GENLOCK_SOURCE_DIGITAL_FIELD_I3D = 8265;

	[RequiredByFeature("WGL_I3D_genlock")]
	public const int GENLOCK_SOURCE_EDGE_FALLING_I3D = 8266;

	[RequiredByFeature("WGL_I3D_genlock")]
	public const int GENLOCK_SOURCE_EDGE_RISING_I3D = 8267;

	[RequiredByFeature("WGL_I3D_genlock")]
	public const int GENLOCK_SOURCE_EDGE_BOTH_I3D = 8268;

	[RequiredByFeature("WGL_I3D_image_buffer")]
	[Log(BitmaskName = "WGLImageBufferMaskI3D")]
	public const int IMAGE_BUFFER_MIN_ACCESS_I3D = 1;

	[RequiredByFeature("WGL_I3D_image_buffer")]
	[Log(BitmaskName = "WGLImageBufferMaskI3D")]
	public const int IMAGE_BUFFER_LOCK_I3D = 2;

	[RequiredByFeature("WGL_NV_DX_interop")]
	[Log(BitmaskName = "WGLDXInteropMaskNV")]
	public const int ACCESS_READ_ONLY_NV = 0;

	[RequiredByFeature("WGL_NV_DX_interop")]
	[Log(BitmaskName = "WGLDXInteropMaskNV")]
	public const int ACCESS_READ_WRITE_NV = 1;

	[RequiredByFeature("WGL_NV_DX_interop")]
	[Log(BitmaskName = "WGLDXInteropMaskNV")]
	public const int ACCESS_WRITE_DISCARD_NV = 2;

	[RequiredByFeature("WGL_NV_float_buffer")]
	public const int FLOAT_COMPONENTS_NV = 8368;

	[RequiredByFeature("WGL_NV_float_buffer")]
	public const int BIND_TO_TEXTURE_RECTANGLE_FLOAT_R_NV = 8369;

	[RequiredByFeature("WGL_NV_float_buffer")]
	public const int BIND_TO_TEXTURE_RECTANGLE_FLOAT_RG_NV = 8370;

	[RequiredByFeature("WGL_NV_float_buffer")]
	public const int BIND_TO_TEXTURE_RECTANGLE_FLOAT_RGB_NV = 8371;

	[RequiredByFeature("WGL_NV_float_buffer")]
	public const int BIND_TO_TEXTURE_RECTANGLE_FLOAT_RGBA_NV = 8372;

	[RequiredByFeature("WGL_NV_float_buffer")]
	public const int TEXTURE_FLOAT_R_NV = 8373;

	[RequiredByFeature("WGL_NV_float_buffer")]
	public const int TEXTURE_FLOAT_RG_NV = 8374;

	[RequiredByFeature("WGL_NV_float_buffer")]
	public const int TEXTURE_FLOAT_RGB_NV = 8375;

	[RequiredByFeature("WGL_NV_float_buffer")]
	public const int TEXTURE_FLOAT_RGBA_NV = 8376;

	[RequiredByFeature("WGL_NV_gpu_affinity")]
	public const int ERROR_INCOMPATIBLE_AFFINITY_MASKS_NV = 8400;

	[RequiredByFeature("WGL_NV_gpu_affinity")]
	public const int ERROR_MISSING_AFFINITY_MASK_NV = 8401;

	[RequiredByFeature("WGL_NV_multisample_coverage")]
	public const int COVERAGE_SAMPLES_NV = 8258;

	[RequiredByFeature("WGL_NV_multisample_coverage")]
	public const int COLOR_SAMPLES_NV = 8377;

	[RequiredByFeature("WGL_NV_present_video")]
	public const int NUM_VIDEO_SLOTS_NV = 8432;

	[RequiredByFeature("WGL_NV_render_depth_texture")]
	public const int BIND_TO_TEXTURE_DEPTH_NV = 8355;

	[RequiredByFeature("WGL_NV_render_depth_texture")]
	public const int BIND_TO_TEXTURE_RECTANGLE_DEPTH_NV = 8356;

	[RequiredByFeature("WGL_NV_render_depth_texture")]
	public const int DEPTH_TEXTURE_FORMAT_NV = 8357;

	[RequiredByFeature("WGL_NV_render_depth_texture")]
	public const int TEXTURE_DEPTH_COMPONENT_NV = 8358;

	[RequiredByFeature("WGL_NV_render_depth_texture")]
	public const int DEPTH_COMPONENT_NV = 8359;

	[RequiredByFeature("WGL_NV_render_texture_rectangle")]
	public const int BIND_TO_TEXTURE_RECTANGLE_RGB_NV = 8352;

	[RequiredByFeature("WGL_NV_render_texture_rectangle")]
	public const int BIND_TO_TEXTURE_RECTANGLE_RGBA_NV = 8353;

	[RequiredByFeature("WGL_NV_render_texture_rectangle")]
	public const int TEXTURE_RECTANGLE_NV = 8354;

	[RequiredByFeature("WGL_NV_video_capture")]
	public const int UNIQUE_ID_NV = 8398;

	[RequiredByFeature("WGL_NV_video_capture")]
	public const int NUM_VIDEO_CAPTURE_SLOTS_NV = 8399;

	[RequiredByFeature("WGL_NV_video_output")]
	public const int BIND_TO_VIDEO_RGB_NV = 8384;

	[RequiredByFeature("WGL_NV_video_output")]
	public const int BIND_TO_VIDEO_RGBA_NV = 8385;

	[RequiredByFeature("WGL_NV_video_output")]
	public const int BIND_TO_VIDEO_RGB_AND_DEPTH_NV = 8386;

	[RequiredByFeature("WGL_NV_video_output")]
	public const int VIDEO_OUT_COLOR_NV = 8387;

	[RequiredByFeature("WGL_NV_video_output")]
	public const int VIDEO_OUT_ALPHA_NV = 8388;

	[RequiredByFeature("WGL_NV_video_output")]
	public const int VIDEO_OUT_DEPTH_NV = 8389;

	[RequiredByFeature("WGL_NV_video_output")]
	public const int VIDEO_OUT_COLOR_AND_ALPHA_NV = 8390;

	[RequiredByFeature("WGL_NV_video_output")]
	public const int VIDEO_OUT_COLOR_AND_DEPTH_NV = 8391;

	[RequiredByFeature("WGL_NV_video_output")]
	public const int VIDEO_OUT_FRAME = 8392;

	[RequiredByFeature("WGL_NV_video_output")]
	public const int VIDEO_OUT_FIELD_1 = 8393;

	[RequiredByFeature("WGL_NV_video_output")]
	public const int VIDEO_OUT_FIELD_2 = 8394;

	[RequiredByFeature("WGL_NV_video_output")]
	public const int VIDEO_OUT_STACKED_FIELDS_1_2 = 8395;

	[RequiredByFeature("WGL_NV_video_output")]
	public const int VIDEO_OUT_STACKED_FIELDS_2_1 = 8396;

	private static GetAddressDelegate _GetAddressDelegate;

	private const string Library = "opengl32.dll";

	public static ErrorHandlingMode ErrorHandling;

	private static KhronosLogContext _LogContext;

	[RequiredByFeature("WGL_VERSION_1_0")]
	public const int PFD_TYPE_RGBA = 0;

	[RequiredByFeature("WGL_VERSION_1_0")]
	public const int PFD_TYPE_COLORINDEX = 1;

	[RequiredByFeature("WGL_VERSION_1_0")]
	public const int PFD_MAIN_PLANE = 0;

	[RequiredByFeature("WGL_VERSION_1_0")]
	public const int PFD_OVERLAY_PLANE = 1;

	[RequiredByFeature("WGL_VERSION_1_0")]
	public const int PFD_UNDERLAY_PLANE = -1;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLPixelFormatDescriptorFlags")]
	public const int PFD_DOUBLEBUFFER = 1;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLPixelFormatDescriptorFlags")]
	public const int PFD_STEREO = 2;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLPixelFormatDescriptorFlags")]
	public const int PFD_DRAW_TO_WINDOW = 4;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLPixelFormatDescriptorFlags")]
	public const int PFD_DRAW_TO_BITMAP = 8;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLPixelFormatDescriptorFlags")]
	public const int PFD_SUPPORT_GDI = 16;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLPixelFormatDescriptorFlags")]
	public const int PFD_SUPPORT_OPENGL = 32;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLPixelFormatDescriptorFlags")]
	public const int PFD_GENERIC_FORMAT = 64;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLPixelFormatDescriptorFlags")]
	public const int PFD_NEED_PALETTE = 128;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLPixelFormatDescriptorFlags")]
	public const int PFD_NEED_SYSTEM_PALETTE = 256;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLPixelFormatDescriptorFlags")]
	public const int PFD_SWAP_EXCHANGE = 512;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLPixelFormatDescriptorFlags")]
	public const int PFD_SWAP_COPY = 1024;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLPixelFormatDescriptorFlags")]
	public const int PFD_SWAP_LAYER_BUFFERS = 2048;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLPixelFormatDescriptorFlags")]
	public const int PFD_GENERIC_ACCELERATED = 4096;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLPixelFormatDescriptorFlags")]
	public const int PFD_SUPPORT_DIRECTDRAW = 8192;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLPixelFormatDescriptorFlags")]
	public const int PFD_DIRECT3D_ACCELERATED = 16384;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLPixelFormatDescriptorFlags")]
	public const int PFD_SUPPORT_COMPOSITION = 32768;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLPixelFormatDescriptorFlags")]
	public const int PFD_DEPTH_DONTCARE = 536870912;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLPixelFormatDescriptorFlags")]
	public const int PFD_DOUBLEBUFFER_DONTCARE = 1073741824;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLPixelFormatDescriptorFlags")]
	public const int PFD_STEREO_DONTCARE = int.MinValue;

	public static readonly KhronosVersion Version_100;

	[RequiredByFeature("WGL_VERSION_1_0")]
	public const int FONT_LINES = 0;

	[RequiredByFeature("WGL_VERSION_1_0")]
	public const int FONT_POLYGONS = 1;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLLayerPlaneMask")]
	public const uint SWAP_MAIN_PLANE = 1u;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLLayerPlaneMask")]
	public const uint SWAP_OVERLAY1 = 2u;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLLayerPlaneMask")]
	public const uint SWAP_OVERLAY2 = 4u;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLLayerPlaneMask")]
	public const uint SWAP_OVERLAY3 = 8u;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLLayerPlaneMask")]
	public const uint SWAP_OVERLAY4 = 16u;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLLayerPlaneMask")]
	public const uint SWAP_OVERLAY5 = 32u;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLLayerPlaneMask")]
	public const uint SWAP_OVERLAY6 = 64u;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLLayerPlaneMask")]
	public const uint SWAP_OVERLAY7 = 128u;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLLayerPlaneMask")]
	public const uint SWAP_OVERLAY8 = 256u;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLLayerPlaneMask")]
	public const uint SWAP_OVERLAY9 = 512u;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLLayerPlaneMask")]
	public const uint SWAP_OVERLAY10 = 1024u;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLLayerPlaneMask")]
	public const uint SWAP_OVERLAY11 = 2048u;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLLayerPlaneMask")]
	public const uint SWAP_OVERLAY12 = 4096u;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLLayerPlaneMask")]
	public const uint SWAP_OVERLAY13 = 8192u;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLLayerPlaneMask")]
	public const uint SWAP_OVERLAY14 = 16384u;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLLayerPlaneMask")]
	public const uint SWAP_OVERLAY15 = 32768u;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLLayerPlaneMask")]
	public const uint SWAP_UNDERLAY1 = 65536u;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLLayerPlaneMask")]
	public const uint SWAP_UNDERLAY2 = 131072u;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLLayerPlaneMask")]
	public const uint SWAP_UNDERLAY3 = 262144u;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLLayerPlaneMask")]
	public const uint SWAP_UNDERLAY4 = 524288u;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLLayerPlaneMask")]
	public const uint SWAP_UNDERLAY5 = 1048576u;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLLayerPlaneMask")]
	public const uint SWAP_UNDERLAY6 = 2097152u;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLLayerPlaneMask")]
	public const uint SWAP_UNDERLAY7 = 4194304u;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLLayerPlaneMask")]
	public const uint SWAP_UNDERLAY8 = 8388608u;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLLayerPlaneMask")]
	public const uint SWAP_UNDERLAY9 = 16777216u;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLLayerPlaneMask")]
	public const uint SWAP_UNDERLAY10 = 33554432u;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLLayerPlaneMask")]
	public const uint SWAP_UNDERLAY11 = 67108864u;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLLayerPlaneMask")]
	public const uint SWAP_UNDERLAY12 = 134217728u;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLLayerPlaneMask")]
	public const uint SWAP_UNDERLAY13 = 268435456u;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLLayerPlaneMask")]
	public const uint SWAP_UNDERLAY14 = 536870912u;

	[RequiredByFeature("WGL_VERSION_1_0")]
	[Log(BitmaskName = "WGLLayerPlaneMask")]
	public const uint SWAP_UNDERLAY15 = 1073741824u;

	public static Extensions CurrentExtensions { get; internal set; }

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

	public static bool HasGetExtensionsStringARB => Delegates.pwglGetExtensionsStringARB != null;

	[RequiredByFeature("WGL_3DL_stereo_control")]
	public static bool SetStereoEmitter3DL(nint hDC, uint uState)
	{
		bool num = Delegates.pwglSetStereoEmitterState3DL(hDC, uState);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_AMD_gpu_association")]
	public unsafe static uint GetGPUIDsAMD(uint maxCount, [Out] uint[] ids)
	{
		uint num;
		fixed (uint* ids2 = ids)
		{
			num = Delegates.pwglGetGPUIDsAMD(maxCount, ids2);
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_AMD_gpu_association")]
	public static int GetGPUInfoAMD(uint id, int property, int dataType, uint size, nint data)
	{
		int num = Delegates.pwglGetGPUInfoAMD(id, property, dataType, size, data);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_AMD_gpu_association")]
	public static uint GetContextGPUIDAMD(nint hglrc)
	{
		uint num = Delegates.pwglGetContextGPUIDAMD(hglrc);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_AMD_gpu_association")]
	public static nint CreateAssociatedContextAMD(uint id)
	{
		nint num = Delegates.pwglCreateAssociatedContextAMD(id);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_AMD_gpu_association")]
	public unsafe static nint CreateAssociatedContextAttribsAMD(uint id, nint hShareContext, int[] attribList)
	{
		nint num;
		fixed (int* attribList2 = attribList)
		{
			num = Delegates.pwglCreateAssociatedContextAttribsAMD(id, hShareContext, attribList2);
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_AMD_gpu_association")]
	public static bool DeleteAssociatedContextAMD(nint hglrc)
	{
		bool num = Delegates.pwglDeleteAssociatedContextAMD(hglrc);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_AMD_gpu_association")]
	public static bool MakeAssociatedContextCurrentAMD(nint hglrc)
	{
		bool num = Delegates.pwglMakeAssociatedContextCurrentAMD(hglrc);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_AMD_gpu_association")]
	public static nint GetCurrentAssociatedContextAMD()
	{
		nint num = Delegates.pwglGetCurrentAssociatedContextAMD();
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_AMD_gpu_association")]
	public static void BlitContextFramebufferAMD(nint dstCtx, int srcX0, int srcY0, int srcX1, int srcY1, int dstX0, int dstY0, int dstX1, int dstY1, uint mask, int filter)
	{
		Delegates.pwglBlitContextFramebufferAMD(dstCtx, srcX0, srcY0, srcX1, srcY1, dstX0, dstY0, dstX1, dstY1, mask, filter);
		DebugCheckErrors(null);
	}

	[RequiredByFeature("WGL_ARB_buffer_region")]
	public static nint CreateBufferRegionARB(nint hDC, int iLayerPlane, uint uType)
	{
		nint num = Delegates.pwglCreateBufferRegionARB(hDC, iLayerPlane, uType);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_ARB_buffer_region")]
	public static void DeleteBufferRegionARB(nint hRegion)
	{
		Delegates.pwglDeleteBufferRegionARB(hRegion);
		DebugCheckErrors(null);
	}

	[RequiredByFeature("WGL_ARB_buffer_region")]
	public static bool SaveBufferRegionARB(nint hRegion, int x, int y, int width, int height)
	{
		bool num = Delegates.pwglSaveBufferRegionARB(hRegion, x, y, width, height);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_ARB_buffer_region")]
	public static bool RestoreBufferRegionARB(nint hRegion, int x, int y, int width, int height, int xSrc, int ySrc)
	{
		bool num = Delegates.pwglRestoreBufferRegionARB(hRegion, x, y, width, height, xSrc, ySrc);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_ARB_create_context")]
	public unsafe static nint CreateContextAttribsARB(nint hDC, nint hShareContext, int[] attribList)
	{
		nint num;
		fixed (int* attribList2 = attribList)
		{
			num = Delegates.pwglCreateContextAttribsARB(hDC, hShareContext, attribList2);
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_ARB_extensions_string")]
	public static string GetExtensionsStringARB(nint hdc)
	{
		nint num = Delegates.pwglGetExtensionsStringARB(hdc);
		DebugCheckErrors(num);
		return Khronos.KhronosApi.PtrToString(num);
	}

	[RequiredByFeature("WGL_ARB_make_current_read")]
	public static bool MakeContextCurrentARB(nint hDrawDC, nint hReadDC, nint hglrc)
	{
		bool num = Delegates.pwglMakeContextCurrentARB(hDrawDC, hReadDC, hglrc);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_ARB_make_current_read")]
	public static nint GetCurrentReadDCARB()
	{
		nint num = Delegates.pwglGetCurrentReadDCARB();
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_ARB_pbuffer")]
	public unsafe static nint CreatePbufferARB(nint hDC, int iPixelFormat, int iWidth, int iHeight, int[] piAttribList)
	{
		nint num;
		fixed (int* piAttribList2 = piAttribList)
		{
			num = Delegates.pwglCreatePbufferARB(hDC, iPixelFormat, iWidth, iHeight, piAttribList2);
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_ARB_pbuffer")]
	public static nint GetPbufferDCARB(nint hPbuffer)
	{
		nint num = Delegates.pwglGetPbufferDCARB(hPbuffer);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_ARB_pbuffer")]
	public static int ReleasePbufferDCARB(nint hPbuffer, nint hDC)
	{
		int num = Delegates.pwglReleasePbufferDCARB(hPbuffer, hDC);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_ARB_pbuffer")]
	public static bool DestroyPbufferARB(nint hPbuffer)
	{
		bool num = Delegates.pwglDestroyPbufferARB(hPbuffer);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_ARB_pbuffer")]
	public unsafe static bool QueryPbufferARB(nint hPbuffer, int iAttribute, int[] piValue)
	{
		bool num;
		fixed (int* piValue2 = piValue)
		{
			num = Delegates.pwglQueryPbufferARB(hPbuffer, iAttribute, piValue2);
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_ARB_pixel_format")]
	public unsafe static bool GetPixelFormatAttribARB(nint hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, int[] piAttributes, [Out] int[] piValues)
	{
		bool num;
		fixed (int* piAttributes2 = piAttributes)
		{
			fixed (int* piValues2 = piValues)
			{
				num = Delegates.pwglGetPixelFormatAttribivARB(hdc, iPixelFormat, iLayerPlane, nAttributes, piAttributes2, piValues2);
			}
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_ARB_pixel_format")]
	public unsafe static bool GetPixelFormatAttribARB(nint hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, int[] piAttributes, [Out] float[] pfValues)
	{
		bool num;
		fixed (int* piAttributes2 = piAttributes)
		{
			fixed (float* pfValues2 = pfValues)
			{
				num = Delegates.pwglGetPixelFormatAttribfvARB(hdc, iPixelFormat, iLayerPlane, nAttributes, piAttributes2, pfValues2);
			}
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_ARB_pixel_format")]
	public unsafe static bool ChoosePixelFormatARB(nint hdc, int[] piAttribIList, float[] pfAttribFList, uint nMaxFormats, int[] piFormats, uint[] nNumFormats)
	{
		bool num;
		fixed (int* piAttribIList2 = piAttribIList)
		{
			fixed (float* pfAttribFList2 = pfAttribFList)
			{
				fixed (int* piFormats2 = piFormats)
				{
					fixed (uint* nNumFormats2 = nNumFormats)
					{
						num = Delegates.pwglChoosePixelFormatARB(hdc, piAttribIList2, pfAttribFList2, nMaxFormats, piFormats2, nNumFormats2);
					}
				}
			}
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_ARB_render_texture")]
	public static bool BindTexImageARB(nint hPbuffer, int iBuffer)
	{
		bool num = Delegates.pwglBindTexImageARB(hPbuffer, iBuffer);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_ARB_render_texture")]
	public static bool ReleaseTexImageARB(nint hPbuffer, int iBuffer)
	{
		bool num = Delegates.pwglReleaseTexImageARB(hPbuffer, iBuffer);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_ARB_render_texture")]
	public unsafe static bool SetPbufferAttribARB(nint hPbuffer, int[] piAttribList)
	{
		bool num;
		fixed (int* piAttribList2 = piAttribList)
		{
			num = Delegates.pwglSetPbufferAttribARB(hPbuffer, piAttribList2);
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_EXT_display_color_table")]
	public static bool CreateDisplayColorTableEXT(ushort id)
	{
		bool num = Delegates.pwglCreateDisplayColorTableEXT(id);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_EXT_display_color_table")]
	public unsafe static bool LoadDisplayColorTableEXT(ushort[] table, uint length)
	{
		bool num;
		fixed (ushort* table2 = table)
		{
			num = Delegates.pwglLoadDisplayColorTableEXT(table2, length);
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_EXT_display_color_table")]
	public static bool BindDisplayColorTableEXT(ushort id)
	{
		bool num = Delegates.pwglBindDisplayColorTableEXT(id);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_EXT_display_color_table")]
	public static void DestroyDisplayColorTableEXT(ushort id)
	{
		Delegates.pwglDestroyDisplayColorTableEXT(id);
		DebugCheckErrors(null);
	}

	[RequiredByFeature("WGL_EXT_extensions_string")]
	public static string GetExtensionsStringEXT()
	{
		nint num = Delegates.pwglGetExtensionsStringEXT();
		DebugCheckErrors(num);
		return Khronos.KhronosApi.PtrToString(num);
	}

	[RequiredByFeature("WGL_EXT_make_current_read")]
	public static bool MakeContextCurrentEXT(nint hDrawDC, nint hReadDC, nint hglrc)
	{
		bool num = Delegates.pwglMakeContextCurrentEXT(hDrawDC, hReadDC, hglrc);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_EXT_make_current_read")]
	public static nint GetCurrentReadDCEXT()
	{
		nint num = Delegates.pwglGetCurrentReadDCEXT();
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_EXT_pbuffer")]
	public unsafe static nint CreatePbufferEXT(nint hDC, int iPixelFormat, int iWidth, int iHeight, int[] piAttribList)
	{
		nint num;
		fixed (int* piAttribList2 = piAttribList)
		{
			num = Delegates.pwglCreatePbufferEXT(hDC, iPixelFormat, iWidth, iHeight, piAttribList2);
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_EXT_pbuffer")]
	public static nint GetPbufferDCEXT(nint hPbuffer)
	{
		nint num = Delegates.pwglGetPbufferDCEXT(hPbuffer);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_EXT_pbuffer")]
	public static int ReleasePbufferDCEXT(nint hPbuffer, nint hDC)
	{
		int num = Delegates.pwglReleasePbufferDCEXT(hPbuffer, hDC);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_EXT_pbuffer")]
	public static bool DestroyPbufferEXT(nint hPbuffer)
	{
		bool num = Delegates.pwglDestroyPbufferEXT(hPbuffer);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_EXT_pbuffer")]
	public unsafe static bool QueryPbufferEXT(nint hPbuffer, int iAttribute, int[] piValue)
	{
		bool num;
		fixed (int* piValue2 = piValue)
		{
			num = Delegates.pwglQueryPbufferEXT(hPbuffer, iAttribute, piValue2);
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_EXT_pixel_format")]
	public unsafe static bool GetPixelFormatAttribEXT(nint hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, [Out] int[] piAttributes, [Out] int[] piValues)
	{
		bool num;
		fixed (int* piAttributes2 = piAttributes)
		{
			fixed (int* piValues2 = piValues)
			{
				num = Delegates.pwglGetPixelFormatAttribivEXT(hdc, iPixelFormat, iLayerPlane, nAttributes, piAttributes2, piValues2);
			}
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_EXT_pixel_format")]
	public unsafe static bool GetPixelFormatAttribEXT(nint hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, [Out] int[] piAttributes, [Out] float[] pfValues)
	{
		bool num;
		fixed (int* piAttributes2 = piAttributes)
		{
			fixed (float* pfValues2 = pfValues)
			{
				num = Delegates.pwglGetPixelFormatAttribfvEXT(hdc, iPixelFormat, iLayerPlane, nAttributes, piAttributes2, pfValues2);
			}
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_EXT_pixel_format")]
	public unsafe static bool ChoosePixelFormatEXT(nint hdc, int[] piAttribIList, float[] pfAttribFList, uint nMaxFormats, int[] piFormats, uint[] nNumFormats)
	{
		bool num;
		fixed (int* piAttribIList2 = piAttribIList)
		{
			fixed (float* pfAttribFList2 = pfAttribFList)
			{
				fixed (int* piFormats2 = piFormats)
				{
					fixed (uint* nNumFormats2 = nNumFormats)
					{
						num = Delegates.pwglChoosePixelFormatEXT(hdc, piAttribIList2, pfAttribFList2, nMaxFormats, piFormats2, nNumFormats2);
					}
				}
			}
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_EXT_swap_control")]
	public static bool SwapIntervalEXT(int interval)
	{
		bool num = Delegates.pwglSwapIntervalEXT(interval);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_EXT_swap_control")]
	public static int GetSwapIntervalEXT()
	{
		int num = Delegates.pwglGetSwapIntervalEXT();
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_I3D_digital_video_control")]
	public unsafe static bool GetDigitalVideoParametersI3D(nint hDC, int iAttribute, [Out] int[] piValue)
	{
		bool num;
		fixed (int* piValue2 = piValue)
		{
			num = Delegates.pwglGetDigitalVideoParametersI3D(hDC, iAttribute, piValue2);
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_I3D_digital_video_control")]
	public unsafe static bool SetDigitalVideoParametersI3D(nint hDC, int iAttribute, int[] piValue)
	{
		bool num;
		fixed (int* piValue2 = piValue)
		{
			num = Delegates.pwglSetDigitalVideoParametersI3D(hDC, iAttribute, piValue2);
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_I3D_gamma")]
	public unsafe static bool GetGammaTableParametersI3D(nint hDC, int iAttribute, [Out] int[] piValue)
	{
		bool num;
		fixed (int* piValue2 = piValue)
		{
			num = Delegates.pwglGetGammaTableParametersI3D(hDC, iAttribute, piValue2);
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_I3D_gamma")]
	public unsafe static bool SetGammaTableParametersI3D(nint hDC, int iAttribute, int[] piValue)
	{
		bool num;
		fixed (int* piValue2 = piValue)
		{
			num = Delegates.pwglSetGammaTableParametersI3D(hDC, iAttribute, piValue2);
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_I3D_gamma")]
	public unsafe static bool GetGammaTableI3D(nint hDC, int iEntries, [Out] ushort[] puRed, [Out] ushort[] puGreen, [Out] ushort[] puBlue)
	{
		bool num;
		fixed (ushort* puRed2 = puRed)
		{
			fixed (ushort* puGreen2 = puGreen)
			{
				fixed (ushort* puBlue2 = puBlue)
				{
					num = Delegates.pwglGetGammaTableI3D(hDC, iEntries, puRed2, puGreen2, puBlue2);
				}
			}
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_I3D_gamma")]
	public unsafe static bool SetGammaTableI3D(nint hDC, int iEntries, ushort[] puRed, ushort[] puGreen, ushort[] puBlue)
	{
		bool num;
		fixed (ushort* puRed2 = puRed)
		{
			fixed (ushort* puGreen2 = puGreen)
			{
				fixed (ushort* puBlue2 = puBlue)
				{
					num = Delegates.pwglSetGammaTableI3D(hDC, iEntries, puRed2, puGreen2, puBlue2);
				}
			}
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_I3D_genlock")]
	public static bool EnableGenlockI3D(nint hDC)
	{
		bool num = Delegates.pwglEnableGenlockI3D(hDC);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_I3D_genlock")]
	public static bool DisableGenlockI3D(nint hDC)
	{
		bool num = Delegates.pwglDisableGenlockI3D(hDC);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_I3D_genlock")]
	public unsafe static bool IsEnabledGenlockI3D(nint hDC, [Out] bool[] pFlag)
	{
		bool num;
		fixed (bool* pFlag2 = pFlag)
		{
			num = Delegates.pwglIsEnabledGenlockI3D(hDC, pFlag2);
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_I3D_genlock")]
	public static bool GenlockSourceI3D(nint hDC, uint uSource)
	{
		bool num = Delegates.pwglGenlockSourceI3D(hDC, uSource);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_I3D_genlock")]
	public unsafe static bool GetGenlockSourceI3D(nint hDC, [Out] uint[] uSource)
	{
		bool num;
		fixed (uint* uSource2 = uSource)
		{
			num = Delegates.pwglGetGenlockSourceI3D(hDC, uSource2);
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_I3D_genlock")]
	public static bool GenlockSourceEdgeI3D(nint hDC, uint uEdge)
	{
		bool num = Delegates.pwglGenlockSourceEdgeI3D(hDC, uEdge);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_I3D_genlock")]
	public unsafe static bool GetGenlockSourceEdgeI3D(nint hDC, [Out] uint[] uEdge)
	{
		bool num;
		fixed (uint* uEdge2 = uEdge)
		{
			num = Delegates.pwglGetGenlockSourceEdgeI3D(hDC, uEdge2);
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_I3D_genlock")]
	public static bool GenlockSampleRateI3D(nint hDC, uint uRate)
	{
		bool num = Delegates.pwglGenlockSampleRateI3D(hDC, uRate);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_I3D_genlock")]
	public unsafe static bool GetGenlockSampleRateI3D(nint hDC, [Out] uint[] uRate)
	{
		bool num;
		fixed (uint* uRate2 = uRate)
		{
			num = Delegates.pwglGetGenlockSampleRateI3D(hDC, uRate2);
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_I3D_genlock")]
	public static bool GenlockSourceDelayI3D(nint hDC, uint uDelay)
	{
		bool num = Delegates.pwglGenlockSourceDelayI3D(hDC, uDelay);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_I3D_genlock")]
	public unsafe static bool GetGenlockSourceDelayI3D(nint hDC, [Out] uint[] uDelay)
	{
		bool num;
		fixed (uint* uDelay2 = uDelay)
		{
			num = Delegates.pwglGetGenlockSourceDelayI3D(hDC, uDelay2);
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_I3D_genlock")]
	public unsafe static bool QueryGenlockMaxSourceDelayI3D(nint hDC, uint[] uMaxLineDelay, uint[] uMaxPixelDelay)
	{
		bool num;
		fixed (uint* uMaxLineDelay2 = uMaxLineDelay)
		{
			fixed (uint* uMaxPixelDelay2 = uMaxPixelDelay)
			{
				num = Delegates.pwglQueryGenlockMaxSourceDelayI3D(hDC, uMaxLineDelay2, uMaxPixelDelay2);
			}
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_I3D_image_buffer")]
	public static nint CreateImageBufferI3D(nint hDC, int dwSize, uint uFlags)
	{
		nint num = Delegates.pwglCreateImageBufferI3D(hDC, dwSize, uFlags);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_I3D_image_buffer")]
	public static bool DestroyImageBufferI3D(nint hDC, nint pAddress)
	{
		bool num = Delegates.pwglDestroyImageBufferI3D(hDC, pAddress);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_I3D_image_buffer")]
	public unsafe static bool AssociateImageBufferEventsI3D(nint hDC, nint[] pEvent, nint[] pAddress, int[] pSize, uint count)
	{
		bool num;
		fixed (nint* pEvent2 = pEvent)
		{
			fixed (nint* pAddress2 = pAddress)
			{
				fixed (int* pSize2 = pSize)
				{
					num = Delegates.pwglAssociateImageBufferEventsI3D(hDC, pEvent2, pAddress2, pSize2, count);
				}
			}
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_I3D_image_buffer")]
	public unsafe static bool ReleaseImageBufferEventsI3D(nint hDC, nint[] pAddress, uint count)
	{
		bool num;
		fixed (nint* pAddress2 = pAddress)
		{
			num = Delegates.pwglReleaseImageBufferEventsI3D(hDC, pAddress2, count);
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_I3D_swap_frame_lock")]
	public static bool EnableFrameLockI3D()
	{
		bool num = Delegates.pwglEnableFrameLockI3D();
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_I3D_swap_frame_lock")]
	public static bool DisableFrameLockI3D()
	{
		bool num = Delegates.pwglDisableFrameLockI3D();
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_I3D_swap_frame_lock")]
	public unsafe static bool IsEnabledFrameLockI3D([Out] bool[] pFlag)
	{
		bool num;
		fixed (bool* pFlag2 = pFlag)
		{
			num = Delegates.pwglIsEnabledFrameLockI3D(pFlag2);
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_I3D_swap_frame_lock")]
	public unsafe static bool QueryFrameLockMasterI3D(bool[] pFlag)
	{
		bool num;
		fixed (bool* pFlag2 = pFlag)
		{
			num = Delegates.pwglQueryFrameLockMasterI3D(pFlag2);
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_I3D_swap_frame_usage")]
	public unsafe static bool GetFrameUsageI3D([Out] float[] pUsage)
	{
		bool num;
		fixed (float* pUsage2 = pUsage)
		{
			num = Delegates.pwglGetFrameUsageI3D(pUsage2);
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_I3D_swap_frame_usage")]
	public static bool BeginFrameTrackingI3D()
	{
		bool num = Delegates.pwglBeginFrameTrackingI3D();
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_I3D_swap_frame_usage")]
	public static bool EndFrameTrackingI3D()
	{
		bool num = Delegates.pwglEndFrameTrackingI3D();
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_I3D_swap_frame_usage")]
	public unsafe static bool QueryFrameTrackingI3D(int[] pFrameCount, int[] pMissedFrames, float[] pLastMissedUsage)
	{
		bool num;
		fixed (int* pFrameCount2 = pFrameCount)
		{
			fixed (int* pMissedFrames2 = pMissedFrames)
			{
				fixed (float* pLastMissedUsage2 = pLastMissedUsage)
				{
					num = Delegates.pwglQueryFrameTrackingI3D(pFrameCount2, pMissedFrames2, pLastMissedUsage2);
				}
			}
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_NV_copy_image")]
	public static bool CopyImageSubDataNV(nint hSrcRC, uint srcName, int srcTarget, int srcLevel, int srcX, int srcY, int srcZ, nint hDstRC, uint dstName, int dstTarget, int dstLevel, int dstX, int dstY, int dstZ, int width, int height, int depth)
	{
		bool num = Delegates.pwglCopyImageSubDataNV(hSrcRC, srcName, srcTarget, srcLevel, srcX, srcY, srcZ, hDstRC, dstName, dstTarget, dstLevel, dstX, dstY, dstZ, width, height, depth);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_NV_delay_before_swap")]
	public static bool DelayBeforeSwapNV(nint hDC, float seconds)
	{
		bool num = Delegates.pwglDelayBeforeSwapNV(hDC, seconds);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_NV_DX_interop")]
	public static bool DXSetResourceShareHandleNV(nint dxObject, nint shareHandle)
	{
		bool num = Delegates.pwglDXSetResourceShareHandleNV(dxObject, shareHandle);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_NV_DX_interop")]
	public static nint DXOpenDeviceNV(nint dxDevice)
	{
		nint num = Delegates.pwglDXOpenDeviceNV(dxDevice);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_NV_DX_interop")]
	public static bool DXCloseDeviceNV(nint hDevice)
	{
		bool num = Delegates.pwglDXCloseDeviceNV(hDevice);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_NV_DX_interop")]
	public static nint DXRegisterObjectNV(nint hDevice, nint dxObject, uint name, int type, int access)
	{
		nint num = Delegates.pwglDXRegisterObjectNV(hDevice, dxObject, name, type, access);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_NV_DX_interop")]
	public static bool DXUnregisterObjectNV(nint hDevice, nint hObject)
	{
		bool num = Delegates.pwglDXUnregisterObjectNV(hDevice, hObject);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_NV_DX_interop")]
	public static bool DXObjectNV(nint hObject, int access)
	{
		bool num = Delegates.pwglDXObjectAccessNV(hObject, access);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_NV_DX_interop")]
	public unsafe static bool DXLockObjectNV(nint hDevice, int count, nint[] hObjects)
	{
		bool num;
		fixed (nint* hObjects2 = hObjects)
		{
			num = Delegates.pwglDXLockObjectsNV(hDevice, count, hObjects2);
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_NV_DX_interop")]
	public unsafe static bool DXUnlockObjectsNV(nint hDevice, int count, nint[] hObjects)
	{
		bool num;
		fixed (nint* hObjects2 = hObjects)
		{
			num = Delegates.pwglDXUnlockObjectsNV(hDevice, count, hObjects2);
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_NV_gpu_affinity")]
	public unsafe static bool EnumGpusNV(uint iGpuIndex, nint[] phGpu)
	{
		bool num;
		fixed (nint* phGpu2 = phGpu)
		{
			num = Delegates.pwglEnumGpusNV(iGpuIndex, phGpu2);
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_NV_gpu_affinity")]
	public static bool EnumGpuDevicesNV(nint hGpu, uint iDeviceIndex, nint lpGpuDevice)
	{
		bool num = Delegates.pwglEnumGpuDevicesNV(hGpu, iDeviceIndex, lpGpuDevice);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_NV_gpu_affinity")]
	public unsafe static nint CreateAffinityDCNV(nint[] phGpuList)
	{
		nint num;
		fixed (nint* phGpuList2 = phGpuList)
		{
			num = Delegates.pwglCreateAffinityDCNV(phGpuList2);
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_NV_gpu_affinity")]
	public unsafe static bool EnumGpusFromAffinityDCNV(nint hAffinityDC, uint iGpuIndex, nint[] hGpu)
	{
		bool num;
		fixed (nint* hGpu2 = hGpu)
		{
			num = Delegates.pwglEnumGpusFromAffinityDCNV(hAffinityDC, iGpuIndex, hGpu2);
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_NV_gpu_affinity")]
	public static bool DeleteDCNV(nint hdc)
	{
		bool num = Delegates.pwglDeleteDCNV(hdc);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_NV_present_video")]
	public unsafe static int EnumerateVideoDevicesNV(nint hDC, nint[] phDeviceList)
	{
		int num;
		fixed (nint* phDeviceList2 = phDeviceList)
		{
			num = Delegates.pwglEnumerateVideoDevicesNV(hDC, phDeviceList2);
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_NV_present_video")]
	public unsafe static bool BindVideoDeviceNV(nint hDC, uint uVideoSlot, nint hVideoDevice, int[] piAttribList)
	{
		bool num;
		fixed (int* piAttribList2 = piAttribList)
		{
			num = Delegates.pwglBindVideoDeviceNV(hDC, uVideoSlot, hVideoDevice, piAttribList2);
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_NV_present_video")]
	public unsafe static bool QueryCurrentContextNV(int iAttribute, int[] piValue)
	{
		bool num;
		fixed (int* piValue2 = piValue)
		{
			num = Delegates.pwglQueryCurrentContextNV(iAttribute, piValue2);
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_NV_swap_group")]
	public static bool JoinSwapGroupNV(nint hDC, uint group)
	{
		bool num = Delegates.pwglJoinSwapGroupNV(hDC, group);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_NV_swap_group")]
	public static bool BindSwapBarrierNV(uint group, uint barrier)
	{
		bool num = Delegates.pwglBindSwapBarrierNV(group, barrier);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_NV_swap_group")]
	public unsafe static bool QuerySwapGroupNV(nint hDC, uint[] group, uint[] barrier)
	{
		bool num;
		fixed (uint* group2 = group)
		{
			fixed (uint* barrier2 = barrier)
			{
				num = Delegates.pwglQuerySwapGroupNV(hDC, group2, barrier2);
			}
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_NV_swap_group")]
	public unsafe static bool QueryMaxSwapGroupsNV(nint hDC, uint[] maxGroups, uint[] maxBarriers)
	{
		bool num;
		fixed (uint* maxGroups2 = maxGroups)
		{
			fixed (uint* maxBarriers2 = maxBarriers)
			{
				num = Delegates.pwglQueryMaxSwapGroupsNV(hDC, maxGroups2, maxBarriers2);
			}
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_NV_swap_group")]
	public unsafe static bool QueryFrameCountNV(nint hDC, uint[] count)
	{
		bool num;
		fixed (uint* count2 = count)
		{
			num = Delegates.pwglQueryFrameCountNV(hDC, count2);
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_NV_swap_group")]
	public static bool ResetFrameCountNV(nint hDC)
	{
		bool num = Delegates.pwglResetFrameCountNV(hDC);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_NV_vertex_array_range")]
	public static nint AllocateMemoryNV(int size, float readfreq, float writefreq, float priority)
	{
		nint num = Delegates.pwglAllocateMemoryNV(size, readfreq, writefreq, priority);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_NV_vertex_array_range")]
	public static void FreeMemoryNV(nint pointer)
	{
		Delegates.pwglFreeMemoryNV(pointer);
		DebugCheckErrors(null);
	}

	[RequiredByFeature("WGL_NV_video_capture")]
	public static bool BindVideoCaptureDeviceNV(uint uVideoSlot, nint hDevice)
	{
		bool num = Delegates.pwglBindVideoCaptureDeviceNV(uVideoSlot, hDevice);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_NV_video_capture")]
	public unsafe static uint EnumerateVideoCaptureDevicesNV(nint hDc, nint[] phDeviceList)
	{
		uint num;
		fixed (nint* phDeviceList2 = phDeviceList)
		{
			num = Delegates.pwglEnumerateVideoCaptureDevicesNV(hDc, phDeviceList2);
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_NV_video_capture")]
	public static bool LockVideoCaptureDeviceNV(nint hDc, nint hDevice)
	{
		bool num = Delegates.pwglLockVideoCaptureDeviceNV(hDc, hDevice);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_NV_video_capture")]
	public unsafe static bool QueryVideoCaptureDeviceNV(nint hDc, nint hDevice, int iAttribute, int[] piValue)
	{
		bool num;
		fixed (int* piValue2 = piValue)
		{
			num = Delegates.pwglQueryVideoCaptureDeviceNV(hDc, hDevice, iAttribute, piValue2);
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_NV_video_capture")]
	public static bool ReleaseVideoCaptureDeviceNV(nint hDc, nint hDevice)
	{
		bool num = Delegates.pwglReleaseVideoCaptureDeviceNV(hDc, hDevice);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_NV_video_output")]
	public unsafe static bool GetVideoDeviceNV(nint hDC, int numDevices, [Out] nint[] hVideoDevice)
	{
		bool num;
		fixed (nint* hVideoDevice2 = hVideoDevice)
		{
			num = Delegates.pwglGetVideoDeviceNV(hDC, numDevices, hVideoDevice2);
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_NV_video_output")]
	public static bool ReleaseVideoDeviceNV(nint hVideoDevice)
	{
		bool num = Delegates.pwglReleaseVideoDeviceNV(hVideoDevice);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_NV_video_output")]
	public static bool BindVideoImageNV(nint hVideoDevice, nint hPbuffer, int iVideoBuffer)
	{
		bool num = Delegates.pwglBindVideoImageNV(hVideoDevice, hPbuffer, iVideoBuffer);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_NV_video_output")]
	public static bool ReleaseVideoImageNV(nint hPbuffer, int iVideoBuffer)
	{
		bool num = Delegates.pwglReleaseVideoImageNV(hPbuffer, iVideoBuffer);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_NV_video_output")]
	public unsafe static bool SendPbufferToVideoNV(nint hPbuffer, int iBufferType, uint[] pulCounterPbuffer, bool bBlock)
	{
		bool num;
		fixed (uint* pulCounterPbuffer2 = pulCounterPbuffer)
		{
			num = Delegates.pwglSendPbufferToVideoNV(hPbuffer, iBufferType, pulCounterPbuffer2, bBlock);
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_NV_video_output")]
	public unsafe static bool GetVideoInfoNV(nint hpVideoDevice, [Out] uint[] pulCounterOutputPbuffer, [Out] uint[] pulCounterOutputVideo)
	{
		bool num;
		fixed (uint* pulCounterOutputPbuffer2 = pulCounterOutputPbuffer)
		{
			fixed (uint* pulCounterOutputVideo2 = pulCounterOutputVideo)
			{
				num = Delegates.pwglGetVideoInfoNV(hpVideoDevice, pulCounterOutputPbuffer2, pulCounterOutputVideo2);
			}
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_OML_sync_control")]
	public unsafe static bool GetSyncValuesOML(nint hdc, [Out] long[] ust, [Out] long[] msc, [Out] long[] sbc)
	{
		bool num;
		fixed (long* ust2 = ust)
		{
			fixed (long* msc2 = msc)
			{
				fixed (long* sbc2 = sbc)
				{
					num = Delegates.pwglGetSyncValuesOML(hdc, ust2, msc2, sbc2);
				}
			}
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_OML_sync_control")]
	public unsafe static bool GetMscRateOML(nint hdc, [Out] int[] numerator, [Out] int[] denominator)
	{
		bool num;
		fixed (int* numerator2 = numerator)
		{
			fixed (int* denominator2 = denominator)
			{
				num = Delegates.pwglGetMscRateOML(hdc, numerator2, denominator2);
			}
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_OML_sync_control")]
	public static long SwapBuffersMscOML(nint hdc, long target_msc, long divisor, long remainder)
	{
		long num = Delegates.pwglSwapBuffersMscOML(hdc, target_msc, divisor, remainder);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_OML_sync_control")]
	public static long SwapLayerBuffersMscOML(nint hdc, int fuPlanes, long target_msc, long divisor, long remainder)
	{
		long num = Delegates.pwglSwapLayerBuffersMscOML(hdc, fuPlanes, target_msc, divisor, remainder);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_OML_sync_control")]
	public unsafe static bool WaitForMscOML(nint hdc, long target_msc, long divisor, long remainder, long[] ust, long[] msc, long[] sbc)
	{
		bool num;
		fixed (long* ust2 = ust)
		{
			fixed (long* msc2 = msc)
			{
				fixed (long* sbc2 = sbc)
				{
					num = Delegates.pwglWaitForMscOML(hdc, target_msc, divisor, remainder, ust2, msc2, sbc2);
				}
			}
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_OML_sync_control")]
	public unsafe static bool WaitForSbcOML(nint hdc, long target_sbc, long[] ust, long[] msc, long[] sbc)
	{
		bool num;
		fixed (long* ust2 = ust)
		{
			fixed (long* msc2 = msc)
			{
				fixed (long* sbc2 = sbc)
				{
					num = Delegates.pwglWaitForSbcOML(hdc, target_sbc, ust2, msc2, sbc2);
				}
			}
		}
		DebugCheckErrors(num);
		return num;
	}

	static Wgl()
	{
		_GetAddressDelegate = KhronosApi.GetProcAddressGLOS;
		ErrorHandling = ErrorHandlingMode.LogOnly;
		Version_100 = new KhronosVersion(1, 0, "wgl");
		BindAPI();
	}

	public static void BindAPI()
	{
		Khronos.KhronosApi.BindAPI<Wgl>("opengl32.dll", _GetAddressDelegate, null);
	}

	public static void DebugCheckErrors(object returnValue)
	{
		if (ErrorHandling == ErrorHandlingMode.Normal && returnValue != null)
		{
			switch (Type.GetTypeCode(returnValue.GetType()))
			{
			case TypeCode.Boolean:
				if (!(bool)returnValue)
				{
				}
				break;
			case TypeCode.String:
				_ = (string)returnValue;
				break;
			}
		}
		int lastWin32Error = Marshal.GetLastWin32Error();
		if (lastWin32Error != 0)
		{
			switch (ErrorHandling)
			{
			default:
				throw new WglException(lastWin32Error);
			case ErrorHandlingMode.LogOnly:
				Khronos.KhronosApi.LogComment(string.Format("GetLastError() = {0} [Error code {0}: {1}]", lastWin32Error, new Win32Exception(lastWin32Error).Message));
				break;
			case ErrorHandlingMode.Ignore:
				break;
			}
		}
	}

	[Conditional("GL_DEBUG")]
	protected new static void LogCommand(string name, object returnValue, params object[] args)
	{
		if (_LogContext == null)
		{
			_LogContext = new KhronosLogContext(typeof(Wgl));
		}
		Khronos.KhronosApi.RaiseLog(new KhronosLogEventArgs(_LogContext, name, args, returnValue));
	}

	public static int ChoosePixelFormat(nint deviceContext, [In] ref PIXELFORMATDESCRIPTOR pixelFormatDescriptor)
	{
		int result = UnsafeNativeMethods.ChoosePixelFormat(deviceContext, ref pixelFormatDescriptor);
		DebugCheckErrors(null);
		return result;
	}

	public static int DescribePixelFormat(nint hdc, int iPixelFormat, uint nBytes, [In][Out] ref PIXELFORMATDESCRIPTOR pixelFormatDescriptor)
	{
		int result = UnsafeNativeMethods.DescribePixelFormat(hdc, iPixelFormat, nBytes, ref pixelFormatDescriptor);
		DebugCheckErrors(null);
		return result;
	}

	public static bool SetPixelFormat(nint deviceContext, int pixelFormat, ref PIXELFORMATDESCRIPTOR pixelFormatDescriptor)
	{
		bool result = UnsafeNativeMethods.SetPixelFormat(deviceContext, pixelFormat, ref pixelFormatDescriptor);
		DebugCheckErrors(null);
		return result;
	}

	public static nint GetDC(nint windowHandle)
	{
		nint dC = UnsafeNativeMethods.GetDC(windowHandle);
		DebugCheckErrors(null);
		return dC;
	}

	public static bool ReleaseDC(nint windowHandle, nint deviceContext)
	{
		bool result = UnsafeNativeMethods.ReleaseDC(windowHandle, deviceContext);
		DebugCheckErrors(null);
		return result;
	}

	[RequiredByFeature("WGL_VERSION_1_0")]
	public static bool CopyContext(nint hglrcSrc, nint hglrcDst, uint mask)
	{
		bool num = Delegates.pwglCopyContext(hglrcSrc, hglrcDst, mask);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_VERSION_1_0")]
	public static nint CreateContext(nint hDc)
	{
		nint num = Delegates.pwglCreateContext(hDc);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_VERSION_1_0")]
	public static nint CreateLayerContext(nint hDc, int level)
	{
		nint num = Delegates.pwglCreateLayerContext(hDc, level);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_VERSION_1_0")]
	public static bool DeleteContext(nint oldContext)
	{
		bool num = Delegates.pwglDeleteContext(oldContext);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_VERSION_1_0")]
	public unsafe static bool DescribeLayerPlane(nint hDc, int pixelFormat, int layerPlane, uint nBytes, nint[] plpd)
	{
		bool num;
		fixed (nint* plpd2 = plpd)
		{
			num = Delegates.pwglDescribeLayerPlane(hDc, pixelFormat, layerPlane, nBytes, plpd2);
		}
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_VERSION_1_0")]
	public static nint GetCurrentContext()
	{
		nint num = Delegates.pwglGetCurrentContext();
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_VERSION_1_0")]
	public static nint GetCurrentDC()
	{
		nint num = Delegates.pwglGetCurrentDC();
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_VERSION_1_0")]
	public static int GetLayerPaletteEntries(nint hdc, int iLayerPlane, int iStart, int cEntries, nint pcr)
	{
		int num = Delegates.pwglGetLayerPaletteEntries(hdc, iLayerPlane, iStart, cEntries, pcr);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_VERSION_1_0")]
	public static nint GetProcAddress(string lpszProc)
	{
		nint num = Delegates.pwglGetProcAddress(lpszProc);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_VERSION_1_0")]
	public static bool MakeCurrent(nint hDc, nint newContext)
	{
		return Delegates.pwglMakeCurrent(hDc, newContext);
	}

	[RequiredByFeature("WGL_VERSION_1_0")]
	public static bool RealizeLayerPalette(nint hdc, int iLayerPlane, bool bRealize)
	{
		bool num = Delegates.pwglRealizeLayerPalette(hdc, iLayerPlane, bRealize);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_VERSION_1_0")]
	public static int SetLayerPaletteEntries(nint hdc, int iLayerPlane, int iStart, int cEntries, nint pcr)
	{
		int num = Delegates.pwglSetLayerPaletteEntries(hdc, iLayerPlane, iStart, cEntries, pcr);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_VERSION_1_0")]
	public static bool ShareLists(nint hrcSrvShare, nint hrcSrvSource)
	{
		bool num = Delegates.pwglShareLists(hrcSrvShare, hrcSrvSource);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_VERSION_1_0")]
	public static bool SwapLayerBuffers(nint hdc, uint fuFlags)
	{
		bool num = Delegates.pwglSwapLayerBuffers(hdc, fuFlags);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_VERSION_1_0")]
	public static bool UseFont(nint hDC, int first, int count, int listBase)
	{
		bool num = Delegates.pwglUseFontBitmaps(hDC, first, count, listBase);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_VERSION_1_0")]
	public static bool UseFontBitmapsA(nint hDC, int first, int count, int listBase)
	{
		bool num = Delegates.pwglUseFontBitmapsA(hDC, first, count, listBase);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_VERSION_1_0")]
	public static bool UseFontBitmapsW(nint hDC, int first, int count, int listBase)
	{
		bool num = Delegates.pwglUseFontBitmapsW(hDC, first, count, listBase);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_VERSION_1_0")]
	public static bool UseFont(nint hDC, int first, int count, int listBase, float deviation, float extrusion, int format, nint lpgmf)
	{
		bool num = Delegates.pwglUseFontOutlines(hDC, first, count, listBase, deviation, extrusion, format, lpgmf);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_VERSION_1_0")]
	public static bool UseFontOutlinesA(nint hDC, int first, int count, int listBase, float deviation, float extrusion, int format, nint lpgmf)
	{
		bool num = Delegates.pwglUseFontOutlinesA(hDC, first, count, listBase, deviation, extrusion, format, lpgmf);
		DebugCheckErrors(num);
		return num;
	}

	[RequiredByFeature("WGL_VERSION_1_0")]
	public static bool UseFontOutlinesW(nint hDC, int first, int count, int listBase, float deviation, float extrusion, int format, nint lpgmf)
	{
		bool num = Delegates.pwglUseFontOutlinesW(hDC, first, count, listBase, deviation, extrusion, format, lpgmf);
		DebugCheckErrors(num);
		return num;
	}
}
