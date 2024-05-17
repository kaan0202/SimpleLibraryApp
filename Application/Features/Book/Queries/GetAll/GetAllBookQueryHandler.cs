using Application.DTOs.BookDto;
using Application.Repositories.Book;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Book.Queries.GetAll
{
    public class GetAllBookQueryHandler : IRequestHandler<GetAllBookQueryRequest, BaseDataResponse<List<QueryBookDto>>>
    {
        readonly IBookReadRepository _bookReadRepository;
         public GetAllBookQueryHandler(IBookReadRepository bookReadRepository)
          {
            _bookReadRepository = bookReadRepository;
          }

        public async Task<BaseDataResponse<List<QueryBookDto>>> Handle(GetAllBookQueryRequest request, CancellationToken cancellationToken)
        {
            var books =  await _bookReadRepository.Table.Include(x => x.Author).Include(x => x.Catalog).Include(x => x.Language).ToListAsync();

            List<QueryBookDto> queryBookDtos = new();
            foreach (var book in books)
            {
                QueryBookDto queryBookDto = new();
                queryBookDto.Id  = book.Id;
                queryBookDto.PageOfNumber = book.PageOfNumber;
                queryBookDto.Name = book.Name;
                queryBookDto.Author = new()
                {
                    Id = book.Author.Id,
                    Name = book.Author.Name,
                    BirthDay = book.Author.BirthDay,
                    Surname = book.Author.Surname,


                };
                queryBookDto.Catalog = new()
                {
                    Id = book.Catalog.Id,
                    CatalogName = book.Catalog.CatalogName,

                };
                queryBookDto.Language = new()
                {
                    Id = book.Language.Id,
                    Name = book.Language.Name,
                };
                queryBookDtos.Add(queryBookDto);

            }

           return new SuccessDataResponse<List<QueryBookDto>>(queryBookDtos);





        }
    }
}
