using ABBI.Domain.Entities;
using ABBI.Domain.Interfaces.Facade;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ABBI.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasketsController : Controller
    {
        private readonly IBasketService _basketRepository;
        public BasketsController(IBasketService basketRepository)
        {
            _basketRepository = basketRepository;
        }
        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
        {
            var basket = await _basketRepository.GetBasket(id);

            return Ok(basket ?? new CustomerBasket(id));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket)
        {
            //var customerBasket = _mapper.Map<CustomerBasket>(basket);

          //  var updatedBasket = await _basketRepository.UpdateBasket(basket);

            return Ok(null);
        }

        [HttpDelete]
        public async Task DeleteBasketAsync(string id)
        {
            await _basketRepository.DeleteBasket(id);
        }
    }
}
