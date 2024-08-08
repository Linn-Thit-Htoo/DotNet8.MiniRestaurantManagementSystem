using DotNet8.MiniRestaurantManagementSystem.Dtos.Features.Order;
using DotNet8.MiniRestaurantManagementSystem.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.MiniRestaurantManagementSystem.Modules.Features.Order
{
    public interface IOrderService
    {
        Task<Result<IEnumerable<OrderDto>>> GetOrdersAsync();
    }
}
