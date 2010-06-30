using System.Collections.Specialized;

namespace Radiator.Settings
{
	/// <summary>
	/// Provides a mechanism for retrieving settings.
	/// </summary>
	public interface ISettingsProvider
	{
		/// <summary>
		/// Gets all settings.
		/// </summary>
		/// <returns></returns>
		NameValueCollection GetSettings();
	}
}
