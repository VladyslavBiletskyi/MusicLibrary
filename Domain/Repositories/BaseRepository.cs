using System.Collections.Generic;
using System.Data.Entity;
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
            var entity = context.Set<TEntity>().FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return null;
            }
            else
            {
                
                return GetQueryable().FirstOrDefault(x => x.Id == id);
            }
        }

        public virtual bool UpdateEntity(int id, TEntity newValue)
        {
            throw new System.NotImplementedException();
        }

        public virtual bool RemoveEntity(int id)
        {
            try
            {
                TEntity entity = GetEntity(id);
                context.Set<TEntity>().Remove(entity);
                SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual bool AddEntity(TEntity entity)
        {
            if (entity == null)
            {
                return false;
            }
            context.Set<TEntity>().Add(entity);
            SaveChanges();
            return true;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return GetQueryable();
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

        private IQueryable<TEntity> GetQueryable()
        {
            var queryable = context.Set<TEntity>().AsQueryable();
            foreach (var property in typeof(TEntity).GetProperties())
            {
                if (property.GetGetMethod().ReturnType.BaseType == typeof(BaseEntity) || property.GetGetMethod().IsVirtual)
                {
                    queryable = queryable.Include(property.Name);
                }
            }

            return queryable;
        }
    }
}
