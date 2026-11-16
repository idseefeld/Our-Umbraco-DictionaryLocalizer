using Our.Umbraco.DictionaryLocalizer.Localization;
using Umbraco.Cms.Core.Composing;
using Umbraco19.Website.Models;

namespace Umbraco19.Website.Services
{
    public class MailOptionComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder) => builder.Services
            .Configure<ContactMailOptions>(builder.Config.GetSection(ContactMailOptions.ContactMail));
        
    }
}
