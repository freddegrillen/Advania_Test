using Advania_Test.Domain.Registrations;
using Advania_Test.Infrastructure.Data.Registrations;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddDomainRegistrations();
        services.AddDataRegistration();
    })
    .Build();

host.Run();
