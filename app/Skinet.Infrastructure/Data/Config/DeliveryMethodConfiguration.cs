using Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class DeliveryMethodConfiguration : IEntityTypeConfiguration<DeliveryMethod>
    {
        public void Configure(EntityTypeBuilder<DeliveryMethod> deliveryMethodBuilder)
        {
            deliveryMethodBuilder.HasKey(deliveryMethod => deliveryMethod.Id);

            deliveryMethodBuilder.Property(deliveryMethod => deliveryMethod.Id)
                .ValueGeneratedOnAdd();
            
            deliveryMethodBuilder.OwnsOne(deliveryMethod => deliveryMethod.Price, priceBuilder =>
            {
                priceBuilder.Property(price => price.Value)
                    .HasColumnName(nameof(DeliveryMethod.Price))
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();
            });
        }
    }
}