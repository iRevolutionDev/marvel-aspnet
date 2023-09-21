using MediatR;

namespace Marvel.Domain.Common;

public abstract class BaseEvent : INotification
{
    public DateTime Timestamp { get; private set; } = DateTime.UtcNow;
}