using Application.DTOs.BookDto;
using Application.Repositories.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Book.Queries.GetById
{
    public class GetByIdBookQueryHandler : IRequestHandler<GetByIdBookQueryRequest, GetByIdBookQueryResponse>
    {
        readonly IBookReadRepository _bookReadRepository;

        public GetByIdBookQueryHandler(IBookReadRepository bookReadRepository)
        {
            _bookReadRepository = bookReadRepository;
        }

        async Task<GetByIdBookQueryResponse> IRequestHandler<GetByIdBookQueryRequest, GetByIdBookQueryResponse>.Handle(GetByIdBookQueryRequest request, CancellationToken cancellationToken)
        {
            bool result = await _bookReadRepository.AnyAsync(data => data.Id == request.Id,false);
            if (result)
            {
                var book = await _bookReadRepository.GetByIdAsync(request.Id,false);
                QueryBookDto queryBookDto =new();
                queryBookDto.Author = new()
                {
                    Id = book.AuthorId,
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
