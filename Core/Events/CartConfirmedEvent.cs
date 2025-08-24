using MediatR;

namespace Core.Events
{
    public record CartConfirmedEvent_CartItem(Guid ProductId, int Quantity);
    public record CartConfirmedEvent(Guid UserId, IEnumerable<CartConfirmedEvent_CartItem> Items) : INotification;
}
