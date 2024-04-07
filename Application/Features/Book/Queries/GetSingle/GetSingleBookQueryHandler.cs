using Application.DTOs.BookDto;
using Application.Repositories.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Book.Queries.GetSingle
{
    public class GetSingleBookQueryHandler : IRequestHandler<GetSingleBookQueryRequest, GetSingleBookQueryResponse>
    {
        readonly IBookReadRepository _bookReadRepository;

        public GetSingleBookQueryHandler(IBookReadRepository bookReadRepository)
        {
            _bookReadRepository = bookReadRepository;
        }

        async Task<GetSingleBookQueryResponse> IRequestHandler<GetSingleBookQueryRequest, GetSingleBookQueryResponse>.Handle(GetSingleBookQueryRequest request, CancellationToken cancellationToken)
        {
            bool result = await _bookReadRepository.AnyAsync(data => data.Id == request.Id);
            if (result) 
            {
                var book = await _bookReadRepository.GetSingleAsync(data => data.Id == request.Id,false);
                QueryBookDto queryBookDto = new();
                queryBookDto.Author = new()
                {
                    Id = book.Id,
                    BirthDay = book.Author.BirthDay,
                    Name = book.Author.Name,
                    Surname = book.Author.Surname

                };
                queryBookDto.Catalog = new()
                {
                    Id = book.CatalogId,
                    CatalogName = book.Catalog.CatalogName,


                };


                return new()
                {
                    BookDto = queryBookDto
                };
            }
            throw new Exception("Hata");
        }
    }
}
