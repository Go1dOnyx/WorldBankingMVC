using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing.Constraints;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WorldBankDB.DataAccess.EF.Models
{
    public class Users: IdentityUser<Guid>
    {
        //public Guid UserId { get; set; }
        //public string? Username { get; set; }
        //public string? EmailAddr { get; set; }
        //public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public int Phone {  get; set; }
        public string? Role {  get; set; }
        public string? Status { get; set; } //Frozen, suspended, blocked

        public ICollection<Accounts>? Accounts { get; set; }
        public ICollection<Addresses>? Addresses { get; set; }
        public ICollection<Cards>? Cards { get; set; }

        public Users(string first, string middle, string last, int phone, string role, string status, ICollection<Accounts> accts, ICollection<Addresses> addrs, ICollection<Cards> cards) 
        {
            FirstName = first;
            MiddleName = middle;
            LastName = last;
            Phone = phone;
            Role = role;
            Status = status;
            Accounts = accts;
            Addresses = addrs;
            Cards = cards; 
        }
        public Users() { }
    }
}
