using QANotes.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace QANotes.DAL
{
    public class QANotesContext : DbContext
    {
        public QANotesContext() : base("QANotes")
        {

        }

        public DbSet<NoteType> NoteTypes { get; set; }
        public DbSet<Note> Note { get; set; }
        public DbSet<CustomNoteType> CustomNote { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}