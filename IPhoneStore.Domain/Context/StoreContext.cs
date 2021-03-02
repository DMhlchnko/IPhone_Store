using IPhoneStore.Domain.Context;
using IPhoneStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPhoneStore.Domain
{
    public class StoreContext : DbContext
    {
        static StoreContext()
        {
            Database.SetInitializer(new DbtInitializer());
            
        }
        public DbSet<IPhone> Phones { get; set; }
    }
}
