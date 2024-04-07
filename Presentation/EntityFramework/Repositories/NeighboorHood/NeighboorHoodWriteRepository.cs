using Persistance.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityFramework.Repositories.NeighboorHood
{
    public class NeighboorHoodWriteRepository : WriteRepository<Domain.Entities.NeighboorHood>
    {
        public NeighboorHoodWriteRepository(LibraryDbContext context) : base(context)
        {
        }
    }
}
