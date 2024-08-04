using FluentValidation;
using MotorcycleRental.Application.Requests;

namespace MotorcycleRental.Application.UseCases.CreateMotorcycle;

public class CreateMotorcycleValidation : AbstractValidator<CreateMotorcycleRequest>
{
}