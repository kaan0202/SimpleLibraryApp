﻿using Application.Repositories.Employee;
using Persistance.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityFramework.Repositories.Employee
{
    public class EmployeeReadRepository : ReadRepository<Domain.Entities.Employee>,IEmployeeReadRepository
    {
        public EmployeeReadRepository(LibraryDbContext context) : base(context)
        {
        }
    }
}
