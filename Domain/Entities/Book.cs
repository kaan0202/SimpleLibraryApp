using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Book:BaseEntity
    {
        public int? LanguageId { get; set; }
      
        public int? CatalogId { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public int PageOfNumber { get; set; }
        public DateTime? DeletedDate { get; set; }
       
        public Catalog? Catalog { get; set; }
        public Author? Author { get; set; }
        public Language? Language { get; set; }
        [NotMapped]
        public DateTime? UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }

    }
}
