namespace Radiator.Infrastructure
{
    public interface IConsumer<in TMessage>
        where TMessage : class
    {
        void Consume(TMessage message);
    }
}