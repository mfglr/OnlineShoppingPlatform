using Domain.ProductAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ModelBuilders
{
    internal class ProductModelBuilders : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.OwnsOne(x => x.Name);
            builder.Property(x => x.RowVersion).IsRowVersion();
        }
    }
}
