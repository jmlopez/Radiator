using System.Collections.Generic;
using System.Linq;
using Radiator.Domain;
using Radiator.Services;

namespace Radiator.Core.Services
{
    public class BuildService : IBuildService
    {
        private readonly ITeamCityService _teamCityService;

        public BuildService(ITeamCityService teamCityService)
        {
            _teamCityService = teamCityService;
        }

        public IEnumerable<Build> FindByBuildTypeId(string buildTypeId)
        {
            var query = EntityQuery<BuildType>
                            .New()
                            .GetProperty(buildTypeId, b => b.Builds);

            return _teamCityService.GetList(query).Cast<Build>();
        }
    }
}