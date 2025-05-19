using Advania_Test.Domain.Abstract;
using Advania_Test.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advania_Test.Domain.Registrations
{
    public static class DomainRegistrations
    {
        public static IServiceCollection AddDomainRegistrations(this IServiceCollection services)
        {
            services.AddScoped<IDomainService, DomainService>();
            return services;
        }
    }
}
