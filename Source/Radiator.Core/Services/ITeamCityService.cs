using System.Collections;

namespace Radiator.Core.Services
{
    public interface ITeamCityService
    {
        TEntity GetEntity<TEntity>(EntityQuery<TEntity> query);
        IEnumerable GetList<TEntity>(EntityQuery<TEntity> query);
    }
}