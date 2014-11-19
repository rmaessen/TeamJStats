using System;
using System.Data.Entity;
using System.Reflection;

namespace TeamJStats.DataAccess.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DataContext() : this("TeamJStats")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<TEntity> CreateSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

        public virtual void MarkAsModified<TEntity>(TEntity instance) where TEntity : class {
            Entry(instance).State = EntityState.Modified;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentException("modelBuilder");
            }
            modelBuilder.Configurations.AddFromAssembly(Assembly.Load("TeamJStats.DataAccess"));
            Configuration.LazyLoadingEnabled = false;
        }
    }
}
