using System.Collections.Generic;

namespace Radiator.Domain
{
    public class BuildTypes
    {
        public List<BuildType> BuildType { get; set; }
    }

    public class BuildType : DomainEntity
    {
        public Project Project { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Paused { get; set; }
        public List<Build> Builds { get; set; }
    }
}