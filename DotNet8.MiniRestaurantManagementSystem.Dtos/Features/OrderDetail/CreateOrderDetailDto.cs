namespace DotNet8.MiniRestaurantManagementSystem.Dtos.Features.OrderDetail;

public class CreateOrderDetailDto
{
    public string MenuItemCode { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal TotalPrice { get; set; }
}
