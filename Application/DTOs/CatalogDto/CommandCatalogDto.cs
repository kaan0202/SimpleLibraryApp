using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.CatalogDto
{
    public class CommandCatalogDto
    {
        public int Id { get; set; }
        public string CatalogName { get; set; }
        public int LanguageId { get; set; }
    }
}
