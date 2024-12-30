using WorldBankDB.DataAccess.EF.Models;

namespace WorldBankDB.DataAccess.EF.Repositories.Contract
{
    public interface IAddressRepository
    {
        Task<List<Addresses>> GetAllAddrAsync();
        Task<Addresses?> GetAddrByIdAsync(int addrID);
        Task<Addresses?> GetAddrByStreetAsync(string street);
        Task<List<Addresses>> GetListAddrByUserIdAsync(Guid userID);
        Task<Addresses> CreateAddressAsync(Addresses addr);
        Task<Addresses> UpdateAddressAsync(Addresses addr);
        Task<bool> DeleteAddressAsync(Addresses addr);
    }
}
