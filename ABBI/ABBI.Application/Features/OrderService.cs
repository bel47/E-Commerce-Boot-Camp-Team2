using ABBI.Application.Exceptions;
using ABBI.Domain.Interfaces.Facade;
using ABBI.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABBI.Domain.Models;
using ABBI.Domain.Entities;

namespace ABBI.Application.Features
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Guid> Add(OrderEntity order)
        {
            Order orderModel = order.MapToModel();
            await _orderRepository.AddAsync(orderModel);
            return orderModel.Id;
        }

        public async Task DeleteOrder(Guid id)
        {
            var orderToDelete = await _orderRepository.GetByIdAsync(id);
            if(orderToDelete == null) 
            {
                throw new NotFoundException(nameof(OrderEntity), id);
            }
            await _orderRepository.DeleteAsync(orderToDelete);
        }

        public async Task<List<OrderEntity>> GetAllOrders()
        {
            var data = await _orderRepository.GetAllAsync();
            return data?.Select(x => new OrderEntity(x)).ToList();
        }

        public async Task<List<OrderEntity>> GetByUser(string user)
        {
            //var data = _orderRepository.GetAsync(x => x.UserName == user);
           // List<OrderEntity> orders = (await data).Select(x=> new OrderEntity(x)).ToList();
            return null;
        }

        public async Task<OrderEntity> GetOrder(Guid id)
        {
            var data = _orderRepository.GetByIdAsync(id);
            return new OrderEntity((await data));
        }

        public async Task UpdateOrder(OrderEntity order)
        {
            var orderToUpdate = await _orderRepository.GetByIdAsync(order.Id);
            if(orderToUpdate == null) 
            {
                throw new NotFoundException(nameof(OrderEntity), order.Id);
            }
            var newOrder = order.MapToModel(orderToUpdate);
            await _orderRepository.UpdateAsync(newOrder);
        }
    }
}
