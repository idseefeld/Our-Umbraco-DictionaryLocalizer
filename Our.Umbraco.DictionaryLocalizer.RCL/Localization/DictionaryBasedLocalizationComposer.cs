using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Our.Umbraco.DictionaryLocalizer.Localization
{
    public class DictionaryBasedLocalizationComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder) => builder.Services
            .Configure<DictionaryLocalizationOptions>(builder.Config.GetSection(DictionaryLocalizationOptions.DictionaryLocalization))
            .AddDictionaryLocalization()
            .AddMvc()
            .AddDataAnnotationsLocalization();
    }
}
