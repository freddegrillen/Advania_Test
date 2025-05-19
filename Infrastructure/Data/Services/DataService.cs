using Advania_Test.Domain.Abstract;
using Advania_Test.Domain.Models;
using Azure.Data.Tables;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advania_Test.Infrastructure.Data.Services
{
    internal class DataService : IDataService
    {
        public async Task<Product> AddProduct(Product product)
        {

            var tableClient = new TableClient(Environment.GetEnvironmentVariable("Table_Storage_Connectionstring"), "Products");
            await tableClient.CreateIfNotExistsAsync();
            var entity = new TableEntity() {
                {"PartitionKey", product.Category },
                {"RowKey", product.Name },
                {"Id", product.Id},
                {"Color", product.Color },
                {"Price", product.Price }
            };
            tableClient.AddEntity(entity);

            return product; //Lägg till implementation
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return new List<Product>(); //Lägg till implementation
        }
    }
}
