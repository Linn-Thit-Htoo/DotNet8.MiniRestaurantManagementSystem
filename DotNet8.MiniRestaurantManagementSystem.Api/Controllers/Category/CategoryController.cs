﻿namespace DotNet8.MiniRestaurantManagementSystem.Api.Controllers.Category;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : BaseController
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories(CancellationToken cancellationToken)
    {
        var result = await _categoryService.GetCategoriesAsync(cancellationToken);
        return Content(result);
    }

    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetCategoryById(int id, CancellationToken cancellationToken)
    {
        var result = await _categoryService.GetCategoryByIdAsync(id, cancellationToken);
        return Content(result);
    }

    [HttpGet("categoryCode/{categoryCode}")]
    public async Task<IActionResult> GetCategoryByCode(
        string categoryCode,
        CancellationToken cancellationToken
    )
    {
        var result = await _categoryService.GetCategoryByCodeAsync(categoryCode, cancellationToken);
        return Content(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(
        [FromBody] CreateCategoryDto categoryDto,
        CancellationToken cancellationToken
    )
    {
        var result = await _categoryService.CreateCategoryAsync(categoryDto, cancellationToken);
        return Content(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id, CancellationToken cancellationToken)
    {
        var result = await _categoryService.DeleteCategoryAsync(id, cancellationToken);
        return Content(result);
    }
}
