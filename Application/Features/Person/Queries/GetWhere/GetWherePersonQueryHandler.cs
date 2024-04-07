using Application.DTOs.PersonDto;
using Application.Repositories.Person;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Person.Queries.GetWhere
{
    public class GetWherePersonQueryHandler : IRequestHandler<GetWherePersonQueryRequest, GetWherePersonQueryResponse>
    {
        readonly IPersonReadRepository _personReadRepository;

        public GetWherePersonQueryHandler(IPersonReadRepository personReadRepository)
        {
            _personReadRepository = personReadRepository;
        }

        async Task<GetWherePersonQueryResponse> IRequestHandler<GetWherePersonQueryRequest, GetWherePersonQueryResponse>.Handle(GetWherePersonQueryRequest request, CancellationToken cancellationToken)
        {
            bool result = await _personReadRepository.AnyAsync(data => data.Id == request.Id, false);
            if (result)
            {
                var person =  _personReadRepository.GetWhere(data => data.Id == request.Id);
               
                return new()
                {
                    PersonDto = person
                };
            }
            throw new Exception("Hata");
        }
    }
}
