using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.User
{

     public class RezerTable
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int RezervationId { get; set; }

          [Required]
          [DataType(DataType.Date)]
          public DateTime DataRezervare { get; set; }

          [Required]
          [DataType(DataType.Time)]
          public TimeSpan OraRezervare { get; set; }

          [Required]
          [Range(1, int.MaxValue)]
          public int NrPersoane { get; set; }

          [Required]
          [StringLength(100)]
          public string TipBanchet { get; set; }

          [Required]
          [Phone]
          [StringLength(20)]
          public string NrTelefon { get; set; }
     }
}

