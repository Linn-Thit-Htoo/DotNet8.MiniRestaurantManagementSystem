using DotNet8.MiniRestaurantManagementSystem.Dtos.Features.MenuItem;
using DotNet8.MiniRestaurantManagementSystem.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.MiniRestaurantManagementSystem.Modules.Features.MenuItem
{
    public interface IMenuItemService
    {
        Task<Result<IEnumerable<MenuItemDto>>> GetMenuItemsAsync(CancellationToken cancellationToken);
        Task<Result<IEnumerable<MenuItemDto>>> GetMenuItemsByCategoryCodeAsync(string categoryCode, CancellationToken cancellationToken);
        Task<Result<MenuItemDto>> GetMenuItemAsync(int id, CancellationToken cancellationToken);
        Task<Result<MenuItemDto>> CreateMenuItem(CreateMenuItemDto menuItemDto, CancellationToken cancellationToken);
    }
}
