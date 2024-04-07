using Application.DTOs.PersonDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Person.Queries.GetWhere
{
    public class GetWherePersonQueryResponse
    {
        public IQueryable<Domain.Entities.Person> PersonDto { get; set; }
    }
}
