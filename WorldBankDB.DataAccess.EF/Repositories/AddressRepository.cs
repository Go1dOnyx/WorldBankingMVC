using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBankDB.DataAccess.EF.Repositories.Contract;
using WorldBankDB.DataAccess.EF.Models;
using WorldBankDB.DataAccess.EF.Context;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;


namespace WorldBankDB.DataAccess.EF.Repositories
{
    public class AddressRepository: IAddressRepository
    {
        private WorldBankDBContext _context;
        public AddressRepository(WorldBankDBContext context) 
        {
            _context = context;
        }
        public async Task<Addresses> CreateAddressAsync(Addresses addr) 
        {
            if (addr != null) 
            {
                try 
                {
                    await _context.AddAsync(addr);
                    await _context.SaveChangesAsync();
                    await _context.SaveChangesAsync();

                    return addr;
                }
                catch (Exception ex) 
                {
                    throw new InvalidOperationException($"Addresses could not be created. Error: {ex.Message}");
                }
            }

            throw new InvalidOperationException("Invalid model data or empty.");
        }
        public async Task<Addresses> UpdateAddressAsync(Addresses addr) 
        {
            Addresses updateAddr = await _context.Addresses.FindAsync(addr.AddressId);

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
            Addresses getAddr = await _context.Addresses.FindAsync(addrID);

            await _context.DisposeAsync();

            if (getAddr != null)
                return getAddr;
            else 
                throw new InvalidOperationException("Could not find address by ID.");
        }
        public async Task<List<Addresses>> GetAllAddrAsync()
        {
            List<Addresses> addrList = await _context.Addresses.ToListAsync();

            await _context.DisposeAsync();

            if (addrList != null)
                return addrList;
            else
                throw new InvalidOperationException("Could not retrieve the list of all addresses.");
        }
        public async Task<bool> DeleteAddressAsync(Addresses addr) 
        {
            Addresses delAddr = await _context.Addresses.FindAsync(addr.AddressId);

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
