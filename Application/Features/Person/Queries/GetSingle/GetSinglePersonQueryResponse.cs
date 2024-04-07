using Application.DTOs.PersonDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Person.Queries.GetSingle
{
    public class GetSinglePersonQueryResponse 
    {
        public QueryPersonDto PersonDto { get; set; }
    }
}
