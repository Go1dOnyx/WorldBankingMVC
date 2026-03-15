using System.Net;
//using WorldBankDBMVC.DataAcess.EF.Context;
//using WorldBankDBMVC.DataAcess.EF.Models;
//using WorldBankDBMVC.DataAcess.EF.Repositories;

namespace WorldBankDBMVC.Models
{
    public class AccountViewModel
    {
        public Guid UserID { get; set; }
        public string? EmailAddress { get; set; }
        public string? Password { get; set; } 
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime Created_At { get; set; }
        public bool RemeberMe { get; set; }

    }
}
