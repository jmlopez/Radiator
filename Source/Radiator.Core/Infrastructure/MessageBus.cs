using System.Threading.Tasks;
using Radiator.Infrastructure;
using StructureMap;

namespace Radiator.Core.Infrastructure
{
    public class MessageBus : IMessageBus
    {
        private readonly IContainer _container;

        public MessageBus(IContainer container)
        {
            _container = container;
        }

        public void Publish<TMessage>(TMessage message) 
            where TMessage : class
        {
            var consumers = _container.GetAllInstances<IConsumer<TMessage>>();
            Parallel.ForEach(consumers, consumer => consumer.Consume(message));
        }
    }
}