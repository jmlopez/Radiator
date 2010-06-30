using System;

namespace Radiator.Settings
{
	/// <summary>
	/// Provides access to environmental variables.
	/// </summary>
	public class EnvironmentalVariableProvider : IEnvironmentalVariableProvider
	{
		/// <summary>
		/// Expands all environmental variables within the specified input.
		/// </summary>
		/// <param name="input">The string to expand.</param>
		/// <returns></returns>
		public string ExpandEnvironmentalVariables(string input)
		{
		    return Environment.ExpandEnvironmentVariables(input);
		}
	}
}
