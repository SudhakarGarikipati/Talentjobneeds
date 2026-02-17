using System.ComponentModel.DataAnnotations;

namespace JobNeedsWebApp.Models
{
    public class SignUpViewModel
    {
        public long UserId { get; set; }

        [Required(ErrorMessage ="First name is requried..")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is requried..")]
        public string LastName { get; set; } 

        [Required(ErrorMessage = "Email is requried..")]
        [EmailAddress(ErrorMessage = "Invalid email address..")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is requried..")]
        [Phone(ErrorMessage = "Invalid phone number..")]
        public string PhoneNumber { get; set; }  

        [Required(ErrorMessage = "Password is requried..")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long..")]
        public string Password { get; set; } 

        [Required(ErrorMessage = "Confirm password is requried..")]
        [Compare("Password", ErrorMessage = "Passwords do not match..")]
        public string ConfirmPassword { get; set; }

        public string Role { get; set; } = "Jobseeker";

    }
}
