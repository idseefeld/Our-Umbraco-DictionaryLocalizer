using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Our.Umbraco.DictionaryLocalizer.Models;
using System;
using System.Collections.Concurrent;
using Umbraco.Cms.Core.Services;

namespace Our.Umbraco.DictionaryLocalizer.Localization
{
    public class DictionaryStringLocalizerFactory : IStringLocalizerFactory
    {
        private readonly ILocalizationService _localizationService;
        private static readonly ConcurrentDictionary<string, IStringLocalizer> _resourceLocalizations = new();
        private readonly IOptions<DictionaryLocalizationOptions> _options;
        public DictionaryStringLocalizerFactory(ILocalizationService localizationService, IOptions<DictionaryLocalizationOptions> options)
        {
            _localizationService = localizationService;
            _options = options;
        }
        public IStringLocalizer Create(Type resourceSource)
        {
            if (_options.Value.DataAnnotationOnly)
            {
                var baseType = resourceSource.BaseType;
                var isDictionaryDataAnnotationModel = resourceSource == typeof(DictionaryDataAnnotationBaseModel);
                while (!isDictionaryDataAnnotationModel && baseType != null)
                {
                    isDictionaryDataAnnotationModel = baseType == typeof(DictionaryDataAnnotationBaseModel);
                    baseType = baseType.BaseType;
                }
#pragma warning disable CS8603 // Possible null reference return.
                if (!isDictionaryDataAnnotationModel) return null;
#pragma warning restore CS8603 // Possible null reference return.
            }

            _resourceLocalizations.TryGetValue(resourceSource.Name, out IStringLocalizer existing);
            if (existing != null) return existing;
            DictionaryStringLocalizer stringLocalizer = new(_localizationService);

            return _resourceLocalizations.GetOrAdd(resourceSource.Name, stringLocalizer);
        }

        public IStringLocalizer Create(string baseName, string location)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return null;
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}

