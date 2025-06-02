using Domain.Entities;
using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.DBModel
{
  public class ReservareContext: DbContext
    {
        public ReservareContext() : base("name=Sarkis")
        {
        }

        public virtual DbSet<ReserTable> ReserTable { get; set; }
    }
}
