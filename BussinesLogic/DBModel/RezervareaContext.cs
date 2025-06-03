using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.DBModel
{
     public class RezervareaContext : DbContext
     {
          public RezervareaContext() : base("name=Sarkis")
          {
          }

          public virtual DbSet<RezerTable> RezerTable { get; set; }
     }
}
