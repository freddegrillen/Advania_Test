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
    internal class DataService(TableClient tableClient) : IDataService
    {
        public async Task<Product> AddProduct(Product product)
        {
            var entity = new TableEntity() {
                {"PartitionKey", product.Category },
                {"RowKey", product.Name },
               // {"Id", product.Id},
                {"Color", product.Color },
                {"Price", product.Price }
            };
            tableClient.AddEntity(entity);

            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            List<TableEntity> entities = tableClient.Query<TableEntity>(maxPerPage: 1000).ToList<TableEntity>();
            List<Product> products = entities.Select(e => new Product
            {
                Category = e.GetString("PartitionKey"),
                Name = e.GetString("RowKey"),
                Color = e.GetString("Color"),
                Price = (decimal) e.GetDouble("Price") //Kolla om det här fungerar bra, kan vara strul med att spara som double.
            }).ToList<Product>();
            return products;
        }
    }
}
