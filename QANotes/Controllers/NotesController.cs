﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QANotes.Models;
using QANotes.DataAccess;

namespace QANotes.Controllers
{
    public class NotesController : Controller
    {
        private NoteRepository noteRepo;

        public NotesController()
        {
            noteRepo = new NoteRepository(new QANotesContext());
        }

        // GET: Notes
        public ActionResult Index(QANotesContext db)
        {
            var currentuser = "a26b4b32-c487-48ed-8474-915521ee920a";


            //TODO FIX THIS SHIT

            //NoteNoteTypesViewModel viewModel = new NoteNoteTypesViewModel();
            //var user = db.Users.FirstOrDefault(p => p.Id == currentuser);
            //IEnumerable<Note> notes = (from u in db.Users
            //             join n in db.Note on u.Id equals n.UserId
            //             where u.Id == currentuser
            //             select new
            //             {
            //                 n.Id,
            //                 n.NoteTypeId,
            //                 n.UserId,
            //                 n.Description
            //             }) as IEnumerable<Note>;

            //var viewModel = new NotesUsersViewModel
            //{
            //    Notes = notes
            //};

            throw new NotImplementedException();

        }
    }
}