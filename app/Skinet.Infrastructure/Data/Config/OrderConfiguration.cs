using System;
using Core.Entities.Enums;
using Core.Entities.OrderAggregate;
using Core.Entities.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> orderBuilder)
        {
            orderBuilder.HasKey(order => order.Id);

            orderBuilder.Property(order => order.Id)
                .ValueGeneratedOnAdd();
            
            orderBuilder.OwnsOne(order => order.BuyerEmail, buyerEmailBuilder =>
            {
                buyerEmailBuilder.Property(buyerEmail => buyerEmail.Value)
                    .HasColumnName(nameof(Order.BuyerEmail));
            });

            orderBuilder.Property(s => s.Status)
                .HasConversion(
                    o => o.ToString(),
                    o => (OrderStatus)Enum.Parse(typeof(OrderStatus), o)
                );

            orderBuilder.HasMany(o => o.OrderItems).WithOne().OnDelete(DeleteBehavior.Cascade);

            orderBuilder.OwnsOne(order => order.Subtotal, subtotalBuilder =>
            {
                subtotalBuilder.Property(subtotal => subtotal.Value)
                    .HasColumnName(nameof(Order.Subtotal))
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();
            });
            
            orderBuilder.OwnsOne(order => order.ShipToAddress, shipToAddressBuilder =>
            {
                shipToAddressBuilder.Property(shipToAddress => shipToAddress.FirstName)
                    .HasColumnName(nameof(Address.FirstName));
                
                shipToAddressBuilder.Property(shipToAddress => shipToAddress.LastName)
                    .HasColumnName(nameof(Address.LastName));
                
                shipToAddressBuilder.Property(shipToAddress => shipToAddress.City)
                    .HasColumnName(nameof(Address.City));
                
                shipToAddressBuilder.Property(shipToAddress => shipToAddress.State)
                    .HasColumnName(nameof(Address.State));
                
                shipToAddressBuilder.Property(shipToAddress => shipToAddress.Street)
                    .HasColumnName(nameof(Address.Street));
                
                shipToAddressBuilder.Property(shipToAddress => shipToAddress.ZipCode)
                    .HasColumnName(nameof(Address.ZipCode));
            });
        }
    }
}