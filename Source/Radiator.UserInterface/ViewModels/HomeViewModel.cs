using System.Collections.ObjectModel;
using System.Linq;
using AutoMapper;
using Caliburn.PresentationFramework;
using Caliburn.PresentationFramework.Invocation;
using Radiator.Infrastructure;
using Radiator.UserInterface.Messages;
using Radiator.UserInterface.Models;

namespace Radiator.UserInterface.ViewModels
{
    public class HomeViewModel : PropertyChangedBase, IConsumer<ProjectsRetrievedMessage>
    {
        public HomeViewModel()
        {
            Projects = new ObservableCollection<ProjectSnapshot>();
        }

        public ObservableCollection<ProjectSnapshot> Projects { get; private set; }

        public void Consume(ProjectsRetrievedMessage message)
        {
            Execute.OnUIThread(() =>
                                   {
                                       var snapshots = message.Projects;
                                       foreach (var snapshot in snapshots)
                                       {
                                           ProjectSnapshot snapshot1 = snapshot;
                                           var project = Projects.FirstOrDefault(p => p.Id == snapshot1.Id);
                                           if (project == null)
                                           {
                                               Projects.Add(snapshot);
                                               continue;
                                           }

                                           Mapper.Map(snapshot, project);
                                       }
                                   });
        }
    }
}