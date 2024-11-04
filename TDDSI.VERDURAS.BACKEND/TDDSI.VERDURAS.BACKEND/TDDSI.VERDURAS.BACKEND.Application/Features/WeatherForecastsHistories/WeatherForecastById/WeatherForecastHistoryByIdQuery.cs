using TDDSI.VERDURAS.BACKEND.Application.Messaging;

namespace TDDSI.VERDURAS.BACKEND.Application.Features.WeatherForecastsHistories.WeatherForecastById;
public record WeatherForecastHistoryByIdQuery(
    Guid Id
) : IQuery<WeatherForecastHistoryByIdQueryResponse>;