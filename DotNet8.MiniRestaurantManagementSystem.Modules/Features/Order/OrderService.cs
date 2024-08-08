using DotNet8.MiniRestaurantManagementSystem.Dtos.Features.Order;
using DotNet8.MiniRestaurantManagementSystem.Dtos.Features.OrderDetail;
using DotNet8.MiniRestaurantManagementSystem.Shared;
using DotNet8.MiniRestaurantManagementSystem.Shared.Queries;
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

        public async Task<Result<OrderListDto>> GetOrdersAsync(CancellationToken cancellationToken)
        {
            Result<OrderListDto> result;
            try
            {
                var orderLst = await _context.TblOrders
                    .OrderByDescending(x => x.OrderId)
                    .ToListAsync(cancellationToken: cancellationToken);

                List<OrderDataDto> orderDataDtos = new();

                foreach (var order in orderLst)
                {
                    var detailLst = await _context.TblOrderDetails.Where(x => x.InvoiceNo == order.InvoiceNo)
                        .ToListAsync(cancellationToken: cancellationToken);

                    orderDataDtos.Add(new OrderDataDto
                    {
                        OrderId = order.OrderId,
                        CreatedDate = order.CreatedDate,
                        InvoiceNo = order.InvoiceNo,
                        TotalPrice = order.TotalPrice,
                        OrderDetails = detailLst.Select(x => x.ToDto()).ToList()
                    });
                }

                result = Result<OrderListDto>.Success(new OrderListDto() { DataLst = orderDataDtos });
            }
            catch (Exception ex)
            {
                result = Result<OrderListDto>.Failure(ex);
            }

            return result;
        }

        public async Task<Result<OrderDataDto>> ViewOrderAsync(string invoiceNo, CancellationToken cancellationToken)
        {
            Result<OrderDataDto> result;
            try
            {
                var order = await _context
                    .TblOrders
                    .FirstOrDefaultAsync(x => x.InvoiceNo == invoiceNo, cancellationToken: cancellationToken);

                if (order is null)
                {
                    result = Result<OrderDataDto>.NotFound("Order Not Found.");
                    goto result;
                }

                var detailLst = await _context.TblOrderDetails
                    .Where(x => x.InvoiceNo.Equals(order.InvoiceNo))
                    .ToListAsync(cancellationToken);

                var orderDataDto = new OrderDataDto()
                {
                    OrderDetails = detailLst.Select(x => x.ToDto()).ToList(),
                    CreatedDate = order.CreatedDate,
                    InvoiceNo = order.InvoiceNo,
                    OrderId = order.OrderId,
                    TotalPrice = order.TotalPrice
                };

                result = Result<OrderDataDto>.Success(orderDataDto);
            }
            catch (Exception ex)
            {
                result = Result<OrderDataDto>.Failure(ex);
            }

        result:
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
