using Microsoft.Practices.ServiceLocation;
using Radiator.Core.Configuration.Conventions;
using Radiator.Core.Infrastructure;
using Radiator.Settings;
using Radiator.Visitors;
using StructureMap.Configuration.DSL;

namespace Radiator.Core.Configuration
{
	/// <summary>
	/// Provides a default registration mechanism for settings classes.
	/// </summary>
	public class SettingsRegistry : Registry
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SettingsRegistry"/> class using
		/// the default registration convention.
		/// </summary>
		public SettingsRegistry()
		{
			For<IServiceLocator>().Use<StructureMapServiceLocator>();
			For<IPropertyInfoProvider>().Use<ReflectionPropertyInfoProvider>();
			For<ISettingKeyResolver>().Use<ClassPrefixSettingKeyResolver>();
		    For<ISettingsProvider>().Use<AppSettingsProvider>();
		    For<IEnvironmentalVariableProvider>().Use<EnvironmentalVariableProvider>();
			Scan(s =>
			     	{
						s.AssembliesFromApplicationBaseDirectory();
                        s.Include(t => t.Name.EndsWith("Settings"));
			     		s.With(new DefaultSettingsConvention());
			     	});
		}
	}
}