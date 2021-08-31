using Microsoft.EntityFrameworkCore;
using ABBI.Infrastructure.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABBI.Domain.Interfaces;
using ABBI.Domain.Models;

namespace ABBI.Infrastructure.Repository
{
    public class OrderRepository : AsyncRepository<Order>, IOrderRepository
    {
        private readonly OrderContext _orderContext;
        public OrderRepository(OrderContext orderContext):base(orderContext)
        {
            _orderContext = orderContext;
        }
        public override async Task<IReadOnlyList<Order>> GetAllAsync()
        {
            var orders = _orderContext.Orders.Include(order => order.OrderItems).ToListAsync();
            return await orders;
        }

        public async Task<List<Order>> GetByUser(string user)
        {
            var orderList = (await GetAsync(x => x.UserName == user)).ToList();
            return orderList;
        }
    }
}
