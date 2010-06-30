using Microsoft.Practices.ServiceLocation;
using NUnit.Framework;
using Radiator.Core.Configuration;
using Radiator.Core.Infrastructure;
using Radiator.Core.Services.Settings;
using Radiator.Services;
using Radiator.Tests;
using StructureMap;

namespace Radiator.IntegrationTests
{
    [TestFixture]
    public class BasicTest
    {
        [Test]
        public void Projects_Can_Be_Retrieved()
        {
            var container = new Container(x =>
                                              {
                                                  x.For<UrlSettings>().Use(new UrlSettings
                                                      {
                                                          BaseUrl = "http://megadevfun.proace.local/httpAuth/app/rest",
                                                          Username = "jmarnold",
                                                          Password = "asshole"
                                                      });
                                                  x.AddRegistry<CoreRegistry>();
                                              });
            ServiceLocator.SetLocatorProvider(() => new StructureMapServiceLocator(container));
            var projectService = container.GetInstance<IProjectService>();
            var projects = projectService.FindAll();

            projects.ShouldNotBeNull();
            projects.ShouldNotBeEmpty();
        }
    }
}