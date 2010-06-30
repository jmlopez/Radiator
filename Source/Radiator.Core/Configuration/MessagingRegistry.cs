using Radiator.Infrastructure;
using StructureMap.Configuration.DSL;

namespace Radiator.Core.Configuration
{
    public class MessagingRegistry : Registry
    {
        public MessagingRegistry()
        {
            Scan(s =>
                     {
                         s.AssembliesFromApplicationBaseDirectory();
                         s.ConnectImplementationsToTypesClosing(typeof (IConsumer<>));
                     });
        }
    }
}