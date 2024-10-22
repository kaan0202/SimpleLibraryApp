using Application.DTOs.PersonDto;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Person.Queries.GetNameById
{
    public class Request : IRequest<BaseDataResponse<List<QueryPersonDto>>>
    {
    }
}
