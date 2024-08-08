using DotNet8.MiniRestaurantManagementSystem.DbService.AppDbContextModels;
using DotNet8.MiniRestaurantManagementSystem.Dtos.Features.Category;
using DotNet8.MiniRestaurantManagementSystem.Dtos.Features.MenuItem;
using DotNet8.MiniRestaurantManagementSystem.Dtos.Features.Order;
using DotNet8.MiniRestaurantManagementSystem.Dtos.Features.OrderDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.MiniRestaurantManagementSystem.Extensions
{
    public static class Extension
    {
        public static CategoryDto ToDto(this TblCategory dataModel)
        {
            return new CategoryDto
            {
                CategoryId = dataModel.CategoryId,
                CategoryCode = dataModel.CategoryCode,
                CategoryName = dataModel.CategoryName
            };
        }

        public static TblCategory ToEntity(this CreateCategoryDto categoryDto)
        {
            return new TblCategory
            {
                CategoryCode = Ulid.NewUlid().ToString(),
                CategoryName = categoryDto.CategoryName
            };
        }

        public static TblMenuItem ToEntity(this CreateMenuItemDto menuItemDto)
        {
            return new TblMenuItem
            {
                MenuItemCode = Ulid.NewUlid().ToString(),
                CategoryCode = menuItemDto.CategoryCode,
                MenuItemName = menuItemDto.MenuItemName,
                Price = menuItemDto.Price
            };
        }

        public static MenuItemDto ToDto(this TblMenuItem dataModel)
        {
            return new MenuItemDto
            {
                MenuItemId = dataModel.MenuItemId,
                MenuItemCode = dataModel.MenuItemCode,
                CategoryCode = dataModel.CategoryCode,
                MenuItemName = dataModel.MenuItemName,
                Price = dataModel.Price
            };
        }

        public static TblOrder ToEntity(this CreateOrderDto orderDto)
        {
            return new TblOrder
            {
                InvoiceNo = DateTime.Now.ToString("yyyMMddHHmmss"),
                CreatedDate = DateTime.Now,
                TotalPrice = orderDto.TotalPrice
            };
        }

        public static TblOrderDetail ToEntity(this CreateOrderDetailDto orderDetailDto, string invoice)
        {
            return new TblOrderDetail
            {
                InvoiceNo = invoice,
                MenuItemCode = orderDetailDto.MenuItemCode,
                Quantity = orderDetailDto.Quantity,
                TotalPrice = orderDetailDto.TotalPrice
            };
        }

        public static OrderDetailDto ToDto(this TblOrderDetail dataModel)
        {
            return new OrderDetailDto
            {
                InvoiceNo = dataModel.InvoiceNo,
                MenuItemCode = dataModel.MenuItemCode,
                OrderDetailId = dataModel.OrderDetailId,
                Quantity = dataModel.Quantity,
                TotalPrice = dataModel.TotalPrice
            };
        }
    }
}
