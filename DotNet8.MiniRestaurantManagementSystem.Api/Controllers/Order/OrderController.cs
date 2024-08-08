﻿using DotNet8.MiniRestaurantManagementSystem.Api.Controllers.Base;
using DotNet8.MiniRestaurantManagementSystem.Dtos.Features.Order;
using DotNet8.MiniRestaurantManagementSystem.Modules.Features.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.MiniRestaurantManagementSystem.Api.Controllers.Order
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var result = await _orderService.GetOrdersAsync();
            return Content(result);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitOrder([FromBody] CreateOrderDto orderDto, CancellationToken cancellationToken)
        {
            var result = await _orderService.CreateOrderAsync(orderDto, cancellationToken);
            return Content(result);
        }
    }
}
