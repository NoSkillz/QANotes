using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QANotes.Models
{
    public class RegisterModel
    {
        [Index("Email", IsUnique = true)]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Repeat password")]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        public string RepeatPassword { get; set; }

        [HiddenInput]
        public DateTime DateCreated { get; set; }
    }
}