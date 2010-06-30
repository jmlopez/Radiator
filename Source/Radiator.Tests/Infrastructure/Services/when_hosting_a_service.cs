using NUnit.Framework;
using Radiator.Core.Infrastructure;
using Rhino.Mocks;

namespace Radiator.Tests.Infrastructure.Services
{
    [TestFixture]
    public class when_hosting_a_service : InteractionContext<ServiceController>
    {
        [Test]
        public void the_service_is_initialized_if_expression_is_given()
        {
            MockFor<IDummyService>()
                .Expect(d => d.Init());

            ClassUnderTest.Host<IDummyService>(x => x.InitializeWith(s => s.Init()));

            VerifyCallsFor<IDummyService>();
        }

        [Test]
        public void the_service_is_started_when_specified()
        {
            MockFor<IDummyService>()
                .Expect(d => d.Start());

            ClassUnderTest.Host<IDummyService>(x => x.StartWith(s => s.Start())
                                                       .AutoStart(true));

            VerifyCallsFor<IDummyService>();
        }

        [Test]
        public void the_service_is_not_started_when_specified()
        {
            ClassUnderTest.Host<IDummyService>(x => x.StartWith(s => s.Start())
                                                       .AutoStart(false));

            MockFor<IDummyService>()
                .AssertWasNotCalled(d => d.Start());
        }
        
        [Test]
        public void the_service_is_stopped_when_instructed()
        {
            MockFor<IDummyService>()
                .Expect(d => d.Stop());

            var id = ClassUnderTest.Host<IDummyService>(x => x.StopWith(s => s.Stop()));

            ClassUnderTest.Stop(id);

            VerifyCallsFor<IDummyService>();
        }

        [Test]
        public void the_service_is_removed_when_instructed()
        {
            MockFor<IDummyService>()
                .Expect(d => d.Stop());

            var id = ClassUnderTest.Host<IDummyService>(x => x.StopWith(s => s.Stop()));

            ClassUnderTest.Dispose(id);

            VerifyCallsFor<IDummyService>();

            MockFor<IDummyService>()
                .BackToRecord();

            ClassUnderTest.Start(id);

            MockFor<IDummyService>()
                .Replay();

            MockFor<IDummyService>()
                .AssertWasNotCalled(s => s.Start());
        }


        #region Nested Type: IDummyService
        public interface IDummyService
        {
            void Init();
            void Start();
            void Stop();
        }
        #endregion
    }
}