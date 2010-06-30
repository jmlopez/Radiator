namespace Radiator.Infrastructure
{
    public interface IMessageBus
    {
        void Publish<TMessage>(TMessage message) where TMessage : class;
    }
}