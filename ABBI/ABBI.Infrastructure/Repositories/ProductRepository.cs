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
/*            IQueryable<Product> productString = _orderContext.Products;


                productString = productString.ToList().Select(i => new Product
                {
                    Name = i.Name
                }).AsQueryable();*/
            
            var product = _orderContext.Products.Include(pt => pt.ProductType).Include(pb => pb.ProductBrand).ToListAsync();
            return await product;
        }

    }
}
