using System.Net;
using WorldBankDBMVC.DataAcess.EF.Context;
using WorldBankDBMVC.DataAcess.EF.Models;
using WorldBankDBMVC.DataAcess.EF.Repositories;

namespace WorldBankDBMVC.Models
{
    public class AccountViewModel
    {
        public int AccountID { get; set; }
        public string UserName { get; set; } = "";
        public string EmailAddress { get; set; }
        public string Password { get; set; } = ""; 
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public decimal CheckingAccount { get; set; }
        public decimal SavingsAccount { get; set; }

        //Admin Class Properties 
        public List<Accounts> GetAccountList { get; set; } 
        //Checking User roles 
        public UserRoles AccountRules { get; set; }
        public string[] AdminNameList = {"Admin1","Admin2","Admin3","Admin4"};

        public AccountViewModel() { }

        //To distinguish between admin and standard users
        public enum UserRoles { 
            AdminUser,
            StandardUser
        }
    }
}
