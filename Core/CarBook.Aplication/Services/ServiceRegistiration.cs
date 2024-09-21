using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Services
{
    public static class ServiceRegistiration
    {
        public static void AddServiceRegistiration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(_=> _.RegisterServicesFromAssemblies(typeof(ServiceRegistiration).Assembly));
        }
    }
}
