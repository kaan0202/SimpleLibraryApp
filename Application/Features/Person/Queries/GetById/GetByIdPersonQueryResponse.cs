using Application.DTOs.PersonDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Person.Queries.GetById
{
    public class GetByIdPersonQueryResponse
    {
        public QueryPersonDto PersonDto { get; set; }
    }
}
