using AutoMapper;
using Radiator.Core.Infrastructure;
using Radiator.Domain;
using Radiator.UserInterface.Models;

namespace Radiator.UserInterface.Mappings
{
    public class ProjectToSnapshotCollectionMapper : IMapper
    {
        /// <summary>
        /// Creates the appropriate map.
        /// </summary>
        /// <param name="configuration">The configuration context.</param>
        public void CreateMap(IConfiguration configuration)
        {
            configuration.CreateMap<Project, ProjectSnapshot>()
                .ForMember(p => p.Builds, o => o.Ignore())
                .AfterMap((p, pc) =>
                              {
                                  foreach (var buildType in p.BuildTypes.BuildType)
                                  {
                                      pc.Builds.Add(Mapper.Map<BuildType, BuildTypeSnapshot>(buildType));
                                  }
                              });
        }
    }
}