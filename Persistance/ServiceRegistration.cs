﻿using Application.Abstraction.Services;
using Application.Abstraction.Services.Authentication;
using Application.Repositories;
using Application.Repositories.Address;
using Application.Repositories.Author;
using Application.Repositories.AuthorImageFile;
using Application.Repositories.Basket;
using Application.Repositories.Book;
using Application.Repositories.BookImageFile;
using Application.Repositories.Catalog;
using Application.Repositories.Employee;
using Application.Repositories.Language;
using Application.Repositories.NeighboorHood;
using Application.Repositories.Person;
using Application.UnitOfWork;
using Domain.Entities.Identity;
using ETicaretAPI.Persistance.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistance.EntityFramework.Configurations;
using Persistance.EntityFramework.Contexts;
using Persistance.EntityFramework.Repositories.Address;
using Persistance.EntityFramework.Repositories.Author;
using Persistance.EntityFramework.Repositories.AuthorImageFile;
using Persistance.EntityFramework.Repositories.Basket;
using Persistance.EntityFramework.Repositories.Book;
using Persistance.EntityFramework.Repositories.BookImageFile;
using Persistance.EntityFramework.Repositories.Catalog;
using Persistance.EntityFramework.Repositories.Employee;
using Persistance.EntityFramework.Repositories.Language;
using Persistance.EntityFramework.Repositories.NeighboorHood;
using Persistance.EntityFramework.Repositories.Person;
using Persistance.EntityFramework.UnitOfWork;
using Persistance.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public static class ServiceRegistration
    {
        public static void  ConfigurePersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<LibraryDbContext>(options => options.UseNpgsql(ConnectionConfiguration.ConnectionString),ServiceLifetime.Singleton);
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<LibraryDbContext>();


            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IInternalAuthentication,AuthService>();
            services.AddScoped<IExternalAuthentication, AuthService>();


            services.AddScoped<IBookReadRepository, BookReadRepository>();
            services.AddScoped<IBookWriteRepository, BookWriteRepository>();

            services.AddScoped<IBookImageFileReadRepository,BookImageFileReadRepository>();
            services.AddScoped<IBookImageFileWriteRepository,BookImageFileWriteRepository>();

            services.AddScoped<IAuthorImageFileReadRepository, AuthorImageFileReadRepository>();
            services.AddScoped<IAuthorImageFileWriteRepository, AuthorImageFileWriteRepository>();

            services.AddScoped<IAuthorReadRepository,AuthorReadRepository>();
            services.AddScoped<IAuthorWriteRepository,AuthorWriteRepository>();
            
            services.AddScoped<IPersonWriteRepository,PersonWriteRepository>();
            services.AddScoped<IPersonReadRepository,PersonReadRepository>();

            services.AddScoped<INeighBoorHoodWriteRepository,NeighboorHoodWriteRepository>();
            services.AddScoped<INeighboorHoodReadRepository,NeighboorHoodReadRepository>();

            services.AddScoped<ICatalogReadRepository,CatalogReadRepository>();
            services.AddScoped<ICatalogWriteRepository,CatalogWriteRepository>();

            services.AddScoped<IBookWriteRepository,BookWriteRepository>();
            services.AddScoped<IBookReadRepository,BookReadRepository>();

            services.AddScoped<IBasketReadRepository,BasketReadRepository>();
            services.AddScoped<IBasketWriteRepository,BasketWriteRepository>();

            services.AddScoped<IAddressReadRepository,AddressReadRepository>();
            services.AddScoped<IAddressWriteRepository,AddressWriteRepository>();

            services.AddScoped<IEmployeeReadRepository,EmployeeReadRepository>();
            services.AddScoped<IEmployeeWriteRepository,EmployeeWriteRepository>();

            services.AddScoped<ILanguageReadRepository,LanguageReadRepository>();
            services.AddScoped<ILanguageWriteRepository,LanguageWriteRepository>();
        }
    }
}
