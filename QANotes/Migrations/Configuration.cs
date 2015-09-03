namespace QANotes.Migrations
{
    using DAL;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<QANotesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(QANotesContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.NoteTypes.AddOrUpdate(
                p => p.Id,
                new NoteType { Id = 1, Name = "Bug" },
                new NoteType { Id = 2, Name = "Issue" },
                new NoteType { Id = 3, Name = "Note" }
                );

            context.Note.AddOrUpdate(
                p => p.Id,
                new Note { Id = 1, Description = "Test bug", NoteTypeId = 1 },
                new Note { Id = 2, Description = "Test issue", NoteTypeId = 2 },
                new Note { Id = 3, Description = "Test note", NoteTypeId = 3 }
                );

            context.CustomNote.AddOrUpdate(
                p => p.Id,
                new CustomNoteType { Id = 1, Name = "Custom note" }
                );
        }
    }
}
