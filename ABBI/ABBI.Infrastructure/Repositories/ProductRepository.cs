using ABBI.Domain.Interfaces.Repository;
using ABBI.Domain.Models;
using ABBI.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABBI.Infrastructure.Repositories
{
    public class ProductRepository : AsyncRepository<Product>, IProductRepository
    {
        private readonly OrderContext _orderContext;
        public ProductRepository(OrderContext orderContext) : base(orderContext)
        {
            _orderContext = orderContext;
        }

        public Task<List<Product>> GetByUser(string user)
        {
            throw new NotImplementedException();
        }

        public override async Task<IReadOnlyList<Product>> GetAllAsync()
        {            
            var product = await _orderContext.Products.Include(p => p.ProductBrand).Include(p => p.ProductType).ToListAsync();
            return product;
        }

        public override async Task<Product> GetByIdAsync(Guid id) 
        {
            var product = await _orderContext.Products.Include(p => p.ProductBrand).Include(p => p.ProductType).FirstOrDefaultAsync(p => p.Id == id);

            return product;
        }

    }
}
