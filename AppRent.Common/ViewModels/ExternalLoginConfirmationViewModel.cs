using System.ComponentModel.DataAnnotations;


namespace AppRent.Common.ViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Hometown")]
        public string Hometown { get; set; }
    }
}
