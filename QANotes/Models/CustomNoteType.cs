﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QANotes.Models
{
    public class CustomNoteType : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual string UserId { get; set; }
    }
}