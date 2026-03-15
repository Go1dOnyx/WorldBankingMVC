using Microsoft.AspNetCore.Identity;
using WorldBankDB.DataAccess.EF.Models;

namespace WorldBankDB.DataAccess.EF.Services.Contract
{
    public interface IUserService
    {
        Task<SignInResult> LoginAsync(string email, string password, bool rememberMe);
        Task<IdentityResult> RegisterAsync(Users user);
        Task<IdentityResult> DeleteAsync(Users user);
        Task<IdentityResult> UpdateAsync(Users user);
        Task<string?> GeneratePasswordResetTokenAsync(string email);
        Task<IdentityResult> ResetPasswordAsync(string email, string token, string newPassword);
        Task<Users?> GetByIdAsync(Guid userID);
        Task<List<Users>> GetAllAsync();
        Task LogoutAsync();
    }
}
