using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Person.Commands.Add
{
    public class AddPersonCommandRequest:IRequest<BaseResponse>
    {
        public Domain.Entities.Person Person { get; set; }
    }
}
