using Application.DTOs.LanguageDto;
using Application.Repositories.Language;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Language.Queries.GetAll
{
    public class GetAllLanguageQueryHandler : IRequestHandler<GetAllLanguageQueryRequest, GetAllLanguageQueryResponse>
    {
        readonly ILanguageReadRepository _languageReadRepository;

        public GetAllLanguageQueryHandler(ILanguageReadRepository languageReadRepository)
        {
            _languageReadRepository = languageReadRepository;
        }

        async Task<GetAllLanguageQueryResponse> IRequestHandler<GetAllLanguageQueryRequest, GetAllLanguageQueryResponse>.Handle(GetAllLanguageQueryRequest request, CancellationToken cancellationToken)
        {
            var languages = await _languageReadRepository.GetAll().ToListAsync();
            List<QueryLanguageDto> queryLanguageDtos = new();
            foreach (var language in languages)
            {
                QueryLanguageDto queryLanguageDto = new();
                queryLanguageDto.Name = language.Name;
                queryLanguageDto.Id = language.Id;
                queryLanguageDtos.Add(queryLanguageDto);
            }
            return new()
            {
                LanguageDtos = queryLanguageDtos
            };
        }
        
    }
}
