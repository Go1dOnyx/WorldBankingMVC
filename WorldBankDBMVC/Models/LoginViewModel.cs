using System.ComponentModel.DataAnnotations;

namespace WorldBankDBMVC.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username or Email")]
        public string? UserEmail { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string? Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

        public string? ErrorMessage { get; set; }
        public LoginViewModel(string userEmail, string pass) 
        {
            UserEmail = userEmail;
            Password = pass;
        }
        public LoginViewModel() { }
    }
}
