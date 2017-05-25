using System;
using System.Linq;
using System.Linq.Expressions;

namespace FrameworkTwo.Repository.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        T GetItem(Expression<Func<T, bool>> filter);
        IQueryable<T> GetAll();
        void Save(T entity);
        void Delete(T entity);
        void Update(T entity, params Expression<Func<T, object>>[] updatedProperties);
    }
}
