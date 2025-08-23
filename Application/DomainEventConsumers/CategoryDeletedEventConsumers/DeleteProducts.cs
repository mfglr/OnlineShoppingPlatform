using Core.Events;
using Domain.ProductAggregate.Abstracts;
using MediatR;

namespace Application.DomainEventConsumers.CategoryDeletedEventConsumers
{
    internal class DeleteProducts(IProductRepository productRepository) : INotificationHandler<CategoryDeletedEvent>
    {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task Handle(CategoryDeletedEvent notification, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProductsByCategoryId(notification.CategoryId, cancellationToken);
            _productRepository.DeleteRange(products);
        }
    }
}
