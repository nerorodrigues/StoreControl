using Utils.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace Utils.Infrastructure
{
    public interface IDAO<TEntity, TKey> where TEntity : EntityModelBase<TKey> where TKey : struct
    {
        TEntity Add(TEntity pEntity);
        void AddMany(params TEntity[] pEntities);
        void Delete(TEntity pEntity);
        void Delete(TKey pEntity);
        void Update(TEntity pEntity);
        TEntity GetByKey(TKey pKey);
        IEnumerable<TEntity> List();
        IQueryable<TEntity> Query();
        void SaveChanges();

    }
}
