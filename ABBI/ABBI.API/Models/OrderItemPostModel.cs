using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABBI.API.Models
{
    public class OrderItemPostModel
    {
        public string Name { get; set; }
        public decimal Qty { get; set; }
        public decimal Price { get; set; }

    }
}
