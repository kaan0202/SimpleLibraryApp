﻿using Persistance.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityFramework.Repositories.Basket
{
    public class BasketWriteRepository : WriteRepository<Domain.Entities.Basket>
    {
        public BasketWriteRepository(LibraryDbContext context) : base(context)
        {
        }
    }
}
