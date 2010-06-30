using AutoMapper;
using Caliburn.StructureMap;
using Microsoft.Practices.ServiceLocation;
using Radiator.Core.Configuration;
using Radiator.Core.Infrastructure;
using Radiator.Core.Services.Settings;
using Radiator.Infrastructure;
using Radiator.UserInterface.Mappings;
using Radiator.UserInterface.Messages;
using Radiator.UserInterface.Services;
using Radiator.UserInterface.ViewModels;
using StructureMap;

namespace Radiator.UserInterface
{
    public static class RadiatorRegistry
    {
        private static IServiceController _controller;
        public static IServiceLocator CreateContainer()
        {
            var container = new Container(x =>
                                         {
                                             x.For<UrlSettings>().Use<UrlSettings>();
                                             x.AddRegistry<CoreRegistry>();
                                             x.For<IServiceController>()
                                                 .Singleton()
                                                 .Use<ServiceController>();

                                             //TODO -- Gotta refactor this. The MessageBus isn't retrieving consumers properly
                                             var vm = new HomeViewModel();
                                             x.For<HomeViewModel>().Singleton().Use(vm);
                                             x.For<IConsumer<ProjectsRetrievedMessage>>().Singleton().Use(vm);
                                         });

            ServiceLocator.SetLocatorProvider(() => new StructureMapServiceLocator(container));
            Mapper.Initialize(x => x.AddAllFromAssemblyContainingType<MappingMarker>());

            _controller = container.GetInstance<IServiceController>();
            _controller
                .Host<ProjectPulseService>(x => x.InitializeWith(s => s.RetrieveProjects())
                                                           .StartWith(s => s.Start())
                                                           .StopWith(s => s.Stop())
                                                           .AutoStart(false));

            return new StructureMapAdapter(container);
        }
    }
}