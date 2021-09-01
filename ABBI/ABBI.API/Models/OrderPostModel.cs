using ABBI.Domain.Models;
using System.Collections.Generic;

namespace ABBI.API.Models
{
    public class OrderPostModel : BaseModel
    {
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderItemPostModel> OrderItemPostModels { get; set; }

        public override T MapToEntity<T>()
        {
            Order order = new Order();
            order.UserName = UserName;
            order.TotalPrice = TotalPrice;
            return order as T;
        }
    }
}
