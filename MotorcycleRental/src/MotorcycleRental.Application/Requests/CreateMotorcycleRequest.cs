namespace MotorcycleRental.Application.Requests;

public class CreateMotorcycleRequest
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Year { get; set; }
    public string Plate { get; set; }
}