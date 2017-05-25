using FrameworkTwo.Domain;
using FrameworkTwo.Repository.Interface;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace FrameworkTwo.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected FrameworkTwoContext _context;

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _context = unitOfWork.DbContext;
        }

        public T GetItem(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = _context.Set<T>();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.FirstOrDefault();
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> query = _context.Set<T>();
            return query;
        }

        public void Save(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity, params Expression<Func<T, object>>[] updatedProperties)
        {
            _context.Set<T>().Attach(entity);
            if (updatedProperties.Any())
            {
                //update explicitly mentioned properties
                foreach (var property in updatedProperties)
                {
                    _context.Entry(entity).Property(property).IsModified = true;
                }
            }
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
