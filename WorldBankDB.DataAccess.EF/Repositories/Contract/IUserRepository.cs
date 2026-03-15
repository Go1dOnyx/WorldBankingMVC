using WorldBankDB.DataAccess.EF.Models;

namespace WorldBankDB.DataAccess.EF.Repositories.Contract
{
    public interface IUserRepository
    {
        Task<Users?> GetUserByIdAsync(Guid userID);
        Task<List<Users>> GetAllUsersAsync();
    }
}
