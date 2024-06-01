using Application.DTOs.AuthorDto;
using Application.Repositories.Author;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Author.Queries.GetAll
{
    public class GetAllAuthorQueryHandler : IRequestHandler<GetAllAuthorQueryRequest, BaseDataResponse<List<QueryAuthorDto>>>
    {
        readonly IAuthorReadRepository _authorReadRepository;
        public GetAllAuthorQueryHandler(IAuthorReadRepository authorReadRepository)
        {
            _authorReadRepository = authorReadRepository;
        }
       public async Task<BaseDataResponse<List<QueryAuthorDto>>> Handle(GetAllAuthorQueryRequest request, CancellationToken cancellationToken)
        {

            var totalCount = _authorReadRepository.GetAll(false).Count();
            var authors = await _authorReadRepository.GetAll(false).Skip(request.Page * request.Size).Take(request.Size).ToListAsync();
            List<QueryAuthorDto> queryAuthorDtos = new();
            foreach (var author in authors)
            {
                QueryAuthorDto queryAuthorDto = new();
                queryAuthorDto.Surname = author.Surname;
                queryAuthorDto.Id = author.Id;
                queryAuthorDto.Name = author.Name;
                queryAuthorDto.BirthDay = author.BirthDay;
               


                queryAuthorDtos.Add(queryAuthorDto);
            }

            return new SuccessDataResponse<List<QueryAuthorDto>>(queryAuthorDtos, totalCount);
        }
           
        }
    }

