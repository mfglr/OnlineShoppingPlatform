using MediatR;

namespace Core.Events
{
    public record DecreaseProductsStockFailedEvent_Item(Guid ProductId, int Quantity);
    public record DecreaseProductsStockFailedEvent(Guid UserId, IEnumerable<DecreaseProductsStockFailedEvent_Item> Items) : INotification;
}
