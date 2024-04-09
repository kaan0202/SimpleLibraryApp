using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Book.Commands.Update
{
    public class UpdateBookCommandRequest:IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public int BasketId { get; set; }
        public int CatalogId { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public int PageOfNumber { get; set; }
    }
}
