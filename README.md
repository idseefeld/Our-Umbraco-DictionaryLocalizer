# Our.Umbraco.DictionaryLocalizerPackage

This package adds Umbraco-dictionary based localisation e. g. models DataAnnotations.

Just prefix the name or error message with: #

```csharp
using Our.Umbraco.DictionaryLocalizer.Models;
using System.ComponentModel.DataAnnotations;

public class MyModel : DictionaryDataAnnotationBaseModel
{
  [Dislpay(Name = "#nameLabel")]
  [Required(ErrorMessage = "#nameRequired")]
  public string Name { get; set; }  
  
  [Dislpay(Name = "#emailLabel")]
  [EmailAddress(ErrorMessage = "#emailInvalid")]
  [Required(ErrorMessage = "#emailRequired")]
  public string Email { get; set; }
  
  ...
}
```

In Back-Office section Translations add items: nameLabel, emailLabel, nameRequired, emailInvalid etc.

## Demo Website

You find a project `Umbraco13.Website` (version 13.9.2) showing a simple form in two languages. Open solution `OurDictionaryLocalizerWebiste.sln`, 
select one .Website and run Debug command. 
The interesting part is in `Models\ContactFormModel.cs`.

When you follow the unattended install as it is configured in appsettings.json, the package will be installed automatically.

**Back-Office login: `admin@example.com` and `1234567890`**

After installition go to settings section open uSync dasboard and install all.

## Runtime optimization

You can inherit your models from `Our.Umbraco.DictionaryLocalizer.Models.DictionaryDataAnnotationBaseModel` and add the following to the appSettings.json:

```json
"DictionaryLocalization": {
  "DataAnnotationOnly": true
}
```

Now *Our.Umbraco.DictionaryLocalizerPackage* is only registered or invoked for these model classes. This might also help mitigating conflicts too.

[Languages icons created by Freepik - Flaticon](https://www.flaticon.com/free-icons/languages)