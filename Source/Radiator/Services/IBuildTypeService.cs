using System.Collections.Generic;
using Radiator.Domain;

namespace Radiator.Services
{
    public interface IBuildTypeService : IDomainEntityService<BuildType>
    {
        void LoadBuildTypes(Project project, List<BuildType> buildTypes);
    }
}