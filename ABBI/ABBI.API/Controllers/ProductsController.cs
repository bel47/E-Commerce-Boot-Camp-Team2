using ABBI.API.Mapping;
using ABBI.API.Models;
using ABBI.Domain.Entities;
using ABBI.Domain.Interfaces.Facade;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ABBI.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet(Name = "GetAllProducts")]
        [ProducesResponseType(typeof(List<ProductPostModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<ProductPostModel>>> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();
            var productsDto = products.Select(product => ProductMapping.MapToDto(product));
            return Ok(productsDto);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        [ProducesResponseType(typeof(ProductPostModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductPostModel>> GetOrdersByUserName(Guid id)
        {
            var product = await _productService.GetProduct(id);
            var productDto = ProductMapping.MapToDto(product);
            return Ok(productDto);
        }

        [HttpPost(Name = "CheckoutProduct")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<Guid>> CheckoutProduct([FromBody] ProductPostModel product)
        {
            var newProductId = await _productService.Add(ProductMapping.MapToEntity(product));
            return Ok(newProductId);
        }

        [HttpPut(Name = "UpdateProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateOrder([FromBody] ProductPostModel product)
        {
            await _productService.UpdateProduct(ProductMapping.MapToEntity(product));
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            await _productService.DeleteProduct(id);
            return NoContent();
        }
    }
}
