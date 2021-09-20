using ABBI.API.Models;
using ABBI.Domain.Entities;

namespace ABBI.API.Mapping
{
    public class ProductMapping
    {
        public static ProductPostModel ToDto(ProductEntity productEntity)
        {
            var productDto = new ProductPostModel();

            productDto.Id = productEntity.Id;
            productDto.IsActive = productEntity.IsActive;
            productDto.CreatedDate = productEntity.CreatedDate;
            productDto.Name = productEntity.Name;
            productDto.Description = productEntity.Description;
            productDto.Price = productEntity.Price;
            productDto.PictureUrl = productEntity.PictureUrl;
            productDto.ProductBrand = productEntity.ProductBrand.Name;
            productDto.ProductType = productEntity.ProductType.Name;

            return productDto;

        }

        public static ProductEntity ToEntity(ProductPostModel productDto)
        {
            var productEntity = new ProductEntity();

            productEntity.Name = productDto.Name;
            productEntity.Description = productDto.Description;
            productEntity.PictureUrl = productDto.PictureUrl;
            productEntity.ProductBrand.Name = productDto.ProductBrand;
            productEntity.ProductType.Name = productDto.ProductType;

            return productEntity;
        }
    }
}
