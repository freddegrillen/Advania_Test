using Advania_Test.Domain.Abstract;
using Advania_Test.Domain.Contracts;
using Advania_Test.Domain.Extensions;
using Advania_Test.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advania_Test.Domain.Services
{
    internal class DomainService(IDataService dataService): IDomainService
    {

        public async Task<ProductResponse> AddProduct(AddProductRequest request)
        {
            if(request.Name is null || request.Category is null)
            {
                throw new ArgumentNullException("Product name and category cannot be null.");
            }

            Product product = request.ToEntity();
            await dataService.AddProduct(product);

            return product.ToResponse();
        }

        public async Task<IEnumerable<ProductResponse>> GetProducts()
        {
            IEnumerable<Product> products = await dataService.GetProducts();
            return products.Select(p => p.ToResponse());
        }
    }
}
