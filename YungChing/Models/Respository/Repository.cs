using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace YungChing.Models
{
    public abstract class Repository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        private readonly TContext _context;
        public Repository(TContext context)
        {
            _context = context;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            //
            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            //
            return entity;
        }

        public async Task<TEntity> Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            //
            return entity;
        }

        public async Task<TEntity> Get(int id) => await _context.Set<TEntity>().FindAsync(id);

        public async Task<IList<TEntity>> GetAll() => await _context.Set<TEntity>().ToListAsync();
        
        public async Task<TEntity> Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            //
            return entity;
        }

        public async Task<IList<TEntity>> Where(TEntity entity, Expression<Func<TEntity, bool>> expression)
            => await _context.Set<TEntity>().Where(expression).ToListAsync();
    }
}
