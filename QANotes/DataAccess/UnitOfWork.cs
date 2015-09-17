using QANotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QANotes.DataAccess
{
    public class UnitOfWork : IDisposable
    {
        private QANotesContext db;
        private Dictionary<string, object> repositories;

        public UnitOfWork(QANotesContext db)
        {
            this.db = db;
        }

        public UnitOfWork()
        {
            db = new QANotesContext();
        }

        public Repository<T> Repository<T>() where T : class
        {
            if (repositories == null)
            {
                repositories = new Dictionary<string, object>();
            }

            var type = typeof(T).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), db);
                repositories.Add(type, repositoryInstance);
            }

            return (Repository<T>)repositories[type];
        }

        #region Dispose
        private bool disposed = false; // To detect redundant calls

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