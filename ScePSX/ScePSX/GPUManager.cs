using System;
using System.Collections.Generic;

namespace ScePSX;

public class GPUManager : IDisposable
{
	public IGPU GPU;

	private readonly Dictionary<GPUType, Func<IGPU>> _Factories;

	public GPUManager()
	{
		_Factories = new Dictionary<GPUType, Func<IGPU>>
		{
			{
				GPUType.Software,
				() => new SoftwareGPU()
			},
			{
				GPUType.OpenGL,
				() => new OpenglGPU()
			},
			{
				GPUType.Vulkan,
				() => new VulkanGPU()
			}
		};
	}

	public void SelectMode(GPUType type)
	{
		IGPU gPU = GPU;
		if (gPU == null || gPU.type != type)
		{
			DisposeGPU();
			if (_Factories.TryGetValue(type, out var value))
			{
				GPU = value();
				GPU.Initialize();
			}
		}
	}

	private void DisposeGPU()
	{
		if (GPU != null)
		{
			GPU.Dispose();
			GPU = null;
		}
	}

	public void Dispose()
	{
		DisposeGPU();
	}
}
