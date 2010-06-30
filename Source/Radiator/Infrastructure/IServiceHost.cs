using System;

namespace Radiator.Infrastructure
{
    public interface IServiceHost
    {
        Guid Id { get; }
        void Initialize();
        void Start();
        void Stop();
    }
}