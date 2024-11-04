using MediatR;

namespace TDDSI.VERDURAS.BACKEND.Application.Messaging;
public interface INotifyHandler<TCommand> : INotificationHandler<TCommand>
where TCommand : INotify {

}
