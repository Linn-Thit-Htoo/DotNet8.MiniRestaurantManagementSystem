using DotNet8.MiniRestaurantManagementSystem.DbService.AppDbContextModels;
using DotNet8.MiniRestaurantManagementSystem.Dtos.Features.MenuItem;
using DotNet8.MiniRestaurantManagementSystem.Extensions;
using DotNet8.MiniRestaurantManagementSystem.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.MiniRestaurantManagementSystem.Modules.Features.MenuItem
{
    public class MenuItemService : IMenuItemService
    {
        private readonly AppDbContext _context;

        public MenuItemService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<IEnumerable<MenuItemDto>>> GetMenuItemsAsync(CancellationToken cancellationToken)
        {
            Result<IEnumerable<MenuItemDto>> result;
            try
            {
                var lst = await _context.TblMenuItems.OrderByDescending(x => x.MenuItemId).ToListAsync();
                result = Result<IEnumerable<MenuItemDto>>.Success(lst.Select(x => x.ToDto()));
            }
            catch (Exception ex)
            {
                result = Result<IEnumerable<MenuItemDto>>.Failure(ex);
            }

            return result;
        }

        public async Task<Result<MenuItemDto>> GetMenuItemAsync(int id, CancellationToken cancellationToken)
        {
            Result<MenuItemDto> result;
            try
            {
                var menuItem = await _context.TblMenuItems.FindAsync([id, cancellationToken], cancellationToken: cancellationToken);
                if (menuItem is null)
                {
                    result = Result<MenuItemDto>.NotFound("Menu Item Not Found.");
                    goto result;
                }

                result = Result<MenuItemDto>.Success(menuItem.ToDto());
            }
            catch (Exception ex)
            {
                result = Result<MenuItemDto>.Failure(ex);
            }

        result:
            return result;
        }
    }
}
