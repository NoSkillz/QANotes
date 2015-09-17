using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QANotes.Models;
using System.Linq.Expressions;

namespace QANotes.DataAccess
{
    // TODO: Generic repository
    public interface IRepo<T> : IDisposable
        where T : class
    {
        IQueryable<T> GetAll();
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
    }
}