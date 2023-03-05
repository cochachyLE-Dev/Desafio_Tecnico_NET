﻿using API.Domain.Entities;
using API.Persistence;
using API.Service.Contract;
using API.Service.Implementation;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Infrastructure.Extension
{
    public static class ConfigureServiceContainer
    {
        public static void AddDbContext(this IServiceCollection serviceCollection, IConfiguration configuration)
        {            
            serviceCollection.AddDbContext<ApplicationDbContext>
                (options => options.UseInMemoryDatabase("ApplicationDb"));
        }
        public static void AddScopedService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped((Func<IServiceProvider, IApplicationDbContext>)(provider =>
            {
                ApplicationDbContext? applicationDbContext = provider.GetService<ApplicationDbContext>();
                return applicationDbContext!;
            }));

            serviceCollection.AddHttpContextAccessor();
            serviceCollection.AddScoped<ICurrentUserService, CurrentUserService>();
        }
        public static void AddTransientServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IAccountService, IAccountService>();
        }
        public static void AddSwaggerOpenAPI(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen(setup =>
            {
                setup.SwaggerDoc(
                    "OpenAPISpecification",
                    new OpenApiInfo()
                    {
                        Title = "Desafío Técnico .NET WebAPI",
                        Version = "1",
                        Description = "...",
                        Contact = new OpenApiContact()
                        {
                            Email = "luis.cochachi@vaetech.net",
                            Name = "LUIS EDUARDO COCHACHI CHAMORRO",
                            Url = new Uri("https://vaetech.net/")
                        }                        
                    });

                setup.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = $"Input your Bearer token in this format - Bearer token to access this API",
                });
                setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                        }, new List<string>()
                    },
                });
            });      
        }
        
    }
}
