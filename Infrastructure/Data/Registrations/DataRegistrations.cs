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
    public static class DataRegistrations
    {
        public static IServiceCollection AddDataRegistration(this IServiceCollection services)
        {
            services.AddScoped<IDataService, DataService>();
            //services.AddClient<TableClient>
            //var TableClient = new TableClient(Environment.GetEnvironmentVariable("Table_Storage_Connectionstring"), "Products");
            //await TableClient.CreateIfNotExistsAsync();
            return services;
        }
    }
}
