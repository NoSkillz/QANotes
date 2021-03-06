﻿using System;
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
                NoteTypes = types.Where(p => p.UserId == userId),
            };

            return View(viewModel);
        }

        // GET /Notes/Edit/5
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var note = notes.Where(p => p.Id == Id).FirstOrDefault();

            if (note == null || note.UserId != User.Identity.GetUserId() )
            {
                throw new HttpException("Requested note not found.");
            }

            // create a viewmodel so the user has some dropdown lists
            var viewModel = new EditNoteViewModel
            {
                Note = note,
                SelectedType = note.NoteTypeId,
                Types = types.GetAll().Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name,
                    Selected = (note.NoteTypeId == x.Id)
                })
            };

            return PartialView("_Edit", viewModel);
        }

        // POST /Notes/Edit/5
        [HttpPost]
        public ActionResult Edit(EditNoteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            notes.Update(model.Note);

            notes.SaveChanges();

            notes.Dispose();

            return RedirectToAction("Index");
        }
    }
}