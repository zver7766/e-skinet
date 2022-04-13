using Core.Entities.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> productTypeBuilder)
        {
            productTypeBuilder.HasKey(productType => productType.Id);

            productTypeBuilder.Property(productType => productType.Id)
                .ValueGeneratedOnAdd();

            productTypeBuilder.Property(productType => productType.Name)
                .IsRequired();
        }
    }
}