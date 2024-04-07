using Application.Repositories;
using Application.Repositories.Author;
using Microsoft.Extensions.DependencyInjection;
using Persistance.EntityFramework.Repositories.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public static class ServiceRegistration
    {
        public static void  ConfigurePersistanceExtensions(this IServiceCollection services)
        {
            services.AddScoped<IAuthorReadRepository,AuthorReadRepository>();
        }
    }
}
