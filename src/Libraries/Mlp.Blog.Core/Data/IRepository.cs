using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mlp.Blog.Core.Data
{
    public interface IRepository<TEntity, TKey>
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes);
        IQueryable<TEntity> GetAll();
        TEntity GetById(TKey id);

    }
}
