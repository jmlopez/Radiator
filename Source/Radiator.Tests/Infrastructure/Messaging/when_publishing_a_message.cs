using NUnit.Framework;
using Radiator.Core.Infrastructure;
using Radiator.Infrastructure;
using StructureMap;

namespace Radiator.Tests.Infrastructure.Messaging
{
    [TestFixture]
    public class when_publishing_a_message
    {
        [Test]
        public void consumers_are_notified()
        {
            const string body = "Test";
            var container = new Container(x => x.For<IConsumer<TestMessage>>().Singleton().Use<TestConsumer>());
            var bus = new MessageBus(container);
            var msg = new TestMessage {Body = body};

            bus.Publish(msg);

            (container.GetInstance<IConsumer<TestMessage>>() as TestConsumer)
                .Message
                .ShouldEqual(body);
        }

        public class TestMessage { public string Body { get; set; } }

        public class TestConsumer : IConsumer<TestMessage>
        {
            public string Message { get; private set; }
            public void Consume(TestMessage message)
            {
                Message = message.Body;
            }
        }
        
    }
}