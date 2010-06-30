using System;

namespace Radiator.Infrastructure
{
    public class ServiceHost<TService> : IServiceHost, IServiceControllerExpression<TService>
        where TService : class
    {
        private Action<TService> _init;
        private Action<TService> _start;
        private Action<TService> _stop;

        public ServiceHost(TService instance)
        {
            Id = Guid.NewGuid();
            Instance = instance;
        }

        public Guid Id { get; private set; }

        public void Initialize()
        {
            if(_init != null)
            {
                _init(Instance);
            }
        }

        public void Start()
        {
            if(_start != null)
            {
                _start(Instance);
            }
        }

        public void Stop()
        {
            if(_stop != null)
            {
                _stop(Instance);
            }
        }

        public TService Instance { get; private set; }

        public bool StartAutomatically { get; private set; }

        public IServiceControllerExpression<TService> InitializeWith(Action<TService> action)
        {
            _init = action;
            return this;
        }

        public IServiceControllerExpression<TService> StartWith(Action<TService> action)
        {
            _start = action;
            return this;
        }

        public IServiceControllerExpression<TService> StopWith(Action<TService> action)
        {
            _stop = action;
            return this;
        }

        public IServiceControllerExpression<TService> AutoStart(bool flag)
        {
            StartAutomatically = flag;
            return this;
        }

        public static ServiceHost<TService> For(TService instance, Action<IServiceControllerExpression<TService>> controllerExpression)
        {
            var serviceHost = new ServiceHost<TService>(instance);
            controllerExpression(serviceHost);
            return serviceHost;
        }
    }
}