using System.Collections.Generic;

namespace Xunit.Runner.Common;

/// <summary>
/// This class is used to read configuration information for a test assembly.
/// </summary>
public static class ConfigReader
{
	/// <summary>
	/// Loads the test assembly configuration for the given test assembly.
	/// </summary>
	/// <param name="configuration">The configuration object to write the values to.</param>
	/// <param name="assemblyFileName">The test assembly.</param>
	/// <param name="configFileName">The test assembly configuration file.</param>
	/// <param name="warnings">The list of warnings that occured when loading</param>
	/// <returns>A flag which indicates whether configuration values were read.</returns>
	public static bool Load(
		TestAssemblyConfiguration configuration,
		string? assemblyFileName,
		string? configFileName,
		out List<string> warnings)
	{
		warnings = new List<string>();
		
		// JSON configuration takes priority over XML configuration
		if (ConfigReader_Json.Load(configuration, assemblyFileName, configFileName, out warnings))
			return true;

#if NETFRAMEWORK
		if (ConfigReader_Configuration.Load(configuration, assemblyFileName, configFileName, out warnings))
			return true;
#endif

		return false;
	}
}
