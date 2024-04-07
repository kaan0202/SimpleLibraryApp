﻿using Application.DTOs.PersonDto;
using Application.Repositories.Person;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Person.Queries.GetById
{
    public class GetByIdPersonQueryHandler : IRequestHandler<GetByIdPersonQueryRequest, GetByIdPersonQueryResponse>
    {
        readonly IPersonReadRepository _personReadRepository;

        public GetByIdPersonQueryHandler(IPersonReadRepository personReadRepository)
        {
            _personReadRepository = personReadRepository;
        }

        async Task<GetByIdPersonQueryResponse> IRequestHandler<GetByIdPersonQueryRequest, GetByIdPersonQueryResponse>.Handle(GetByIdPersonQueryRequest request, CancellationToken cancellationToken)
        {
            bool result = await _personReadRepository.AnyAsync(data => data.Id == request.Id,false);
            if (result)
            {
                var person = await _personReadRepository.GetByIdAsync(request.Id);
                QueryPersonDto personDto = new QueryPersonDto();
                personDto.AddressDto = new()
                {
                    AddressTitle = person.Address.AddressTitle,
                    Description = person.Address.Description,
                    Id = person.Address.Id,
                    NeighboorHood = new()
                    {
                        
                        Name = person.Address.NeighboorHood.Name
                    },
                    OpenAddress = person.Address.OpenAddress,
                    PhoneNumber = person.Address.PhoneNumber,

                };
                return new()
                {
                    PersonDto = personDto
                };
            }
            throw new Exception("Hata");
        }
    }
}
