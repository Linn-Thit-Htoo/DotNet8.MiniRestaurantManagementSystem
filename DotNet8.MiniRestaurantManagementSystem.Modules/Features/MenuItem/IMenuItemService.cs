namespace DotNet8.MiniRestaurantManagementSystem.Modules.Features.MenuItem;

public interface IMenuItemService
{
    Task<Result<IEnumerable<MenuItemDto>>> GetMenuItemsAsync(CancellationToken cancellationToken);
    Task<Result<IEnumerable<MenuItemDto>>> GetMenuItemsByCategoryCodeAsync(
        string categoryCode,
        CancellationToken cancellationToken
    );
    Task<Result<MenuItemDto>> GetMenuItemAsync(int id, CancellationToken cancellationToken);
    Task<Result<MenuItemDto>> CreateMenuItemAsync(
        CreateMenuItemDto menuItemDto,
        CancellationToken cancellationToken
    );
    Task<Result<MenuItemDto>> UpdateMenuItemAsync(
        int id,
        CreateMenuItemDto menuItemDto,
        CancellationToken cancellationToken
    );
    Task<Result<MenuItemDto>> DeleteMenuItemAsync(int id, CancellationToken cancellationToken);
}
