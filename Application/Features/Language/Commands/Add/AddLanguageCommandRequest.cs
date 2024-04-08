using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Language.Commands.Add
{
    public class AddLanguageCommandRequest:IRequest<BaseResponse>
    {
        public Domain.Entities.Language Language { get; set; }
    }
}
