using System.Threading.Tasks;
using ABBI.Domain.Entities;

namespace ABBI.Interfaces.facade
{
    public interface IPaymentService
    {
        Task<CustomerBasket> CreateOrUpdatePaymentIntent(string basketId);
        Task<OrderEntity> UpdateOrderPaymentSucceeded(string paymentIntentId);
        Task<OrderEntity> UpdateOrderPaymentFailed(string paymentIntentId);
    }
}
