using Application.DTOs.BookDto;
using Application.Repositories.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Book.Queries.GetWhere
{
    public class GetWhereBookQueryHandler : IRequestHandler<GetWhereBookQueryRequest, GetWhereBookQueryResponse>
    {
        readonly IBookReadRepository _bookReadRepository;
        public GetWhereBookQueryHandler(IBookReadRepository bookReadRepository)
        {
            _bookReadRepository = bookReadRepository;
        }
        async Task<GetWhereBookQueryResponse> IRequestHandler<GetWhereBookQueryRequest, GetWhereBookQueryResponse>.Handle(GetWhereBookQueryRequest request, CancellationToken cancellationToken)
        {
            bool result = await _bookReadRepository.AnyAsync(data => data.Id == request.Id,false);
            if (result)
            {
                var book = _bookReadRepository.GetWhere(data => data.Id == request.Id,false);
                return new()
                {
                    BookDto = book
                };
                
            }
            throw new Exception("Hata");
        }
    }
}
