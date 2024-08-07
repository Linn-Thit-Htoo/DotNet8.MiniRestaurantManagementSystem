using System;
using System.Collections.Generic;

namespace DotNet8.MiniRestaurantManagementSystem.DbService.AppDbContextModels;

public partial class TblOrder
{
    public int OrderId { get; set; }

    public string InvoiceNo { get; set; } = null!;

    public decimal TotalPrice { get; set; }
}
