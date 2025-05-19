using Advania_Test.Domain.Abstract;
using Advania_Test.Domain.Contracts;
using Advania_Test.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Text.Json;

namespace Advania_Test.Application.Endpoints
{
    public class AddProduct
    {
        private readonly ILogger<AddProduct> _logger;
        private readonly IDomainService _domainService;

        public AddProduct(ILogger<AddProduct> logger, IDomainService domainService)
        {
            _logger = logger;
            _domainService = domainService;
        }

        [Function("AddProduct")]
        public async  Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req /*AddProductRequest request*/)
        {
            _logger.LogInformation("AddProduct function triggered.");

            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            AddProductRequest? request = JsonSerializer.Deserialize<AddProductRequest>(requestBody);
            if(request == null)
            {
                _logger.LogError("request body is null.");
                return new BadRequestObjectResult("Missing Request body");
            }

            _logger.LogInformation(request.ToString()); //ta bort
            ProductResponse response = await _domainService.AddProduct(request);

            return new OkObjectResult(response);
        }
    }
}
