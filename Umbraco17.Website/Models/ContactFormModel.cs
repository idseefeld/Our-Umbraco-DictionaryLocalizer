using Our.Umbraco.DictionaryLocalizer.Models;
using System.ComponentModel.DataAnnotations;

namespace Umbraco17.Website.Models
{
    public class ContactFormModel : DictionaryDataAnnotationBaseModel
    {
        [Display(Name = "#nameLabel")]
        [Required(ErrorMessage = "#RequiredErrorMessage")]
        public string? FirstAndLastName { get; set; }

        [Display(Name = "#emailLabel")]
        [Required(ErrorMessage = "#RequiredErrorMessage")]
        [EmailAddress(ErrorMessage = "#InvalidErrorMessage")]
        public string? Email { get; set; }

        [Display(Name = "#subjectLabel")]
        [Required(ErrorMessage = "#RequiredErrorMessage")]
        public string? Subject { get; set; }

        [Display(Name = "#messageLabel")]
        [Required(ErrorMessage = "#RequiredErrorMessage")]
        public string? Message { get; set; }
    }
}
