using Carter;
using MotorcycleRental.Application.Base.Shared;
using MotorcycleRental.Application.Interfaces.UseCases;
using MotorcycleRental.Application.Requests;
using MotorcycleRental.Application.Responses;

namespace MotorcycleRental.Api.Modules;

public class MotorcycleEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/Motorcycle", async (ICreateMotorcycleUseCase useCase, CreateMotorcycleRequest request, CancellationToken cancellation) =>
        {
            var result = await useCase.Handle(request, cancellation);
            return result.Match(
                response => Results.Ok(response),
                error => Results.BadRequest(error));
        })
        .WithTags("Motorcycle")
        .ConfigureRoute<CreateMotorcycleResponse, Error>(
            StatusCodes.Status200OK,
            StatusCodes.Status400BadRequest,
            requireAuthorization: false);
    }
}