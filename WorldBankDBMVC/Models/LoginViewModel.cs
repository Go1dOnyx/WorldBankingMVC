using System.ComponentModel.DataAnnotations;

namespace WorldBankDBMVC.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Enter Username or Email")]
        public string? UserEmail { get; set; }

        [Required]
        [Display(Name = "Enter Password")]
        public string? Password { get; set; }    
        public LoginViewModel(string userEmail, string pass) 
        {
            UserEmail = userEmail;
            Password = pass;
        }
    }
}
