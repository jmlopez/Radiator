using System;

namespace Radiator.Settings
{
	/// <summary>
	/// Provides a mechanism for resolving keys for settings by prefixing the setting with the class name (i.e., "MyClass.MyProperty").
	/// </summary>
	public class ClassPrefixSettingKeyResolver : ISettingKeyResolver
	{
		/// <summary>
		/// Resolves the key for the specific type.
		/// </summary>
		/// <param name="type">The type of settings class.</param>
		/// <param name="key">The key being resolved.</param>
		/// <returns></returns>
		public string Resolve(Type type, string key)
		{
            if(!key.ToLower().StartsWith(type.Name.ToLower()))
            {
                return key;
            }

			return key.Substring(type.Name.Length + 1);
		}

		/// <summary>
		/// Gets a flag indicating whether the resolution is case sensitive.
		/// </summary>
		public bool IsCaseSensitive
		{
			get { return false; }
		}
	}
}
