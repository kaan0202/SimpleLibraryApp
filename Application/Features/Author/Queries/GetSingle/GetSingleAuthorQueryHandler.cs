using Application.DTOs.AuthorDto;
using Application.Repositories.Author;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Author.Queries.Single
{
    public class GetSingleAuthorQueryHandler : IRequestHandler<GetSingleAuthorQueryRequest, GetSingleAuthorQueryResponse>
    {
        readonly IAuthorReadRepository _authorReadRepository;
        public GetSingleAuthorQueryHandler(IAuthorReadRepository authorReadRepository)
        {
            _authorReadRepository = authorReadRepository;
        }
        async Task<GetSingleAuthorQueryResponse> IRequestHandler<GetSingleAuthorQueryRequest, GetSingleAuthorQueryResponse>.Handle(GetSingleAuthorQueryRequest request, CancellationToken cancellationToken)
        {
            bool result = await _authorReadRepository.AnyAsync(data => data.Id == request.Id, false);
            if (result)
            {
                var author = await _authorReadRepository.GetSingleAsync(data => data.Id == request.Id, false);
                QueryAuthorDto authorDto = new();
                authorDto.Id = request.Id;
                authorDto.BirthDay = author.BirthDay;
                authorDto.Surname = author.Surname;
                authorDto.Name = author.Name;
                
                return new() { AuthorDto = authorDto };
            }
            throw new Exception("Hata");
        }
    }
}
