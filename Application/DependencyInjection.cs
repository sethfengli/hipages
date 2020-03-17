using AutoMapper;
using Application.Common.Behaviours;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Application.EmailService;
using Microsoft.AspNetCore.Http.Features;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            var emailSettings = configuration.GetSection("EmailSettings").Get<EmailSettings>();
            services.AddSingleton(emailSettings);
            services.AddScoped<IEmailSender, EmailSender>();

            //services.Configure<FormOptions>(o => {
            //    o.ValueLengthLimit = int.MaxValue;
            //    o.MultipartBodyLengthLimit = int.MaxValue;
            //    o.MemoryBufferThreshold = int.MaxValue;
            //});

            return services;
        }
    }
}
