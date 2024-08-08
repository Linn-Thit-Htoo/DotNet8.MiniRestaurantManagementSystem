using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.MiniRestaurantManagementSystem.Dtos.Features.OrderDetail
{
    public class CreateOrderDetailDto
    {
        public string MenuItemCode { get; set; } = null!;

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
