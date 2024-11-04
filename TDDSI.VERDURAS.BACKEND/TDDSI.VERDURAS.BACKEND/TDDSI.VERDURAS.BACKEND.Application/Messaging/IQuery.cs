using MediatR;
using TDDSI.VERDURAS.BACKEND.Domain.Abstractions;

namespace TDDSI.VERDURAS.BACKEND.Application.Messaging;
public interface IQuery<TResponse> : IRequest<Result<TResponse>> {

}