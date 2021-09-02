﻿using ABBI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABBI.API.Models
{
    public class ProductPostModel :  BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public ProductType ProductType { get; set; }
        public override T MapToEntity<T>()
        {
            ProductEntity product = new ProductEntity();
            product.Name = Name;
            product.Description = Description;
            product.Price = Price;
            product.PictureUrl = PictureUrl;
            product.ProductBrand = ProductBrand;
            product.ProductType = ProductType;
            return product as T;
        }
    }
}