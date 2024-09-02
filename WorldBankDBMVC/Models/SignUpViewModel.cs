//using WorldBankDBMVC.DataAcess.EF.Context;
//using WorldBankDBMVC.DataAcess.EF.Models;
//using WorldBankDBMVC.DataAcess.EF.Repositories;

namespace WorldBankDBMVC.Models
{
    public class SignUpViewModel
    {
        //Sign up form properties
        public string EmailAddress { get; set; } 
        public string UserName { get; set; } 
        public string Password { get; set; }    
        public string FirstName { get; set; }
        public string? MiddleName { get; set; } //? help to controll null values
        public string LastName { get; set; }
        public decimal CheckingBalance { get; set; }
        public decimal SavingsBalance { get; set; }

        //Properties to check if validation is true (correct formart)


    }
}
