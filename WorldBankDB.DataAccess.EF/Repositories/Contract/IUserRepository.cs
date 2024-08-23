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
        Task<Users> CreateUserAsync(Users user);
        Task<Users> UpdateUserAsync(Users user);
        Task<Users> GetUserByIdAsync(Guid userID);
        Task<List<Users>> GetAllUsersAsync();
        Task<bool> DeleteUserAsync(Guid userID);
    }
}
