using Persistance.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityFramework.Repositories.Catalog
{
    public class CatalogReadRepository : ReadRepository<Domain.Entities.Catalog>
    {
        public CatalogReadRepository(LibraryDbContext context) : base(context)
        {
        }
    }
}
