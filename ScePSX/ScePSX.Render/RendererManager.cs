using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScePSX.Render;

public class RendererManager : IDisposable
{
	public IRenderer _currentRenderer;

	private readonly Dictionary<RenderMode, Func<IRenderer>> _rendererFactories;

	public int oglMSAA;

	public int frameskip;

	public string oglShaderPath;

	public RendererManager()
	{
		_rendererFactories = new Dictionary<RenderMode, Func<IRenderer>>
		{
			{
				RenderMode.OpenGL,
				() => new OpenGLRenderer()
			},
			{
				RenderMode.Directx3D,
				() => new SDL2Renderer()
			},
			{
				RenderMode.Directx2D,
				() => new D2DRenderer()
			},
			{
				RenderMode.Vulkan,
				() => new VulkanRenderer()
			}
		};
	}

	public void SelectRenderer(RenderMode mode, Control parentControl, int Param = 0)
	{
		IRenderer currentRenderer = _currentRenderer;
		if (currentRenderer != null && currentRenderer.Mode == mode)
		{
			return;
		}
		DisposeCurrentRenderer();
		if (!_rendererFactories.TryGetValue(mode, out var value))
		{
			return;
		}
		_currentRenderer = value();
		_currentRenderer.Initialize(parentControl);
		if (_currentRenderer is OpenGLRenderer openGLRenderer)
		{
			if (openGLRenderer.ShadreName == "" && oglShaderPath != "")
			{
				openGLRenderer.LoadShaders(oglShaderPath);
			}
			openGLRenderer.MultisampleBits = (uint)oglMSAA;
		}
	}

	private void DisposeCurrentRenderer()
	{
		if (_currentRenderer != null)
		{
			_currentRenderer.Dispose();
			_currentRenderer = null;
		}
	}

	public void RenderBuffer(int[] pixels, int width, int height, ScaleParam scale)
	{
		_currentRenderer?.RenderBuffer(pixels, width, height, scale);
	}

	public void Dispose()
	{
		DisposeCurrentRenderer();
	}
}
