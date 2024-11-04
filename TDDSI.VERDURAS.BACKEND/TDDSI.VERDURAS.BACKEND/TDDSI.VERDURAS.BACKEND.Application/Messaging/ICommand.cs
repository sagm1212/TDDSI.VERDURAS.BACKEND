using MediatR;
using TDDSI.VERDURAS.BACKEND.Domain.Abstractions;

namespace TDDSI.VERDURAS.BACKEND.Application.Messaging;
public interface ICommand : IRequest<Result>, IBaseCommand {

}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand {

}