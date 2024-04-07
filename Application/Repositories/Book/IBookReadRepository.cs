using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.Book
{
    public interface IBookReadRepository:IReadRepository<Domain.Entities.Book>
    {
    }
}
