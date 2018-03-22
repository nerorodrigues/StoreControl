using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StoreControl.Infrastructure.Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils.Infrastructure.Dao;
using Utils.Infrastructure.Data;

namespace StoreControl.Infrastructure.Database.DAO.Base
{
    public abstract class AppDaoBase<TEntity> : DaoEntityBase<ApplicationDbContext, TEntity, Guid> where TEntity : EntityModelBase<Guid>
    {
        protected abstract DbSet<TEntity> DbSet { get; }

        protected abstract string EntityName { get; }

        public AppDaoBase()
            : base(new DesignTimeDbContextFactory().CreateDbContext(null))
        {

        }

        protected AppDaoBase(ApplicationDbContext pContext = null)
            : base(pContext)
        {
        }

        public override TEntity Add(TEntity pEntity)
        {
            pEntity.CreationDate = DateTime.Now;
            DbSet.Add(pEntity);
            SaveChanges();
            return pEntity;
        }
        public override void AddMany(params TEntity[] pEntities)
        {
            foreach (var entity in pEntities)
            {
                entity.CreationDate = DateTime.Now;
                DbSet.Add(entity);
            }
        }

        public override void Delete(TEntity pEntity)
        {
            if (pEntity == null)
                throw new Exception($"E necessário informar a {EntityName} para exclusão");
            Delete(pEntity.ID);
        }
        public override void Delete(Guid pKey)
        {
            var entity = DbSet.Find(pKey);
            DbSet.Remove(entity);
        }
        public override void Update(TEntity pEntity)
        {
            var entity = DbSet.Find(pEntity.ID);
            if (entity == null)
                return;
            pEntity.LastDateTimeUpdate = DateTime.Now;
            Mapper.Map(pEntity, entity);
        }
        public override TEntity GetByKey(Guid pKey)
        {
            var entity = DbSet.Find(pKey);
            return entity;
        }
        public override IEnumerable<TEntity> List()
        {
            return DbSet.AsEnumerable();
        }

        public override IQueryable<TEntity> Query()
        {
            return DbSet.AsQueryable();
        }
    }
}
