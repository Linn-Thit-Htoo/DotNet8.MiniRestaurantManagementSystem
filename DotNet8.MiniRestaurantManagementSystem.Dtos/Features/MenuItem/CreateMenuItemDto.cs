namespace DotNet8.MiniRestaurantManagementSystem.Dtos.Features.MenuItem;

public class CreateMenuItemDto
{
    public string CategoryCode { get; set; } = null!;

    public string MenuItemName { get; set; } = null!;

    public decimal Price { get; set; }
}
