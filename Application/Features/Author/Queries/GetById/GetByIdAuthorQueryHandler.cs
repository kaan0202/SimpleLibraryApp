using Application.DTOs.AuthorDto;
using Application.Repositories.Author;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Author.Queries.GetById
{
    public class GetByIdAuthorQueryHandler : IRequestHandler<GetByIdAuthorQueryRequest, GetByIdAuthorQueryResponse>
    {
        readonly IAuthorReadRepository _authorReadRepository;

        public GetByIdAuthorQueryHandler(IAuthorReadRepository authorReadRepository)
        {
            _authorReadRepository = authorReadRepository;
        }

        public async Task<GetByIdAuthorQueryResponse> Handle(GetByIdAuthorQueryRequest request, CancellationToken cancellationToken)
        {
            bool result = await _authorReadRepository.AnyAsync(data => data.Id == request.Id,false);
            if (result)
            {
                var author = await _authorReadRepository.GetByIdAsync(request.Id);
                QueryAuthorDto queryAuthorDto = new();
                queryAuthorDto.BirthDay = author.BirthDay;
                queryAuthorDto.Surname = author.Surname;
                queryAuthorDto.Name = author.Name;
                queryAuthorDto.Id = author.Id;
                

                return new()
                {
                    AuthorDto = queryAuthorDto
                };
            }
            throw new Exception("Hata");
        }
    }
}
