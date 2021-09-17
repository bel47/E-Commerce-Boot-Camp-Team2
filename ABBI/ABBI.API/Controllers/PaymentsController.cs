using System.Threading.Tasks;
using ABBI.Domain.Entities;
using ABBI.Interfaces.facade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PaymentsController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly string _whSecret;
        private readonly ILogger<PaymentsController> _logger;
        public PaymentsController(IPaymentService paymentService, ILogger<PaymentsController> logger, 
            IConfiguration config)
        {
            _logger = logger;
            _paymentService = paymentService;
            _whSecret = config.GetSection("StripeSettings:WhSecret").Value;
        }

        [HttpPost("{basketId}")]
        public async Task<ActionResult<CustomerBasket>> CreateOrUpdatePaymentIntent(string basketId)
        {
            var basket = await _paymentService.CreateOrUpdatePaymentIntent(basketId);

            if (basket == null) return BadRequest();

            return basket;
        }

    }
}
