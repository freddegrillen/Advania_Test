using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Advania_Test.Application.Endpoints
{
    public class AddProduct
    {
        private readonly ILogger<AddProduct> _logger;

        public AddProduct(ILogger<AddProduct> logger)
        {
            _logger = logger;
        }

        [Function("AddProduct")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
        {
            _logger.LogInformation("AddProduct function triggered.");
            _logger.LogInformation("");


            return new OkObjectResult("Product added");
        }
    }
}
