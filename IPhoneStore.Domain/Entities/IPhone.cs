using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPhoneStore.Domain.Entities
{
    public class IPhone
    {
        public int Id { get; set; }
     
        public string Description { get; set; }

        public int Store { get; set; }

        public string Color { get; set; }

        public string Model { get; set; }

        public int Price { get; set; }
    }
}
