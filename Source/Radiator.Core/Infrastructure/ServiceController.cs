using System;
using FubuCore.Util;
using Radiator.Infrastructure;
using StructureMap;

namespace Radiator.Core.Infrastructure
{
    public class ServiceController : IServiceController
    {
        private readonly IContainer _container;
        private readonly Cache<Guid, IServiceHost> _services;
        public ServiceController(IContainer container)
        {
            _container = container;
            _services = new Cache<Guid, IServiceHost>(id => new NulloServiceHost());
        }

        public Guid Host<TService>(Action<IServiceControllerExpression<TService>> controllerExpression) where TService : class
        {
            var instance = _container.GetInstance<TService>();
            var host = ServiceHost<TService>.For(instance, controllerExpression);
            _services.Fill(host.Id, host);
            host.Initialize();

            if(host.StartAutomatically)
            {
                host.Start();
            }

            return host.Id;
        }

        public void Start(Guid serviceId)
        {
            _services[serviceId]
                .Start();
        }

        public void Stop(Guid serviceId)
        {
            _services[serviceId]
                .Stop();
        }

        public void Dispose(Guid serviceId)
        {
            var service = _services[serviceId];
            service.Stop();
            _services.Remove(serviceId);
            service = null;
        }
    }
}