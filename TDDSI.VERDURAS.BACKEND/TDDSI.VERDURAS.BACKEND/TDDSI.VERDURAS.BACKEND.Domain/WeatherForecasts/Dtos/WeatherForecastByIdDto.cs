using TDDSI.VERDURAS.BACKEND.Domain.Primitives;

namespace TDDSI.VERDURAS.BACKEND.Domain.WeatherForecasts.Dtos;
public class WeatherForecastByIdDto {
    public Guid Id { get; set; }
    public DateOnly Date { get; set; }
    public int TemperatureC { get; set; }
    public string? Summary { get; set; }
    public Temperature Temperature { get; set; }
}
