using Core;

namespace Domain.MaintenanceAggregate.Entities
{
    public class Maintenance(Guid? userId, string? userAgent, string? url, string? ip, int statusCode) : Entity, IAggregateRoot
    {
        public Guid? UserId { get; private set; } = userId;
        public string? UserAgent { get; private set; } = userAgent;
        public string? Url { get; private set; } = url;
        public string? Ip { get; private set; } = ip;
        public int StatusCode { get; private set; } = statusCode;
    }
}
