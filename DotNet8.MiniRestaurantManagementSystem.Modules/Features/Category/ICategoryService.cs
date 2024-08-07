using DotNet8.MiniRestaurantManagementSystem.Dtos.Features.Category;
using DotNet8.MiniRestaurantManagementSystem.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.MiniRestaurantManagementSystem.Modules.Features.Category
{
    public interface ICategoryService
    {
        Task<Result<IEnumerable<CategoryDto>>> GetCategoriesAsync(CancellationToken cancellationToken);
        Task<Result<CategoryDto>> GetCategoryByIdAsync(int categoryId, CancellationToken cancellationToken);
        Task<Result<CategoryDto>> GetCategoryByCodeAsync(string categoryCode, CancellationToken cancellationToken);
        Task<Result<CategoryDto>> CreateCategoryAsync(CreateCategoryDto categoryDto, CancellationToken cancellationToken);
    }
}
