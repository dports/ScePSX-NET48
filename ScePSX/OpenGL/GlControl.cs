using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Khronos;

namespace OpenGL;

public class GlControl : UserControl
{
	public enum ProfileType
	{
		Core,
		Compatibility,
		Embedded,
		SecurityCritical2
	}

	public enum AttributePermission
	{
		Required,
		Enabled,
		EnabledInDebugger,
		DonCare
	}

	public enum ContextSharingOption
	{
		OwnContext,
		SingleContext
	}

	private ProfileType _ProfileType = ProfileType.Compatibility;

	private AttributePermission _DebugContextBit = AttributePermission.EnabledInDebugger;

	private AttributePermission _ForwardCompatibleContextBit = AttributePermission.DonCare;

	private AttributePermission _RobustContextBit = AttributePermission.DonCare;

	private uint _ColorBits = 24u;

	private uint _DepthBits;

	private uint _StencilBits;

	private uint _MultisampleBits;

	private bool _DoubleBuffer = true;

	private int _SwapInterval = 1;

	private string _DesignerPixelFormatNotice;

	private bool _Animation;

	private int _AnimationTime;

	private bool _AnimationTimerFlag = true;

	private System.Windows.Forms.Timer _AnimationTimer;

	private int _AnimationInvalidated;

	private readonly Pen _DesignPen = new Pen(Color.Black, 1.5f);

	private readonly Brush _DesignBrush = new SolidBrush(Color.Black);

	private readonly Font _DesignFont = new Font(FontFamily.GenericMonospace, 9f);

	private readonly Pen _FailurePen = new Pen(Color.Red, 1.5f);

	private readonly Brush _FailureBrush = new SolidBrush(Color.Red);

	protected DeviceContext _DeviceContext;

	protected nint _RenderContext;

	private GlControl _SharingControl;

	private ContextSharingOption _ContextSharing;

	private string _ContextSharingGroup;

	private static readonly Dictionary<string, List<nint>> _SharingGroups = new Dictionary<string, List<nint>>();

	private static readonly Dictionary<string, GlControl> _SharingControls = new Dictionary<string, GlControl>();

	private TimeSpan _FrameDrawTime;

	private TimeSpan _FrameSwapTime;

	private IContainer components;

	[Browsable(true)]
	[Category("Context")]
	[Description("The version to be implemented by the context created by this GlControl. If null, the default version is created. Considered only if WGL_ARB_create_context is supported.")]
	[DefaultValue(null)]
	public KhronosVersion ContextVersion { get; set; }

	[Browsable(true)]
	[Category("Context")]
	[Description("Select the type of profile of the context. Considered only if WGL_ARB_create_context is supported.")]
	[DefaultValue(ProfileType.Compatibility)]
	public ProfileType ContextProfile
	{
		get
		{
			return _ProfileType;
		}
		set
		{
			_ProfileType = value;
		}
	}

	[Browsable(true)]
	[Category("Context")]
	[Description("Creates a debug context. Considered only if WGL_ARB_create_context_profile is supported.")]
	[DefaultValue(AttributePermission.EnabledInDebugger)]
	public AttributePermission DebugContext
	{
		get
		{
			return _DebugContextBit;
		}
		set
		{
			_DebugContextBit = value;
		}
	}

	[Browsable(true)]
	[Category("Context")]
	[Description("Creates a forward-compatible context. Considered only if WGL_ARB_create_context is supported.")]
	[DefaultValue(AttributePermission.DonCare)]
	public AttributePermission ForwardCompatibleContext
	{
		get
		{
			return _ForwardCompatibleContextBit;
		}
		set
		{
			_ForwardCompatibleContextBit = value;
		}
	}

	[Browsable(true)]
	[Category("Context")]
	[Description("Creates a robust context. Considered only if WGL_ARB_create_context_robustness is supported.")]
	[DefaultValue(AttributePermission.DonCare)]
	public AttributePermission RobustContext
	{
		get
		{
			return _RobustContextBit;
		}
		set
		{
			_RobustContextBit = value;
		}
	}

	[Browsable(true)]
	[Category("Framebuffer")]
	[Description("Minimum number of bits of the color buffer.")]
	[DefaultValue(24)]
	public uint ColorBits
	{
		get
		{
			return _ColorBits;
		}
		set
		{
			_ColorBits = value;
			DesignerValidatePixelFormat();
		}
	}

	[Browsable(true)]
	[Category("Framebuffer")]
	[Description("Minimum number of bits of the depth buffer.")]
	[DefaultValue(0)]
	public uint DepthBits
	{
		get
		{
			return _DepthBits;
		}
		set
		{
			_DepthBits = value;
			DesignerValidatePixelFormat();
		}
	}

	[Browsable(true)]
	[Category("Framebuffer")]
	[Description("Minimum number of bits of the stencil buffer.")]
	[DefaultValue(0)]
	public uint StencilBits
	{
		get
		{
			return _StencilBits;
		}
		set
		{
			_StencilBits = value;
			DesignerValidatePixelFormat();
		}
	}

	[Browsable(true)]
	[Category("Framebuffer")]
	[Description("Minimum number of samples of the multisample buffer.")]
	[DefaultValue(0)]
	public uint MultisampleBits
	{
		get
		{
			return _MultisampleBits;
		}
		set
		{
			_MultisampleBits = value;
			DesignerValidatePixelFormat();
		}
	}

	[Browsable(true)]
	[Category("Framebuffer")]
	[Description("Flag indicating whether double buffering is required.")]
	[DefaultValue(true)]
	public bool DoubleBuffer
	{
		get
		{
			return _DoubleBuffer;
		}
		set
		{
			_DoubleBuffer = value;
			DesignerValidatePixelFormat();
		}
	}

	[Browsable(true)]
	[Category("Framebuffer")]
	[Description("Integer specifing the minimum number of video frames that are displayed before a buffer swap will occur. Considered only if (WGL|GLX)_EXT_swap_control is supported: set to 1 to enable V-Sync or set to 0 to disable V-Sync. If the (WGL|GLX)_EXT_swap_control_tear is supported, set to -1 to enable adaptive V-Sync.")]
	[DefaultValue(1)]
	public int SwapInterval
	{
		get
		{
			return _SwapInterval;
		}
		set
		{
			_SwapInterval = value;
		}
	}

	private DevicePixelFormat ControlPixelFormat => new DevicePixelFormat
	{
		RgbaUnsigned = true,
		RenderWindow = true,
		ColorBits = (int)ColorBits,
		DepthBits = (int)DepthBits,
		StencilBits = (int)StencilBits,
		MultisampleBits = (int)MultisampleBits,
		DoubleBuffer = (DoubleBuffer && _ProfileType != ProfileType.Embedded)
	};

	[Browsable(true)]
	[Category("Animation")]
	[Description("Flag indicating whether control should update itself continuosly.")]
	[DefaultValue(false)]
	public bool Animation
	{
		get
		{
			return _Animation;
		}
		set
		{
			_Animation = value;
			if (base.DesignMode)
			{
				return;
			}
			if (_AnimationTimer != null && AnimationTimer)
			{
				_AnimationTimer.Enabled = Animation;
			}
			else if (!AnimationTimer && Animation && !AnimationTimer && base.IsHandleCreated)
			{
				BeginInvoke((MethodInvoker)delegate
				{
					Invalidate();
				});
			}
		}
	}

	[Browsable(true)]
	[Category("Animation")]
	[Description("Animation update time, in milliseconds. Zero means continuos update, limited to V-Sync (see SwapInterval property).")]
	[DefaultValue(0)]
	public int AnimationTime
	{
		get
		{
			return _AnimationTime;
		}
		set
		{
			_AnimationTime = value;
			if (_AnimationTimer != null && !base.DesignMode)
			{
				_AnimationTimer.Interval = Math.Max(1, _AnimationTime);
			}
		}
	}

	[Browsable(true)]
	[Category("Animation")]
	[Description("Animation triggered by a Timer. Enable when integrated with other Forms control.")]
	[DefaultValue(true)]
	public bool AnimationTimer
	{
		get
		{
			return _AnimationTimerFlag;
		}
		set
		{
			_AnimationTimerFlag = value;
			if (_AnimationTimer == null && AnimationTimer && !base.DesignMode)
			{
				CreateAnimationTimer();
			}
			else if (_AnimationTimer != null && !AnimationTimer && !base.DesignMode)
			{
				_AnimationTimer.Enabled = false;
			}
		}
	}

	[Browsable(false)]
	public DeviceContext Device => _DeviceContext;

	[Browsable(true)]
	[Category("Context")]
	[Description("Option for sharing the context with other GlControl instances.")]
	[DefaultValue(ContextSharingOption.OwnContext)]
	public ContextSharingOption ContextSharing
	{
		get
		{
			return _ContextSharing;
		}
		set
		{
			if (_RenderContext != IntPtr.Zero)
			{
				throw new InvalidOperationException("read-only property");
			}
			_ContextSharing = value;
		}
	}

	[Browsable(true)]
	[Category("Context")]
	[Description("Tag for sharing resource with other GlControl instances. Each one having the same tag will share resources.")]
	[DefaultValue(null)]
	public string ContextSharingGroup
	{
		get
		{
			return _ContextSharingGroup;
		}
		set
		{
			if (_RenderContext != IntPtr.Zero)
			{
				throw new InvalidOperationException("read-only property");
			}
			_ContextSharingGroup = value;
		}
	}

	[Browsable(false)]
	public TimeSpan FrameDrawTime => _FrameDrawTime;

	[Browsable(false)]
	public TimeSpan FrameSwapTime => _FrameSwapTime;

	protected override CreateParams CreateParams
	{
		get
		{
			CreateParams createParams = base.CreateParams;
			if (Platform.CurrentPlatformId == Platform.Id.WindowsNT)
			{
				createParams.ClassStyle |= 35;
			}
			return createParams;
		}
	}

	[Browsable(true)]
	[Category("Rendering")]
	[Description("Generated when the relative OpenGL context has been created.")]
	public event EventHandler<GlControlEventArgs> ContextCreated;

	[Browsable(true)]
	[Category("Rendering")]
	[Description("Generated just before the relative OpenGL context is being released.")]
	public event EventHandler<GlControlEventArgs> ContextDestroying;

	[Browsable(true)]
	[Category("Rendering")]
	[Description("Generated when the GlControl has been requested to update its contents.")]
	public event EventHandler<GlControlEventArgs> Render;

	[Browsable(true)]
	[Category("Rendering")]
	[Description("Generated when the GlControl drawing commands are executed, but before the back-buffer is swapped.")]
	public event EventHandler<GlControlEventArgs> ContextUpdate;

	public GlControl()
	{
		SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
		SetStyle(ControlStyles.Opaque, value: true);
		SetStyle(ControlStyles.DoubleBuffer, value: false);
		DoubleBuffered = false;
		SetStyle(ControlStyles.ResizeRedraw, value: true);
		SetStyle(ControlStyles.UserPaint, value: true);
		InitializeComponent();
	}

	private void DesignerValidatePixelFormat()
	{
		if (!base.DesignMode)
		{
			return;
		}
		try
		{
			if (_DeviceContext == null)
			{
				CreateDeviceContext(new DevicePixelFormat(0));
			}
			List<DevicePixelFormat> list = _DeviceContext.PixelsFormats.Choose(ControlPixelFormat);
			if (list.Count > 0)
			{
				_DesignerPixelFormatNotice = $"Device pixel format:\n  > {list[0]}";
			}
			else
			{
				_DesignerPixelFormatNotice = $"Unable to find suitable pixel format:\n  > {_DeviceContext.PixelsFormats.GuessChooseError(ControlPixelFormat)}";
			}
		}
		catch (Exception ex)
		{
			_DesignerPixelFormatNotice = ex.ToString();
		}
		Invalidate();
	}

	private void CreateAnimationTimer()
	{
		if (_AnimationTimer == null)
		{
			_AnimationTimer = new System.Windows.Forms.Timer();
			_AnimationTimer.Tick += AnimationTimer_Tick;
			_AnimationTimer.Interval = Math.Max(1, _AnimationTime);
			_AnimationTimer.Enabled = Animation;
		}
	}

	private void AnimationTimer_Tick(object sender, EventArgs e)
	{
		if (_AnimationInvalidated == 0)
		{
			Invalidate();
		}
		Interlocked.Add(ref _AnimationInvalidated, 1);
	}

	protected void DrawDesign(PaintEventArgs e)
	{
		Size clientSize = base.ClientSize;
		RectangleF rectangleF = new RectangleF(PointF.Empty, clientSize);
		e.Graphics.SetClip(rectangleF);
		e.Graphics.Clear(BackColor);
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("Running on OpenGL {0}\n", (Gl.CurrentVersion != null) ? Gl.CurrentVersion.ToString() : "unknown (not initialized)");
		stringBuilder.AppendFormat("  - OpenGL Shading Language version: {0}\n", (Gl.CurrentShadingVersion != null) ? Gl.CurrentShadingVersion.ToString() : "unknown (not initialized)");
		stringBuilder.AppendFormat("  - Vendor: {0}\n", Gl.CurrentVendor ?? "unknown (not initialized)");
		stringBuilder.AppendFormat("  - Renderer: {0}\n", Gl.CurrentRenderer ?? "unknown (not initialized)");
		if (Egl.IsAvailable)
		{
			stringBuilder.AppendFormat("- EGL is available.\n\n");
		}
		if (_DesignerPixelFormatNotice != null)
		{
			stringBuilder.AppendFormat("{0}\n", _DesignerPixelFormatNotice);
		}
		e.Graphics.DrawString(stringBuilder.ToString(), _DesignFont, _DesignBrush, rectangleF);
	}

	protected void DrawFailure(PaintEventArgs e, Exception exception)
	{
		Size clientSize = base.ClientSize;
		e.Graphics.Clear(BackColor);
		if (exception != null)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("Exception of type {0}: {1}\n", exception.GetType().Name, exception.ToString());
			stringBuilder.AppendFormat("Exception stacktrace: {0}\n", exception.StackTrace);
			e.Graphics.DrawString(stringBuilder.ToString(), _DesignFont, _FailureBrush, new RectangleF(PointF.Empty, clientSize));
		}
		else
		{
			e.Graphics.DrawLines(_FailurePen, new Point[4]
			{
				new Point(0, 0),
				new Point(clientSize.Width, clientSize.Height),
				new Point(0, clientSize.Height),
				new Point(clientSize.Width, 0)
			});
		}
	}

	protected void CreateDeviceContext()
	{
		CreateDeviceContext(ControlPixelFormat);
	}

	private void CreateDeviceContext(DevicePixelFormat controlReqFormat)
	{
		switch (_ProfileType)
		{
		case ProfileType.Embedded:
			DeviceContext.DefaultAPI = "gles2";
			break;
		case ProfileType.SecurityCritical2:
			DeviceContext.DefaultAPI = "glsc2";
			break;
		}
		_DeviceContext = DeviceContext.Create(GetDisplay(), base.Handle);
		_DeviceContext.IncRef();
		DevicePixelFormatCollection pixelsFormats = _DeviceContext.PixelsFormats;
		List<DevicePixelFormat> list = pixelsFormats.Choose(controlReqFormat);
		if (list.Count == 0 && controlReqFormat.MultisampleBits > 0)
		{
			int multisampleBits = 0;
			pixelsFormats.ForEach(delegate(DevicePixelFormat item)
			{
				multisampleBits = Math.Max(multisampleBits, item.MultisampleBits);
			});
			controlReqFormat.MultisampleBits = multisampleBits;
			list = pixelsFormats.Choose(controlReqFormat);
		}
		if (list.Count == 0 && controlReqFormat.DoubleBuffer)
		{
			controlReqFormat.DoubleBuffer = false;
			list = pixelsFormats.Choose(controlReqFormat);
			if (list.Count == 0)
			{
				throw new InvalidOperationException($"unable to find a suitable pixel format: {pixelsFormats.GuessChooseError(controlReqFormat)}");
			}
		}
		else if (list.Count == 0)
		{
			throw new InvalidOperationException($"unable to find a suitable pixel format: {pixelsFormats.GuessChooseError(controlReqFormat)}");
		}
		_DeviceContext.SetPixelFormat(list[0]);
		if (Gl.PlatformExtensions.SwapControl)
		{
			int num = SwapInterval;
			if (!Gl.PlatformExtensions.SwapControlTear && num == -1)
			{
				num = 1;
			}
			_DeviceContext.SwapInterval(num);
		}
	}

	protected nint GetDisplay()
	{
		switch (Platform.CurrentPlatformId)
		{
		case Platform.Id.WindowsNT:
			return IntPtr.Zero;
		case Platform.Id.Linux:
		{
			Type? type = Type.GetType("System.Windows.Forms.XplatUIX11, System.Windows.Forms");
			if (type == null)
			{
				throw new InvalidOperationException("no XPlatUI implementation");
			}
			nint num = (nint)type.GetField("DisplayHandle", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null);
			Khronos.KhronosApi.LogComment("System.Windows.Forms.XplatUIX11.DisplayHandle is 0x" + ((IntPtr)num).ToString("X"));
			if (num == IntPtr.Zero)
			{
				throw new InvalidOperationException("unable to connect to X server using XPlatUI");
			}
			return num;
		}
		default:
			throw new NotSupportedException("platform " + Platform.CurrentPlatformId.ToString() + " not supported");
		}
	}

	protected virtual void CreateContext()
	{
		if (_RenderContext != IntPtr.Zero)
		{
			throw new InvalidOperationException("context already created");
		}
		switch (ContextSharing)
		{
		case ContextSharingOption.OwnContext:
			CreateDesktopContext();
			break;
		case ContextSharingOption.SingleContext:
			ReuseOtherContext();
			break;
		}
	}

	protected virtual void MakeCurrentContext()
	{
		if (!_DeviceContext.MakeCurrent(_RenderContext))
		{
			throw new InvalidOperationException("unable to make context current");
		}
	}

	protected virtual void DeleteContext()
	{
		if (ContextSharing == ContextSharingOption.OwnContext && ContextSharingGroup != null)
		{
			_SharingGroups.TryGetValue(ContextSharingGroup, out var value);
			value.Remove(_RenderContext);
		}
		if (_RenderContext != IntPtr.Zero)
		{
			_DeviceContext.DeleteContext(_RenderContext);
			_RenderContext = IntPtr.Zero;
		}
	}

	protected void CreateDesktopContext()
	{
		if (_RenderContext != IntPtr.Zero)
		{
			throw new InvalidOperationException("context already created");
		}
		nint sharedContext = IntPtr.Zero;
		if (ContextSharing == ContextSharingOption.OwnContext && ContextSharingGroup != null)
		{
			if (_SharingGroups.TryGetValue(ContextSharingGroup, out var value))
			{
				sharedContext = ((value.Count > 0) ? value[0] : IntPtr.Zero);
			}
			else
			{
				_SharingGroups.Add(ContextSharingGroup, new List<nint>());
			}
		}
		if (Gl.PlatformExtensions.CreateContext_ARB)
		{
			List<int> list = new List<int>();
			uint num = 0u;
			uint num2 = 0u;
			bool isAttached = Debugger.IsAttached;
			if (ContextVersion != null)
			{
				list.AddRange(new int[4] { 8337, ContextVersion.Major, 8338, ContextVersion.Minor });
			}
			else
			{
				list.AddRange(new int[4] { 8337, 1, 8338, 0 });
			}
			if (_DebugContextBit == AttributePermission.Enabled || (isAttached && _DebugContextBit == AttributePermission.EnabledInDebugger))
			{
				num2 |= 1;
			}
			if (_ForwardCompatibleContextBit == AttributePermission.Enabled || (isAttached && _ForwardCompatibleContextBit == AttributePermission.EnabledInDebugger))
			{
				num2 |= 2;
			}
			if (Gl.PlatformExtensions.CreateContextProfile_ARB)
			{
				switch (_ProfileType)
				{
				case ProfileType.Core:
					num |= 1;
					break;
				case ProfileType.Compatibility:
					num |= 2;
					break;
				}
			}
			if (Gl.PlatformExtensions.CreateContextRobustness_ARB && (_RobustContextBit == AttributePermission.Enabled || (isAttached && _RobustContextBit == AttributePermission.EnabledInDebugger)))
			{
				num2 |= 4;
			}
			if (num2 != 0)
			{
				list.AddRange(new int[2]
				{
					8340,
					(int)num2
				});
			}
			if (num != 0)
			{
				list.AddRange(new int[2]
				{
					37158,
					(int)num
				});
			}
			list.Add(0);
			if ((_RenderContext = _DeviceContext.CreateContextAttrib(sharedContext, list.ToArray())) == IntPtr.Zero)
			{
				throw new InvalidOperationException($"unable to create render context ({Gl.GetError()})");
			}
		}
		else if ((_RenderContext = _DeviceContext.CreateContext(sharedContext)) == IntPtr.Zero)
		{
			throw new InvalidOperationException("unable to create render context");
		}
		if (ContextSharing == ContextSharingOption.OwnContext && ContextSharingGroup != null)
		{
			_SharingGroups.TryGetValue(ContextSharingGroup, out var value2);
			value2.Add(_RenderContext);
		}
	}

	protected void ReuseOtherContext()
	{
		if (ContextSharingGroup == null)
		{
			throw new InvalidOperationException("undefined context sharing group");
		}
		if (!_SharingControls.TryGetValue(ContextSharingGroup, out _SharingControl))
		{
			throw new InvalidOperationException($"no GlControl sharing with {ContextSharingGroup}");
		}
		_RenderContext = _SharingControl._RenderContext;
		_SharingControl.ContextCreated += SharingControl_ContextCreated;
		_SharingControl.ContextDestroying += SharingControl_ContextDestroying;
	}

	private void SharingControl_ContextCreated(object sender, GlControlEventArgs e)
	{
		_RenderContext = _SharingControl._RenderContext;
		OnContextCreated();
	}

	private void SharingControl_ContextDestroying(object sender, GlControlEventArgs e)
	{
		OnContextDestroying();
		_RenderContext = IntPtr.Zero;
	}

	protected virtual void OnContextCreated()
	{
		if (this.ContextCreated != null)
		{
			this.ContextCreated(this, new GlControlEventArgs(_DeviceContext, _RenderContext));
		}
	}

	protected virtual void OnContextDestroying()
	{
		if (this.ContextDestroying != null)
		{
			this.ContextDestroying(this, new GlControlEventArgs(_DeviceContext, _RenderContext));
		}
	}

	protected virtual void OnRender()
	{
		if (this.Render != null && _RenderContext != IntPtr.Zero)
		{
			this.Render(this, new GlControlEventArgs(_DeviceContext, _RenderContext));
		}
	}

	protected virtual void OnContextUpdate()
	{
		if (this.ContextUpdate != null && _RenderContext != IntPtr.Zero)
		{
			this.ContextUpdate(this, new GlControlEventArgs(_DeviceContext, _RenderContext));
		}
	}

	protected override void OnHandleCreated(EventArgs e)
	{
		if (!base.DesignMode)
		{
			CreateDeviceContext();
			CreateContext();
			MakeCurrentContext();
			OnContextCreated();
			if (AnimationTimer && Animation)
			{
				CreateAnimationTimer();
			}
		}
		base.OnHandleCreated(e);
	}

	protected override void OnHandleDestroyed(EventArgs e)
	{
		if (!base.DesignMode)
		{
			if (_RenderContext != IntPtr.Zero)
			{
				OnContextDestroying();
				if (_SharingControl == null)
				{
					DeleteContext();
				}
			}
			_DeviceContext.DecRef();
			_DeviceContext = null;
		}
		base.OnHandleDestroyed(e);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		if (!base.DesignMode)
		{
			Stopwatch stopwatch = Stopwatch.StartNew();
			MakeCurrentContext();
			OnRender();
			_FrameDrawTime = stopwatch.Elapsed;
			OnContextUpdate();
			_DeviceContext.SwapBuffers();
			_FrameSwapTime = stopwatch.Elapsed;
		}
		else
		{
			DrawDesign(e);
		}
		base.OnPaint(e);
		Interlocked.Exchange(ref _AnimationInvalidated, 0);
		if (Animation && !AnimationTimer && !base.DesignMode)
		{
			if (AnimationTime > 0)
			{
				Thread.Sleep(AnimationTime);
			}
			Invalidate();
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		if (_AnimationTimer != null)
		{
			_AnimationTimer.Tick -= AnimationTimer_Tick;
			_AnimationTimer.Dispose();
		}
		if (_SharingControl != null)
		{
			_SharingControl.ContextDestroying -= SharingControl_ContextDestroying;
			_SharingControl.ContextCreated -= SharingControl_ContextCreated;
		}
		if (ContextSharing == ContextSharingOption.OwnContext && ContextSharingGroup != null)
		{
			_SharingControls.Remove(ContextSharingGroup);
		}
		_DesignPen.Dispose();
		_FailurePen.Dispose();
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		base.SuspendLayout();
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
		base.Name = "GlControl";
		base.Size = new System.Drawing.Size(441, 246);
		base.ResumeLayout(false);
	}
}
