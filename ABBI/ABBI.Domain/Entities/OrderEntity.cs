using ABBI.Domain.Models;
using ABBI.Domain.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABBI.Domain.Entities
{
    public class OrderEntity : BaseEntity<Order>
    {
        public decimal TotalPrice { get; set; }
        public string UserName { get; set; }

        public List<OrderItem> OrderItems { get; set; }
        public OrderEntity()
        {
            OrderItems = new List<OrderItem>();
        }
        public OrderEntity(Order order) : base(order)
        {
            UserName = order.UserName;
            TotalPrice = order.TotalPrice;
            OrderItems = order.OrderItems?.Select(x => new OrderItem(x)).ToList();
        }

        public override Order MapToModel()
        {
            Order orderModel = new Order();
            orderModel.UserName = UserName;
            orderModel.TotalPrice = TotalPrice;
            orderModel.OrderItems = OrderItems?.Select(x => x.MapToModel()).ToList();
            return orderModel;
        }

        public override Order MapToModel(Order t)
        {
            throw new NotImplementedException();
        }
    }
}
