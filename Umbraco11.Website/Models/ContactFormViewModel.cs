using Umbraco.Cms.Web.Common;

namespace Umbraco11.Website.Models
{
    public class ContactFormViewModel : ContactFormModel
    {
        private readonly UmbracoHelper? _umbraco;

        public UmbracoHelper? Umbraco
        {
            get
            {
                return _umbraco;
            }
        }

        public ContactFormViewModel() { }
        public ContactFormViewModel(UmbracoHelper umbraco)
        {
            _umbraco = umbraco;
        }
    }
}