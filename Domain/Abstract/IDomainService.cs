using Advania_Test.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advania_Test.Domain.Abstract
{
    internal interface IDomainService
    {
        ProductResponse AddProduct(AddProductRequest request);
        IEnumerable<ProductResponse> GetProducts();
    }
}
