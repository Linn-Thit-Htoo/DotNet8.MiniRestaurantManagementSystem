namespace DotNet8.MiniRestaurantManagementSystem.Dtos.Features.Order;

public class OrderListDto
{
    public List<OrderDataDto> DataLst { get; set; }
}

public class OrderDataDto
{
    public int OrderId { get; set; }

    public string InvoiceNo { get; set; } = null!;

    public decimal TotalPrice { get; set; }

    public DateTime CreatedDate { get; set; }

    public List<OrderDetailDto> OrderDetails { get; set; }
}
