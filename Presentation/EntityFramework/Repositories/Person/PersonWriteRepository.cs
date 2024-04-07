using Persistance.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityFramework.Repositories.Person
{
    public class PersonWriteRepository : WriteRepository<Domain.Entities.Person>
    {
        public PersonWriteRepository(LibraryDbContext context) : base(context)
        {
        }
    }
}
