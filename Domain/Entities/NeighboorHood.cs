using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class NeighboorHood:BaseEntity
    {
        
        public string Name { get; set; }
        public IList<Address> Addresses { get; set; }
    }
}
