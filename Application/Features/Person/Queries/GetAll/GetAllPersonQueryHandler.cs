using Application.DTOs.PersonDto;
using Application.Repositories.Person;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Person.Queries.GetAll
{
    public class GetAllPersonQueryHandler : IRequestHandler<GetAllPersonQueryRequest, BaseDataResponse<List<QueryPersonDto>>>
    {
        readonly IPersonReadRepository _personReadRepository;

        public GetAllPersonQueryHandler(IPersonReadRepository personReadRepository)
        {
            _personReadRepository = personReadRepository;
        }

        public async Task<BaseDataResponse<List<QueryPersonDto>>> Handle(GetAllPersonQueryRequest request, CancellationToken cancellationToken)
        {
            var persons = await _personReadRepository.GetAll().ToListAsync();
            List<QueryPersonDto> personDtos = new();
            foreach (var person in persons)
            {
                QueryPersonDto queryPersonDto = new();
                queryPersonDto.Surname = person.Surname;
                queryPersonDto.Name = person.Name;
                queryPersonDto.Password = person.Password;
                queryPersonDto.Email = person.Email;
                queryPersonDto.AddressDto = new()
                {
                    AddressTitle = person.Address.AddressTitle,
                    Description = person.Address.Description,
                    
                    OpenAddress = person.Address.OpenAddress,
                    PhoneNumber = person.Address.PhoneNumber,
                    NeighboorHood = new()
                    {
                        Name = person.Address.NeighboorHood.Name
                    },
                    
                };
                personDtos.Add(queryPersonDto);
                
            }
            return new SuccessDataResponse<List<QueryPersonDto>>(personDtos);


        }
    }
}

