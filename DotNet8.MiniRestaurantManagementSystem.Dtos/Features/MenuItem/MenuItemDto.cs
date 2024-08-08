namespace DotNet8.MiniRestaurantManagementSystem.Dtos.Features.MenuItem;

public class MenuItemDto
{
    public int MenuItemId { get; set; }

    public string MenuItemCode { get; set; } = null!;

    public string CategoryCode { get; set; } = null!;

    public string MenuItemName { get; set; } = null!;

    public decimal Price { get; set; }
}
