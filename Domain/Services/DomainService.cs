using Advania_Test.Domain.Abstract;
using Advania_Test.Domain.Contracts;
using Advania_Test.Domain.Extensions;
using Advania_Test.Domain.Models;

namespace Advania_Test.Domain.Services
{
    internal class DomainService(IDataService dataService): IDomainService
    {

        public async Task<ProductResponse> AddProduct(AddProductRequest request)
        {
            if(string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.Category))
            {
                throw new ArgumentNullException("Product name and category cannot be null.");
            }

            Product product = request.ToEntity();
            await dataService.AddProduct(product);

            return product.ToResponse();
        }

        public IEnumerable<ProductResponse> GetProducts()
        {
            IEnumerable<Product> products = dataService.GetProducts();
            return products.Select(p => p.ToResponse());
        }
    }
}
