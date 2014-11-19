﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Dory.Core.Infrastructure.Common;
using Dory.Domain;
using Dory.Domain.Enumerations;
﻿using TeamJStats.DataAccess;
﻿using TeamJStats.DataAccess.Core;
﻿using TeamJStats.Domain;

namespace Dory.Core.DataAccess
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        #region Constructors and Destructors

        public Repository(IDataContextFactory contextFactory)
        {
            Contract.Requires<ArgumentNullException>(
                contextFactory != null,
                "Repository: contextFactory cannot be null");
            ContextFactory = contextFactory;
        }

        #endregion

        #region Public Properties
        public IDataContextFactory ContextFactory { get; set; }
        #endregion

        private DbSet<TEntity> CreateSet()
        {
            return ContextFactory.GetContext().Set<TEntity>();
        }

        // Aliased set as IQueryable
        private IQueryable<TEntity> CreateQuery()
        {
            return CreateSet();
        }

        #region Public methods
        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate = null)
        {
            return Query(EntityStatus.Active, predicate);
        }

        public IQueryable<TEntity> Query(EntityStatus status, Expression<Func<TEntity, bool>> predicate = null)
        {
            var query = CreateQuery();
            query = query.Where(x => x.EntityStatus == status);
            return predicate != null ? query.Where(predicate) : query;
        }

        public void Delete(TEntity entity)
        {
            CreateSet().Remove(entity);
        }

        public void Archive(TEntity entity)
        {
            entity.EntityStatus = EntityStatus.Archived;
            Save(entity);
        }

        public void Activate(TEntity entity)
        {
            entity.EntityStatus = EntityStatus.Active;
            Save(entity);
        }

        public void Save(TEntity entity)
        {
            entity.DateUpdatedUtc = DateTime.UtcNow;
            if (entity.Id == 0)
            {
                entity.DateCreatedUtc = DateTime.UtcNow;
                entity.EntityStatus = EntityStatus.Active;
                CreateSet().Add(entity);
            }
            else
            {
                ContextFactory.GetContext().MarkAsModified(entity);
            }
        }

        #endregion

    }
}