# Our.Umbraco.DictionaryLocalizerPackage

[![Downloads](https://img.shields.io/nuget/dt/Our.Umbraco.DictionaryLocalizer?color=cc9900)](https://www.nuget.org/packages/Our.Umbraco.DictionaryLocalizer/)
[![NuGet](https://img.shields.io/nuget/vpre/Our.Umbraco.DictionaryLocalizer?color=0273B3)](https://www.nuget.org/packages/Our.Umbraco.DictionaryLocalizer)
[![GitHub license](https://img.shields.io/github/license/idseefeld/Our-Umbraco-DictionaryLocalizer?color=8AB803)](../LICENSE)

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

In Backoffice section Translations add items: nameLabel, emailLabel, nameRequired, emailInvalid etc.

## Demo Website

You find a project `Umbraco17.Website` (version 17.8.1) showing a simple form in two languages. Open solution `OurDictionaryLocalizerWebiste.sln`, 
select one .Website and run Debug command. 
The interesting part is in `Models\ContactFormModel.cs`.

After installition go to settings section open uSync dashboard and install all.

## Runtime optimization

You can inherit your models from `Our.Umbraco.DictionaryLocalizer.Models.DictionaryDataAnnotationBaseModel` and add the following to the appSettings.json:

```json
"DictionaryLocalization": {
  "DataAnnotationOnly": true
}
```

Now *Our.Umbraco.DictionaryLocalizerPackage* is only registered or invoked for these model classes. This might also help mitigating conflicts too.

[Languages icons created by Freepik - Flaticon](https://www.flaticon.com/free-icons/languages)
