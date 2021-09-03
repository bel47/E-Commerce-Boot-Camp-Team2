using ABBI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABBI.Domain.Interfaces.Facade
{
    public interface IOrderService
    {
        Task<List<OrderEntity>> GetAllOrders();
        Task<Guid> Add(OrderEntity order);
        Task<List<OrderEntity>> GetByUser(string user);
        Task<OrderEntity> GetOrder(Guid id);
        Task UpdateOrder(OrderEntity order);
        Task DeleteOrder(Guid id);

    }
}
