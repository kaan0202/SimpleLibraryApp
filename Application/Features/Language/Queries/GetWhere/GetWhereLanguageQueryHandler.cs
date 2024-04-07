using Application.Repositories.Language;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Language.Queries.GetWhere
{
    public class GetWhereLanguageQueryHandler : IRequestHandler<GetWhereLanguageQueryRequest, GetWhereLanguageQueryResponse>
    {
        readonly ILanguageReadRepository _languageReadRepository;

        public GetWhereLanguageQueryHandler(ILanguageReadRepository languageReadRepository)
        {
            _languageReadRepository = languageReadRepository;
        }

        async Task<GetWhereLanguageQueryResponse> IRequestHandler<GetWhereLanguageQueryRequest, GetWhereLanguageQueryResponse>.Handle(GetWhereLanguageQueryRequest request, CancellationToken cancellationToken)
        {
            bool result = await _languageReadRepository.AnyAsync(data => data.Id == request.Id, false);
            if (result)
            {
                var language = _languageReadRepository.GetWhere(data => data.Id == request.Id, false);
                return new()
                {
                    Language = language
                };
            }
            throw new Exception("Hata");
        }
    }
}
