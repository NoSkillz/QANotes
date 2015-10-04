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

        //TODO Cleanup hash. We need a better password

        protected override void Seed(QANotesContext context)
        {
            //Seed notetypes
            context.NoteTypes.AddOrUpdate(
                p => p.Id,
                new NoteType { Id = 1, Name = "Bug", Custom = false, UserId = null },
                new NoteType { Id = 2, Name = "Issue", Custom = false, UserId = null },
                new NoteType { Id = 3, Name = "Note", Custom = false, UserId = null }
                //new NoteType { Id = 4, Name = "Action", Custom = true, UserId = "A26B4B32-C487-48ED-8474-915521EE920A" },
                //new NoteType { Id = 5, Name = "TODO", Custom = true, UserId = "A26B4B32-C487-48ED-8474-915521EE920A" }
                );

            //Seed built-in notes
            context.Notes.AddOrUpdate(
                p => p.Id,
                //Bugs
                new Note { Id = 1, Description = "Exception when trying to add a note", NoteTypeId = 1, UserId = "A26B4B32-C487-48ED-8474-915521EE920A" },
                new Note { Id = 2, Description = "App looks bad on small resolutions", NoteTypeId = 1, UserId = "A26B4B32-C487-48ED-8474-915521EE920A" },
                new Note { Id = 3, Description = "Reloading is very slow", NoteTypeId = 1, UserId = "A26B4B32-C487-48ED-8474-915521EE920A" },
                new Note { Id = 4, Description = "Notes are not saved after confirming", NoteTypeId = 1, UserId = "A26B4B32-C487-48ED-8474-915521EE920A" },
                new Note { Id = 5, Description = "You can't delete a note yet", NoteTypeId = 1, UserId = "A26B4B32-C487-48ED-8474-915521EE920A" },

                //Issues
                new Note { Id = 6, Description = "When using a mobile device, the compatibility of the app hasn't been checked", NoteTypeId = 2, UserId = "A26B4B32-C487-48ED-8474-915521EE920A" },
                new Note { Id = 7, Description = "The app's theme doesn't look very nice. We should check other themes", NoteTypeId = 2, UserId = "A26B4B32-C487-48ED-8474-915521EE920A" },
                new Note { Id = 8, Description = "Databinding is incomplete", NoteTypeId = 2, UserId = "A26B4B32-C487-48ED-8474-915521EE920A" },


                //Notes
                new Note { Id = 9, Description = "How would a long list look?", NoteTypeId = 3, UserId = "A26B4B32-C487-48ED-8474-915521EE920A" },
                new Note { Id = 10, Description = "How would implementing some statistics go?", NoteTypeId = 3, UserId = "A26B4B32-C487-48ED-8474-915521EE920A" },
                new Note { Id = 11, Description = "Is there anything else I can do better? I should investigate", NoteTypeId = 3, UserId = "A26B4B32-C487-48ED-8474-915521EE920A" }

                //Custom
                //new Note { Id = 12, Description = "Test this feature", NoteTypeId = 4, UserId = "A26B4B32-C487-48ED-8474-915521EE920A" },
                //new Note { Id = 13, Description = "Test that other feature", NoteTypeId = 4, UserId = "BAE991AB-A59F-4210-A732-01B15FE88FFC" },
                //new Note { Id = 14, Description = "TODO: Find something to fix", NoteTypeId = 5, UserId = "BAE991AB-A59F-4210-A732-01B15FE88FFC" },
                //new Note { Id = 15, Description = "TODO: Find something to implement", NoteTypeId = 5, UserId = "BAE991AB-A59F-4210-A732-01B15FE88FFC" }
                );

            #region Seed users
            string password = new PasswordHasher().HashPassword("password");

            context.Users.AddOrUpdate(
                p => p.Email,
                new AppUser
                {
                    Id = "00000000-0000-0000-0000-000000000000",
                    Email = "system@QANote",
                    DateCreated = DateTime.Now,
                    UserName = "system@QANote",
                    SecurityStamp = "AC280409-EAC7-4293-9790-4632C5AC32DF".ToString(),
                    PasswordHash = password,
                },
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
