using System;

namespace Radiator.Infrastructure
{
    public interface IServiceController
    {
        Guid Host<TService>(Action<IServiceControllerExpression<TService>> controllerExpression)
            where TService : class;

        void Start(Guid serviceId);

        void Stop(Guid serviceId);
    }
}