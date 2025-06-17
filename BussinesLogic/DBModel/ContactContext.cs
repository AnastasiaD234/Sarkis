using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.DBModel
{
  public class ContactContext: DbContext
    {
     
            public ContactContext() : base("name=Sarkis")
            {
            }

            public virtual DbSet<ContactTable> ContactTable { get; set; }
        
    }
}
