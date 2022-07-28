using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Entities.ProductAggregate;
using Core.Entities.ValueObjects;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.Price, o => o.MapFrom(s => s.Price.Value))
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
            
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();
            CreateMap<AddressDto, Address>();

            CreateMap<Order, OrderToReturnDto>()
                .ForMember(d => d.BuyerEmail, o => o.MapFrom(s => s.BuyerEmail.Value))
                .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
                .ForMember(d => d.ShippingPrice, o => o.MapFrom(s => s.DeliveryMethod.Price.Value))
                .ForMember(d => d.Subtotal, o => o.MapFrom(s => s.Subtotal.Value))
                .ForMember(d => d.Total, o => o.MapFrom(s => s.GetTotal()));

            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(d => d.Price, o => o.MapFrom(s => s.Price.Value))
                .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ItemOrdered.ProductItemId))
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.ItemOrdered.ProductName))
                .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.ItemOrdered.PictureUrl))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<OrderItemUrlResolver>());

            CreateMap<DeliveryMethod, DeliveryMethodDto>()
                .ForMember(d => d.Price, o => o.MapFrom(s => s.Price.Value));
        }
    }
}