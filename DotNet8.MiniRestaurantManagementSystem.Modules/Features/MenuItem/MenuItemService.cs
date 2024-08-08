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
                var lst = await _context.TblMenuItems.OrderByDescending(x => x.MenuItemId).ToListAsync(cancellationToken: cancellationToken);
                result = Result<IEnumerable<MenuItemDto>>.Success(lst.Select(x => x.ToDto()));
            }
            catch (Exception ex)
            {
                result = Result<IEnumerable<MenuItemDto>>.Failure(ex);
            }

            return result;
        }

        public async Task<Result<IEnumerable<MenuItemDto>>> GetMenuItemsByCategoryCodeAsync(string categoryCode, CancellationToken cancellationToken)
        {
            Result<IEnumerable<MenuItemDto>> result;
            try
            {
                var lst = await _context.TblMenuItems
                    .Where(x => x.CategoryCode == categoryCode)
                    .OrderByDescending(x => x.MenuItemId)
                    .ToListAsync(cancellationToken: cancellationToken);

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

        public async Task<Result<MenuItemDto>> CreateMenuItemAsync(CreateMenuItemDto menuItemDto, CancellationToken cancellationToken)
        {
            Result<MenuItemDto> result;
            try
            {
                bool categoryValid = await _context.TblCategories.AnyAsync(x => x.CategoryCode == menuItemDto.CategoryCode, cancellationToken: cancellationToken);
                if (!categoryValid)
                {
                    result = Result<MenuItemDto>.NotFound("Category Not Found.");
                    goto result;
                }

                await _context.TblMenuItems.AddAsync(menuItemDto.ToEntity(), cancellationToken: cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                result = Result<MenuItemDto>.SaveSuccess();
            }
            catch (Exception ex)
            {
                result = Result<MenuItemDto>.Failure(ex);
            }

        result:
            return result;
        }

        public async Task<Result<MenuItemDto>> UpdateMenuItemAsync(int id, CreateMenuItemDto menuItemDto, CancellationToken cancellationToken)
        {
            Result<MenuItemDto> result;
            try
            {
                bool categoryValid = await _context.TblCategories.AnyAsync(x => x.CategoryCode == menuItemDto.CategoryCode, cancellationToken: cancellationToken);
                if (!categoryValid)
                {
                    result = Result<MenuItemDto>.NotFound("Category Not Found.");
                    goto result;
                }

                var menuItem = await _context.TblMenuItems.FindAsync([id, cancellationToken], cancellationToken: cancellationToken);
                if (menuItem is null)
                {
                    result = Result<MenuItemDto>.NotFound("Menu Item Not Found.");
                    goto result;
                }

                menuItem.CategoryCode = menuItemDto.CategoryCode;
                menuItem.MenuItemName = menuItemDto.MenuItemName;
                menuItem.Price = menuItemDto.Price;

                _context.TblMenuItems.Update(menuItem);
                await _context.SaveChangesAsync(cancellationToken);

                result = Result<MenuItemDto>.UpdateSuccess();
            }
            catch (Exception ex)
            {
                result = Result<MenuItemDto>.Failure(ex);
            }

        result:
            return result;
        }

        public async Task<Result<MenuItemDto>> DeleteMenuItemAsync(int id, CancellationToken cancellationToken)
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

                _context.TblMenuItems.Remove(menuItem);
                await _context.SaveChangesAsync(cancellationToken);

                result = Result<MenuItemDto>.DeleteSuccess();
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
