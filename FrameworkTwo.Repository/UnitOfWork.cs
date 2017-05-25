using FrameworkTwo.Domain;
using FrameworkTwo.Repository.Interface;
using System;

namespace FrameworkTwo.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private FrameworkTwoContext _context;

        public UnitOfWork(FrameworkTwoContext context)
        {
            this._context = context;
        }

        public FrameworkTwoContext DbContext
        {
            get
            {
                return this._context;
            }
        }

        public int Save()
        {
            return this._context.SaveChanges();
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._context != null)
                {
                    this._context.Dispose();
                    this._context = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
