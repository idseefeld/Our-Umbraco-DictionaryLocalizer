# Our.Umbraco.DictionaryLocalizerPackage
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
