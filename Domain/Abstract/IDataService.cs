using Advania_Test.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advania_Test.Domain.Abstract
{
    internal interface IDataService
    {
        Task<Product> AddProduct(Product product);
        IEnumerable<Product> GetProducts();
    }
}
