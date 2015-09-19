using Microsoft.AspNet.Identity.EntityFramework;
using QANotes.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace QANotes.DataAccess
{
    public class QANotesContext : IdentityDbContext
    {
        public QANotesContext() : base("QANotes")
        {

        }

        public DbSet<NoteType> NoteTypes { get; set; }
        public DbSet<Note> Notes { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}