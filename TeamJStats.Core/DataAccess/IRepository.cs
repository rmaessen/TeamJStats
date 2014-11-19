using System;
using System.Linq;
using System.Linq.Expressions;
using TeamJStats.Domain;

namespace TeamJStats.DataAccess.DataAccess
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IDataContextFactory ContextFactory { get; set; }

        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate = null);
        IQueryable<TEntity> Query(EntityStatus status, Expression<Func<TEntity, bool>> predicate = null);

        void Delete(TEntity entity);
        void Archive(TEntity entity);
        void Activate(TEntity entity);
        void Save(TEntity entity);
    }
}