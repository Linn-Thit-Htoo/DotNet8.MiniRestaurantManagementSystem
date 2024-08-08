namespace DotNet8.MiniRestaurantManagementSystem.Dtos.Features.Order;

public class CreateOrderDto
{
    public decimal TotalPrice { get; set; }
    public List<CreateOrderDetailDto> OrderDetails { get; set; }
}
