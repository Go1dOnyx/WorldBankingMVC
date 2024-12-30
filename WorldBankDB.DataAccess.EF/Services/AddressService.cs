using WorldBankDB.DataAccess.EF.Models;
using WorldBankDB.DataAccess.EF.Repositories.Contract;
using WorldBankDB.DataAccess.EF.Services.Contract;

namespace WorldBankDB.DataAccess.EF.Services
{
    public class AddressService: IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        public AddressService(IAddressRepository addressRepository) 
        {
            _addressRepository = addressRepository;
        }
        public async Task<List<Addresses>> GetAllAsync() => await _addressRepository.GetAllAddrAsync();
        public async Task<Addresses> GetByIdAsync(int addrID) 
        {
            var getAddr = await _addressRepository.GetAddrByIdAsync(addrID);

            return getAddr ?? throw new InvalidOperationException("Could not find address.");
        }
        public async Task<Addresses> GetByStreetAsync(string street) 
        {
            var getAddr = await _addressRepository.GetAddrByStreetAsync(street);

            return getAddr ?? throw new InvalidOperationException("Could not find address.");
        }
        public async Task<List<Addresses>> GetListAddrByUserIdAsync(Guid userID) 
        {
            var getList = await _addressRepository.GetListAddrByUserIdAsync(userID);

            return getList ?? throw new InvalidOperationException("Could not retrieve list of addresses.");
        }
        public async Task<Addresses> RegisterAsync(Addresses addr) 
        {
            var addrExist = await _addressRepository.GetAddrByIdAsync(addr.AddressId);

            if (addr != null && addrExist == null) 
            {
                var addAddr = await _addressRepository.CreateAddressAsync(addr);

                if (addAddr != null) return addAddr;
            }

            throw new InvalidOperationException("Could not add address or already exist.");
        }
        public async Task<Addresses> EditAsync(Addresses addr)
        {
            if (addr != null) return await _addressRepository.UpdateAddressAsync(addr);

            throw new ArgumentNullException(nameof(addr));
        }
        public async Task<bool> DeleteAsync(Addresses addr)
        {
            if (addr != null) return await _addressRepository.DeleteAddressAsync(addr);

            throw new ArgumentNullException(nameof(addr));
        }
    }
}
