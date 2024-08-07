using DotNet8.MiniRestaurantManagementSystem.DbService.AppDbContextModels;
using DotNet8.MiniRestaurantManagementSystem.Dtos.Features.Category;
using DotNet8.MiniRestaurantManagementSystem.Extensions;
using DotNet8.MiniRestaurantManagementSystem.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.MiniRestaurantManagementSystem.Modules.Features.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<IEnumerable<CategoryDto>>> GetCategoriesAsync()
        {
            Result<IEnumerable<CategoryDto>> result;
            try
            {
                var lst = await _context.TblCategories.OrderByDescending(x => x.CategoryId).ToListAsync();
                result = Result<IEnumerable<CategoryDto>>.Success(lst.Select(x => x.ToDto()));
            }
            catch (Exception ex)
            {
                result = Result<IEnumerable<CategoryDto>>.Failure(ex);
            }

            return result;
        }
    }
}
