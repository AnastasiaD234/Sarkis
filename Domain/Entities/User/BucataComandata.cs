using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.User
{
    public class BucataComandata
    {
        public int Id { get; set; }
        public int ReserTableId { get; set; }
        public ReserTable ReserTable { get; set; }

        public string Nume { get; set; }
        public decimal Pret { get; set; }
        public int Cantitate { get; set; }
    }
}
