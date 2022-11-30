using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Umbraco.Cms.Core.Services;
using Umbraco.Extensions;

namespace Our.Umbraco.DictionaryLocalizer.Localization
{
    public class DictionaryStringLocalizer : IStringLocalizer
    {
        private readonly ILocalizationService _localizationService;
        public DictionaryStringLocalizer(ILocalizationService localizationService)
        {
            _localizationService = localizationService;
        }
        public LocalizedString this[string name]
        {
            get
            {
                var text = GetText(name, out bool notSucceed);

                return new LocalizedString(name, text, notSucceed);
            }
        }
        private string GetText(string name, out bool notSucceed)
        {
            var rVal = name;
            notSucceed = true;
            if (!name.StartsWith("#")) return rVal;

            var key = name[1..];
            rVal = key;
            var item = _localizationService.GetDictionaryItemByKey(key);
            if (item != null)
            {
                var languages = _localizationService.GetAllLanguages();
                var defaultLanguage = languages.FirstOrDefault(l => l.Id == (_localizationService.GetDefaultLanguageId() ?? -1));
                var language = languages.FirstOrDefault(l => l.CultureInfo == CultureInfo.CurrentCulture) ?? defaultLanguage;
                if (language != null)
                {
                    var text = item.GetTranslatedValue(language.Id);
                    if (!string.IsNullOrEmpty(text))
                    {
                        notSucceed = false;
                        rVal = text;
                    }
                }
            }

            return rVal;
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                var localizedString = this[name];
                return new LocalizedString(name, string.Format(localizedString.Value, arguments), localizedString.ResourceNotFound);
            }

        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            var rVal = new List<LocalizedString>();

            var languages = _localizationService.GetAllLanguages();
            var language = languages.FirstOrDefault(l => l.CultureInfo == CultureInfo.CurrentCulture);
            if (language == null && includeParentCultures)
            {
                language = languages.FirstOrDefault(l => l.Id == (_localizationService.GetDefaultLanguageId() ?? -1));
            }
            if (language != null)
            {
                var keyMap = _localizationService.GetDictionaryItemKeyMap();
                foreach (var key in keyMap)
                {
                    var item = _localizationService.GetDictionaryItemByKey(key.Key);
                    if (item != null)
                    {
                        var text = item.GetTranslatedValue(language.Id);
                        if (!string.IsNullOrEmpty(text))
                        {
                            var ls = new LocalizedString(key.Key, text, false);
                            rVal.Add(ls);
                        }
                    }
                }
            }

            return rVal;
        }
    }
}