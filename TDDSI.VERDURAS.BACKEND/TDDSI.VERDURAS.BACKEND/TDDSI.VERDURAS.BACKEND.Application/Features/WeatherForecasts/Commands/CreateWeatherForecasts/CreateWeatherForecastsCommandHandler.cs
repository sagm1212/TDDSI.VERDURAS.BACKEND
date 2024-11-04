using TDDSI.VERDURAS.BACKEND.Application.Features.WeatherForecasts.Events.NotifyWeatherForecastCreated;
using TDDSI.VERDURAS.BACKEND.Application.Messaging;
using TDDSI.VERDURAS.BACKEND.Domain.Abstractions;
using TDDSI.VERDURAS.BACKEND.Domain.Ports;
using TDDSI.VERDURAS.BACKEND.Domain.WeatherForecasts;

namespace TDDSI.VERDURAS.BACKEND.Application.Features.WeatherForecasts.Commands.CreateWeatherForecasts;
internal sealed class CreateWeatherForecastsCommandHandler(
        IDispatch dispatch
        , IJsonConfiguration jsonConfiguration
        , WeatherForecastService forecastService
    ) : ICommandHandler<CreateWeatherForecastsCommand, CreateWeatherForecastsResponse> {

    public async Task<Result<CreateWeatherForecastsResponse>> Handle(
        CreateWeatherForecastsCommand request,
        CancellationToken cancellationToken
    ) {

        IEnumerable<WeatherForecast> weatherForecasts = await forecastService
            .GenerateForecastTimesAsync( cancellationToken );

        foreach (var forecast in weatherForecasts) {
            string serializer = jsonConfiguration.SerializeObject( forecast );
            await dispatch.Publish( new NotifyWeatherForecastCreatedCommand(
                serializer
            )
            , cancellationToken );
        }

        return new CreateWeatherForecastsResponse(
            weatherForecasts.Select( forecast => forecast.Id )
            .ToArray()
        );
    }
}
