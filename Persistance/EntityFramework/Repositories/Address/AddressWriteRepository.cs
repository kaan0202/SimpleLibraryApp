using Persistance.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityFramework.Repositories.Address
{
    public class AddressWriteRepository : WriteRepository<Domain.Entities.Address>
    {
        public AddressWriteRepository(LibraryDbContext context) : base(context)
        {
        }
    }
}
