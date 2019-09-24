using System;
using Microsoft.Extensions.DependencyInjection;
using StatHat;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class StatHatDependencyInjectionExtensions
    {
        public static void AddStatHat(this IServiceCollection services, string ezKey)
        {
            if(services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if(ezKey == null)
            {
                throw new ArgumentException(nameof(ezKey));
            }

            services.AddScoped<IStatHatClient, StatHatClient>(s => new StatHatClient(ezKey));
        }
    }
}