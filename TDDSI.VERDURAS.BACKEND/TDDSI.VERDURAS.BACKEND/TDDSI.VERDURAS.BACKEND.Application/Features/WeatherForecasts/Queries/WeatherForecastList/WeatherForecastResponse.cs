using TDDSI.VERDURAS.BACKEND.Domain.WeatherForecasts.Dtos;

namespace TDDSI.VERDURAS.BACKEND.Application.Features.WeatherForecasts.Queries.WeatherForecastList;
public record WeatherForecastResponse(
    IEnumerable<WeatherForecastDto> WeatherForecasts
);
