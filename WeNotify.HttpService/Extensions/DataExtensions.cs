using Microsoft.Extensions.DependencyInjection;
using PremiumTesh.TwitterNotifier.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeNotify.HttpService.Contracts;

namespace WeNotify.HttpService.Extensions
{
    public static class DataExtensions
    {
        public static IServiceCollection AddTwitterService(this IServiceCollection services)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            // register data service repository
            services.AddScoped(typeof(IRepository<>), typeof(RepositoryFactory<>));
            return services;
        }
    }
}
