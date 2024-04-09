using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Catalog:BaseEntity
    {
        
        public string CatalogName { get; set; }
        public int? LanguageId { get; set; }



        public ICollection<Book>? Books { get; set; }
        public Language? Language { get; set; }
    }
}
