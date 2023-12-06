using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.Models
{
    public class ForgotPassword
    {
        [Required(ErrorMessage = "Please enter your username.")]
        [StringLength(255)]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your email.")]
        [StringLength(255)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a new password.")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please confirm new password.")]
        [DataType(DataType.Password)]
        public string ConfirmedPassword { get; set; } = string.Empty;
    }
}
