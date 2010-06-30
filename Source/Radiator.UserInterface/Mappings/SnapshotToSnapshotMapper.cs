using AutoMapper;
using Radiator.Core.Infrastructure;
using Radiator.UserInterface.Models;

namespace Radiator.UserInterface.Mappings
{
    public class SnapshotToSnapshotMapper : IMapper
    {
        /// <summary>
        /// Creates the appropriate map.
        /// </summary>
        /// <param name="configuration">The configuration context.</param>
        public void CreateMap(IConfiguration configuration)
        {
            configuration.CreateMap<ProjectSnapshot, ProjectSnapshot>();
        }
    }
}