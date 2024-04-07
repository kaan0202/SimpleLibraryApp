﻿using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Language:BaseEntity
    {
        
        public string Name { get; set; }
        public int CatalogId { get; set; }
        public ICollection<Book> Books { get; set; }
        public Catalog Catalog { get; set; }
    }
    }
