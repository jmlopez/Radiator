using System.Collections.Generic;
using Radiator.Domain;

namespace Radiator.Services
{
    public interface IDomainEntityService<out TEntity>
        where TEntity : DomainEntity
    {
        IEnumerable<TEntity> FindAll();
        TEntity FindById(string id);
    }
}