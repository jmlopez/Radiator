using System.Collections.Generic;
using System.Linq;
using Radiator.Domain;
using Radiator.Services;

namespace Radiator.Core.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ITeamCityService _teamCityService;
        private readonly IBuildTypeService _buildTypeService;
        public ProjectService(ITeamCityService teamCityService, IBuildTypeService buildTypeService)
        {
            _teamCityService = teamCityService;
            _buildTypeService = buildTypeService;
        }

        public IEnumerable<Project> FindAll()
        {
            var query = EntityQuery<Project>
                            .New()
                            .FindAll();

            var projects = _teamCityService.GetList(query).Cast<Project>();
            foreach (var project in projects)
            {
                yield return FindById(project.Id);
            }
        }

        public Project FindById(string id)
        {
            var query = EntityQuery<Project>
                            .New()
                            .FindById(id);

            var project = _teamCityService.GetEntity(query);
            _buildTypeService.LoadBuildTypes(project, project.BuildTypes.BuildType);

            return project;
        }
    }
}