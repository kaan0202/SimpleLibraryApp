using Application.DTOs.BookDto;
using Application.Repositories.Book;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Book.Queries.GetAll
{
    public class GetAllBookQueryHandler : IRequestHandler<GetAllBookQueryRequest, GetAllBookQueryResponse>
    {
        readonly IBookReadRepository _bookReadRepository;
         public GetAllBookQueryHandler(IBookReadRepository bookReadRepository)
          {
            _bookReadRepository = bookReadRepository;
          }

        public async Task<GetAllBookQueryResponse> Handle(GetAllBookQueryRequest request, CancellationToken cancellationToken)
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
                    
                    Name = book.Author.Name,
                    BirthDay = book.Author.BirthDay,
                    Surname = book.Author.Surname,


                };
                queryBookDto.Catalog = new()
                {
                    
                    CatalogName = book.Catalog.CatalogName,

                };
                queryBookDto.Language = new()
                {
                    
                    Name = book.Language.Name,
                };
                queryBookDtos.Add(queryBookDto);

            }

            return  new GetAllBookQueryResponse()
            {
                BookDtos = queryBookDtos
            };





        }
    }
}
