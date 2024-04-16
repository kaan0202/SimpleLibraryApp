using Domain.Results.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AuthorImageFile.Commands.Upload
{
    public class UploadAuthorImageFileCommandRequest:IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public IFormFileCollection Files { get; set; }
    }
}
