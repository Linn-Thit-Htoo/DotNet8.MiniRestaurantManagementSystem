using DotNet8.MiniRestaurantManagementSystem.DbService.AppDbContextModels;
using DotNet8.MiniRestaurantManagementSystem.Dtos.Features.Category;
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
    }
}
