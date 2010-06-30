using System.Collections.Generic;
using Radiator.Domain;

namespace Radiator.Services
{
    public interface IBuildService
    {
        IEnumerable<Build> FindByBuildTypeId(string buildTypeId);
    }
}