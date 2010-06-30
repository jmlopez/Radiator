using System.Collections.Generic;
using System.Linq;
using Radiator.Domain;
using Radiator.Services;

namespace Radiator.Core.Services
{
    public class BuildTypeService : IBuildTypeService
    {
        private readonly ITeamCityService _teamCityService;
        private readonly IBuildService _buildService;
        public BuildTypeService(ITeamCityService teamCityService, IBuildService buildService)
        {
            _teamCityService = teamCityService;
            _buildService = buildService;
        }

        public IEnumerable<BuildType> FindAll()
        {
            var query = EntityQuery<BuildType>
                            .New()
                            .FindAll();

            return _teamCityService.GetList(query).Cast<BuildType>();
        }

        public BuildType FindById(string id)
        {
            var query = EntityQuery<BuildType>
                            .New()
                            .FindById(id);

            return _teamCityService.GetEntity(query);
        }

        public void LoadBuildTypes(Project project, List<BuildType> buildTypes)
        {
            foreach (var buildType in buildTypes)
            {
                buildType.Project = project;
                buildType.Builds = new List<Build>(_buildService.FindByBuildTypeId(buildType.Id));
            }
        }
    }
}