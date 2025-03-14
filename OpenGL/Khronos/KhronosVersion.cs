using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Khronos;

[DebuggerDisplay("KhronosVersion: Version={Major}.{Minor}.{Revision} API='{Api}' Profile={Profile}")]
public class KhronosVersion : IEquatable<KhronosVersion>, IComparable<KhronosVersion>
{
	public const string ApiGl = "gl";

	public const string ApiWgl = "wgl";

	public const string ApiGlx = "glx";

	public const string ApiEgl = "egl";

	public const string ApiGles1 = "gles1";

	public const string ApiGles2 = "gles2";

	public const string ApiGlsc2 = "glsc2";

	public const string ApiVg = "vg";

	public const string ApiVx = "vx";

	public const string ApiGlsl = "glsl";

	public const string ApiEssl = "essl";

	public const string ApiWfc = "wfc";

	public const string ApiWfd = "wfd";

	public readonly string Api;

	public readonly int Major;

	public readonly int Minor;

	public readonly int Revision;

	public const string ProfileCore = "core";

	public const string ProfileCompatibility = "compatibility";

	public const string ProfileCommon = "common";

	public readonly string Profile;

	public virtual int VersionId => Major * 100 + Minor * 10;

	public KhronosVersion(int major, int minor, string api)
		: this(major, minor, 0, api)
	{
	}

	public KhronosVersion(int major, int minor, int revision, string api)
		: this(major, minor, revision, api, null)
	{
	}

	public KhronosVersion(int major, int minor, int revision, string api, string profile)
	{
		if (major < 0)
		{
			throw new ArgumentException("less than 0 not allowed", "major");
		}
		if (minor < 0)
		{
			throw new ArgumentException("less than 0 not allowed", "minor");
		}
		if (revision < 0)
		{
			throw new ArgumentException("less than 0 not allowed", "revision");
		}
		if (api == null)
		{
			throw new ArgumentNullException("api");
		}
		Major = major;
		Minor = minor;
		Revision = revision;
		Api = api;
		Profile = profile;
	}

	public KhronosVersion(KhronosVersion other)
	{
		if (other == null)
		{
			throw new ArgumentNullException("other");
		}
		Major = other.Major;
		Minor = other.Minor;
		Revision = other.Revision;
		Api = other.Api;
		Profile = other.Profile;
	}

	public KhronosVersion(KhronosVersion other, string profile)
		: this(other)
	{
		Profile = profile;
	}

	public static bool operator ==(KhronosVersion left, KhronosVersion right)
	{
		if ((object)left == right)
		{
			return true;
		}
		return left?.Equals(right) ?? false;
	}

	public static bool operator !=(KhronosVersion left, KhronosVersion right)
	{
		if ((object)left == right)
		{
			return false;
		}
		if ((object)left == null)
		{
			return false;
		}
		return !left.Equals(right);
	}

	public static bool operator >(KhronosVersion left, KhronosVersion right)
	{
		if ((object)left == right)
		{
			return false;
		}
		if ((object)left == null)
		{
			return false;
		}
		if ((object)right == null)
		{
			return false;
		}
		return left.CompareTo(right) > 0;
	}

	public static bool operator <(KhronosVersion left, KhronosVersion right)
	{
		if ((object)left == right)
		{
			return false;
		}
		if ((object)left == null)
		{
			return false;
		}
		if ((object)right == null)
		{
			return false;
		}
		return left.CompareTo(right) < 0;
	}

	public static bool operator >=(KhronosVersion left, KhronosVersion right)
	{
		if ((object)left == right)
		{
			return true;
		}
		if ((object)left == null)
		{
			return false;
		}
		if ((object)right == null)
		{
			return false;
		}
		return left.CompareTo(right) >= 0;
	}

	public static bool operator <=(KhronosVersion left, KhronosVersion right)
	{
		if ((object)left == right)
		{
			return true;
		}
		if ((object)left == null)
		{
			return false;
		}
		if ((object)right == null)
		{
			return false;
		}
		return left.CompareTo(right) <= 0;
	}

	internal static KhronosVersion ParseFeature(string featureName)
	{
		if (featureName == null)
		{
			throw new ArgumentNullException("featureName");
		}
		if (featureName == "GL_VERSION_ES_CM_1_0")
		{
			return new KhronosVersion(1, 0, 0, "gles1");
		}
		Match match = Regex.Match(featureName, "(?<Api>GL(_(ES|SC|))?|WGL|GLX|EGL)_VERSION_(?<Major>\\d+)_(?<Minor>\\d+)");
		if (!match.Success)
		{
			return null;
		}
		string text = match.Groups["Api"].Value;
		int major = int.Parse(match.Groups["Major"].Value);
		int minor = int.Parse(match.Groups["Minor"].Value);
		switch (text)
		{
		case "GL":
			text = "gl";
			break;
		case "GL_ES":
			text = "gles2";
			break;
		case "GL_SC":
			text = "glsc2";
			break;
		case "WGL":
			text = "wgl";
			break;
		case "GLX":
			text = "glx";
			break;
		case "EGL":
			text = "egl";
			break;
		}
		return new KhronosVersion(major, minor, text);
	}

	public static KhronosVersion Parse(string input)
	{
		return Parse(input, null);
	}

	public static KhronosVersion Parse(string input, string api)
	{
		if (input == null)
		{
			throw new ArgumentNullException("input");
		}
		Match match = Regex.Match(input, "(?<Major>\\d+)\\.(?<Minor>\\d+)(\\.(?<Rev>\\d+))?");
		if (!match.Success)
		{
			throw new ArgumentException("unrecognized pattern '" + input + "'", "input");
		}
		int num = int.Parse(match.Groups["Major"].Value);
		int num2 = int.Parse(match.Groups["Minor"].Value);
		int revision = (match.Groups["Rev"].Success ? int.Parse(match.Groups["Rev"].Value) : 0);
		if (num2 >= 10 && num2 % 10 == 0)
		{
			num2 /= 10;
		}
		if (Regex.IsMatch(input, "ES"))
		{
			api = ((num != 1) ? "gles2" : "gles1");
		}
		else if (api == null)
		{
			api = "gl";
		}
		return new KhronosVersion(num, num2, revision, api);
	}

	public bool IsCompatible(KhronosVersion other)
	{
		if (other == null)
		{
			throw new ArgumentNullException("other");
		}
		if (Api != other.Api)
		{
			return false;
		}
		if (Major < other.Major)
		{
			return false;
		}
		if (Minor < other.Minor)
		{
			return false;
		}
		if (Revision < other.Revision)
		{
			return false;
		}
		return true;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("Version={0}.{1}", Major, Minor);
		if (Revision != 0)
		{
			stringBuilder.AppendFormat(".{0}", Revision);
		}
		if (!string.IsNullOrEmpty(Api))
		{
			stringBuilder.AppendFormat(" API={0}", Api);
		}
		if (Profile != null)
		{
			stringBuilder.AppendFormat(" Profile={0}", Profile);
		}
		return stringBuilder.ToString();
	}

	public bool Equals(KhronosVersion other)
	{
		if ((object)other == null)
		{
			return false;
		}
		if ((object)this == other)
		{
			return true;
		}
		if (Api != other.Api)
		{
			return false;
		}
		if (Major != other.Major)
		{
			return false;
		}
		if (Minor != other.Minor)
		{
			return false;
		}
		if (Revision != other.Revision)
		{
			return false;
		}
		if (Profile != null && other.Profile != null && Profile != other.Profile)
		{
			return false;
		}
		return true;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (this == obj)
		{
			return true;
		}
		if (obj.GetType() != typeof(KhronosVersion) && !obj.GetType().GetTypeInfo().IsSubclassOf(typeof(KhronosVersion)))
		{
			return false;
		}
		return Equals((KhronosVersion)obj);
	}

	public override int GetHashCode()
	{
		int num = 0;
		num = (num * 397) ^ Api.GetHashCode();
		num = (num * 397) ^ Major.GetHashCode();
		num = (num * 397) ^ Minor.GetHashCode();
		num = (num * 397) ^ Revision.GetHashCode();
		if (Profile != null)
		{
			num = (num * 397) ^ Profile.GetHashCode();
		}
		return num;
	}

	public int CompareTo(KhronosVersion other)
	{
		if ((object)this == other)
		{
			return 0;
		}
		if ((object)other == null)
		{
			return 1;
		}
		if (Api != other.Api)
		{
			throw new InvalidOperationException("different API version are not comparable");
		}
		int num = Major.CompareTo(other.Major);
		if (num != 0)
		{
			return num;
		}
		int num2 = Minor.CompareTo(other.Minor);
		if (num2 != 0)
		{
			return num2;
		}
		int num3 = Revision.CompareTo(other.Revision);
		if (num3 != 0)
		{
			return num3;
		}
		return 0;
	}
}
