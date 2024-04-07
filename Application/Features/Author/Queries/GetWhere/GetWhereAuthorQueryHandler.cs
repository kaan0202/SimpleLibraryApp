using Application.DTOs.AuthorDto;
using Application.Repositories.Author;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Author.Queries.Where
{
    public class GetWhereAuthorQueryHandler : IRequestHandler<GetWhereAuthorQueryRequest, GetWhereAuthorQueryResponse>
    {
        readonly IAuthorReadRepository _authorReadRepository;

        public GetWhereAuthorQueryHandler(IAuthorReadRepository authorReadRepository)
        {
            _authorReadRepository = authorReadRepository;
        }

        async Task<GetWhereAuthorQueryResponse> IRequestHandler<GetWhereAuthorQueryRequest, GetWhereAuthorQueryResponse>.Handle(GetWhereAuthorQueryRequest request, CancellationToken cancellationToken)
        {
            bool result = await _authorReadRepository.AnyAsync(data => data.Id == request.Id, false);
            if (result)
            {
                var author =  _authorReadRepository.GetWhere(data => data.Id == request.Id,false);
                return new()
                {
                    AuthorDto = author
                };
                


            }
            throw new Exception("Hata");
        }
    }
}
