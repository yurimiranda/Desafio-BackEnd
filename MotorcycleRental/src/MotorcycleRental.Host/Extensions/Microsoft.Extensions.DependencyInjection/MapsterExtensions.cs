using Mapster;

namespace Microsoft.Extensions.DependencyInjection;

public static class MapsterExtensions
{
    public static IServiceCollection AddMapsterService(this IServiceCollection services)
    {
        services.AddMapster();
        return services;
    }
}