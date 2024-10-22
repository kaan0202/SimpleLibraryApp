using Application.DTOs.PersonDto;
using Application.Repositories.Person;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Person.Queries.GetNameById
{
    public class Handler : IRequestHandler<Request, BaseDataResponse<List<QueryPersonDto>>>
    {
        readonly private IPersonReadRepository _personReadRepository;

        public Handler(IPersonReadRepository personReadRepository)
        {
            _personReadRepository = personReadRepository;
        }

        public async Task<BaseDataResponse<List<QueryPersonDto>>> Handle(Request request, CancellationToken cancellationToken)
        {
            var persons= _personReadRepository.GetAll(false);
            List<QueryPersonDto> queryPersonDtos = new();
            foreach (var person in persons)
            {
                QueryPersonDto queryPersonDto = new();
                queryPersonDto.Id = person.Id;
                queryPersonDto.Name = $"{person.Name} {person.Surname}";
                queryPersonDtos.Add(queryPersonDto);
            }

            return new SuccessDataResponse<List<QueryPersonDto>>(queryPersonDtos);
        }
    }
}
