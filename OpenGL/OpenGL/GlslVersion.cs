using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Khronos;

namespace OpenGL;

[DebuggerDisplay("GlslVersion: Version={Major}.{Minor}.{Revision} (API='{Api}')")]
public class GlslVersion : KhronosVersion
{
	public override int VersionId => Major * 100 + ((Minor >= 10) ? Minor : (Minor * 10));

	public GlslVersion(int major, int minor, string api)
		: base(major, minor, 0, api)
	{
	}

	public new static GlslVersion Parse(string input)
	{
		if (input == null)
		{
			throw new ArgumentNullException("input");
		}
		Match match = Regex.Match(input, "(?<Major>\\d+)\\.(?<Minor>\\d+)(\\.(?<Rev>\\d+))?( .*)?");
		if (!match.Success)
		{
			throw new ArgumentException("unrecognized pattern", "input");
		}
		int major = int.Parse(match.Groups["Major"].Value);
		int num = int.Parse(match.Groups["Minor"].Value);
		string api = "glsl";
		if (Regex.IsMatch(input, "\\sES\\s?"))
		{
			api = "essl";
		}
		return new GlslVersion(major, (num >= 10) ? (num / 10) : num, api);
	}

	public new static GlslVersion Parse(string input, string api)
	{
		if (input == null)
		{
			throw new ArgumentNullException("input");
		}
		GlslVersion glslVersion = Parse(input);
		switch (api)
		{
		case "gl":
		case "glsl":
			glslVersion = new GlslVersion(glslVersion.Major, glslVersion.Minor, "glsl");
			break;
		case "gles2":
		case "glsc2":
		case "essl":
			glslVersion = new GlslVersion(glslVersion.Major, glslVersion.Minor, "essl");
			break;
		default:
			throw new NotSupportedException("api '" + api + "' not supported");
		case null:
			break;
		}
		return glslVersion;
	}
}
