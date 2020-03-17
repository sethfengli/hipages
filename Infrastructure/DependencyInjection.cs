using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Pomelo.EntityFrameworkCore.MySql;
using Application.EmailService;
namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            return services;
        }
    }
}
