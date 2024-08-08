using DotNet8.MiniRestaurantManagementSystem.Dtos.Features.MenuItem;
using DotNet8.MiniRestaurantManagementSystem.Modules.Features.MenuItem;
using Microsoft.AspNetCore.Http;

namespace DotNet8.MiniRestaurantManagementSystem.Api.Controllers.MenuItem
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : BaseController
    {
        private readonly IMenuItemService _menuItemService;

        public MenuItemController(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMenuItems(CancellationToken cancellationToken)
        {
            var result = await _menuItemService.GetMenuItemsAsync(cancellationToken);
            return Content(result);
        }

        [HttpGet("categoryCode/{categoryCode}")]
        public async Task<IActionResult> GetMenuItemsByCategoryCode(string categoryCode, CancellationToken cancellationToken)
        {
            var result = await _menuItemService.GetMenuItemsByCategoryCodeAsync(categoryCode, cancellationToken);
            return Content(result);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetMenuItem(int id, CancellationToken cancellationToken)
        {
            var result = await _menuItemService.GetMenuItemAsync(id, cancellationToken);
            return Content(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenuItem([FromBody] CreateMenuItemDto menuItemDto, CancellationToken cancellationToken)
        {
            var result = await _menuItemService.CreateMenuItemAsync(menuItemDto, cancellationToken);
            return Content(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenuItem([FromBody] CreateMenuItemDto menuItemDto, int id, CancellationToken cancellationToken)
        {
            var result = await _menuItemService.UpdateMenuItemAsync(id, menuItemDto, cancellationToken);
            return Content(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuItem(int id, CancellationToken cancellationToken)
        {
            var result = await _menuItemService.DeleteMenuItemAsync(id, cancellationToken);
            return Content(result);
        }
    }
}
