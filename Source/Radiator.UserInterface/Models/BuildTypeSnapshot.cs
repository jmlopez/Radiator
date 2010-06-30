using Caliburn.PresentationFramework;

namespace Radiator.UserInterface.Models
{
    public class BuildTypeSnapshot : PropertyChangedBase
    {
        private string _name;
        private BuildStatus _status;

        public string Id { get; set; }

        public BuildStatus Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                NotifyOfPropertyChange("Status");
            }
        }


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
    }
}