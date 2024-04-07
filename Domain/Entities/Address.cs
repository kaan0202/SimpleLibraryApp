using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class Address : BaseEntity
    {
        
        public int PersonId { get; set; }
        public string AddressTitle { get; set; }
        public string Description { get; set; }
        public string OpenAddress { get; set; }
        public string PhoneNumber { get; set; }
        public int NeighboorHoodId { get; set; }
        public Person Person { get; set; }
        public NeighboorHood NeighboorHood { get; set; }



    }
}
