using System.ComponentModel.DataAnnotations;

namespace Vize.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email Required.")]
        [EmailAddress(ErrorMessage = "İnvalid Email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
