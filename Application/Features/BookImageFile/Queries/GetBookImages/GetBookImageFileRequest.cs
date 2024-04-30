using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BookImageFile.Queries.GetBookImages
{
    public class GetBookImageFileRequest:IRequest<BaseDataResponse<List<Domain.Entities.File.BookImageFile>>>
    {
        public int Id { get; set; }
    }
}
