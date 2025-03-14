using System;
using System.Text.RegularExpressions;

namespace Khronos;

[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public sealed class RequiredByFeatureAttribute : Attribute
{
	public readonly string FeatureName;

	public readonly KhronosVersion FeatureVersion;

	public string Api = "gl";

	public string Profile;

	public string EntryPoint;

	public RequiredByFeatureAttribute(string featureName)
	{
		if (string.IsNullOrEmpty(featureName))
		{
			throw new ArgumentException("null or empty feature not allowed", "featureName");
		}
		FeatureName = featureName;
		FeatureVersion = KhronosVersion.ParseFeature(FeatureName);
	}

	internal bool IsSupportedApi(string api)
	{
		if (api == null)
		{
			throw new ArgumentNullException("api");
		}
		if (FeatureVersion != null)
		{
			return false;
		}
		return Regex.IsMatch(api, Api);
	}

	public bool IsSupported(KhronosVersion version, KhronosApi.ExtensionsCollection extensions)
	{
		if (version == null)
		{
			throw new ArgumentNullException("version");
		}
		if (FeatureVersion != null)
		{
			if (version.Api != FeatureVersion.Api)
			{
				return false;
			}
			if (Profile != null && version.Profile != null && !Regex.IsMatch(version.Profile, Profile))
			{
				return false;
			}
			return version >= FeatureVersion;
		}
		if (extensions != null)
		{
			if (!Regex.IsMatch(version.Api, Api))
			{
				return false;
			}
			return extensions.HasExtensions(FeatureName);
		}
		return false;
	}
}
