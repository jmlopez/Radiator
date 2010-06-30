using System;

namespace Radiator.Infrastructure
{
    public interface IServiceControllerExpression<out TService> 
        where TService : class
    {
        IServiceControllerExpression<TService> InitializeWith(Action<TService> action);
        IServiceControllerExpression<TService> StartWith(Action<TService> action);
        IServiceControllerExpression<TService> StopWith(Action<TService> action);
        IServiceControllerExpression<TService> AutoStart(bool flag);
    }
}