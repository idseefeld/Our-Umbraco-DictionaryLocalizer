using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;

namespace Our.Umbraco.DictionaryLocalizer.Localization
{
    public static class DictionaryLocalizationServiceCollectionExtensions
    {
        public static IServiceCollection AddDictionaryLocalization(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.TryAdd(new ServiceDescriptor(
                typeof(IStringLocalizerFactory),
                typeof(DictionaryStringLocalizerFactory),
                ServiceLifetime.Singleton));

            return services;
        }
    }
}
