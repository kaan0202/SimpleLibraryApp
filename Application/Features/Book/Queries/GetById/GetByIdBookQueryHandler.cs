using Application.DTOs.BookDto;
using Application.Repositories.Book;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Book.Queries.GetById
{
    public class GetByIdBookQueryHandler : IRequestHandler<GetByIdBookQueryRequest, BaseDataResponse<QueryBookDto>>
    {
        readonly IBookReadRepository _bookReadRepository;

        public GetByIdBookQueryHandler(IBookReadRepository bookReadRepository)
        {
            _bookReadRepository = bookReadRepository;
        }

       public async Task<BaseDataResponse<QueryBookDto>> Handle(GetByIdBookQueryRequest request, CancellationToken cancellationToken)
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
                

               return new SuccessDataResponse<QueryBookDto>(queryBookDto);
            }
            throw new Exception("Hata");
        }
    }
}
