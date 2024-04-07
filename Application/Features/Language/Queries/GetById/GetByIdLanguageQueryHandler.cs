using Application.DTOs.LanguageDto;
using Application.Repositories.Language;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Language.Queries.GetById
{
    public class GetByIdLanguageQueryHandler : IRequestHandler<GetByIdLanguageQueryRequest, GetByIdLanguageQueryResponse>
    {
        readonly ILanguageReadRepository _languageReadRepository;

        public GetByIdLanguageQueryHandler(ILanguageReadRepository languageReadRepository)
        {
            _languageReadRepository = languageReadRepository;
        }

        async Task<GetByIdLanguageQueryResponse> IRequestHandler<GetByIdLanguageQueryRequest, GetByIdLanguageQueryResponse>.Handle(GetByIdLanguageQueryRequest request, CancellationToken cancellationToken)
        {
            bool result = await _languageReadRepository.AnyAsync(data => data.Id == request.Id,false);
            if (result) 
            { 
                var language = await _languageReadRepository.GetByIdAsync(request.Id);
                QueryLanguageDto languageDto = new();
                languageDto.Id = request.Id;
                languageDto.Name=language.Name;

                return new()
                {
                    LanguageDto = languageDto
                };
            }
            throw new Exception("Hata");
        }
    }
}
