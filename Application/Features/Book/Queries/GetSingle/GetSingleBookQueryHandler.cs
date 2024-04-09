using Application.DTOs.BookDto;
using Application.Exceptions;
using Application.Repositories.Book;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Book.Queries.GetSingle
{
    public class GetSingleBookQueryHandler : IRequestHandler<GetSingleBookQueryRequest, BaseDataResponse<QueryBookDto>>
    {
        readonly IBookReadRepository _bookReadRepository;

        public GetSingleBookQueryHandler(IBookReadRepository bookReadRepository)
        {
            _bookReadRepository = bookReadRepository;
        }

        public async Task<BaseDataResponse<QueryBookDto>> Handle(GetSingleBookQueryRequest request, CancellationToken cancellationToken)
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
                    
                    CatalogName = book.Catalog.CatalogName,


                };


               return new SuccessDataResponse<QueryBookDto>(queryBookDto);
            }
            throw new NotFoundException("Hata");
        }
    }
}
