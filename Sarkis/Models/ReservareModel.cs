using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sarkis.Models
{
    public class ReservareModel
    {
        [Required(ErrorMessage = "Data evenimentului este obligatorie")]
        [DataType(DataType.Date)]
        [Display(Name = "Data evenimentului")]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Ora evenimentului este obligatorie")]
        [DataType(DataType.Time)]
        [Display(Name = "Ora evenimentului")]
        public TimeSpan EventTime { get; set; }

        [Required(ErrorMessage = "Numărul de persoane este obligatoriu")]
        [Range(1, 1000, ErrorMessage = "Trebuie să alegi cel puțin 1 persoană")]
        [Display(Name = "Număr persoane")]
        public int NumPersons { get; set; }

        [Required(ErrorMessage = "Tipul evenimentului este obligatoriu")]
        [Display(Name = "Tipul evenimentului")]
        public string EventType { get; set; }

        [Required(ErrorMessage = "Numărul de telefon este obligatoriu")]
        [Phone(ErrorMessage = "Număr de telefon invalid")]
        [Display(Name = "Număr de telefon")]
        public string PhoneNumber { get; set; }
        public List<BucataComandata> BucateComandate { get; set; }
    }
   
}