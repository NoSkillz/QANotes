using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QANotes.Models
{
    public class Note : IEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual int NoteTypeId { get; set; }
        public virtual string UserId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}