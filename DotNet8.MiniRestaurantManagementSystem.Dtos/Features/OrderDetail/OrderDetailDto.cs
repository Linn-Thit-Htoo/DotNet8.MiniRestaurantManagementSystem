namespace DotNet8.MiniRestaurantManagementSystem.Dtos.Features.OrderDetail;

public class OrderDetailDto
{
    public int OrderDetailId { get; set; }

    public string InvoiceNo { get; set; } = null!;

    public string MenuItemCode { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal TotalPrice { get; set; }
}
