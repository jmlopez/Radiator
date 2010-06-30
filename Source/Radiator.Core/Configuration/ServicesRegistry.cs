using Radiator.Core.Services;
using Radiator.Services;
using StructureMap.Configuration.DSL;

namespace Radiator.Core.Configuration
{
	/// <summary>
	/// Provides a common registry mechanism for repository implementations.
	/// </summary>
	public class ServicesRegistry : Registry
	{
		/// <summary>
        /// Initializes a new instance of the <see cref="ServicesRegistry"/> class.
		/// </summary>
        public ServicesRegistry()
		{
            Scan(x =>
                     {
                         x.TheCallingAssembly();
                         x.AssemblyContainingType<ServiceMarker>();
                         x.IncludeNamespaceContainingType<ServiceMarker>();
                         x.IncludeNamespaceContainingType<CoreServiceMarker>();
                         x.WithDefaultConventions();
                     });
		}
	}
}
