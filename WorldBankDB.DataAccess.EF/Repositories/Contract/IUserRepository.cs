using WorldBankDB.DataAccess.EF.Models;

namespace WorldBankDB.DataAccess.EF.Repositories.Contract
{
    public interface IUserRepository
    {
        //UserManager handles creation, updating, deleting, password, etc.
        Task<Users?> GetUserByIdAsync(Guid userID);
        Task<List<Users>> GetAllUsersAsync();
    }
}
