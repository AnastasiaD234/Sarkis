using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sarkis.Models
{
     public class RezervareSimplaModel
     {
               public string TipBanchet { get; set; }
               public int NrPersoane { get; set; }
               public DateTime DataRezervare { get; set; }
               public TimeSpan OraRezervare { get; set; }
               public string NrTelefon { get; set; }

     }
}