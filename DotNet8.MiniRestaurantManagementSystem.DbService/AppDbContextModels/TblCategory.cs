using System;
using System.Collections.Generic;

namespace DotNet8.MiniRestaurantManagementSystem.DbService.AppDbContextModels;

public partial class TblCategory
{
    public int CategoryId { get; set; }

    public string CategoryCode { get; set; } = null!;

    public string CategoryName { get; set; } = null!;
}
