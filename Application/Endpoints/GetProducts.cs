using Advania_Test.Domain.Abstract;
using Advania_Test.Domain.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Advania_Test.Application.Endpoints
{
    public class GetProducts(ILogger<GetProducts> _logger, IDomainService domainService)
    {  
        [Function("GetProducts")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
        {
            _logger.LogInformation("GetProducts triggered.");
            IEnumerable<ProductResponse> response = await domainService.GetProducts();
            return new OkObjectResult(response);
        }
    }
}
