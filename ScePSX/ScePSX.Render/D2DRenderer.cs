using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DirectX.D2D1;

namespace ScePSX.Render;

public class D2DRenderer : UserControl, IRenderer, IDisposable
{
	private D2D1Factory factory;

	private D2D1HwndRenderTarget renderTarget;

	private D2D1Bitmap bitmap;

	private D2D1BitmapProperties bmpprops;

	private D2D1ColorF clearcolor = new D2D1ColorF(0f, 0f, 0f, 1f);

	private int[] pixels = new int[524288];

	private int width;

	private int oldwidth = 1024;

	private int height;

	private int oldheight = 512;

	private ScaleParam scale;

	private ScaleParam oldscale;

	public int frameskip;

	public int fsk = 1;

	private float dpiX;

	private float dpiY;

	private readonly object bufferLock = new object();

	public RenderMode Mode => RenderMode.Directx2D;

	protected override CreateParams CreateParams
	{
		get
		{
			CreateParams createParams = base.CreateParams;
			createParams.ClassStyle |= 35;
			return createParams;
		}
	}

	public D2DRenderer()
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
		base.Name = "D2DRenderer";
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
		factory = D2D1Factory.Create(D2D1FactoryType.MultiThreaded);
		if (factory == null)
		{
			Console.WriteLine("Failed to create D2D1Factory.");
			return;
		}
		factory.GetDesktopDpi(out dpiX, out dpiY);
		D2D1RenderTargetProperties renderTargetProperties = new D2D1RenderTargetProperties(D2D1RenderTargetType.Default, new D2D1PixelFormat(DxgiFormat.B8G8R8A8UNorm, D2D1AlphaMode.Premultiplied), dpiX, dpiY, D2D1RenderTargetUsages.None, D2D1FeatureLevel.Default);
		D2D1HwndRenderTargetProperties hwndRenderTargetProperties = new D2D1HwndRenderTargetProperties(base.Handle, new D2D1SizeU((uint)base.ClientSize.Width, (uint)base.ClientSize.Height), D2D1PresentOptions.None);
		renderTarget = factory.CreateHwndRenderTarget(renderTargetProperties, hwndRenderTargetProperties);
		if (renderTarget == null)
		{
			Console.WriteLine("Failed to create RenderTarget");
			return;
		}
		renderTarget.AntialiasMode = D2D1AntialiasMode.PerPrimitive;
		D2D1SizeU size = new D2D1SizeU((uint)width, (uint)height);
		bmpprops = new D2D1BitmapProperties(new D2D1PixelFormat(DxgiFormat.B8G8R8A8UNorm, D2D1AlphaMode.Premultiplied), dpiX, dpiY);
		bitmap = renderTarget.CreateBitmap(size, IntPtr.Zero, 0u, bmpprops);
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
		this.width = width;
		this.height = height;
		this.scale = scale;
		Invalidate();
		fsk = frameskip;
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		Render();
		base.OnPaint(e);
	}

	private void Render()
	{
		if (renderTarget == null || bitmap == null || !base.Visible || width <= 0 || height <= 0)
		{
			return;
		}
		if (scale.scale > 0)
		{
			pixels = PixelsScaler.Scale(pixels, width, height, scale.scale, scale.mode);
			width *= scale.scale;
			height *= scale.scale;
		}
		if (oldscale.scale != scale.scale || oldwidth != width || oldheight != height)
		{
			D2D1SizeU size = new D2D1SizeU((uint)width, (uint)height);
			bitmap = renderTarget.CreateBitmap(size, IntPtr.Zero, 0u, bmpprops);
			oldscale = scale;
			oldwidth = width;
			oldheight = height;
		}
		lock (bufferLock)
		{
			bitmap.CopyFromMemory(Marshal.UnsafeAddrOfPinnedArrayElement(pixels, 0), (uint)(width * 4));
			renderTarget.BeginDraw();
			renderTarget.Clear();
			D2D1RectF destinationRectangle = new D2D1RectF(0f, 0f, base.ClientSize.Width, base.ClientSize.Height);
			D2D1RectF sourceRectangle = new D2D1RectF(0f, 0f, width, height);
			renderTarget.DrawBitmap(bitmap, destinationRectangle, 1f, D2D1BitmapInterpolationMode.Linear, sourceRectangle);
			renderTarget.EndDraw();
		}
	}

	protected override void OnResize(EventArgs e)
	{
		base.OnResize(e);
		if (base.ClientSize.Width > 0 && base.ClientSize.Height > 0 && renderTarget != null)
		{
			D2D1SizeU pixelSize = new D2D1SizeU((uint)base.ClientSize.Width, (uint)base.ClientSize.Height);
			renderTarget.Resize(pixelSize);
			Invalidate();
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (bitmap != null)
			{
				bitmap.Dispose();
			}
			if (renderTarget != null)
			{
				renderTarget.Dispose();
			}
			if (factory != null)
			{
				factory.Dispose();
			}
		}
		base.Dispose(disposing);
	}
}
