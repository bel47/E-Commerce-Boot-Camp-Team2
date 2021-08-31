using ABBI.Domain.Seeds;
using System.Collections.Generic;

namespace ABBI.Domain.Models
{
    public class Order : BaseAuditModel
    {
        public decimal TotalPrice { get; set; }
        public string UserName { get; set; }
        public List<OrderItemModel> OrderItems { get; set; }
        public Order() {  }
    }
}
