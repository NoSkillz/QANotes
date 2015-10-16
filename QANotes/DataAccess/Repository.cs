using QANotes.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace QANotes.DataAccess
{
    public class Repository<T> : IRepo<T> where T : class
    {
        QANotesContext db;
        

        public Repository(QANotesContext db)
        {
            this.db = db;
        }

        public Repository()
        {
            db = new QANotesContext();
        }

        public void Add(T entity)
        {
            db.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            db.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return db.Set<T>();
        }

        public void Update(T entity)
        {
            db.Entry<T>(entity).State = EntityState.Modified;
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return db.Set<T>().Where(predicate);
        }

        public IQueryable<T> Select(Expression<Func<T, T>> selector)
        {
            return db.Set<T>().Select(selector);
        }


        public void SaveChanges()
        {
            db.SaveChanges();
        }

        #region Dispose
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}