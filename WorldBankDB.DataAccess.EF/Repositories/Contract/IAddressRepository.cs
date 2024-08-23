using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBankDB.DataAccess.EF.Models;

namespace WorldBankDB.DataAccess.EF.Repositories.Contract
{
    internal interface IAddressRepository
    {
        Task<Addresses> CreateAddressAsync(Addresses addr);
        Task<Addresses> UpdateAddressAsync(Addresses addr);
        Task<Addresses> GetAddrByIdAsync(Guid addrID);
        Task<List<Addresses>> GetAllAddrAsync();
        Task<bool> DeleteAddressAsync(Addresses addr);
    }
}
