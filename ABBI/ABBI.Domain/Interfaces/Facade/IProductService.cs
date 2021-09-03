using ABBI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABBI.Domain.Interfaces.Facade
{
    public interface IProductService
    {
        Task<List<ProductEntity>> GetAllProducts();
        Task<Guid> Add(ProductEntity product);
        Task<List<ProductEntity>> GetByUser(string user);
        Task<ProductEntity> GetProduct(Guid id);
        Task UpdateProduct(ProductEntity product);
        Task DeleteProduct(Guid id);
    }
}
