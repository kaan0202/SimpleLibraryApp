using Application.DTOs.AuthorDto;
using Application.Repositories.Author;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Author.Queries.Single
{
    public class GetSingleAuthorQueryHandler : IRequestHandler<GetSingleAuthorQueryRequest, BaseDataResponse<QueryAuthorDto>>
    {
        readonly IAuthorReadRepository _authorReadRepository;
        public GetSingleAuthorQueryHandler(IAuthorReadRepository authorReadRepository)
        {
            _authorReadRepository = authorReadRepository;
        }
       public async Task<BaseDataResponse<QueryAuthorDto>> Handle(GetSingleAuthorQueryRequest request, CancellationToken cancellationToken)
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
                
                return new SuccessDataResponse<QueryAuthorDto>(authorDto);
            }
            throw new Exception("Hata");
        }
    }
}
