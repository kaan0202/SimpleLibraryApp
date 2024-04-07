using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Language.Commands.Update
{
    public class UpdateLanguageCommandRequest : IRequest<UpdateLanguageCommandResponse>
    {
        public Domain.Entities.Language Language { get; set; }
    }
}
