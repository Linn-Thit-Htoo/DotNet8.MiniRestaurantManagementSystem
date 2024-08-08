using DotNet8.MiniRestaurantManagementSystem.DbService.AppDbContextModels;
using DotNet8.MiniRestaurantManagementSystem.Dtos.Features.Order;
using DotNet8.MiniRestaurantManagementSystem.Extensions;
using DotNet8.MiniRestaurantManagementSystem.Shared;
using DotNet8.MiniRestaurantManagementSystem.Shared.Queries;
using DotNet8.MiniRestaurantManagementSystem.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.MiniRestaurantManagementSystem.Modules.Features.Order
{
    public class OrderService : IOrderService
    {
        private readonly DapperService _dapperService;
        private readonly AppDbContext _context;

        public OrderService(DapperService dapperService, AppDbContext context)
        {
            _dapperService = dapperService;
            _context = context;
        }

        public async Task<Result<IEnumerable<OrderDto>>> GetOrdersAsync()
        {
            Result<IEnumerable<OrderDto>> result;
            try
            {
                string query = OrderQuery.OrderListQuery;
                var lst = await _dapperService.QueryAsync<OrderDto>(query);

                result = Result<IEnumerable<OrderDto>>.Success(lst);
            }
            catch (Exception ex)
            {
                result = Result<IEnumerable<OrderDto>>.Failure(ex);
            }

            return result;
        }

        public async Task<Result<OrderDto>> CreateOrderAsync(CreateOrderDto orderDto, CancellationToken cancellationToken)
        {
            Result<OrderDto> result;
            var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

            try
            {
                var order = orderDto.ToEntity();
                await _context.TblOrders.AddAsync(order, cancellationToken);

                foreach (var item in orderDto.OrderDetails)
                {
                    await _context.TblOrderDetails.AddAsync(item.ToEntity(order.InvoiceNo), cancellationToken);
                }

                await _context.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
                result = Result<OrderDto>.SaveSuccess();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
                result = Result<OrderDto>.Failure(ex);
            }

            return result;
        }
    }
}
