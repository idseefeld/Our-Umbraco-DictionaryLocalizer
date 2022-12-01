using System.ComponentModel.DataAnnotations;

namespace Umbraco10_0_0.Website.Models
{
    public class ContactFormModel : Our.Umbraco.DictionaryLocalizer.Models.DictionaryDataAnnotationBaseModel
    {
        [Required(ErrorMessage = "#RequiredErrorMessage.name")]
        [Display(Name = "#nameLabel")]
        public string? FirstAndLastName { get; set; }

        [Required(ErrorMessage = "#RequiredErrorMessage.email")]
        [EmailAddress(ErrorMessage = "#InvalidErrorMessage.email")]
        [Display(Name = "#emailLabel")]
        public string? Email { get; set; }

        [Display(Name = "#subjectLabel")]
        [Required(ErrorMessage = "#RequiredErrorMessage.subject")]
        public string? Subject { get; set; }

        [Display(Name = "#messageLabel")]
        [Required(ErrorMessage = "#RequiredErrorMessage.message")]
        public string? Message { get; set; }
    }
}
