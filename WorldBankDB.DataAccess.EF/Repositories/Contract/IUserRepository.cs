using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBankDB.DataAccess.EF.Models;

namespace WorldBankDB.DataAccess.EF.Repositories.Contract
{
    internal interface IUserRepository
    {
        //Identity use methods
        Task<IdentityResult> CreateUserAsync(Users user);
        Task<SignInResult> LoginUserAsync(string userEmail, string pass, bool isPersistent, bool lockoutOnFailure);
        Task SignOutUserAsync();

        //Regular methods
        Task<Users> UpdateUserAsync(Users user);
        Task<Users> GetUserByIdAsync(Guid userID);
        Task<List<Users>> GetAllUsersAsync();
        Task<bool> DeleteUserAsync(Users user);
    }
}
