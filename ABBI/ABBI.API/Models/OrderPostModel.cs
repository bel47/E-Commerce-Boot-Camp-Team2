using ABBI.Domain.Entities;
using System.Collections.Generic;

namespace ABBI.API.Models
{
    public class OrderPostModel : BaseModel
    {
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderItemPostModel> OrderItemPostModels { get; set; }
    }
}
