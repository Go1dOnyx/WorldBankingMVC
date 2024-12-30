using WorldBankDB.DataAccess.EF.Models;

namespace WorldBankDB.DataAccess.EF.Services.Contract
{
    public interface IAddressService
    {
        Task<List<Addresses>> GetAllAsync();
        Task<Addresses> GetByIdAsync(int addrID);
        Task<Addresses> GetByStreetAsync(string street);
        Task<List<Addresses>> GetListAddrByUserIdAsync(Guid userID);
        Task<Addresses> RegisterAsync(Addresses addr);
        Task<Addresses> EditAsync(Addresses addr);
        Task<bool> DeleteAsync(Addresses addr); 
    }
}
