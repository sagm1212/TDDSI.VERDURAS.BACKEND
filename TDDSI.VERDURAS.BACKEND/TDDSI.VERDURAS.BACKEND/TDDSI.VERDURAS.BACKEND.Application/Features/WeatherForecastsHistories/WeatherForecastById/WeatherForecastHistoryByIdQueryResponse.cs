using TDDSI.VERDURAS.BACKEND.Domain.WeatherForecasts.Dtos;

namespace TDDSI.VERDURAS.BACKEND.Application.Features.WeatherForecastsHistories.WeatherForecastById;
public record WeatherForecastHistoryByIdQueryResponse(
      Guid Id
    , WeatherForecastByIdDto? Proccess
    , DateOnly? CreatedDate
    , string? CreatedByUser
    , DateOnly? LastModifiedDate
    , string? LastModifiedByUser
);
