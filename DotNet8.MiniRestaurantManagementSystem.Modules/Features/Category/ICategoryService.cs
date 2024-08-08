namespace DotNet8.MiniRestaurantManagementSystem.Modules.Features.Category;

public interface ICategoryService
{
    Task<Result<IEnumerable<CategoryDto>>> GetCategoriesAsync(CancellationToken cancellationToken);
    Task<Result<CategoryDto>> GetCategoryByIdAsync(
        int categoryId,
        CancellationToken cancellationToken
    );
    Task<Result<CategoryDto>> GetCategoryByCodeAsync(
        string categoryCode,
        CancellationToken cancellationToken
    );
    Task<Result<CategoryDto>> CreateCategoryAsync(
        CreateCategoryDto categoryDto,
        CancellationToken cancellationToken
    );
    Task<Result<CategoryDto>> DeleteCategoryAsync(
        int categoryId,
        CancellationToken cancellationToken
    );
}
