using System;
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
        private QANotesContext db;

        // GET: Notes
        public ActionResult Index(QANotesContext db)
        {
            var viewModel = new NoteNoteTypesViewModel();
            viewModel.Notes = db.Note;
            return View(viewModel);
        }
    }
}