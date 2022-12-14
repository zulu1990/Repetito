using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Repetito.Application.Common.Validator;
using System.Reflection;

namespace Repetito.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped(
            typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
        
    }
}
