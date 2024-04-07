using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Person.Commands.Update
{
    public class UpdatePersonCommandRequest : IRequest<UpdatePersonCommandResponse>
    {
        public Domain.Entities.Person Person { get; set; }
    }
}
