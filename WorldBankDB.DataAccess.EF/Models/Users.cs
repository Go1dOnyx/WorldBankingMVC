using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing.Constraints;

namespace WorldBankDB.DataAccess.EF.Models
{
    public enum UserStatus
    {
        Active = 1,
        Suspended = 2,
        Terminated = 3
    }
    public class Users: IdentityUser<Guid>
    {
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public UserStatus Status { get; set; } = UserStatus.Active;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        //Navigation Property
        public ICollection<BankAccounts>? BankAccounts { get; set; }
    }
}
