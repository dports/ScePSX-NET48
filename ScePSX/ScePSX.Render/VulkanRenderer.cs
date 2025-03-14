using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Vulkan;
using Vulkan.Win32;

namespace ScePSX.Render;

public class VulkanRenderer : UserControl, IRenderer, IDisposable
{
	private VkInstance instance;

	private VkPhysicalDevice physicalDevice;

	private VkDevice device;

	private VkQueue graphicsQueue;

	private VkQueue presentQueue;

	private VkSurfaceKHR surface;

	private VkSwapchainKHR swapChain;

	private vkRawList<VkImage> swapChainImages = new vkRawList<VkImage>();

	private vkRawList<VkImageView> swapChainImageViews = new vkRawList<VkImageView>();

	private VkFormat swapChainImageFormat;

	private VkExtent2D swapChainExtent;

	private VkRenderPass renderPass;

	private VkPipeline graphicsPipeline;

	private VkPipelineLayout pipelineLayout;

	private vkRawList<VkFramebuffer> framebuffers = new vkRawList<VkFramebuffer>();

	private vkRawList<VkCommandBuffer> commandBuffers = new vkRawList<VkCommandBuffer>();

	private VkDescriptorSetLayout descriptorSetLayout;

	private VkDescriptorPool descriptorPool;

	private VkDescriptorSet descriptorSet;

	private vkRawList<VkFence> inFlightFences = new vkRawList<VkFence>();

	private int currentFrame;

	private VkRenderPassBeginInfo renderPassInfo;

	private VkCommandBufferBeginInfo drawbegininfo;

	private VkBuffer stagingBuffer;

	private VkDeviceMemory stagingBufferMemory;

	private VkImage image;

	private VkDeviceMemory imageMemory;

	private VkViewport viewport;

	private VkRect2D scissor;

	private VkCommandPool commandPool;

	private VkSubmitInfo submitInfo;

	private VkPresentInfoKHR presentInfo;

	private int graphicsQueueFamilyIndex = -1;

	private int presentQueueFamilyIndex = -1;

	private int currentWidth;

	private int currentHeight;

	private bool _isDisposed;

	public RenderMode Mode => RenderMode.Vulkan;

	[DllImport("user32.dll", SetLastError = true)]
	private static extern nint GetWindowLongPtr(nint hWnd, int nIndex);

	[DllImport("user32.dll", EntryPoint = "GetWindowLong", SetLastError = true)]
	private static extern nint GetWindowLong32(nint hWnd, int nIndex);

	public VulkanRenderer()
	{
		SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
		SetStyle(ControlStyles.Opaque, value: true);
		SetStyle(ControlStyles.DoubleBuffer, value: false);
		SetStyle(ControlStyles.ResizeRedraw, value: true);
		SetStyle(ControlStyles.UserPaint, value: true);
		DoubleBuffered = false;
		InitializeComponent();
	}

	private void InitializeComponent()
	{
		base.SuspendLayout();
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
		base.Size = new System.Drawing.Size(441, 246);
		base.Name = "VulkanRenderer";
		base.ResumeLayout(false);
	}

	public void Initialize(Control parentControl)
	{
		base.Parent = parentControl;
		Dock = DockStyle.Fill;
		base.Enabled = false;
		parentControl.Controls.Add(this);
	}

	public void SetParam(int Param)
	{
	}

	protected override void OnHandleCreated(EventArgs e)
	{
		base.OnHandleCreated(e);
		VulkanInit(base.Handle, base.ClientSize.Width, base.ClientSize.Height);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		if (!(device == VkDevice.Null) && !_isDisposed)
		{
			Draw();
			Present();
		}
	}

	protected override void OnResize(EventArgs e)
	{
		base.OnResize(e);
		if (base.ClientSize.Width != 0 && base.ClientSize.Height != 0 && !(device == VkDevice.Null))
		{
			VulkanNative.vkDeviceWaitIdle(device);
			CleanupSwapChain();
			CreateSwapChain(base.ClientSize.Width, base.ClientSize.Height);
			CreateImageViews();
			CreateFramebuffers();
			UpdateViewportAndScissor();
			Invalidate();
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (!_isDisposed)
		{
			if (disposing)
			{
				VulkanNative.vkDeviceWaitIdle(device);
				VulkanDispose();
			}
			_isDisposed = true;
			base.Dispose(disposing);
		}
	}

	public void RenderBuffer(int[] pixels, int width, int height, ScaleParam scale)
	{
		if (_isDisposed)
		{
			return;
		}
		if (base.InvokeRequired)
		{
			BeginInvoke((MethodInvoker)delegate
			{
				RenderBuffer(pixels, width, height, scale);
			});
			return;
		}
		if (scale.scale > 0)
		{
			pixels = PixelsScaler.Scale(pixels, width, height, scale.scale, scale.mode);
			width *= scale.scale;
			height *= scale.scale;
		}
		if (currentWidth != width || currentHeight != height)
		{
			InitializeResources(width, height);
			currentWidth = width;
			currentHeight = height;
			UpdateViewportAndScissor();
		}
		if (device != VkDevice.Null && stagingBufferMemory != VkDeviceMemory.Null)
		{
			UploadImage(pixels, width, height);
		}
		Invalidate();
	}

	public unsafe void Draw()
	{
		VkCommandBuffer commandBuffer = commandBuffers[currentFrame];
		renderPassInfo.framebuffer = framebuffers[currentFrame];
		renderPassInfo.renderArea.extent = swapChainExtent;
		VulkanNative.vkResetCommandBuffer(commandBuffer, VkCommandBufferResetFlags.None);
		VulkanNative.vkBeginCommandBuffer(commandBuffer, ref drawbegininfo);
		VulkanNative.vkCmdSetViewport(commandBuffer, 0u, 1u, ref viewport);
		VulkanNative.vkCmdSetScissor(commandBuffer, 0u, 1u, ref scissor);
		VulkanNative.vkCmdBeginRenderPass(commandBuffer, ref renderPassInfo, VkSubpassContents.Inline);
		VulkanNative.vkCmdBindPipeline(commandBuffer, VkPipelineBindPoint.Graphics, graphicsPipeline);
		VulkanNative.vkCmdBindDescriptorSets(commandBuffer, VkPipelineBindPoint.Graphics, pipelineLayout, 0u, 1u, ref descriptorSet, 0u, null);
		if (currentWidth > 0 && currentHeight > 0)
		{
			VulkanNative.vkCmdDraw(commandBuffer, 4u, 1u, 0u, 0u);
		}
		VulkanNative.vkCmdEndRenderPass(commandBuffer);
		VulkanNative.vkEndCommandBuffer(commandBuffer);
	}

	public unsafe void Present()
	{
		VulkanNative.vkWaitForFences(device, 1u, ref inFlightFences[currentFrame], true, ulong.MaxValue);
		VulkanNative.vkResetFences(device, 1u, ref inFlightFences[currentFrame]);
		VkCommandBuffer vkCommandBuffer = commandBuffers[currentFrame];
		submitInfo.pCommandBuffers = &vkCommandBuffer;
		VulkanNative.vkQueueSubmit(graphicsQueue, 1u, ref submitInfo, VkFence.Null);
		uint num = (uint)currentFrame;
		VkSwapchainKHR vkSwapchainKHR = swapChain;
		presentInfo.pSwapchains = &vkSwapchainKHR;
		presentInfo.pImageIndices = &num;
		VulkanNative.vkQueuePresentKHR(presentQueue, ref presentInfo);
		currentFrame = (currentFrame + 1) % (int)swapChainImages.Count;
	}

	public void VulkanInit(nint hwnd, int width, int height)
	{
		Console.ForegroundColor = ConsoleColor.Blue;
		Console.WriteLine("[VULKAN] Initialization....");
		CreateInstance();
		CreateSurface(hwnd);
		SelectPhysicalDevice();
		CreateLogicalDevice();
		CreateSwapChain(width, height);
		CreateImageViews();
		CreateRenderPass();
		CreateGraphicsPipeline();
		CreateFramebuffers();
		CreateCommandBuffers();
		renderPassInfo = VkRenderPassBeginInfo.New();
		renderPassInfo.clearValueCount = 0u;
		renderPassInfo.renderPass = renderPass;
		drawbegininfo = VkCommandBufferBeginInfo.New();
		drawbegininfo.sType = VkStructureType.CommandBufferBeginInfo;
		drawbegininfo.flags = VkCommandBufferUsageFlags.OneTimeSubmit;
		submitInfo = VkSubmitInfo.New();
		submitInfo.sType = VkStructureType.SubmitInfo;
		submitInfo.commandBufferCount = 1u;
		presentInfo = VkPresentInfoKHR.New();
		presentInfo.sType = VkStructureType.PresentInfoKHR;
		presentInfo.swapchainCount = 1u;
		Console.WriteLine("[VULKAN] Initializationed...");
		Console.ResetColor();
	}

	public void VulkanDispose()
	{
		CleanupResources();
		VulkanNative.vkDestroyPipeline(device, graphicsPipeline, IntPtr.Zero);
		VulkanNative.vkDestroyPipelineLayout(device, pipelineLayout, IntPtr.Zero);
		VulkanNative.vkDestroyRenderPass(device, renderPass, IntPtr.Zero);
		foreach (VkFramebuffer framebuffer in framebuffers)
		{
			VulkanNative.vkDestroyFramebuffer(device, framebuffer, IntPtr.Zero);
		}
		foreach (VkImageView swapChainImageView in swapChainImageViews)
		{
			VulkanNative.vkDestroyImageView(device, swapChainImageView, IntPtr.Zero);
		}
		VulkanNative.vkDestroySwapchainKHR(device, swapChain, IntPtr.Zero);
		VulkanNative.vkDestroyDevice(device, IntPtr.Zero);
		VulkanNative.vkDestroySurfaceKHR(instance, surface, IntPtr.Zero);
		VulkanNative.vkDestroyInstance(instance, IntPtr.Zero);
	}

	private unsafe void CleanupSwapChain()
	{
		foreach (VkFramebuffer framebuffer in framebuffers)
		{
			VulkanNative.vkDestroyFramebuffer(device, framebuffer, null);
		}
		foreach (VkImageView swapChainImageView in swapChainImageViews)
		{
			VulkanNative.vkDestroyImageView(device, swapChainImageView, null);
		}
		VulkanNative.vkDestroySwapchainKHR(device, swapChain, null);
		framebuffers.Clear();
		swapChainImageViews.Clear();
	}

	private void UpdateViewportAndScissor()
	{
		viewport = new VkViewport
		{
			x = 0f,
			y = 0f,
			width = swapChainExtent.width,
			height = swapChainExtent.height,
			minDepth = 0f,
			maxDepth = 1f
		};
		scissor = new VkRect2D
		{
			offset = new VkOffset2D
			{
				x = 0,
				y = 0
			},
			extent = swapChainExtent
		};
	}

	public static uint VK_MAKE_VERSION(uint major, uint minor, uint patch)
	{
		return (major << 22) | (minor << 12) | patch;
	}

	private unsafe void CreateInstance()
	{
		VkApplicationInfo vkApplicationInfo = default(VkApplicationInfo);
		vkApplicationInfo.sType = VkStructureType.ApplicationInfo;
		vkApplicationInfo.pApplicationName = vkStrings.AppName;
		vkApplicationInfo.applicationVersion = VK_MAKE_VERSION(1u, 0u, 0u);
		vkApplicationInfo.pEngineName = vkStrings.EngineName;
		vkApplicationInfo.engineVersion = VK_MAKE_VERSION(1u, 0u, 0u);
		vkApplicationInfo.apiVersion = VK_MAKE_VERSION(1u, 0u, 0u);
		VkApplicationInfo vkApplicationInfo2 = vkApplicationInfo;
		VkInstanceCreateInfo pCreateInfo = VkInstanceCreateInfo.New();
		pCreateInfo.pApplicationInfo = &vkApplicationInfo2;
		vkRawList<nint> vkRawList2 = new vkRawList<nint>();
		vkRawList2.Add((nint)vkStrings.VK_KHR_SURFACE_EXTENSION_NAME);
		vkRawList2.Add((nint)vkStrings.VK_KHR_WIN32_SURFACE_EXTENSION_NAME);
		fixed (nint* ppEnabledExtensionNames = &vkRawList2.Items[0])
		{
			pCreateInfo.enabledExtensionCount = vkRawList2.Count;
			pCreateInfo.ppEnabledExtensionNames = (byte**)ppEnabledExtensionNames;
			if (VulkanNative.vkCreateInstance(ref pCreateInfo, null, out instance) != 0)
			{
				throw new Exception("Failed to create Vulkan instance!");
			}
		}
	}

	private unsafe void CreateSurface(nint hwnd)
	{
		HINSTANCE hinstance = ((IntPtr.Size != 8) ? ((HINSTANCE)GetWindowLong32(hwnd, -6)) : ((HINSTANCE)GetWindowLongPtr(hwnd, -6)));
		VkWin32SurfaceCreateInfoKHR vkWin32SurfaceCreateInfoKHR = default(VkWin32SurfaceCreateInfoKHR);
		vkWin32SurfaceCreateInfoKHR.sType = VkStructureType.Win32SurfaceCreateInfoKHR;
		vkWin32SurfaceCreateInfoKHR.hinstance = hinstance;
		vkWin32SurfaceCreateInfoKHR.hwnd = hwnd;
		VkWin32SurfaceCreateInfoKHR vkWin32SurfaceCreateInfoKHR2 = vkWin32SurfaceCreateInfoKHR;
		if (VulkanNative.vkCreateWin32SurfaceKHR(instance, &vkWin32SurfaceCreateInfoKHR2, null, out surface) != 0)
		{
			throw new Exception("Failed to create Vulkan surface!");
		}
	}

	private unsafe void SelectPhysicalDevice()
	{
		uint pPhysicalDeviceCount = 0u;
		VulkanNative.vkEnumeratePhysicalDevices(instance, ref pPhysicalDeviceCount, null);
		if (pPhysicalDeviceCount == 0)
		{
			throw new Exception("No Vulkan-capable physical devices found!");
		}
		VkPhysicalDevice[] array = new VkPhysicalDevice[pPhysicalDeviceCount];
		VulkanNative.vkEnumeratePhysicalDevices(instance, &pPhysicalDeviceCount, (VkPhysicalDevice*)Marshal.UnsafeAddrOfPinnedArrayElement(array, 0));
		VkPhysicalDevice[] array2 = array;
		foreach (VkPhysicalDevice vkPhysicalDevice in array2)
		{
			VulkanNative.vkGetPhysicalDeviceProperties(vkPhysicalDevice, out var pProperties);
			VulkanNative.vkGetPhysicalDeviceFeatures(vkPhysicalDevice, out var _);
			uint pQueueFamilyPropertyCount = 0u;
			VulkanNative.vkGetPhysicalDeviceQueueFamilyProperties(vkPhysicalDevice, ref pQueueFamilyPropertyCount, null);
			VkQueueFamilyProperties[] array3 = new VkQueueFamilyProperties[pQueueFamilyPropertyCount];
			VulkanNative.vkGetPhysicalDeviceQueueFamilyProperties(vkPhysicalDevice, &pQueueFamilyPropertyCount, (VkQueueFamilyProperties*)Marshal.UnsafeAddrOfPinnedArrayElement(array3, 0));
			bool flag = false;
			for (int j = 0; j < array3.Length; j++)
			{
				if ((array3[j].queueFlags & VkQueueFlags.Graphics) != 0)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				physicalDevice = vkPhysicalDevice;
				Console.WriteLine("[VULKAN] Selected physical device: " + Marshal.PtrToStringAnsi((nint)pProperties.deviceName));
				return;
			}
		}
		throw new Exception("No suitable physical device found!");
	}

	private unsafe void CreateLogicalDevice()
	{
		uint pQueueFamilyPropertyCount = 0u;
		VulkanNative.vkGetPhysicalDeviceQueueFamilyProperties(physicalDevice, ref pQueueFamilyPropertyCount, null);
		VkQueueFamilyProperties[] array = new VkQueueFamilyProperties[pQueueFamilyPropertyCount];
		VulkanNative.vkGetPhysicalDeviceQueueFamilyProperties(physicalDevice, &pQueueFamilyPropertyCount, (VkQueueFamilyProperties*)Marshal.UnsafeAddrOfPinnedArrayElement(array, 0));
		for (int i = 0; i < array.Length; i++)
		{
			if ((array[i].queueFlags & VkQueueFlags.Graphics) != 0)
			{
				graphicsQueueFamilyIndex = i;
			}
			VulkanNative.vkGetPhysicalDeviceSurfaceSupportKHR(physicalDevice, (uint)i, surface, out var pSupported);
			if ((bool)pSupported)
			{
				presentQueueFamilyIndex = i;
			}
			if (graphicsQueueFamilyIndex != -1 && presentQueueFamilyIndex != -1)
			{
				break;
			}
		}
		if (graphicsQueueFamilyIndex == -1 || presentQueueFamilyIndex == -1)
		{
			throw new Exception("Failed to find required queue families!");
		}
		float num = 1f;
		VkDeviceQueueCreateInfo vkDeviceQueueCreateInfo = default(VkDeviceQueueCreateInfo);
		vkDeviceQueueCreateInfo.sType = VkStructureType.DeviceQueueCreateInfo;
		vkDeviceQueueCreateInfo.queueFamilyIndex = (uint)graphicsQueueFamilyIndex;
		vkDeviceQueueCreateInfo.queueCount = 1u;
		vkDeviceQueueCreateInfo.pQueuePriorities = &num;
		VkDeviceQueueCreateInfo vkDeviceQueueCreateInfo2 = vkDeviceQueueCreateInfo;
		VkDeviceCreateInfo vkDeviceCreateInfo = default(VkDeviceCreateInfo);
		vkDeviceCreateInfo.sType = VkStructureType.DeviceCreateInfo;
		vkDeviceCreateInfo.queueCreateInfoCount = 1u;
		vkDeviceCreateInfo.pQueueCreateInfos = &vkDeviceQueueCreateInfo2;
		vkDeviceCreateInfo.pEnabledFeatures = null;
		VkDeviceCreateInfo vkDeviceCreateInfo2 = vkDeviceCreateInfo;
		vkRawList<nint> vkRawList2 = new vkRawList<nint>();
		vkRawList2.Add((nint)vkStrings.VK_KHR_SWAPCHAIN_EXTENSION_NAME);
		fixed (nint* ppEnabledExtensionNames = &vkRawList2.Items[0])
		{
			vkDeviceCreateInfo2.enabledExtensionCount = vkRawList2.Count;
			vkDeviceCreateInfo2.ppEnabledExtensionNames = (byte**)ppEnabledExtensionNames;
			if (VulkanNative.vkCreateDevice(physicalDevice, &vkDeviceCreateInfo2, null, out device) != 0)
			{
				throw new Exception("Failed to create logical device!");
			}
		}
		VulkanNative.vkGetDeviceQueue(device, (uint)graphicsQueueFamilyIndex, 0u, out graphicsQueue);
		VulkanNative.vkGetDeviceQueue(device, (uint)presentQueueFamilyIndex, 0u, out presentQueue);
	}

	private unsafe void CreateRenderPass()
	{
		VkAttachmentDescription vkAttachmentDescription = default(VkAttachmentDescription);
		vkAttachmentDescription.format = swapChainImageFormat;
		vkAttachmentDescription.samples = VkSampleCountFlags.Count1;
		vkAttachmentDescription.loadOp = VkAttachmentLoadOp.Clear;
		vkAttachmentDescription.storeOp = VkAttachmentStoreOp.Store;
		vkAttachmentDescription.stencilLoadOp = VkAttachmentLoadOp.DontCare;
		vkAttachmentDescription.stencilStoreOp = VkAttachmentStoreOp.DontCare;
		vkAttachmentDescription.initialLayout = VkImageLayout.Undefined;
		vkAttachmentDescription.finalLayout = VkImageLayout.PresentSrcKHR;
		VkAttachmentDescription vkAttachmentDescription2 = vkAttachmentDescription;
		VkAttachmentReference vkAttachmentReference = default(VkAttachmentReference);
		vkAttachmentReference.attachment = 0u;
		vkAttachmentReference.layout = VkImageLayout.ColorAttachmentOptimal;
		VkAttachmentReference vkAttachmentReference2 = vkAttachmentReference;
		VkSubpassDescription vkSubpassDescription = default(VkSubpassDescription);
		vkSubpassDescription.pipelineBindPoint = VkPipelineBindPoint.Graphics;
		vkSubpassDescription.colorAttachmentCount = 1u;
		vkSubpassDescription.pColorAttachments = &vkAttachmentReference2;
		VkSubpassDescription vkSubpassDescription2 = vkSubpassDescription;
		VkSubpassDependency vkSubpassDependency = default(VkSubpassDependency);
		vkSubpassDependency.srcSubpass = uint.MaxValue;
		vkSubpassDependency.dstSubpass = 0u;
		vkSubpassDependency.srcStageMask = VkPipelineStageFlags.ColorAttachmentOutput;
		vkSubpassDependency.dstStageMask = VkPipelineStageFlags.ColorAttachmentOutput;
		vkSubpassDependency.srcAccessMask = VkAccessFlags.None;
		vkSubpassDependency.dstAccessMask = VkAccessFlags.ColorAttachmentWrite;
		VkSubpassDependency vkSubpassDependency2 = vkSubpassDependency;
		VkRenderPassCreateInfo vkRenderPassCreateInfo = default(VkRenderPassCreateInfo);
		vkRenderPassCreateInfo.sType = VkStructureType.RenderPassCreateInfo;
		vkRenderPassCreateInfo.attachmentCount = 1u;
		vkRenderPassCreateInfo.pAttachments = &vkAttachmentDescription2;
		vkRenderPassCreateInfo.subpassCount = 1u;
		vkRenderPassCreateInfo.pSubpasses = &vkSubpassDescription2;
		vkRenderPassCreateInfo.dependencyCount = 1u;
		vkRenderPassCreateInfo.pDependencies = &vkSubpassDependency2;
		VkRenderPassCreateInfo vkRenderPassCreateInfo2 = vkRenderPassCreateInfo;
		if (VulkanNative.vkCreateRenderPass(device, &vkRenderPassCreateInfo2, null, out renderPass) != 0)
		{
			throw new Exception("Failed to create render pass!");
		}
	}

	private unsafe void CreateDescriptorSetLayout()
	{
		VkDescriptorSetLayoutBinding vkDescriptorSetLayoutBinding = default(VkDescriptorSetLayoutBinding);
		vkDescriptorSetLayoutBinding.binding = 0u;
		vkDescriptorSetLayoutBinding.descriptorType = VkDescriptorType.CombinedImageSampler;
		vkDescriptorSetLayoutBinding.descriptorCount = 1u;
		vkDescriptorSetLayoutBinding.stageFlags = VkShaderStageFlags.Fragment;
		VkDescriptorSetLayoutBinding vkDescriptorSetLayoutBinding2 = vkDescriptorSetLayoutBinding;
		VkDescriptorSetLayoutCreateInfo vkDescriptorSetLayoutCreateInfo = default(VkDescriptorSetLayoutCreateInfo);
		vkDescriptorSetLayoutCreateInfo.sType = VkStructureType.DescriptorSetLayoutCreateInfo;
		vkDescriptorSetLayoutCreateInfo.bindingCount = 1u;
		vkDescriptorSetLayoutCreateInfo.pBindings = &vkDescriptorSetLayoutBinding2;
		VkDescriptorSetLayoutCreateInfo pCreateInfo = vkDescriptorSetLayoutCreateInfo;
		if (VulkanNative.vkCreateDescriptorSetLayout(device, ref pCreateInfo, null, out descriptorSetLayout) != 0)
		{
			throw new Exception("Failed to create descriptor set layout!");
		}
	}

	private byte[] LoadShader(string filename)
	{
		return File.ReadAllBytes(filename);
	}

	private unsafe void CreateGraphicsPipeline()
	{
		byte[] code = LoadShader("./Shaders/shader.vert.spv");
		byte[] code2 = LoadShader("./Shaders/shader.frag.spv");
		VkShaderModule vkShaderModule = CreateShaderModule(code);
		VkShaderModule vkShaderModule2 = CreateShaderModule(code2);
		VkPipelineShaderStageCreateInfo vkPipelineShaderStageCreateInfo = default(VkPipelineShaderStageCreateInfo);
		vkPipelineShaderStageCreateInfo.sType = VkStructureType.PipelineShaderStageCreateInfo;
		vkPipelineShaderStageCreateInfo.stage = VkShaderStageFlags.Vertex;
		vkPipelineShaderStageCreateInfo.module = vkShaderModule;
		vkPipelineShaderStageCreateInfo.pName = vkStrings.main;
		VkPipelineShaderStageCreateInfo first = vkPipelineShaderStageCreateInfo;
		vkPipelineShaderStageCreateInfo = default(VkPipelineShaderStageCreateInfo);
		vkPipelineShaderStageCreateInfo.sType = VkStructureType.PipelineShaderStageCreateInfo;
		vkPipelineShaderStageCreateInfo.stage = VkShaderStageFlags.Fragment;
		vkPipelineShaderStageCreateInfo.module = vkShaderModule2;
		vkPipelineShaderStageCreateInfo.pName = vkStrings.main;
		VkPipelineShaderStageCreateInfo second = vkPipelineShaderStageCreateInfo;
		VkPipelineVertexInputStateCreateInfo vkPipelineVertexInputStateCreateInfo = default(VkPipelineVertexInputStateCreateInfo);
		vkPipelineVertexInputStateCreateInfo.sType = VkStructureType.PipelineVertexInputStateCreateInfo;
		vkPipelineVertexInputStateCreateInfo.vertexBindingDescriptionCount = 0u;
		vkPipelineVertexInputStateCreateInfo.pVertexBindingDescriptions = null;
		vkPipelineVertexInputStateCreateInfo.vertexAttributeDescriptionCount = 0u;
		vkPipelineVertexInputStateCreateInfo.pVertexAttributeDescriptions = null;
		VkPipelineVertexInputStateCreateInfo vkPipelineVertexInputStateCreateInfo2 = vkPipelineVertexInputStateCreateInfo;
		VkPipelineInputAssemblyStateCreateInfo vkPipelineInputAssemblyStateCreateInfo = default(VkPipelineInputAssemblyStateCreateInfo);
		vkPipelineInputAssemblyStateCreateInfo.sType = VkStructureType.PipelineInputAssemblyStateCreateInfo;
		vkPipelineInputAssemblyStateCreateInfo.topology = VkPrimitiveTopology.TriangleStrip;
		vkPipelineInputAssemblyStateCreateInfo.primitiveRestartEnable = false;
		VkPipelineInputAssemblyStateCreateInfo vkPipelineInputAssemblyStateCreateInfo2 = vkPipelineInputAssemblyStateCreateInfo;
		VkViewport vkViewport = default(VkViewport);
		vkViewport.x = 0f;
		vkViewport.y = 0f;
		vkViewport.width = swapChainExtent.width;
		vkViewport.height = swapChainExtent.height;
		vkViewport.minDepth = 0f;
		vkViewport.maxDepth = 1f;
		VkViewport vkViewport2 = vkViewport;
		VkRect2D vkRect2D = default(VkRect2D);
		vkRect2D.offset = new VkOffset2D
		{
			x = 0,
			y = 0
		};
		vkRect2D.extent = swapChainExtent;
		VkRect2D vkRect2D2 = vkRect2D;
		VkPipelineViewportStateCreateInfo vkPipelineViewportStateCreateInfo = default(VkPipelineViewportStateCreateInfo);
		vkPipelineViewportStateCreateInfo.sType = VkStructureType.PipelineViewportStateCreateInfo;
		vkPipelineViewportStateCreateInfo.viewportCount = 1u;
		vkPipelineViewportStateCreateInfo.pViewports = &vkViewport2;
		vkPipelineViewportStateCreateInfo.scissorCount = 1u;
		vkPipelineViewportStateCreateInfo.pScissors = &vkRect2D2;
		VkPipelineViewportStateCreateInfo vkPipelineViewportStateCreateInfo2 = vkPipelineViewportStateCreateInfo;
		VkPipelineRasterizationStateCreateInfo vkPipelineRasterizationStateCreateInfo = default(VkPipelineRasterizationStateCreateInfo);
		vkPipelineRasterizationStateCreateInfo.sType = VkStructureType.PipelineRasterizationStateCreateInfo;
		vkPipelineRasterizationStateCreateInfo.depthClampEnable = false;
		vkPipelineRasterizationStateCreateInfo.rasterizerDiscardEnable = false;
		vkPipelineRasterizationStateCreateInfo.polygonMode = VkPolygonMode.Fill;
		vkPipelineRasterizationStateCreateInfo.lineWidth = 1f;
		vkPipelineRasterizationStateCreateInfo.cullMode = VkCullModeFlags.None;
		vkPipelineRasterizationStateCreateInfo.frontFace = VkFrontFace.Clockwise;
		vkPipelineRasterizationStateCreateInfo.depthBiasEnable = false;
		VkPipelineRasterizationStateCreateInfo vkPipelineRasterizationStateCreateInfo2 = vkPipelineRasterizationStateCreateInfo;
		VkPipelineMultisampleStateCreateInfo vkPipelineMultisampleStateCreateInfo = default(VkPipelineMultisampleStateCreateInfo);
		vkPipelineMultisampleStateCreateInfo.sType = VkStructureType.PipelineMultisampleStateCreateInfo;
		vkPipelineMultisampleStateCreateInfo.sampleShadingEnable = false;
		vkPipelineMultisampleStateCreateInfo.rasterizationSamples = VkSampleCountFlags.Count1;
		VkPipelineMultisampleStateCreateInfo vkPipelineMultisampleStateCreateInfo2 = vkPipelineMultisampleStateCreateInfo;
		VkPipelineColorBlendAttachmentState vkPipelineColorBlendAttachmentState = default(VkPipelineColorBlendAttachmentState);
		vkPipelineColorBlendAttachmentState.colorWriteMask = VkColorComponentFlags.R | VkColorComponentFlags.G | VkColorComponentFlags.B | VkColorComponentFlags.A;
		vkPipelineColorBlendAttachmentState.blendEnable = false;
		VkPipelineColorBlendAttachmentState vkPipelineColorBlendAttachmentState2 = vkPipelineColorBlendAttachmentState;
		VkPipelineColorBlendStateCreateInfo vkPipelineColorBlendStateCreateInfo = default(VkPipelineColorBlendStateCreateInfo);
		vkPipelineColorBlendStateCreateInfo.sType = VkStructureType.PipelineColorBlendStateCreateInfo;
		vkPipelineColorBlendStateCreateInfo.logicOpEnable = false;
		vkPipelineColorBlendStateCreateInfo.logicOp = VkLogicOp.Copy;
		vkPipelineColorBlendStateCreateInfo.attachmentCount = 1u;
		vkPipelineColorBlendStateCreateInfo.pAttachments = &vkPipelineColorBlendAttachmentState2;
		vkPipelineColorBlendStateCreateInfo.blendConstants_0 = 0f;
		vkPipelineColorBlendStateCreateInfo.blendConstants_1 = 0f;
		vkPipelineColorBlendStateCreateInfo.blendConstants_2 = 0f;
		vkPipelineColorBlendStateCreateInfo.blendConstants_3 = 0f;
		VkPipelineColorBlendStateCreateInfo vkPipelineColorBlendStateCreateInfo2 = vkPipelineColorBlendStateCreateInfo;
		CreateDescriptorSetLayout();
		VkDescriptorSetLayout vkDescriptorSetLayout = descriptorSetLayout;
		VkPipelineLayoutCreateInfo vkPipelineLayoutCreateInfo = default(VkPipelineLayoutCreateInfo);
		vkPipelineLayoutCreateInfo.sType = VkStructureType.PipelineLayoutCreateInfo;
		vkPipelineLayoutCreateInfo.setLayoutCount = 1u;
		vkPipelineLayoutCreateInfo.pSetLayouts = &vkDescriptorSetLayout;
		vkPipelineLayoutCreateInfo.pushConstantRangeCount = 0u;
		vkPipelineLayoutCreateInfo.pPushConstantRanges = null;
		VkPipelineLayoutCreateInfo vkPipelineLayoutCreateInfo2 = vkPipelineLayoutCreateInfo;
		if (VulkanNative.vkCreatePipelineLayout(device, &vkPipelineLayoutCreateInfo2, null, out pipelineLayout) != 0)
		{
			throw new Exception("Failed to create pipeline layout!");
		}
		vkFixedArray2<VkDynamicState> vkFixedArray7 = default(vkFixedArray2<VkDynamicState>);
		vkFixedArray7.First = VkDynamicState.Viewport;
		vkFixedArray7.Second = VkDynamicState.Scissor;
		VkPipelineDynamicStateCreateInfo vkPipelineDynamicStateCreateInfo = VkPipelineDynamicStateCreateInfo.New();
		vkPipelineDynamicStateCreateInfo.dynamicStateCount = vkFixedArray7.Count;
		vkPipelineDynamicStateCreateInfo.pDynamicStates = &vkFixedArray7.First;
		vkFixedArray2<VkPipelineShaderStageCreateInfo> vkFixedArray8 = default(vkFixedArray2<VkPipelineShaderStageCreateInfo>);
		vkFixedArray8.First = first;
		vkFixedArray8.Second = second;
		VkGraphicsPipelineCreateInfo vkGraphicsPipelineCreateInfo = default(VkGraphicsPipelineCreateInfo);
		vkGraphicsPipelineCreateInfo.sType = VkStructureType.GraphicsPipelineCreateInfo;
		vkGraphicsPipelineCreateInfo.stageCount = vkFixedArray8.Count;
		vkGraphicsPipelineCreateInfo.pStages = &vkFixedArray8.First;
		vkGraphicsPipelineCreateInfo.pVertexInputState = &vkPipelineVertexInputStateCreateInfo2;
		vkGraphicsPipelineCreateInfo.pInputAssemblyState = &vkPipelineInputAssemblyStateCreateInfo2;
		vkGraphicsPipelineCreateInfo.pViewportState = &vkPipelineViewportStateCreateInfo2;
		vkGraphicsPipelineCreateInfo.pRasterizationState = &vkPipelineRasterizationStateCreateInfo2;
		vkGraphicsPipelineCreateInfo.pMultisampleState = &vkPipelineMultisampleStateCreateInfo2;
		vkGraphicsPipelineCreateInfo.pColorBlendState = &vkPipelineColorBlendStateCreateInfo2;
		vkGraphicsPipelineCreateInfo.layout = pipelineLayout;
		vkGraphicsPipelineCreateInfo.renderPass = renderPass;
		vkGraphicsPipelineCreateInfo.subpass = 0u;
		vkGraphicsPipelineCreateInfo.basePipelineHandle = VkPipeline.Null;
		vkGraphicsPipelineCreateInfo.basePipelineIndex = -1;
		vkGraphicsPipelineCreateInfo.pDynamicState = &vkPipelineDynamicStateCreateInfo;
		VkGraphicsPipelineCreateInfo vkGraphicsPipelineCreateInfo2 = vkGraphicsPipelineCreateInfo;
		if (VulkanNative.vkCreateGraphicsPipelines(device, VkPipelineCache.Null, 1u, &vkGraphicsPipelineCreateInfo2, null, out graphicsPipeline) != 0)
		{
			throw new Exception("Failed to create graphics pipeline!");
		}
		Console.WriteLine("[VULKAN] GraphicsPipelines Created.");
		VulkanNative.vkDestroyShaderModule(device, vkShaderModule, null);
		VulkanNative.vkDestroyShaderModule(device, vkShaderModule2, null);
	}

	private unsafe VkShaderModule CreateShaderModule(byte[] code)
	{
		VkShaderModuleCreateInfo vkShaderModuleCreateInfo = default(VkShaderModuleCreateInfo);
		vkShaderModuleCreateInfo.sType = VkStructureType.ShaderModuleCreateInfo;
		vkShaderModuleCreateInfo.codeSize = (nuint)code.Length;
		vkShaderModuleCreateInfo.pCode = (uint*)Marshal.UnsafeAddrOfPinnedArrayElement(code, 0);
		VkShaderModuleCreateInfo vkShaderModuleCreateInfo2 = vkShaderModuleCreateInfo;
		if (VulkanNative.vkCreateShaderModule(device, &vkShaderModuleCreateInfo2, null, out var pShaderModule) != 0)
		{
			throw new Exception("Failed to create shader module!");
		}
		return pShaderModule;
	}

	private unsafe void CreateSwapChain(int width, int height)
	{
		VkSurfaceFormatKHR vkSurfaceFormatKHR = ChooseSurfaceFormat();
		VkPresentModeKHR presentMode = ChoosePresentMode();
		VkExtent2D imageExtent = new VkExtent2D((uint)width, (uint)height);
		uint swapChainImageCount = GetSwapChainImageCount();
		VkSwapchainCreateInfoKHR vkSwapchainCreateInfoKHR = default(VkSwapchainCreateInfoKHR);
		vkSwapchainCreateInfoKHR.sType = VkStructureType.SwapchainCreateInfoKHR;
		vkSwapchainCreateInfoKHR.surface = surface;
		vkSwapchainCreateInfoKHR.minImageCount = swapChainImageCount;
		vkSwapchainCreateInfoKHR.imageFormat = vkSurfaceFormatKHR.format;
		vkSwapchainCreateInfoKHR.imageColorSpace = vkSurfaceFormatKHR.colorSpace;
		vkSwapchainCreateInfoKHR.imageExtent = imageExtent;
		vkSwapchainCreateInfoKHR.imageArrayLayers = 1u;
		vkSwapchainCreateInfoKHR.imageUsage = VkImageUsageFlags.ColorAttachment;
		vkSwapchainCreateInfoKHR.preTransform = VkSurfaceTransformFlagsKHR.InheritKHR;
		vkSwapchainCreateInfoKHR.compositeAlpha = VkCompositeAlphaFlagsKHR.OpaqueKHR;
		vkSwapchainCreateInfoKHR.presentMode = presentMode;
		vkSwapchainCreateInfoKHR.clipped = true;
		VkSwapchainCreateInfoKHR pCreateInfo = vkSwapchainCreateInfoKHR;
		if (VulkanNative.vkCreateSwapchainKHR(device, ref pCreateInfo, null, out swapChain) != 0)
		{
			throw new Exception("Failed to create swap chain!");
		}
		VulkanNative.vkGetSwapchainImagesKHR(device, swapChain, &swapChainImageCount, null);
		swapChainImages.Resize(swapChainImageCount);
		VulkanNative.vkGetSwapchainImagesKHR(device, swapChain, &swapChainImageCount, out swapChainImages[0]);
		swapChainImageFormat = vkSurfaceFormatKHR.format;
		swapChainExtent = imageExtent;
	}

	private unsafe void CreateImageViews()
	{
		swapChainImageViews.Resize(swapChainImages.Count);
		for (int i = 0; i < swapChainImages.Count; i++)
		{
			VkImageViewCreateInfo pCreateInfo = VkImageViewCreateInfo.New();
			pCreateInfo.image = swapChainImages[i];
			pCreateInfo.viewType = VkImageViewType.Image2D;
			pCreateInfo.format = swapChainImageFormat;
			pCreateInfo.subresourceRange.aspectMask = VkImageAspectFlags.Color;
			pCreateInfo.subresourceRange.baseMipLevel = 0u;
			pCreateInfo.subresourceRange.levelCount = 1u;
			pCreateInfo.subresourceRange.baseArrayLayer = 0u;
			pCreateInfo.subresourceRange.layerCount = 1u;
			if (VulkanNative.vkCreateImageView(device, ref pCreateInfo, null, out swapChainImageViews[i]) != 0)
			{
				throw new Exception("Failed to create image view!");
			}
		}
	}

	private unsafe void CreateFramebuffers()
	{
		framebuffers.Resize(swapChainImageViews.Count);
		for (uint num = 0u; num < framebuffers.Count; num++)
		{
			VkImageView vkImageView = swapChainImageViews[num];
			VkFramebufferCreateInfo pCreateInfo = VkFramebufferCreateInfo.New();
			pCreateInfo.renderPass = renderPass;
			pCreateInfo.attachmentCount = 1u;
			pCreateInfo.pAttachments = &vkImageView;
			pCreateInfo.width = swapChainExtent.width;
			pCreateInfo.height = swapChainExtent.height;
			pCreateInfo.layers = 1u;
			VulkanNative.vkCreateFramebuffer(device, ref pCreateInfo, null, out framebuffers[num]);
		}
	}

	private unsafe void CreateCommandBuffers()
	{
		commandBuffers.Resize(framebuffers.Count);
		VkCommandPoolCreateInfo vkCommandPoolCreateInfo = default(VkCommandPoolCreateInfo);
		vkCommandPoolCreateInfo.sType = VkStructureType.CommandPoolCreateInfo;
		vkCommandPoolCreateInfo.queueFamilyIndex = (uint)graphicsQueueFamilyIndex;
		vkCommandPoolCreateInfo.flags = VkCommandPoolCreateFlags.ResetCommandBuffer;
		VkCommandPoolCreateInfo vkCommandPoolCreateInfo2 = vkCommandPoolCreateInfo;
		if (VulkanNative.vkCreateCommandPool(device, &vkCommandPoolCreateInfo2, null, out commandPool) != 0)
		{
			throw new Exception("Failed to create command pool!");
		}
		VkCommandBufferAllocateInfo vkCommandBufferAllocateInfo = default(VkCommandBufferAllocateInfo);
		vkCommandBufferAllocateInfo.sType = VkStructureType.CommandBufferAllocateInfo;
		vkCommandBufferAllocateInfo.commandPool = commandPool;
		vkCommandBufferAllocateInfo.level = VkCommandBufferLevel.Primary;
		vkCommandBufferAllocateInfo.commandBufferCount = framebuffers.Count;
		VkCommandBufferAllocateInfo vkCommandBufferAllocateInfo2 = vkCommandBufferAllocateInfo;
		_ = new VkCommandBuffer[framebuffers.Count];
		if (VulkanNative.vkAllocateCommandBuffers(device, &vkCommandBufferAllocateInfo2, out commandBuffers[0]) != 0)
		{
			throw new Exception("Failed to allocate command buffers!");
		}
		VkFenceCreateInfo vkFenceCreateInfo = default(VkFenceCreateInfo);
		vkFenceCreateInfo.sType = VkStructureType.FenceCreateInfo;
		vkFenceCreateInfo.flags = VkFenceCreateFlags.Signaled;
		VkFenceCreateInfo pCreateInfo = vkFenceCreateInfo;
		inFlightFences.Resize(framebuffers.Count);
		for (int i = 0; i < inFlightFences.Count; i++)
		{
			if (VulkanNative.vkCreateFence(device, ref pCreateInfo, null, out inFlightFences[i]) != 0)
			{
				throw new Exception("Failed to create fence!");
			}
		}
	}

	private unsafe void CreateDescriptorPool()
	{
		vkFixedArray2<VkDescriptorPoolSize> vkFixedArray7 = default(vkFixedArray2<VkDescriptorPoolSize>);
		vkFixedArray7.First.type = VkDescriptorType.CombinedImageSampler;
		vkFixedArray7.First.descriptorCount = 1u;
		VkDescriptorPoolCreateInfo pCreateInfo = VkDescriptorPoolCreateInfo.New();
		pCreateInfo.poolSizeCount = 1u;
		pCreateInfo.pPoolSizes = &vkFixedArray7.First;
		pCreateInfo.maxSets = 1u;
		if (VulkanNative.vkCreateDescriptorPool(device, ref pCreateInfo, null, out descriptorPool) != 0)
		{
			throw new Exception("Failed to create descriptor pool!");
		}
	}

	private unsafe void CreateDescriptorSet()
	{
		VkDescriptorSetLayout vkDescriptorSetLayout = descriptorSetLayout;
		VkDescriptorSetAllocateInfo pAllocateInfo = VkDescriptorSetAllocateInfo.New();
		pAllocateInfo.descriptorPool = descriptorPool;
		pAllocateInfo.pSetLayouts = &vkDescriptorSetLayout;
		pAllocateInfo.descriptorSetCount = 1u;
		if (VulkanNative.vkAllocateDescriptorSets(device, ref pAllocateInfo, out descriptorSet) != 0)
		{
			throw new Exception("Failed to allocate descriptor set!");
		}
		VkSamplerCreateInfo vkSamplerCreateInfo = default(VkSamplerCreateInfo);
		vkSamplerCreateInfo.sType = VkStructureType.SamplerCreateInfo;
		vkSamplerCreateInfo.magFilter = VkFilter.Linear;
		vkSamplerCreateInfo.minFilter = VkFilter.Linear;
		vkSamplerCreateInfo.addressModeU = VkSamplerAddressMode.ClampToEdge;
		vkSamplerCreateInfo.addressModeV = VkSamplerAddressMode.ClampToEdge;
		vkSamplerCreateInfo.addressModeW = VkSamplerAddressMode.ClampToEdge;
		vkSamplerCreateInfo.anisotropyEnable = false;
		vkSamplerCreateInfo.borderColor = VkBorderColor.IntOpaqueBlack;
		vkSamplerCreateInfo.unnormalizedCoordinates = false;
		vkSamplerCreateInfo.compareEnable = false;
		vkSamplerCreateInfo.compareOp = VkCompareOp.Always;
		vkSamplerCreateInfo.mipLodBias = 0f;
		vkSamplerCreateInfo.minLod = 0f;
		vkSamplerCreateInfo.maxLod = 0f;
		VkSamplerCreateInfo vkSamplerCreateInfo2 = vkSamplerCreateInfo;
		if (VulkanNative.vkCreateSampler(device, &vkSamplerCreateInfo2, null, out var pSampler) != 0)
		{
			throw new Exception("Failed to create texture sampler!");
		}
		VkImageViewCreateInfo vkImageViewCreateInfo = default(VkImageViewCreateInfo);
		vkImageViewCreateInfo.sType = VkStructureType.ImageViewCreateInfo;
		vkImageViewCreateInfo.image = image;
		vkImageViewCreateInfo.viewType = VkImageViewType.Image2D;
		vkImageViewCreateInfo.format = VkFormat.B8g8r8a8Unorm;
		vkImageViewCreateInfo.subresourceRange = new VkImageSubresourceRange
		{
			aspectMask = VkImageAspectFlags.Color,
			baseMipLevel = 0u,
			levelCount = 1u,
			baseArrayLayer = 0u,
			layerCount = 1u
		};
		VkImageViewCreateInfo vkImageViewCreateInfo2 = vkImageViewCreateInfo;
		if (VulkanNative.vkCreateImageView(device, &vkImageViewCreateInfo2, null, out var pView) != 0)
		{
			throw new Exception("Failed to create texture image view!");
		}
		VkDescriptorImageInfo vkDescriptorImageInfo = default(VkDescriptorImageInfo);
		vkDescriptorImageInfo.imageLayout = VkImageLayout.ShaderReadOnlyOptimal;
		vkDescriptorImageInfo.imageView = pView;
		vkDescriptorImageInfo.sampler = pSampler;
		VkDescriptorImageInfo vkDescriptorImageInfo2 = vkDescriptorImageInfo;
		VkWriteDescriptorSet vkWriteDescriptorSet = default(VkWriteDescriptorSet);
		vkWriteDescriptorSet.sType = VkStructureType.WriteDescriptorSet;
		vkWriteDescriptorSet.dstSet = descriptorSet;
		vkWriteDescriptorSet.dstBinding = 0u;
		vkWriteDescriptorSet.dstArrayElement = 0u;
		vkWriteDescriptorSet.descriptorType = VkDescriptorType.CombinedImageSampler;
		vkWriteDescriptorSet.descriptorCount = 1u;
		vkWriteDescriptorSet.pImageInfo = &vkDescriptorImageInfo2;
		VkWriteDescriptorSet vkWriteDescriptorSet2 = vkWriteDescriptorSet;
		VulkanNative.vkUpdateDescriptorSets(device, 1u, &vkWriteDescriptorSet2, 0u, null);
	}

	private unsafe VkSurfaceFormatKHR ChooseSurfaceFormat()
	{
		uint pSurfaceFormatCount = 0u;
		VulkanNative.vkGetPhysicalDeviceSurfaceFormatsKHR(physicalDevice, surface, ref pSurfaceFormatCount, null);
		if (pSurfaceFormatCount == 0)
		{
			throw new Exception("No surface formats found!");
		}
		vkRawList<VkSurfaceFormatKHR> vkRawList2 = new vkRawList<VkSurfaceFormatKHR>(pSurfaceFormatCount);
		VulkanNative.vkGetPhysicalDeviceSurfaceFormatsKHR(physicalDevice, surface, &pSurfaceFormatCount, out vkRawList2[0]);
		if (vkRawList2.Count == 1 && vkRawList2[0].format == VkFormat.Undefined)
		{
			VkSurfaceFormatKHR result = default(VkSurfaceFormatKHR);
			result.format = VkFormat.B8g8r8a8Unorm;
			result.colorSpace = VkColorSpaceKHR.SrgbNonlinearKHR;
			return result;
		}
		foreach (VkSurfaceFormatKHR item in vkRawList2)
		{
			if (item.format == VkFormat.B8g8r8a8Unorm && item.colorSpace == VkColorSpaceKHR.SrgbNonlinearKHR)
			{
				return item;
			}
		}
		return vkRawList2[0];
	}

	private unsafe VkPresentModeKHR ChoosePresentMode()
	{
		uint pPresentModeCount = 0u;
		VulkanNative.vkGetPhysicalDeviceSurfacePresentModesKHR(physicalDevice, surface, ref pPresentModeCount, null);
		if (pPresentModeCount == 0)
		{
			throw new Exception("No present modes found!");
		}
		vkRawList<VkPresentModeKHR> vkRawList2 = new vkRawList<VkPresentModeKHR>(pPresentModeCount);
		VulkanNative.vkGetPhysicalDeviceSurfacePresentModesKHR(physicalDevice, surface, &pPresentModeCount, out vkRawList2[0]);
		foreach (VkPresentModeKHR item in vkRawList2)
		{
			if (item == VkPresentModeKHR.MailboxKHR)
			{
				return item;
			}
		}
		return VkPresentModeKHR.FifoKHR;
	}

	private uint GetSwapChainImageCount()
	{
		vkRawList<VkSurfaceCapabilitiesKHR> vkRawList2 = new vkRawList<VkSurfaceCapabilitiesKHR>(1u);
		VulkanNative.vkGetPhysicalDeviceSurfaceCapabilitiesKHR(physicalDevice, surface, out vkRawList2[0]);
		uint num = vkRawList2[0].minImageCount + 1;
		if (vkRawList2[0].maxImageCount != 0 && num > vkRawList2[0].maxImageCount)
		{
			num = vkRawList2[0].maxImageCount;
		}
		return num;
	}

	private unsafe void UploadImage(int[] pixels, int width, int height)
	{
		if (!(device == VkDevice.Null))
		{
			void* destination = default(void*);
			VulkanNative.vkMapMemory(device, stagingBufferMemory, 0uL, (ulong)(width * height * 4), 0u, &destination);
			Marshal.Copy(pixels, 0, (nint)destination, width * height);
			VulkanNative.vkUnmapMemory(device, stagingBufferMemory);
			CopyBufferToImage(stagingBuffer, image, width, height);
			TransitionImageLayout(image, VkImageLayout.TransferDstOptimal, VkImageLayout.ShaderReadOnlyOptimal);
		}
	}

	public unsafe void InitializeImage(int width, int height)
	{
		stagingBuffer = CreateStagingBuffer(width * height * 4);
		VulkanNative.vkGetBufferMemoryRequirements(device, stagingBuffer, out var pMemoryRequirements);
		VkMemoryAllocateInfo vkMemoryAllocateInfo = default(VkMemoryAllocateInfo);
		vkMemoryAllocateInfo.sType = VkStructureType.MemoryAllocateInfo;
		vkMemoryAllocateInfo.allocationSize = pMemoryRequirements.size;
		vkMemoryAllocateInfo.memoryTypeIndex = FindMemoryType(pMemoryRequirements.memoryTypeBits, VkMemoryPropertyFlags.HostVisible | VkMemoryPropertyFlags.HostCoherent);
		VkMemoryAllocateInfo pAllocateInfo = vkMemoryAllocateInfo;
		VulkanNative.vkAllocateMemory(device, ref pAllocateInfo, null, out stagingBufferMemory);
		VulkanNative.vkBindBufferMemory(device, stagingBuffer, stagingBufferMemory, 0uL);
		image = CreateImage(width, height, VkFormat.B8g8r8a8Unorm);
		VulkanNative.vkGetImageMemoryRequirements(device, image, out pMemoryRequirements);
		vkMemoryAllocateInfo = default(VkMemoryAllocateInfo);
		vkMemoryAllocateInfo.sType = VkStructureType.MemoryAllocateInfo;
		vkMemoryAllocateInfo.allocationSize = pMemoryRequirements.size;
		vkMemoryAllocateInfo.memoryTypeIndex = FindMemoryType(pMemoryRequirements.memoryTypeBits, VkMemoryPropertyFlags.DeviceLocal);
		pAllocateInfo = vkMemoryAllocateInfo;
		VulkanNative.vkAllocateMemory(device, ref pAllocateInfo, null, out imageMemory);
		VulkanNative.vkBindImageMemory(device, image, imageMemory, 0uL);
		TransitionImageLayout(image, VkImageLayout.Undefined, VkImageLayout.TransferDstOptimal);
	}

	private void InitializeResources(int width, int height)
	{
		VulkanNative.vkDeviceWaitIdle(device);
		CleanupResources();
		InitializeImage(width, height);
		CreateDescriptorPool();
		CreateDescriptorSet();
	}

	private unsafe void CleanupResources()
	{
		if (stagingBuffer != VkBuffer.Null)
		{
			VulkanNative.vkDestroyBuffer(device, stagingBuffer, null);
			stagingBuffer = VkBuffer.Null;
		}
		if (stagingBufferMemory != VkDeviceMemory.Null)
		{
			VulkanNative.vkFreeMemory(device, stagingBufferMemory, null);
			stagingBufferMemory = VkDeviceMemory.Null;
		}
		if (image != VkImage.Null)
		{
			VulkanNative.vkDestroyImage(device, image, null);
			image = VkImage.Null;
		}
		if (imageMemory != VkDeviceMemory.Null)
		{
			VulkanNative.vkFreeMemory(device, imageMemory, null);
			imageMemory = VkDeviceMemory.Null;
		}
		if (descriptorPool != VkDescriptorPool.Null)
		{
			VulkanNative.vkDestroyDescriptorPool(device, descriptorPool, null);
			descriptorPool = VkDescriptorPool.Null;
		}
	}

	private unsafe VkBuffer CreateStagingBuffer(int size)
	{
		VkBufferCreateInfo vkBufferCreateInfo = default(VkBufferCreateInfo);
		vkBufferCreateInfo.sType = VkStructureType.BufferCreateInfo;
		vkBufferCreateInfo.size = (ulong)size;
		vkBufferCreateInfo.usage = VkBufferUsageFlags.TransferSrc;
		vkBufferCreateInfo.sharingMode = VkSharingMode.Exclusive;
		VkBufferCreateInfo pCreateInfo = vkBufferCreateInfo;
		if (VulkanNative.vkCreateBuffer(device, ref pCreateInfo, null, out stagingBuffer) != 0)
		{
			throw new Exception("Failed to create staging buffer!");
		}
		return stagingBuffer;
	}

	private unsafe VkImage CreateImage(int width, int height, VkFormat format)
	{
		VkImageCreateInfo vkImageCreateInfo = default(VkImageCreateInfo);
		vkImageCreateInfo.sType = VkStructureType.ImageCreateInfo;
		vkImageCreateInfo.imageType = VkImageType.Image2D;
		vkImageCreateInfo.extent = new VkExtent3D
		{
			width = (uint)width,
			height = (uint)height,
			depth = 1u
		};
		vkImageCreateInfo.mipLevels = 1u;
		vkImageCreateInfo.arrayLayers = 1u;
		vkImageCreateInfo.format = format;
		vkImageCreateInfo.tiling = VkImageTiling.Optimal;
		vkImageCreateInfo.initialLayout = VkImageLayout.Undefined;
		vkImageCreateInfo.usage = VkImageUsageFlags.TransferDst | VkImageUsageFlags.Sampled;
		vkImageCreateInfo.sharingMode = VkSharingMode.Exclusive;
		vkImageCreateInfo.samples = VkSampleCountFlags.Count1;
		VkImageCreateInfo pCreateInfo = vkImageCreateInfo;
		if (VulkanNative.vkCreateImage(device, ref pCreateInfo, null, out image) != 0)
		{
			throw new Exception("Failed to create image!");
		}
		VulkanNative.vkGetImageMemoryRequirements(device, image, out var pMemoryRequirements);
		VkMemoryAllocateInfo vkMemoryAllocateInfo = default(VkMemoryAllocateInfo);
		vkMemoryAllocateInfo.sType = VkStructureType.MemoryAllocateInfo;
		vkMemoryAllocateInfo.allocationSize = pMemoryRequirements.size;
		vkMemoryAllocateInfo.memoryTypeIndex = FindMemoryType(pMemoryRequirements.memoryTypeBits, VkMemoryPropertyFlags.DeviceLocal);
		VkMemoryAllocateInfo pAllocateInfo = vkMemoryAllocateInfo;
		if (VulkanNative.vkAllocateMemory(device, ref pAllocateInfo, null, out imageMemory) != 0)
		{
			throw new Exception("Failed to allocate memory for image!");
		}
		VulkanNative.vkBindImageMemory(device, image, imageMemory, 0uL);
		return image;
	}

	private void CopyBufferToImage(VkBuffer buffer, VkImage image, int width, int height)
	{
		VkCommandBuffer commandBuffer = BeginSingleTimeCommands();
		VkImageSubresourceLayers vkImageSubresourceLayers = default(VkImageSubresourceLayers);
		vkImageSubresourceLayers.aspectMask = VkImageAspectFlags.Color;
		vkImageSubresourceLayers.mipLevel = 0u;
		vkImageSubresourceLayers.baseArrayLayer = 0u;
		vkImageSubresourceLayers.layerCount = 1u;
		VkImageSubresourceLayers imageSubresource = vkImageSubresourceLayers;
		VkBufferImageCopy vkBufferImageCopy = default(VkBufferImageCopy);
		vkBufferImageCopy.bufferOffset = 0uL;
		vkBufferImageCopy.bufferRowLength = 0u;
		vkBufferImageCopy.bufferImageHeight = 0u;
		vkBufferImageCopy.imageSubresource = imageSubresource;
		vkBufferImageCopy.imageOffset = new VkOffset3D
		{
			x = 0,
			y = 0,
			z = 0
		};
		vkBufferImageCopy.imageExtent = new VkExtent3D
		{
			width = (uint)width,
			height = (uint)height,
			depth = 1u
		};
		VkBufferImageCopy pRegions = vkBufferImageCopy;
		VulkanNative.vkCmdCopyBufferToImage(commandBuffer, buffer, image, VkImageLayout.TransferDstOptimal, 1u, ref pRegions);
		EndSingleTimeCommands(commandBuffer);
	}

	private uint FindMemoryType(uint typeFilter, VkMemoryPropertyFlags properties)
	{
		VulkanNative.vkGetPhysicalDeviceMemoryProperties(physicalDevice, out var pMemoryProperties);
		for (uint num = 0u; num < pMemoryProperties.memoryTypeCount; num++)
		{
			VkMemoryType vkMemoryType = num switch
			{
				0u => pMemoryProperties.memoryTypes_0, 
				1u => pMemoryProperties.memoryTypes_1, 
				2u => pMemoryProperties.memoryTypes_2, 
				3u => pMemoryProperties.memoryTypes_3, 
				4u => pMemoryProperties.memoryTypes_4, 
				5u => pMemoryProperties.memoryTypes_5, 
				6u => pMemoryProperties.memoryTypes_6, 
				7u => pMemoryProperties.memoryTypes_7, 
				8u => pMemoryProperties.memoryTypes_8, 
				9u => pMemoryProperties.memoryTypes_9, 
				10u => pMemoryProperties.memoryTypes_10, 
				11u => pMemoryProperties.memoryTypes_11, 
				12u => pMemoryProperties.memoryTypes_12, 
				13u => pMemoryProperties.memoryTypes_13, 
				14u => pMemoryProperties.memoryTypes_14, 
				15u => pMemoryProperties.memoryTypes_15, 
				16u => pMemoryProperties.memoryTypes_16, 
				17u => pMemoryProperties.memoryTypes_17, 
				18u => pMemoryProperties.memoryTypes_18, 
				19u => pMemoryProperties.memoryTypes_19, 
				20u => pMemoryProperties.memoryTypes_20, 
				21u => pMemoryProperties.memoryTypes_21, 
				22u => pMemoryProperties.memoryTypes_22, 
				23u => pMemoryProperties.memoryTypes_23, 
				24u => pMemoryProperties.memoryTypes_24, 
				25u => pMemoryProperties.memoryTypes_25, 
				26u => pMemoryProperties.memoryTypes_26, 
				27u => pMemoryProperties.memoryTypes_27, 
				28u => pMemoryProperties.memoryTypes_28, 
				29u => pMemoryProperties.memoryTypes_29, 
				30u => pMemoryProperties.memoryTypes_30, 
				31u => pMemoryProperties.memoryTypes_31, 
				_ => throw new Exception("Unsupported memory type index!"), 
			};
			if ((typeFilter & (1 << (int)num)) != 0L && (vkMemoryType.propertyFlags & properties) == properties)
			{
				return num;
			}
		}
		throw new Exception("Failed to find suitable memory type!");
	}

	private VkCommandBuffer BeginSingleTimeCommands()
	{
		VkCommandBufferAllocateInfo pAllocateInfo = VkCommandBufferAllocateInfo.New();
		pAllocateInfo.commandBufferCount = 1u;
		pAllocateInfo.commandPool = commandPool;
		pAllocateInfo.level = VkCommandBufferLevel.Primary;
		VulkanNative.vkAllocateCommandBuffers(device, ref pAllocateInfo, out var pCommandBuffers);
		VkCommandBufferBeginInfo pBeginInfo = VkCommandBufferBeginInfo.New();
		pBeginInfo.flags = VkCommandBufferUsageFlags.OneTimeSubmit;
		VulkanNative.vkBeginCommandBuffer(pCommandBuffers, ref pBeginInfo);
		return pCommandBuffers;
	}

	private unsafe void EndSingleTimeCommands(VkCommandBuffer commandBuffer)
	{
		VulkanNative.vkEndCommandBuffer(commandBuffer);
		VkSubmitInfo vkSubmitInfo = default(VkSubmitInfo);
		vkSubmitInfo.sType = VkStructureType.SubmitInfo;
		vkSubmitInfo.commandBufferCount = 1u;
		vkSubmitInfo.pCommandBuffers = &commandBuffer;
		VkSubmitInfo pSubmits = vkSubmitInfo;
		VulkanNative.vkQueueSubmit(graphicsQueue, 1u, ref pSubmits, VkFence.Null);
		VulkanNative.vkQueueWaitIdle(graphicsQueue);
		VulkanNative.vkFreeCommandBuffers(device, commandPool, 1u, ref commandBuffer);
	}

	private unsafe void TransitionImageLayout(VkImage image, VkImageLayout oldLayout, VkImageLayout newLayout)
	{
		VkCommandBuffer commandBuffer = BeginSingleTimeCommands();
		VkImageMemoryBarrier vkImageMemoryBarrier = default(VkImageMemoryBarrier);
		vkImageMemoryBarrier.sType = VkStructureType.ImageMemoryBarrier;
		vkImageMemoryBarrier.oldLayout = oldLayout;
		vkImageMemoryBarrier.newLayout = newLayout;
		vkImageMemoryBarrier.srcQueueFamilyIndex = uint.MaxValue;
		vkImageMemoryBarrier.dstQueueFamilyIndex = uint.MaxValue;
		vkImageMemoryBarrier.image = image;
		vkImageMemoryBarrier.subresourceRange = new VkImageSubresourceRange
		{
			aspectMask = VkImageAspectFlags.Color,
			baseMipLevel = 0u,
			levelCount = 1u,
			baseArrayLayer = 0u,
			layerCount = 1u
		};
		VkImageMemoryBarrier pImageMemoryBarriers = vkImageMemoryBarrier;
		VkPipelineStageFlags srcStageMask;
		VkPipelineStageFlags dstStageMask;
		if (oldLayout == VkImageLayout.Undefined && newLayout == VkImageLayout.TransferDstOptimal)
		{
			pImageMemoryBarriers.srcAccessMask = VkAccessFlags.None;
			pImageMemoryBarriers.dstAccessMask = VkAccessFlags.TransferWrite;
			srcStageMask = VkPipelineStageFlags.TopOfPipe;
			dstStageMask = VkPipelineStageFlags.Transfer;
		}
		else
		{
			if (oldLayout != VkImageLayout.TransferDstOptimal || newLayout != VkImageLayout.ShaderReadOnlyOptimal)
			{
				throw new Exception("Unsupported layout transition!");
			}
			pImageMemoryBarriers.srcAccessMask = VkAccessFlags.TransferWrite;
			pImageMemoryBarriers.dstAccessMask = VkAccessFlags.ShaderRead;
			srcStageMask = VkPipelineStageFlags.Transfer;
			dstStageMask = VkPipelineStageFlags.FragmentShader;
		}
		VulkanNative.vkCmdPipelineBarrier(commandBuffer, srcStageMask, dstStageMask, VkDependencyFlags.None, 0u, null, 0u, null, 1u, ref pImageMemoryBarriers);
		EndSingleTimeCommands(commandBuffer);
	}
}
