using MotorcycleRental.Application.Base;
using MotorcycleRental.Application.Base.Shared;
using MotorcycleRental.Application.Interfaces.UseCases;
using MotorcycleRental.Application.Requests;
using MotorcycleRental.Application.Responses;

namespace MotorcycleRental.Application.UseCases.CreateMotorcycle;

public class CreateMotorcycleUseCase : UseCaseBase, ICreateMotorcycleUseCase
{
    public Task<Result<CreateMotorcycleResponse, Error>> Handle(CreateMotorcycleRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}