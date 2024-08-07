using System;
using System.Collections.Generic;

namespace DotNet8.MiniRestaurantManagementSystem.DbService.AppDbContextModels;

public partial class TblMenuItem
{
    public int MenuItemId { get; set; }

    public string MenuItemCode { get; set; } = null!;

    public string CategoryCode { get; set; } = null!;

    public string MenuItemName { get; set; } = null!;

    public decimal Price { get; set; }
}
