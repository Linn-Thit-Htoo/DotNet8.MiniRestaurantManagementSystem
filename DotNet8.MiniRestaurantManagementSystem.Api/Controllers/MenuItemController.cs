using DotNet8.MiniRestaurantManagementSystem.Modules.Features.MenuItem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.MiniRestaurantManagementSystem.Api.Controllers
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
    }
}
