using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QANotes.Models
{
    public class EditNoteViewModel
    {
        public Note Note { get; set; }
        //public IEnumerable<NoteType> NoteTypes { get; set; }
        public int SelectedType { get; set; }
        public IEnumerable<SelectListItem> Types { get; set; }
    }
}