using DotNet8.MiniRestaurantManagementSystem.Dtos.Features.OrderDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.MiniRestaurantManagementSystem.Dtos.Features.Order
{
    public class CreateOrderDto
    {
        public decimal TotalPrice { get; set; }
        public List<CreateOrderDetailDto> OrderDetails { get; set; }
    }
}
