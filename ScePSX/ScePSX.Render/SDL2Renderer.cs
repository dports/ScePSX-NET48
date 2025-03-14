using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SDL2;

namespace ScePSX.Render;

internal class SDL2Renderer : UserControl, IRenderer, IDisposable
{
	private int[] pixels = new int[524288];

	private ScaleParam scale;

	private ScaleParam oldscale;

	private nint m_Window;

	private nint p_Window;

	private nint m_Renderer;

	private nint m_Texture;

	private SDL.SDL_Rect srcRect;

	private SDL.SDL_Rect dstRect;

	private int oldwidth = 1024;

	private int oldheight = 512;

	private bool sizeing;

	private readonly object _renderLock = new object();

	private readonly object bufferLock = new object();

	public int frameskip;

	public int fsk = 1;

	public RenderMode Mode => RenderMode.Directx3D;

	protected override CreateParams CreateParams => base.CreateParams;

	public SDL2Renderer()
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
		base.Name = "SDL2Renderer";
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
		frameskip = Param;
	}

	protected override void OnHandleCreated(EventArgs e)
	{
		base.OnHandleCreated(e);
		SDL.SDL_Init(32u);
		SDL.SDL_SetHint("SDL_RENDER_SCALE_QUALITY", "2");
        int data = base.Handle.ToInt32();
		m_Window = SDL.SDL_CreateWindowFrom(data);
		m_Renderer = SDL.SDL_CreateRenderer(m_Window, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED | SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC);
		m_Texture = SDL.SDL_CreateTexture(m_Renderer, SDL.SDL_PIXELFORMAT_ARGB8888, 1, 1024, 512);
		SDL.SDL_RenderClear(m_Renderer);
		SDL.SDL_RenderPresent(m_Renderer);
		srcRect = new SDL.SDL_Rect
		{
			x = 0,
			y = 0,
			w = 1024,
			h = 512
		};
		dstRect = new SDL.SDL_Rect
		{
			x = 0,
			y = 0,
			w = base.Width,
			h = base.Height
		};
		p_Window = SDL.SDL_CreateWindowFrom(base.Parent.Handle);
		SDL.SDL_RaiseWindow(p_Window);
		SDL.SDL_SetWindowInputFocus(p_Window);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (m_Texture != IntPtr.Zero)
			{
				SDL.SDL_DestroyTexture(m_Texture);
			}
			if (m_Renderer != IntPtr.Zero)
			{
				SDL.SDL_DestroyRenderer(m_Renderer);
			}
			if (m_Window != IntPtr.Zero)
			{
				SDL.SDL_DestroyWindow(m_Window);
			}
			if (p_Window != IntPtr.Zero)
			{
				SDL.SDL_DestroyWindow(p_Window);
			}
		}
		base.Dispose(disposing);
	}

	public void RenderBuffer(int[] pixels, int width, int height, ScaleParam scale)
	{
		if (base.InvokeRequired)
		{
			BeginInvoke((MethodInvoker)delegate
			{
				RenderBuffer(pixels, width, height, scale);
			});
			return;
		}
		if (fsk > 0)
		{
			fsk--;
			return;
		}
		lock (bufferLock)
		{
			this.pixels = pixels;
		}
		srcRect.w = width;
		srcRect.h = height;
		this.scale = scale;
		Invalidate();
		fsk = frameskip;
	}

	private void Render()
	{
		if (sizeing || !base.Visible || srcRect.w <= 0 || srcRect.h <= 0)
		{
			return;
		}
		if (scale.scale > 0)
		{
			pixels = PixelsScaler.Scale(pixels, srcRect.w, srcRect.h, scale.scale, scale.mode);
			srcRect.w *= scale.scale;
			srcRect.h *= scale.scale;
		}
		if (oldscale.scale != scale.scale || oldwidth != srcRect.w || oldheight != srcRect.h)
		{
			oldscale = scale;
			oldwidth = srcRect.w;
			oldheight = srcRect.h;
			SDL.SDL_DestroyTexture(m_Texture);
			m_Texture = SDL.SDL_CreateTexture(m_Renderer, SDL.SDL_PIXELFORMAT_ARGB8888, 1, srcRect.w, srcRect.h);
		}
		lock (_renderLock)
		{
			dstRect.w = base.Width;
			dstRect.h = base.Height;
			lock (bufferLock)
			{
				SDL.SDL_UpdateTexture(m_Texture, IntPtr.Zero, Marshal.UnsafeAddrOfPinnedArrayElement(pixels, 0), srcRect.w * 4);
				SDL.SDL_RenderClear(m_Renderer);
				SDL.SDL_RenderCopy(m_Renderer, m_Texture, ref srcRect, ref dstRect);
				SDL.SDL_RenderPresent(m_Renderer);
			}
		}
	}

	protected override void OnResize(EventArgs e)
	{
		try
		{
			lock (_renderLock)
			{
				sizeing = true;
				if (m_Texture != IntPtr.Zero)
				{
					SDL.SDL_DestroyTexture(m_Texture);
					m_Texture = IntPtr.Zero;
				}
				if (m_Renderer != IntPtr.Zero)
				{
					SDL.SDL_DestroyRenderer(m_Renderer);
					m_Renderer = IntPtr.Zero;
				}
				dstRect.w = base.Width;
				dstRect.h = base.Height;
				m_Renderer = SDL.SDL_CreateRenderer(m_Window, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED | SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC);
				m_Texture = SDL.SDL_CreateTexture(m_Renderer, SDL.SDL_PIXELFORMAT_ARGB8888, 1, srcRect.w, srcRect.h);
				SDL.SDL_RenderSetViewport(m_Renderer, ref dstRect);
				SDL.SDL_RenderSetLogicalSize(m_Renderer, dstRect.w, dstRect.h);
				SDL.SDL_RenderClear(m_Renderer);
				SDL.SDL_RenderPresent(m_Renderer);
				sizeing = false;
			}
			base.OnResize(e);
		}
		catch
		{
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		Render();
		base.OnPaint(e);
	}
}
