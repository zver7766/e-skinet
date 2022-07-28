using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Extensions;
using AutoMapper;
using Core.Entities.OrderAggregate;
using Core.Entities.ValueObjects;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class OrdersController : BaseApiController
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _mapper = mapper;
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult<OrderToReturnDto>> CreateOrder(OrderDto orderDto, string buyerEmail)
        {
            var address = _mapper.Map<AddressDto, Address>(orderDto.ShipToAddress);

            var order = await _orderService.CreateOrderAsync(buyerEmail, orderDto.DeliveryMethodId,
                 orderDto.BasketId, address);

            var orderToReturn = _mapper.Map<Order, OrderToReturnDto>(order);

            return Ok(orderToReturn);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OrderToReturnDto>>> GetOrdersForUser(string email)
        {
            var orders = await _orderService.GetOrdersForUserAsync(email);

            return Ok(_mapper.Map<IReadOnlyList<Order>, IReadOnlyList<OrderToReturnDto>>(orders));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderToReturnDto>> GetOrderByIdForUser(int id, string email)
        {
            var order = await _orderService.GetOrderByIdAsync(id, email);

            if (order == null) return NotFound(new ApiResponse(404));

            return Ok(_mapper.Map<Order, OrderToReturnDto>(order));
        }

        [HttpGet("deliveryMethods")]
        public async Task<ActionResult<IReadOnlyList<DeliveryMethodDto>>> GetDeliveryMethods()
        {
            var deliveryMethods = await _orderService.GetDeliveryMethodsAsync();
            return Ok(_mapper.Map<IReadOnlyList<DeliveryMethod>, IReadOnlyList<DeliveryMethodDto>>(deliveryMethods));
        }
    }
}