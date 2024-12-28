using Microsoft.AspNetCore.Identity;
using WorldBankDB.DataAccess.EF.Models;

namespace WorldBankDB.DataAccess.EF.Services.Contract
{
    public interface IUserService
    {
        //Identity
        Task<IdentityResult> RegisterAsync(Users user);
        Task<IdentityResult> DeleteAsync(Users user);
        Task<SignInResult> LoginAsync(string userEmail, string password);
        Task<IdentityResult> ChangePasswordAsync(string userEmail, string oldPassword, string newPassword);
        Task<IdentityResult> EditAsync(Users user);
        Task SignOutAsync();

        //Regular
        Task<Users> GetByIdAsync(Guid userID);
        Task<Users> GetByEmailAsync(string userEmail);
        Task<List<Users>> GetAllAsync();
    }
}
