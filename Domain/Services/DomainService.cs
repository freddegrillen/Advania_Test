using Advania_Test.Domain.Abstract;
using Advania_Test.Domain.Contracts;
using Advania_Test.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advania_Test.Domain.Services
{
    internal class DomainService: IDomainService
    {

        public ProductResponse AddProduct(AddProductRequest request)
        {
            return new ProductResponse(1, "Name","blue", 2.55m); //Fixa sen
        }

        public IEnumerable<ProductResponse> GetProducts()
        {
            return new List<ProductResponse>();
        }
    }
}
