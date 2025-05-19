using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Advania_Test.Application.Endpoints
{
    public class Add_Product
    {
        private readonly ILogger<Add_Product> _logger;

        public Add_Product(ILogger<Add_Product> logger)
        {
            _logger = logger;
        }

        [Function("Add_Product")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
