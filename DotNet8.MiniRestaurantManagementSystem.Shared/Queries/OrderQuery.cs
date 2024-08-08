namespace DotNet8.MiniRestaurantManagementSystem.Shared.Queries;

public class OrderQuery
{
    public static string OrderListQuery { get; } =
        @"SELECT O.OrderId, O.InvoiceNo,
O.TotalPrice, O.CreatedDate, OD.OrderDetailId, OD.MenuItemCode, OD.Quantity, OD.TotalPrice
FROM Tbl_Order O
INNER JOIN Tbl_Order_Detail OD
ON O.InvoiceNo = OD.InvoiceNo
ORDER BY O.OrderId DESC";
}
