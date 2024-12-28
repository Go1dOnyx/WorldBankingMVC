using WorldBankDB.DataAccess.EF.Repositories.Contract;
using WorldBankDB.DataAccess.EF.Models;
using WorldBankDB.DataAccess.EF.Context;
using Microsoft.EntityFrameworkCore;


namespace WorldBankDB.DataAccess.EF.Repositories
{
    public class AddressRepository: IAddressRepository
    {
        private WorldBankDBContext _context;
        public AddressRepository(WorldBankDBContext context) 
        {
            _context = context;
        }
        public async Task<List<Addresses>> GetAllAddrAsync() => await _context.Addresses.ToListAsync();
        public async Task<Addresses> CreateAddressAsync(Addresses addr) 
        {
            await _context.AddAsync(addr);
            await _context.SaveChangesAsync();

            return addr;
        }
        public async Task<Addresses> UpdateAddressAsync(Addresses addr) 
        {
            var updateAddr = await _context.Addresses.FindAsync(addr.AddressId);

            if (updateAddr == null) { throw new InvalidOperationException("Could not find account."); }

            if (updateAddr != null) 
            {
                try 
                {
                    updateAddr.UserId = updateAddr.UserId;
                    updateAddr.Street = addr.Street;
                    updateAddr.Apt = addr.Apt;
                    updateAddr.City = addr.City;
                    updateAddr.Country = addr.Country;
                    updateAddr.ZipCode = addr.ZipCode;

                    await _context.SaveChangesAsync();
                    await _context.DisposeAsync();

                    return updateAddr;
                }
                catch (Exception ex) 
                {
                    throw new InvalidOperationException($"Address could not be updated. Error: {ex.Message}");
                }
            }

            throw new InvalidOperationException("Invalid model data or empty.");
        }
        public async Task<Addresses> GetAddrByIdAsync(Guid addrID) 
        {
            var getAddr = await _context.Addresses.FindAsync(addrID);

            await _context.DisposeAsync();

            if (getAddr != null)
                return getAddr;
            else 
                throw new InvalidOperationException("Could not find address by ID.");
        }
        public async Task<bool> DeleteAddressAsync(Addresses addr) 
        {
            var delAddr = await _context.Addresses.FindAsync(addr.AddressId);

            if (delAddr != null) 
            {
                try
                {
                    _context.Remove(delAddr);

                    await _context.SaveChangesAsync();

                    await _context.DisposeAsync();

                    return true;
                }
                catch (Exception ex) 
                {
                    throw new InvalidOperationException($"Could not delete account. Error: {ex.Message}");
                }
            }

            throw new InvalidOperationException("Could not find account.");
        }
    }
}
