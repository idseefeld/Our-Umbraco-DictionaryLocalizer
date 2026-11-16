namespace Our.Umbraco.DictionaryLocalizer.Localization
{
    public class DictionaryLocalizationOptions
    {
        public const string DictionaryLocalization = "DictionaryLocalization";
        public bool DataAnnotationOnly { get; set; }
        public string DictionaryPrefix { get; set; }
        public void UseSettings(bool dataAnnotationOnly, string dictionaryPrefix)
        {
            DataAnnotationOnly = dataAnnotationOnly;
            DictionaryPrefix = dictionaryPrefix;
        }
    }
}
