using MediatR;

namespace Core.Events
{
    public record DecreaseProductsStockSuccessEvent_Item(int ProductId, string Name, decimal Price, int Quantity);
    public record DecreaseProductsStockSuccessEvent(int UserId, IEnumerable<DecreaseProductsStockSuccessEvent_Item> Items) : INotification;
}
