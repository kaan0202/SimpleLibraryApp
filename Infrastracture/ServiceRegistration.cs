using Application.Abstraction.Storage;
using Application.Token;
using Infrastracture.Services.Storage;
using Infrastracture.Services.Token;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture
{
    public static class ServiceRegistration
    {
        public static void ConfigureInfrastractureServices(this IServiceCollection services)
        {
            services.AddScoped<IStorageService, StorageService>();
            services.AddScoped<ITokenHandler,TokenHandler>();
        }

        public static void AddStorageService<T>(this IServiceCollection services) where T : class,IStorage
        {
            services.AddScoped<IStorage,T>();
        }
    }
}
