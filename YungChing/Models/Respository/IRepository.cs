using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace YungChing.Models
{
    public interface IRepository<T> where T : class
    {
        Task<IList<T>> GetAll();
        Task<IList<T>> Where(T entity, Expression<Func<T, bool>> expression);
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
        Task<T> Delete(T entity);
    }
}
