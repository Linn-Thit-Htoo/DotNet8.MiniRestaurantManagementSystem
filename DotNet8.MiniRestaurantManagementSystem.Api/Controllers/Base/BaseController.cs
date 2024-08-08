namespace DotNet8.MiniRestaurantManagementSystem.Api.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult Content(object obj)
        {
            return Content(obj.SerializeObject(), "application/json");
        }
    }
}
