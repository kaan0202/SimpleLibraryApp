using Application.DTOs.LanguageDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Language.Queries.GetAll
{
    public class GetAllLanguageQueryResponse
    {
        public List<QueryLanguageDto> LanguageDtos { get; set; }
    }
}
