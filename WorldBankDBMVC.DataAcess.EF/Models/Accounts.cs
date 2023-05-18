using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WorldBankDBMVC.DataAcess.EF.Models
{
    public partial class Accounts
    {
        //If any issues persists check on the null for the properties
        [Key]
        public int AccountId { get; set; }
        public string UserName { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public decimal CheckingBalance { get; set; }
        public decimal SavingBalance { get; set; }

        public Accounts(int acctID, string userName, string emailAddr, string pass, string firstN, string middleN, string lastN, decimal checkB, decimal savB) {
            AccountId = acctID;
            UserName = userName;
            EmailAddress = emailAddr;
            Password = pass;
            FirstName = firstN;
            MiddleName = middleN;
            LastName = lastN;
            CheckingBalance = checkB;
            SavingBalance = savB; 
        }
        public Accounts()
        {

        }
    }
}
