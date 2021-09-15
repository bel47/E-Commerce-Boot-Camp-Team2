using ABBI.API.Models;
using ABBI.Domain.Entities;
using ABBI.Domain.Interfaces.Facade;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ABBI.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet(Name = "GetAllProducts")]
        [ProducesResponseType(typeof(IEnumerable<ProductEntity>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductEntity>>> GetAllProducts()
        {
            var orders = await _productService.GetAllProducts();
            return Ok(orders);
        }
        [HttpGet("{id}", Name = "GetProduct")]
        [ProducesResponseType(typeof(IEnumerable<OrderEntity>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<OrderEntity>>> GetOrdersByUserName(string userName)
        {
            var orders = await _productService.GetByUser(userName);
            return Ok(orders);
        }
        [HttpPost(Name = "CheckoutProduct")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<Guid>> CheckoutProduct([FromBody] ProductPostModel product)
        {
            var newOrder = await _productService.Add(product.MapToEntity<ProductEntity>());
            return Ok(newOrder);
        }
        [HttpPut(Name = "UpdateProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateOrder([FromBody] OrderPostModel order)
        {
            await _productService.UpdateProduct(order.MapToEntity<ProductEntity>());
            return NoContent();
        }
        [HttpDelete("{id}", Name = "DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            var data = _productService.DeleteProduct(id);
            await data;
            return NoContent();

        }
    }
}
