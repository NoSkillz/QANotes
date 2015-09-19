using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QANotes.Models;
using QANotes.DataAccess;
using System.Data.Entity;

namespace QANotes.Controllers
{
    public class NotesController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private Repository<Note> notes;
        private Repository<NoteType> types;


        public NotesController()
        {
            notes = new Repository<Note>();
            types = new Repository<NoteType>();
        }

        // GET: Notes
        public ActionResult Index(QANotesContext db)
        {
            var user = "a26b4b32-c487-48ed-8474-915521ee920a";

            var viewModel = new NotesViewModel
            {
                Notes = notes.Where(p => p.UserId == user),
                NoteTypes = types.Where(p => p.UserId == user)
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult SubmitNote(object data)
        {
            NotesViewModel viewModel = data.UnJsonify();

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            foreach (var note in viewModel.Notes)
            {
                notes.Update(note);
            }

            notes.SaveChanges();

            foreach (var type in viewModel.NoteTypes)
            {
                types.Update(type);
            }

            types.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}