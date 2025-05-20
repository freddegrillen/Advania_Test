using Advania_Test.Domain.Abstract;
using Advania_Test.Infrastructure.Data.Services;
using Microsoft.Extensions.DependencyInjection;
using Azure.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advania_Test.Infrastructure.Data.Registrations
{
    internal static class DataRegistrations
    {
        internal static IServiceCollection AddDataRegistration(this IServiceCollection services)
        {
            services.AddSingleton<TableClient>(provider =>
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
