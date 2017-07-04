using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIBoilerPlate.BusinessEntities;
using WebAPIBoilerPlate.Services;
using WebAPIBoilerPlate.Services.Interfaces;

namespace WebAPIBoilerPlate.Controllers
{
    public class OrderController : ApiController
    {
        private readonly IOrderService _orderService;

        public OrderController()
        {
            _orderService = new OrderService();
        }

        public HttpResponseMessage Get()
        {
            var orders = _orderService.GetAllOrders();
            if (orders != null)
            {
                var orderEntities = orders as List<OrderEntity> ?? orders.ToList();
                if (orderEntities.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, orderEntities);
                }
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Order not found");
        }
    }
}