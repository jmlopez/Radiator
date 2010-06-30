using System.Linq;
using AutoMapper;
using Radiator.Core.Infrastructure;
using Radiator.Domain;
using Radiator.UserInterface.Models;

namespace Radiator.UserInterface.Mappings
{
    public class BuildTypeToSnapshotMapper : IMapper
    {
        /// <summary>
        /// Creates the appropriate map.
        /// </summary>
        /// <param name="configuration">The configuration context.</param>
        public void CreateMap(IConfiguration configuration)
        {
            configuration.CreateMap<BuildType, BuildTypeSnapshot>()
                .ForMember(s => s.Status, o => o.MapFrom(src =>
                                                             {
                                                                 var build = src.Builds.FirstOrDefault();
                                                                 if(build != null)
                                                                 {
                                                                     return build.Status.Substring(0, 1) + build.Status.Substring(1).ToLower();
                                                                 }

                                                                 return "Unknown";
                                                             }));
        }
    }
}