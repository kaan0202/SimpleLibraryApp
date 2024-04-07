using Application.DTOs.AuthorDto;
using Application.DTOs.CatalogDto;
using Application.DTOs.LanguageDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.BookDto
{
    public class QueryBookDto
    {
        public int Id { get; set; }
        public QueryLanguageDto Language { get; set; }
        public QueryCatalogDto Catalog { get; set; }
        public string Name { get; set; }
        public QueryAuthorDto Author { get; set; }
        public int PageOfNumber { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
