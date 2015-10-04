using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QANotes.Models;
using QANotes.DataAccess;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

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

        // GET /Notes/Index
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var viewModel = new NotesViewModel
            {
                Notes = notes.Where(p => p.UserId == userId),
                NoteTypes = types.Where(p => p.UserId == userId || p.Custom == false),
            };

            return View(viewModel);
        }

        // GET /Notes/Edit/5
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var model = notes.Where(p => p.Id == Id).FirstOrDefault();

            return PartialView("_Edit", model);
        }

        [HttpPost]
        public ActionResult Edit(Note model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            notes.Update(model);

            notes.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}