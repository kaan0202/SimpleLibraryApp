using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.File
{
    public class AuthorImageFile:File
    {
        public int AuthorId { get; set; }

        public Author? Author { get; set; }
    }
}
