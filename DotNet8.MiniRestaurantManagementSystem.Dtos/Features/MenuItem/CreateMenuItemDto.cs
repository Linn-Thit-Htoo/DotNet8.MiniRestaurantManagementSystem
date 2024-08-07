using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.MiniRestaurantManagementSystem.Dtos.Features.MenuItem
{
    public class CreateMenuItemDto
    {
        public string CategoryCode { get; set; } = null!;

        public string MenuItemName { get; set; } = null!;

        public decimal Price { get; set; }
    }
}
