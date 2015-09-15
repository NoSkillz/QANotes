using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QANotes.Models
{
    public class NoteNoteTypesViewModel
    {
        public IEnumerable<Note> Notes { get; set; }
        public IEnumerable<NoteType> NoteTypes { get; set; }
        public IEnumerable<CustomNoteType> CustomNoteTypes { get; set; }
    }
}