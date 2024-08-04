using MotorcycleRental.Application.Base.Shared;
using MotorcycleRental.Application.Requests;
using MotorcycleRental.Application.Responses;

namespace MotorcycleRental.Application.Interfaces.UseCases;

public interface ICreateMotorcycleUseCase
{
    Task<Result<CreateMotorcycleResponse, Error>> Handle(CreateMotorcycleRequest request, CancellationToken cancellationToken);
}