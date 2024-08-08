using DotNet8.MiniRestaurantManagementSystem.Dtos.Features.Order;
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

        public OrderService(DapperService dapperService)
        {
            _dapperService = dapperService;
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
    }
}
