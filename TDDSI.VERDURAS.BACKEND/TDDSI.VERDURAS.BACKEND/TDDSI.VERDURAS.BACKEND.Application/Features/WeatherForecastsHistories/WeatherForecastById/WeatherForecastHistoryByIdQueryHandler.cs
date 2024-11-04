using TDDSI.VERDURAS.BACKEND.Application.Messaging;
using TDDSI.VERDURAS.BACKEND.Domain.Abstractions;
using TDDSI.VERDURAS.BACKEND.Domain.Ports;
using TDDSI.VERDURAS.BACKEND.Domain.WeatherForecasts.Dtos;
using TDDSI.VERDURAS.BACKEND.Domain.WeatherForecastsHistories;

namespace TDDSI.VERDURAS.BACKEND.Application.Features.WeatherForecastsHistories.WeatherForecastById;
internal sealed record class WeatherForecastHistoryByIdQueryHandler(
          WeatherForecastsHistoryService WeatherForecastsHistoryService
        , IJsonConfiguration JsonConfiguration
    ) : IQueryHandler<WeatherForecastHistoryByIdQuery, WeatherForecastHistoryByIdQueryResponse> {

    public async Task<Result<WeatherForecastHistoryByIdQueryResponse>> Handle(
          WeatherForecastHistoryByIdQuery request
        , CancellationToken cancellationToken
    ) {
        var history = await WeatherForecastsHistoryService.GetByAsync(
              request.Id
            , cancellationToken
        );

        var result = new WeatherForecastHistoryByIdQueryResponse(
            history.Id
            , JsonConfiguration.DeserializeObject<WeatherForecastByIdDto>( history.Proccess! )
            , history.CreatedDate
            , history.CreatedByUser
            , history.LastModifiedDate
            , history.LastModifiedByUser
        );

        return result;
    }
}
