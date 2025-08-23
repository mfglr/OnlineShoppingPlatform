using MediatR;

namespace Core.Events
{
    public record CartConfirmedEvent_CartItem(int ProductId, int Quantity);
    public record CartConfirmedEvent(int UserId, IEnumerable<CartConfirmedEvent_CartItem> Items) : INotification;
}
