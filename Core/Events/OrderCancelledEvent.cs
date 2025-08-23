using MediatR;

namespace Core.Events
{
    public record OrderCancelledEvent_Item(int ProductId, int Quantity);
    public record OrderCancelledEvent(int OrderId, IEnumerable<OrderCancelledEvent_Item> Items) : INotification; 
}
