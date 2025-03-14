using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using Khronos;

namespace OpenGL;

public class Glu : KhronosApi
{
	public enum StringName
	{
		Version = 100800,
		Extensions
	}

	public enum ErrorCode
	{
		InvalidEnum = 100900,
		InvalidValue,
		OutOfMemory,
		IncompatibleGL_Version,
		InvalidOperation
	}

	public enum NurbsDisplay
	{
		OutlinePolygon = 100240,
		OutlinePatch
	}

	public enum NurbsCallback
	{
		Error = 100103,
		Begin = 100164,
		Vertex = 100165,
		Normal = 100166,
		Color = 100167,
		TextureCoord = 100168,
		End = 100169,
		BeginData = 100170,
		VertexData = 100171,
		NormalData = 100172,
		ColorData = 100173,
		TextureCoordData = 100174,
		EndData = 100175
	}

	public enum NurbsError
	{
		NurbsError1 = 100251
	}

	public enum NurbsProperty
	{
		AutoLoadMatrix = 100200,
		Culling = 100201,
		SamplingTolerance = 100203,
		DisplayMode = 100204,
		ParametricTolerance = 100202,
		SamplingMethod = 100205,
		UStep = 100206,
		VStep = 100207,
		NurbsMode = 100160,
		NurbsTessellator = 100161,
		NurbsRenderer = 100162
	}

	public enum NurbsSampling
	{
		ObjectParametricError = 100208,
		ObjectPathLength = 100209,
		PathLength = 100215,
		ParametricError = 100216,
		DomainDistance = 100217
	}

	public enum NurbsTrim
	{
		Map1Trim2 = 100210,
		Map1Trim3
	}

	public enum QuadricDrawStyle
	{
		Point = 100010,
		Line,
		Fill,
		Silhouette
	}

	public enum QuadricNormal
	{
		Smooth = 100000,
		Flat,
		None
	}

	public enum QuadricOrientation
	{
		Outside = 100020,
		Inside
	}

	public enum TessCallbackType
	{
		TessBegin = 100100,
		Begin = 100100,
		TessVertex = 100101,
		Vertex = 100101,
		TessEnd = 100102,
		End = 100102,
		TessError = 100103,
		TessEdgeFlag = 100104,
		EdgeFlag = 100104,
		TessCombine = 100105,
		TessBeginData = 100106,
		TessVertexData = 100107,
		TessEndData = 100108,
		TessErrorData = 100109,
		TessEdgeFlagData = 100110,
		TessCombineData = 100111
	}

	public enum TessContour
	{
		CW = 100120,
		CCW,
		Interior,
		Exterior,
		Unknown
	}

	public enum TessPropertyName
	{
		TessWindingRule = 100140,
		TessBoundaryOnly,
		TessTolerance
	}

	public enum TessError
	{
		TessError1 = 100151,
		TessError2 = 100152,
		TessError3 = 100153,
		TessError4 = 100154,
		TessError5 = 100155,
		TessError6 = 100156,
		TessError7 = 100157,
		TessError8 = 100158,
		TessMissingBeginPolygon = 100151,
		TessMissingBeginContour = 100152,
		TessMissingEndPolygon = 100153,
		TessMissingEndContour = 100154,
		TessCoordTooLarge = 100155,
		TessNeedCombineCallback = 100156
	}

	public enum TessWinding
	{
		TessWindingOdd = 100130,
		TessWindingNonZero,
		TessWindingPositive,
		TessWindingNegative,
		TessWindingAbsGeqTwo
	}

	public delegate void CallbackBeginDelegate(PrimitiveType type);

	public delegate void CallbackBeginDataDelegate(PrimitiveType type, nint polygon_data);

	public delegate void CallbackEdgeFlagDelegate(bool flag);

	public delegate void CallbackEdgeFlagDataDelegate(bool flag, nint polygon_data);

	public delegate void CallbackTessVertexDelegate(nint vertex_data);

	public delegate void CallbackTessVertexDataDelegate(nint vertex_data, nint polygon_data);

	public delegate void CallbackEndDelegate();

	public delegate void CallbackEndDataDelegate(nint polygon_data);

	public delegate void CallbackErrorDelegate(int errno);

	public delegate void CallbackErrorDataDelegate(int errno, nint polygon_data);

	internal static class UnsafeNativeMethods
	{
		[DllImport("Glu32.dll", ExactSpelling = true)]
		[SuppressUnmanagedCodeSecurity]
		internal static extern nint gluNewTess();

		[DllImport("Glu32.dll", ExactSpelling = true)]
		[SuppressUnmanagedCodeSecurity]
		internal static extern void gluDeleteTess(nint tess);

		[DllImport("Glu32.dll", ExactSpelling = true)]
		[SuppressUnmanagedCodeSecurity]
		internal static extern void gluTessBeginPolygon(nint tess, nint polygon_data);

		[DllImport("Glu32.dll", ExactSpelling = true)]
		[SuppressUnmanagedCodeSecurity]
		internal static extern void gluTessEndPolygon(nint tess);

		[DllImport("Glu32.dll", ExactSpelling = true)]
		[SuppressUnmanagedCodeSecurity]
		internal static extern void gluTessBeginContour(nint tess);

		[DllImport("Glu32.dll", ExactSpelling = true)]
		[SuppressUnmanagedCodeSecurity]
		internal static extern void gluTessEndContour(nint tess);

		[DllImport("Glu32.dll", ExactSpelling = true)]
		[SuppressUnmanagedCodeSecurity]
		internal static extern void gluTessVertex(nint tess, nint coords, nint data);

		[DllImport("Glu32.dll", ExactSpelling = true)]
		[SuppressUnmanagedCodeSecurity]
		internal static extern void gluTessNormal(nint tess, double valueX, double valueY, double valueZ);

		[DllImport("Glu32.dll", ExactSpelling = true)]
		[SuppressUnmanagedCodeSecurity]
		internal static extern void gluTessProperty(nint tess, int which, double value);

		[DllImport("Glu32.dll", ExactSpelling = true)]
		[SuppressUnmanagedCodeSecurity]
		internal static extern void gluTessCallback(nint tess, int which, nint fn);
	}

	internal static class Delegates
	{
		[SuppressUnmanagedCodeSecurity]
		internal delegate nint gluNewTess();

		[SuppressUnmanagedCodeSecurity]
		internal delegate void gluDeleteTess(nint tess);

		[SuppressUnmanagedCodeSecurity]
		internal delegate void gluTessBeginPolygon(nint tess, nint polygon_data);

		[SuppressUnmanagedCodeSecurity]
		internal delegate void gluTessEndPolygon(nint tess);

		[SuppressUnmanagedCodeSecurity]
		internal delegate void gluTessBeginContour(nint tess);

		[SuppressUnmanagedCodeSecurity]
		internal delegate void gluTessEndContour(nint tess);

		[SuppressUnmanagedCodeSecurity]
		internal delegate void gluTessVertex(nint tess, nint coords, nint data);

		[SuppressUnmanagedCodeSecurity]
		internal delegate void gluTessNormal(nint tess, double valueX, double valueY, double valueZ);

		[SuppressUnmanagedCodeSecurity]
		internal delegate void gluTessProperty(nint tess, int which, double value);

		[SuppressUnmanagedCodeSecurity]
		internal delegate void gluTessCallback(nint tess, int which, nint fn);

		internal static gluNewTess pgluNewTess;

		internal static gluDeleteTess pgluDeleteTess;

		internal static gluTessBeginPolygon pgluTessBeginPolygon;

		internal static gluTessEndPolygon pgluTessEndPolygon;

		internal static gluTessBeginContour pgluTessBeginContour;

		internal static gluTessEndContour pgluTessEndContour;

		internal static gluTessVertex pgluTessVertex;

		internal static gluTessNormal pgluTessNormal;

		internal static gluTessProperty pgluTessProperty;

		internal static gluTessCallback pgluTessCallback;
	}

	internal const string Library = "Glu32.dll";

	private static KhronosLogContext _LogContext;

	public const int FALSE = 0;

	public const int TRUE = 1;

	public const int VERSION = 100800;

	public const int EXTENSIONS = 100801;

	public const int INVALID_ENUM = 100900;

	public const int INVALID_VALUE = 100901;

	public const int OUT_OF_MEMORY = 100902;

	public const int INCOMPATIBLE_GL_VERSION = 100903;

	public const int INVALID_OPERATION = 100904;

	public const int OUTLINE_POLYGON = 100240;

	public const int OUTLINE_PATCH = 100241;

	public const int NURBS_ERROR = 100103;

	public const int ERROR = 100103;

	public const int NURBS_BEGIN = 100164;

	public const int NURBS_BEGIN_EXT = 100164;

	public const int NURBS_VERTEX = 100165;

	public const int NURBS_VERTEX_EXT = 100165;

	public const int NURBS_NORMAL = 100166;

	public const int NURBS_NORMAL_EXT = 100166;

	public const int NURBS_COLOR = 100167;

	public const int NURBS_COLOR_EXT = 100167;

	public const int NURBS_TEXTURE_COORD = 100168;

	public const int NURBS_TEX_COORD_EXT = 100168;

	public const int NURBS_END = 100169;

	public const int NURBS_END_EXT = 100169;

	public const int NURBS_BEGIN_DATA = 100170;

	public const int NURBS_BEGIN_DATA_EXT = 100170;

	public const int NURBS_VERTEX_DATA = 100171;

	public const int NURBS_VERTEX_DATA_EXT = 100171;

	public const int NURBS_NORMAL_DATA = 100172;

	public const int NURBS_NORMAL_DATA_EXT = 100172;

	public const int NURBS_COLOR_DATA = 100173;

	public const int NURBS_COLOR_DATA_EXT = 100173;

	public const int NURBS_TEXTURE_COORD_DATA = 100174;

	public const int NURBS_TEX_COORD_DATA_EXT = 100174;

	public const int NURBS_END_DATA = 100175;

	public const int NURBS_END_DATA_EXT = 100175;

	public const int NURBS_ERROR1 = 100251;

	public const int AUTO_LOAD_MATRIX = 100200;

	public const int CULLING = 100201;

	public const int SAMPLING_TOLERANCE = 100203;

	public const int DISPLAY_MODE = 100204;

	public const int PARAMETRIC_TOLERANCE = 100202;

	public const int SAMPLING_METHOD = 100205;

	public const int U_STEP = 100206;

	public const int V_STEP = 100207;

	public const int NURBS_MODE = 100160;

	public const int NURBS_MODE_EXT = 100160;

	public const int NURBS_TESSELLATOR = 100161;

	public const int NURBS_TESSELLATOR_EXT = 100161;

	public const int NURBS_RENDERER = 100162;

	public const int NURBS_RENDERER_EXT = 100162;

	public const int OBJECT_PARAMETRIC_ERROR = 100208;

	public const int OBJECT_PARAMETRIC_ERROR_EXT = 100208;

	public const int OBJECT_PATH_LENGTH = 100209;

	public const int OBJECT_PATH_LENGTH_EXT = 100209;

	public const int PATH_LENGTH = 100215;

	public const int PARAMETRIC_ERROR = 100216;

	public const int DOMAIN_DISTANCE = 100217;

	public const int MAP1_TRIM_2 = 100210;

	public const int MAP1_TRIM_3 = 100211;

	public const int POINT = 100010;

	public const int LINE = 100011;

	public const int FILL = 100012;

	public const int SILHOUETTE = 100013;

	public const int SMOOTH = 100000;

	public const int FLAT = 100001;

	public const int NONE = 100002;

	public const int OUTSIDE = 100020;

	public const int INSIDE = 100021;

	public const int TESS_BEGIN = 100100;

	public const int BEGIN = 100100;

	public const int TESS_VERTEX = 100101;

	public const int VERTEX = 100101;

	public const int TESS_END = 100102;

	public const int END = 100102;

	public const int TESS_ERROR = 100103;

	public const int TESS_EDGE_FLAG = 100104;

	public const int EDGE_FLAG = 100104;

	public const int TESS_COMBINE = 100105;

	public const int TESS_BEGIN_DATA = 100106;

	public const int TESS_VERTEX_DATA = 100107;

	public const int TESS_END_DATA = 100108;

	public const int TESS_ERROR_DATA = 100109;

	public const int TESS_EDGE_FLAG_DATA = 100110;

	public const int TESS_COMBINE_DATA = 100111;

	public const int CW = 100120;

	public const int CCW = 100121;

	public const int INTERIOR = 100122;

	public const int EXTERIOR = 100123;

	public const int UNKNOWN = 100124;

	public const int TESS_WINDING_RULE = 100140;

	public const int TESS_BOUNDARY_ONLY = 100141;

	public const int TESS_TOLERANCE = 100142;

	public const int TESS_ERROR1 = 100151;

	public const int TESS_ERROR2 = 100152;

	public const int TESS_ERROR3 = 100153;

	public const int TESS_ERROR4 = 100154;

	public const int TESS_ERROR5 = 100155;

	public const int TESS_ERROR6 = 100156;

	public const int TESS_ERROR7 = 100157;

	public const int TESS_ERROR8 = 100158;

	public const int TESS_MISSING_BEGIN_POLYGON = 100151;

	public const int TESS_MISSING_BEGIN_CONTOUR = 100152;

	public const int TESS_MISSING_END_POLYGON = 100153;

	public const int TESS_MISSING_END_CONTOUR = 100154;

	public const int TESS_COORD_TOO_LARGE = 100155;

	public const int TESS_NEED_COMBINE_CALLBACK = 100156;

	public const int TESS_WINDING_ODD = 100130;

	public const int TESS_WINDING_NONZERO = 100131;

	public const int TESS_WINDING_POSITIVE = 100132;

	public const int TESS_WINDING_NEGATIVE = 100133;

	public const int TESS_WINDING_ABS_GEQ_TWO = 100134;

	public static bool IsAvailable => Delegates.pgluNewTess != null;

	static Glu()
	{
		string platformLibrary = GetPlatformLibrary();
		try
		{
			Khronos.KhronosApi.LogComment("Querying GLU from " + platformLibrary);
			Khronos.KhronosApi.BindAPI<Glu>(platformLibrary, Khronos.KhronosApi.GetProcAddressOS, null);
			Khronos.KhronosApi.LogComment($"GLU availability: {IsAvailable}");
		}
		catch (Exception value)
		{
			Khronos.KhronosApi.LogComment($"GLU not available:\n{value}");
		}
	}

	private static string GetPlatformLibrary()
	{
		_ = Platform.CurrentPlatformId;
		return "Glu32.dll";
	}

	public static void CheckErrors()
	{
	}

	private static void DebugCheckErrors(object returnValue)
	{
	}

	[Conditional("GL_DEBUG")]
	protected new static void LogCommand(string name, object returnValue, params object[] args)
	{
		if (_LogContext == null)
		{
			_LogContext = new KhronosLogContext(typeof(Glu));
		}
		Khronos.KhronosApi.RaiseLog(new KhronosLogEventArgs(_LogContext, name, args, returnValue));
	}

	public static nint NewTess()
	{
		return Delegates.pgluNewTess();
	}

	public static void DeleteTess(nint tess)
	{
		Delegates.pgluDeleteTess(tess);
	}

	public static void TessBeginPolygon(nint tess, nint polygon_data)
	{
		Delegates.pgluTessBeginPolygon(tess, polygon_data);
	}

	public static void TessEndPolygon(nint tess)
	{
		Delegates.pgluTessEndPolygon(tess);
	}

	public static void TessBeginContour(nint tess)
	{
		Delegates.pgluTessBeginContour(tess);
	}

	public static void TessEndContour(nint tess)
	{
		Delegates.pgluTessEndContour(tess);
	}

	public static void TessVertex(nint tess, nint coords, nint data)
	{
		Delegates.pgluTessVertex(tess, coords, data);
	}

	public static void TessNormal(nint tess, double valueX, double valueY, double valueZ)
	{
		Delegates.pgluTessNormal(tess, valueX, valueY, valueZ);
	}

	public static void TessProperty(nint tess, int which, double value)
	{
		Delegates.pgluTessProperty(tess, which, value);
	}

	public static void TessCallback(nint tess, TessCallbackType which, nint fn)
	{
		Delegates.pgluTessCallback(tess, (int)which, fn);
	}
}
