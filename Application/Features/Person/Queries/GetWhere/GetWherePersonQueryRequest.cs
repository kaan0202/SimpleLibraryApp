using Application.DTOs.PersonDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Person.Queries.GetWhere
{
    public class GetWherePersonQueryRequest:IRequest<GetWherePersonQueryResponse>
    {
        public int Id { get; set; }
    }
}
