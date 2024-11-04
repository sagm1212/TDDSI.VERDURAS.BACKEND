using MediatR;
using TDDSI.VERDURAS.BACKEND.Domain.Abstractions;

namespace TDDSI.VERDURAS.BACKEND.Application.Messaging;
public interface IQueryHandler<TQuery, TResponse>
: IRequestHandler<TQuery, Result<TResponse>>
where TQuery : IQuery<TResponse> {

}
