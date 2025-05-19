using Advania_Test.Domain.Contracts;
using Advania_Test.Domain.Models;


namespace Advania_Test.Domain.Extensions
{
    public static class ProductExtensions
    {
        public static Product ToEntity(this AddProductRequest request)
        {
            return new Product 
            {
                Name = request.Name,
                Category = request.Category,
                Color = request.Color,
                Price = request.Price,
            };
        }

        public static ProductResponse ToResponse(this Product product)
        {
            return new ProductResponse
            (
               // product.Id,
                product.Name,
                product.Category,
                product.Color,
                product.Price
            );
        }


    }
}
