using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Repositories
{
    internal abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity: BaseEntity
    {
        private MusicLibraryContext context;

        protected BaseRepository(MusicLibraryContext context)
        {
            this.context = context;
        }

        public virtual TEntity GetEntity(int id)
        {
            return context.Set<TEntity>().FirstOrDefault(x => x.Id == id);
        }

        public virtual bool UpdateEntity(int id, TEntity newValue)
        {
            throw new System.NotImplementedException();
        }

        public virtual bool RemoveEntity(TEntity entity)
        {
            if (entity == null)
            {
                return false;
            }
            context.Set<TEntity>().Remove(entity);
            return true;
        }

        public virtual bool AddEntity(TEntity entity)
        {
            if (entity == null)
            {
                return false;
            }
            context.Set<TEntity>().Add(entity);
            return true;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return context.Set<TEntity>().AsQueryable();
        }

        protected void SaveChanges()
        {
            context.SaveChanges();
        }

        protected void RemoveOtherEntities<TOtherEntity>(IEnumerable<TOtherEntity> entities)
            where TOtherEntity : BaseEntity
        {
            context.Set<TOtherEntity>().RemoveRange(entities);
        }
    }
}
