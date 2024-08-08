using DotNet8.MiniRestaurantManagementSystem.DbService.AppDbContextModels;
using DotNet8.MiniRestaurantManagementSystem.Dtos.Features.Category;
using DotNet8.MiniRestaurantManagementSystem.Dtos.Features.MenuItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.MiniRestaurantManagementSystem.Extensions
{
    public static class Extension
    {
        public static CategoryDto ToDto(this TblCategory dataModel)
        {
            return new CategoryDto
            {
                CategoryId = dataModel.CategoryId,
                CategoryCode = dataModel.CategoryCode,
                CategoryName = dataModel.CategoryName
            };
        }

        public static TblCategory ToEntity(this CreateCategoryDto categoryDto)
        {
            return new TblCategory
            {
                CategoryCode = Ulid.NewUlid().ToString(),
                CategoryName = categoryDto.CategoryName
            };
        }

        public static TblMenuItem ToEntity(this CreateMenuItemDto menuItemDto)
        {
            return new TblMenuItem
            {
                MenuItemCode = Ulid.NewUlid().ToString(),
                CategoryCode = menuItemDto.CategoryCode,
                MenuItemName = menuItemDto.MenuItemName,
                Price = menuItemDto.Price
            };
        }

        public static MenuItemDto ToDto(this TblMenuItem dataModel)
        {
            return new MenuItemDto
            {
                MenuItemId = dataModel.MenuItemId,
                MenuItemCode = dataModel.MenuItemCode,
                CategoryCode = dataModel.CategoryCode,
                MenuItemName = dataModel.MenuItemName,
                Price = dataModel.Price
            };
        }
    }
}
