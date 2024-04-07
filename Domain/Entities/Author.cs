using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Author:BaseEntity
    {
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public string Surname { get; set; }
        public ICollection<Book> Books { get; set; }

       
        

    }
}
