using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABBI.API.Models
{
    public class BasketItemModel : BaseModel
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string PictureUrl { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
    }
}
