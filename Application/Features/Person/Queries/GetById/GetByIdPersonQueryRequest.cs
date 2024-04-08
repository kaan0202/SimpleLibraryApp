using Application.DTOs.PersonDto;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Person.Queries.GetById
{
    public class GetByIdPersonQueryRequest:IRequest<BaseDataResponse<QueryPersonDto>>
    {
        public int Id { get; set; }
    }
}
