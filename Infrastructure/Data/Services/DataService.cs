using Advania_Test.Domain.Abstract;
using Advania_Test.Domain.Models;
using Azure.Data.Tables;
using Microsoft.Extensions.Logging;


namespace Advania_Test.Infrastructure.Data.Services
{
    internal class DataService(TableClient tableClient, ILogger<DataService> _logger) : IDataService
    {
        public async Task<Product> AddProduct(Product product)
        {
            var entity = new TableEntity() {
                {"PartitionKey", product.Category },
                {"RowKey", product.Name },
                {"Color", product.Color },
                {"Price", product.Price.ToString() }
            };

            await tableClient.AddEntityAsync(entity);
            _logger.LogInformation("Entity stored in table storage.");

            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var entities = tableClient.QueryAsync<TableEntity>();
            List<Product> products = new List<Product>();

            await foreach(var e in entities)
            {
                products.Add(new Product
                {
                    Category = e.GetString("PartitionKey"),
                    Name = e.GetString("RowKey"),
                    Color = e.GetString("Color"),
                    Price = decimal.Parse(e.GetString("Price"))
                });
            }

            return products;
        }
    }
}
