using Core.Entities.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> productBuilder)
        {
            productBuilder.HasKey(product => product.Id);

            productBuilder.Property(product => product.Id)
                .ValueGeneratedOnAdd();
            
            productBuilder.Property(p => p.Name).IsRequired().HasMaxLength(150);
            
            productBuilder.Property(p => p.Description).IsRequired();
            
            productBuilder.OwnsOne(product => product.Price, priceBuilder =>
            {
                priceBuilder.Property(price => price.Value)
                    .HasColumnName(nameof(Product.Price))
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();
            });
            
            productBuilder.Property(p => p.PictureUrl).IsRequired();
            
            productBuilder.HasOne(product => product.ProductBrand)
                .WithMany()
                .IsRequired();
            
            productBuilder.HasOne(product => product.ProductType)
                .WithMany()
                .IsRequired();
        }
    }
}