using Advania_Test.Domain.Abstract;
using Advania_Test.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advania_Test.Infrastructure.Data.Services
{
    internal class DataService : IDataService
    {
        public async Task<Product> AddProduct(Product product)
        {
            return product; //Lägg till implementation
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return new List<Product>(); //Lägg till implementation
        }
    }
}
