using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Utils.Infrastructure.Data;

namespace Utils.Infrastructure.Dao
{
    public abstract class DaoEntityBase<TDbContext, TEntity, TKey> : IDAO<TEntity, TKey>, IDisposable 
        where TDbContext : DbContext, new()
        where TKey : struct where TEntity : EntityModelBase<TKey>
    {
        protected TDbContext Context;
        protected bool AutoSave;

        public DaoEntityBase(TDbContext pContext)
        {
            AutoSave = Context != null;
            Context = pContext ?? new TDbContext();
        }

        public abstract TEntity Add(TEntity pEntity);
        public abstract void AddMany(params TEntity[] pEntities);
        public abstract void Delete(TEntity pEntity);
        public abstract void Delete(TKey pEntity);
        public abstract TEntity GetByKey(TKey pKey);
        public abstract IEnumerable<TEntity> List();
        public abstract IQueryable<TEntity> Query();
        public abstract void Update(TEntity pEntity);
        public void Dispose()
        {
            if (AutoSave && Context != null)
            {
                SaveChanges();
                Context.Dispose();
            }
        }

        public void SaveChanges()
        {
            if (Context != null)
                Context.SaveChanges();
        }
    }
}
