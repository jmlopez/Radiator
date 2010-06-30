namespace Radiator.Domain
{
    public class Project : DomainEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public BuildTypes BuildTypes { get; set; }
    }
}