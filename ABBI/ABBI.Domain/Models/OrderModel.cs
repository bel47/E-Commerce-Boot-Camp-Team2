using Order.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Models
{
    public class OrderModel : BaseAuditModel
    {
        public decimal TotalPrice { get; set; }
        public string UserName { get; set; }
       
        public List<OrderItemModel> OrderItems { get; set; }
        public OrderModel()
        {

        }
    }
}
