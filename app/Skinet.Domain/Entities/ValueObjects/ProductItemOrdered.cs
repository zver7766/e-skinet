using System.Collections.Generic;

namespace Core.Entities.ValueObjects
{
    public class ProductItemOrdered : ValueObject
    {
        public int? ProductItemId { get; set; }
        public string? ProductName { get; set; }
        public string? PictureUrl { get; set; }

        public ProductItemOrdered(int? productItemId = default, string? productName = default, string? pictureUrl = default)
        {
            ProductItemId = productItemId;
            ProductName = productName;
            PictureUrl = pictureUrl;
        }
        
        protected ProductItemOrdered()
        {
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            if (ProductItemId != null) yield return ProductItemId;
            if (ProductName != null) yield return ProductName;
            if (PictureUrl != null) yield return PictureUrl;
        }

        public static Result<ProductItemOrdered> Create(int? productItemId, string? productName, string? pictureUrl)
        {
            
            
            return Result.Ok(new ProductItemOrdered(productItemId, productName, pictureUrl));
        }
    }
}