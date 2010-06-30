using Radiator.UserInterface.Models;

namespace Radiator.UserInterface.Messages
{
    public class ProjectsRetrievedMessage
    {
        public ProjectSnapshotCollection Projects { get; set; }
    }
}