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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Guid> Add(ProductEntity product)
        {
            Product prod = product.MapToModel();
            await _productRepository.AddAsync(prod);
            return prod.Id;
        }

        public async Task DeleteProduct(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                throw new NotFoundException(nameof(ProductEntity), id);
            }
            await _productRepository.DeleteAsync(product);
        }

        public async Task<List<ProductEntity>> GetAllProducts()
        {
            var data = await _productRepository.GetAllAsync();
            return data?.Select(x => new ProductEntity(x)).ToList();
        }

        public Task<List<ProductEntity>> GetByUser(string user)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductEntity> GetProduct(Guid id)
        {
            var data = _productRepository.GetByIdAsync(id);
            return new ProductEntity((await data));
        }

        public async Task UpdateProduct(ProductEntity product)
        {
            var prod = await _productRepository.GetByIdAsync(product.Id);
            if (prod == null)
            {
                throw new NotFoundException(nameof(OrderEntity), product.Id);
            }
            var newProduct = product.MapToModel(prod);
            await _productRepository.UpdateAsync(newProduct);
        }
    }
}
