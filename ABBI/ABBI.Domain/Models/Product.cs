using ABBI.Domain.Entities;
using ABBI.Domain.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABBI.Domain.Models
{
    public class Product : BaseAuditModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public ProductType ProductType { get; set; }
        public Guid ProductTypeId { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public Guid ProductBrandId { get; set; }
    }
}
