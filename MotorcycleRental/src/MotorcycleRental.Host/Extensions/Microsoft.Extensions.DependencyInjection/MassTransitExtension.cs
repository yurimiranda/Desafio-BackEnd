using MassTransit;

namespace Microsoft.Extensions.DependencyInjection;

internal static class MassTransitExtension
{
    internal static void AddMassTransitService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(bus =>
        {
            bus.AddConsumers(typeof(Program).Assembly);
            bus.UsingRabbitMq((ctx, busConfigurator) =>
            {
                busConfigurator.Host(configuration.GetConnectionString("RabbitMq"));
                busConfigurator.ConfigureEndpoints(ctx);
            });
        });

        services.Configure<MassTransitHostOptions>(options =>
        {
            options.WaitUntilStarted = true;
            options.StartTimeout = TimeSpan.FromSeconds(30);
            options.StopTimeout = TimeSpan.FromMinutes(1);
        });

        var formatter = new KebabCaseEndpointNameFormatter("rental", false);
        services.AddSingleton<IEndpointNameFormatter>(formatter);
    }
}