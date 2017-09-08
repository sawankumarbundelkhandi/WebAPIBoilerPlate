using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace WebAPIBoilerPlate.DataModel.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Delete(Func<TEntity, bool> where);

        void Delete(object id);

        bool Exists(object primaryKey);

        IEnumerable<TEntity> Get();

        TEntity Get(Func<TEntity, bool> where);

        IEnumerable<TEntity> GetAll();

        TEntity GetByID(object id);

        TEntity GetFirst(Func<TEntity, bool> predicate);

        IEnumerable<TEntity> GetMany(Func<TEntity, bool> where);

        IQueryable<TEntity> GetManyQueryable(Func<TEntity, bool> where);

        TEntity GetSingle(Func<TEntity, bool> predicate);

        IQueryable<TEntity> GetWithInclude(Expression<Func<TEntity, bool>> predicate, params string[] include);

        void Insert(TEntity entity);

        void Update(TEntity entityToUpdate);
    }
}