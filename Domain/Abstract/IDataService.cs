using Advania_Test.Domain.Models;

namespace Advania_Test.Domain.Abstract
{
    internal interface IDataService
    {
        Task<Product> AddProduct(Product product);
        Task<IEnumerable<Product>> GetProducts();
    }
}
