using System.Collections.ObjectModel;
using Caliburn.PresentationFramework;

namespace Radiator.UserInterface.Models
{
    public class ProjectSnapshot : PropertyChangedBase
    {
        public ProjectSnapshot()
        {
            Builds = new ObservableCollection<BuildTypeSnapshot>();
        }

        private string _name;
        private string _projectName;
        private string _description;
        private BuildStatus _status;

        public string Id { get; set; }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                NotifyOfPropertyChange("Name");
            }
        }

        public ObservableCollection<BuildTypeSnapshot> Builds { get; set; }
    }
}