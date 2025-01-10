using Microsoft.AspNetCore.Identity;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WorldBankDB.DataAccess.EF.Models
{
    public partial class Users: IdentityUser
    {
        public Guid UserId { get; set; }
        public string? Username { get; set; }
        public string? EmailAddr { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Role {  get; set; }
        public string? Status { get; set; }

        public ICollection<Accounts>? Accounts { get; set; }
        public ICollection<Addresses>? Addresses { get; set; }

        public Users(Guid userID, string user, string email,string pass, string first, string middle, string last, string role, string status, ICollection<Accounts> accts, ICollection<Addresses> addrs) 
        {
            UserId = userID;
            Username = user;
            EmailAddr = email;
            Password = pass;
            FirstName = first;
            MiddleName = middle;
            LastName = last;
            Role = role;
            Status = status;
            Accounts = accts;
            Addresses = addrs;
        }
        public Users() { }
    }
}
