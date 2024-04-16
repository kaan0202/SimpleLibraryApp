using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.File
{
    public class BookImageFile:File
    {
        public int BookId { get; set; }
        public Book? Book { get; set; }
    }
}
