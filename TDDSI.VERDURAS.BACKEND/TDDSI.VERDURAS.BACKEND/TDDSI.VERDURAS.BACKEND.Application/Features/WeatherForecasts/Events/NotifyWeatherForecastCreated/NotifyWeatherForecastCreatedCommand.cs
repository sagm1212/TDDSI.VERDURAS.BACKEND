using TDDSI.VERDURAS.BACKEND.Application.Messaging;

namespace TDDSI.VERDURAS.BACKEND.Application.Features.WeatherForecasts.Events.NotifyWeatherForecastCreated;
public record NotifyWeatherForecastCreatedCommand(
    string Proccess
) : INotify;
