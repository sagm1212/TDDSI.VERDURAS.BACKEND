using TDDSI.VERDURAS.BACKEND.Application.Messaging;

namespace TDDSI.VERDURAS.BACKEND.Application.Features.WeatherForecasts.Commands.CreateWeatherForecasts;
public record CreateWeatherForecastsCommand(
    ) : ICommand<CreateWeatherForecastsResponse>;
