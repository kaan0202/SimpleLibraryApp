using Application.DTOs.PersonDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Person.Queries.GetAll
{
    public class GetAllPersonQueryResponse
    {
        public List<QueryPersonDto> PersonDtos { get; set; }
    }
}
