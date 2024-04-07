using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Author.Commands.Delete
{
    public class DeleteAuthorCommandRequest:IRequest<DeleteAuthorCommandResponse>   
    {
        public int Id { get; set; }
    }
}
