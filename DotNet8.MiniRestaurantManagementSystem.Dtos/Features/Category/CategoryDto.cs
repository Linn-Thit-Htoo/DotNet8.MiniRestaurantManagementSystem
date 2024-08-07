using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.MiniRestaurantManagementSystem.Dtos.Features.Category
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }

        public string CategoryCode { get; set; } = null!;

        public string CategoryName { get; set; } = null!;
    }
}
