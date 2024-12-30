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
        public async Task<Addresses?> GetAddrByIdAsync(int addrID) => await _context.Addresses.FindAsync(addrID);
        public async Task<Addresses?> GetAddrByStreetAsync(string street) => await _context.Addresses.FirstOrDefaultAsync(x => x.Street == street);
        public async Task<List<Addresses>> GetListAddrByUserIdAsync(Guid userID) => await _context.Addresses.Where(e => e.UserId == userID).ToListAsync();
        public async Task<Addresses> CreateAddressAsync(Addresses addr) 
        {
            await _context.AddAsync(addr);
            await _context.SaveChangesAsync();

            return addr;
        }
        public async Task<Addresses> UpdateAddressAsync(Addresses addr) 
        {
            var updateAddr = await _context.Addresses.FindAsync(addr.AddressId);

            if (updateAddr == null) { throw new InvalidOperationException("Could not find address."); }

            updateAddr.Street = addr.Street;
            updateAddr.Apt = addr.Apt;
            updateAddr.City = addr.City;
            updateAddr.Country = addr.Country;
            updateAddr.ZipCode = addr.ZipCode;

            try 
                {
                    await _context.SaveChangesAsync();
                    return updateAddr;
                }
                catch (Exception ex) { throw new InvalidOperationException($"Address could not be updated. Error: {ex.Message}"); }
        }
        public async Task<bool> DeleteAddressAsync(Addresses addr) 
        {
            var delAddr = await _context.Addresses.FindAsync(addr.AddressId);

            if (delAddr == null) { throw new InvalidOperationException("Could not find address."); }

            try
            {
                _context.Remove(delAddr);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { throw new InvalidOperationException($"Could not delete address. {ex.Message}"); }
        }
    }
}
