using Application.DTOs.AuthorDto;
using Application.Repositories.Author;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Author.Queries.GetAll
{
    public class GetAllAuthorQueryHandler : IRequestHandler<GetAllAuthorQueryRequest, GetAllAuthorQueryResponse>
    {
        readonly IAuthorReadRepository _authorReadRepository;
        public GetAllAuthorQueryHandler(IAuthorReadRepository authorReadRepository)
        {
            _authorReadRepository = authorReadRepository;
        }
        async Task<GetAllAuthorQueryResponse> IRequestHandler<GetAllAuthorQueryRequest, GetAllAuthorQueryResponse>.Handle(GetAllAuthorQueryRequest request, CancellationToken cancellationToken)
        {
            bool result = await _authorReadRepository.AnyAsync(data => data.Id == request.Id,false);
            if (result) 
            {
                var authors = await _authorReadRepository.GetAll(false).ToListAsync();

                List<QueryAuthorDto> authorDtos = new();
                foreach (var author in authors)
                {
                    QueryAuthorDto authorDto = new();
                    authorDto.Id = author.Id;
                    authorDto.Name = author.Name;
                    authorDto.BirthDay = author.BirthDay;
                    authorDto.Surname = author.Surname;
                    
                    
                    
                    authorDtos.Add(authorDto);
                }
                return new()
                {
                    AuthorDto = authorDtos
                };
            }
            throw new Exception("Hata");
        }
    }
}
