namespace QANotes.Migrations
{
    using DataAccess;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
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
            //Seed notetypes
            context.NoteTypes.AddOrUpdate(
                p => p.Id,
                new NoteType { Id = 1, Name = "Bug" },
                new NoteType { Id = 2, Name = "Issue" },
                new NoteType { Id = 3, Name = "Note" }
                );

            //Seed built-in notes
            context.Note.AddOrUpdate(
                p => p.Id,
                new Note { Id = 1, Description = "Test bug - Andrei", NoteTypeId = 1, UserId = "A26B4B32-C487-48ED-8474-915521EE920A" },
                new Note { Id = 2, Description = "Test issue - Andrei", NoteTypeId = 2, UserId = "A26B4B32-C487-48ED-8474-915521EE920A" },
                new Note { Id = 3, Description = "Test note - RandomUser", NoteTypeId = 3, UserId = "BAE991AB-A59F-4210-A732-01B15FE88FFC" }
                );

            //Seed custom notes
            context.CustomNote.AddOrUpdate(
                p => p.Id,
                new CustomNoteType { Id = 1, Name = "Custom note", UserId = "A26B4B32-C487-48ED-8474-915521EE920A" }
                );

            #region Seed users
            string password = new PasswordHasher().HashPassword("password");

            context.Users.AddOrUpdate(
                p => p.Email,
                new AppUser
                {
                    Id = "A26B4B32-C487-48ED-8474-915521EE920A",
                    Email = "noskillz05@gmail.com",
                    DateCreated = DateTime.Now,
                    UserName = "noskillz05@gmail.com",
                    SecurityStamp = "F8647A37-D900-438D-8F16-DC0F65689914".ToString(),
                    PasswordHash = password,
                },
                new AppUser
                {
                    Id = "BAE991AB-A59F-4210-A732-01B15FE88FFC",
                    Email = "randomuser@gmail.com",
                    DateCreated = DateTime.Now,
                    UserName = "randomuser@gmail.com",
                    SecurityStamp = "BBE32731-3202-4670-A0DF-1C439C353160".ToString(),
                    PasswordHash = password
                },
                new AppUser
                {
                    Id = "8428FC78-A280-4499-AD66-C276CADDD139",
                    Email = "vasile.mure@yahoo.com",
                    DateCreated = DateTime.Today,
                    UserName = "vasile.mure@yahoo.com",
                    SecurityStamp = "EDBE5CF3-433C-4271-80AD-E35B63297C5B".ToString(),
                    PasswordHash = password
                });
            #endregion
        }
    }
}
