using TDDSI.VERDURAS.BACKEND.Application.Messaging;

namespace TDDSI.VERDURAS.BACKEND.Application.Features.WeatherForecasts.Queries.WeatherForecastList;
public record WeatherForecastQuery(
) : IQuery<WeatherForecastResponse>;
