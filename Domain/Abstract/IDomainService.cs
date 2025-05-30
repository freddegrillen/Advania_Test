﻿using Advania_Test.Domain.Contracts;


namespace Advania_Test.Domain.Abstract
{
    public interface IDomainService
    {
        Task<ProductResponse> AddProduct(AddProductRequest request);
        Task<IEnumerable<ProductResponse>> GetProducts();
    }
}
