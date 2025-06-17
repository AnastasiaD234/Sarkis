using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sarkis.Models
{
    public class ContactModel
    {
        [Required(ErrorMessage = "Numele este obligatoriu")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Emailul este obligatoriu")]
        [EmailAddress(ErrorMessage = "Email invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Subiectul este obligatoriu")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Mesajul este obligatoriu")]
        public string Message { get; set; }
    }
}