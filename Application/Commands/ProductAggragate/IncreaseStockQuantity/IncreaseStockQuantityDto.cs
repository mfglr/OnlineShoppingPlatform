using MediatR;

namespace Application.Commands.ProductAggragate.IncreaseStockQuantity
{
    public record IncreaseStockQuantityDto(Guid Id, int StockQuantity) : IRequest;
}
