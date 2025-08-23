using MediatR;

namespace Core.Events
{
    public record DecreaseProductsStockFailedEvent_Item(int ProductId, int Quantity);
    public record DecreaseProductsStockFailedEvent(int UserId, IEnumerable<DecreaseProductsStockFailedEvent_Item> Items) : INotification;
}
