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
        private readonly ILanguageService _languageService;
        private readonly IDictionaryItemService _dictionaryItemService;
        public DictionaryStringLocalizer(ILanguageService languageService, IDictionaryItemService dictionaryItemService)
        {
            _languageService = languageService;
            _dictionaryItemService = dictionaryItemService;
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
            var item = _dictionaryItemService.GetAsync(key).Result;
            if (item != null)
            {
                var languages = _languageService.GetAllAsync().Result;
                var currentCulture = System.Threading.Thread.CurrentThread.CurrentCulture;
                var defaultLanguage = languages.FirstOrDefault(l => l.Id == (_languageService.GetDefaultLanguageAsync().Result?.Id ?? -1));
                var language = languages.FirstOrDefault(l => l.CultureInfo.Name == currentCulture.Name) ?? defaultLanguage;
                if (language != null)
                {
                    var text = item.GetTranslatedValue(language.IsoCode);
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

            var languages = _languageService.GetAllAsync().Result;
            var language = languages.FirstOrDefault(l => l.CultureInfo == CultureInfo.CurrentCulture);
            if (language == null && includeParentCultures)
            {
                language = languages.FirstOrDefault(l => l.Id == (_languageService.GetDefaultLanguageAsync().Result?.Id ?? -1));
            }
            if (language != null)
            {
                var allDictEntries = _dictionaryItemService.GetPagedAsync(null,0,10000).Result;
                foreach (var entry in allDictEntries.Items)
                {
                    var item = _dictionaryItemService.GetAsync(entry.Key).Result;
                    if (item != null)
                    {
                        var text = item.GetTranslatedValue(language.IsoCode);
                        if (!string.IsNullOrEmpty(text))
                        {
                            var ls = new LocalizedString(item.ItemKey, text, false);
                            rVal.Add(ls);
                        }
                    }
                }
            }

            return rVal;
        }
    }
}