using MediatR;

namespace Core.Events
{
    public record OrderCancelledEvent_Item(Guid ProductId, int Quantity);
    public record OrderCancelledEvent(Guid OrderId, IEnumerable<OrderCancelledEvent_Item> Items) : INotification; 
}
