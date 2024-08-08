namespace DotNet8.MiniRestaurantManagementSystem.Api.Controllers.Order;

[Route("api/[controller]")]
[ApiController]
public class OrderController : BaseController
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders(CancellationToken cancellationToken)
    {
        var result = await _orderService.GetOrdersAsync(cancellationToken);
        return Content(result);
    }

    [HttpGet("invoiceNo")]
    public async Task<IActionResult> ViewOrder(
        string invoiceNo,
        CancellationToken cancellationToken
    )
    {
        var result = await _orderService.ViewOrderAsync(invoiceNo, cancellationToken);
        return Content(result);
    }

    [HttpPost]
    public async Task<IActionResult> SubmitOrder(
        [FromBody] CreateOrderDto orderDto,
        CancellationToken cancellationToken
    )
    {
        var result = await _orderService.CreateOrderAsync(orderDto, cancellationToken);
        return Content(result);
    }
}
