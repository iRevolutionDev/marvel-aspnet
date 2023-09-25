using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Marvel.Application.Common.Behaviours;
using Marvel.Application.Services;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Marvel.Application.Common;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
        });
        
        services.AddHttpClient<MarvelApiService>(client =>
        {
            client.BaseAddress = new Uri("http://gateway.marvel.com/v1/public/");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        });
        
        services.AddScoped<CharacterService>();
        
        return services;
    }
}