using Application.Repositories.NeighboorHood;
using Persistance.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityFramework.Repositories.NeighboorHood
{
    public class NeighboorHoodReadRepository : ReadRepository<Domain.Entities.NeighboorHood>,INeighboorHoodReadRepository
    {
        public NeighboorHoodReadRepository(LibraryDbContext context) : base(context)
        {
        }
    }
}
