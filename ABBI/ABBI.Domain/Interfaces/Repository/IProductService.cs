using ABBI.Domain.Models;
using ABBI.Domain.Seeds;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABBI.Domain.Interfaces.Repository
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
        Task<List<Product>> GetByUser(string user);
    }
}
