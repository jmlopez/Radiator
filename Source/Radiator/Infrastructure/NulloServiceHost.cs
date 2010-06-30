using System;

namespace Radiator.Infrastructure
{
    public class NulloServiceHost : IServiceHost
    {
        public Guid Id
        {
            get { return Guid.Empty; }
        }

        public void Initialize()
        {
        }

        public void Start()
        {
        }

        public void Stop()
        {
        }
    }
}