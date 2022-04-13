using Core.Entities.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductBrandConfiguration : IEntityTypeConfiguration<ProductBrand>
    {
        public void Configure(EntityTypeBuilder<ProductBrand> productBrandBuilder)
        {
            productBrandBuilder.HasKey(productBrand => productBrand.Id);

            productBrandBuilder.Property(productBrand => productBrand.Id)
                .ValueGeneratedOnAdd();
            
            productBrandBuilder.Property(productBrand => productBrand.Name)
                .IsRequired();
        }
    }
}