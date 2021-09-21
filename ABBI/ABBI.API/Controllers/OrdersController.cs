using Microsoft.AspNetCore.Mvc;
using ABBI.Domain.Interfaces.Facade;
using ABBI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ABBI.API.Models;
using Microsoft.AspNetCore.Http;

namespace ABBI.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet(Name = "GetAllOrders")]
        [ProducesResponseType(typeof(IEnumerable<OrderEntity>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<OrderEntity>>> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrders();
            return Ok(orders);
        }
        [HttpGet("{userName}", Name = "GetOrder")]
        [ProducesResponseType(typeof(IEnumerable<OrderEntity>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<OrderEntity>>> GetOrdersByUserName(string userName)
        {
            var orders = await _orderService.GetByUser(userName);
            return Ok(orders);
        }
        [HttpPost(Name = "CheckoutOrder")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<Guid>> CheckoutOrder([FromBody] OrderPostModel order)
        {
            var newOrder = await _orderService.Add(order.MapToEntity<OrderEntity>());
            return Ok(newOrder);
        }
        [HttpPut(Name = "UpdateOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateOrder([FromBody] OrderPostModel order)
        {
            await _orderService.UpdateOrder(order.MapToEntity<OrderEntity>());
            return NoContent();
        }
        [HttpDelete("{id}", Name = "DeleteOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteOrder(Guid id) 
        {
            var data = _orderService.DeleteOrder(id);
            await data;
            return NoContent();

        }
    }
}
