using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBankDB.DataAccess.EF.Models;

namespace WorldBankDB.DataAccess.EF.Repositories.Contract
{
    public interface IAddressRepository
    {
        Task<List<Addresses>> GetAllAddrAsync();
        Task<Addresses> CreateAddressAsync(Addresses addr);
        Task<Addresses> UpdateAddressAsync(Addresses addr);
        Task<Addresses> GetAddrByIdAsync(Guid addrID);
        Task<bool> DeleteAddressAsync(Addresses addr);
    }
}
