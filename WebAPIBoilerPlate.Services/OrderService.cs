using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebAPIBoilerPlate.BusinessEntities;
using WebAPIBoilerPlate.DataModel;
using WebAPIBoilerPlate.DataModel.UnitOfWork;
using WebAPIBoilerPlate.Services.Interfaces;

namespace WebAPIBoilerPlate.Services
{
    public class OrderService : IOrderService, IDisposable
    {
        private readonly UnitOfWork _unitOfWork;

        public OrderService()
        {
            _unitOfWork = new UnitOfWork();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Order, OrderEntity>();
            });
        }

        public IEnumerable<OrderEntity> GetAllOrders()
        {
            return _unitOfWork.OrderRepository.GetAll().ToList().Any() ? Mapper.Map<List<OrderEntity>>(_unitOfWork.OrderRepository.GetAll().ToList()) : null;
        }

        public OrderEntity GetOrderById(int orderId)
        {
            throw new System.NotImplementedException();
        }

        public int AddOrder(OrderEntity orderId)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateOrder(OrderEntity productEntity)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteOrder(int orderId)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }
    }
}