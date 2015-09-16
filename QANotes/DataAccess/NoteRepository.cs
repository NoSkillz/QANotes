using QANotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QANotes.DataAccess
{
    public class NoteRepository : IRepo<Note>, IDisposable
    {
        QANotesContext db;

        public NoteRepository(QANotesContext db)
        {
            this.db = db;
        }

        public void Add(Note entity)
        {
            db.Note.Add(entity);
            //db.SaveChanges();
        }

        public void Delete(Note entity)
        {
            db.Note.Remove(entity);
            //db.SaveChanges();
        }

        public IEntity GetById(int id)
        {
            return db.Note.FirstOrDefault(p => p.Id == id);
        }

        public IQueryable<Note> GetAll()
        {
            return db.Note.Select(p => p);
        }

        public void Update(Note entity)
        {
            //db.Entry(entity).State
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
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}