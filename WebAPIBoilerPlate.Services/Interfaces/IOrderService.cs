using System.Collections.Generic;
using WebAPIBoilerPlate.BusinessEntities;

namespace WebAPIBoilerPlate.Services.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderEntity> GetAllOrders();

        OrderEntity GetOrderById(int orderId);

        int AddOrder(OrderEntity orderId);

        bool UpdateOrder(OrderEntity productEntity);

        bool DeleteOrder(int orderId);
    }
}