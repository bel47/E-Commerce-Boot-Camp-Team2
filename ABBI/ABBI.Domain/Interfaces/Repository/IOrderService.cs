using ABBI.Domain.Models;
using ABBI.Domain.Seeds;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABBI.Domain.Interfaces.Repository
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
        Task<List<Order>> GetByUser(string user);
    }
}
