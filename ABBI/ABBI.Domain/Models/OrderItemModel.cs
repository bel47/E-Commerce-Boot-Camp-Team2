using ABBI.Domain.Seeds;

namespace ABBI.Domain.Models
{
    public class OrderItemModel: BaseAuditModel
    {
        public decimal Qty { get; protected set; }
        public string Name { get; protected set; }
        public decimal Price { get; protected set; }
        public OrderItemModel(decimal qty, string name, decimal price)
        {
            Price = price;
            Qty = qty;
            Name = name;
        }
    }
}
