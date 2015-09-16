using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QANotes.Models;

namespace QANotes.DataAccess
{
    // TODO Rename file to IRepo after commit
    public interface IRepo<T>
        where T : IEntity
    {
        IQueryable<T> GetAll();
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        IEntity GetById(int id);
    }
}