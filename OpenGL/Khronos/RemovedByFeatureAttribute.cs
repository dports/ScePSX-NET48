using System;
using System.Text.RegularExpressions;

namespace Khronos;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field | AttributeTargets.Delegate, AllowMultiple = true)]
public sealed class RemovedByFeatureAttribute : Attribute
{
	public readonly string FeatureName;

	public readonly KhronosVersion FeatureVersion;

	public string Api = "gl";

	public string Profile;

	public RemovedByFeatureAttribute(string featureName)
	{
		if (string.IsNullOrEmpty(featureName))
		{
			throw new ArgumentException("null or empty feature not allowed", "featureName");
		}
		FeatureName = featureName;
		FeatureVersion = KhronosVersion.ParseFeature(FeatureName);
	}

	public bool IsRemoved(KhronosVersion version, KhronosApi.ExtensionsCollection extensions)
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
