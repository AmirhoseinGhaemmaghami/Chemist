using Chemist.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Chemist.Services.DI
{
    public static class RegisterToDi
    {
        public static IServiceCollection AddServicesLayerServices(this IServiceCollection services)
        {
            services.AddSingleton<IPizzeriaFactory, PizzeriaFactory>();
            services.AddScoped<IPriceService, PriceService>();
            return services;
        }
    }
}
