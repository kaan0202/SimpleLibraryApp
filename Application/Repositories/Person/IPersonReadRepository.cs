using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.Person
{
    public interface IPersonReadRepository:IReadRepository<Domain.Entities.Person>
    {
    }
}
