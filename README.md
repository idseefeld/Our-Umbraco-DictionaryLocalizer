﻿# Our.Umbraco.DictionaryLocalizerPackage

This package adds Umbraco-dictionary based localisation e. g. models DataAnnotations.

Just prefix the name or error message with: #

```csharp
public class MyModel
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

## Umbraco version 10.x issue

For version 10.1+ the localizer will only in conjunction work for ModelsBuilder generated models. Otherwise the `[Dislpay(Name = "#nameLabel")]` translations will not work. This issue seems to be fixed in version 11. Version 10.0.0 and 10.0.1 do not handle `[Dislpay(Name = "#nameLabel")]` at all. But as a work-a-round you can use dictionary items directly in tag helpers.

You find two projects `Umbraco10.Website` (version 10.4.0) and `Umbraco11.Website` (version 11.1.0) showing a simple form in two languages. Open solution `OurDictionaryLocalizerWebiste.sln`, select one .Website and run Debug command. The interesting part is in `Models\ContactFormModel.cs`.

Back-Office login: `dirk.seefeld@idseefeld.de` and `Test!23456` 

## Runtime optimization

You can inherit your models from `Our.Umbraco.DictionaryLocalizer.Models.DictionaryDataAnnotationBaseModel` and add the following to the appSettings.json:

```json
"DictionaryLocalization": {
  "DataAnnotationOnly": true
}
```

Now *Our.Umbraco.DictionaryLocalizerPackage* is only registered or invoked for these model classes. This might also help mitigating conflicts too.

[Languages icons created by Freepik - Flaticon](https://www.flaticon.com/free-icons/languages)