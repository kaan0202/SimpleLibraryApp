using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AuthorImageFile.Commands.Remove
{
    public class RemoveAuthorImageFileCommandRequest:IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public int ImageId { get; set; }
    }
}
