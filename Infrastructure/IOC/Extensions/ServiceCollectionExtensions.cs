using Application.Identity;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Application.Services;  
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IOC.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped<ICustomerRepository, CustomerRepository>();


        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<ICustomerService, CustomerService>()
                .AddScoped<IPasswordHasherService, PasswordHasherService>();

        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }
    } 
    
}
