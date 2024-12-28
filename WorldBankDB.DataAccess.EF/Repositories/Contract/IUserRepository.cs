using Microsoft.AspNetCore.Identity;
using WorldBankDB.DataAccess.EF.Models;

namespace WorldBankDB.DataAccess.EF.Repositories.Contract
{
    public interface IUserRepository
    {
        //Identity use methods
        Task<IdentityResult> CreateUserAsync(Users user);
        Task<IdentityResult> DeleteUserAsync(Users user);
        Task<SignInResult> LoginUserAsync(string userEmail, string pass);
        Task<IdentityResult> ChangePasswordAsync(string userEmail, string oldPassword, string newPassword);
        Task<IdentityResult> UpdateUserAsync(Users user);
        Task SignOutUserAsync();

        //Regular methods
        Task<Users> GetUserByUserEmailAsync(string userEmail);
        Task<Users> GetUserByIdAsync(Guid userID);
        Task<List<Users>> GetAllUsersAsync();

        //Add Methods to handle tokens, cookies, password hashes, email verification
        //etc.
    }
}
