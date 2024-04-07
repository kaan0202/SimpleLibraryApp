using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Author.Commands.Update
{
    public class UpdateAuthorCommandRequest:IRequest<UpdateAuthorCommandResponse>
    {
        public Domain.Entities.Author Author { get; set; }
    }
}
