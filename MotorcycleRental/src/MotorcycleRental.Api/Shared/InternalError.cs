namespace MotorcycleRental.Api.Shared;

public class InternalError
{
    public string TraceId { get; set; }
    public string Error { get; set; }
    public string InnerError { get; set; }
}