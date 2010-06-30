using AutoMapper;
using Radiator.Core.Infrastructure;
using Radiator.Infrastructure;
using StructureMap.Configuration.DSL;

namespace Radiator.Core.Configuration
{
	/// <summary>
	/// Provides a common registry mechanism for the infrastructure layer.
	/// </summary>
	public class InfrastructureRegistry : Registry
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="InfrastructureRegistry"/> class.
		/// </summary>
        public InfrastructureRegistry()
		{
		    For<IMappingEngine>().Use(() => Mapper.Engine);
		    For<IMappingRegistry>().Use<AutoMapperMappingRegistry>();
		    For<IMessageBus>().Use<MessageBus>();
		    For<IJsonService>().Use<JsonService>();
		}
	}
}
