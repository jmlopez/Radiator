using System;
using System.Linq;
using System.Timers;
using Radiator.Domain;
using Radiator.Infrastructure;
using Radiator.Services;
using Radiator.UserInterface.Messages;
using Radiator.UserInterface.Models;

namespace Radiator.UserInterface.Services
{
    public class ProjectPulseService
    {
        private static readonly object Lock;
        static ProjectPulseService()
        {
            Lock = new object();
        }

        private readonly IMessageBus _messageBus;
        private readonly IMappingRegistry _mappingRegistry;
        private readonly IProjectService _projectService;
        private readonly Timer _timer;

        public ProjectPulseService(IMessageBus messageBus, IMappingRegistry mappingRegistry, IProjectService projectService)
        {
            _messageBus = messageBus;
            _projectService = projectService;
            _mappingRegistry = mappingRegistry;
            
            _timer = new Timer(300000);
            _timer.Elapsed += (s, e) => RetrieveProjects();
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        public void RetrieveProjects()
        {
            Stop();
            _messageBus.Publish(new RetrievingProjectsMessage());
            
            lock(Lock)
            {
                try
                {
                    var projects = _projectService.FindAll();
                    var snapshots = from p in projects
                                    select _mappingRegistry.Map<Project, ProjectSnapshot>(p);

                    _messageBus.Publish(new ProjectsRetrievedMessage
                                            {
                                                Projects = new ProjectSnapshotCollection(snapshots.ToList())
                                            });
                }
                catch (Exception exc)
                {
                    _messageBus.Publish(new ErrorMessage
                                            {
                                                Exception = exc
                                            });
                }
            }

            Start();
        }
    }
}