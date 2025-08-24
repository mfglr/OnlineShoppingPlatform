using Core;

namespace Domain.MaintenanceAggregate.Entities
{
    public class Maintenance(int? userId, string? userAgent, string? url, string? ip, int statusCode) : Entity, IAggregateRoot
    {
        public int? UserId { get; private set; } = userId;
        public string? UserAgent { get; private set; } = userAgent;
        public string? Url { get; private set; } = url;
        public string? Ip { get; private set; } = ip;
        public int StatusCode { get; private set; } = statusCode;
    }
}
