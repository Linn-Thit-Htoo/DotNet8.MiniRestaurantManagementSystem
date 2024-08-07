using DotNet8.MiniRestaurantManagementSystem.DbService.AppDbContextModels;
using DotNet8.MiniRestaurantManagementSystem.Dtos.Features.Category;
using DotNet8.MiniRestaurantManagementSystem.Extensions;
using DotNet8.MiniRestaurantManagementSystem.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<Result<IEnumerable<CategoryDto>>> GetCategoriesAsync(CancellationToken cancellationToken)
        {
            Result<IEnumerable<CategoryDto>> result;
            try
            {
                var lst = await _context.TblCategories.OrderByDescending(x => x.CategoryId).ToListAsync(cancellationToken: cancellationToken);
                result = Result<IEnumerable<CategoryDto>>.Success(lst.Select(x => x.ToDto()));
            }
            catch (Exception ex)
            {
                result = Result<IEnumerable<CategoryDto>>.Failure(ex);
            }

            return result;
        }

        public async Task<Result<CategoryDto>> GetCategoryByIdAsync(int categoryId, CancellationToken cancellationToken)
        {
            Result<CategoryDto> result;
            try
            {
                var category = await GetSpecificCategory(x => x.CategoryId == categoryId, cancellationToken);
                if (category is null)
                {
                    result = Result<CategoryDto>.NotFound("Category Not Found.");
                    goto result;
                }

                result = Result<CategoryDto>.Success(category.ToDto());
            }
            catch (Exception ex)
            {
                result = Result<CategoryDto>.Failure(ex);
            }

        result:
            return result;
        }

        public async Task<Result<CategoryDto>> GetCategoryByCodeAsync(string categoryCode, CancellationToken cancellationToken)
        {
            Result<CategoryDto> result;
            try
            {
                var category = await GetSpecificCategory(x => x.CategoryCode == categoryCode, cancellationToken);
                if (category is null)
                {
                    result = Result<CategoryDto>.NotFound("Category Not Found.");
                    goto result;
                }

                result = Result<CategoryDto>.Success(category.ToDto());
            }
            catch (Exception ex)
            {
                result = Result<CategoryDto>.Failure(ex);
            }

        result:
            return result;
        }

        public async Task<Result<CategoryDto>> CreateCategoryAsync(CreateCategoryDto categoryDto, CancellationToken cancellationToken)
        {
            Result<CategoryDto> result;
            try
            {
                bool isDuplicate = await IsCategoryDuplicate(x => x.CategoryName == categoryDto.CategoryName, cancellationToken);
                if (isDuplicate)
                {
                    result = Result<CategoryDto>.Duplicate("Category Name already exists.");
                    goto result;
                }

                await _context.TblCategories.AddAsync(categoryDto.ToEntity(), cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                result = Result<CategoryDto>.SaveSuccess();
            }
            catch (Exception ex)
            {
                result = Result<CategoryDto>.Failure(ex);
            }

        result:
            return result;
        }

        private async Task<bool> IsCategoryDuplicate(Expression<Func<TblCategory, bool>> expression, CancellationToken cancellationToken)
        {
            return await _context.TblCategories.AnyAsync(expression, cancellationToken: cancellationToken);
        }

        private async Task<TblCategory?> GetSpecificCategory(Expression<Func<TblCategory, bool>> expression, CancellationToken cancellationToken)
        {
            return await _context.TblCategories.FirstOrDefaultAsync(expression, cancellationToken: cancellationToken);
        }
    }
}
