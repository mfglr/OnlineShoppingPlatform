using MediatR;

namespace Application.Commands.ProductAggragate.IncreaseStockQuantity
{
    public record IncreaseStockQuantityDto(int Id, int StockQuantity) : IRequest;
}
