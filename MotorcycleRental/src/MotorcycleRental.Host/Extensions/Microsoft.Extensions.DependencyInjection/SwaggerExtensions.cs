using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Microsoft.Extensions.DependencyInjection;

public static class SwaggerExtensions
{
    public static void AddSwaggerService(this IServiceCollection services, IConfiguration configuration)
    {
        var swaggerConfiguration = configuration.GetSection("Swagger").Get<SwaggerConfiguration>();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = swaggerConfiguration.Title,
                    Description = swaggerConfiguration.Description,
                    Version = "v1"
                });
            c.ResolveConflictingActions(x => x.First());
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Bearer {token}",
                Name = "Authorization",
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
                 {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                 });
        });
    }

    public static void UseSwaggerService(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
            c.DocExpansion(DocExpansion.None);
        });
    }
}

public class SwaggerConfiguration
{
    public string Title { get; set; }
    public string Description { get; set; }
}