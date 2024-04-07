using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Basket:BaseEntity
    {
        public int PersonId { get; set; }

        public Person Person { get; set; }
        public List<Book> Books {  get; set; }
    }
}
