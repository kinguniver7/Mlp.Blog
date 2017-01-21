using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Mlp.Blog.Core.Data;
using Mlp.Blog.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mlp.Blog.Data
{
    public class SqlRepository<TEntity,TKey> : IRepository<TEntity, TKey>
        where TEntity: class, IKey<TKey>
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        private object _loocker = new object();

        public SqlRepository()
        {
            _context = new TemporaryDbContextFactory().Create();
            _dbSet = _context.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            lock (_loocker)
            {
                _dbSet.Add(entity);
                _context.SaveChanges();
            }
            
        }

        public void Update(TEntity entity)
        {
            lock (_loocker)
            {
                _dbSet.Update(entity);
                _context.SaveChanges();
            }
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsQueryable();
        }
        public IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = null;
            foreach (var include in includes)
            {
                query = _dbSet.Include(include);
            }

            return query == null ? _dbSet : query;
        }
        
        public TEntity GetById(TKey id)
        {
            return _dbSet.FirstOrDefault(c => c.Id.Equals(id));
        }
    }
}
