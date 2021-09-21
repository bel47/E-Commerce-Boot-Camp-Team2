using ABBI.Domain.Models;
using ABBI.Domain.Seeds;
using System;

namespace ABBI.Domain.Entities
{
    public class ProductEntity : BaseEntity<Product>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public ProductType ProductType { get; set; }
        public Guid ProductTypeId { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public Guid ProdictBrandId   { get; set; }
        public ProductEntity()
        {
            ProductBrand = new ProductBrand();
            ProductType = new ProductType();
        }
        public ProductEntity(Product product) : base(product)
        {
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            PictureUrl = product.PictureUrl;
            ProductBrand = product.ProductBrand;
            ProductType = product.ProductType;
        }
        public override Product MapToModel()
        {
            Product product = new Product();

            product.IsActive = this.IsActive;
            product.Description = this.Description;
            product.Name = this.Name;
            product.Price = this.Price;
            product.PictureUrl = this.PictureUrl;
            product.ProductBrand = this.ProductBrand;
            product.ProductType = this.ProductType;

            return product;
        }
        public override Product MapToModel(Product t)
        {
            Product product = t;

            product.IsActive = this.IsActive;
            product.Description = this.Description;
            product.Name = this.Name;
            product.Price = this.Price;
            product.PictureUrl = this.PictureUrl;
            product.ProductBrand = this.ProductBrand;
            product.ProductType = this.ProductType;

            return product;
        }
    }
}
