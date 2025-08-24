using MediatR;

namespace Core.Events
{
    public record DecreaseProductsStockSuccessEvent_Item(Guid ProductId, string Name, decimal Price, int Quantity);
    public record DecreaseProductsStockSuccessEvent(Guid UserId, IEnumerable<DecreaseProductsStockSuccessEvent_Item> Items) : INotification;
}
