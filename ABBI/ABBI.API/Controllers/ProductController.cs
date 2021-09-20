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
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet(Name = "GetAllProducts")]
        [ProducesResponseType(typeof(List<ProductPostModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<ProductPostModel>>> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();

            var productDtos = products.Select(product => ProductMapping.ToDto(product)).ToList();

            return Ok(productDtos);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        [ProducesResponseType(typeof(ProductPostModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductPostModel>> GetProductById(Guid Id)
        {
            var product = await _productService.GetProduct(Id);

            var productDto = ProductMapping.ToDto(product);

            return Ok(productDto);
        }

        [HttpPost(Name = "CheckoutProduct")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<Guid>> CheckoutProduct([FromBody] ProductPostModel product)
        {
            var productId = await _productService.Add(ProductMapping.ToEntity(product));
            return Ok(productId);
        }

        [HttpPut(Name = "UpdateProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateOrder([FromBody] ProductPostModel productDto)
        {
            await _productService.UpdateProduct(ProductMapping.ToEntity(productDto));
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
