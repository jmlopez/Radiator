using StructureMap.Configuration.DSL;

namespace Radiator.Core.Configuration
{
    public class CoreRegistry : Registry
    {
        public CoreRegistry()
        {
            Scan(x =>
                     {
                         x.TheCallingAssembly();
                         x.IncludeNamespaceContainingType<CoreRegistry>();
                         x.ExcludeType<CoreRegistry>();
                         x.LookForRegistries();
                     });
        }
    }
}