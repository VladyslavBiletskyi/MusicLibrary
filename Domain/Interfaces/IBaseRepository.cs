using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity GetEntity(int id);

        bool UpdateEntity(int id, TEntity newValue);

        bool RemoveEntity(TEntity entity);

        bool AddEntity(TEntity entity);

        IQueryable<TEntity> GetAll();
    }
}
