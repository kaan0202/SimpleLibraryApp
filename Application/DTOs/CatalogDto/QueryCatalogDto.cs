using Application.DTOs.BookDto;
using Application.DTOs.LanguageDto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.CatalogDto
{
    public class QueryCatalogDto
    {
        public int Id { get; set; }
        public string CatalogName { get; set; }

        
    }
}
