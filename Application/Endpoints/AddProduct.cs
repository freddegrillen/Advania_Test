using Advania_Test.Domain.Abstract;
using Advania_Test.Domain.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Advania_Test.Application.Endpoints
{
    public class AddProduct(ILogger<AddProduct> _logger, IDomainService domainService)
    {

        [Function("AddProduct")]
        public async  Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
        {
            _logger.LogInformation("AddProduct function triggered.");
  

            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            if (string.IsNullOrEmpty(requestBody))
            {
                _logger.LogError("request body is null.");
                return new BadRequestObjectResult("Missing Request body");
            }
            AddProductRequest? request = JsonSerializer.Deserialize<AddProductRequest>(requestBody);

            try
            {
                ProductResponse response = await domainService.AddProduct(request);
                _logger.LogInformation($"Product added successfully.");
                return new OkObjectResult($"Product '{response.Name}' added successfully.");
            }
            catch (ArgumentNullException e)
            {
                _logger.LogError(e, "Error adding product: " + e.Message);
                return new BadRequestObjectResult("Error adding product: " + e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error adding product: " + e.Message);
                return new ConflictObjectResult("Error adding product: " + e.Message);
            }
        }
    }
}
