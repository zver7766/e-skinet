using Core.Entities.OrderAggregate;
using Core.Entities.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> orderItemBuilder)
        {
            orderItemBuilder.HasKey(application => application.Id);

            orderItemBuilder.Property(application => application.Id)
                .ValueGeneratedOnAdd();
            
            orderItemBuilder.OwnsOne(orderItem => orderItem.ItemOrdered, itemOrderedBuilder =>
            {
                itemOrderedBuilder.Property(itemOrdered => itemOrdered.ProductName)
                    .HasColumnName(nameof(ProductItemOrdered.ProductName));
                
                itemOrderedBuilder.Property(itemOrdered => itemOrdered.ProductItemId)
                    .HasColumnName(nameof(ProductItemOrdered.ProductItemId));
                
                itemOrderedBuilder.Property(itemOrdered => itemOrdered.PictureUrl)
                    .HasColumnName(nameof(ProductItemOrdered.PictureUrl));
            });

            orderItemBuilder.OwnsOne(orderItem => orderItem.Price, priceBuilder =>
            {
                priceBuilder.Property(price => price.Value)
                    .HasColumnName(nameof(OrderItem.Price))
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();
            });
        }
    }
}