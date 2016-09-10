using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CemPattern.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        int SaveChanges();
    }
}