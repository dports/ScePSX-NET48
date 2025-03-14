using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenGL;

namespace ScePSX.Render;

internal class OpenGLRenderer : GlControl, IRenderer, IDisposable
{
	private int[] Pixels = new int[524288];

	private uint _textureId;

	public int iWidth = 1024;

	public int iHeight = 512;

	private ScaleParam scale;

	public string ShadreName = "";

	private uint programID;

	private uint vertexShaderID;

	private uint fragmentShaderID;

	private uint vboID;

	public RenderMode Mode => RenderMode.OpenGL;

	protected override CreateParams CreateParams => base.CreateParams;

	public OpenGLRenderer()
	{
		base.Load += OpenGLRenderer_Load;
		base.Render += OpenGLRenderer_Render;
		base.Resize += OpenGLRenderer_Resize;
		programID = 0u;
		base.MultisampleBits = 4u;
	}

	private bool CheckReShadeInjection()
	{
		return ((IEnumerable)Process.GetCurrentProcess().Modules).Cast<ProcessModule>().Any((ProcessModule m) => m.ModuleName.Contains("ReShade"));
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
		base.MultisampleBits = (uint)Param;
	}

	protected override void OnHandleCreated(EventArgs e)
	{
		base.OnHandleCreated(e);
	}

	private void OpenGLRenderer_Load(object sender, EventArgs e)
	{
		Gl.Enable(EnableCap.Multisample);
		Gl.Enable(EnableCap.Texture2d);
		Gl.ClearColor((float)(int)Color.Gray.R / 255f, (float)(int)Color.Gray.G / 255f, (float)(int)Color.Gray.B / 255f, 0f);
		CreateVBO();
		_textureId = Gl.GenTexture();
		Gl.BindTexture(TextureTarget.Texture2d, _textureId);
		Gl.TextureParameterEXT(_textureId, TextureTarget.Texture2d, TextureParameterName.TextureMagFilter, 9729);
		Gl.TextureParameterEXT(_textureId, TextureTarget.Texture2d, TextureParameterName.TextureMinFilter, 9729);
		Gl.TexParameter(TextureTarget.Texture2d, TextureParameterName.TextureWrapS, 33071);
		Gl.TexParameter(TextureTarget.Texture2d, TextureParameterName.TextureWrapT, 33071);
		OpenGLRenderer_Resize(sender, e);
	}

	private void OpenGLRenderer_Resize(object sender, EventArgs e)
	{
		Gl.MatrixMode(MatrixMode.Projection);
		Gl.LoadIdentity();
		Gl.Viewport(0, 0, base.ClientSize.Width, base.ClientSize.Height);
		Gl.Ortho(0.0, 1.0, 0.0, 1.0, -1.0, 1.0);
		Gl.MatrixMode(MatrixMode.Modelview);
		Gl.LoadIdentity();
	}

	private void OpenGLRenderer_Render(object sender, GlControlEventArgs e)
	{
		if (base.Visible && !base.DesignMode)
		{
			if (scale.scale > 0)
			{
				Pixels = PixelsScaler.Scale(Pixels, iWidth, iHeight, scale.scale, scale.mode);
				iWidth *= scale.scale;
				iHeight *= scale.scale;
			}
			Gl.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);
			Gl.UseProgram(programID);
			Gl.ActiveTexture(TextureUnit.Texture0);
			Gl.BindTexture(TextureTarget.Texture2d, _textureId);
			Gl.TexImage2D(TextureTarget.Texture2d, 0, InternalFormat.Rgba, iWidth, iHeight, 0, PixelFormat.Bgra, PixelType.UnsignedByte, Pixels);
			Gl.BindBuffer(BufferTarget.ArrayBuffer, vboID);
			Gl.DrawArrays(PrimitiveType.Quads, 0, 4);
		}
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
		Pixels = pixels;
		iWidth = width;
		iHeight = height;
		this.scale = scale;
		Invalidate();
	}

	public void LoadShaders(string ShaderDir)
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(ShaderDir);
		if (!directoryInfo.Exists)
		{
			Console.WriteLine("[OPENGL] Shader directory not found: " + ShaderDir);
			return;
		}
		string[] array = null;
		string[] array2 = null;
		FileInfo[] files = directoryInfo.GetFiles("*.VS", SearchOption.TopDirectoryOnly);
		int num = 0;
		if (num < files.Length)
		{
			array = File.ReadAllLines(files[num].FullName);
		}
		files = directoryInfo.GetFiles("*.FS", SearchOption.TopDirectoryOnly);
		num = 0;
		if (num < files.Length)
		{
			FileInfo fileInfo = files[num];
			array2 = File.ReadAllLines(fileInfo.FullName);
			ShadreName = Path.GetFileNameWithoutExtension(fileInfo.FullName);
		}
		if (array == null || array2 == null)
		{
			Console.WriteLine("[OPENGL] Missing shader files in directory");
			return;
		}
		programID = Gl.CreateProgram();
		vertexShaderID = Gl.CreateShader(ShaderType.VertexShader);
		Gl.ShaderSource(vertexShaderID, array);
		Gl.CompileShader(vertexShaderID);
		CheckShaderCompileStatus(vertexShaderID, "Vertex Shader");
		fragmentShaderID = Gl.CreateShader(ShaderType.FragmentShader);
		Gl.ShaderSource(fragmentShaderID, array2);
		Gl.CompileShader(fragmentShaderID);
		CheckShaderCompileStatus(fragmentShaderID, "Fragment Shader");
		Gl.AttachShader(programID, vertexShaderID);
		Gl.AttachShader(programID, fragmentShaderID);
		Gl.LinkProgram(programID);
		CheckProgramLinkStatus();
		Gl.DetachShader(programID, vertexShaderID);
		Gl.DetachShader(programID, fragmentShaderID);
		Gl.DeleteShader(vertexShaderID);
		Gl.DeleteShader(fragmentShaderID);
		Gl.UseProgram(programID);
		Gl.Uniform1(Gl.GetUniformLocation(programID, "textureSampler"), 0);
		int attribLocation = Gl.GetAttribLocation(programID, "vertexPosition");
		Gl.EnableVertexAttribArray((uint)attribLocation);
		Gl.VertexAttribPointer((uint)attribLocation, 2, VertexAttribPointerType.Float, normalized: false, 16, IntPtr.Zero);
		int attribLocation2 = Gl.GetAttribLocation(programID, "vertexTexCoord");
		Gl.EnableVertexAttribArray((uint)attribLocation2);
		Gl.VertexAttribPointer((uint)attribLocation2, 2, VertexAttribPointerType.Float, normalized: false, 16, 8);
		Console.WriteLine($"[OPENGL] {ShadreName} Shader, {base.MultisampleBits}xMSAA");
	}

	private void CheckShaderCompileStatus(uint shaderId, string shaderName)
	{
		Gl.GetShader(shaderId, ShaderParameterName.CompileStatus, out var @params);
		if (@params == 0)
		{
			Gl.GetShader(shaderId, ShaderParameterName.InfoLogLength, out var params2);
			if (params2 > 0)
			{
				StringBuilder stringBuilder = new StringBuilder(params2);
				Gl.GetShaderInfoLog(shaderId, params2, out var _, stringBuilder);
				string text = stringBuilder.ToString();
				Console.WriteLine("[OPENGL] " + shaderName + " compile error:\n" + text);
			}
		}
	}

	private void CheckProgramLinkStatus()
	{
		Gl.GetProgram(programID, ProgramProperty.LinkStatus, out var @params);
		if (@params == 0)
		{
			Gl.GetProgram(programID, ProgramProperty.InfoLogLength, out var params2);
			if (params2 > 0)
			{
				StringBuilder stringBuilder = new StringBuilder(params2);
				Gl.GetProgramInfoLog(programID, params2, out var _, stringBuilder);
				string text = stringBuilder.ToString();
				Console.WriteLine("[OPENGL] Program link error:\n" + text);
			}
		}
	}

	private void CreateVBO()
	{
		float[] array = new float[16]
		{
			-1f, 1f, 0f, 1f, -1f, -1f, 0f, 0f, 1f, -1f,
			1f, 0f, 1f, 1f, 1f, 1f
		};
		vboID = Gl.GenBuffer();
		Gl.BindBuffer(BufferTarget.ArrayBuffer, vboID);
		Gl.BufferData(BufferTarget.ArrayBuffer, (uint)(4 * array.Length), array, BufferUsage.StaticDraw);
	}

	private void InitializeComponent()
	{
		base.SuspendLayout();
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
		base.Name = "OpenGLRenderer";
		base.ResumeLayout(false);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			Gl.DeleteTextures(_textureId);
			Gl.DeleteBuffers(vboID);
			Gl.DeleteProgram(programID);
		}
		base.Dispose(disposing);
	}
}
