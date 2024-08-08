namespace DotNet8.MiniRestaurantManagementSystem.Dtos.Features.Order;

public class OrderDto
{
    public int OrderId { get; set; }

    public string InvoiceNo { get; set; } = null!;

    public decimal TotalPrice { get; set; }

    public DateTime CreatedDate { get; set; }

    public ICollection<OrderDetailDto> OrderDetails { get; set; }
}
