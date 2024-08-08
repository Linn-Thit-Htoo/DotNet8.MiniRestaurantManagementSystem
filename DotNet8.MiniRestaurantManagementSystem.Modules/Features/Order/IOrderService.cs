namespace DotNet8.MiniRestaurantManagementSystem.Modules.Features.Order;

public interface IOrderService
{
    Task<Result<OrderListDto>> GetOrdersAsync(CancellationToken cancellationToken);
    Task<Result<OrderDto>> CreateOrderAsync(
        CreateOrderDto orderDto,
        CancellationToken cancellationToken
    );
    Task<Result<OrderDataDto>> ViewOrderAsync(
        string invoiceNo,
        CancellationToken cancellationToken
    );
}
