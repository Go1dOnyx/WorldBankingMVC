using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing.Constraints;

namespace WorldBankDB.DataAccess.EF.Models
{
    public class Users: IdentityUser<Guid>
    {
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        //Navigation Property
        public ICollection<BankAccounts>? BankAccounts { get; set; }
    }
}
