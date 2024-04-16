using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AuthorImageFile.Queries.GetAuthorImages
{
    public class GetAuthorImageFileRequest:IRequest<BaseDataResponse<List<Domain.Entities.File.AuthorImageFile>>>
    {
        public int Id { get; set; }
    }
}
