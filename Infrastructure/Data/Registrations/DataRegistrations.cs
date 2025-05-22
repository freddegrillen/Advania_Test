using Advania_Test.Domain.Abstract;
using Advania_Test.Infrastructure.Data.Services;
using Microsoft.Extensions.DependencyInjection;
using Azure.Data.Tables;

namespace Advania_Test.Infrastructure.Data.Registrations
{
    internal static class DataRegistrations
    {
        internal static IServiceCollection AddDataRegistration(this IServiceCollection services)
        {
            services.AddScoped<TableClient>(provider =>
            {
                string connectionString = Environment.GetEnvironmentVariable("Table_Storage_Connectionstring")
                    ?? throw new Exception("Connection string is missing.");
                string tableName = "Products";
                var client = new TableClient(connectionString, tableName);
                client.CreateIfNotExists();
                return client;
            });
            services.AddScoped<IDataService, DataService>();

            return services;
        }
    }
}
